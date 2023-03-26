using Azure.Core;
using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using System.Net;
using System.Net.Http.Headers;
using Minio;
using Minio.Exceptions;
using Minio.DataModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace objStorageServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        // GET: api/<FileController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<FileController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        //// POST api/<FileController>
        //[HttpPost]
        //public async Task<ActionResult<string>> Post([FromBody] .File file)
        //{
        //    IFormFileCollection files = .Form.Files;
        //    // путь к папке, где будут храниться файлы
        //    var uploadPath = $"{Directory.GetCurrentDirectory()}/uploads";
        //    // создаем папку для хранения файлов
        //    Directory.CreateDirectory(uploadPath);

        //    foreach (var file in files)
        //    {
        //        // путь к папке uploads
        //        string fullPath = $"{uploadPath}/{file.FileName}";

        //        // сохраняем файл в папку uploads
        //        using (var fileStream = new FileStream(fullPath, FileMode.Create))
        //        {
        //            await file.CopyToAsync(fileStream);
        //        }
        //    }
        //    return "Файлы успешно загружены";
        //}


        // POST api/<FileController>
        [EnableCors("Policy1")]
        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> OnPostUploadAsync(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);
            var uploadPath = $"{Directory.GetCurrentDirectory()}/Files";

            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    var fileName = formFile.FileName;

                    // Файл загружается на комп, иначе в минио он будет пустой
                    // Удаления файлов с компа нет, как говорится, ебитесь сами
                    string fullPath = $"{uploadPath}/{fileName}";
                    using (var stream = System.IO.File.Create(fullPath))
                    {
                        await formFile.CopyToAsync(stream);
                    }

                    // MINIO
                    var endpoint = "localhost:9000";
                    var accessKey = "4rWYXZPXkTn9UPoO";
                    var secretKey = "PNFnV4Xmd8TIoZ8KBgFiacng92lmPUK7";
                    var bucketName = "marrrr";
                    var objectName = fileName;
                    var contentType = "application/octet-stream";

                    try
                    {
                        var minio = new MinioClient()
                                            .WithEndpoint(endpoint)
                                            .WithCredentials(accessKey, secretKey)
                                            .WithSSL(false)
                                            .Build();

                        // Make a bucket on the server, if not already present.
                        var beArgs = new BucketExistsArgs()
                            .WithBucket(bucketName);
                        bool found = await minio.BucketExistsAsync(beArgs).ConfigureAwait(false);
                        if (!found)
                        {
                            var mbArgs = new MakeBucketArgs()
                                .WithBucket(bucketName);
                            await minio.MakeBucketAsync(mbArgs).ConfigureAwait(false);
                        }
                        // Upload a file to bucket.
                        var putObjectArgs = new PutObjectArgs()
                            .WithBucket(bucketName)
                            .WithObject(objectName)
                            .WithFileName(fullPath)
                            .WithContentType(contentType);
                        await minio.PutObjectAsync(putObjectArgs).ConfigureAwait(false);
                        Console.WriteLine("Successfully uploaded " + objectName);
                    }
                    catch (MinioException e)
                    {
                        Console.WriteLine("File Upload Error: {0}", e.Message);
                    }
                }
            }

            return Ok(new { count = files.Count, size });
        }

        // PUT api/<FileController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FileController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

using Azure.Core;
using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

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
        [HttpPost]
        public async Task<IActionResult> Post(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);

            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    var filePath = Path.Combine("objStorageServer.Files",
                        Path.GetRandomFileName());

                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }

            // Process uploaded files
            // Don't rely on or trust the FileName property without validation.

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

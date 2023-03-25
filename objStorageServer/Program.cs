using Microsoft.EntityFrameworkCore;
using objStorageServer.Models;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("Policy1",
        policy =>
        {
            policy.WithOrigins(objStorageServer.AllowedHosts.hostUrl).AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials(); 
        });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<StorageDbContext>(opt =>
    //opt.UseSqlite("objStorage.db"));
    opt.UseInMemoryDatabase("objStorage.db"));
builder.Services.AddSwaggerGen();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();

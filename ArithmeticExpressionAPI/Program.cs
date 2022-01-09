using Microsoft.Extensions.PlatformAbstractions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

//Swagger configs
builder.Services.AddSwaggerGen();
builder.Services.ConfigureSwaggerGen(options =>
{
    var basePath = PlatformServices.Default.Application.ApplicationBasePath;
    options.IncludeXmlComments(basePath + "\\ArithmeticExpressionAPI.xml");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

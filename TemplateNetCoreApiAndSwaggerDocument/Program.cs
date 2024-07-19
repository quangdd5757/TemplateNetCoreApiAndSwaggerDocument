using Microsoft.AspNetCore.Mvc.ApiExplorer;
using TemplateNetCoreApiAndSwaggerDocument.Extensions;
using TemplateNetCoreApiAndSwaggerDocument.Extensions.MultiExample;
using TemplateNetCoreApiAndSwaggerDocument.Modesl;
using TemplateNetCoreApiAndSwaggerDocument.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<BookStoreDatabaseSettings>(  // BookStoreDatabase trong file appsetting.json được đăng ký vào Dependency Injection (DI)
    builder.Configuration.GetSection("BookStoreDatabase")); // thuộc tính trong BookStoreDatabaseSetting sẽ liên kết với thuộc tính trong BookStoreDatabase trong appsetting.json

builder.Services.AddSingleton<BooksService>(); // đăng ký BookService vào DI

#region config swagger document
// Configure the API versioning properties of the project.
//builder.Services.AddApiVersioningConfigured();

// Add a Swagger generator and Automatic Request and Response annotations:
builder.Services.AddSwaggerSwashbuckleConfigured();
// Multi example
builder.Services.AddSwaggerGen(c => c.ParameterFilter<CustomParameterFilter>());
#endregion

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Enable middleware to serve the generated OpenAPI definition as JSON files.
    app.UseSwagger();
    app.UseSwaggerUI();

    // sử dụng cho logic version
    // Enable middleware to serve Swagger-UI (HTML, JS, CSS, etc.) by specifying the Swagger JSON endpoint(s).
    //var descriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
    //app.UseSwaggerUI(options =>
    //{
    //    // Build a swagger endpoint for each discovered API version
    //    foreach (var description in descriptionProvider.ApiVersionDescriptions)
    //    {
    //        options.SwaggerEndpoint($"{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
    //    }
    //});
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

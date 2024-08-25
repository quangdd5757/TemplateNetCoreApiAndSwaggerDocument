Web API document (Swashbuckle Tool)
# Giới thiệu
- đây là tài liệu mẫu nhằm khởi tạo 1 project mới
- project này phát triển trên nền tàng ASP.NET core 6.0 API kết nối tới database MongoDB, nhằm sử dụng swagger/openApi để tạo document trong quá trình code, bao gồm:
    - Authorization Type (api key, bearer token, authorization code,...)
    - Action Method: endpoint, HTTP method, header,...
    - Data Contract: mô tả dữ liệu nhận/trả như: name, type, restriction (hạn chế, valid),...
    - Example: ví dụ sử dụng web Api
- bằng việc sử dụng OpenApi trong project, chúng ta có thể tự động tạo tài liệu trực tiếp từ source code thông qua chú thích (the data annotations), XML comment và ví dụ dựa trên các dữ liệu thực tế truyền vào các class
# môi trường
- ASP.NET core 6.0 API
- MongoDB.Driver
- Microsoft.AspNetCore.Mvc.Versioning.ApiExplorer
- Swashbuckle.AspNetCore.Filters
- MicroElements.Swashbuckle.FluentValidation.AspNetCore
- Swashbuckle.AspNetCore.Annotations

# hướng dẫn chi tiết (từ nguồn [link](https://www.dotnetnakama.com/blog/enriched-web-api-documentation-using-swagger-openapi-in-asp-dotnet-core/]))
1. khởi tạo project ASP.NET core API mẫu
2. install package Microsoft.AspNetCore.Mvc.Versioning.ApiExplorer
    -  config thuộc tính Api versioning
        ```C#
        // Configure the API versioning properties of the project.
        builder.Services.AddApiVersioningConfigured();
        ```
    - config swagger dựa trên nhu cầu riêng
        ```C#
        // Add a Swagger generator and Automatic Request and Response annotations:
        builder.Services.AddSwaggerSwashbuckleConfigured();
        ```
    - config thông tin cơ bản (title, description, license,...)
        ```C#
        var info = new OpenApiInfo()
        {
            Title = "Web API Documentation Tutorial",
            Version = description.ApiVersion.ToString(),
            Description = "A tutorial project to provide documentation for our existing APIs.",
            Contact = new OpenApiContact() { Name = "Ioannis Kyriakidis", Email = "info@dotnetnakama.com" },
            License = new OpenApiLicense() { Name = "MIT License", Url = new Uri("https://opensource.org/licenses/MIT") }
        };
        ```
    - add UseSwagger() và UseSwaggerUI() vào Program.cs
    - để enable tính năng tạo tệp document, nên set GenerateDocumentationFile option = true
        ```C#
        <PropertyGroup>
            <GenerateDocumentationFile>True</GenerateDocumentationFile>
            <NoWarn>$(NoWarn);1591</NoWarn>
        </PropertyGroup>
        ```

# kết quả
- swagger mặc định
![Swagger Default](/TemplateNetCoreApiAndSwaggerDocument/Docs/SwaggerBefore.png)

- swagger sau khi đã update generate
![Swagger After](/TemplateNetCoreApiAndSwaggerDocument/Docs/SwaggerAfter.png)

# các nội dung khác
- Swagger Param Route nhiều lựa chọn [Link](https://medium.com/@niteshsinghal85/multiple-example-for-parameters-in-swagger-with-asp-net-core-c4f3aaf1ae9f)
- Swagger Param Route cho phép empty [Link](https://www.seeleycoder.com/blog/optional-route-parameters-with-swagger-asp-net-core/)
```
chú ý việc áp dụng empty ko dùng chung được với attribute quy định length(24) của param
```
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TemplateNetCoreApiAndSwaggerDocument.Extensions;
using TemplateNetCoreApiAndSwaggerDocument.Extensions.MultiExample;
using TemplateNetCoreApiAndSwaggerDocument.Modesl;
using TemplateNetCoreApiAndSwaggerDocument.Services;

namespace TemplateNetCoreApiAndSwaggerDocument.Controllers
{
    /// <summary>
    /// (mô tả controller)
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly BooksService _booksService;

        public BooksController(BooksService booksService) =>
            _booksService = booksService;

        [HttpGet]
        public async Task<List<Book>> Get() =>
            await _booksService.GetAsync();

        /// <summary>
        /// (mô tả api) lấy danh sách "<see cref="Book"/>"
        /// </summary>
        /// <param name="id" example="1"></param>
        /// <remarks>
        /// (mô tả thêm)
        /// - điều 1
        /// - điều 2
        /// </remarks>
        /// <returns>(mô tả return)</returns>
        /// <response code="200">(mô tả cho kết quả status 200) Returns a list with the available sample responses.</response>
        [HttpGet("{id:length(24)}")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(Book))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status409Conflict)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable)]
        public async Task<ActionResult<Book>> Get(string id)
        {
            var book = await _booksService.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Book newBook)
        {
            await _booksService.CreateAsync(newBook);

            return CreatedAtAction(nameof(Get), new { id = newBook.Id }, newBook);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Book updatedBook)
        {
            var book = await _booksService.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            updatedBook.Id = book.Id;

            await _booksService.UpdateAsync(id, updatedBook);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var book = await _booksService.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            await _booksService.RemoveAsync(id);

            return NoContent();
        }

        /// <summary>
        /// (api demo) swagger chọn giá trị input
        /// </summary>
        /// <param name="option"></param>
        /// <returns></returns>
        [HttpGet("multiSelect/{option}")]
        public string GetOption(
            [SwaggerParameterExample("Option Value 1", "Text 1")]
            [SwaggerParameterExample("Option Value 2", "Text 2")]
            [SwaggerParameterExample("Option Value 3", "Text 3")]
            string option)
        {
            return option;
        }

        /// <summary>
        /// (api demo) swagger parameter null
        /// </summary>
        /// <param name="require">parameter phải nhập</param>
        /// <param name="optional">có thể null</param>
        /// <returns></returns>
        [HttpGet("nullParameter/{require}/{optional?}")]
        [SwaggerOperationFilter(typeof(ReApplyOptionalRouteParameterOperationFilter))]
        public string GetParameterNull(
            string require, string? optional = null)
        {
            return string.IsNullOrEmpty(optional) ? $"require: {require}, optional: Không truyền value" : $"require: {require}, optional: {optional}";
        }
    }
}

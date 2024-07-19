namespace TemplateNetCoreApiAndSwaggerDocument.Modesl
{
    /// <summary>
    /// model chứa thông tin kết nối tới Mongo
    /// </summary>
    public class BookStoreDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!; // chuỗi kết nối

        public string DatabaseName { get; set; } = null!; // database kết nối

        public string BooksCollectionName { get; set; } = null!; // tên collection BookName
    }
}

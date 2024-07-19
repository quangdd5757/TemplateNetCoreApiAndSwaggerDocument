using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace TemplateNetCoreApiAndSwaggerDocument.Modesl
{
    /// <summary>
    /// model mẫu
    /// </summary>
    public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Name")]
        [StringLength(100)]
        public string BookName { get; set; } = null!;

        [DefaultValue(2)]
        [Range(0, 100)]
        public decimal Price { get; set; }

        /// <summary>
        /// (mô tả) category
        /// </summary>
        public string Category { get; set; } = null!;

        public string Author { get; set; } = null!;
    }
}

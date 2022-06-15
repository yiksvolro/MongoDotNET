using MongoDB.Bson.Serialization.Attributes;

namespace MongoDotNET.Models
{
    public class Book
    {
		[BsonId]
		public int Id { get; set; }
        [BsonElement("Name")]
        public string BookName { get; set; } = null!;
        public decimal Price { get; set; }
        public string Category { get; set; } = null!;
        public string Author { get; set; } = null!;

    }
}

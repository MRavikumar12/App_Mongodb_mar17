using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace App_Mongodb_mar17.Models
{
    public class Product
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string? id { get; set; }
        [BsonElement("name")]

        public string name { get; set; }
        public string Price { get; set; }
        public string description { get; set; }
        public string rating { get; set; }
        public string category { get; set; }

    }
}

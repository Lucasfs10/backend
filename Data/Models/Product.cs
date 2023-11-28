using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; private set; }
        [BsonElement("Name")]
        public string Name { get; private set; }
        [BsonElement("CodErp")]
        public string CodErp { get; private set; }
        [BsonElement("Price")]
        public decimal Price { get; private set; }
        public ICollection<Purchase> Purchase { get; set; }
    }
}

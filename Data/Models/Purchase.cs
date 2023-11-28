using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Purchase
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; private set; }
        [BsonElement("ProductId")]
        public string ProductId { get; private set; }
        [BsonElement("PersonId")]
        public string PersonId { get; private set; }
        [BsonElement("Date")]
        public DateTime Date { get; private set; }
        public Person Person { get; set; }
        public Product Product { get; set; }
    }
}

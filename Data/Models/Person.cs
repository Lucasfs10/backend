using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Person
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; }
        [BsonElement("Document")]
        public string Document { get; set; }
        [BsonElement("Phone")]
        public string Phone { get; set; }
        //public ICollection<Purchase> Purchases { get; set; }
    }
}

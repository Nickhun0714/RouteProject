using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteProject
{
    class Routes
    {
        [BsonId]
        public int _id { get; set; }
        [BsonElement("number")]
        public int number { get; set; }
        [BsonElement("isSorted")]
        public int isSorted { get; set; }

        public Routes(int _id, int number, int isSorted)
        {
            this._id = _id;
            this.number = number;
            this.isSorted = isSorted;
        }
    }
}

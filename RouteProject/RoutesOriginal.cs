using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteProject
{
    class RoutesOriginal
    {

        [BsonId]
        public int _id { get; set; }
        [BsonElement("number")]
        public int number { get; set; }


        public RoutesOriginal(int _id, int number)
        {
            this._id = _id;
            this.number = number;

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Driver;

namespace ConnectionTest
{
    class Program
    {
        static void Main(string[] args)
        {
            MongoClient dbClient = new MongoClient("mongodb+srv://root:root@cluster0-yl9ao.mongodb.net/test?retryWrites=true&w=majority");
            var database = dbClient.GetDatabase("sample_training");
            var collection = database.GetCollection<BsonDocument>("grades");

            Console.WriteLine("First record in table...");
            var firstDocument = collection.Find(new BsonDocument()).FirstOrDefault();
            var jsonFirstDocument = firstDocument.ToJson(new JsonWriterSettings { Indent = true });
            Console.WriteLine($"{jsonFirstDocument}\n");

            Console.WriteLine("Specific record in table...");
            var filter = Builders<BsonDocument>.Filter.Eq("student_id", 213);
            var specificDocument = collection.Find(filter).FirstOrDefault();
            var jsonSpecificDocument = specificDocument.ToJson(new JsonWriterSettings { Indent = true });
            Console.WriteLine(jsonSpecificDocument);

            //collection.InsertOne("");



            Console.ReadKey();
        }
    }
}

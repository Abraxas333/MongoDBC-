using MongoDB.Bson;
using MongoDB.Driver;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Initialize the database object
            var db = new DB("mongodb://localhost:27017", "employees", "employees");

            // Create a sample document
            var document = new BsonDocument
            {
                { "name", "Alice" },
                { "age", 25 },
                { "city", "New York" }
            };

            Employee Joe = new Employee("Joe", 45, "Coder");

            foreach (BsonDocument e in Employee.Employees)
                db.InsertDocument(e);

            // Insert the document
            db.InsertDocument(document);

            // Fetch and print all documents in the collection
            db.FetchAllDocuments();

            // Example of finding documents with a filter
            var filter = Builders<BsonDocument>.Filter.Eq("name", "Alice");
            db.FindDocuments(filter);
        }
    }
}

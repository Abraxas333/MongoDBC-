using System;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ConsoleApp2
{
    internal class DB
    {
        // Private fields for MongoDB client, database, and collection
        private MongoClient _client;
        private IMongoDatabase _database;
        private IMongoCollection<BsonDocument> _collection;

        // Constructor to initialize the connection
        public DB(string clientUri, string databaseName, string collectionName)
        {
            // Initialize the MongoDB client
            _client = new MongoClient(clientUri);

            // Access the specified database
            _database = _client.GetDatabase(databaseName);

            // Access the specified collection
            _collection = _database.GetCollection<BsonDocument>(collectionName);
        }

        // Method to insert a document into the collection
        public void InsertDocument(BsonDocument document)
        {
            _collection.InsertOne(document);
            Console.WriteLine("Document inserted successfully.");
        }

        // Method to fetch all documents in the collection
        public void FetchAllDocuments()
        {
            var documents = _collection.Find(FilterDefinition<BsonDocument>.Empty).ToList();
            Console.WriteLine("Documents in collection:");
            foreach (var doc in documents)
            {
                Console.WriteLine(doc.ToJson());
            }
        }

        // Method to find documents based on a filter
        public void FindDocuments(FilterDefinition<BsonDocument> filter)
        {
            var documents = _collection.Find(filter).ToList();
            Console.WriteLine("Filtered documents:");
            foreach (var doc in documents)
            {
                Console.WriteLine(doc.ToJson());
            }
        }
    }
}


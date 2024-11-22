using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    internal class Employee
    {
        // Properties
        private string Name { get; set; }
        private int Age { get; set; }
        private string Position { get; set; }

        // Static List to store employees as BsonDocuments
        public static List<BsonDocument> Employees = new List<BsonDocument>();

        // Constructor
        public Employee(string name, int age, string position)
        {
            Name = name;
            Age = age;
            Position = position;

            // Add this employee as a BsonDocument to the static list
            var employeeDocument = new BsonDocument
            {
                { "name", this.Name },
                { "age", this.Age },
                { "position", this.Position }
            };

            Employees.Add(employeeDocument);
        }

        // Method to Display All Employees
        public static void DisplayAllEmployees()
        {
            Console.WriteLine("Employees:");
            foreach (var employee in Employees)
            {
                Console.WriteLine(employee.ToJson());
            }
        }
    }
}

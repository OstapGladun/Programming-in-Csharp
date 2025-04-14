using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace Lab04
{
    public static class DataManager
    {
        private static readonly string FilePath = "people.json";

        public static List<Person> LoadOrCreateUsers()
        {
            if (File.Exists(FilePath))
            {
                try
                {
                    string json = File.ReadAllText(FilePath);
                    var people = JsonSerializer.Deserialize<List<Person>>(json) ?? new List<Person>();
                    foreach (var person in people)
                    {
                        person.CalculateProperties();
                    }
                    return people;
                }
                catch
                {
                    return new List<Person>();
                }
            }
            else
            {
                var users = GenerateUsers(50);
                SaveUsers(users);
                return users;
            }
        }

        public static void SaveUsers(List<Person> users)
        {   
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            string json = JsonSerializer.Serialize(users, options);
            File.WriteAllText(FilePath, json);
        }

        private static List<Person> GenerateUsers(int amount)
        {
            var rand = new Random();
            var names = new[] { "James", "Michael", "Robert", "John", "David", "William", "Richard", "Joseph", "Thomas", "Christopher", "Charles" };
            var surnames = new[] { "Smith", "Jones", "Williams", "Taylor", "Brown", "Davies", "Evans", "Thomas ", "Wilson", "Johnson", "Roberts" };
            var list = new List<Person>();
            for (int i = 0; i < amount; i++)
            {
                string first = names[rand.Next(names.Length)];
                string last = surnames[rand.Next(surnames.Length)];
                string email = $"{first.ToLower()}.{last.ToLower()}@gmail.com";
                DateTime birthDate = DateTime.Today.AddYears(rand.Next(-100, 0)).AddDays(rand.Next(0, 365));
                list.Add(new Person(first, last, email, birthDate));
            }
            return list;
        }
    }
}

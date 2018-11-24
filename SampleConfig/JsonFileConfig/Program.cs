using System;
using Microsoft.Extensions.Configuration;

namespace JsonFileConfig
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");
            var configurations = builder.Build();


            Console.WriteLine($"ClassNo:{configurations["ClassNo"]}");
            Console.WriteLine($"ClassDesc:{configurations["ClassDesc"]}");
            Console.WriteLine("Students:");
            Console.WriteLine(configurations[$"Students:0:name"]);
            Console.WriteLine(configurations[$"Students:0:age"]);
            Console.WriteLine(configurations[$"Students:1:name"]);
            Console.WriteLine(configurations[$"Students:1:age"]);
            Console.WriteLine(configurations[$"Students:2:name"]);
            Console.WriteLine(configurations[$"Students:2:age"]);
            Console.ReadLine();
        }
    }
}

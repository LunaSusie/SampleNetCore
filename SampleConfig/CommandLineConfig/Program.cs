using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace CommandLineConfig
{
    class Program
    {
        static void Main(string[] args)
        {
            //默认参数
            var settings = new Dictionary<string, string>
            {
                {"name","luan"},
                {"age","18"}
            };
            var builder = new ConfigurationBuilder().AddCommandLine(args).AddInMemoryCollection(settings);
            var configurations = builder.Build();
            
            Console.WriteLine($"name:{configurations["name"]}");
            Console.WriteLine($"age:{configurations["age"]}");
            Console.ReadLine();
        }
    }
}

using AnagramChecker_lib;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Console_AnagramChecker
{       
    class Program
    {

        static void Main(string[] args)
        {
            new ConsoleAnagramChecker(new AnagramChecker(), GetConfiguration().Build()).AnagramCheck(args);
        }
        private static IConfigurationBuilder GetConfiguration()
        {
            return new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");
        }
    }
}

using AnagramChecker_lib;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Console_AnagramChecker
{
    class ConsoleAnagramChecker
    {
        private readonly IAnagramChecker checker;
        private readonly IAnagramReader reader;

        public ConsoleAnagramChecker(IAnagramChecker checker, IConfiguration config)

        {
            this.checker = checker;
            this.reader = new AnagramFileReader(null, config);
        }

        public async void AnagramCheck(string[] args)
        {
            if (args.Length <= 3 && args.Length >= 2)
            {
                if (args[0] == "check" && args.Length == 3)
                {
                    String anagram = checker.IsAnagram(args[1], args[2]) ? "" : "no ";
                    {
                        Console.WriteLine("\"{0}\" and \"{1}\" are {2}anagrams", args[1], args[2], anagram);
                    }
                    return;
                }
                else if (args[0] == "getKnown" && args.Length == 2)
                {

                    string anagramText = await reader.ReadAnagramFile();

                    foreach (var s in checker.GetKnownAnagrams(args[1], anagramText))
                    {
                        Console.WriteLine(s);
                    }
                    return;
                }
                Console.WriteLine("Please enter:");
                Console.WriteLine("AnagramChecker check <word1> <word2>");
                Console.WriteLine("or AnagramChecker getKnown <word>");
            }
        }
    }
}

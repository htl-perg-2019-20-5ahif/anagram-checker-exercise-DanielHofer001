using AnagramChecker_lib;
using System;

namespace Console_AnagramChecker
{
    class Program
    {

        static void Main(string[] args)
        {
            new ConsoleAnagramChecker(new AnagramChecker(),new AnagramFileReader()).AnagramCheck(args);

        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace AnagramChecker_lib
{
    public interface IAnagramChecker
    {
        bool IsAnagram(string word1, string word2);
        IEnumerable<string> GetKnownAnagrams(string word, IEnumerable<Anagram> anagramWords);
    }
}

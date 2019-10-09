using AnagramChecker_lib;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AnagramChecker_lib
{
    public class AnagramChecker : IAnagramChecker

    {
        public IEnumerable<string> GetKnownAnagrams(string word, string anagramText)
        {
            IEnumerable<Anagram> anagramWords = parseText(anagramText);
            var anagrams = new List<string>();
            foreach (var anagram in anagramWords)
            {
                if (anagram.w1 == word || (IsAnagram(anagram.w2, word) && anagram.w2 != word))
                {
                    if (!anagrams.Contains(anagram.w2))
                        anagrams.Add(anagram.w2);
                }
                if (anagram.w2 == word || (IsAnagram(anagram.w1, word) && anagram.w1 != word))
                {
                    if (!anagrams.Contains(anagram.w1))
                        anagrams.Add(anagram.w1);
                }
            }
            return anagrams;
        }

        private IEnumerable<Anagram> parseText(string anagramText)
        {
            var anagramWords = anagramText.Replace("\r", "").Split("\n");
            List<Anagram> anagramList = new List<Anagram>();

            foreach (var s in anagramWords)
            {
                var splitted = s.Replace(" ", "").Split("=");
                anagramList.Add(new Anagram(splitted[0], splitted[1]));
            }
            return anagramList;
        }

        public bool IsAnagram(string word1, string word2)
        {
            char[] ch1 = word1.ToLower().ToCharArray();
            char[] ch2 = word2.ToLower().ToCharArray();
            Array.Sort(ch1);
            Array.Sort(ch2);
            string val1 = new string(ch1);
            string val2 = new string(ch2);

            if (val1 == val2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

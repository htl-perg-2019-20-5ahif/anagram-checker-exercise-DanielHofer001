﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AnagramChecker_lib
{
    public class Permutator : IPermutator
    {
        List<string> list;
        public IEnumerable<string> Permutate(string word)
        {
            list = new List<string>();
            permute(word, 0, word.Length - 1);
            return list;
        }
        private void permute(String str,
                               int l, int r)
        {
            if (l == r)
                list.Add(str);
            else
            {
                for (int i = l; i <= r; i++)
                {
                    str = swap(str, l, i);
                    permute(str, l + 1, r);
                    str = swap(str, l, i);
                }
            }
        }
        public static String swap(String a,
                              int i, int j)
        {
            char temp;
            char[] charArray = a.ToCharArray();
            temp = charArray[i];
            charArray[i] = charArray[j];
            charArray[j] = temp;
            string s = new string(charArray);
            return s;
        }
    }
}
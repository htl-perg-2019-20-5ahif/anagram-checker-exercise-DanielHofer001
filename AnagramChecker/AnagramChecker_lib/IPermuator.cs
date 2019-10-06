using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AnagramChecker_lib
{
    public interface IPermutator
    {
        IEnumerable<string> Permutate(string word);
    }
}

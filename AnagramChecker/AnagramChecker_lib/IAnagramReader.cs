using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AnagramChecker_lib
{
    public interface IAnagramReader
    {
        Task<string> ReadAnagramFile();
    }
}

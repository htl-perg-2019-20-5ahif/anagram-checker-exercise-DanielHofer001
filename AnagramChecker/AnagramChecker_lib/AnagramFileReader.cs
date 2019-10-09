using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace AnagramChecker_lib
{
    public class AnagramFileReader : IAnagramReader
    {
        private readonly ILogger<AnagramFileReader> logger;
        private readonly IConfiguration config;


        // IMPORTANT - WITHOUT CONSTRUCTOR --> NULLREFERENCE
        public AnagramFileReader(ILogger<AnagramFileReader> logger, IConfiguration config)
        {
            this.logger = logger;
            this.config = config;
        }
    
        public async Task<string> ReadAnagramFile()
        {
            string anagramText;
            try
            {
                // Read the anagram list
                string anagramFile = config["anagramFileName"];
                anagramText = await System.IO.File.ReadAllTextAsync(anagramFile);
            }
            catch (FileNotFoundException ex)
            {
                if(logger!=null)
                logger.LogError(ex, "AnagramFile not found");
                throw;
            }

            return anagramText;
        }
    }
}

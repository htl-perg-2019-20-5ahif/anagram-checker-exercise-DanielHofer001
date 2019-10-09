using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnagramChecker_lib;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebAPI_Anagram.Controllers
{
    [ApiController]
    [Route("/api")]
    public class AnagramController : ControllerBase
    {
        private readonly IAnagramChecker checker;
        private readonly IAnagramReader reader;
        private readonly IPermutator permutator;
        public AnagramController(IAnagramChecker checker, IAnagramReader reader, IPermutator permutator)
        {
            this.checker = checker;
            this.reader = reader;
            this.permutator = permutator;
        }



        [HttpPost]
        [Route("checkAnagram")]
        public IActionResult CheckAnagram([FromBody] Anagram a1)
        {
            if (checker.IsAnagram(a1.w1, a1.w2)) return Ok();
            return BadRequest();
        }
        [HttpGet]
        [Route("getKnownAnagrams")]

        public async Task <IActionResult> GetKnownAnagrams([FromQuery] string w)
        {
            string anagramText = await reader.ReadAnagramFile();
            var anagramWords = anagramText.Replace("\r", "").Split("\n");
            List<Anagram> anagramList = new List<Anagram>();

            foreach (var s in anagramWords)
            {
                var splitted = s.Replace(" ","").Split("=");
                anagramList.Add(new Anagram(splitted[0], splitted[1]));
            }
            var res = checker.GetKnownAnagrams(w, anagramText);
            if (res.Count() >0 )
            {
                return Ok(res);
            }
            return NotFound();
            
        }
        [HttpGet]
        [Route("getPermutations")]
        public IEnumerable<string> GetPermutations([FromQuery] string w)
        {
            return  permutator.Permutate(w);
        }
    }
}

using System.ComponentModel.DataAnnotations;

namespace AnagramChecker_lib
{
    public class Anagram
    {
        //DONT'T FORGET GET AND SET
        [Required(ErrorMessage = "w1 is required.")]
        public string w1 { get; set; }
        [Required(ErrorMessage = "w1 is required.")]
        public string w2 { get; set; }
        public Anagram(string w1, string w2)
        {
            this.w1 = w1;
            this.w2 = w2;
        }
        public Anagram()
        {
        }
    }
}
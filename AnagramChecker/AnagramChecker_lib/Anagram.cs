namespace AnagramChecker_lib
{
    public class Anagram
    {
        //DONT'T FORGET GET AND SET
        public string w1 { get; set; }
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
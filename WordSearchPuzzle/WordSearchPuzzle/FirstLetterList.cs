using System.Collections.Generic;

namespace WordSearchPuzzle
{
    public class FirstLetterList
    {
        public FirstLetterList(string word)
        {
            Letter = word.Substring(0, 1).ToUpper();
        }
        public string Letter { get; set; }
        public List<FirstLetter> Locations { get; set; }
    }
}
namespace WordSearchPuzzle
{
    public class WordSearch
    {
        public static WordFound FindWord(string wordToFind, string[] grid)
        {
            string wordInCaps = wordToFind.ToUpper().Trim();
            var wordFound = new WordFound();
            for (var i = 0; i < grid.Length; i++)
            {
                if (grid[i].Contains(wordInCaps))
                {
                    wordFound.WordText = wordInCaps;
                    return wordFound;
                }
            }
            return null;
        }
    }
}
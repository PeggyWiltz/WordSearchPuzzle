using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordSearchPuzzle
{
    public class WordSearch
    {
        public static WordFound FindWordLr(string wordToFind, string[] grid)
        {
            var wordInCaps = wordToFind.ToUpper().Trim();
            var wordFound = new WordFound();
            if (grid.Any(t => t.Contains(wordInCaps)))
            {
                wordFound.WordText = wordInCaps;
                wordFound.WordDirection = "LR";
                return wordFound;
            }
            return null;
        }

        private static string ReverseString(string s)
        {
            char[] reversed = s.ToCharArray();
            Array.Reverse(reversed);
            return new String(reversed);
        }

        public static WordFound FindWordRl(string wordToFind, string[] grid)
        {
            var reversedString = ReverseString(wordToFind);
            var wordFound = FindWordLr(reversedString, grid);
            if (wordFound != null)
            {
                return new WordFound
                    {
                        WordText = wordToFind.ToUpper(),
                        WordDirection = "RL"
                    };
            }
            return null;
        }


        public static FirstLetterList FindFirstLetter(string wordToFind, string[] grid)
        {
            var firstLetterList = new FirstLetterList(wordToFind);
            var locationsList = new List<FirstLetter>();
            var firstLetter = firstLetterList.Letter;

            for (var i = 0; i < grid.Length; i++)
            {
                if (!grid[i].Contains(firstLetter)) continue;
                for (var j = 0; j < grid[i].Length; j++)
                {
                    var gridLetter = grid[i][j].ToString();
                    if (!firstLetter.Equals(gridLetter)) continue;
                    var newLocation = new FirstLetter
                    {
                        Row = i, 
                        Column = j
                    };
                    locationsList.Add(newLocation);
                }
            }
            firstLetterList.Locations = locationsList;
            return firstLetterList;
            
        }

        public static WordFound FindWordU(string wordToFind, string[] grid)
        {
            var firstLetterList = FindFirstLetter(wordToFind, grid);
            var wordLen = wordToFind.Length;
            var wordUpper = wordToFind.ToUpper();
            foreach (var letter in firstLetterList.Locations)
            {
                var charList = FillCharListUp(grid, letter, wordLen, "U");
                if (charList == wordUpper)
                {
                    return new WordFound
                    {
                        WordText = wordUpper,
                        WordDirection = "U"
                    };
                }
            }
            return null;
        }

        public static WordFound FindWordD(string wordToFind, string[] grid)
        {
            return null;
        }

        private static string FillCharListUp(IList<string> grid, FirstLetter letter, int wordLen, string direction)
        {
            var charList = new StringBuilder();
            var row = letter.Row;

            if (ValidateWordSpace(wordLen, row, direction))
            {
                return string.Empty;
            }
            var col = letter.Column;
            charList.Append(grid[row][col]);
            for (var i = 1; i < wordLen; i++)
            {
                row = SetNewRowValue(row, direction);
                charList.Append(grid[row][col]);
            }
            return charList.ToString();
        }

        private static int SetNewRowValue(int row, string direction)
        {
            switch (direction)
            {
                case "U":
                    row -= 1;
                    break;
            }
            
            return row;
        }

        private static bool ValidateWordSpace(int wordLen, int row, string direction)
        {
            switch (direction)
            {
                case "U":
                    return row < wordLen - 1;
                default:
                    return false;
            }
            
        }
    }
}
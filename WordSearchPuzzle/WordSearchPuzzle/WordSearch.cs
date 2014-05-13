using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace WordSearchPuzzle
{
    public class WordSearch
    {
        
        public static WordFound FindWordLr(string wordToFind, string[] grid)
        {
            var wordInCaps = wordToFind.ToUpper().Trim();
            var wordFound = new WordFound();
            var firstLetterList = FindFirstLetter(wordToFind, grid);
            foreach (var letter in firstLetterList.Locations)
            {
                var gridRowStr = grid[letter.Row].ToString(CultureInfo.InvariantCulture);
                if (gridRowStr.Contains(wordInCaps))
                {
                    wordFound.WordText = wordInCaps;
                    wordFound.WordDirection = "LR";
                    wordFound.Location.Row = letter.Row;
                    wordFound.Location.Column = gridRowStr.IndexOf(wordInCaps, StringComparison.Ordinal);
                    return wordFound;
                }
            }
            return null;
        }

        public static WordFound FindWordRl(string wordToFind, string[] grid)
        {
            var reversedString = ReverseString(wordToFind);
            var wordFound = FindWordLr(reversedString, grid);
            if (wordFound != null)
            {
                var wordRow = wordFound.Location.Row;
                var wordCol = wordFound.Location.Column + wordToFind.Length - 1;
                return new WordFound
                    {
                        WordText = wordToFind.ToUpper(),
                        WordDirection = "RL",
                        Location = new GridLocation(wordRow, wordCol)
                    };
            }
            return null;
        }

        public static WordFound FindWordU(string wordToFind, string[] grid)
        {
            return FindWordInDirection(wordToFind, grid, "U");
        }

        public static WordFound FindWordD(string wordToFind, string[] grid)
        {
            return FindWordInDirection(wordToFind, grid, "D");
        }

        public static WordFound FindWordDul(string wordToFind, string[] grid)
        {
            return FindWordInDirection(wordToFind, grid, "DUL");
        }

        public static WordFound FindWordDur(string wordToFind, string[] grid)
        {
            return FindWordInDirection(wordToFind, grid, "DUR");
        }

        public static WordFound FindWordDdl(string wordToFind, string[] grid)
        {
            return FindWordInDirection(wordToFind, grid, "DDL");
        }

        public static WordFound FindWordDdr(string wordToFind, string[] grid)
        {
            return FindWordInDirection(wordToFind, grid, "DDR");
        }

        private static string ReverseString(string s)
        {
            var reversed = s.ToCharArray();
            Array.Reverse(reversed);
            return new String(reversed);
        }

        public static WordFound FindWordInDirection(string wordToFind, string[] grid, string direction )
        {
            var firstLetterList = FindFirstLetter(wordToFind, grid);
            var wordLen = wordToFind.Length;
            var wordUpper = wordToFind.ToUpper();
            foreach (var letter in firstLetterList.Locations)
            {
                var charList = FillCharList(grid, letter, wordLen, direction);
                if (charList == wordUpper)
                {
                    return new WordFound
                    {
                        WordText = wordUpper,
                        WordDirection = direction,
                        Location = new GridLocation(letter.Row, letter.Column)
                    };
                }
            }
            return null;
        }

        
        public static FirstLetterList FindFirstLetter(string wordToFind, string[] grid)
        {
            var firstLetterList = new FirstLetterList(wordToFind);
            var locationsList = new List<GridLocation>();
            var firstLetter = firstLetterList.Letter;

            for (var i = 0; i < grid.Length; i++)
            {
                if (!grid[i].Contains(firstLetter)) continue;
                for (var j = 0; j < grid[i].Length; j++)
                {
                    var gridLetter = grid[i][j].ToString(CultureInfo.InvariantCulture);
                    if (!firstLetter.Equals(gridLetter)) continue;
                    var newLocation = new GridLocation
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
        
        
        private static string FillCharList(IList<string> grid, GridLocation letter, int wordLen, string direction)
        {
            var charList = new StringBuilder();
            var row = letter.Row;
            var col = letter.Column;
            var gridDimension = grid.Count;     //NOTE: handling grid with different height/width out of scope
            var gridLoc = new GridLocation(row, col);

            if (InvalidWordSpace(wordLen, letter, direction, gridDimension))
            {
                return string.Empty;
            }

            charList.Append(grid[row][col]);
            for (var i = 1; i < wordLen; i++)
            {
                gridLoc = SetNewRowValue(gridLoc.Row, gridLoc.Column, direction);
                charList.Append(grid[gridLoc.Row][gridLoc.Column]);
            }
            return charList.ToString();
        }

        private static GridLocation SetNewRowValue(int row, int col, string direction)
        {
            var gridLoc = new GridLocation
                {
                    Row = row,
                    Column = col
                };

            switch (direction)
            {
                case "U":
                    gridLoc.Row -= 1;
                    break;
                case "D":
                    gridLoc.Row += 1;
                    break;
                case "DUL":
                    gridLoc.Row -= 1;
                    gridLoc.Column -= 1;
                    break;
                case "DUR":
                    gridLoc.Row -= 1;
                    gridLoc.Column += 1;
                    break;
                case "DDL":
                    gridLoc.Row += 1;
                    gridLoc.Column -= 1;
                    break;
                case "DDR":
                    gridLoc.Row += 1;
                    gridLoc.Column += 1;
                    break;
            }
            
            return gridLoc;
        }

        private static bool InvalidWordSpace(int wordLen, GridLocation gridLoc, string direction, int gridDimension)
        {
            switch (direction)
            {
                case "U":
                    return gridLoc.Row < wordLen - 1;
                case "D":
                    return gridLoc.Row + wordLen > gridDimension;
                case "DUL":
                    return gridLoc.Row < wordLen - 1 || gridLoc.Column < gridDimension - 1;
                case "DUR":
                    return gridLoc.Row < wordLen - 1 || gridLoc.Column + wordLen > gridDimension;
                case "DDL":
                    return gridLoc.Row + wordLen - 1 > gridDimension || gridLoc.Column < wordLen - 1;
                case "DDR":
                    return gridLoc.Row + wordLen - 1 > gridDimension || gridLoc.Column + wordLen - 1 > gridDimension;
                default:
                    return false;
            }
            
        }
    }
}
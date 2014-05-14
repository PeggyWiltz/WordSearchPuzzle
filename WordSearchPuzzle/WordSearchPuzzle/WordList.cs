using System;
using System.Collections.Generic;
using System.IO;

namespace WordSearchPuzzle
{
    public static class WordList
    {
        public static List<string> FromTextFile(string wordListFileName)
        {
            var wordList = new List<string>();
            var path = Path.Combine(Environment.CurrentDirectory, wordListFileName);
            // Read the file and display it line by line.
            using (var file = new StreamReader(path))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    wordList.Add(line);
                }
            }

            return wordList;
        }
    }
}
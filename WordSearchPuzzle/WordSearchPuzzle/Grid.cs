using System;
using System.Collections.Generic;
using System.IO;

namespace WordSearchPuzzle
{
    public static class Grid
    {
        public static string[] FromTextFile(string gridFileName)
        {
            var gridStrList = new List<string>();
            var path = Path.Combine(Environment.CurrentDirectory, gridFileName);
            // Read the file and display it line by line.
            using (var file = new StreamReader(path))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    gridStrList.Add(line);
                }
            }

            return gridStrList.ToArray();
        }
    }
}
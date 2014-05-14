using System;
using System.Text;

namespace WordSearchPuzzle
{
    class Program
    {
        static void Main()
        {
            const string gridFile = @"Files\WordSearch.txt";
            const string listFile = @"Files\WordList.txt";
            var grid = Grid.FromTextFile(gridFile);
            var searchList = WordList.FromTextFile(listFile);

            //output
            foreach (var word in searchList)
            {
                var foundWord = WordSearch.GetWord(word, grid);
                if (foundWord != null)
                {
                    WriteWordData(foundWord);

                }
                else
                {
                    Console.WriteLine("{0} not found", word);
                }
            }
            Console.ReadKey();
        }

        private static void WriteWordData(WordFound wordFound)
        {
            var str = new StringBuilder();
            str.Append(wordFound.WordText).Append(" ");
            str.Append(" Direction: ").Append(wordFound.WordDirection);
            str.Append(" Row: ").Append(wordFound.Location.Row);
            str.Append(" Col: ").Append(wordFound.Location.Column);
            Console.WriteLine(str);
        }
    }
}

namespace WordSearchPuzzle.Test
{
    public class Get
    {
        public static string[] AnySmallGrid()
        {
            var grid = new[]
                {
                    "TPIR",
                    "WORD",
                    "CRAB",
                    "TARB"
                };
            return grid;
        }

        public static string[] AnySmallGridWithDDLWordInsideBorder()
        {
            var grid = new[]
                {
                    "AAAA",
                    "ABAA",
                    "ABCA",
                    "CAAD"
                };
            return grid;
        }
    }
}
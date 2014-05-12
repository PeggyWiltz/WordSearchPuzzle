namespace WordSearchPuzzle
{
    public class GridLocation
    {
        public GridLocation()
        {
            
        }
        public GridLocation(int row, int col)
        {
            Row = row;
            Column = col;
        }
        public int Row { get; set; }

        public int Column { get; set; }
    }
}
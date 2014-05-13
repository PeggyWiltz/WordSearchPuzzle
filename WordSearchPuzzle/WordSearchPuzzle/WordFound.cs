namespace WordSearchPuzzle
{
    public class WordFound
    {
        public WordFound()
        {
            Location = new GridLocation(0, 0);
        }
        public string WordText { get; set; }

        public GridLocation Location { get; set; }

        public string WordDirection { get; set; }
    }
}
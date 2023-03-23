namespace BoardGame
{
    internal class Board
    {
        public int Lines { get; private set; }
        public int Columns { get; private set; }
        public Piece[,] pieces;

        public Board(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            pieces = new Piece[Columns,];
        }
    }
}

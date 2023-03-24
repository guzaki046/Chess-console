using BoardGame.Enums;

namespace BoardGame
{
    internal class Piece
    {
        public Position position { get; set; }
        public Color color { get; private set; }
        public int movesQty { get; private set; }
        public Board board { get; set; }

        public Piece(Board board, Color color)
        {
            this.position = null;
            this.color = color;
            this.board = board;
            this.movesQty = 0;
        }
    }
}

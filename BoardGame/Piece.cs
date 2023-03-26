using BoardGame.Enums;

namespace BoardGame
{
    internal abstract class Piece
    {
        public Position position { get; set; }
        public Color color { get; private set; }
        public int movementsQty { get; private set; }
        public Board board { get; set; }

        // Constructors
        public Piece(Board board, Color color)
        {
            this.position = null;
            this.color = color;
            this.board = board;
            this.movementsQty = 0;
        }

        public abstract bool[,] PossibleMovements();

        // Increase movements
        public void IncrementMovesQty()
        {
            movementsQty++;
        }
    }
}

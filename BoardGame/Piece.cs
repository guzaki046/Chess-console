using BoardGame.Enums;
using System.Text.RegularExpressions;

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

        public bool ExistsPossibleMovements()
        {
            bool[,] mat = PossibleMovements();
            for (int i = 0; i < board.Lines; i++) 
            {
                for (int j = 0; j < board.Columns; j++)
                {
                    if (mat[i,j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool CanMoveTo(Position pos)
        {
            return PossibleMovements()[pos.Line, pos.Column];
        }

        public abstract bool[,] PossibleMovements();

        // Increase movements
        public void IncrementMovesQty()
        {
            movementsQty++;
        }
        public void DecrementMovesQty()
        {
            movementsQty--;
        }
    }
}

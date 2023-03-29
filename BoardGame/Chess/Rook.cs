using BoardGame.Enums;

namespace BoardGame.Chess
{
    internal class Rook : Piece
    {
        public Rook(Board board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "R";
        }

        // Implementing the Tower movements
        private bool CanMove(Position pos)
        {
            Piece p = board.piece(pos);
            return p == null || p.color != color;
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] mat = new bool[board.Lines, board.Columns];

            Position pos = new Position(0,0);

            // upward
            pos.SetValue(position.Line - 1, position.Column);
            while (board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.Line = pos.Line - 1;
            }

            // downward
            pos.SetValue(position.Line + 1, position.Column);
            while (board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.Line = pos.Line + 1;
            }

            // right
            pos.SetValue(position.Line, position.Column + 1);
            while (board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.Column = pos.Column + 1;
            }

            // left
            pos.SetValue(position.Line, position.Column - 1);
            while (board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.Column = pos.Column - 1;
            }

            return mat;
        }
    }
}

using BoardGame.Enums;

namespace BoardGame.Chess
{
    internal class King : Piece
    {
        // Constructor
        public King (Board board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "K";
        }

        // Implementing the King movements
        private bool CanMove(Position pos)
        {
            Piece p = board.piece(pos);
            return p == null || p.color != color;
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] mat = new bool[board.Lines, board.Columns];

            Position pos = new Position(0, 0);

            // upward
            pos.SetValue(position.Line - 1, position.Column);
            if (board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            //north east
            pos.SetValue(position.Line - 1, position.Column + 1);
            if (board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // right
            pos.SetValue(position.Line, position.Column + 1);
            if (board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            //south east
            pos.SetValue(position.Line + 1, position.Column + 1);
            if (board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // downward
            pos.SetValue(position.Line + 1, position.Column);
            if (board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // south west
            pos.SetValue(position.Line + 1, position.Column - 1);
            if (board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // left
            pos.SetValue(position.Line, position.Column - 1);
            if (board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // north west
            pos.SetValue(position.Line - 1, position.Column - 1);
            if (board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            return mat;
        }
    }
}

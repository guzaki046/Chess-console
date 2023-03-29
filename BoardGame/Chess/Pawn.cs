using BoardGame;
using BoardGame.Enums;
using System.Reflection.PortableExecutable;

namespace chess_console.BoardGame.Chess
{
    internal class Pawn : Piece
    {
        public Pawn(Board board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "P";
        }

        private bool ExistEnemy(Position pos)
        {
            Piece p = board.piece(pos);
            return p != null && p.color != color;
        }

        private bool Free(Position pos)
        {
            return board.piece(pos) == null;
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] mat = new bool[board.Lines, board.Columns];

            Position pos = new Position(0, 0);

            if (color == Color.White)
            {
                pos.SetValue(position.Line - 1, position.Column);
                if (board.ValidPosition(pos) && Free(pos))
                {
                    mat[pos.Line,pos.Column] = true;
                }

                pos.SetValue(position.Line - 2, position.Column);
                if (board.ValidPosition(pos) && Free(pos) && movementsQty == 0)
                {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.SetValue(position.Line - 1, position.Column - 1);
                if (board.ValidPosition(pos) && ExistEnemy(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.SetValue(position.Line - 1, position.Column + 1);
                if (board.ValidPosition(pos) && ExistEnemy(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
            }
            else
            {
                pos.SetValue(position.Line + 1, position.Column);
                if (board.ValidPosition(pos) && Free(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.SetValue(position.Line + 2, position.Column);
                if (board.ValidPosition(pos) && Free(pos) && movementsQty == 0)
                {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.SetValue(position.Line + 1, position.Column - 1);
                if (board.ValidPosition(pos) && ExistEnemy(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.SetValue(position.Line + 1, position.Column + 1);
                if (board.ValidPosition(pos) && ExistEnemy(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
            }

            return mat;
        }
    }
}

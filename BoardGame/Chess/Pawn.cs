using BoardGame;
using BoardGame.Chess;
using BoardGame.Enums;
using System.Reflection.PortableExecutable;

namespace chess_console.BoardGame.Chess
{
    internal class Pawn : Piece
    {
        private ChessMatch Match;
        public Pawn(Board board, Color color, ChessMatch match) : base(board, color)
        {
            Match = match;
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

                // #SpecialMove En Passant
                if (position.Line == 3)
                {
                    Position left = new Position(position.Line, position.Column - 1);
                    if (board.ValidPosition(left) && ExistEnemy(left) && board.piece(left) == Match.VulnerableEnPassant)
                    {
                        mat[left.Line - 1, left.Column] = true;
                    }
                    Position right = new Position(position.Line, position.Column + 1);
                    if (board.ValidPosition(right) && ExistEnemy(right) && board.piece(right) == Match.VulnerableEnPassant)
                    {
                        mat[right.Line - 1, right.Column] = true;
                    }
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

                // #SpecialMove En Passant
                if (position.Line == 4)
                {
                    Position left = new Position(position.Line, position.Column - 1);
                    if (board.ValidPosition(left) && ExistEnemy(left) && board.piece(left) == Match.VulnerableEnPassant)
                    {
                        mat[left.Line + 1, left.Column] = true;
                    }
                    Position right = new Position(position.Line, position.Column + 1);
                    if (board.ValidPosition(right) && ExistEnemy(right) && board.piece(right) == Match.VulnerableEnPassant)
                    {
                        mat[right.Line + 1, right.Column] = true;
                    }
                }
            }

            return mat;
        }
    }
}

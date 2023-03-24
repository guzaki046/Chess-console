using BoardGame.Exceptions;

namespace BoardGame
{
    internal class Board
    {
        public int Lines { get; private set; }
        public int Columns { get; private set; }
        private Piece[,] pieces;

        public Board(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            pieces = new Piece[Lines,Columns];
        }

        public Piece piece(int line, int column) 
        {
            return pieces[line, column];
        }

        public Piece piece(Position pos)
        {
            return pieces[pos.Line, pos.Column];
        }

        public void PutPiece(Piece p, Position pos)
        {
            if (ThereIsPiece(pos))
            {
                throw new BoardException("There is already a piece here");
            }
            pieces[pos.Line, pos.Column] = p;
            p.position = pos;
        }

        public bool ThereIsPiece(Position pos)
        {
            ValidatePosition(pos);
            return piece(pos) != null;
        }

        public bool ValidPosition(Position pos)
        {
            if (pos.Line < 0 || pos.Line >= Lines || pos.Column < 0 || pos.Column >= Columns)
            {
                return false;
            }
            return true;
        }

        public void ValidatePosition(Position pos)
        {
            if (!ValidPosition(pos))
            {
                throw new BoardException("Invalid position!");
            }
        }
    }
}

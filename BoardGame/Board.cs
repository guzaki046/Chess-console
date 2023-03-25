using BoardGame.Exceptions;

namespace BoardGame
{
    internal class Board
    {
        public int Lines { get; private set; }
        public int Columns { get; private set; }
        private Piece[,] pieces;

        // Constructors
        public Board(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            pieces = new Piece[Lines,Columns];
        }

        //Receiving pieces
        public Piece piece(int line, int column) 
        {
            return pieces[line, column];
        }

        public Piece piece(Position pos)
        {
            return pieces[pos.Line, pos.Column];
        }

        // This method insert a piece into the board
        public void PutPiece(Piece p, Position pos)
        {
            if (ThereIsPiece(pos))
            {
                throw new BoardException("There is a piece in this position already!");
            }
            pieces[pos.Line, pos.Column] = p;
            p.position = pos;
        }

        // This metod removes a piece from the board
        public Piece RemovePiece(Position pos)
        {
            if (piece(pos) == null)
            {
                return null;
            }
            Piece aux = piece(pos);
            aux.position = null;
            pieces[pos.Line, pos.Column] = null;
            return aux;
        }

        //Checking if there is a piece in a specific position
        public bool ThereIsPiece(Position pos)
        {
            ValidatePosition(pos);
            return piece(pos) != null;
        }

        // Testing if a position is valid
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

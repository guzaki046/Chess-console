using BoardGame.Enums;
using BoardGame.Exceptions;

namespace BoardGame.Chess
{
    internal class ChessMatch
    {
        public Board Board { get; private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool Finished { get; private set; }

        // Initialize board
        public ChessMatch()
        {
            Board = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            Finished = false;
            PutPieces();
        }

        // Execute a movement in the game, change the player and the turn
        public void ExecuteMovement(Position origin, Position destination)
        {
            Piece p = Board.RemovePiece(origin);
            p.IncrementMovesQty();
            Piece capturedPiece = Board.RemovePiece(destination);
            Board.PutPiece(p, destination);
        }

        public void MadeMovement(Position origin, Position destination)
        {
            ExecuteMovement(origin, destination);
            Turn++;
            ChangePlayer();
        }

        public void ValidOriginPosition(Position pos)
        {
            if (Board.piece(pos) == null)
            {
                throw new BoardException("There is no piece in position of origin!");
            }
            if (CurrentPlayer != Board.piece(pos).color)
            {
                throw new BoardException("The piece of origin it is not yours!");
            }
            if (!Board.piece(pos).ExistsPossibleMovements())
            {
                throw new BoardException("There are no possible movements for the chosen piece");
            }
        }

        public void ValidDestinationPosition(Position origin, Position destination)
        {
            if (!Board.piece(origin).CanMoveTo(destination))
            {
                throw new BoardException("Invalid destination position!");
            }
        }

        private void ChangePlayer()
        {
            if (CurrentPlayer == Color.White)
            {
                CurrentPlayer = Color.Black;
            }
            else
            {
                CurrentPlayer = Color.White;
            }
        }

        // 
        private void PutPieces()
        {
            Board.PutPiece(new Tower(Board, Color.White), new ChessPosition('c', 1).toPosition());
            Board.PutPiece(new Tower(Board, Color.White), new ChessPosition('c', 2).toPosition());
            Board.PutPiece(new Tower(Board, Color.White), new ChessPosition('d', 2).toPosition());
            Board.PutPiece(new Tower(Board, Color.White), new ChessPosition('e', 2).toPosition());
            Board.PutPiece(new Tower(Board, Color.White), new ChessPosition('e', 1).toPosition());
            Board.PutPiece(new King(Board, Color.White), new ChessPosition('d', 1).toPosition());


            Board.PutPiece(new Tower(Board, Color.Black), new ChessPosition('c', 7).toPosition());
            Board.PutPiece(new Tower(Board, Color.Black), new ChessPosition('c', 8).toPosition());
            Board.PutPiece(new Tower(Board, Color.Black), new ChessPosition('d', 7).toPosition());
            Board.PutPiece(new Tower(Board, Color.Black), new ChessPosition('e', 7).toPosition());
            Board.PutPiece(new Tower(Board, Color.Black), new ChessPosition('e', 8).toPosition());
            Board.PutPiece(new King(Board, Color.Black), new ChessPosition('d', 8).toPosition());
        }
    }
}

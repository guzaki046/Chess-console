using BoardGame.Enums;
using BoardGame.Exceptions;
using System.Collections.Generic;

namespace BoardGame.Chess
{
    internal class ChessMatch
    {
        public Board Board { get; private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool Finished { get; private set; }
        private HashSet<Piece> Pieces;
        private HashSet<Piece> Captured;

        // Initialize board
        public ChessMatch()
        {
            Board = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            Finished = false;
            Pieces = new HashSet<Piece>();
            Captured = new HashSet<Piece>();
            PutPieces();
        }

        // Execute a movement in the game, change the player and the turn
        public void ExecuteMovement(Position origin, Position destination)
        {
            Piece p = Board.RemovePiece(origin);
            p.IncrementMovesQty();
            Piece capturedPiece = Board.RemovePiece(destination);
            Board.PutPiece(p, destination);
            if (capturedPiece != null)
            {
                Captured.Add(capturedPiece);
            }
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

        public HashSet<Piece> CapturesPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach(Piece x in Captured)
            {
                if (x.color == color)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Piece> PiecesInGame(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in Pieces)
            {
                if (x.color == color)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(CapturesPieces(color));
            return aux;
        }

        public void PutNewPiece(char column, int line, Piece piece)
        {
            Board.PutPiece(piece, new ChessPosition(column, line).toPosition());
            Pieces.Add(piece);
        }

        private void PutPieces()
        {
            PutNewPiece('c', 1, new Tower(Board, Color.White));
            PutNewPiece('c', 2, new Tower(Board, Color.White));
            PutNewPiece('d', 2, new Tower(Board, Color.White));
            PutNewPiece('e', 1, new Tower(Board, Color.White));
            PutNewPiece('e', 2, new Tower(Board, Color.White));
            PutNewPiece('d', 1, new King(Board, Color.White));

            PutNewPiece('c', 7, new Tower(Board, Color.Black));
            PutNewPiece('c', 8, new Tower(Board, Color.Black));
            PutNewPiece('d', 7, new Tower(Board, Color.Black));
            PutNewPiece('e', 8, new Tower(Board, Color.Black));
            PutNewPiece('e', 7, new Tower(Board, Color.Black));
            PutNewPiece('d', 8, new King(Board, Color.Black));
        }
    }
}

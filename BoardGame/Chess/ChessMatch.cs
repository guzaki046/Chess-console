using BoardGame.Enums;

namespace BoardGame.Chess
{
    internal class ChessMatch
    {
        public Board Board { get; private set; }
        private int Turn;
        private Color CurrentPlayer;
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

        // Execute a movement in the game
        public void ExecuteMovevent(Position origin, Position destination)
        {
            Piece p = Board.RemovePiece(origin);
            p.IncrementMovesQty();
            Piece capturedPiece = Board.RemovePiece(destination);
            Board.PutPiece(p, destination);
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

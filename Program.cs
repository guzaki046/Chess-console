// See https://aka.ms/new-console-template for more information
using BoardGame;
using BoardGame.Chess;
using BoardGame.Enums;
using BoardGame.Exceptions;
using chess_console;
using BoardGame.Chess;

try
{
    Board board = new Board(8, 8);

    board.PutPiece(new Tower(board, Color.White), new Position(0, 0));
    board.PutPiece(new King(board, Color.White), new Position(1, 3));
    board.PutPiece(new Tower(board, Color.White), new Position(2, 4));


    board.PutPiece(new King(board, Color.Black), new Position(7, 0));
    board.PutPiece(new Tower(board, Color.Yellow), new Position(6, 7));
    board.PutPiece(new King(board, Color.Blue), new Position(7, 6));

    Screen.PrintBoard(board);
}
catch (BoardException e)
{
    Console.WriteLine(e.Message);
}

// See https://aka.ms/new-console-template for more information
using BoardGame;
using BoardGame.Chess;
using BoardGame.Enums;
using BoardGame.Exceptions;
using chess_console;
using BoardGame.Chess;

try
{
    ChessMatch match = new ChessMatch();

    while (!match.Finished)
    {
        Console.Clear();
        Screen.PrintBoard(match.Board);

        Console.Write("Origin: ");
        Position origin = Screen.ReadChessPosition().toPosition();
        Console.Write("Destination: ");
        Position destination = Screen.ReadChessPosition().toPosition();

        match.ExecuteMovevent(origin, destination);
    }

}
catch (BoardException e)
{
    Console.WriteLine(e.Message);
}

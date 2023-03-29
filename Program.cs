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
        Screen.PrintMatch(match);

        Console.WriteLine();
        Console.Write("Origin: ");
        Position origin = Screen.ReadChessPosition().toPosition();
        match.ValidOriginPosition(origin);

        bool[,] possibleMovements = match.Board.piece(origin).PossibleMovements();

        Console.Clear();
        Screen.PrintBoard(match.Board, possibleMovements);

        Console.WriteLine();
        Console.Write("Destination: ");
        Position destination = Screen.ReadChessPosition().toPosition();
        match.ValidDestinationPosition(origin, destination);

        match.MadeMovement(origin, destination);
    }

}
catch (BoardException e)
{
    Console.WriteLine(e.Message);
}

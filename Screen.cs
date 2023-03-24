﻿using System;
using BoardGame;

namespace chess_console
{
    internal class Screen
    {
        public static void PrintBoard(Board board)
        {
            for (int i = 0; i < board.Lines;  i++)
            {
                for (int j = 0; j < board.Columns; j++)
                {
                    if (board.piece(i,j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(board.piece(i,j) + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}

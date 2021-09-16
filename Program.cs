using Stockfish.NET;
using System;
using System.Collections.Generic;
using SkakRobot.Utils;

namespace SkakRobot
{
    class Program
    {
        private static ChessGame game;

        static void Main(string[] args)
        {
            
            game = new ChessGame();

            game.initProcess();

            game.startGame();

        }
    }
}

using Stockfish.NET;
using System;
using System.Collections.Generic;

namespace SkakRobot
{
    class Program
    {
        static Stockfish stockfish;
        static String CurrentGame;
        
        static List<String> moves = new List<string>();

        static void Main(string[] args)
        {
            init();

            startGame();

            ///Chessgame game = new Chessgame();

        }

        static void init()
        {
            stockfish = new Stockfish("D:/Work_LOCAL/C# Workspace/ConsoleApp1/ConsoleApp1/Stockfish/win/stockfish_12_win_x64/stockfish_20090216_x64.exe");
        }


        static void startGame()
        {
            ///CurrentGame = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";
            stockFishTurn();
        }

        static void stockFishTurn()
        {
            ///stockfish.SetFenPosition(CurrentGame);
            string move = stockfish.GetBestMove();
            //Robot.move(move)

            moves.Add(move);

            stockfish.SetPosition(moves.ToArray());
            ///CurrentGame = stockfish.GetFenPosition();
            ///Console.WriteLine(CurrentGame);
            Console.WriteLine(stockfish.GetBoardVisual());
            stockfish.IsMoveCorrect("");
            Console.WriteLine("Your move... Human");
            playerTurn();

        }

        static void playerTurn()
        {
            string playerInput = Console.ReadLine();

            ///stockfish.SetFenPosition(CurrentGame);
            if (stockfish.IsMoveCorrect(playerInput))
            {
                moves.Add(playerInput);
                stockfish.SetPosition(moves.ToArray());
                ///CurrentGame = stockfish.GetFenPosition();
                Console.WriteLine(stockfish.GetBoardVisual());
                stockfish.IsMoveCorrect("");
                stockFishTurn();
            } else
            {
                Console.WriteLine("Bad move, try again");
                playerTurn();
            }
        }
    }
}

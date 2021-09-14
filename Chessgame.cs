using System;
using System.Collections.Generic;
using System.Text;
using Stockfish.NET;


namespace SkakRobot
{
    class Chessgame
    {

        public Chessgame()
        {

            Stockfish stockfish = new Stockfish("D:/Work_LOCAL/C# Workspace/ConsoleApp1/ConsoleApp1/Stockfish/win/stockfish_12_win_x64/stockfish_20090216_x64.exe");

            stockfish.SetPosition("h2h3");
            Console.WriteLine(stockfish.GetBoardVisual());
            Console.WriteLine(stockfish.GetFenPosition());
            Console.WriteLine(stockfish.IsMoveCorrect(""));
            stockfish.SetPosition("h7h6");
            Console.WriteLine(stockfish.GetBoardVisual());
            Console.WriteLine(stockfish.GetFenPosition());
            Console.WriteLine(stockfish.IsMoveCorrect("h7h6"));
        }
    }
}

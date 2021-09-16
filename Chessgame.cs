using System;
using System.Collections.Generic;
using System.Text;
using Stockfish.NET;

namespace SkakRobot
{
    class ChessGame
    {
        private Stockfish stockfish;
        private List<String> moves = new List<string>();
        public int[,] pieceLocation;
        private MovementEvent movementEvent;

        public ChessGame()
        {

            
        }

        public void initProcess()
        {
            stockfish = new Stockfish("C:/Users/Gusta/Desktop/UltraDestroyerDoomHumanChessKillerRobot_OfDoom/UltraDestroyerDoomHumanChessKillerRobot_OfDoom/Stockfish/win/stockfish_12_win_x64/stockfish_20090216_x64.exe");
        }
        public void startGame()
        {
            pieceLocation = new int[,] { { 4, 3, 2, 5, 6, 2, 3, 4 }, { 1, 1, 1, 1, 1, 1, 1, 1 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 7, 7, 7, 7, 7, 7, 7, 7 }, { 10, 9, 8, 11, 12, 8, 9, 10 } };
            moves.Clear();
            movementEvent = null;
            movementEvent = new MovementEvent(pieceLocation);
            Console.WriteLine(stockfish.GetBoardVisual());
            playerTurn();
        }

        private void stockFishTurn()
        {
            ///stockfish.SetFenPosition(CurrentGame);
            string move = stockfish.GetBestMove();
            //Robot.move(move)

            moves.Add(move);

            string from = move[0].ToString() + move[1].ToString();
            string to = move[2].ToString() + move[3].ToString();

            movementEvent.pieceMoved(from, to, false);

            printPieceLocations();

            stockfish.SetPosition(moves.ToArray());
            ///CurrentGame = stockfish.GetFenPosition();
            ///Console.WriteLine(CurrentGame);
            Console.WriteLine(stockfish.GetBoardVisual());
            stockfish.IsMoveCorrect("");
            playerTurn();

        }

        private void playerTurn()
        {
            if (!stockfish.IsMoveCorrect(stockfish.GetBestMove()))
            {
                Console.WriteLine("Checkmate");
                Console.ReadKey();

                startGame();
            }

            else
            {
                Console.WriteLine("Your move... Human");
                string playerInput = Console.ReadLine();

                ///stockfish.SetFenPosition(CurrentGame);
                if (stockfish.IsMoveCorrect(playerInput) && playerInput != "")
                {
                    moves.Add(playerInput);
                    stockfish.SetPosition(moves.ToArray());
                    ///CurrentGame = stockfish.GetFenPosition();

                    string from = playerInput[0].ToString() + playerInput[1].ToString();
                    string to = playerInput[2].ToString() + playerInput[3].ToString();

                    movementEvent.pieceMoved(from, to, false);


                    printPieceLocations();

                    Console.WriteLine(stockfish.GetBoardVisual());

                    //Console.ReadKey();

                    stockfish.IsMoveCorrect("");

                    stockFishTurn();


                }
                else
                {
                    Console.WriteLine("Bad move, try again");
                    playerTurn();
                }
            }
        
        }

        private void printPieceLocations()
        {
            for (int x = 7; x >= 0; x--)
            {
                string printLn = "";
                for (int y = 0; y < 8; y++)
                {
                    //Console.WriteLine(y);
                    //Console.ReadKey();
                    switch (pieceLocation[x, y])
                    {
                        case 1:
                            printLn = printLn + " P";
                            break;
                        case 2:
                            printLn = printLn + " B";
                            break;
                        case 3:
                            printLn = printLn + " N";
                            break;
                        case 4:
                            printLn = printLn + " R";
                            break;
                        case 5:
                            printLn = printLn + " Q";
                            break;
                        case 6:
                            printLn = printLn + " K";
                            break;
                        case 7:
                            printLn = printLn + " p";
                            break;
                        case 8:
                            printLn = printLn + " b";
                            break;
                        case 9:
                            printLn = printLn + " n";
                            break;
                        case 10:
                            printLn = printLn + " r";
                            break;
                        case 11:
                            printLn = printLn + " q";
                            break;
                        case 12:
                            printLn = printLn + " k";
                            break;
                        default:
                            printLn = printLn + "  ";
                            break;

                    }


                }
                Console.WriteLine(printLn);
            }
        }

    }
}

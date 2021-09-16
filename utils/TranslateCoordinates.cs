using System;
using System.Collections.Generic;
using System.Text;

namespace SkakRobot.Utils
{
    public class TranslateCoordinates
    {
        private static int TranslateLetterToInt(char coord)
        {
            switch (coord) {
                case 'a':
                case 'A':
                    return 1;
                    
                case 'b':
                case 'B':
                    return 2;
                    
                case 'c':
                case 'C':
                    return 3;
                    
                case 'd':
                case 'D':
                    return 4;
                    
                case 'e':
                case 'E':
                    return 5;
                    
                case 'f':
                case 'F':
                    return 6;
                   
                case 'g':
                case 'G':
                    return 7;
                  
                case 'h':
                case 'H':
                    return 8;
                  

                default:
                    return 0;
                   

            }
            
        }


        public static int[] TranslateANToXY(string move)
        {

            if (move.Length == 2)
            {
                

                int x = TranslateLetterToInt(move[0]);
                double yDouble = Char.GetNumericValue(move[1]);
                int y = Convert.ToInt32(yDouble);
                int[] coords = { x, y };
                return coords;
                
            }
            Console.WriteLine("Length: " + move.Length);
            int[] standart = { 1, 1 };
            return standart;


        }

    }
}

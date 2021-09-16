using System;
using System.Collections.Generic;
using System.Text;
using SkakRobot.Utils;

namespace SkakRobot
{
    class MovementEvent
    {

        private int[,] pieceLocation;

        public MovementEvent(int[,] pieceLocation)
        {
            this.pieceLocation = pieceLocation;
        }

        public void pieceMoved(string from,string to, bool isPlayer)
        {

            int[] fromPos = TranslateCoordinates.TranslateANToXY(from);
            int[] toPos = TranslateCoordinates.TranslateANToXY(to);

            int x = toPos[0] -1;
            int y = toPos[1] - 1;

            int x2 = fromPos[0] - 1;
            int y2 = fromPos[1] - 1;

            //DobotMove(x2, y2, x, y, pieceLocation[y, x] != 0);

            pieceLocation[y , x]  = pieceLocation[y2, x2];
            pieceLocation[y2, x2] = 0;
        }



    }
}

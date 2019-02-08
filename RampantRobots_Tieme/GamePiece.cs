using System;
using System.Collections.Generic;

namespace RampantRobots_Tieme
{
    public class GamePiece
    {
        public int Xpos { get; set; }
        public int Ypos { get; set; }

        public void Move(int direction)
        {
            // 0: north, 1: east, etc.
            switch (direction)
            {
                case 0: Ypos -= 1; break;
                case 1: Xpos += 1; break;
                case 2: Ypos += 1; break;
                case 3: Xpos -= 1; break;
            }
        }

        public bool LocEqual(int tempX, int tempY)
        {
            if (this.Xpos == tempX & this.Ypos == tempY)
                return true;
            else
                return false;
        }

        public bool ListContain(int Xpos, int Ypos, List<Robot> robots)
        {
            foreach (Robot tempbot in robots)
            {
                if (Xpos == tempbot.Xpos & Ypos == tempbot.Ypos)
                return true;
            }

            return false;
        }

        public Boolean ValidMoveRobot(GamePiece tempPiece, int direction, Mechanic mec, List<Robot> robots, int xBoundary, int yBoundary)
        {
            foreach (Robot tempbot in robots)
            {
                if (tempbot.LocEqual(tempPiece.Xpos, tempPiece.Ypos))
                {
                    switch (direction)
                    {
                        case 0:
                            if (tempPiece.Ypos == 0 || (tempPiece.Ypos - 1 == mec.Ypos & tempPiece.Xpos == mec.Xpos)||ListContain(tempPiece.Xpos, tempPiece.Ypos-1, robots))
                                return false;
                            break;
                        case 1:
                            if (tempPiece.Xpos == xBoundary-1 || (tempPiece.Xpos + 1 == mec.Xpos & tempPiece.Ypos == mec.Ypos) || ListContain(tempPiece.Xpos+1, tempPiece.Ypos, robots))
                                return false;
                            break;
                        case 2:
                            if (tempPiece.Ypos == yBoundary-1 || (tempPiece.Ypos + 1 == mec.Ypos & tempPiece.Xpos == mec.Xpos) || ListContain(tempPiece.Xpos, tempPiece.Ypos + 1, robots))
                                return false;
                            break;
                        case 3:
                            if (tempPiece.Xpos == 0 || (tempPiece.Xpos - 1 == mec.Xpos & tempPiece.Ypos == mec.Ypos) || ListContain(tempPiece.Xpos-1, tempPiece.Ypos, robots))
                                return false;
                            break;
                    }
                }
            }
            return true;
        }

        public Boolean ValidMoveMechanic(Mechanic mec, int direction, int xBoundary, int yBoundary)
        {
            switch (direction)
            {
                case 0:
                    if (mec.Ypos == 0)
                        return false;
                    break;
                case 1:
                    if (mec.Xpos == xBoundary-1)
                        return false;
                    break;
                case 2:
                    if (mec.Ypos == yBoundary-1)
                        return false;
                    break;
                case 3:
                    if (mec.Xpos == 0)
                        return false;
                    break;
            }

            return true;
        }
    }
}
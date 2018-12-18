using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RampantRobots_Tieme
{
    public class Mechanic
    {
        public int Xpos { get; set; }
        public int Ypos { get; set; }

        public int Xboundary { get; set; }
        public int Yboundary { get; set; }

        public Mechanic(int xpos, int ypos)
        {
            this.Xpos = xpos;
            this.Ypos = ypos;
        }

        public void Move(string moveSet)
        {
            foreach (char c in moveSet)
            {
                if (ValidMove(c.ToString(), this.Xboundary, this.Yboundary))
                {
                    if (c.Equals('w') || c.Equals('W'))
                    {
                        this.Ypos += 1;
                    }
                    if (c.Equals('s') || c.Equals('S'))
                    {
                        this.Ypos += -1;
                    }
                    if (c.Equals('d') || c.Equals('D'))
                    {
                        this.Xpos += 1;
                    }
                    if (c.Equals('a') || c.Equals('A'))
                    {
                        this.Ypos += -1;
                    }
                }
            }
        }

        public Boolean ValidMove(string Direction,int xBoundary, int yBoundary)
        {
            if (Direction.Equals('w') || Direction.Equals('W'))
            {
                if (this.Ypos == yBoundary)
                {
                    return false;
                }
            }
            if (Direction.Equals('s') || Direction.Equals('S'))
            {
                if (this.Ypos == 0)
                {
                    return false;
                }
            }
            if (Direction.Equals('a') || Direction.Equals('A'))
            {
                if (this.Xpos == 0)
                {
                    return false;
                }
            }
            if (Direction.Equals('d') || Direction.Equals('D'))
            {
                if (this.Xpos == xBoundary)
                {
                    return false;
                }
            }
            return true;
        }
    }

}

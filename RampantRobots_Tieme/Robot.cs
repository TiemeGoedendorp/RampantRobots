using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RampantRobots_Tieme
{
    public class Robot : GamePiece
    {
        public Robot(int xpos, int ypos)
        {
            this.Xpos = xpos;
            this.Ypos = ypos;
        }
    }
}

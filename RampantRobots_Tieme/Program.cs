﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RampantRobots_Tieme
{
    class program
    {
        static void Main(string[] args)
        {
            Factory FactoryTest = new Factory(4, 4, 6, 20, true);
            FactoryTest.Run();
        }
    }   
}

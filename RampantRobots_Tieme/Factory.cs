using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RampantRobots_Tieme
{
    class Factory
    {
        static Random random = new Random();
        public int xBoundary { get; set; }
        public int yBoundary { get; set; }
        public int numOfRobots { get; set; }
        public int turns { get; set; }
        public int roundTurns { get; set; }

        public bool robotsMove { get; set; }

        //Mechanic en robots aanmaken
        public Mechanic mec = new Mechanic(0, 0);
        public List<Robot> Robots = new List<Robot>();

        // constructor
        public Factory(int XBoundary, int YBoundary, int robots, int Turns, bool RobotsMove)
        {
            this.xBoundary = XBoundary;
            this.yBoundary = YBoundary;
            this.numOfRobots = robots;
            this.turns = Turns;
            this.robotsMove = RobotsMove;
            this.roundTurns = Turns;

            // Robots toevoegen op plekken waar geen mechanic of andere robot staat
            for (int i = 0; i < numOfRobots; i++)
            {
                Robot newRobot = new Robot(random.Next(0, xBoundary), random.Next(0, yBoundary));
                if (Robots != null)
                {
                    foreach (Robot tempbot in Robots)
                    {
                        if (tempbot.Xpos == newRobot.Xpos & tempbot.Ypos == newRobot.Ypos)
                            i--;
                    }
                }

                if (newRobot.Xpos == mec.Xpos & newRobot.Ypos == mec.Ypos)
                    i--;
                else
                {
                    Robots.Add(newRobot);
                }
            }
        }

        // Het veld tekenen
        public void draw()
        {
            Console.WriteLine("Wellllcoommeee toooo rraamppaannnttt rooobbboootttssss \nYou can move your mechanic with the WASD keys, dont use other keys because \nit will use up your turns!\nTry to catch and KILL all the robots! \nyou can kill the robots by ending your turn on their spaces");
            // x en y intialiseren
            int n = 0;
            int m = 0;
            StringBuilder Field = new StringBuilder();
            while (n < this.yBoundary)
            {
                while (m < this.xBoundary)
                {
                    Field.Append('.');
                    // Als het de coordinaten van een robot is, verwijder dan de . die ervoor kwam en teken een Robot.
                    foreach (Robot tempbot in Robots)
                        if (tempbot.LocEqual(m, n))
                        {
                            Field.Length--;
                            Field.Append('R');
                        }

                    // Als het de coordinaten van de mechanic zijn, teken dan de mechanic
                    if (mec.Xpos == m & mec.Ypos == n)
                    {
                        Field.Length--;
                        Field.Append('M');
                    }

                    m++;
                }

                m = 0;
                Field.AppendLine();
                n++;
            }

            Console.WriteLine(Field.ToString());
            Console.WriteLine("\n");
            Console.WriteLine($"You have {roundTurns} turns left");
        }

        public void Playround()
        {
            Console.WriteLine("Press enter to continue");
            string input = Console.ReadLine();
            input = input.ToLower();
            foreach (char c in input)
            {
                if (c == 'w')
                {
                    if(robotsMove)
                    foreach (Robot tempbot in Robots)
                    {
                        int move = random.Next(0, 4);
                        if (tempbot.ValidMoveRobot(tempbot, move, mec, Robots, xBoundary, yBoundary))
                            tempbot.Move(move);
                    }

                    if (mec.ValidMoveMechanic(mec, 0, xBoundary, yBoundary))
                        mec.Move(0);
                }

                if (c == 'd')
                {
                    if(robotsMove)
                    foreach (Robot tempbot in Robots)
                    {
                        int move = random.Next(0, 4);
                        if (tempbot.ValidMoveRobot(tempbot, move, mec, Robots, xBoundary, yBoundary))
                            tempbot.Move(move);
                    }

                    if (mec.ValidMoveMechanic(mec, 1, xBoundary, yBoundary))
                        mec.Move(1);
                }

                if (c == 's')
                {
                    if(robotsMove)
                    foreach (Robot tempbot in Robots)
                    {
                        int move = random.Next(0, 4);
                        if (tempbot.ValidMoveRobot(tempbot, move, mec, Robots, xBoundary, yBoundary))
                            tempbot.Move(move);
                    }

                    if (mec.ValidMoveMechanic(mec, 2, xBoundary, yBoundary))
                        mec.Move(2);
                }

                if (c == 'a')
                {
                    if(robotsMove)
                    foreach (Robot tempbot in Robots)
                    {
                        int move = random.Next(0, 4);
                        if (tempbot.ValidMoveRobot(tempbot, move, mec, Robots, xBoundary, yBoundary))
                            tempbot.Move(move);
                    }

                    if (mec.ValidMoveMechanic(mec, 3, xBoundary, yBoundary))
                        mec.Move(3);
                }
            }

            Console.Clear();
            draw();
        }

        public void Kill(Mechanic mec, List<Robot> robots)
        {
            //andersom over de lijst heen loopen zodat je een robot kan verwijderen als hij op de mechanic eindigt
            foreach (Robot tempbot in robots.ToList())
            {
                if (tempbot.LocEqual(mec.Xpos, mec.Ypos))
                {
                    robots.Remove(tempbot);
                }
            }
        }

        public void Run()
        {
            Boolean Wingame = false;
            Console.Clear();
            draw();
            while (roundTurns > 0)
            {
                roundTurns--;
                Playround();
                Kill(mec, Robots);
                if (Robots.Count == 0)
                {
                    Wingame = true;
                    EndGame(Wingame);
                }
            }

            EndGame(Wingame);
            Console.ReadLine();
        }

        public void EndGame(bool wingame)
        {
            if (wingame)
            Console.WriteLine("Congratulations, you KILLED all the INNOCENT CUTE LITTLE robots! \nWould you like to play again? \nY/N");
            else
            Console.WriteLine("You did not succeed in killing all the INNOCENT CUTE  LITTLE robots \nWould you like to play again? \nY / N");
            string input = Console.ReadLine();
            input = input.ToLower();
            if (input == 'y'.ToString())
            {

                Factory newFactory = new Factory(this.xBoundary, this.yBoundary, this.numOfRobots, this.turns, this.robotsMove);
                newFactory.Run();
            }
            else if(input == 'n'.ToString())
            Environment.Exit(1);
            else
            Environment.Exit(1);
        }
    }
}
// Play round
    //WIN GAME
    // iets leuks daarvan maken
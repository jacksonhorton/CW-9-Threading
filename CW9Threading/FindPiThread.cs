/*
 *  Name: Jackson Horton
 *  CW 9
 *  This class houses the object created and used by each thread.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW9Threading
{
    internal class FindPiThread
    {
        private Random rand;
        private int DartsToThrow;
        private int DartsLandedInside;

        public FindPiThread(int dartsToThrow)
        {
            rand = new Random();
            DartsLandedInside = 0;
            this.DartsToThrow = dartsToThrow;
        }

        public int GetDartsInside()
        {
            return DartsLandedInside;
        }

        private bool isInCircle(double x, double y)
        {
            // returns is a given point is within a circle (or quarter circle) of radius 1.
            double radius = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));

            return radius <= 1;
        }

        // needs to be public and void to correctly interact with Thread functions
        public void throwDarts()
        {
            double x, y;
            for (int i = 0; i < DartsToThrow; i++)
            {
                x = rand.NextDouble();
                y = rand.NextDouble();

                //Console.WriteLine(x + " " + y);
                if (isInCircle(x, y))
                {
                    DartsLandedInside++;
                }
            }

        }
    }
}

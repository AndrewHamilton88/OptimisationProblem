using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class FixedVariables
    {
        public int StartingSeeds = 1000;
        public int StepsClimbed = 100;
        public int MutationsAroundAPoint = 10;
        
        public static int NumberOfStages = 4;
        public static int MinimumGreenTime = 7;
        public static int IntergreenTime = 5;
        public static int MaximumGreenTime = 25;
        public static int IntergreenStageNumber = 99;
        public static int MaxCycleTime = 120;

        public double[] Stage1 = { 3, 3, 1, 1 };
        public double[] Stage2 = { 5, 1, 1, 1 };
        public double[] Stage3 = { 2, 2, 1, 3 };
        public double[] Stage4 = { 8, 2, 1, 1 };
        //double [] will contain [0] = queue length, [1] = arrival rate, [2] = discharge rate, [3] = minimum green time
    }
}

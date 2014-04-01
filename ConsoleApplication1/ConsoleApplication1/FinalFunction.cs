using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class FinalFunction
    {
        private List<double[]> CopyRoadState(List<double[]> CyclePlan)
        {
            List<double[]> Returner = new List<double[]>();
            foreach (double[] item in CyclePlan)
            {
                Returner.Add(item);
            }
            return Returner;
        }

        public double RunnerFunction(List<int[]> CyclePlan, double LeastDelay, List<double[]> CurrentRoadState)
        {
            Performance Perf = new Performance();
            Queue_Lengths Queue = new Queue_Lengths();

            double TempDelayTotal = 0;
            List<double[]> TempRoadState = CopyRoadState(CurrentRoadState);

            foreach (int[] Stage in CyclePlan)
            {
                if (TempDelayTotal <= LeastDelay)
                {
                    TempDelayTotal += Perf.DelayFunctionOtherStages(Stage[0], Stage[1], TempRoadState, LeastDelay);   //Determines 'off' stages's delay  
                    TempRoadState = Queue.UpdateQueueLength(Stage[0], Stage[1], TempRoadState);     //Updates current queues
                    TempDelayTotal += Perf.DelayFunctionCurrentStage(Stage[0], Stage[1], TempRoadState);   //Calculates the delay to the remaining queued vehicles on current stage
                }
                else
                {
                    return 9999999999;
                }
            }
            return TempDelayTotal;
        }
    }
}

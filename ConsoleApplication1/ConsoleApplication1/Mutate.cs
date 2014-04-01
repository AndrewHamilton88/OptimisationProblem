using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Mutate
    {
        int NumberOfStages = FixedVariables.NumberOfStages;
        int MinimumGreenTime = FixedVariables.MinimumGreenTime;
        int IntergreenTime = FixedVariables.IntergreenTime;
        int MaximumGreenTime = FixedVariables.MaximumGreenTime;
        int IntergreenStageNumber = FixedVariables.IntergreenStageNumber;
        static int MaxCycleTime = FixedVariables.MaxCycleTime;

        List<int[]> InitialCyclePlanList = new List<int[]>();
        Random RandomGenerator = new Random();

        private List<int[]> Copy(List<int[]> CyclePlan)
        {
            List<int[]> Returner = new List<int[]>();
            foreach (int[] item in CyclePlan)
            {
                Returner.Add(item);
            }
            return Returner;
        }

        private int CopyInt(int Value)
        {
            int Result = Value;
            return Result;
        }

        public List<int[]> MutateCyclePlan(List<int[]> InitialCyclePlan)
        {
            int NumberOfStages = InitialCyclePlan.Count() / 2;              //This is divided by two otherwise it would count the intergreen stage as well
            int MutateNumber = RandomGenerator.Next(1, NumberOfStages + 1);     //This is the position number of the stage which will be mutated
            int CurrentStageLength = InitialCyclePlan[2 * MutateNumber - 2][1];     // [(StageNumber, StageLength)...] but want the altnerate numbers to avoid the intergreen period
            int NewStageLength;
            int Difference = 0;

            if (CurrentStageLength == MinimumGreenTime)
            {
                NewStageLength = MinimumGreenTime + 1;
                Difference = 1;
            }
            if (CurrentStageLength == MaximumGreenTime)
            {
                NewStageLength = MaximumGreenTime - 1;
                Difference = -1;
            }
            else
            {
                Difference += RandomGenerator.Next(0, 1) * 2 - 1;           //This generates a random number of either -1 and +1
                NewStageLength = CurrentStageLength + Difference;
            }

            int OtherStageLength;
            int TempCounter = 0;

            while (TempCounter < 10)        //The function trials up to 10 other stages to include the 'difference' into the cycle plan
            {
                int RandomOtherNumber = RandomGenerator.Next(1, NumberOfStages + 1);
                if (RandomOtherNumber != MutateNumber)
                {
                    OtherStageLength = CopyInt(InitialCyclePlan[2 * RandomOtherNumber - 2][1]);
                    OtherStageLength -= Difference;                     //The difference must be subtracted to ensure the cycle plan has the correct time.

                    if (!(OtherStageLength < MinimumGreenTime || OtherStageLength > MaximumGreenTime))
                    {
                        List<int[]> FinalCyclePlanList = Copy(InitialCyclePlan);
                        FinalCyclePlanList[2 * MutateNumber - 2][1] = NewStageLength;
                        FinalCyclePlanList[2 * RandomOtherNumber - 2][1] = OtherStageLength;
                        return FinalCyclePlanList;
                    }
                }
                TempCounter++;
            }
            return InitialCyclePlan;      //If no adjustment can be made then the Initial Cycle Plan is returned
        }
    }
}

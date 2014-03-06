using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ConsoleApplication1
{
    class Optimization_Problem
    {
        double[] Phase1 = { 3, 1, 2, 7 };
        double[] Phase2 = { 2, 1.5, 2, 7 };
        double[] Phase3 = { 6, 2, 3, 7 };
        double[] Phase4 = { 7, 2.5, 3, 7 };
        //double [] will contain [0] = queue length, [1] = arrival rate, [2] = discharge rate, [3] = minimum green time

        int NumberOfStages = 4;             //In this simple scenario, Phase1, etc are considered as Stages
        int NumberOfTimeSteps = 10;

        List<double[]> ListOfPhases = new List<double[]>();

        private List<double[]> PopulatePhases()
        {
            ListOfPhases.Add(Phase1);
            ListOfPhases.Add(Phase2);
            ListOfPhases.Add(Phase3);
            ListOfPhases.Add(Phase4);
            return ListOfPhases;
        }

        private List<double[]> UpdateQueueLength(int CurrentStage, double time, List<double[]> CurrentRoadState)
        {
            List<double[]> NewRoadState = CurrentRoadState;
            NewRoadState[CurrentStage - 1][0] += (NewRoadState[CurrentStage - 1][1] - NewRoadState[CurrentStage - 1][2] * time);   //This is updating the current stage which is on to reflect the current arrival and discharge rates for the specified time
            if (NewRoadState[CurrentStage - 1][0] < 0)
            {
                NewRoadState[CurrentStage - 1][0] = 0;
            }

            for (int Stage = 1; Stage < NumberOfStages + 1; Stage++)  //This updates the stopped stages using the arrival rate (nothing will be discharged)
            {
                if (Stage != CurrentStage)
                {
                    NewRoadState[Stage - 1][0] += (NewRoadState[Stage - 1][1] * time);  
                }
            }
            return NewRoadState;
        }

        private double DelayFunctionOtherStages(int CurrentStage, double TimeActive, List<double[]> RoadState, double CurrentLowestDelay)  //RoadState[0] = Phase1, RoadState[1] = Phase2, RoadState[2] = Phase3
        {
            double DelayOnOtherStages = 0; //Currently ignores any delay that would occur to the active stage...

            for (int Stage = 1; Stage < NumberOfStages + 1; Stage++)
            {
                if (DelayOnOtherStages <= CurrentLowestDelay)
                {
                    if (Stage != CurrentStage)
                    {
                        DelayOnOtherStages += TimeActive * (RoadState[Stage - 1][0] + TimeActive * (RoadState[Stage - 1][1]));
                    }
                }
                else
                {
                    return 99999999999.00;
                }

            }
            return DelayOnOtherStages;
        }

        private double DelayFunctionCurrentStage(int CurrentStage, double TimeActive, List<double[]> RoadState)  //RoadState[0] = Phase1, RoadState[1] = Phase2, RoadState[2] = Phase3
        {
            double DelayOnActiveStage = 0;
            DelayOnActiveStage += RoadState[CurrentStage - 1][0] * TimeActive;
            return DelayOnActiveStage;
        }

        private int[] Copy(int[] CyclePlan)
        {
            int Counter = 0;
            int[] TempList = new int[NumberOfTimeSteps];
            foreach (int item in CyclePlan)
            {
                TempList[Counter] = item;
                Counter++;
            }
            return TempList;
        }

        private List<int[]> EveryPossibilityV2()
        {
            List<int[]> AnswerList = new List<int[]>();
            int[] TempList = new int[NumberOfTimeSteps];

            List<int[]> TempStage1 = new List<int[]>();
            List<int[]> TempStage2 = new List<int[]>();
            List<int[]> TempStage3 = new List<int[]>();
            List<int[]> TempStage4 = new List<int[]>();
            List<int[]> TempStage5 = new List<int[]>();
            List<int[]> TempStage6 = new List<int[]>();
            List<int[]> TempStage7 = new List<int[]>();
            List<int[]> TempStage8 = new List<int[]>();
            List<int[]> TempStage9 = new List<int[]>();
            List<int[]> TempStage10 = new List<int[]>();
            /*List<int[]> TempStage11 = new List<int[]>();
            List<int[]> TempStage12 = new List<int[]>();
            List<int[]> TempStage13 = new List<int[]>();
            List<int[]> TempStage14 = new List<int[]>();
            List<int[]> TempStage15 = new List<int[]>();
            List<int[]> TempStage16 = new List<int[]>();
            List<int[]> TempStage17 = new List<int[]>();
            List<int[]> TempStage18 = new List<int[]>();
            List<int[]> TempStage19 = new List<int[]>();
            List<int[]> TempStage20 = new List<int[]>();*/

            for (int Stage1 = 1; Stage1 < NumberOfStages + 1; Stage1++)
            {
                TempList[0] = Stage1;
                TempStage1.Add(ObjectCopier.Clone(TempList));
            }

            foreach (int[] Stage in TempStage1)
            {
                for (int StageX = 1; StageX < NumberOfStages + 1; StageX++)
                {
                    Stage[1] = StageX;
                    TempList = Copy(Stage);
                    TempStage2.Add(TempList);
                }
            }
            Console.WriteLine("TempStage2 Complete");
            foreach (int[] Stage in TempStage2)
            {
                for (int StageX = 1; StageX < NumberOfStages + 1; StageX++)
                {
                    Stage[2] = StageX;
                    TempList = Copy(Stage);
                    TempStage3.Add(TempList);
                }
            }
            Console.WriteLine("TempStage3 Complete");

            foreach (int[] Stage in TempStage3)
            {
                for (int StageX = 1; StageX < NumberOfStages + 1; StageX++)
                {
                    Stage[3] = StageX;
                    TempList = Copy(Stage);
                    TempStage4.Add(TempList);
                }
            }
            Console.WriteLine("TempStage4 Complete");
            foreach (int[] Stage in TempStage4)
            {
                for (int StageX = 1; StageX < NumberOfStages + 1; StageX++)
                {
                    Stage[4] = StageX;
                    TempList = Copy(Stage);
                    TempStage5.Add(TempList);
                }
            }
            Console.WriteLine("TempStage5 Complete");
            foreach (int[] Stage in TempStage5)
            {
                for (int StageX = 1; StageX < NumberOfStages + 1; StageX++)
                {
                    Stage[5] = StageX;
                    TempList = Copy(Stage);
                    TempStage6.Add(TempList);
                }
            }
            Console.WriteLine("TempStage6 Complete");
            foreach (int[] Stage in TempStage6)
            {
                for (int StageX = 1; StageX < NumberOfStages + 1; StageX++)
                {
                    Stage[6] = StageX;
                    TempList = Copy(Stage);
                    TempStage7.Add(TempList);
                }
            }
            Console.WriteLine("TempStage7 Complete");
            foreach (int[] Stage in TempStage7)
            {
                for (int StageX = 1; StageX < NumberOfStages + 1; StageX++)
                {
                    Stage[7] = StageX;
                    TempList = Copy(Stage);
                    TempStage8.Add(TempList);
                }
            }
            Console.WriteLine("TempStage8 Complete");
            foreach (int[] Stage in TempStage8)
            {
                for (int StageX = 1; StageX < NumberOfStages + 1; StageX++)
                {
                    Stage[8] = StageX;
                    TempList = Copy(Stage);
                    TempStage9.Add(TempList);
                }
            }
            Console.WriteLine("TempStage9 Complete = " + TempStage9.Count());
            foreach (int[] Stage in TempStage9)
            {
                for (int StageX = 1; StageX < NumberOfStages + 1; StageX++)
                {
                    Stage[9] = StageX;
                    TempList = Copy(Stage);
                    TempStage10.Add(TempList);
                }
            }
            Console.WriteLine("TempStage10 Complete = " + TempStage10.Count());

            /*foreach (int[] Stage in TempStage10)
            {
                for (int StageX = 1; StageX < NumberOfStages + 1; StageX++)
                {
                    Stage[10] = StageX;
                    TempList = Copy(Stage);
                    TempStage11.Add(TempList);
                }
            }
            Console.WriteLine("TempStage11 Complete = " + TempStage11.Count());

            foreach (int[] Stage in TempStage11)
            {
                for (int StageX = 1; StageX < NumberOfStages + 1; StageX++)
                {
                    Stage[11] = StageX;
                    TempList = Copy(Stage);
                    TempStage12.Add(TempList);
                }
            }
            Console.WriteLine("TempStage12 Complete = " + TempStage12.Count());

            foreach (int[] Stage in TempStage12)
            {
                for (int StageX = 1; StageX < NumberOfStages + 1; StageX++)
                {
                    Stage[12] = StageX;
                    TempList = Copy(Stage);
                    TempStage13.Add(TempList);
                }
            }
            Console.WriteLine("TempStage13 Complete = " + TempStage13.Count());

            foreach (int[] Stage in TempStage13)
            {
                for (int StageX = 1; StageX < NumberOfStages + 1; StageX++)
                {
                    Stage[13] = StageX;
                    TempList = Copy(Stage);
                    TempStage14.Add(TempList);
                }
            }
            Console.WriteLine("TempStage14 Complete = " + TempStage14.Count());

            foreach (int[] Stage in TempStage14)
            {
                for (int StageX = 1; StageX < NumberOfStages + 1; StageX++)
                {
                    Stage[14] = StageX;
                    TempList = Copy(Stage);
                    TempStage15.Add(TempList);
                }
            }
            Console.WriteLine("TempStage15 Complete = " + TempStage15.Count());

            foreach (int[] Stage in TempStage15)
            {
                for (int StageX = 1; StageX < NumberOfStages + 1; StageX++)
                {
                    Stage[15] = StageX;
                    TempList = Copy(Stage);
                    TempStage16.Add(TempList);
                }
            }
            Console.WriteLine("TempStage16 Complete = " + TempStage16.Count());

            foreach (int[] Stage in TempStage16)
            {
                for (int StageX = 1; StageX < NumberOfStages + 1; StageX++)
                {
                    Stage[16] = StageX;
                    TempList = Copy(Stage);
                    TempStage17.Add(TempList);
                }
            }
            Console.WriteLine("TempStage17 Complete = " + TempStage17.Count());

            foreach (int[] Stage in TempStage17)
            {
                for (int StageX = 1; StageX < NumberOfStages + 1; StageX++)
                {
                    Stage[17] = StageX;
                    TempList = Copy(Stage);
                    TempStage18.Add(TempList);
                }
            }
            Console.WriteLine("TempStage18 Complete = " + TempStage18.Count());

            foreach (int[] Stage in TempStage18)
            {
                for (int StageX = 1; StageX < NumberOfStages + 1; StageX++)
                {
                    Stage[18] = StageX;
                    TempList = Copy(Stage);
                    TempStage19.Add(TempList);
                }
            }
            Console.WriteLine("TempStage19 Complete = " + TempStage19.Count());

            foreach (int[] Stage in TempStage19)
            {
                for (int StageX = 1; StageX < NumberOfStages + 1; StageX++)
                {
                    Stage[19] = StageX;
                    TempList = Copy(Stage);
                    TempStage20.Add(TempList);
                }
            }
            Console.WriteLine("TempStage20 Complete = " + TempStage20.Count());*/

            //return TempStage20;
            return TempStage10;
        }

        private List<int[]> EveryPossibility()
        {
            List<int[]> AnswerList = new List<int[]>();
            int[] TempList = new int[NumberOfTimeSteps];
            //int NumberOfPhases = 3;

            List<int[]> TempStage1 = new List<int[]>();
            List<int[]> TempStage2 = new List<int[]>();
            List<int[]> TempStage3 = new List<int[]>();
            List<int[]> TempStage4 = new List<int[]>();
            List<int[]> TempStage5 = new List<int[]>();
            List<int[]> TempStage6 = new List<int[]>();
            List<int[]> TempStage7 = new List<int[]>();
            List<int[]> TempStage8 = new List<int[]>();
            List<int[]> TempStage9 = new List<int[]>();
            List<int[]> TempStage10 = new List<int[]>();
            /*List<int[]> TempStage11 = new List<int[]>();
            List<int[]> TempStage12 = new List<int[]>();
            List<int[]> TempStage13 = new List<int[]>();
            List<int[]> TempStage14 = new List<int[]>();
            List<int[]> TempStage15 = new List<int[]>();
            List<int[]> TempStage16 = new List<int[]>();
            List<int[]> TempStage17 = new List<int[]>();
            List<int[]> TempStage18 = new List<int[]>();
            List<int[]> TempStage19 = new List<int[]>();
            List<int[]> TempStage20 = new List<int[]>();*/

            for (int Stage1 = 1; Stage1 < NumberOfStages + 1; Stage1++)
            {
                TempList[0] = Stage1;
                TempStage1.Add(ObjectCopier.Clone(TempList));
            }

            foreach (int[] Stage in TempStage1)
            {
                for (int Stage2 = 1; Stage2 < NumberOfStages + 1; Stage2++)
                {
                    TempList = Stage;
                    TempList[1] = Stage2;
                    TempStage2.Add(ObjectCopier.Clone(TempList));
                }
            }
            Console.WriteLine("TempStage2 Complete");
            foreach (int[] Stage in TempStage2)
            {
                for (int Stage3 = 1; Stage3 < NumberOfStages + 1; Stage3++)
                {
                    TempList = Stage;
                    Stage[2] = Stage3;
                    TempStage3.Add(ObjectCopier.Clone(Stage));
                }
            }
            Console.WriteLine("TempStage3 Complete");
            foreach (int[] Stage in TempStage3)
            {
                for (int Stage4 = 1; Stage4 < NumberOfStages + 1; Stage4++)
                {
                    TempList = Stage;
                    Stage[3] = Stage4;
                    TempStage4.Add(ObjectCopier.Clone(Stage));
                }
            }
            Console.WriteLine("TempStage4 Complete");
            foreach (int[] Stage in TempStage4)
            {
                for (int Stage5 = 1; Stage5 < NumberOfStages + 1; Stage5++)
                {
                    TempList = Stage;
                    Stage[4] = Stage5;
                    TempStage5.Add(ObjectCopier.Clone(Stage));
                }
            }
            Console.WriteLine("TempStage5 Complete");
            foreach (int[] Stage in TempStage5)
            {
                for (int Stage6 = 1; Stage6 < NumberOfStages + 1; Stage6++)
                {
                    TempList = Stage;
                    Stage[5] = Stage6;
                    TempStage6.Add(ObjectCopier.Clone(Stage));
                }
            }
            Console.WriteLine("TempStage6 Complete");
            foreach (int[] Stage in TempStage6)
            {
                for (int Stage7 = 1; Stage7 < NumberOfStages + 1; Stage7++)
                {
                    TempList = Stage;
                    Stage[6] = Stage7;
                    TempStage7.Add(ObjectCopier.Clone(Stage));
                }
            }
            Console.WriteLine("TempStage7 Complete");
            foreach (int[] Stage in TempStage7)
            {
                for (int Stage8 = 1; Stage8 < NumberOfStages + 1; Stage8++)
                {
                    TempList = Stage;
                    Stage[7] = Stage8;
                    TempStage8.Add(ObjectCopier.Clone(Stage));
                }
            }
            Console.WriteLine("TempStage8 Complete");
            foreach (int[] Stage in TempStage8)
            {
                for (int Stage9 = 1; Stage9 < NumberOfStages + 1; Stage9++)
                {
                    TempList = Stage;
                    Stage[8] = Stage9;
                    TempStage9.Add(ObjectCopier.Clone(Stage));
                }
            }
            Console.WriteLine("TempStage9 Complete = " + TempStage9.Count());
            foreach (int[] Stage in TempStage9)
            {
                for (int Stage10 = 1; Stage10 < NumberOfStages + 1; Stage10++)
                {
                    TempList = Stage;
                    Stage[9] = Stage10;
                    TempStage10.Add(ObjectCopier.Clone(Stage));
                }
            }
            Console.WriteLine("TempStage10 Complete = " + TempStage10.Count());

            /*foreach (int[] Stage in TempStage10)
            {
                for (int StageX = 1; StageX < NumberOfStages + 1; StageX++)
                {
                    TempList = Stage;
                    Stage[10] = StageX;
                    TempStage11.Add(ObjectCopier.Clone(Stage));
                }
            }
            Console.WriteLine("TempStage11 Complete = " + TempStage11.Count());

            foreach (int[] Stage in TempStage11)
            {
                for (int StageX = 1; StageX < NumberOfStages + 1; StageX++)
                {
                    TempList = Stage;
                    Stage[11] = StageX;
                    TempStage12.Add(ObjectCopier.Clone(Stage));
                }
            }
            Console.WriteLine("TempStage12 Complete = " + TempStage12.Count());

            foreach (int[] Stage in TempStage12)
            {
                for (int StageX = 1; StageX < NumberOfStages + 1; StageX++)
                {
                    TempList = Stage;
                    Stage[12] = StageX;
                    TempStage13.Add(ObjectCopier.Clone(Stage));
                }
            }
            Console.WriteLine("TempStage13 Complete = " + TempStage13.Count());

            foreach (int[] Stage in TempStage13)
            {
                for (int StageX = 1; StageX < NumberOfStages + 1; StageX++)
                {
                    TempList = Stage;
                    Stage[13] = StageX;
                    TempStage14.Add(ObjectCopier.Clone(Stage));
                }
            }
            Console.WriteLine("TempStage14 Complete = " + TempStage14.Count());

            foreach (int[] Stage in TempStage14)
            {
                for (int StageX = 1; StageX < NumberOfStages + 1; StageX++)
                {
                    TempList = Stage;
                    Stage[14] = StageX;
                    TempStage15.Add(ObjectCopier.Clone(Stage));
                }
            }
            Console.WriteLine("TempStage15 Complete = " + TempStage15.Count());

            foreach (int[] Stage in TempStage15)
            {
                for (int StageX = 1; StageX < NumberOfStages + 1; StageX++)
                {
                    TempList = Stage;
                    Stage[15] = StageX;
                    TempStage16.Add(ObjectCopier.Clone(Stage));
                }
            }
            Console.WriteLine("TempStage16 Complete = " + TempStage16.Count());

            foreach (int[] Stage in TempStage16)
            {
                for (int StageX = 1; StageX < NumberOfStages + 1; StageX++)
                {
                    TempList = Stage;
                    Stage[16] = StageX;
                    TempStage17.Add(ObjectCopier.Clone(Stage));
                }
            }
            Console.WriteLine("TempStage17 Complete = " + TempStage17.Count());

            foreach (int[] Stage in TempStage17)
            {
                for (int StageX = 1; StageX < NumberOfStages + 1; StageX++)
                {
                    TempList = Stage;
                    Stage[17] = StageX;
                    TempStage18.Add(ObjectCopier.Clone(Stage));
                }
            }
            Console.WriteLine("TempStage18 Complete = " + TempStage18.Count());

            foreach (int[] Stage in TempStage18)
            {
                for (int StageX = 1; StageX < NumberOfStages + 1; StageX++)
                {
                    TempList = Stage;
                    Stage[18] = StageX;
                    TempStage19.Add(ObjectCopier.Clone(Stage));
                }
            }
            Console.WriteLine("TempStage19 Complete = " + TempStage19.Count());

            foreach (int[] Stage in TempStage19)
            {
                for (int StageX = 1; StageX < NumberOfStages + 1; StageX++)
                {
                    TempList = Stage;
                    Stage[19] = StageX;
                    TempStage20.Add(ObjectCopier.Clone(Stage));
                }
            }
            Console.WriteLine("TempStage20 Complete = " + TempStage20.Count());*/

          
            //AnswerList = ObjectCopier.Clone(TempStage10);      //This stage has a massive impact on performance! So I've removed it at the moment 04/03/14    
            //return AnswerList;

            return TempStage10;
            //return TempStage5;
        }

        public void GenerateCSVFile(string filename)
        {
            List<int[]> EveryPossibleCyclePlan = new List<int[]>();
            EveryPossibleCyclePlan = UsableCyclePlans();

            //StreamWriter sw = new StreamWriter(@filename);
            StreamWriter sw = new StreamWriter(@"C:\Users\Andrew\Desktop\" + filename);
            foreach (int[] CyclePlan in EveryPossibleCyclePlan)
            {
                foreach (int Stage in CyclePlan)
                {
                    sw.Write(Stage + ",");
                }
                sw.WriteLine();
            }
            sw.Close();   
        }

        private List<int[]> UsableCyclePlans()
        {
            List<int[]> EveryPossibleCyclePlan = new List<int[]>();
            //EveryPossibleCyclePlan = EveryPossibility();
            EveryPossibleCyclePlan = EveryPossibilityV2();
            Console.WriteLine("Usable cycle plans being generated");

            List<int[]> UsableCyclePlans = new List<int[]>();

            //int Ticker1 = 0;  //Console Tickers to make sure that I know it's still working!
            //int Ticker2 = 0;  //

            foreach (int[] CyclePlan in EveryPossibleCyclePlan)
            {
                //Ticker1++; //Console Ticker
                bool[] UsedStages = new bool[NumberOfStages];
                int Counter = 0;

                foreach (int Stage in CyclePlan)
                {
                    UsedStages[Stage - 1] = true;
                }
                foreach (bool item in UsedStages)
                {
                    if (item == true)
                    {
                        Counter++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (Counter == NumberOfStages)
                {
                    UsableCyclePlans.Add(CyclePlan);
                }

                //Just to make sure it's still working
                /*if (Ticker1 == 10000)
                {
                    Ticker2++;
                    Console.WriteLine(Ticker2 * 1000);
                    Ticker1 = 0;
                }*/
            }
            Console.WriteLine("The number of usable cycle plans are: " + UsableCyclePlans.Count());

            return UsableCyclePlans;
        }

        private List<int[]> FileReader(string filename)
        {
            StreamReader file = new StreamReader(@filename);
            List<int[]> Results = new List<int[]>();
            string Line;

            // Read the file and display it line by line.

            while ((Line = file.ReadLine()) != null)
            {
                int StageCounter = 0;
                StageCounter = Line.Split(',').Count() - 1;
                int[] TempCyclePlan = new int[StageCounter];
                int TempCounter = 0;
                foreach (string Stage in Line.Split(','))
                {
                    if (Stage != "")
                    {
                        TempCyclePlan[TempCounter] = Convert.ToInt16(Stage);
                        TempCounter++;                        
                    }
                }
                Results.Add(TempCyclePlan);
            }
            file.Close();
            return Results;
        }
        
        public void RunnerFunction(string filename)
        {
            List<double[]> CurrentRoadState = PopulatePhases();
            List<int[]> EveryPossibleCyclePlan = new List<int[]>();
            //EveryPossibleCyclePlan = UsableCyclePlans();        //Only uses the allowable cycle plans, ie. one's which use all stages.
            EveryPossibleCyclePlan = FileReader(@filename);

            int[] BestCyclePlan = new int[NumberOfTimeSteps];
            double LeastDelay = 9999999999;

            int Ticker = 0;
            int Ticker2 = 0;
            
            foreach (int[] CyclePlan in EveryPossibleCyclePlan)
            {
                Ticker++;
                double TempDelayTotal = 0;
                List<double[]> TempRoadState = ObjectCopier.Clone(CurrentRoadState);
                foreach (int Stage in CyclePlan)
                {
                    if (TempDelayTotal <= LeastDelay)
                    {
                        TempDelayTotal += DelayFunctionOtherStages(Stage, TempRoadState[Stage - 1][3], TempRoadState, LeastDelay);   //Determines 'off' stages's delay  
                        TempRoadState = UpdateQueueLength(Stage, TempRoadState[Stage - 1][3], TempRoadState);     //Updates current queues
                        TempDelayTotal += DelayFunctionCurrentStage(Stage, TempRoadState[Stage - 1][3], TempRoadState);   //Calculates the delay to the remaining queued vehicles on current stage
                    }
                    else
                    {
                        break;
                    }
                }
                if (TempDelayTotal < LeastDelay)  //Currently this ignores any stage with the same amount of delay...
                {
                    LeastDelay = ObjectCopier.Clone(TempDelayTotal);
                    BestCyclePlan = ObjectCopier.Clone(CyclePlan);
                }
                if (Ticker == 10000)
                {
                    Ticker2++;
                    Console.WriteLine(Ticker * Ticker2);
                    Ticker = 0;
                }
            }

            Console.Write("The best cycle plan is: ");
            foreach (int stage in BestCyclePlan)
            {
                Console.Write(Convert.ToString(stage) + ",");
            }
            Console.Write(" with a Total Delay = " + Convert.ToString(LeastDelay));
            Console.Read();

        }

    }
}

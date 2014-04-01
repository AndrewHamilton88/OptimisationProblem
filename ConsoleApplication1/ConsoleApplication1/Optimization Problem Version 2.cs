using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ConsoleApplication1
{
    class Optimization_Problem_Version_2
    {
        double[] Phase1 = { 1, 1, 1, 1 };
        double[] Phase2 = { 1, 1, 1, 1 };
        double[] Phase3 = { 1, 1, 1, 1 };
        double[] Phase4 = { 1, 1, 1, 1 };
        double[] Phase5 = { 1, 1, 1, 1 };
        double[] Phase6 = { 1, 1, 1, 1 };
        double[] Phase7 = { 1, 1, 1, 1 };
        double[] Phase8 = { 1, 1, 1, 1 };
        double[] Phase9 = { 1, 1, 1, 1 };
        double[] Phase10 = { 1, 1, 1, 1 };
        double[] Phase11 = { 1, 1, 1, 1 };
        double[] Phase12 = { 1, 1, 1, 1 };
        //double [] will contain [0] = queue length, [1] = arrival rate, [2] = discharge rate, [3] = minimum green time

        int NumberOfStages = 4;
        int NumberOfTimeSteps = 10;

        List<double[]> ListOfPhases = new List<double[]>();

        private List<double[]> PopulatePhases()
        {
            ListOfPhases.Add(Phase1);
            ListOfPhases.Add(Phase2);
            ListOfPhases.Add(Phase3);
            ListOfPhases.Add(Phase4);
            ListOfPhases.Add(Phase5);
            ListOfPhases.Add(Phase6);
            ListOfPhases.Add(Phase7);
            ListOfPhases.Add(Phase8);
            ListOfPhases.Add(Phase9);
            ListOfPhases.Add(Phase10);
            ListOfPhases.Add(Phase11);
            ListOfPhases.Add(Phase12);
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

        /*private int[] Copy(int[] CyclePlan)
        {
            int Counter = 0;
            int[] TempList = new int[NumberOfTimeSteps];
            foreach (int item in CyclePlan)
            {
                TempList[Counter] = item;
                Counter++;
            }
            return TempList;
        }*/

        public void EveryPossibilityV3()
        {
            List<int[]> AnswerList = new List<int[]>();
            int[] TempList = new int[NumberOfTimeSteps];
            List<string> Filenames = new List<string>();

            for (int i = 1; i < NumberOfTimeSteps + 1; i++)
            {
                string FilenameBits = "Timestep" + Convert.ToString(i) + ".csv";
                Filenames.Add(FilenameBits);
            }

            //Write the first file independently so that all other timesteps can be built upon the same logic
            StreamWriter FirstFile = new StreamWriter(@Filenames[0]);
            for (int Stage1 = 1; Stage1 < NumberOfStages + 1; Stage1++)
            {
                TempList[0] = Stage1;
                foreach (int Stage in TempList)
                {
                    FirstFile.Write(Stage + ",");
                }
                FirstFile.WriteLine();
            }
            FirstFile.Close();

            for (int Timestep = 1; Timestep < NumberOfTimeSteps; Timestep++)
            {
                StreamReader sr = new StreamReader(@Filenames[Timestep - 1]);
                StreamWriter sw = new StreamWriter(@Filenames[Timestep]);

                string Line;

                // Read the previous file line by line
                while ((Line = sr.ReadLine()) != null)
                {
                    int[] TempCyclePlan = new int[NumberOfTimeSteps];
                    int TempCounter = 0;
                    foreach (string Stage in Line.Split(','))
                    {
                        if (Stage != "")
                        {
                            TempCyclePlan[TempCounter] = Convert.ToInt16(Stage);
                            TempCounter++;
                        }
                    }
                    for (int StageX = 1; StageX < NumberOfStages + 1; StageX++)
                    {
                        TempCyclePlan[Timestep] = StageX;
                        foreach (int Stage in TempCyclePlan)
                        {
                            sw.Write(Stage + ",");
                        }
                        sw.WriteLine();
                    }
                }
                sr.Close();
                Console.WriteLine("Filename" + Timestep + " Complete");
                sw.Close(); 

            }
        }


        private List<int[]> UsableCyclePlans()
        {
            List<int[]> EveryPossibleCyclePlan = new List<int[]>();
            //EveryPossibleCyclePlan = EveryPossibility();
            Optimization_Problem OP = new Optimization_Problem();
            EveryPossibleCyclePlan = OP.EveryPossibilityV2();
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

            //StreamWriter sw = new StreamWriter(@"output4.csv");   //This is for generating a csv file with all stage options with their corresponding performance value 
                                                                    //N.B. There are other parts of the code you will need to unblock for this to work...
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

                
                /*foreach (int item in CyclePlan)
                {
                    sw.Write(item + ",");
                }
                sw.Write(TempDelayTotal);
                sw.WriteLine();*/

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

            //sw.Close();
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

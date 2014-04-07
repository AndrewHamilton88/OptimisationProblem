using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            AllStages AS = new AllStages();
            TestClass TC = new TestClass();
            UsefulStages US = new UsefulStages();
            ParamicsStageBuilder PSB = new ParamicsStageBuilder();
            Stage_Generator SG = new Stage_Generator();
            Optimization_Problem OP = new Optimization_Problem();
            Optimization_Problem_Version_2 OP2 = new Optimization_Problem_Version_2();
            Initialising_Genome IG = new Initialising_Genome();
            Mutate MU = new Mutate();
            FixedVariables FV = new FixedVariables();
            SingleStageInitialGenerator SSIG = new SingleStageInitialGenerator();
            RunnerSingleStage RunSS = new RunnerSingleStage();

            
            /*Answer FinalAnswer = RunSS.RunAlgorithm(2, 1, 2, RunSS.PopulateStages(), 0);
            Console.Read();*/

            /*FinalFunction FF = new FinalFunction();
            Console.WriteLine(FF.RunnerFunction(FF.TestFunction(),99999,RunSS.PopulateStages()));
            Console.Read();*/

            RunnerCyclePlan Run = new RunnerCyclePlan();
            for (int i = FV.MutationsAroundAPoint; i < 101; i += 10)
            {
                Run.RunAlgorithm(FV.StartingSeeds, FV.StepsClimbed, i, Run.PopulateStages());
            }
            
            //Console.Read();

            /*StreamWriter sw = new StreamWriter(@"outputforhillclimber" + FV.StartingSeeds + "seeds," + FV.StepsClimbed + "steps," + FV.MutationsAroundAPoint + "Mutations" + ".csv");
            for (int j = 0; j < 10; j++)                       //This runs the whole model 100 times
            {
                RunnerCyclePlan Run = new RunnerCyclePlan();
                sw.WriteLine(Run.RunAlgorithm(FV.StartingSeeds, FV.StepsClimbed, FV.MutationsAroundAPoint, Run.PopulateStages()) + ",");
                Console.WriteLine(j + "Finished");
            }
            sw.Close();*/


            /*StreamWriter sw = new StreamWriter(@"outputforhillclimber" + FV.StartingSeeds + "seeds," + "Incremental_Steps," + FV.MutationsAroundAPoint + "Mutations" + ".csv");
            for (int i = FV.StepsClimbed; i < 1001; i += 10)         //This varies the number of mutations by increasing it by 5 (starting at 5 up to 50)
            {
                for (int j = 0; j < 1; j++)                       //This runs the whole model 100 times
                {
                    RunnerCyclePlan Run = new RunnerCyclePlan();
                    sw.WriteLine(FV.StartingSeeds + "Seeds," + i + "Steps," + FV.MutationsAroundAPoint + "Mutations," + Run.RunAlgorithm(FV.StartingSeeds, i, FV.MutationsAroundAPoint, Run.PopulateStages()) + ",");
                }
                Console.WriteLine(i + "Finished");
            }
            sw.Close();*/

            /*for (int i = FV.StepsClimbed; i < 101; i+=100)         //This varies the number of mutations by increasing it by 5 (starting at 5 up to 50)
            {
                StreamWriter sw = new StreamWriter(@"outputforhillclimber" + FV.StartingSeeds + "seeds," + i + "steps," + FV.MutationsAroundAPoint + "Mutations" + ".csv");
                for (int j = 0; j < 100; j++)                       //This runs the whole model 100 times
                {
                    RunnerCyclePlan Run = new RunnerCyclePlan();
                    sw.WriteLine(Run.RunAlgorithm(FV.StartingSeeds, i, FV.MutationsAroundAPoint, Run.PopulateStages()) + ",");
                }
                Console.WriteLine(i + "Finished");
                sw.Close();
            }*/

            //MU.MutateCyclePlan(IG.GenerateCyclePlan());
            //IG.GenerateCyclePlan();
            //OP.EveryPossibilityV3();
            //OP.RunnerFunction("Timestep10.csv");    //This runs the function
            //OP.RunnerFunction("UsableStages - 5 Timesteps and 4 Stages.csv");
            //OP.RunnerFunction("UsableStages - 10 Timesteps and 4 Stages.csv");    //This runs the function
            //OP.GenerateCSVFile("UsableStages - 20 Timesteps and 4 Stages.csv");                       //This generates the file showing all feasible cycle plans
            
            //SG.TwoPhaseStages();
            //SG.ThreePhaseStages(SG.TwoPhaseStages());

            /*CyclePlanGenerator CPG = new CyclePlanGenerator();

            Int64 nSequencePatterns = 1;

            CPG.traverseStages(120, 1, nSequencePatterns);

            Console.Write("Number of possible stage sequences: %lld\n", nSequencePatterns);
            Console.Read();
            //CPG.traverseStages(120, 1, 1);*/


            //AS.StagesGenerator();
            //AS.ReturnAllTJunctionStages();

            //AS.StageOptions();
            //AS.SimpleHighestStage(AS.StagesGenerator(@"OptimalCrossroadStages.txt"));
            //AS.CheckAllStages();
            //AS.AvoidingConflictsStage(AS.ReturnAllCrossroadStages());
            //AS.HowManyConflicts();
            //TC.DisplayResults();

            //AS.ReturnAllCrossroadStages();

            //US.AllUsefulStages();

            //PSB.MakeFile();


            /*List<List<int>> All = new List<List<int>>();
            List<int> Test = new List<int>();
            Test.Add(1);
            Test.Add(2);
            All.Add(Test);
            List<int> Test2 = new List<int>();
            Test2.Add(3);
            Test2.Add(41);
            All.Add(Test2);
            List<int> Test3 = new List<int>();
            Test3.Add(5);
            All.Add(Test3);
            foreach (List<int> item in All)
            {
                Console.WriteLine(item.Count());
                if (item.Count() == 2)
                {
                    Console.WriteLine("I don't understand this");
                }
            }
             */
            //Console.WriteLine(Test.Count());
            //Console.Read();

        }
    }
}

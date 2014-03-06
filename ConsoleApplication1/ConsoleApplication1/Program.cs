using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

            //OP.RunnerFunction("UsableStages - 10 Timesteps and 4 Stages.csv");    //This runs the function
            OP.GenerateCSVFile("UsableStages - 10 Timesteps and 4 Stages.csv");                       //This generates the file showing all feasible cycle plans
            
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

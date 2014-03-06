using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Stage_Generator
    {
        List<int> ListOfPhases = new List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12};
        List<int[]> Matrix = new List<int[]>();
        List<int[]> ListTwoPhaseStage = new List<int[]>();
        List<int[]> ListThreePhaseStage = new List<int[]>();

        /*int[] One = new int[12] { 0,1,1,0,0,1,1,2,2,0,0,1};           //This is using a '2' for an allowed conflict
        int[] Two = new int[12] {1,0,1,0,0,0,2,1,1,0,0,1};
        int[] Three = new int[12] { 1,1,0,1,1,1,2,1,1,1,0,1 };
        int[] Four = new int[12] { 0,0,1,0,1,1,0,0,1,1,2,2};
        int[] Five = new int[12] { 0,0,1,1,0,1,0,0,0,2,1,1};
        int[] Six = new int[12] { 1,0,1,1,1,0,1,1,1,2,1,1};
        int[] Seven = new int[12] { 1,2,2,0,0,1,0,1,1,0,0,1};
        int[] Eight = new int[12] { 2,1,1,0,0,1,1,0,1,0,0,0};
        int[] Nine = new int[12] { 2,1,1,1,0,1,1,1,0,1,1,1 };
        int[] Ten = new int[12] { 0,0,1,1,2,2,0,0,1,0,1,1 };
        int[] Eleven = new int[12] { 0,0,0,2,1,1,0,0,1,1,0,1 };
        int[] Twelve = new int[12] { 1,1,1,2,1,1,1,0,1,1,1,0 };*/

        int[] One = new int[12] { 0, 1, 1, 0, 0, 1, 1, 1, 1, 0, 0, 1 };     //Use this matrix if using the 'How many conflicts' solution as well.
        int[] Two = new int[12] { 1, 0, 1, 0, 0, 0, 1, 1, 1, 0, 0, 1 };
        int[] Three = new int[12] { 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 0, 1 };
        int[] Four = new int[12] { 0, 0, 1, 0, 1, 1, 0, 0, 1, 1, 1, 1 };
        int[] Five = new int[12] { 0, 0, 1, 1, 0, 1, 0, 0, 0, 1, 1, 1 };
        int[] Six = new int[12] { 1, 0, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1 };
        int[] Seven = new int[12] { 1, 1, 1, 0, 0, 1, 0, 1, 1, 0, 0, 1 };
        int[] Eight = new int[12] { 1, 1, 1, 0, 0, 1, 1, 0, 1, 0, 0, 0 };
        int[] Nine = new int[12] { 1, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1 };
        int[] Ten = new int[12] { 0, 0, 1, 1, 1, 1, 0, 0, 1, 0, 1, 1 };
        int[] Eleven = new int[12] { 0, 0, 0, 1, 1, 1, 0, 0, 1, 1, 0, 1 };
        int[] Twelve = new int[12] { 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0 };

        private List<int[]> PopulateMatrix()
        {
            Matrix.Add(One);
            Matrix.Add(Two);
            Matrix.Add(Three);
            Matrix.Add(Four);
            Matrix.Add(Five);
            Matrix.Add(Six);
            Matrix.Add(Seven);
            Matrix.Add(Eight);
            Matrix.Add(Nine);
            Matrix.Add(Ten);
            Matrix.Add(Eleven);
            Matrix.Add(Twelve);

            return Matrix;
        }

        public List<int[]> TwoPhaseStages()
        {
            PopulateMatrix();
            int TempInt;
            
            for (int i = 1; i < 13; i++)
            {
                for (int j = 1; j < 13; j++)
                {
                    TempInt = Matrix[i - 1][j - 1];      //We are checking i - 1 and j - 1 to make sure it is the right matrix reference but i and j are the normal phase numbers used

                    if (TempInt == 0)   
                    {}
                    else
                    {
                        if (i<j)
                        {
                            int[] TempArray = new int[2];
                            TempArray[0] = i;
                            TempArray[1] = j;
                            if (TempInt == 1)
                            {
                                ListTwoPhaseStage.Add(TempArray);
                            }
                        }
                    }
                }
            }

            //List<int[]> noDuplicates = ListTwoPhaseStage.Distinct().ToList();
            //foreach (int[] stage in noDuplicates)
            /*foreach (int[] stage in ListTwoPhaseStage)
            {
                foreach (int phase in stage)
                {
                    Console.Write(Convert.ToString(phase) + ",");
                }
                Console.WriteLine();
            }
            Console.Read();*/

            return ListTwoPhaseStage;
        }

        public List<int[]> ThreePhaseStages(List<int[]> TwoPhaseStages)
        {

            foreach (int[] stage in TwoPhaseStages)
            {
                int Phase1 = 0;
                int Phase2 = 0;
                int Counter = 0;
                foreach (int phase in stage)
                {
                    Counter++;
                    if (Counter == 1)
                    {
                        Phase1 = phase;
                    }
                    else
                    {
                        Phase2 = phase;
                    }
                }

                for (int i = 1; i < 13; i++)
                {
                    if (Matrix[Phase1-1][i-1] == 1 && Matrix[Phase2-1][i-1] == 1)
                    {
                        int[] TempArray = new int[3];
                        if (i>Phase2)
                        {
                            TempArray[0] = Phase1;
                            TempArray[1] = Phase2;
                            TempArray[2] = i;
                        }
                        if (i<Phase2 && i>Phase1)
                        {
                            TempArray[0] = Phase1;
                            TempArray[1] = i;
                            TempArray[2] = Phase2;
                        }
                        if (i<Phase1)
                        {
                            TempArray[0] = i;
                            TempArray[1] = Phase1;
                            TempArray[2] = Phase2;
                        }
                        
                        
                        ListThreePhaseStage.Add(TempArray);
                    }
                }
            }
            //ListThreePhaseStage.Sort();
            List<int[]> noDuplicates = ListThreePhaseStage.Distinct().ToList();
            foreach (int[] stage in noDuplicates)
            {
                foreach (int phase in stage)
                {
                    Console.Write(Convert.ToString(phase) + ",");
                }
                Console.WriteLine();
            }
            Console.Read();

            return ListThreePhaseStage;
        }

        public int HowManyConflicts(List<int> stage)
        {
            int Counter = 0;

            if ((stage.Contains(0) && stage.Contains(7)))
            {
                Counter++;
            }
            if ((stage.Contains(0) && stage.Contains(8)))
            {
                Counter++;
            }
            if ((stage.Contains(1) && stage.Contains(6)))
            {
                Counter++;
            }
            if ((stage.Contains(2) && stage.Contains(6)))
            {
                Counter++;
            }
            if ((stage.Contains(3) && stage.Contains(10)))
            {
                Counter++;
            }
            if ((stage.Contains(3) && stage.Contains(11)))
            {
                Counter++;
            }
            if ((stage.Contains(4) && stage.Contains(9)))
            {
                Counter++;
            }
            if ((stage.Contains(5) && stage.Contains(9)))
            {
                Counter++;
            }
            return Counter;
        }








    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ConsoleApplication1
{
    class CyclePlanGenerator
    {
        /*public const int nMinGreen = 7;
        public const int nIntergreen = 5;

        public const int nStages = 3;

        public const int nIncrement = 1;


        internal static void traverseStages(int remainingTime, int currentStage, int startStage, ref long nPatterns, List<CStageEvent> pattern, int iPattern)
        {
            while (remainingTime >= nIntergreen)
            {
                for (int iStage = 1; iStage <= nStages; iStage++)
                {
                    if (iStage != currentStage)
                    {
                        pattern[iPattern].iStage = 0;
                        pattern[iPattern].nRunTime = nIntergreen;
                        pattern[iPattern + 1].iStage = iStage;
                        pattern[iPattern + 1].nRunTime = nMinGreen;

                        traverseStages(remainingTime - nIntergreen - nMinGreen, iStage, startStage, ref nPatterns, pattern, iPattern + 2);
                    }
                }

                pattern[iPattern - 1].nRunTime += nIncrement;

                remainingTime -= nIncrement;
            }

            // Discard patterns where the start of the next cycle does not start with the same stage.
            if (currentStage != startStage)
                return;

            // Correct for under or over run.
            pattern[iPattern - 1].nRunTime += remainingTime;
            while (pattern[iPattern - 1].nRunTime <= 0)
            {
                iPattern--;
                pattern[iPattern - 1].nRunTime += pattern[iPattern].nRunTime;
            }

            //StreamWriter sw = new StreamWriter("Output.csv");
            
            // Print out this sequence
            for (int i = 0; i < iPattern; i++)
            {
                Console.Write("{0},{1:D},", pattern[i].iStage == 0 ? '-' : pattern[i].iStage + 'A' - 1, pattern[i].nRunTime);
            }
            Console.Write('\n');
            //sw.Write('\n');

            nPatterns++;
        }

        static void Main(string[] args)
        {
            long nPatterns = 0;

            int nCycleTime = 80;
            int nMaxChanges = (nCycleTime / (nMinGreen + nIntergreen) + 1) * 2;

            List<CStageEvent> pattern = new List<CStageEvent>(nMaxChanges);

            StreamWriter sw = new StreamWriter("Output.csv");
            // Print CSV column headings.
            for (int i = 0; i < nMaxChanges; i++)
            {
                sw.Write("Stage,Run Time,");
            }
            sw.Write('\n');

            for (int iStage = 1; iStage <= nStages; iStage++)
            {
                pattern[0].iStage = iStage;
                pattern[0].nRunTime = nMinGreen;
                traverseStages(nCycleTime - nMinGreen, iStage, iStage, ref nPatterns, pattern, 1);
            }

            Console.Write("Number of possible stage sequences: {0:D}\n", nPatterns);
        }
    }

    public class CStageEvent
    {
        public CStageEvent()
        {
            this.iStage = 0;
            this.nRunTime = 0;
        }
        public int iStage;
        public int nRunTime;*/
    }
}
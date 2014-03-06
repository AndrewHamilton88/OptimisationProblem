using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ConsoleApplication1
{
    class ParamicsStageBuilder
    {
        string StageFile = @"PooleJunctionMyStages.txt";
        string NewPrioritiesFile = "priorities_PooleMy11Stages";
        //string StageFile = @"StraightAndRight2Lane.txt";
        //string NewPrioritiesFile = "priorities_SR2Lane7Stage";

        string One = "from 1 to 4 MAJOR  map to phase \"A\" start offset 0.0 end offset 0.0 \"\"";
        string Two = "from 1 to 3 MAJOR  map to phase \"K\" start offset 0.0 end offset 0.0 \"\"";
        string Three = "from 1 to 2 MAJOR  map to phase \"G\" start offset 0.0 end offset 0.0 \"\"";
        string Four = "from 2 to 1 MAJOR  map to phase \"H\" start offset 0.0 end offset 0.0 \"\"";
        string Five = "from 2 to 4 MAJOR  map to phase \"E\" start offset 0.0 end offset 0.0 \"\"";
        string Six = "from 2 to 3 MAJOR  map to phase \"B\" start offset 0.0 end offset 0.0 \"\"";
        string Seven = "from 3 to 2 MAJOR  map to phase \"C\" start offset 0.0 end offset 0.0 \"\"";
        string Eight = "from 3 to 1 MAJOR  map to phase \"L\" start offset 0.0 end offset 0.0 \"\"";
        string Nine = "from 3 to 4 MAJOR  map to phase \"I\" start offset 0.0 end offset 0.0 \"\"";
        string Ten = "from 4 to 3 MAJOR  map to phase \"J\" start offset 0.0 end offset 0.0 \"\"";
        string Eleven = "from 4 to 2 MAJOR  map to phase \"F\" start offset 0.0 end offset 0.0 \"\"";
        string Twelve = "from 4 to 1 MAJOR  map to phase \"D\" start offset 0.0 end offset 0.0 \"\"";

        string OneNot = "from 1 to 4 BARRED";
        string TwoNot = "from 1 to 3 BARRED";
        string ThreeNot = "from 1 to 2 BARRED";
        string FourNot = "from 2 to 1 BARRED";
        string FiveNot = "from 2 to 4 BARRED";
        string SixNot = "from 2 to 3 BARRED";
        string SevenNot = "from 3 to 2 BARRED";
        string EightNot = "from 3 to 1 BARRED";
        string NineNot = "from 3 to 4 BARRED";
        string TenNot = "from 4 to 3 BARRED";
        string ElevenNot = "from 4 to 2 BARRED";
        string TwelveNot = "from 4 to 1 BARRED";

        public void MakeFile()
        {
            StreamWriter sw;
            //sw = new StreamWriter(@"C:\Dropbox\LanchesterRouteChoiceExperiment - Andrew's\TestBed\ConsoleApplication1\ConsoleApplication1\bin\Debug\" + NewPrioritiesFile);   //Laptop Version
            //sw = new StreamWriter(@"C:\Dropbox\Dropbox\LanchesterRouteChoiceExperiment - Andrew's\TestBed\ConsoleApplication1\ConsoleApplication1\bin\Debug\" + NewPrioritiesFile);   //Desktop Version
            sw = new StreamWriter(@NewPrioritiesFile);   //Bin folder Version

            sw.WriteLine("clear exit adherence model 0");
            sw.WriteLine();
            sw.WriteLine("actions signals post-2001 0");
            sw.WriteLine("stage offset 0 sec");

            int Counter = 0;
            string Line;

            // Read the file and display it line by line.
            System.IO.StreamReader File = new System.IO.StreamReader(StageFile);
            while ((Line = File.ReadLine()) != null)
            {
                Counter++;
                sw.WriteLine("stage " + Convert.ToString(Counter));
                sw.WriteLine("    20");
                sw.WriteLine("    min -5");
                sw.WriteLine("    max 20");
                sw.WriteLine("red time 2");
                sw.WriteLine("not pedestrian");
                sw.WriteLine("all barred except");
                sw.Write("activephases ");

                if (Line.Contains(",1,"))
                {
                    sw.Write("0 ");
                }
                if (Line.Contains("6"))
                {
                    sw.Write("1 ");
                }
                if (Line.Contains("7"))
                {
                    sw.Write("2 ");
                }
                if (Line.Contains("12"))
                {
                    sw.Write("3 ");
                }
                if (Line.Contains("5"))
                {
                    sw.Write("4 ");
                }
                if (Line.Contains("11"))
                {
                    sw.Write("5 ");
                }
                if (Line.Contains("3"))
                {
                    sw.Write("6 ");
                }
                if (Line.Contains("4"))
                {
                    sw.Write("7 ");
                }
                if (Line.Contains("9"))
                {
                    sw.Write("8 ");
                }
                if (Line.Contains("10"))
                {
                    sw.Write("9 ");
                }
                if (Line.Contains(",2,"))
                {
                    sw.Write("10 ");
                }
                if (Line.Contains("8"))
                {
                    sw.Write("11 ");
                }
                sw.WriteLine("");

                if (Line.Contains("3"))
                {
                    sw.WriteLine(Three);
                }
                else
                {
                    sw.WriteLine(ThreeNot);
                }
                if (Line.Contains(",2,"))
                {
                    sw.WriteLine(Two);
                }
                else
                {
                    sw.WriteLine(TwoNot);
                }
                if (Line.Contains(",1,"))
                {
                    sw.WriteLine(One);
                }
                else
                {
                    sw.WriteLine(OneNot);
                }
                if (Line.Contains("4"))
                {
                    sw.WriteLine(Four);
                }
                else
                {
                    sw.WriteLine(FourNot);
                }
                if (Line.Contains("6"))
                {
                    sw.WriteLine(Six);
                }
                else
                {
                    sw.WriteLine(SixNot);
                }
                if (Line.Contains("5"))
                {
                    sw.WriteLine(Five);
                }
                else
                {
                    sw.WriteLine(FiveNot);
                }
                if (Line.Contains("8"))
                {
                    sw.WriteLine(Eight);
                }
                else
                {
                    sw.WriteLine(EightNot);
                }
                if (Line.Contains("7"))
                {
                    sw.WriteLine(Seven);
                }
                else
                {
                    sw.WriteLine(SevenNot);
                }
                if (Line.Contains("9"))
                {
                    sw.WriteLine(Nine);
                }
                else
                {
                    sw.WriteLine(NineNot);
                }
                if (Line.Contains("12"))
                {
                    sw.WriteLine(Twelve);
                }
                else
                {
                    sw.WriteLine(TwelveNot);
                }
                if (Line.Contains("11"))
                {
                    sw.WriteLine(Eleven);
                }
                else
                {
                    sw.WriteLine(ElevenNot);
                }
                if (Line.Contains("10"))
                {
                    sw.WriteLine(Ten);
                }
                else
                {
                    sw.WriteLine(TenNot);
                }
                
            }

            sw.WriteLine("");
            sw.WriteLine("actions 1");
            sw.WriteLine("from 0 to 5 MAJOR");
            sw.WriteLine("from 5 to 0 MAJOR");
            sw.WriteLine("");
            sw.WriteLine("actions 2");
            sw.WriteLine("from 0 to 6 MAJOR");
            sw.WriteLine("from 6 to 0 MAJOR");
            sw.WriteLine("");
            sw.WriteLine("actions 3");
            sw.WriteLine("from 0 to 7 MAJOR");
            sw.WriteLine("from 7 to 0 MAJOR");
            sw.WriteLine("");
            sw.WriteLine("actions 4");
            sw.WriteLine("from 0 to 8 MAJOR");
            sw.WriteLine("from 8 to 0 MAJOR");

            File.Close();
            sw.Close();
        }

        /*public void MakeFile()
        {
            StreamWriter sw;
            //sw = new StreamWriter(@"C:\Dropbox\LanchesterRouteChoiceExperiment - Andrew's\TestBed\ConsoleApplication1\ConsoleApplication1\bin\Debug\" + NewPrioritiesFile);   //Laptop Version
            //sw = new StreamWriter(@"C:\Dropbox\Dropbox\LanchesterRouteChoiceExperiment - Andrew's\TestBed\ConsoleApplication1\ConsoleApplication1\bin\Debug\" + NewPrioritiesFile);   //Desktop Version
            sw = new StreamWriter(@NewPrioritiesFile);   //Bin folder Version

            sw.WriteLine("clear exit adherence model 0");
            sw.WriteLine();
            sw.WriteLine("actions signals post-2001 0");
            sw.WriteLine("stage offset 0 sec");

            int Counter = 0;
            string Line;

            // Read the file and display it line by line.
            System.IO.StreamReader File = new System.IO.StreamReader(StageFile);
            while ((Line = File.ReadLine()) != null)
            {
                Counter++;
                sw.WriteLine("stage " + Convert.ToString(Counter));
                sw.WriteLine("    20");
                sw.WriteLine("    min -5");
                sw.WriteLine("    max 20");
                sw.WriteLine("red time 2");
                sw.WriteLine("not pedestrian");
                sw.WriteLine("all barred except");
                sw.Write("activephases ");

                if (Line.Contains(",1,"))
                {
                    sw.Write("0 ");
                }

            }

            sw.WriteLine("");
            sw.WriteLine("actions 1");
            sw.WriteLine("from 0 to 5 MAJOR");
            sw.WriteLine("from 5 to 0 MAJOR");
            sw.WriteLine("");
            sw.WriteLine("actions 2");
            sw.WriteLine("from 0 to 6 MAJOR");
            sw.WriteLine("from 6 to 0 MAJOR");
            sw.WriteLine("");
            sw.WriteLine("actions 3");
            sw.WriteLine("from 0 to 7 MAJOR");
            sw.WriteLine("from 7 to 0 MAJOR");
            sw.WriteLine("");
            sw.WriteLine("actions 4");
            sw.WriteLine("from 0 to 8 MAJOR");
            sw.WriteLine("from 8 to 0 MAJOR");

            File.Close();
            sw.Close();
        }
        */
    }
}

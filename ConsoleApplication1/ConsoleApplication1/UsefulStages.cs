using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ConsoleApplication1
{
    class UsefulStages
    {

        public void AllUsefulStages()
        {
            string temp = @"C:\Dropbox\LanchesterRouteChoiceExperiment - Andrew's\TestBed\ConsoleApplication1\ConsoleApplication1\bin\Debug\AllPossibleStages(ComputerNumbers).txt";
            StreamReader sr = new StreamReader(temp);
            string[] AllStages = sr.ReadLine().Split(',');

            foreach (string Stage in AllStages)
            {
                foreach (char item2 in Stage)
                {
                    Console.Write(item2);
                }
                Console.WriteLine();
            }
            
            Console.Read();
        }
    }
}

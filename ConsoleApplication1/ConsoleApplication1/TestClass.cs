using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class TestClass
    {

        List<int> VideoOrder = new List<int> { 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        public static void Shuffle<T>(IList<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public void DisplayResults()
        {
            Shuffle2(VideoOrder);
            foreach (int item in VideoOrder)
            {
                Console.WriteLine(item);
            }
            Console.Read();
        }

        public static List<int> Shuffle2<T>(IList<T> list)
        {
            List<int> temp = new List<int>();
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
            foreach (T item in list)
            {
                temp.Add(Convert.ToInt16(item));
            }
            return temp;
        }

    }
}

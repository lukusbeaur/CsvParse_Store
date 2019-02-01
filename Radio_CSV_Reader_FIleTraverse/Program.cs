using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Radio_CSV_Reader_FIleTraverse
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            FindValues findValues = new FindValues();
            FileTraverse file = new FileTraverse();
            List<string> temp = new List<string>(file.TestENumerator("C:/Test CTDI/results/Nokia Radio FCT/"));
            foreach (string x in temp)
            {
                findValues.ReadCsv(x);
            }
            stopwatch.Stop();
            Console.WriteLine($"The program ran  {stopwatch.ElapsedMilliseconds}  miliSeconds");
            

            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;


namespace Radio_CSV_Reader_FIleTraverse
{
    //<sum> This will look throughthe CSV file for the values of serialnum(name)
    //The date, and PassorFail 
    public class FindValues : IQueryInterface
    {
        public void ReadCsv(string filename)
        {
            //This function Finds All required Data Tidy this up, make it generic, add Regex and cast it to the Iquearable to get ready to upload to Server
            //also This needs to filter way better 
            List<string> list = new List<string>();
            using (StreamReader stream = new StreamReader(filename))
            {
                while (!stream.EndOfStream)
                {
                    string lines = stream.ReadLine();
                    list.Add(lines.ToString());
                    //Console.WriteLine("new line");
                }
            }
            //These are the Values i will be saving the the Que-able list object.
            //listobjects = _name, _date, and _PassOrFail 
            var name = list.Where((p) => p.Contains("COMCODE")).ToArray();
            var faildate = list.Where((p) => p.Contains("Test Termination")).ToArray();
            var passorfail = list.Where((p) => p.Contains("Reason")).ToArray();
            //this is testing my concept of Iquery

          
        }

        public IQueryable<ResultObjets> ResultObjets => new List<ResultObjets>
        {
            //example with out automating process
            new ResultObjets
            {
                Set_Name = "This is a name of fail",
                Set_Date =  11,
                Set_PassOrFail = false
            },
            new ResultObjets
            {
                Set_Name = "This is the name of pass",
                Set_Date = 11, 
                Set_PassOrFail = true
            }
        }.AsQueryable<ResultObjets>();
    }
}
    //<sum> This will Take the values of the Find Values Function and save them to a list.


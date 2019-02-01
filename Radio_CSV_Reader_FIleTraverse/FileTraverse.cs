using System;
using System.Collections.Generic;
using System.IO;

//This is done No more Dev on this Class
namespace Radio_CSV_Reader_FIleTraverse
{
    public class FileTraverse
    {
        //<Summary> TestEnumerator takes the Initial Path Directory and Runs it through the Get File Directory adding entire Ienumerable Object to a list
        //<Names ="FinalListOfDirNames", "file">
        //<FinalListOfDirNames> = This is the finished list of all the CSV files in the Directory
        //<file> = is the string literal for the foreach loop that will be added to the FinalListOfDirNames list 
        public List<string>TestENumerator(string Initial_PathDirectory)
        {
            List<string> FinalListOfDirNames = new List<string>();
            foreach (string file in Get_File_Directory(Initial_PathDirectory))
            {
                FinalListOfDirNames.Add(file);
            }
           //This area was where I displayed all the files and their objects need to send this info to an Iquery to better process the  data
            Console.WriteLine($"You parsed {FinalListOfDirNames.Count} CSV files in .......");
            return FinalListOfDirNames;
        }

        //<Summary> This is a non public non static member where only the TestENumerator Function above will access and send DIR Full names to the Main Class
        //<summary> This is a First in First out type directory traverse. Adding the Directory to a Queue List and then DeQuing or (poping) the top value off
        //<summary Return Type> This yeilds a return array as an Ienumerable list of objects.
        //<exceptions> It catches File not found, Not accessable , and a general Exception to ensure a no crash program. No Finally needed, No Using need. Files
        //<exceptions cont.> will not be opened in this Function or class.
        IEnumerable<String> Get_File_Directory(string DIRpath)
        {
            Queue<string> FileDirectoryQueList = new Queue<string>();
            FileDirectoryQueList.Enqueue(DIRpath);
            

            while (FileDirectoryQueList.Count > 0)
            {
                DIRpath = FileDirectoryQueList.Dequeue();

                try
                {
                    foreach (string Subdir in Directory.GetDirectories(DIRpath))
                    {
                        FileDirectoryQueList.Enqueue(Subdir);
                    }
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("This File was not found");
                }
                catch (AccessViolationException)
                {
                    Console.WriteLine("The FIle you are trying to reach you do not have access to");
                }
                catch (Exception) { Console.WriteLine("An Error has occured"); }

                string[] FileNameArray = null;
                try
                {
                    FileNameArray = Directory.GetFiles(DIRpath);
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("The file you are looking for has not been found");
                }
                catch (AccessViolationException)
                {
                    Console.WriteLine("The File you are trying to reach you do not have access to");
                }
                catch (Exception)
                {
                    Console.WriteLine("An Error has occured");
                }
                if (FileNameArray != null)
                {
                    for (int i = 0; i < FileNameArray.Length; i++) //returning each FileDirectory full name
                    {
                        yield return FileNameArray[i];
                    }
                    
                }

            }
        }
    }
}

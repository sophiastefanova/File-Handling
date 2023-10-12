using System;
using System.IO;

class Test
{
    public static void Main()
    {
        //Create folder
        string path = "/Users/sophiastefanova/Documents/File Handeling";

        string newDir = $"{path}/TheNewF";
        DirectoryInfo di = Directory.CreateDirectory(newDir);

        //Check if folder already exists
        if (Directory.Exists(newDir))
        {
            Console.WriteLine("Directory exists!");
        }
        else
        {
            Console.WriteLine("Directory does NOT exist!");
        }

        //Create file
        var file = $"{newDir}/StudyForTest.txt";

        //Write on file (one string)
        string input = "Hello";
        File.WriteAllText(file,input);
        File.WriteAllText(file, string.Empty); //Clear contents of file

        //Write on file (more strings)
        string[] inputs = { "Good Morning!", "Good Night!" };
        File.WriteAllLines(file, inputs);

        //Add stuff to file
        string[] additionalInputs = { "Hello Guys!", "Mamacita!" };
        File.AppendAllLines(file, additionalInputs);

        //Write on file via Streamwriter
        string path2 = $"{newDir}/StudyForTestHarder.txt";

        if (!File.Exists(path2))
        {
            //Create file via StreamWriter
            using(StreamWriter sw = File.CreateText(path2))
            {
                sw.WriteLine("I'm the better version!");
                sw.WriteLine("GG!");
            }
        }
        else
        {
            Console.WriteLine("This file already exists!");
        }

        //Add text via StreamWriter 
        using(StreamWriter sw = File.AppendText(path2))
        {
            sw.WriteLine("This is new text added.");
        }

        //Open file to read from and check if there isn't a blank space (if so, program would crush)
        using(StreamReader sr = File.OpenText(path2))
        {
            string s = "";
            while((s = sr.ReadLine()) != null)
            {
                Console.WriteLine(s);
            }
        }


        //File.Move() process
        string path3 = $"{newDir}/Move.txt";
        if (!File.Exists(path2)) //Enusre file exists or create it if it doesn't
        {
            using (FileStream fs = File.Create(path2)) { }
        }
        if (File.Exists(path3)) //Ensure target doesn't exist
        {
            File.Delete(path3);
        }
        File.Move(path2, path3); //finally MOVE FILE 
        Console.WriteLine($"{path2} was moved to {path3}");

        //See if original exists now
        if (File.Exists(path2))
        {
            Console.WriteLine("It is unexpected that original file still exists.");
        }
        else
        {
            Console.WriteLine("It is expected that the original file is now moved and no longer exists.");
        }

        //File.Copy() short
        string pathCopy = $"{newDir}/Copy.txt";
        File.Copy(path3, pathCopy);
    }
}
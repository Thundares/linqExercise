using System;
using System.IO;

namespace linqExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Create the file for the exercise? <y/n>");
            try
            {
                char r = char.Parse(Console.ReadLine());
                if(r == 'y')
                {
                    try
                    {
                        using(FileStream fs = new FileStream(Path.GetTempPath() + "file.txt", FileMode.CreateNew))
                        {
                            using(StreamWriter sw = new StreamWriter(fs))
                            {
                                sw.WriteLine("Maria,maria@gmail.com,3200.00");
                                sw.WriteLine("Alex,alex@gmail.com,1900.00");
                                sw.WriteLine("Marco,marco@gmail.com,1700.00");
                                sw.WriteLine("Bob,bob@gmail.com,3500.00");
                                sw.WriteLine("Anna,anna@gmail.com,2800.00");
                            }
                        }
                        Console.WriteLine("Create File was successful");
                    }
                    catch (IOException)
                    {
                        throw new IOException("The File could not be created");
                    }
                }
            }
            catch (System.Exception)
            {
                throw new SystemException("Error");
            }

            Console.WriteLine();
            Console.WriteLine("==================");
            Console.Write("Enter full file path: ");
            string path = Console.ReadLine();
            try
            {
                using(StreamReader sr = new StreamReader(path))
                {
                    Console.WriteLine("Loading was successful");
                }
            }
            catch (IOException)
            {
                throw new IOException("Could not load the file");
            }
        }
    }
}

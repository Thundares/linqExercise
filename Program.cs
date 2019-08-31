using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using linqExercise.Entities;

namespace linqExercise
{
    class Program
    {
        static void CreateFile()
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
        static void Print<T>(IEnumerable<T> a)
        {
            foreach (T obj in a)
            {
                Console.WriteLine(obj);
            }
        }
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
                        CreateFile();
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
            List<Employee> employees = new List<Employee>();
            try
            {
                using(StreamReader sr = new StreamReader(path))
                {
                    Console.WriteLine("Loading was successful");
                    while(!sr.EndOfStream)
                    {
                        string[] st = sr.ReadLine().Split(",");
                        employees.Add(new Employee(st[0], st[1], double.Parse(st[2])));
                    }
                }
            }
            catch (IOException)
            {
                throw new IOException("Could not load the file");
            }
            Console.Write("Enter Salary: ");
            double salary = double.Parse(Console.ReadLine());

            var r1 = 
                from E in employees
                where E.Salary > salary
                select E.Email;

            Console.WriteLine("Email of people whose salary is more than {0}:", salary);
            Print(r1);

            var r2 =
                from E in employees
                where E.Name[0] == 'M'
                select E.Salary;

            Console.Write("Sum of salalry of people whose name start with 'M': " + r2.Sum());
        }
    }
}

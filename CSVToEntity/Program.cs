﻿using System;
using System.Collections.Generic;
using System.IO;

namespace CSVToEntity
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter CSV file path:");
            string filePath=Console.ReadLine();

            try
            {
                string[] allLines = File.ReadAllLines(filePath);

                //read first line to get column name from the csv file
                string headerLine = allLines[0];

                List<Student> studentCollection = new List<Student>();

                using (var dbContext = new StudentContext())
                {
                    //process line based on comma seperated values
                    foreach (string temp in allLines)
                    {
                        string[] csvFields = temp.Split(',');


                        dbContext.studentEntity.Add(CSVToObjectLoad.loadEntity<Student>(csvFields));

                    }

                    dbContext.SaveChanges();

                }

             

                Console.WriteLine("Import finished");
                Console.ReadLine();

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
            
        }
    }
}

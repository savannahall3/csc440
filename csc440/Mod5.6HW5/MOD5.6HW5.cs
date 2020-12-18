using System;
using System.IO;

namespace Mod5._6HW5
{
    class Program
    {
        /*Create a program that has 2 options for a user to select.
        The first option accepts information from the user and then save that data to a file on disk.

        
        The second option loads all data stored on that file.
        */
        static void Main(string[] args)
        {
            //giving the user the option of what they would like to do

            Console.WriteLine("Please make a selection by entering the number:");
            Console.WriteLine("Option 1: Write data to save on to a file" );
            Console.WriteLine("Option 2: Load all data stored from file previously saved.");
            int response = Convert.ToInt32(Console.ReadLine());

            //taking their response and aligning it with that choice
            if (response == 1)
            {
                Option1();
            }
            else
            {
                Option2();
            }    
        }

        static void Option1()
        {
            //opening a stream for the users input to be saved
            StreamWriter savedData = new StreamWriter("SavedData.txt");
            Console.WriteLine("Enter the data you would like to save:");
            string data = Console.ReadLine();
            savedData.Write(data);
            savedData.Close(); //closing that file
        
        }

        static void Option2()
        {
            //creating the second option of allowing the user to
            //have the previously saved data presented on the console
            string line = "";
            using (StreamReader sr = new StreamReader("SavedData.txt"))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }

            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;

namespace coviddataproject1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Program p = new Program();
            //p.loadMainMenu();


            Console.WriteLine("Local COVID - Main Menu \n");

            Console.WriteLine("c) List all cities \n" +
                "i) Import data \n" +
                "x) Exit \n");

            while (true)
            {
                Console.Write("Please enter your choice: ");

                string word = Console.ReadLine();
                if (word.ToLower() == "x")
                {
                    break;
                }
                else if (word.ToLower() == "c")
                {
                    Console.WriteLine("Listing all cities...");
                }
                else if (word.ToLower() == "i")
                {
                    Console.Write("Please enter the path to import the file: ");
                    Translator translator = new Translator(Console.ReadLine());



                    //Program p = new Program();
                }
            }
        }
    }
}



//public void SumGame()
//{
//    var rand = new Random();
//    int num1 = rand.Next(0, 10);
//    int num2 = rand.Next(0, 10);

//    Console.Write($"{num1} of {num2} = ");

//    var sum = int.Parse(Console.ReadLine());

//    var realsum = num1 + num2;

//    if (realsum == sum)
//    {
//        Console.WriteLine("Your answer is correct.");
//    }
//    else
//    {
//        Console.WriteLine("Your answer is incorrect.");
//    }

//    Console.WriteLine("Do you want to try again? ");
//    if (Console.ReadLine().Contains("y"))
//    {
//        Program p = new Program();
//        p.SumGame();
//    }
//    else
//    {

//    }
//}

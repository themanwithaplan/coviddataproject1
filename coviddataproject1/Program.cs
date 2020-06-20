using System;

namespace coviddataproject1
{
    class Program
    {
        public void SumGame()
        {
            var rand = new Random();
            int num1 = rand.Next(0, 10);
            int num2 = rand.Next(0, 10);

            Console.Write($"{num1} of {num2} = ");

            var sum = int.Parse(Console.ReadLine());

            var realsum = num1 + num2;

            if (realsum == sum)
            {
                Console.WriteLine("Your answer is correct.");
            }
            else
            {
                Console.WriteLine("Your answer is incorrect.");
            }

            Console.WriteLine("Do you want to try again? ");
            if (Console.ReadLine().Contains("y"))
            {
                Program p = new Program();
                p.SumGame();
            }
            else
            {

            }
        }

        static void Main(string[] args)
        {
            Program p = new Program();
            p.SumGame();
        }
    }
}

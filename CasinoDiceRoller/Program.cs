using System;

namespace CasinoDiceRoller
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Welcome to the Gilbrry Casino Resort!");
            bool runProgram = true;
            int roll = 0;
            int sides = IsGreaterThan0();
            while (runProgram)
            {
                int num1 = RandoDice(sides);
                int num2 = RandoDice(sides);
                int tot = num1 + num2;
                roll += 1;
                Console.WriteLine($"Roll {roll}");
                Console.WriteLine($"Your dice rolls are {num1} and {num2}. ({tot})");
                if (sides == 6)
                {
                    DisplayMesage(num1, num2, tot);
                }

                runProgram = RunAgain();
            }
            Console.WriteLine("Please have a wonderful day");
        }

        public static int IsGreaterThan0()
        {
            int sides = 0;
            while (true)
            {
                try
                {
                    Console.WriteLine("Please enter how many dice sides you would prefer. (We recommend 6 sided)");
                    string input = Console.ReadLine();

                    sides = 0;
                    bool isInt = int.TryParse(input, out sides);
                    if (isInt == true && sides > 0)
                    {
                        break;
                    }
                    else if(isInt == false)
                    {
                        throw new Exception("Unfortunetly that is not a number.");
                    }
                    else
                    {
                        throw new Exception("Unfortunetly that dice side does not exist.");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return sides;
        }

        public static int RandoDice(int side)
        {
            Random rando = new Random();
            int result = rando.Next(1, side);
            return result;
        }

        public static void DisplayMesage(int num1, int num2, int tot)
        {
            if (num1 == 1 && num2 == 1)
            {
                Console.WriteLine("Snake Eyes!");
            }
            else if((num1 == 1 && num2 == 2) || (num2 == 1 && num1 == 2))
            {
                Console.WriteLine("Ace Deuce");
            }
            else if(num1 == 6 && num2 == 6)
            {
                Console.WriteLine("Box Cars");
            }
            else if(tot == 7 || tot == 11)
            {
                Console.WriteLine("You Win");
            }
            
            if(tot == 2|| tot == 3 || tot == 12)
            {
                Console.WriteLine("Craps");
            }
        
        }

        static bool RunAgain()
        {
            bool runProgram = true;
            while(true)
            {
                
                Console.WriteLine("Would you ike to roll again? y/n");
                string input = Console.ReadLine();
                if(input == "y")
                {
                    Console.Clear();
                    break;
                }
                else if(input == "n")
                {
                    runProgram = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Our apologies, we do not understand, please try again.");
                }

            }

            return runProgram;
        }

        
    }
}

using System;

namespace Exercise3
{
    class Program
    {
        static void Main(string[] args)
        {
            /*

            3. make a program that prints the Collatz sequence (up until 1) for a given number,
                taking the number from Console.ReadLine.
                for any number n, the next number in its Collatz sequence is:
                - if n is even, it is n divided by two.
                - if n is odd, it is n times three, plus one.
                for example, for 10, you should print:
            10
            5
            16
            8
            4
            2
            1
            the Collatz conjecture says, this process eventually reaches 1 for every number.
            */
            Console.Write("What value would you like to start the Collatz sequence with: ");
            string userInput = Console.ReadLine();

            int sequenceStartVal = int.Parse(userInput);
            int collatzVal = sequenceStartVal;

            while(collatzVal > 1)//once the collatzVal is 16, it will always end the program after 4 more calculations
            {
                Console.WriteLine(collatzVal);
                if(collatzVal % 2 == 0)//even value
                {
                    collatzVal = collatzVal/2;
                }
                else//odd value
                {
                    collatzVal = (collatzVal * 3) + 1;
                }
            }
        }
    }
}

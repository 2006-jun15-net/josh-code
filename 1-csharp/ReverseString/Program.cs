using System;

namespace ReverseString
{
    class Program
    {
        static void Main()
        {
            //Write a program to reverse a string input by the user
            Console.Write("Please enter a string to reverse: ");
            string userInput = Console.ReadLine();

            int stringLength = userInput.Length;

            for(int i = stringLength - 1; i >= 0; i--)
            {
                Console.Write(userInput[i]);
            }
            
        }
    }   
}
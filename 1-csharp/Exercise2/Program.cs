using System;

namespace Exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Write a program that creates a staircase of a size that is input by the user. 
            A staircase looks like this:
                #
               ##
              ###
            */
            Console.Write("Please enter a size to build the staircase: ");
            string userInput = Console.ReadLine();
            int requestedSize = int.Parse(userInput); // inputsize
            
            int staircaseSize = requestedSize;
            int staircaseLevel = 0;
            int spaces = (staircaseSize - 1); // inputsize -1

            for(;staircaseLevel < requestedSize ; staircaseLevel++)
            {
                for(int i = spaces; i >= 0; i--)
                {
                    Console.Write(" ");
                }
                
                for(int j = staircaseSize; j <= requestedSize; j++)
                {   
                    Console.Write("#");
                }
                spaces--;
                staircaseSize--;
                Console.WriteLine();
            }
        }
    }
}

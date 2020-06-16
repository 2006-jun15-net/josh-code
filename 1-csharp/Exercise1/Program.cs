using System;

namespace Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Write a program that creates a staircase of size 8
            A staircase looks like this:
                #
               ##
              ###
            */

            int staircaseSize = 8;
            int staircaseLevel = 0;
            int spaces = 7;


            for(;staircaseLevel < 8 ; staircaseLevel++)
            {
                for(int i = spaces; i >= 0; i--)
                {
                    Console.Write(" ");
                }
                
                for(int j = staircaseSize; j <= 8; j++)
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

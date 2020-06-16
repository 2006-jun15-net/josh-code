using System;

namespace ProceduralBasics
{
    class Program
    {
        static void Main(string[] args)
        {

            //variable types cannot be changed after declared. It is "type safe"
            
            /*
            numeric data types
                int(4 bytes, between -2 billion to 2 billion) fairly uncommon to use any data type other than int
                short (2 bytes), long (8 bytes), byte (1 byte) long and byte are occasionally used.

            numbers with fractions (floating point number) rounding errors can sometimes be introduced
                double (8 bytes, very wide range)
                float (4 bytes, less precise)

            true/false
                bool

            text
                string (more than one character, use double quotes)
                char (just one character, use single quotes)

            collections
                arrays
                    int[], double[], string[], anything else
                several other types that we use more often than arrays
            */
            
            /*
            int x = 5;

            x = 4;

            int[] numbers = {4, 5, 9, 2};

            bool mathWorks = (3 + 3 == 6); // true if math works in the universe
            */

            Console.WriteLine("Enter a number:");
            string userInput = Console.ReadLine();

            int number = int.Parse(userInput);

            number *= 2; //shorthand for writing "number = number * 2;"

            Console.WriteLine("Doubled: " + number);

            /*
            control structures

            */

            //In CSharp, the conventional way to place the curly braces is as shown below
            if(number < 0) 
            {
                Console.WriteLine("negative number");
            }
            else
            {
                //lups
                
                for(; number >= 0; number -=5)//(init; test; update)
                {
                    Console.WriteLine(number);
                }
            }

        }
    }
}

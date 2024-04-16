using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;


//cerinte:
/* exemplu input file: 
 * 
            [D]    
        [N] [C]    
        [Z] [M] [P]
         1   2   3   <------------ stack

        move 1 from 2 to 1
        move 3 from 1 to 3
        move 2 from 2 to 1
        move 1 from 1 to 2

        [Z]
        [N]
        [D]
[C] [M] [P]
 1   2   3

mesaj final CMZ (se ia doar cutiile de deasupra)


*/

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            // avem nevoie de un numar de coloane care poate varia, cutii care sa aiba o coloana corespondenta
            // instructiuni de urmat pentru rearanjari

            string filePath = @"D:\Sample.txt"; // Replace with your file path
            string[] readText = File.ReadAllLines(filePath);
            string line;
            
            Stack<char>[] coloane;

            StreamReader sr = new StreamReader(filePath);
            
            //Read the first line of text
            line = sr.ReadLine();

            //Continue to read until you reach end of file
            while (line != null)
            {
                //Read the next line
                line = sr.ReadLine();
            }

            int i;

            // separam cutiile si coloanele de partea cu aranjamente 
            for (i = 0; i < readText.Length; i++) 
            { 
                if (string.IsNullOrWhiteSpace(readText[i]))
                {
                    
                    Regex regex = new Regex(@"(\d+)(?!.*\d)");
                    Match match = regex.Match(readText[i - 1]);
                    Console.WriteLine(match.Value);
                    coloane = new Stack<char>[3];
                    break;
                }
            }

            // parcurgem instructiunile
            for (int j = 0; j < readText.Length; j++)
            {
                Console.WriteLine(readText[i]);
            }

            sr.Close();
            Console.ReadLine();

        }
    
    }
}

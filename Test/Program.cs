﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
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
            Stack<char>[] coloane;
            string filePath = @"D:\Sample.txt"; // Replace with your file path
            string[] fisierText = File.ReadAllLines(filePath);
            string line;
            Regex regex = new(@"(\d+)(?!.*\d)");
            Match match = regex.Match(""); 

            // declaram i local functiei main deoarece il vom folosi pentru a continua parcurgerea in fisierText pentru rearanjamente
            int i;
            for (i = 0; i < fisierText.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(fisierText[i]))
                {
                    // folosim regex cu pattern-ul (\d+)(?!.*\d) pentru a gasi ultima cifra dintr-un sir de caractere,
                    // mai exact cel precedent de randul gol din fisier dat de readText[i - 1]
                    // astfel indiferent de cum sunt puse spatiile putem initializa un vector de coloane cu oricate coloane am avea nevoie
                    match = regex.Match(fisierText[i - 1]);
                    break; // in final iesim din for loop
                }
            }

            coloane = new Stack<char>[int.Parse(match.Value)];

            int indexColoane = 0;

            for(int k = 0; k < coloane.Length; k++)
            {
                coloane[k] = new Stack<char>();
            }

            int copieI = i;
            copieI -= 2;
            AdaugaCutii(copieI, indexColoane, coloane, fisierText);



            StreamReader cititorFisier = new(filePath);
            
            // Read the first line of text
            line = cititorFisier.ReadLine();

            // Continue to read until you reach end of file
            while (line != null)
            {
                // Read the next line
                line = cititorFisier.ReadLine();
            }

            cititorFisier.Close();
            Console.ReadLine();
        }

        public static int AdaugaCutii(int i, int indexColoane, Stack<char>[] stacks, string[] fisierText)
        {
            for (int j = 1; j < fisierText[i].Length; j += 4)
            {
                if (char.IsLetter(fisierText[i][j]))
                {
                    stacks[indexColoane].Push(fisierText[i][j]);
                }

                if((j - 1) % 4  == 0)
                {
                    indexColoane++;
                }
            }

            // functia a terminat de adaugat cutii
            if(i - 1 < 0)
            {
                return 1;
            }

            indexColoane = 0;

            return AdaugaCutii(i - 1, indexColoane, stacks, fisierText);
        }
    }
}

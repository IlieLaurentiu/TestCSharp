using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace Test
{
    class CititorFisier
    {
        public static void CitesteInput(string path)
        {
            string line;

            try
            {

                StreamReader streamReader = new(path);

                line = streamReader.ReadLine();

                while (line != null)
                {
                    Console.WriteLine(line);

                    Console.WriteLine(line[5]);
                    Console.WriteLine(line[12]);
                    Console.WriteLine(line[17]);

                    line = streamReader.ReadLine();
                }

                streamReader.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Am creat si initializat un vector de stack-uri (coloane) pentru a contine cutiile
            Stack<string>[] Coloana = [new Stack<string>(), new Stack<string>(), new Stack<string>()];

            // Introducem valorile din problema in ordine inversa, in fiecare stack
            Coloana[0].Push("Z");
            Coloana[0].Push("N");

            Coloana[1].Push("M");
            Coloana[1].Push("C");
            Coloana[1].Push("D");

            Coloana[2].Push("P");

            // Citim instructiunile date de catre fisier
            CititorFisier.CitesteInput("D:\\Sample.txt");

            TrimiteMesajElfilor("");

            MutaCutii(3, Coloana[1], Coloana[2]);
        }

        public static void MutaCutii(int numarCutii, Stack<string> dinStack, Stack<string> peStack)
        {
            for (int i = 0; i < numarCutii; i++)
            {
                peStack.Push(dinStack.Pop());
            }
        }

        public static void TrimiteMesajElfilor(string mesaj)
        {
            Console.WriteLine(mesaj);
        }
    }
}

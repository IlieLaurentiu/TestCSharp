namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            // Am creat si initializat un vector de stack-uri (coloane) pentru a contine cutiile
            Stack<string>[] Coloana = [new Stack<string>(), new Stack<string>(), new Stack<string>()];
            string linieFisier;

            // Introducem valorile din problema in ordine inversa, in fiecare stack
            Coloana[0].Push("Z");
            Coloana[0].Push("N");

            Coloana[1].Push("M");
            Coloana[1].Push("C");
            Coloana[1].Push("D");

            Coloana[2].Push("P");

            StreamReader streamReader = new("D:\\Sample.txt");
            linieFisier = streamReader.ReadLine();

            while (linieFisier != null)
            {
<<<<<<< HEAD
                // apelam functia muta cutii 
                // desi este o cale foarte rigida, voi lua direct fiecare caracter de pe pozitia 5, 12 si 17, adica numarul de cutii si primele doua coloane din instructiune
                // de pe fiecare linie, pentru a evita sa parcurg sau sa fac alte operatii cu siruri de caractere
                MutaCutii(int.Parse(linieFisier[5].ToString()), Coloana[int.Parse(linieFisier[12].ToString()) - 1], Coloana[int.Parse(linieFisier[17].ToString()) - 1]);

                // linieFisier devine linia urmatoare din fisierul citit
                linieFisier = cititorFisier.ReadLine();
=======
                Console.WriteLine(linieFisier);
                //MutaCutii(linieFisier[5], Coloana[linieFisier[12] - 1], Coloana[linieFisier[17] - 1]);

                linieFisier = streamReader.ReadLine();
>>>>>>> parent of b76fcbb (adaugat comentarii)
            }

            streamReader.Close();

            TrimiteMesajElfilor($"{Coloana[0].Pop()}{Coloana[1].Pop()}{Coloana[2].Pop()}");
        }

        public static void MutaCutii(int numarCutii, Stack<string> dinStack, Stack<string> peStack)
        {
            for (int i = 0; i < numarCutii; i++)
            {
<<<<<<< HEAD
                // scoatem 'cutia' din stackul iaDinColoana si o punem in mutaInColoana
                mutaInColoana.Push(iaDinColoana.Pop());
=======
                peStack.Push(dinStack.Pop());
>>>>>>> parent of b76fcbb (adaugat comentarii)
            }
        }

        public static void TrimiteMesajElfilor(string mesaj)
        {
            Console.WriteLine(mesaj);
        }
    }
}

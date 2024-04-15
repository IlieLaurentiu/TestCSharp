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
                Console.WriteLine(linieFisier);
                //MutaCutii(linieFisier[5], Coloana[linieFisier[12] - 1], Coloana[linieFisier[17] - 1]);

                linieFisier = streamReader.ReadLine();
            }

            streamReader.Close();

            TrimiteMesajElfilor($"{Coloana[0].Pop()}{Coloana[1].Pop()}{Coloana[2].Pop()}");
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

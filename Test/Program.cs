namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {

            // Am creat si initializat un vector de stack-uri (coloane) de tip generic string, pentru a contine cutiile
            Stack<string>[] Coloana = [new Stack<string>(), new Stack<string>(), new Stack<string>()];
            // definim un sir de caractere pe care il folosim la citirea rand cu rand din fisier
            string linieFisier;

            // Introducem valorile din problema in ordine inversa, in fiecare coloana
            Coloana[0].Push("Z");
            Coloana[0].Push("N");

            Coloana[1].Push("M");
            Coloana[1].Push("C");
            Coloana[1].Push("D");

            Coloana[2].Push("P");

            // initializam un cititor de fisier
            StreamReader cititorFisier = new("D:\\Sample.txt");
            // introducem in linieFisier sirul de caractere de pe prima linie
            linieFisier = cititorFisier.ReadLine();

            // cat timp fisierul nu s-a terminat (linia citita este diferita de null) continuam sa citim
            while (linieFisier != null)
            {
                // apelam functia muta cutii 
                // desi este o cale foarte rigida, voi lua direct fiecare caracter de pe pozitia 5, 12 si 17, adica numarul de cutii si primele doua coloane din instructiune
                // de pe fiecare linie, pentru a evita sa parcurg sau sa fac alte operatii cu siruri de caractere
                MutaCutii(int.Parse(linieFisier[5].ToString()), Coloana[int.Parse(linieFisier[12].ToString()) - 1], Coloana[int.Parse(linieFisier[17].ToString()) - 1]);

                // linieFisier devine linia urmatoare din fisierul citit
                linieFisier = cititorFisier.ReadLine();
            }

            // Inchidem fisierul
            cititorFisier.Close();

            // La final afisam mesajul catre elfi folosind functia Peek() la fiecare coloana, pentru a returna doar valoarea cutiei de deasupra, fara modificarea coloanei
            Console.WriteLine($"{Coloana[0].Peek()}{Coloana[1].Peek()}{Coloana[2].Peek()}");
        }

        // cream o functie statica pentru a putea sa o accesam usor
        // care ia ca argumente numarul de cutii si 2 coloane, din prima va lua cutii si le va pune in a doua
        public static void MutaCutii(int numarCutii, Stack<string> iaDinColoana, Stack<string> mutaInColoana)
        {
            // parcurgem aceasta operatie pentru fiecare cutie, data de numarCutii
            for (int i = 0; i < numarCutii; i++)
            {
                // scoatem 'cutia' din stackul iaDinColoana si o punem in mutaInColoana
                mutaInColoana.Push(iaDinColoana.Pop());
            }
        }
    }

    // Complexitatea spatiu-timp a programului este lineara, O(n)
    // deoarece aceasta creste direct proportional cu input-ul, sau in cazul nostru numarul de cutii
}

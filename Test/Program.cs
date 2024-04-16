using System.Text.RegularExpressions;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            // declaram si initializam un obiect Regex cu pattern-ul (\d+)(?!.*\d) pentru a gasi ultima cifra dintr-un sir de caractere
            Regex regex = new(@"(\d+)(?!.*\d)");
            Match match = regex.Match(""); 

            // declaram un vector de tip stack care sa contina un caracter, pentru coloanele cutiilor
            Stack<char>[] coloane;
            string filePath = @"D:\Sample.txt"; // calea in calculator pentru fisier-ul cu input
            string[] fisierText = File.ReadAllLines(filePath); // introducem toate rand-urile din fisier intr-un vector de tip string
            int i, indexColoane = 0; // le vom folosi mai tarziu pentru parcurgeri

            for (i = 0; i < fisierText.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(fisierText[i])) // cand gasim o linie doar cu spatii albe in input trecem cu o linie inapoi,
                {
                    // la randul precedent din fisier dat de readText[i - 1]
                    // si folosim pattern-ul creat cu regex pentru a lua ultima cifra de pe rand, astfel o vom folosi cand initializam vectorul coloane
                    match = regex.Match(fisierText[i - 1]);
                    break; // in final iesim din for loop
                }
            }

            // initializam vectorul coloane cu cifra luata mai devreme din regex
            coloane = new Stack<char>[int.Parse(match.Value)];

            // parcurgem fiecare coloana pentru a le aloca memorie
            for(int k = 0; k < coloane.Length; k++)
            {
                coloane[k] = new Stack<char>();
            }

            // cream o copie la i si trecem cu 2 randuri mai sus in fisier, astfel suntem pe linia de baza la cutii
            int copieI = i;
            copieI -= 2;
            AdaugaCutii(copieI, indexColoane, coloane, fisierText); // adaugam cutiile in coloanele corespunzatoare

            i++; // trecem pe linia cu instructiunile de rearanjamente

            // parcurgem fiecare instructiune de rearanjare
            for (; i < fisierText.Length; i++) 
            {
                // o solutie destul de rigida, dar din moment de instructiunile nu se schimba
                // folosim exact caracterele 5, 12 si 17 de pe linie pentru a lua numarul de cutii, coloana din care muta si coloana pe care mutam
                // scadem 1 la coloane pentru a corecta la indexarea care incepe de la 0
                // rearanjam cutiile
                // tratam cazul in care se introduce o coloana cu numar mai mare decat totalul de coloane
                if(int.Parse(fisierText[i][12].ToString()) - 1 > coloane.Length || int.Parse(fisierText[i][17].ToString()) - 1 > coloane.Length)
                {
                    Console.WriteLine("Nu exista atat de multe coloane");
                }

                RearanjeazaCutii(int.Parse(fisierText[i][5].ToString()), coloane[int.Parse(fisierText[i][12].ToString()) - 1], coloane[int.Parse(fisierText[i][17].ToString()) - 1]);             
            }

            // pentru fiecare coloana, afisam cutia de deasupra
            foreach(Stack<char> coloana in coloane)
            {
               Console.Write(coloana.Peek());
            }
        }

       
        public static int AdaugaCutii(int i, int indexColoane, Stack<char>[] stacks, string[] fisierText)
        {
            // parcurgem linia din fisier pana la finalul liniei din 4 in 4 caractere pentru a selecta doar litera din cutie
            for (int j = 1; j < fisierText[i].Length; j += 4)
            {
                // daca caracterul selectat e o litera 
                if (char.IsLetter(fisierText[i][j]))
                {
                    stacks[indexColoane].Push(fisierText[i][j]); // atunci punem pe coloana cu numarul dat de indexColoane litera sau 'cutia'
                }

                // la fiecare parcurgere ne mutam pe coloana urmatoare
                if((j - 1) % 4  == 0)
                {
                    indexColoane++;
                }
            }

            // daca functia a terminat de adaugat cutii, iesim din functie
            if(i - 1 < 0)
            {
                return 1;
            }

            // trecem inapoi la prima coloana
            indexColoane = 0;

            // apelam recursiv functia
            return AdaugaCutii(i - 1, indexColoane, stacks, fisierText);
        }

        
        public static void RearanjeazaCutii(int numarCutii, Stack<char> dinColoana, Stack<char> inColoana)
        {
            // daca nu mai sunt cutii de aranjat, oprim functia
            if (numarCutii <= 0)
            {
                return; 
            }

            // daca input-ul incearca sa scoata mai multe cutii decat sunt in coloana, afisam un mesaj pentru acest caz
            if (dinColoana.Count < numarCutii)
            {
                Console.WriteLine($"Ai incercat sa scoti {numarCutii} dintr-o coloana cu {dinColoana.Count} cutii");
                return; 
            }
            
            // scoatem cutia dinColoana x si o punem inColoana y. (x si y fiind date ca argumente ale functiei)
            inColoana.Push(dinColoana.Pop());

            // apelam recursiv functia
            RearanjeazaCutii(numarCutii - 1, dinColoana, inColoana);
        }
    }

    // complexitatea spatiu-timp a programului este lineara - O(n)
    // deoarece creste direct proportional cu marimea fisierului de input
}

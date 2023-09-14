using System.Text;

namespace csharp_lista_indirizzi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            Oggi esercitazione sui file, ossia vi chiedo di prendere dimestichezza con quanto appena visto sui file in classe, in particolare nel live - coding di oggi.
            In questo esercizio dovrete leggere un file CSV, che cambia poco da quanto appena visto nel live-coding in classe, e salvare tutti gli indirizzi contenuti al sul interno all’interno di una lista di oggetti istanziati a partire dalla classe Indirizzo.
            Attenzione: gli ultimi 3 indirizzi presentano dei possibili “casi particolari” che possono accadere a questo genere di file: vi chiedo di pensarci e di gestire come meglio crediate queste casistiche.
            */

            // istanzio una lista di indirizzi a partire dalla classe Adress
            List<Adress> rightAdress = new List<Adress>();

            try
            {
                // salvo il file di testo in una variabile del tipo StreamReader(classe)
                StreamReader adressesFile = File.OpenText("C:\\Users\\giova\\source\\repos\\csharp-lista-indirizzi\\csharp-lista-indirizzi\\my-addresses.csv");

                // istanzio un contatore a 1 per saltare la prima riga
                int lineCounter = 1;

                // ciclo per leggere le varie righe di adressesFile
                while (!adressesFile.EndOfStream)
                {
                    // salvo in una variabile stringa la riga letta
                    string line = adressesFile.ReadLine();

                    // controllo di non essere nella prima linea per evitare di stampare la legenda
                    if (lineCounter > 1)
                    {
                        //Console.WriteLine(line);

                        // divido una stringa in un array di stringhe basandomi sul carattere della virgola
                        string[] stringSplits = line.Split(',');

                        if (stringSplits.Length != 6)
                        {
                            // sollevo un eccezione come prova perchè una volta sollevata il programma ferma la sua esecuzione
                            //throw new Exception($"L'indirizzo '{line}' non è leggibile");

                            // utilizzo un writeline per evitare che si blocchi il programma
                            Console.WriteLine($"L'indirizzo '{line}' non è leggibile");

                        }
                        else
                        {

                            //if (stringSplits[0].Length == 0 || stringSplits[1].Length == 0 || stringSplits[2].Length == 0 || stringSplits[3].Length == 0 || stringSplits[4].Length == 0 || stringSplits[5].Length == 0)
                            if (stringSplits.Any(s => s.Length == 0))
                            {
                                Console.WriteLine($"L'indirizzo '{line}' non è conforme");
                            }
                            else
                            {
                                string name = stringSplits[0];
                                string surname = stringSplits[1];
                                string street = stringSplits[2];
                                string city = stringSplits[3];
                                string province = stringSplits[4];
                                int zip = int.Parse(stringSplits[5]);

                                // controllo
                                //Console.WriteLine($"L'indirizzo è: {name}, {surname}, {street}, {city}, {province}, {zip}.");

                                Adress newAdress = new Adress(name, surname, street, city, province, zip);

                                // richiamo il metodo della classe Adress per stampare a video l'indirizzo
                                newAdress.PrintAdress();

                                // aggiungo l'indirizzo alla lista degli indirizzi giusti
                                rightAdress.Add(newAdress);
                            }
                        }
                    }

                    lineCounter++;
                }

                // chiudo il file in lettura
                adressesFile.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // come prova stampo gli elementi della lista 
            for (int i = 0; i < rightAdress.Count; i++)
            {
                Console.WriteLine($"L'elemento {i + 1} della lista è: {rightAdress[i].Name}, {rightAdress[i].Surname}, {rightAdress[i].Street}, {rightAdress[i].City}, {rightAdress[i].Province}, {rightAdress[i].Zip}");
            }


            // CREO UN ALTRO FILE IN CUI INSERISCO LA LISTA

            try
            {

                StreamWriter rightFile = File.CreateText("C:\\Users\\giova\\source\\repos\\csharp-lista-indirizzi\\csharp-lista-indirizzi\\right-addresses.csv");

                for (int i = 0; i < rightAdress.Count; i++)
                {
                    rightFile.WriteLine($"{rightAdress[i].Name}, {rightAdress[i].Surname}, {rightAdress[i].Street}, {rightAdress[i].City}, {rightAdress[i].Province}, {rightAdress[i].Zip}");

                }

                rightFile.Close();

            } catch
            {
                Console.WriteLine("Eccezione");
            }
        }
    }
}
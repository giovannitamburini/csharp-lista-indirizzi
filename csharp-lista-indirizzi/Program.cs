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

                try
                {
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
                            try
                            {
                                Adress newAdress = Adress.ParseFromLine(line);
                                rightAdress.Add(newAdress);

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }

                        lineCounter++;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    adressesFile.Close();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
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

            }
            catch
            {
                Console.WriteLine("Eccezione");
            }
        }
    }
}
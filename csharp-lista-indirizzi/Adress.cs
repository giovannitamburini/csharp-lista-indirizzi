using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_lista_indirizzi
{
    public class Adress
    {
        //Name, Surname, Street,City,Province,ZIP
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Street { get; private set; }
        public string City { get; private set; }
        public string Province { get; private set; }
        public int Zip { get; private set; }

        public Adress(string name, string surname, string street, string city, string province, int zip)
        {
            this.Name = name;
            this.Surname = surname;
            this.Street = street;
            this.City = city;
            this.Province = province;
            this.Zip = zip;
        }

        public void PrintAdress()
        {
            Console.WriteLine($"INDIRIZZO: {Name}, {Surname}, {Street}, {City}, {Province}, {Zip}");
        }

        // metodo statico
        public static Adress ParseFromLine(string line)
        {
            // divido una stringa in un array di stringhe basandomi sul carattere della virgola
            string[] stringSplits = line.Split(',');

            for (int i = 0; i < stringSplits.Length; i++)
            {
                stringSplits[i] = stringSplits[i].Trim();
            }

            if (stringSplits.Length != 6)
            {
                // sollevo un eccezione come prova perchè una volta sollevata il programma ferma la sua esecuzione
                //throw new Exception($"L'indirizzo '{line}' non è leggibile");

                // utilizzo un writeline per evitare che si blocchi il programma
                //Console.WriteLine($"L'indirizzo '{line}' non è leggibile");

                throw new Exception($"L'indirizzo '{line}' non è leggibile");

            }
            else
            {
                //if (stringSplits[0].Length == 0 || stringSplits[1].Length == 0 || stringSplits[2].Length == 0 || stringSplits[3].Length == 0 || stringSplits[4].Length == 0 || stringSplits[5].Length == 0)
                if (stringSplits.Any(s => s.Length == 0))
                {
                    //Console.WriteLine($"L'indirizzo '{line}' non è conforme");

                    throw new Exception($"L'indirizzo '{line}' non è conforme");
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

                    return newAdress;
                }
            }
        }
    }
}

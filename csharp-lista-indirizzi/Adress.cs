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
    }
}

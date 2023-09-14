using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_lista_indirizzi
{
    public class Adress
    {
        // Street,City,Province,ZIP
        public string Street { get; private set; }
        public string City { get; private set; }
        public string Province { get; private set; }
        public int Zip { get; private set; }

        public Adress(string street, string city, string province, int zip)
        {
            this.Street = street;
            this.City = city;
            this.Province = province;
            this.Zip = zip;
        }
    }
}

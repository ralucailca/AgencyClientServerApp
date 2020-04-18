using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    [Serializable]
    public class Client : Entity<int>
    {
        public string Nume { get; set; }
        public string Telefon { get; set; }

        public Client(int id, string nume, string telefon)
        {
            Id = id;
            Nume = nume;
            Telefon = telefon;
        }

        public Client()
        {

        }

        public override string ToString()
        {
            return Id + " " + Nume + " " + Telefon;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}

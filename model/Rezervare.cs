using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    [Serializable]
    public class Rezervare : Entity<IdRezervare>
    {
        public int Bilete { get; set; }

        public Rezervare(IdRezervare id, int bilete)
        {
            Id = id;
            Bilete = bilete;
        }

        public Rezervare()
        {

        }

        public override string ToString()
        {
            return Id.IdExcursie + " " + Id.IdClient + " " + Bilete;
        }


    }
}

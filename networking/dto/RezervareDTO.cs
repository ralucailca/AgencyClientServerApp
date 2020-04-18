using model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace networking.dto
{
    [Serializable]
    public class RezervareDTO
    {
        public Excursie Excursie { get; set; }
        public Client Client { get; set; }
        public int Bilete { get; set; }

        public RezervareDTO()
        {
                
        }

        public RezervareDTO(Excursie excursie, Client client, int bilete)
        {
            Excursie = excursie;
            Client = client;
            Bilete = bilete;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace networking.dto
{
    [Serializable]
    public class CautareDTO
    {
        public string Obiectiv { get; set; }
        public int Ora1 { get; set; }
        public int Ora2 { get; set; }

        public CautareDTO(string obiectiv, int ora1, int ora2)
        {
            Obiectiv = obiectiv;
            Ora1 = ora1;
            Ora2 = ora2;
        }

        public CautareDTO()
        {

        }
    }
}

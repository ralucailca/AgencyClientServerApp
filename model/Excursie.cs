using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    [Serializable]
    public class Excursie : Entity<int>
    {
        public string Obiectiv { get; set; }
        public string Firma { get; set; }
        public int OraPlecare { get; set; }
        public float Pret { get; set; }
        public int Locuri { get; set; }

        public Excursie()
        {

        }

        public Excursie(int id, string obiectiv, string firma, int oraPlecare, float pret, int locuri)
        {
            Id = id;
            Obiectiv = obiectiv;
            Firma = firma;
            OraPlecare = oraPlecare;
            Pret = pret;
            Locuri = locuri;
        }

        public override bool Equals(object obj)
        {
            var excursie = obj as Excursie;
            return excursie != null &&
                   Obiectiv == excursie.Obiectiv &&
                   Firma == excursie.Firma &&
                   OraPlecare == excursie.OraPlecare &&
                   Pret == excursie.Pret &&
                   Locuri == excursie.Locuri;
        }

        public override int GetHashCode()
        {
            var hashCode = 1010089584;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Obiectiv);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Firma);
            hashCode = hashCode * -1521134295 + OraPlecare.GetHashCode();
            hashCode = hashCode * -1521134295 + Pret.GetHashCode();
            hashCode = hashCode * -1521134295 + Locuri.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return Id + " " + Obiectiv + " " + Firma + " " + OraPlecare + " " + Pret + " " + Locuri;
        }

    }
}

using model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace services
{
    public interface IService
    {
        void Login(Agent agent, IObserver observer);
        void Logout(Agent agent, IObserver observer);
        IEnumerable<Excursie> CautaObiectivInterval(string obv, int ora1, int ora2);
        IEnumerable<Excursie> FindAll();
        void Rezerva(Excursie excursie, Client client, int bilete);
    }
}

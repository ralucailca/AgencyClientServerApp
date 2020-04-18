using model;
using services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clientAgentie
{
    public class Controller: IObserver
    {
        public event EventHandler<UpdateEventArgs> updateEvent; //ctrl calls it when it has received an update
        private readonly IService server;
        private Agent current;
        public Controller(IService server)
        {
            this.server = server;
            current = null;
        }

        public void Update(List<Excursie> excursii)
        {
            Console.WriteLine("UPDATE");
            UpdateEventArgs update = new UpdateEventArgs(excursii);
            OnUserEvent(update);
        }

        protected virtual void OnUserEvent(UpdateEventArgs e)
        {
            if (updateEvent == null) return;
            updateEvent(this, e);
            Console.WriteLine("Update Event called");
        }

        public void Login(string user, string pass)
        {
            Agent agent = new Agent(0, user, pass);
            server.Login(agent, this);
            current = agent;
        }

        public void logout()
        {
            Console.WriteLine("Ctrl logout");
            server.Logout(current, this);
            current = null;
        }

        public IEnumerable<Excursie> CautaObiectivInterval(string obv, int ora1, int ora2)
        {
            return server.CautaObiectivInterval(obv, ora1, ora2);
        }

        public IEnumerable<Excursie> FindAll()
        {
            return server.FindAll();
        }

        public void Rezerva(Excursie excursie, model.Client client, int bilete)
        {
            server.Rezerva(excursie, client, bilete);
        }

    }
}

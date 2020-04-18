using model;
using persistence;
using services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentieClientServer_MPP
{
    class ServerImplementation : IService
    {
        private ClientDbRepository clientDbRepository;
        private RezervareDbRepository rezervareDbRepository;
        private ExcursieDbRepository excursieDbRepository;
        private AgentDbRepository agentiDbRepository;
        private readonly IDictionary<int, IObserver> loggedAgenti;

        public ServerImplementation(ClientDbRepository clientDbRepository, RezervareDbRepository rezervareDbRepository, 
            ExcursieDbRepository excursieDbRepository, AgentDbRepository agentiDbRepository)
        {
            this.clientDbRepository = clientDbRepository;
            this.rezervareDbRepository = rezervareDbRepository;
            this.excursieDbRepository = excursieDbRepository;
            this.agentiDbRepository = agentiDbRepository;
            loggedAgenti = new Dictionary<int, IObserver>();
        }

        public IEnumerable<Excursie> CautaObiectivInterval(string obv, int ora1, int ora2)
        {
            return excursieDbRepository.findAll().Where(e => e.Obiectiv.Equals(obv) && e.OraPlecare >= ora1 && e.OraPlecare <= ora2).ToList();
        }

        public IEnumerable<Excursie> FindAll()
        {
            return excursieDbRepository.findAll();
        }

        public void Login(Agent agent, IObserver observer)
        {
            Agent a;
            try
            {
                a = agentiDbRepository.findAll().Where(x => x.User.Equals(agent.User) && x.Password.Equals(agent.Password)).Select(x => x).First();
            }catch(ArgumentNullException e)
            {
                throw new AgentieException("User invalid!");
            }
            catch (InvalidOperationException e)
            {
                throw new AgentieException("User invalid!");
            }
            if (a != null)
            {
                if (loggedAgenti.ContainsKey(a.Id))
                    throw new AgentieException("User already logged in.");
                loggedAgenti[a.Id] = observer;
            }
            else
                throw new AgentieException("Authentication failed.");
        }

        public void Logout(Agent agent, IObserver observer)
        {
            Agent a;
            try
            {
                a = agentiDbRepository.findAll().Where(x => x.User.Equals(agent.User) && x.Password.Equals(agent.Password)).Select(x => x).First();
            }
            catch (ArgumentNullException e)
            {
                throw new AgentieException("User invalid!");
            }
            catch (InvalidOperationException e)
            {
                throw new AgentieException("User invalid!");
            }
            IObserver localClient = loggedAgenti[a.Id];
            if (localClient == null)
                throw new AgentieException("User " + a.User + " is not logged in.");
            loggedAgenti.Remove(a.Id);
        }

        public void Rezerva(Excursie excursie, Client client, int bilete)
        {
            
            client.Id = clientDbRepository.findAll().Max(x => x.Id)+1;
            clientDbRepository.save(client);
            IdRezervare idRezervare = new IdRezervare { IdExcursie = excursie.Id, IdClient = client.Id };
            Rezervare rezervare = new Rezervare(idRezervare, bilete);
            int locuriDisponibile = excursie.Locuri;
            if (locuriDisponibile - bilete < 0)
                throw new AgentieException("Nu mai exista suficiente locuri pentru a finaliza rezervarea!");
            excursie.Locuri = locuriDisponibile - bilete;
            excursieDbRepository.update(excursie.Id, excursie);
            rezervareDbRepository.save(rezervare);
            notifyUpdateExcursii();
        }

        private void notifyUpdateExcursii()
        {
            foreach(IObserver observer in loggedAgenti.Values)
            {
                Task.Run(()=>observer.Update(excursieDbRepository.findAll().ToList()));
            }
        }
    }
}

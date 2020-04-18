using log4net.Config;
using networking;
using persistence;
using services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AgentieClientServer_MPP
{
    public class StartServer
    {
        public static void Main(string[] args)
        {

            XmlConfigurator.Configure(new System.IO.FileInfo("log4net.xml"));

            AgentDbRepository agentDbRepository = new AgentDbRepository();
            ClientDbRepository clientDbRepository = new ClientDbRepository();
            ExcursieDbRepository excursieDbRepository = new ExcursieDbRepository();
            RezervareDbRepository rezervareDbRepository = new RezervareDbRepository();
            IService serviceImpl = new ServerImplementation(clientDbRepository, rezervareDbRepository, excursieDbRepository, agentDbRepository);

            SerialServer server = new SerialServer("127.0.0.1", 55555, serviceImpl);
            server.Start();
            Console.WriteLine("Server started ...");
            //Console.WriteLine("Press <enter> to exit...");
            Console.ReadLine();

        }
    }

    public class SerialServer : ConcurrentServer
    {
        private IService server;
        private ClientWorker worker;
        public SerialServer(string host, int port, IService server) : base(host, port)
        {
            this.server = server;
            Console.WriteLine("SerialChatServer...");
        }
        protected override Thread createWorker(TcpClient client)
        {
            worker = new ClientWorker(server, client);
            return new Thread(new ThreadStart(worker.run));
        }
    }
}

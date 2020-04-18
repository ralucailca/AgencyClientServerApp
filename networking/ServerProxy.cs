using model;
using networking.dto;
using services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace networking
{
    public class ServerProxy: IService
    {
        private string host;
        private int port;

        private IObserver client;

        private NetworkStream stream;

        private IFormatter formatter;
        private TcpClient connection;

        private Queue<Response> responses;
        private volatile bool finished;
        private EventWaitHandle _waitHandle;
        public ServerProxy(string host, int port)
        {
            this.host = host;
            this.port = port;
            responses = new Queue<Response>();
        }

        public virtual void Login(Agent agent, IObserver observer)
        {
            initializeConnection();
            sendRequest(new LoginRequest(agent));
            Response response = readResponse();
            if (response is OkResponse)
            {
                this.client = observer;
                return;
            }
            if (response is ErrorResponse)
            {
                ErrorResponse err = (ErrorResponse)response;
                closeConnection();
                throw new AgentieException(err.Message);
            }
        }

        public virtual void Logout(Agent agent, IObserver observer)
        {
            sendRequest(new LogoutRequest(agent));
            Response response = readResponse();
            closeConnection();
            if (response is ErrorResponse)
            {
                ErrorResponse err = (ErrorResponse)response;
                throw new AgentieException(err.Message);
            }
        }

        public virtual IEnumerable<Excursie> CautaObiectivInterval(string obv, int ora1, int ora2)
        {
            CautareDTO cautareDTO = new CautareDTO(obv, ora1, ora2);
            sendRequest(new CautareRequest(cautareDTO));
            Response response = readResponse();
            if (response is ErrorResponse)
            {
                ErrorResponse err = (ErrorResponse)response;
                throw new AgentieException(err.Message);
            }
            CautareResponse resp = (CautareResponse)response;
            Excursie[] ex = resp.Excursii;
            List<Excursie> excursii = ex.OfType<Excursie>().ToList();
            return excursii;
        }

        public virtual IEnumerable<Excursie> FindAll()
        {
            sendRequest(new ListaRequest());
            Response response = readResponse();
            if (response is ErrorResponse)
            {
                ErrorResponse err = (ErrorResponse)response;
                throw new AgentieException(err.Message);
            }
            ListaResponse resp = (ListaResponse)response;
            Excursie[] ex = resp.Excursii;
            List<Excursie> excursii = ex.OfType<Excursie>().ToList();
            return excursii;

        }

        public virtual void Rezerva(Excursie excursie, Client client, int bilete)
        {
            RezervareDTO rezervareDTO = new RezervareDTO(excursie, client, bilete);
            sendRequest(new RezervareRequest(rezervareDTO));
            Response response = readResponse();
            if(response is ErrorResponse)
            {
                ErrorResponse err = (ErrorResponse)response;
                throw new AgentieException(err.Message);
            }

        }


        private void closeConnection()
        {
            finished = true;
            try
            {
                stream.Close();
                //output.close();
                connection.Close();
                _waitHandle.Close();
                client = null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

        }

        private void sendRequest(Request request)
        {
            try
            {
                formatter.Serialize(stream, request);
                stream.Flush();
            }
            catch (Exception e)
            {
                throw new AgentieException("Error sending object " + e);
            }

        }

        private Response readResponse()
        {
            Response response = null;
            try
            {
                _waitHandle.WaitOne();
                lock (responses)
                {
                    //Monitor.Wait(responses); 
                    response = responses.Dequeue();

                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            return response;
        }
        private void initializeConnection()
        {
            try
            {
                connection = new TcpClient(host, port);
                stream = connection.GetStream();
                formatter = new BinaryFormatter();
                finished = false;
                _waitHandle = new AutoResetEvent(false);
                startReader();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
        private void startReader()
        {
            Thread tw = new Thread(run);
            tw.Start();
        }


        private void handleUpdate(UpdateResponse update)
        {
            if (update is Update)
            {

                Update up = (Update)update;
                Excursie[] ex = up.Excursii;
                List<Excursie> excursii = ex.OfType<Excursie>().ToList();
                Console.WriteLine("Excursi update " );
                try
                {
                    client.Update(excursii);
                }
                catch (AgentieException e)
                {
                    Console.WriteLine(e.StackTrace);
                }
            }
        }

        public virtual void run()
        {
            while (!finished)
            {
                try
                {
                    object response = formatter.Deserialize(stream);
                    Console.WriteLine("response received " + response);
                    if (response is UpdateResponse)
                    {
                        handleUpdate((UpdateResponse)response);
                    }
                    else
                    {

                        lock (responses)
                        {


                            responses.Enqueue((Response)response);

                        }
                        _waitHandle.Set();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Reading error " + e);
                }

            }
        }

        
    }

}

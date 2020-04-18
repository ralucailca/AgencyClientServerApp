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
    public class ClientWorker : IObserver
    { 
        private IService server;
        private TcpClient connection;

        private NetworkStream stream;
        private IFormatter formatter;
        private volatile bool connected;
        public ClientWorker(IService server, TcpClient connection)
        {
            this.server = server;
            this.connection = connection;
            try
            {

                stream = connection.GetStream();
                formatter = new BinaryFormatter();
                connected = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        public virtual void run()
        {
            while (connected)
            {
                try
                {
                    object request = formatter.Deserialize(stream);
                    object response = handleRequest((Request)request);
                    if (response != null)
                    {
                        sendResponse((Response)response);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }

                try
                {
                    Thread.Sleep(1000);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
            }
            try
            {
                stream.Close();
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e);
            }
        }

        public virtual void Update(List<Excursie> excursii)
        {
            Console.WriteLine("Excursii " );
            Excursie[] ex = excursii.ToArray();
            try
            {
                sendResponse(new Update(ex));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        private Response handleRequest(Request request)
        {
            Response response = null;
            if (request is LoginRequest)
            {
                Console.WriteLine("Login request ...");
                LoginRequest logReq = (LoginRequest)request;
                Agent agent = logReq.Agent;
                try
                {
                    lock (server)
                    {
                        server.Login(agent, this);
                    }
                    return new OkResponse();
                }
                catch (AgentieException e)
                {
                    connected = false;
                    return new ErrorResponse(e.Message);
                }
            }
            if (request is LogoutRequest)
            {
                Console.WriteLine("Logout request");
                LogoutRequest logReq = (LogoutRequest)request;
                Agent agent = logReq.Agent;
                try
                {
                    lock (server)
                    {

                        server.Logout(agent, this);
                    }
                    connected = false;
                    return new OkResponse();

                }
                catch (AgentieException e)
                {
                    return new ErrorResponse(e.Message);
                }
            }
            if (request is RezervareRequest)
            {
                Console.WriteLine("RezervareRequest ...");
                RezervareRequest rezReq = (RezervareRequest)request;
                RezervareDTO rdto = rezReq.RezervareDTO;
                try
                {
                    lock (server)
                    {
                        server.Rezerva(rdto.Excursie, rdto.Client, rdto.Bilete);
                    }
                    return new OkResponse();
                }
                catch (AgentieException e)
                {
                    return new ErrorResponse(e.Message);
                }
            }

            if (request is ListaRequest)
            {
                Console.WriteLine("Lista Request ...");
                ListaRequest listReq = (ListaRequest)request;
               
                try
                {
                    Excursie[] res;
                    lock (server)
                    {
                        res = server.FindAll().ToArray();
                    }
                    return new ListaResponse(res);
                }
                catch (AgentieException e)
                {
                    return new ErrorResponse(e.Message);
                }
            }

            if (request is CautareRequest)
            {
                Console.WriteLine("Cautare Response ...");
                CautareRequest cautaReq = (CautareRequest)request;
                CautareDTO cautareDTO = cautaReq.CautareDTO;
                try
                {
                    Excursie[] res;
                    lock(server)
                    {
                        res = server.CautaObiectivInterval(cautareDTO.Obiectiv, cautareDTO.Ora1, cautareDTO.Ora2).ToArray();
                    }
                    return new CautareResponse(res);
                }catch(AgentieException e)
                {
                    return new ErrorResponse(e.Message);
                }
            }
            return response;
        }

        private void sendResponse(Response response)
        {
            Console.WriteLine("sending response " + response);
            formatter.Serialize(stream, response);
            stream.Flush();

        }
    }

}

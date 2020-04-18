using model;
using networking.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace networking
{
    public interface Request
    {
    }


    [Serializable]
    public class LoginRequest : Request
    {
        private Agent agent;

        public LoginRequest(Agent agent)
        {
            this.agent = agent;
        }

        public virtual Agent Agent
        {
            get
            {
                return agent;
            }
        }
    }

    [Serializable]
    public class LogoutRequest : Request
    {
        private Agent agent;

        public LogoutRequest(Agent agent)
        {
            this.agent = agent;
        }

        public virtual Agent Agent
        {
            get
            {
                return agent;
            }
        }
    }

    [Serializable]
    public class RezervareRequest : Request
    {
        private RezervareDTO rezervareDTO;

        public RezervareRequest(RezervareDTO rezervareDTO)
        {
            this.rezervareDTO=rezervareDTO;
        }

        public virtual RezervareDTO RezervareDTO
        {
            get
            {
                return rezervareDTO;
            }
        }
    }

    [Serializable]
    public class CautareRequest : Request
    {
        private CautareDTO cautareDTO;

        public CautareRequest(CautareDTO cautareDTO)
        {
            this.cautareDTO = cautareDTO;
        }

        public virtual CautareDTO CautareDTO
        {
            get
            {
                return cautareDTO;
            }
        }
    }

    [Serializable]
    public class ListaRequest : Request
    {
        public ListaRequest()
        {
          
        }
    }

}

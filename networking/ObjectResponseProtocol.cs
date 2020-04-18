using model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace networking
{
    public interface Response
    {
    }

    [Serializable]
    public class OkResponse : Response
    {

    }

    [Serializable]
    public class ErrorResponse : Response
    {
        private string message;

        public ErrorResponse(string message)
        {
            this.message = message;
        }

        public virtual string Message
        {
            get
            {
                return message;
            }
        }
    }

    [Serializable]
    public class CautareResponse : Response
    {
        private Excursie[] excursii;

        public CautareResponse(Excursie[] excursii)
        {
            this.excursii = excursii;
        }

        public virtual Excursie[] Excursii
        {
            get
            {
                return excursii;
            }
        }
    }

    [Serializable]
    public class ListaResponse : Response
    {
        private Excursie[] excursii;

        public ListaResponse(Excursie[] excursii)
        {
            this.excursii = excursii;
        }

        public virtual Excursie[] Excursii
        {
            get
            {
                return excursii;
            }
        }
    }

    public interface UpdateResponse : Response
    {
    }

    [Serializable]
    public class Update : UpdateResponse
    {
        private Excursie[] excursii;

        public Update(Excursie[] excursii)
        {
            this.excursii = excursii;
        }

        public virtual Excursie[] Excursii
        {
            get
            {
                return excursii;
            }
        }
    }
    
}

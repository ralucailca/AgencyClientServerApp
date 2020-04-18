using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    [Serializable]
    public class Agent : Entity<int>
    {
        public string User { get; set; }
        public string Password { get; set; }

        public Agent()
        {

        }

        public Agent(int id, string user, string pass)
        {
            Id = id;
            User = user;
            Password = pass;
        }


        public override string ToString()
        {
            return Id + " " + User + " " + Password;
        }
    }
}

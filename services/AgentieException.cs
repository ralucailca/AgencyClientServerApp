using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace services
{
    public class AgentieException : Exception
    {
        public AgentieException() : base() { }

        public AgentieException(String msg) : base(msg) { }

        public AgentieException(String msg, Exception ex) : base(msg, ex) { }

    }
}

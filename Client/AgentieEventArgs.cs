using model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clientAgentie
{
    public class UpdateEventArgs
    {
        private readonly List<Excursie> data;

        public UpdateEventArgs(List<Excursie> data)
        {
            this.data = data;
        }

        public List<Excursie> Data
        {
            get { return data; }
        }
    }
}

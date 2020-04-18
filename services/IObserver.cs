using model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace services
{
    public interface IObserver
    {
        void Update(List<Excursie> excursii);
    }
}

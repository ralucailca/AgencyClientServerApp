
using networking;
using services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clientAgentie
{
    static class StartClient
    {
       
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            IService server = new ServerProxy("127.0.0.1", 55555);
            Controller ctrl = new Controller(server);
            LoginForm win = new LoginForm(ctrl);
            Application.Run(win);
        }
    }
}

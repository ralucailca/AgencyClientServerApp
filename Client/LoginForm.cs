using model;
using services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clientAgentie
{
    public partial class LoginForm : Form
    {
        private Controller controller;

        public LoginForm(Controller controller)
        {
            InitializeComponent();
            this.controller = controller;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == "" || txtPass.Text == "")
            {
                MessageBox.Show("Introduceti user-ul si parola!");
                return;
            }

            string user = txtUser.Text;
            string pass = txtPass.Text;
            try
            {
                controller.Login(user, pass);  
                ExcursieForm excursieForm = new ExcursieForm(controller);
                excursieForm.Text = "AGENT:" + user;
                excursieForm.Show();
                this.Hide();
            }
            catch(AgentieException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}

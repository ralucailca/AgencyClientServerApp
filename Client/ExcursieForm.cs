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
    public partial class ExcursieForm : Form
    {
        private Controller controller;

        public ExcursieForm(Controller controller)
        {
            InitializeComponent();
            this.controller = controller;

            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewCauta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.MultiSelect = false;
            controller.updateEvent += Update;
            Init();
        }


        public void Update(object sender, UpdateEventArgs e)
        {
            
            List<Excursie> excursii = e.Data;
            dataGridView.BeginInvoke(new UpdateDataGridCallback(this.updateDataGrid), new Object[] { dataGridView, excursii });
        }


        //for updating the GUI

        //1. define a method for updating the ListBox
        private void updateDataGrid(DataGridView dataGrid, IList<Excursie> newData)
        {
            dataGrid.Rows.Clear();
            foreach (Excursie e in newData)
            {
                var index = dataGridView.Rows.Add();
                dataGridView.Rows[index].Cells["Id"].Value = e.Id;
                dataGridView.Rows[index].Cells["obiectiv"].Value = e.Obiectiv;
                dataGridView.Rows[index].Cells["Firma"].Value = e.Firma;
                dataGridView.Rows[index].Cells["OraPlecare"].Value = e.OraPlecare;
                dataGridView.Rows[index].Cells["Pret"].Value = e.Pret;
                dataGridView.Rows[index].Cells["Locuri"].Value = e.Locuri;

                foreach (DataGridViewRow row in dataGridView.Rows)
                    if (Convert.ToInt32(row.Cells[5].Value) == 0 && row.Cells[0].Value != null)
                    {
                        row.DefaultCellStyle.BackColor = Color.Red;
                    }
            }
        }

        //2. define a delegate to be called back by the GUI Thread
        public delegate void UpdateDataGridCallback(DataGridView dataGrid, IList<Excursie> newData);

        public void Init()
        {
            dataGridView.Rows.Clear();
            IEnumerable<Excursie> excursii = controller.FindAll();
            foreach (Excursie e in excursii)
            {
                var index = dataGridView.Rows.Add();
                dataGridView.Rows[index].Cells["Id"].Value = e.Id;
                dataGridView.Rows[index].Cells["obiectiv"].Value = e.Obiectiv;
                dataGridView.Rows[index].Cells["Firma"].Value = e.Firma;
                dataGridView.Rows[index].Cells["OraPlecare"].Value = e.OraPlecare;
                dataGridView.Rows[index].Cells["Pret"].Value = e.Pret;
                dataGridView.Rows[index].Cells["Locuri"].Value = e.Locuri;

                foreach (DataGridViewRow row in dataGridView.Rows)
                    if (Convert.ToInt32(row.Cells[5].Value) == 0 && row.Cells[0].Value != null)
                    {
                        row.DefaultCellStyle.BackColor = Color.Red;
                    }
            }
        }



        private void btnCauta_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridViewCauta.Rows.Clear();
                IEnumerable<Excursie> result = controller.CautaObiectivInterval(txtObiectiv.Text, Int32.Parse(txtOra1.Text), Int32.Parse(txtOra2.Text));
                foreach (Excursie ex in result)
                {
                    var index = dataGridViewCauta.Rows.Add();
                    dataGridViewCauta.Rows[index].Cells["IdExcursie"].Value = ex.Id;
                    dataGridViewCauta.Rows[index].Cells["ObiectivTuristic"].Value = ex.Obiectiv;
                    dataGridViewCauta.Rows[index].Cells["FirmaExcursie"].Value = ex.Firma;
                    dataGridViewCauta.Rows[index].Cells["Ora"].Value = ex.OraPlecare;
                    dataGridViewCauta.Rows[index].Cells["PretExcursie"].Value = ex.Pret;
                    dataGridViewCauta.Rows[index].Cells["LocuriExcursie"].Value = ex.Locuri;

                }
            }
            catch (FormatException exc)
            {
                MessageBox.Show("Orele trebuie sa fie numere intregi!");
            }
        }


        private void btnRezervare_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView.SelectedRows.Count == 0)
                    MessageBox.Show("Selectati o excursie dintr-un tabel!");
                else
                {
                    int idSelected;
                    string obv;
                    string firma;
                    int ora, locuri;
                    float pret;
                    
                    idSelected = Int32.Parse(dataGridView.SelectedRows[0].Cells["Id"].Value.ToString());
                    obv = dataGridView.SelectedRows[0].Cells["obiectiv"].Value.ToString();
                    firma = dataGridView.SelectedRows[0].Cells["Firma"].Value.ToString();
                    ora = Int32.Parse(dataGridView.SelectedRows[0].Cells["OraPlecare"].Value.ToString());
                    pret = Single.Parse(dataGridView.SelectedRows[0].Cells["Pret"].Value.ToString());
                    locuri = Int32.Parse(dataGridView.SelectedRows[0].Cells["Locuri"].Value.ToString());
                    Excursie excursie = new Excursie(idSelected, obv, firma, ora, pret, locuri);
                    // int idClient = Int32.Parse(txtId.Text);
                    string nume = txtNume.Text;
                    string tel = txtTel.Text;
                    int bilete = Int32.Parse(txtBilete.Text);
                    model.Client client = new model.Client(0, nume, tel);
                    controller.Rezerva(excursie, client, bilete);
                    MessageBox.Show("Rezervarea a fost finalizata!");
                }

            }
            catch (AgentieException exception)
            {
                MessageBox.Show(exception.Message);
            }
            catch(FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            controller.logout();
            controller.updateEvent -= Update;
            this.Hide();
            Application.Exit();
        }

    }
}

using Academy.DataManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Academy.Entities;
namespace Academy.Bank
{
    public partial class OpenCCForm : Form
    {
        private IDataManager datamanager;
        public string CurrentUser;// nè get ne set cosi non posso settarlo ne leggerlo da fuori ma da dentro posso ffare quello che voglio
        public OpenCCForm()
        {
            InitializeComponent();

            this.lbl_owner.Text = CurrentUser;


        }
        public OpenCCForm(string username) // per passare un parametro lo devo passare nel costruttore
        {
            datamanager = new FileSystemDataManager();
            InitializeComponent();
            this.CurrentUser = username;
            this.lbl_owner.Text = CurrentUser;
            string numconto= Academy.Helper.RandomHelper.GetNumConto(10);
            this.label3.Text = numconto; 
        }



        private void btn_conferma_Click(object sender, EventArgs e)
        {
            string numconto = this.label3.Text;
            string username = this.lbl_owner.Text;
            string nome = this.txt_nome.Text;
            string cognome = this.txt_cognome.Text;
            string CF = this.txt_CF.Text;
            ContoCorrente newCC = new ContoCorrente(numconto, 0); // creo una nuova entità conto corrente 
            Cliente newCliente = new Cliente() // creo una nuova entità cliente, a cui però devo pasare un oggetto conto corrente 

            {
                Username = username,
                FirstName = nome,
                LastName = cognome,
                CF = CF, 
                mioConto = newCC

            };

             
            

             
            //ora devo creare un'entità cliente e una conto corrente
            
            DataOperationResult result= datamanager.CreateNewCliente(newCliente); // ora scrivo i dati usando datamanager
            if (result.isOK)
            {

                ManageCCForm manageform = new ManageCCForm(newCC,numconto, newCC.GetSaldo(),"OpenCC") ;
                manageform.Tag = this; // this è open ccform
                manageform.Show();
                this.Hide();

            }
            else
            {
                this.label7.Text = "L'operazione non è andata a buon fine, riprovare";
            }


            //ManageCCForm manageform = new ManageCCForm();
            //manageform.Show();
            //this.Hide();

            //manageform.Tag = this;
            //manageform.Show(this);
            //this.Hide();
        }

        private void btn_annulla_Click(object sender, EventArgs e)
        {
            this.txt_nome.Text = "";
            this.txt_cognome.Text = "";
            this.txt_CF.Text = "";
        }

        private void btn_close_open_Click(object sender, EventArgs e)
        {
            this.Close();
            var form1 = (LoginForm)Tag; // prendo la variabile tag che ha il puntatore al login form, ne faccio un casting così ho il riferimento
            form1.Show();
            form1.Close();

        }
    }
}
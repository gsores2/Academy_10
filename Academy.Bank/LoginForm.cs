using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Academy.DataManager;
using DataManager;
using Academy.Entities;
namespace Academy.Bank
{
    public partial class LoginForm : Form
    {

        private IDataManager datamanager; // uso un interfaccia cosi posso usare sia un file di testo che un database 
        public LoginForm()
        {
            datamanager = new FileSystemDataManager(); // creo un istanza della classe filesystem che implementa interfaccia
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //bottone login
        {
            // se credenziali corrette vado all'altra form, altrimenti errore
            string username = this.textBox1.Text;

            string password = this.textBox2.Text;

            if (datamanager.LoginIsOK (username, password))
            {
                if (datamanager.UserIsAnOwner(username))
                {
                    //// devo trovare il contocorrente per poter aprire manage form
                    ContoCorrente cc = datamanager.GetContoCorrenteByUsername(username);
                    ManageCCForm manageform = new ManageCCForm(cc, cc.GetNumeroConto(), cc.GetSaldo(),"Login");
                    manageform.Show();


                    manageform.Tag = this;
                    manageform.Show();
                    this.Hide();
                }
                else // apro open cc quando user non è un owner
                {
                    lbl_login_error.Text = "";
                    OpenCCForm openform = new OpenCCForm(username); // Form1 crea gli altri 2 form a seconda 
                                                            //openform.Show();
                                                            //this.Hide();
                    // devo passare il nome del cliente ( nel costruttore)
                    openform.Tag = this; // proprietà tag di operform (suo padre è il login form)
                    openform.Show(); //this è un puntatore
                    this.Hide();
                }
               
            }
            else
            {
                lbl_login_error.Text = "Invalid credentials";
            }
            
            
        }

        

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbl_login_error_Click(object sender, EventArgs e)
        {

        }
    }
}

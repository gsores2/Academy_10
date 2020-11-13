using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Acadeny.DB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_clienti_Click(object sender, EventArgs e)
        {
            
            string connectionString = @" Data Source=WINAP4R3GZJOYFF\SQLEXPRESS;Initial Catalog=AcademyDB;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connectionString)) // usando la connessione
            { // per potermi connetter a un server mi serve una stringa di connessione
               
                // copio la command string dal mamagement sql
                string cmd_text = "SELECT [ID],[FirstName],[LastName],[FiscalCode] FROM [AcademyDB].[dbo].[Clients]"; // voglio prendere tutti i clienit
                SqlCommand cmd = new SqlCommand(cmd_text, conn);

                // ora devo aprire una connessione per comunicare con il database (l'ho creata ma non aperta)

                conn.Open();
                //poi eseguo il comando, che ha diversi metodi a seconda che mi aspetti uno scalare (tipo count o avg) o un record (reader)
                SqlDataReader dr = cmd.ExecuteReader(); // exectue scalar prende il risutlato di count o avg 
                // data reader è uguale allos tream di byte, mi resituisce un record con i campi che ho cheisto
                // EXECUTE READER è UN PUNTATORE (quando lo dichiaro si mette all'inizio della tabella)
                while (dr.Read()) // quando read mi dà false ho finito i record (ogni riga è un array, cioè un record)
                {
                    string id = dr[0].ToString();
                    string firstName = dr[1].ToString(); // in posizione 0 ho l'id
                    string lastName = dr[2].ToString();
                    string item =id+ " "+ firstName + " " + lastName;
                    this.lst_clienti.Items.Add(item); // aggiunge un item alla lista 
                    // voglio mettere un gestore di eventi cosi quando clicco un nome mi fa vedere il conto corrente
                }
                conn.Close(); 
            }

        
        }

        private void lst_clienti_SelectedIndexChanged(object sender, EventArgs e)
        {


            string item = this.lst_clienti.SelectedItem.ToString(); // copio chi ho selezionato, selezion ID
            // ora splitto stringa e trovo id  
            string[] splittedString = item.Split(new char[] { ' ' });
            int ID = Int32.Parse(splittedString[0]);
            string connectionString = @"Data Source=WINAP4R3GZJOYFF\SQLEXPRESS;Initial Catalog=AcademyDB;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                string sqlClients_ContiCorrtext = "SELECT ContiCorrenti.Saldo FROM Clients INNER JOIN ContiCorrenti ON Clients.ID = ContiCorrenti.Owner WHERE ContiCorrenti.ID = " + ID;
                SqlCommand cmd = new SqlCommand(sqlClients_ContiCorrtext, conn);

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                this.lst_conticorrenti.Items.Add(dr[0]);

                conn.Close();
            }

        }

        private void lst_conticorrenti_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}

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
using Academy.DataManager;
namespace Academy.Bank
{
    public partial class ManageCCForm : Form
    {
        private IDataManager datamanager1;
        
        string start_form;
        string conto;
        ContoCorrente contocorrente;
        string beneficiario_bonifico;
        DataOperationResult result_aggiornamento;
       
        public  ManageCCForm(ContoCorrente cc, string numconto, double saldo, string sender)
        {
            InitializeComponent();
            conto = numconto;
            this.lbl_CC.Text = numconto; // passo il numero di conto
            this.lbl_saldo.Text = saldo.ToString();
            start_form = sender;
            contocorrente = cc;
            datamanager1 = new FileSystemDataManager();
            //this.txt_movimenti.Text = string.Join("\r\n", contocorrente.ShowMovimenti());
        }

        private  void btn_cls_manage_Click(object sender, EventArgs e)
        {
            this.Hide();
             if(start_form=="Login")
            {
                var form1 = (LoginForm)Tag; // prendo la variabile tag che ha il puntatore al login form, ne faccio un casting così ho il riferimento
                form1.Show();
                form1.Close();
            }

            else 
            { 
                var form1 = (OpenCCForm)Tag; 
                form1.Show();
                form1.Close();
            }
            
           

        }
        
        private void btn_preleva_Click(object sender, EventArgs e)
        {
            
            contocorrente.Preleva(Double.Parse(txt_importo.Text));
            //displayBox.AppendText(sent);
            //displayBox.AppendText(Environment.NewLine);

            this.txt_movimenti.Text += contocorrente.ShowMovimenti("prelievo") +"\r\n";
            result_aggiornamento = datamanager1.AggiornaFileMovimenti(contocorrente.GetMovimento());
        }

        private  void btn_versa_Click(object sender, EventArgs e)
        {

            contocorrente.Deposita(Double.Parse(txt_importo.Text));

            this.txt_movimenti.Text += contocorrente.ShowMovimenti("deposito") + "\r\n";
            result_aggiornamento = datamanager1.AggiornaFileMovimenti(contocorrente.GetMovimento());
            //string line;
            //string saldo_corrente = "";
            //char[] chararray = new char[1]; // se scrivessi char[] ca starei dichiarando un puntatore vuoto
            //chararray[0] = ';';
            //System.IO.StreamReader file = new System.IO.StreamReader(System.IO.Path.Combine(@"C:\Users\giulia.soresini\Desktop", "ContiCorrenti.txt");
            //while ((line = file.ReadLine()) != null) // quella tra paresntesi si chiama guardia ed e' un espressione booleana
            //{
            //    String[] resultArray = line.Split(chararray);
            //    string current_conto = resultArray[0];

            //    if (current_conto == conto)
            //    {
            //        saldo_corrente = resultArray[1];
            //        break;
            //    }



            //}
            //file.Close();

            //saldo_corrente += Double.Parse(txt_importo.Text);
            //Movimento deposito = new Movimento() // così inizializzo una classe in un modo diverso
            //{
            //    Tipo = TipoMovimento.Deposito,
            //    Importo = Double.Parse(txt_importo.Text),
            //    Data = DateTime.Now // data di adesso
            //};
            //Movimenti.Add(deposito);

        }

        private void btn_bonifico_Click(object sender, EventArgs e)
        {
            beneficiario_bonifico = this.txt_beneficiario.Text;
            contocorrente.Bonifico(Double.Parse(txt_importo_bonifico.Text), beneficiario_bonifico);
            this.txt_movimenti.Text += contocorrente.ShowMovimenti("bonifico") + "\r\n";
            result_aggiornamento = datamanager1.AggiornaFileMovimenti(contocorrente.GetMovimento());
        }
    }
}

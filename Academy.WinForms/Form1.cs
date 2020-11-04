using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Academy.WinForms
{
    public partial class Form1 : Form
    {
        public Form1() // chiama costruttore
        {
            InitializeComponent();


        }
          
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) // ho un doppio click fatto quando ho creato itnerfaccia
        {
            string citta = this.comboBox1.SelectedItem.ToString(); // predno quello che ho selezionato
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.label1.Text = "Hello Form";
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Academy.WinForm.Tris
{   // mi serve un enum fuori che dichiaro come classe
    public partial class Form1 : Form
    {
        private Moves lastMove;
        public Form1()
        {
            lastMove = Moves.NoMoveYet; // nel costruttore ancora non ho dfatto mosse 
            InitializeComponent();
        }

        private void txt_00_TextChanged(object sender, EventArgs e)
        {
            //this.label1.Text = "Coordinate [0,0]";
            switch (lastMove)
            {
                case Moves.X: // X è B
                    if (this.txt_00.Text.ToUpper() == "X")
                    {
                        this.txt_00.Text = "";
                        this.label1.Text = "E' il turno di B"; // se ho già messo X
                    }
                    else if (this.txt_00.Text.ToUpper() == "O") // mossa giusta
                    {
                        lastMove = Moves.O;
                        this.txt_00.Text = this.txt_00.Text.ToUpper();
                        this.txt_00.Enabled = false;
                    }
                    else
                    {
                        this.txt_00.Text = "";
                        this.label1.Text = "Valori possibili sono 'X' e 'O'"; //non disabilito casella
                    }
                    break;
               
                   
            
            
                case Moves.O:
                    if (this.txt_00.Text.ToUpper() == "X")
                    {
                        lastMove = Moves.X;
                        this.txt_00.Text = this.txt_00.Text.ToUpper();
                        this.txt_00.Enabled = false;
                    }
                    else if (this.txt_00.Text.ToUpper() == "O")
                    {
                       
                        this.txt_00.Text = "";
                        this.label1.Text = "E' il turno di A";
                    }
                    else
                    {
                        this.txt_00.Text = "";
                        this.label1.Text = "Valori possibili sono 'X' e 'O'";
                    }
                    break;
                case Moves.NoMoveYet: // prima mossa puo accettare sia x che o

                    if (this.txt_00.Text.ToUpper() == "X")
                    {
                        lastMove = Moves.X;
                        this.txt_00.Text = this.txt_00.Text.ToUpper();
                        this.txt_00.Enabled = false;
                    }
                    else if (this.txt_00.Text.ToUpper() == "O")
                    {
                        lastMove = Moves.O;
                        this.txt_00.Text = this.txt_00.Text.ToUpper();
                        this.txt_00.Enabled = false;
                    }
                    else
                    {
                        this.txt_00.Text = "";
                        this.label1.Text = "Valori possibili sono 'X' e 'O'";
                    }
                    break;

                default:
                    break;
            }
            


        }

        private void txt_01_TextChanged(object sender, EventArgs e)
        {
            switch (lastMove)
            {
                case Moves.X:
                    if (this.txt_01.Text.ToUpper() == "X")
                    {
                        this.txt_01.Text = "";
                        this.label1.Text = "E' il turno di B";
                    }
                    else if (this.txt_01.Text.ToUpper() == "O")
                    {
                        lastMove = Moves.O;
                        this.txt_01.Text = this.txt_01.Text.ToUpper();
                        this.txt_01.Enabled = false;
                    }
                    else
                    {
                        this.txt_01.Text = "";
                        this.label1.Text = "Valori possibili sono 'X' e 'O' ";
                    }
                    break;
                case Moves.O:
                    if (this.txt_01.Text.ToUpper() == "X")
                    {
                        lastMove = Moves.X;
                        this.txt_01.Text = this.txt_01.Text.ToUpper();
                        this.txt_01.Enabled = false;
                    }
                    else if (this.txt_01.Text.ToUpper() == "O")
                    {
                        this.txt_01.Text = "";
                        this.label1.Text = "E' il turno di A";
                    }
                    else
                    {
                        this.txt_01.Text = "";
                        this.label1.Text = "Valori possibili sono 'X' e 'O' ";
                    }
                    break;
                case Moves.NoMoveYet:
                    if (this.txt_01.Text.ToUpper() == "X")
                    {
                        lastMove = Moves.X;
                        this.txt_01.Text = this.txt_01.Text.ToUpper();
                        this.txt_01.Enabled = false;
                    }
                    else if (this.txt_01.Text.ToUpper() == "O")
                    {
                        lastMove = Moves.O;
                        this.txt_01.Text = this.txt_01.Text.ToUpper();
                        this.txt_01.Enabled = false;
                    }
                    else
                    {
                        this.txt_01.Text = "";
                        this.label1.Text = "Valori possibili sono 'X' e 'O' ";
                    }
                    break;
                default:
                    break;
            }
        }

        private void txt_02_TextChanged(object sender, EventArgs e)
        {
            this.txt_02.Enabled = false;
        }

        private void txt_10_TextChanged(object sender, EventArgs e)
        {
            this.txt_10.Enabled = false;
        }

        private void txt_11_TextChanged(object sender, EventArgs e)
        {
            this.txt_11.Enabled = false;
        }

        private void txt_12_TextChanged(object sender, EventArgs e)
        {
            this.txt_12.Enabled = false;
        }

        private void txt_20_TextChanged(object sender, EventArgs e)
        {
            this.txt_20.Enabled = false;
        }

        private void txt_21_TextChanged(object sender, EventArgs e)
        {
            this.txt_21.Enabled = false;
        }

        private void txt_22_TextChanged(object sender, EventArgs e)
        {
            this.txt_22.Enabled = false;
        }
    }
}

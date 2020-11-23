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
        private Moves lastMove; // enum che contiene le possibili mosse
        public Form1()
        {
            lastMove = Moves.NoMoveYet; // nel costruttore ancora non ho dfatto mosse (NoMoveYet)
            InitializeComponent();
           
        }

        #region txt correct boolean variables
        string[,] Tris = new string[3, 3] { {"","",""},{ "","","" }, { "", "", "" } }; // inizializzo la matrice
        private bool txt_00_IsCorrect = false;
        private bool txt_01_IsCorrect = false;
        private bool txt_02_IsCorrect = false;
        private bool txt_10_IsCorrect = false;
        private bool txt_11_IsCorrect = false;
        private bool txt_12_IsCorrect = false;
        private bool txt_20_IsCorrect = false;
        private bool txt_21_IsCorrect = false;
        private bool txt_22_IsCorrect = false;
       
        #endregion
        // key down sollevato appena inserisco qualcosa in textbox, qui mi accorgo se i dati sono corretti
        // E' UNA CLASSE PARZIALE, GESTISCO in FORM1.ROWi
        private bool IsWinner(string[,] matrix, string v)
        {
              bool result = false; 
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == v) // controlla dove stanno X o O a seconda che stia giocando A o B sia in righe che in colonne che in diagonale
                    {
                        result = RowControl(v, i, matrix); // se isEqual è vero in RowControl allora result è vero quindi nella riga i-esima ho trovato un tris
                        if (result == true) break;
                        result = ColumnControl(v, j, matrix);  // se isEqual è vero in ColumnControl allora result è vero quindi nella colonna j-esima ho trovato un tris
                        if (result == true) break;
                        if ((i + j) % 2 == 0) result = DiagonalControl(v, i, j, matrix); // sto sulla diagonale se la somma di riga e colonna è pari 
                        if (result == true) break;
                    }
                }
                if (result == true) break;
            }

            
            
            return result;

        }
        private static bool DiagonalControl(string v, int i, int j, string[,] matrix)
        {
            bool diagonal = false;
            bool antidiagonal = false;
            if (i == j) // sono sulla diagonale 
            {
                diagonal = true;
                for (int k = 0; k < matrix.GetLength(0); k++)
                {
                    if (matrix[k, k] == v) diagonal = diagonal && true; // rimane vera solo se tutta la diagonale è uguale a v
                    else diagonal = diagonal && false;
                }
            }
            if (i + j == 2) // sull'antidiagonale la somma degli indici è 2
            {
                antidiagonal = true;
                for (int k = 0; k < matrix.GetLength(0); k++)
                {
                    if (matrix[k, matrix.GetLength(0) - 1 - k] == v) antidiagonal = antidiagonal && true;
                    else antidiagonal = antidiagonal && false;
                }
            }

            return (diagonal || antidiagonal); // ritorna vero se una delle due è vera
        }

        private static bool ColumnControl(string v,  int j, string[,] matrix) // funziona come RowControl
        {
            bool isEqual = true;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, j] == v) isEqual = isEqual && true;
                else isEqual = isEqual && false;
            }
            return isEqual;
        }

        private static bool RowControl(string v, int i, string[,] matrix)
        { //restituisce true se v è vincitore lungo la riga i

            bool isEqual = true;
            for (int j = 0; j < matrix.GetLength(1); j++) // se sto controllando la riga i-esima scorrono le colonne
            {
                if (matrix[i, j] == v) isEqual = isEqual && true; // se lo è in tutta la riga allora rimane vero, altrimenti diventa falso
                else isEqual = isEqual && false;
            }
            return isEqual;
        }
       
       

       
       
        #region "text changed"
        private void txt_00_TextChanged(object sender, EventArgs e)
        {
            //this.label1.Text = "Coordinate [0,0]";
            //switch (lastMove)
            //{
            //    case Moves.X: // X è B
            //        if (this.txt_00.Text.ToUpper() == "X")
            //        {
            //            this.txt_00.Text = "";
            //            this.label1.Text = "E' il turno di B"; // se ho già messo X
            //        }
            //        else if (this.txt_00.Text.ToUpper() == "O") // mossa giusta
            //        {
            //            lastMove = Moves.O;
            //            this.txt_00.Text = this.txt_00.Text.ToUpper();
            //            this.txt_00.Enabled = false;
            //        }
            //        else
            //        {
            //            this.txt_00.Text = "";
            //            this.label1.Text = "Valori possibili sono 'X' e 'O'"; //non disabilito casella
            //        }
            //        break;
               
                   
            
            
            //    case Moves.O:
            //        if (this.txt_00.Text.ToUpper() == "X")
            //        {
            //            lastMove = Moves.X;
            //            this.txt_00.Text = this.txt_00.Text.ToUpper();
            //            this.txt_00.Enabled = false;
            //        }
            //        else if (this.txt_00.Text.ToUpper() == "O")
            //        {
                       
            //            this.txt_00.Text = "";
            //            this.label1.Text = "E' il turno di A";
            //        }
            //        else
            //        {
            //            this.txt_00.Text = "";
            //            this.label1.Text = "Valori possibili sono 'X' e 'O'";
            //        }
            //        break;
            //    case Moves.NoMoveYet: // prima mossa puo accettare sia x che o

            //        if (this.txt_00.Text.ToUpper() == "X")
            //        {
            //            lastMove = Moves.X;
            //            this.txt_00.Text = this.txt_00.Text.ToUpper();
            //            this.txt_00.Enabled = false;
            //        }
            //        else if (this.txt_00.Text.ToUpper() == "O")
            //        {
            //            lastMove = Moves.O;
            //            this.txt_00.Text = this.txt_00.Text.ToUpper();
            //            this.txt_00.Enabled = false;
            //        }
            //        else
            //        {
            //            this.txt_00.Text = "";
            //            this.label1.Text = "Valori possibili sono 'X' e 'O'";
            //        }
            //        break;

            //    default: // se le 3 precedenti non si verificano
            //        break;
            //}
            


        }

        
        private void txt_01_TextChanged(object sender, EventArgs e)
        {
            //switch (lastMove)
            //{
            //    case Moves.X:
            //        if (this.txt_01.Text.ToUpper() == "X")
            //        {
            //            this.txt_01.Text = "";
            //            this.label1.Text = "E' il turno di B";
            //        }
            //        else if (this.txt_01.Text.ToUpper() == "O")
            //        {
            //            lastMove = Moves.O;
            //            this.txt_01.Text = this.txt_01.Text.ToUpper();
            //            this.txt_01.Enabled = false;
            //        }
            //        else
            //        {
            //            this.txt_01.Text = "";
            //            this.label1.Text = "Valori possibili sono 'X' e 'O' ";
            //        }
            //        break;
            //    case Moves.O:
            //        if (this.txt_01.Text.ToUpper() == "X")
            //        {
            //            lastMove = Moves.X;
            //            this.txt_01.Text = this.txt_01.Text.ToUpper();
            //            this.txt_01.Enabled = false;
            //        }
            //        else if (this.txt_01.Text.ToUpper() == "O")
            //        {
            //            this.txt_01.Text = "";
            //            this.label1.Text = "E' il turno di A";
            //        }
            //        else
            //        {
            //            this.txt_01.Text = "";
            //            this.label1.Text = "Valori possibili sono 'X' e 'O' ";
            //        }
            //        break;
            //    case Moves.NoMoveYet:
            //        if (this.txt_01.Text.ToUpper() == "X")
            //        {
            //            lastMove = Moves.X;
            //            this.txt_01.Text = this.txt_01.Text.ToUpper();
            //            this.txt_01.Enabled = false;
            //        }
            //        else if (this.txt_01.Text.ToUpper() == "O")
            //        {
            //            lastMove = Moves.O;
            //            this.txt_01.Text = this.txt_01.Text.ToUpper();
            //            this.txt_01.Enabled = false;
            //        }
            //        else
            //        {
            //            this.txt_01.Text = "";
            //            this.label1.Text = "Valori possibili sono 'X' e 'O' ";
            //        }
            //        break;
            //    default:
            //        break;
            //}
        }

        private void txt_02_TextChanged(object sender, EventArgs e)
        {
    
        }

        private void txt_10_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txt_11_TextChanged(object sender, EventArgs e)
        {
        }

        private void txt_12_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txt_20_TextChanged(object sender, EventArgs e)
        {
        }

        private void txt_21_TextChanged(object sender, EventArgs e)
        {
       
        }

        private void txt_22_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
    #endregion

}

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
        #region "txt_00
        private void txt_00_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            txt_00_IsCorrect = false;
            if(Control.IsKeyLocked(Keys.CapsLock)) // ho premuto caps lock
            {  
            // determine if i am insertin x or o
                if(e.KeyCode == Keys.O || e.KeyCode==Keys.X)
                 {
                    txt_00_IsCorrect = true;
                 }
            }   
            else if (Control.ModifierKeys == Keys.Shift) // ho premuto shift
            {
                // determine if i am insertin x or o
                if (e.KeyCode == Keys.O || e.KeyCode == Keys.X)
                {
                    txt_00_IsCorrect = true; // dò il via alla gestione del contenuto della casella se questo è true
                }
            }
            else
            {
                this.label1.Text = "I valori possibili sono solo X e O";
                e.Handled = true; // gestisce direttamente lui
            }
        }
        // key press gestisce il controllo del se è giusto quello che ho inserito rispetto a quello che volevo fare
        private void txt_00_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if(txt_00_IsCorrect==true) // quindi se scrivo un carattere giusto ok, altrimeenti lo gestisco già qui (non me lo scrive)
            {
                switch (lastMove)
                {
                    case Moves.X: // X è B che ha appena mosso
                        if (e.KeyChar == 88)
                        {

                            this.label1.Text = "E' il turno di A"; // se ho già messo X
                            e.Handled = true; // dopo che mi sono accorto che è il turno di B 
                        }
                        else
                        {
                            this.label1.Text = "";
                           
                            lastMove = Moves.O;
                            Tris[0, 0] = "O";
                            this.txt_00.Text = "O";
                            this.txt_00.Enabled = false;
                            if (IsWinner(Tris, "O"))// una volta che ho giocato verifico se ha vinto 
                            {
                                this.label1.Text = "A is winner";
                                this.txt_01.Enabled = false;
                                this.txt_02.Enabled = false;
                                this.txt_10.Enabled = false;
                                this.txt_11.Enabled = false;
                                this.txt_12.Enabled = false;
                                this.txt_20.Enabled = false;
                                this.txt_21.Enabled = false;
                                this.txt_22.Enabled = false;
                            }
                            
                                if (!IsWinner(Tris, "O") && !IsWinner(Tris, "X") &&
                                  (txt_00.Enabled == false) && (txt_01.Enabled == false) &&
                                 (txt_02.Enabled == false) && (txt_11.Enabled == false) &&
                                 (txt_10.Enabled == false) && (txt_12.Enabled == false) &&
                                 (txt_20.Enabled == false) && (txt_21.Enabled == false) &&
                                  (txt_22.Enabled == false))
                                    this.label1.Text = "IT'S A TIE!";
                            


                        }
                        
                        break;




                    case Moves.O:
                        if (e.KeyChar== 88)
                        {
                            this.label1.Text = "";
                           
                            lastMove = Moves.X;
                            Tris[0, 0] = "X";
                            this.txt_00.Text = "X";
                            this.txt_00.Enabled = false;
                            if (IsWinner(Tris, "X"))// una volta che ho giocato verifico se ha vinto 
                            {
                                this.label1.Text = "B is winner";
                                this.txt_01.Enabled = false;
                                this.txt_02.Enabled = false;
                                this.txt_10.Enabled = false;
                                this.txt_11.Enabled = false;
                                this.txt_12.Enabled = false;
                                this.txt_20.Enabled = false;
                                this.txt_21.Enabled = false;
                                this.txt_22.Enabled = false;
                            }
                            if (!IsWinner(Tris, "O") && !IsWinner(Tris, "X") &&
                                  (txt_00.Enabled == false) && (txt_01.Enabled == false) &&
                                 (txt_02.Enabled == false) && (txt_11.Enabled == false) &&
                                 (txt_10.Enabled == false) && (txt_12.Enabled == false) &&
                                 (txt_20.Enabled == false) && (txt_21.Enabled == false) &&
                                  (txt_22.Enabled == false))
                                this.label1.Text = "IT'S A TIE!";
                        }
                        else
                        {

                            
                            this.label1.Text = "E' il turno di B";
                            e.Handled = true;
                        }
                       
                        break;
                    case Moves.NoMoveYet: // prima mossa puo accettare sia x che o

                        if (e.KeyChar == 88)
                        {
                            lastMove = Moves.X;
                            Tris[0, 0] = "X";
                            this.txt_00.Enabled = false;

                        }
                        else 
                        {
                            lastMove = Moves.O;
                            Tris[0, 0] = "O";
                            this.txt_00.Enabled = false;
                        }
                        
                        break;

                    default: // se le 3 precedenti non si verificano
                        break;
                }

                // gestisco tutto nel key press mettendo lo switch case qui 
                
            }
            else
            { e.Handled = true; }
        }

        
        #endregion"

        #region "txt_01"
        private void txt_01_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            txt_01_IsCorrect = false;
            if (Control.IsKeyLocked(Keys.CapsLock)) // ho premuto caps lock
            {
                // determine if i am insertin x or o
                if (e.KeyCode == Keys.O || e.KeyCode == Keys.X)
                {
                    txt_01_IsCorrect = true;
                }
            }
            else if (Control.ModifierKeys == Keys.Shift) // ho premuto shift
            {
                // determine if i am insertin x or o
                if (e.KeyCode == Keys.O || e.KeyCode == Keys.X)
                {
                    txt_01_IsCorrect = true; // dò il via alla gestione del contenuto della casella se questo è true
                }
            }
            else
            {
                this.label1.Text = "I valori possibili sono solo X e O";
                e.Handled = true; // gestisce direttamente lui
            }
        }
        // key press gestisce il controllo del se è giusto quello che ho inserito rispetto a quello che volevo fare
        private void txt_01_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (txt_01_IsCorrect == true) // quindi se scrivo un carattere giusto ok, altrimeenti lo gestisco già qui (non me lo scrive)
            {
                switch (lastMove)
                {
                    case Moves.X: // X è B che ha appena mosso
                        if (e.KeyChar == 88)
                        {

                            this.label1.Text = "E' il turno di A"; // se ho già messo X
                            e.Handled = true; // dopo che mi sono accorto che è il turno di B 
                        }
                        else
                        {
                            this.label1.Text = "";
                            Tris[0, 1] = "O";
                            lastMove = Moves.O;
                            //this.txt_01.Text = "O";
                            this.txt_01.Enabled = false;
                            if (IsWinner(Tris, "O"))// una volta che ho giocato verifico se ha vinto 
                            {
                                this.label1.Text = "A is winner";
                                this.txt_00.Enabled = false;
                                this.txt_02.Enabled = false;
                                this.txt_10.Enabled = false;
                                this.txt_11.Enabled = false;
                                this.txt_12.Enabled = false;
                                this.txt_20.Enabled = false;
                                this.txt_21.Enabled = false;
                                this.txt_22.Enabled = false;
                            }
                            if (!IsWinner(Tris, "O") && !IsWinner(Tris, "X") &&
                                  (txt_00.Enabled == false) && (txt_01.Enabled == false) &&
                                 (txt_02.Enabled == false) && (txt_11.Enabled == false) &&
                                 (txt_10.Enabled == false) && (txt_12.Enabled == false) &&
                                 (txt_20.Enabled == false) && (txt_21.Enabled == false) &&
                                  (txt_22.Enabled == false))
                                this.label1.Text = "IT'S A TIE!";
                        }

                        break;




                    case Moves.O:
                        if (e.KeyChar == 88)
                        {
                            this.label1.Text = "";
                            Tris[0, 1] = "X";
                            lastMove = Moves.X;
                          //  this.txt_01.Text = "X";
                            this.txt_01.Enabled = false;
                            if (IsWinner(Tris, "X"))// una volta che ho giocato verifico se ha vinto 
                            {
                                this.label1.Text = "B is winner";
                                this.txt_00.Enabled = false;
                                this.txt_02.Enabled = false;
                                this.txt_10.Enabled = false;
                                this.txt_11.Enabled = false;
                                this.txt_12.Enabled = false;
                                this.txt_20.Enabled = false;
                                this.txt_21.Enabled = false;
                                this.txt_22.Enabled = false;
                            }
                            if (!IsWinner(Tris, "O") && !IsWinner(Tris, "X") &&
                                  (txt_00.Enabled == false) && (txt_01.Enabled == false) &&
                                 (txt_02.Enabled == false) && (txt_11.Enabled == false) &&
                                 (txt_10.Enabled == false) && (txt_12.Enabled == false) &&
                                 (txt_20.Enabled == false) && (txt_21.Enabled == false) &&
                                  (txt_22.Enabled == false))
                                this.label1.Text = "IT'S A TIE!";
                        }
                        else
                        {


                            this.label1.Text = "E' il turno di B";
                            e.Handled = true;
                        }

                        break;
                    case Moves.NoMoveYet: // prima mossa puo accettare sia x che o

                        if (e.KeyChar == 88)
                        {
                            lastMove = Moves.X;
                            Tris[0, 1] = "X";
                            this.txt_01.Enabled = false;

                        }
                        else
                        {
                            lastMove = Moves.O;
                            Tris[0, 1] = "O";
                            this.txt_01.Enabled = false;
                        }

                        break;

                    default: // se le 3 precedenti non si verificano
                        break;
                }

                // gestisco tutto nel key press mettendo lo switch case qui 

            }
            else
            { e.Handled = true; }
        }


        #endregion

        #region "txt_02"
        private void txt_02_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            txt_02_IsCorrect = false;
            if (Control.IsKeyLocked(Keys.CapsLock)) // ho premuto caps lock
            {
                // determine if i am insertin x or o
                if (e.KeyCode == Keys.O || e.KeyCode == Keys.X)
                {
                    txt_02_IsCorrect = true;
                }
            }
            else if (Control.ModifierKeys == Keys.Shift) // ho premuto shift
            {
                // determine if i am insertin x or o
                if (e.KeyCode == Keys.O || e.KeyCode == Keys.X)
                {
                    txt_02_IsCorrect = true; // dò il via alla gestione del contenuto della casella se questo è true
                }
            }
            else
            {
                this.label1.Text = "I valori possibili sono solo X e O";
                e.Handled = true; // gestisce direttamente lui
            }
        }
        // key press gestisce il controllo del se è giusto quello che ho inserito rispetto a quello che volevo fare
        private void txt_02_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (txt_02_IsCorrect == true) // quindi se scrivo un carattere giusto ok, altrimeenti lo gestisco già qui (non me lo scrive)
            {
                switch (lastMove)
                {
                    case Moves.X: // X è B che ha appena mosso
                        if (e.KeyChar == 88)
                        {

                            this.label1.Text = "E' il turno di A"; // se ho già messo X
                            e.Handled = true; // dopo che mi sono accorto che è il turno di B 
                        }
                        else
                        {
                            this.label1.Text = "";
                            Tris[0, 2] = "O";
                            lastMove = Moves.O;
                           // this.txt_02.Text = "O";
                            this.txt_02.Enabled = false;
                            if (IsWinner(Tris, "O"))// una volta che ho giocato verifico se ha vinto 
                            {
                                this.label1.Text = "A is winner";
                                this.txt_01.Enabled = false;
                                this.txt_00.Enabled = false;
                                this.txt_10.Enabled = false;
                                this.txt_11.Enabled = false;
                                this.txt_12.Enabled = false;
                                this.txt_20.Enabled = false;
                                this.txt_21.Enabled = false;
                                this.txt_22.Enabled = false;
                            }
                            if (!IsWinner(Tris, "O") && !IsWinner(Tris, "X") &&
                                  (txt_00.Enabled == false) && (txt_01.Enabled == false) &&
                                 (txt_02.Enabled == false) && (txt_11.Enabled == false) &&
                                 (txt_10.Enabled == false) && (txt_12.Enabled == false) &&
                                 (txt_20.Enabled == false) && (txt_21.Enabled == false) &&
                                  (txt_22.Enabled == false))
                                this.label1.Text = "IT'S A TIE!";
                        }

                        break;




                    case Moves.O:
                        if (e.KeyChar == 88)
                        {

                            this.label1.Text = "";
                            Tris[0, 2] = "X";
                            lastMove = Moves.X;
                         //   this.txt_02.Text = "X";
                            this.txt_02.Enabled = false;
                            if (IsWinner(Tris, "X"))// una volta che ho giocato verifico se ha vinto 
                            {
                                this.label1.Text = "B is winner";
                                this.txt_01.Enabled = false;
                                this.txt_00.Enabled = false;
                                this.txt_10.Enabled = false;
                                this.txt_11.Enabled = false;
                                this.txt_12.Enabled = false;
                                this.txt_20.Enabled = false;
                                this.txt_21.Enabled = false;
                                this.txt_22.Enabled = false;
                            }
                            if (!IsWinner(Tris, "O") && !IsWinner(Tris, "X") &&
                                  (txt_00.Enabled == false) && (txt_01.Enabled == false) &&
                                 (txt_02.Enabled == false) && (txt_11.Enabled == false) &&
                                 (txt_10.Enabled == false) && (txt_12.Enabled == false) &&
                                 (txt_20.Enabled == false) && (txt_21.Enabled == false) &&
                                  (txt_22.Enabled == false))
                                this.label1.Text = "IT'S A TIE!";
                        }
                        else
                        {


                            this.label1.Text = "E' il turno di B";
                            e.Handled = true;
                        }

                        break;
                    case Moves.NoMoveYet: // prima mossa puo accettare sia x che o

                        if (e.KeyChar == 88)
                        {
                            lastMove = Moves.X;
                            Tris[0, 2] = "X";
                            this.txt_02.Enabled = false;

                        }
                        else
                        {
                            lastMove = Moves.O;
                            Tris[0, 2] = "O";
                            this.txt_02.Enabled = false;
                        }

                        break;

                    default: // se le 3 precedenti non si verificano
                        break;
                }

                // gestisco tutto nel key press mettendo lo switch case qui 

            }
            else
            { e.Handled = true; }
        }

        #endregion

        #region "txt_10" 
        private void txt_10_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            txt_10_IsCorrect = false;
            if (Control.IsKeyLocked(Keys.CapsLock)) // ho premuto caps lock
            {
                // determine if i am insertin x or o
                if (e.KeyCode == Keys.O || e.KeyCode == Keys.X)
                {
                    txt_10_IsCorrect = true;
                }
            }
            else if (Control.ModifierKeys == Keys.Shift) // ho premuto shift
            {
                // determine if i am insertin x or o
                if (e.KeyCode == Keys.O || e.KeyCode == Keys.X)
                {
                    txt_10_IsCorrect = true; // dò il via alla gestione del contenuto della casella se questo è true
                }
            }
            else
            {
                this.label1.Text = "I valori possibili sono solo X e O";
                e.Handled = true; // gestisce direttamente lui
            }
        }
        // key press gestisce il controllo del se è giusto quello che ho inserito rispetto a quello che volevo fare
        private void txt_10_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (txt_10_IsCorrect == true) // quindi se scrivo un carattere giusto ok, altrimeenti lo gestisco già qui (non me lo scrive)
            {
                switch (lastMove)
                {
                    case Moves.X: // X è B che ha appena mosso
                        if (e.KeyChar == 88)
                        {

                            this.label1.Text = "E' il turno di A"; // se ho già messo X
                            e.Handled = true; // dopo che mi sono accorto che è il turno di B 
                        }
                        else
                        {
                            this.label1.Text = "";
                            Tris[1, 0] = "O";
                            lastMove = Moves.O;
                          //  this.txt_10.Text = "O";
                            this.txt_10.Enabled = false;
                            if (IsWinner(Tris, "O"))// una volta che ho giocato verifico se ha vinto 
                            {
                                this.label1.Text = "A is winner";
                                this.txt_00.Enabled = false;
                                this.txt_01.Enabled = false;
                                this.txt_02.Enabled = false;
                                this.txt_11.Enabled = false;
                                this.txt_12.Enabled = false;
                                this.txt_20.Enabled = false;
                                this.txt_21.Enabled = false;
                                this.txt_22.Enabled = false;
                            }
                            if (!IsWinner(Tris, "O") && !IsWinner(Tris, "X") &&
                                  (txt_00.Enabled == false) && (txt_01.Enabled == false) &&
                                 (txt_02.Enabled == false) && (txt_11.Enabled == false) &&
                                 (txt_10.Enabled == false) && (txt_12.Enabled == false) &&
                                 (txt_20.Enabled == false) && (txt_21.Enabled == false) &&
                                  (txt_22.Enabled == false))
                                this.label1.Text = "IT'S A TIE!";
                        }

                        break;




                    case Moves.O:
                        if (e.KeyChar == 88)
                        {

                            this.label1.Text = "";
                            Tris[1, 0] = "X";
                            lastMove = Moves.X;
                           // this.txt_10.Text = "X";
                            this.txt_10.Enabled = false;
                            if (IsWinner(Tris, "X"))// una volta che ho giocato verifico se ha vinto 
                            {
                                this.label1.Text = "B is winner";
                                this.txt_00.Enabled = false;
                                this.txt_01.Enabled = false;
                                this.txt_02.Enabled = false;
                                this.txt_11.Enabled = false;
                                this.txt_12.Enabled = false;
                                this.txt_20.Enabled = false;
                                this.txt_21.Enabled = false;
                                this.txt_22.Enabled = false;
                            }
                            if (!IsWinner(Tris, "O") && !IsWinner(Tris, "X") &&
                                  (txt_00.Enabled == false) && (txt_01.Enabled == false) &&
                                 (txt_02.Enabled == false) && (txt_11.Enabled == false) &&
                                 (txt_10.Enabled == false) && (txt_12.Enabled == false) &&
                                 (txt_20.Enabled == false) && (txt_21.Enabled == false) &&
                                  (txt_22.Enabled == false))
                                this.label1.Text = "IT'S A TIE!";
                        }
                        else
                        {


                            this.label1.Text = "E' il turno di B";
                            e.Handled = true;
                        }

                        break;
                    case Moves.NoMoveYet: // prima mossa puo accettare sia x che o

                        if (e.KeyChar == 88)
                        {
                            lastMove = Moves.X;
                            Tris[1, 0] = "X";
                            this.txt_10.Enabled = false;

                        }
                        else
                        {
                            lastMove = Moves.O;
                            Tris[1, 0] = "O";
                            this.txt_10.Enabled = false;
                        }

                        break;

                    default: // se le 3 precedenti non si verificano
                        break;
                }

                // gestisco tutto nel key press mettendo lo switch case qui 

            }
            else
            { e.Handled = true; }
        }

        #endregion

        #region "txt_11" 
        private void txt_11_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            txt_11_IsCorrect = false;
            if (Control.IsKeyLocked(Keys.CapsLock)) // ho premuto caps lock
            {
                // determine if i am insertin x or o
                if (e.KeyCode == Keys.O || e.KeyCode == Keys.X)
                {
                    txt_11_IsCorrect = true;
                }
            }
            else if (Control.ModifierKeys == Keys.Shift) // ho premuto shift
            {
                // determine if i am insertin x or o
                if (e.KeyCode == Keys.O || e.KeyCode == Keys.X)
                {
                    txt_11_IsCorrect = true; // dò il via alla gestione del contenuto della casella se questo è true
                }
            }
            else
            {
                this.label1.Text = "I valori possibili sono solo X e O";
                e.Handled = true; // gestisce direttamente lui
            }
        }
        // key press gestisce il controllo del se è giusto quello che ho inserito rispetto a quello che volevo fare
        private void txt_11_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (txt_11_IsCorrect == true) // quindi se scrivo un carattere giusto ok, altrimeenti lo gestisco già qui (non me lo scrive)
            {
                switch (lastMove)
                {
                    case Moves.X: // X è B che ha appena mosso
                        if (e.KeyChar == 88)
                        {

                            this.label1.Text = "E' il turno di A"; // se ho già messo X
                            e.Handled = true; // dopo che mi sono accorto che è il turno di B 
                        }
                        else
                        {
                            this.label1.Text = "";
                            Tris[1, 1] = "O";
                            lastMove = Moves.O;
                           // this.txt_11.Text = "O";
                            this.txt_11.Enabled = false;
                            if (IsWinner(Tris, "O"))// una volta che ho giocato verifico se ha vinto 
                            {
                                this.label1.Text = "A is winner";
                                this.txt_00.Enabled = false;
                                this.txt_01.Enabled = false;
                                this.txt_02.Enabled = false;
                                this.txt_10.Enabled = false;
                                this.txt_12.Enabled = false;
                                this.txt_20.Enabled = false;
                                this.txt_21.Enabled = false;
                                this.txt_22.Enabled = false;
                            }
                            if (!IsWinner(Tris, "O") && !IsWinner(Tris, "X") &&
                                  (txt_00.Enabled == false) && (txt_01.Enabled == false) &&
                                 (txt_02.Enabled == false) && (txt_11.Enabled == false) &&
                                 (txt_10.Enabled == false) && (txt_12.Enabled == false) &&
                                 (txt_20.Enabled == false) && (txt_21.Enabled == false) &&
                                  (txt_22.Enabled == false))
                                this.label1.Text = "IT'S A TIE!";
                        }

                        break;




                    case Moves.O:
                        if (e.KeyChar == 88)
                        {

                            this.label1.Text = "";
                            Tris[1, 1] = "X";
                            lastMove = Moves.X;
                           // this.txt_11.Text = "X";
                            this.txt_11.Enabled = false;
                            if (IsWinner(Tris, "X"))// una volta che ho giocato verifico se ha vinto 
                            {
                                this.label1.Text = "B is winner";
                                this.txt_00.Enabled = false;
                                this.txt_01.Enabled = false;
                                this.txt_02.Enabled = false;
                                this.txt_10.Enabled = false;
                                this.txt_12.Enabled = false;
                                this.txt_20.Enabled = false;
                                this.txt_21.Enabled = false;
                                this.txt_22.Enabled = false;
                            }
                            if (!IsWinner(Tris, "O") && !IsWinner(Tris, "X") &&
                                  (txt_00.Enabled == false) && (txt_01.Enabled == false) &&
                                 (txt_02.Enabled == false) && (txt_11.Enabled == false) &&
                                 (txt_10.Enabled == false) && (txt_12.Enabled == false) &&
                                 (txt_20.Enabled == false) && (txt_21.Enabled == false) &&
                                  (txt_22.Enabled == false))
                                this.label1.Text = "IT'S A TIE!";
                        }
                        else
                        {


                            this.label1.Text = "E' il turno di B";
                            e.Handled = true;
                        }

                        break;
                    case Moves.NoMoveYet: // prima mossa puo accettare sia x che o

                        if (e.KeyChar == 88)
                        {
                            lastMove = Moves.X;
                            Tris[1, 1] = "X";
                            this.txt_11.Enabled = false;

                        }
                        else
                        {
                            lastMove = Moves.O;
                            Tris[1, 1] = "O";
                            this.txt_11.Enabled = false;
                        }

                        break;

                    default: // se le 3 precedenti non si verificano
                        break;
                }

                // gestisco tutto nel key press mettendo lo switch case qui 

            }
            else
            { e.Handled = true; }
        }

        #endregion

        #region "txt_12" 
        private void txt_12_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            txt_12_IsCorrect = false;
            if (Control.IsKeyLocked(Keys.CapsLock)) // ho premuto caps lock
            {
                // determine if i am insertin x or o
                if (e.KeyCode == Keys.O || e.KeyCode == Keys.X)
                {
                    txt_12_IsCorrect = true;
                }
            }
            else if (Control.ModifierKeys == Keys.Shift) // ho premuto shift
            {
                // determine if i am insertin x or o
                if (e.KeyCode == Keys.O || e.KeyCode == Keys.X)
                {
                    txt_12_IsCorrect = true; // dò il via alla gestione del contenuto della casella se questo è true
                }
            }
            else
            {
                this.label1.Text = "I valori possibili sono solo X e O";
                e.Handled = true; // gestisce direttamente lui
            }
        }
        // key press gestisce il controllo del se è giusto quello che ho inserito rispetto a quello che volevo fare
        private void txt_12_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (txt_12_IsCorrect == true) // quindi se scrivo un carattere giusto ok, altrimeenti lo gestisco già qui (non me lo scrive)
            {
                switch (lastMove)
                {
                    case Moves.X: // X è B che ha appena mosso
                        if (e.KeyChar == 88)
                        {

                            this.label1.Text = "E' il turno di A"; // se ho già messo X
                            e.Handled = true; // dopo che mi sono accorto che è il turno di B 
                        }
                        else
                        {
                            this.label1.Text = "";
                            Tris[1, 2] = "O";
                            lastMove = Moves.O;
                          //  this.txt_12.Text = "O";
                            this.txt_12.Enabled = false;
                            if (IsWinner(Tris, "O"))// una volta che ho giocato verifico se ha vinto 
                            {
                                this.label1.Text = "A is winner";
                                this.txt_00.Enabled = false;
                                this.txt_01.Enabled = false;
                                this.txt_02.Enabled = false;
                                this.txt_10.Enabled = false;
                                this.txt_11.Enabled = false;
                                this.txt_20.Enabled = false;
                                this.txt_21.Enabled = false;
                                this.txt_22.Enabled = false;
                            }
                            if (!IsWinner(Tris, "O") && !IsWinner(Tris, "X") &&
                                  (txt_00.Enabled == false) && (txt_01.Enabled == false) &&
                                 (txt_02.Enabled == false) && (txt_11.Enabled == false) &&
                                 (txt_10.Enabled == false) && (txt_12.Enabled == false) &&
                                 (txt_20.Enabled == false) && (txt_21.Enabled == false) &&
                                  (txt_22.Enabled == false))
                                this.label1.Text = "IT'S A TIE!";
                        }

                        break;




                    case Moves.O:
                        if (e.KeyChar == 88)
                        {

                            this.label1.Text = "";
                            Tris[1, 2] = "X";
                            lastMove = Moves.X;
                            //this.txt_12.Text = "X";
                            this.txt_12.Enabled = false;
                            if (IsWinner(Tris, "X"))// una volta che ho giocato verifico se ha vinto 
                            {
                                this.label1.Text = "B is winner";
                                this.txt_00.Enabled = false;
                                this.txt_01.Enabled = false;
                                this.txt_02.Enabled = false;
                                this.txt_10.Enabled = false;
                                this.txt_11.Enabled = false;
                                this.txt_20.Enabled = false;
                                this.txt_21.Enabled = false;
                                this.txt_22.Enabled = false;
                            }
                            if (!IsWinner(Tris, "O") && !IsWinner(Tris, "X") &&
                                  (txt_00.Enabled == false) && (txt_01.Enabled == false) &&
                                 (txt_02.Enabled == false) && (txt_11.Enabled == false) &&
                                 (txt_10.Enabled == false) && (txt_12.Enabled == false) &&
                                 (txt_20.Enabled == false) && (txt_21.Enabled == false) &&
                                  (txt_22.Enabled == false))
                                this.label1.Text = "IT'S A TIE!";
                        }
                        else
                        {


                            this.label1.Text = "E' il turno di B";
                            e.Handled = true;
                        }

                        break;
                    case Moves.NoMoveYet: // prima mossa puo accettare sia x che o

                        if (e.KeyChar == 88)
                        {
                            lastMove = Moves.X;
                            Tris[1, 2] = "X";
                            this.txt_12.Enabled = false;

                        }
                        else
                        {
                            lastMove = Moves.O;
                            Tris[1, 2] = "O";
                            this.txt_12.Enabled = false;
                        }

                        break;

                    default: // se le 3 precedenti non si verificano
                        break;
                }

                // gestisco tutto nel key press mettendo lo switch case qui 

            }
            else
            { e.Handled = true; }
        }

        #endregion

        #region "txt_20" 
        private void txt_20_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            txt_20_IsCorrect = false;
            if (Control.IsKeyLocked(Keys.CapsLock)) // ho premuto caps lock
            {
                // determine if i am insertin x or o
                if (e.KeyCode == Keys.O || e.KeyCode == Keys.X)
                {
                    txt_20_IsCorrect = true;
                }
            }
            else if (Control.ModifierKeys == Keys.Shift) // ho premuto shift
            {
                // determine if i am insertin x or o
                if (e.KeyCode == Keys.O || e.KeyCode == Keys.X)
                {
                    txt_20_IsCorrect = true; // dò il via alla gestione del contenuto della casella se questo è true
                }
            }
            else
            {
                this.label1.Text = "I valori possibili sono solo X e O";
                e.Handled = true; // gestisce direttamente lui
            }
        }
        // key press gestisce il controllo del se è giusto quello che ho inserito rispetto a quello che volevo fare
        private void txt_20_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (txt_20_IsCorrect == true) // quindi se scrivo un carattere giusto ok, altrimeenti lo gestisco già qui (non me lo scrive)
            {
                switch (lastMove)
                {
                    case Moves.X: // X è B che ha appena mosso
                        if (e.KeyChar == 88)
                        {

                            this.label1.Text = "E' il turno di A"; // se ho già messo X
                            e.Handled = true; // dopo che mi sono accorto che è il turno di B 
                        }
                        else
                        {
                            this.label1.Text = "";
                            Tris[2, 0] = "O";
                            lastMove = Moves.O;
                        //    this.txt_20.Text = "O";
                            this.txt_20.Enabled = false;
                            if (IsWinner(Tris, "O"))// una volta che ho giocato verifico se ha vinto 
                            {
                                this.label1.Text = "A is winner";
                                this.txt_00.Enabled = false;
                                this.txt_01.Enabled = false;
                                this.txt_02.Enabled = false;
                                this.txt_10.Enabled = false;
                                this.txt_11.Enabled = false;
                                this.txt_12.Enabled = false;
                                this.txt_21.Enabled = false;
                                this.txt_22.Enabled = false;
                            }
                            if (!IsWinner(Tris, "O") && !IsWinner(Tris, "X") &&
                                  (txt_00.Enabled == false) && (txt_01.Enabled == false) &&
                                 (txt_02.Enabled == false) && (txt_11.Enabled == false) &&
                                 (txt_10.Enabled == false) && (txt_12.Enabled == false) &&
                                 (txt_20.Enabled == false) && (txt_21.Enabled == false) &&
                                  (txt_22.Enabled == false))
                                this.label1.Text = "IT'S A TIE!";
                        }

                        break;




                    case Moves.O:
                        if (e.KeyChar == 88)
                        {

                            this.label1.Text = "";
                            Tris[2, 0] = "X";
                            lastMove = Moves.X;
                         //   this.txt_20.Text = "X";
                            this.txt_20.Enabled = false;
                            if (IsWinner(Tris, "X"))// una volta che ho giocato verifico se ha vinto 
                            {
                                this.label1.Text = "B is winner";
                                this.txt_00.Enabled = false;
                                this.txt_01.Enabled = false;
                                this.txt_02.Enabled = false;
                                this.txt_10.Enabled = false;
                                this.txt_11.Enabled = false;
                                this.txt_12.Enabled = false;
                                this.txt_21.Enabled = false;
                                this.txt_22.Enabled = false;
                            }
                            if (!IsWinner(Tris, "O") && !IsWinner(Tris, "X") &&
                                  (txt_00.Enabled == false) && (txt_01.Enabled == false) &&
                                 (txt_02.Enabled == false) && (txt_11.Enabled == false) &&
                                 (txt_10.Enabled == false) && (txt_12.Enabled == false) &&
                                 (txt_20.Enabled == false) && (txt_21.Enabled == false) &&
                                  (txt_22.Enabled == false))
                                this.label1.Text = "IT'S A TIE!";
                        }
                        else
                        {


                            this.label1.Text = "E' il turno di B";
                            e.Handled = true;
                        }

                        break;
                    case Moves.NoMoveYet: // prima mossa puo accettare sia x che o

                        if (e.KeyChar == 88)
                        {
                            lastMove = Moves.X;

                            Tris[2, 0] = "X";
                            this.txt_20.Enabled = false;

                        }
                        else
                        {
                            lastMove = Moves.O;
                            Tris[2, 0] = "O";
                            this.txt_20.Enabled = false;
                        }

                        break;

                    default: // se le 3 precedenti non si verificano
                        break;
                }

                // gestisco tutto nel key press mettendo lo switch case qui 

            }
            else
            { e.Handled = true; }
        }

        #endregion

        #region "txt_21" 
        private void txt_21_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            txt_21_IsCorrect = false;
            if (Control.IsKeyLocked(Keys.CapsLock)) // ho premuto caps lock
            {
                // determine if i am insertin x or o
                if (e.KeyCode == Keys.O || e.KeyCode == Keys.X)
                {
                    txt_21_IsCorrect = true;
                }
            }
            else if (Control.ModifierKeys == Keys.Shift) // ho premuto shift
            {
                // determine if i am insertin x or o
                if (e.KeyCode == Keys.O || e.KeyCode == Keys.X)
                {
                    txt_21_IsCorrect = true; // dò il via alla gestione del contenuto della casella se questo è true
                }
            }
            else
            {
                this.label1.Text = "I valori possibili sono solo X e O";
                e.Handled = true; // gestisce direttamente lui
            }
        }
        // key press gestisce il controllo del se è giusto quello che ho inserito rispetto a quello che volevo fare
        private void txt_21_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (txt_21_IsCorrect == true) // quindi se scrivo un carattere giusto ok, altrimeenti lo gestisco già qui (non me lo scrive)
            {
                switch (lastMove)
                {
                    case Moves.X: // X è B che ha appena mosso
                        if (e.KeyChar == 88)
                        {

                            this.label1.Text = "E' il turno di A"; // se ho già messo X
                            e.Handled = true; // dopo che mi sono accorto che è il turno di B 
                        }
                        else
                        {
                            this.label1.Text = "";
                            Tris[2, 1] = "O";
                            lastMove = Moves.O;
                         //   this.txt_21.Text = "O";
                            this.txt_21.Enabled = false;
                            if (IsWinner(Tris, "O"))// una volta che ho giocato verifico se ha vinto 
                            {
                                this.label1.Text = "A is winner";
                                this.txt_00.Enabled = false;
                                this.txt_01.Enabled = false;
                                this.txt_02.Enabled = false;
                                this.txt_10.Enabled = false;
                                this.txt_11.Enabled = false;
                                this.txt_12.Enabled = false;
                                this.txt_20.Enabled = false;
                                this.txt_22.Enabled = false;
                            }
                            if (!IsWinner(Tris, "O") && !IsWinner(Tris, "X") &&
                                  (txt_00.Enabled == false) && (txt_01.Enabled == false) &&
                                 (txt_02.Enabled == false) && (txt_11.Enabled == false) &&
                                 (txt_10.Enabled == false) && (txt_12.Enabled == false) &&
                                 (txt_20.Enabled == false) && (txt_21.Enabled == false) &&
                                  (txt_22.Enabled == false))
                                this.label1.Text = "IT'S A TIE!";
                        }

                        break;




                    case Moves.O:
                        if (e.KeyChar == 88)
                        {

                            this.label1.Text = "";
                            Tris[2, 1] = "X";
                            lastMove = Moves.X;
                           // this.txt_21.Text = "X";
                            this.txt_21.Enabled = false;
                            if(IsWinner(Tris, "X"))// una volta che ho giocato verifico se ha vinto 
                            {
                                this.label1.Text = "B is winner";
                                this.txt_00.Enabled = false;
                                this.txt_01.Enabled = false;
                                this.txt_02.Enabled = false;
                                this.txt_10.Enabled = false;
                                this.txt_11.Enabled = false;
                                this.txt_12.Enabled = false;
                                this.txt_20.Enabled = false;
                                this.txt_22.Enabled = false;
                            }
                            if (!IsWinner(Tris, "O") && !IsWinner(Tris, "X") &&
                                  (txt_00.Enabled == false) && (txt_01.Enabled == false) &&
                                 (txt_02.Enabled == false) && (txt_11.Enabled == false) &&
                                 (txt_10.Enabled == false) && (txt_12.Enabled == false) &&
                                 (txt_20.Enabled == false) && (txt_21.Enabled == false) &&
                                  (txt_22.Enabled == false))
                                this.label1.Text = "IT'S A TIE!";
                        }
                        else
                        {


                            this.label1.Text = "E' il turno di B";
                            e.Handled = true;
                        }

                        break;
                    case Moves.NoMoveYet: // prima mossa puo accettare sia x che o

                        if (e.KeyChar == 88)
                        {
                            lastMove = Moves.X;
                            Tris[2, 1] = "X";
                            this.txt_21.Enabled = false;

                        }
                        else
                        {
                            lastMove = Moves.O;
                            Tris[2, 1] = "O";
                            this.txt_21.Enabled = false;
                        }

                        break;

                    default: // se le 3 precedenti non si verificano
                        break;
                }

                // gestisco tutto nel key press mettendo lo switch case qui 

            }
            else
            { e.Handled = true; }
        }

        #endregion

        #region "txt_22" 
        private void txt_22_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            txt_22_IsCorrect = false;
            if (Control.IsKeyLocked(Keys.CapsLock)) // ho premuto caps lock
            {
                // determine if i am insertin x or o
                if (e.KeyCode == Keys.O || e.KeyCode == Keys.X)
                {
                    txt_22_IsCorrect = true;
                }
            }
            else if (Control.ModifierKeys == Keys.Shift) // ho premuto shift
            {
                // determine if i am insertin x or o
                if (e.KeyCode == Keys.O || e.KeyCode == Keys.X)
                {
                    txt_22_IsCorrect = true; // dò il via alla gestione del contenuto della casella se questo è true
                }
            }
            else
            {
                this.label1.Text = "I valori possibili sono solo X e O";
                e.Handled = true; // gestisce direttamente lui
            }
        }
        // key press gestisce il controllo del se è giusto quello che ho inserito rispetto a quello che volevo fare
        private void txt_22_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (txt_22_IsCorrect == true) // quindi se scrivo un carattere giusto ok, altrimeenti lo gestisco già qui (non me lo scrive)
            {
                switch (lastMove)
                {
                    case Moves.X: // X è B che ha appena mosso
                        if (e.KeyChar == 88)
                        {

                            this.label1.Text = "E' il turno di A"; // se ho già messo X
                            e.Handled = true; // dopo che mi sono accorto che è il turno di B 
                        }
                        else
                        {
                            this.label1.Text = "";
                            Tris[2, 2] = "O";
                            lastMove = Moves.O;
                           // this.txt_22.Text = "O";
                            this.txt_22.Enabled = false;
                            if (IsWinner(Tris, "O"))// una volta che ho giocato verifico se ha vinto 
                            {
                                this.label1.Text = "A is winner";
                                this.txt_00.Enabled = false;
                                this.txt_01.Enabled = false;
                                this.txt_02.Enabled = false;
                                this.txt_10.Enabled = false;
                                this.txt_11.Enabled = false;
                                this.txt_12.Enabled = false;
                                this.txt_20.Enabled = false;
                                this.txt_21.Enabled = false;
                            }
                            if (!IsWinner(Tris, "O") && !IsWinner(Tris, "X") &&
                                  (txt_00.Enabled == false) && (txt_01.Enabled == false) &&
                                 (txt_02.Enabled == false) && (txt_11.Enabled == false) &&
                                 (txt_10.Enabled == false) && (txt_12.Enabled == false) &&
                                 (txt_20.Enabled == false) && (txt_21.Enabled == false) &&
                                  (txt_22.Enabled == false))
                                this.label1.Text = "IT'S A TIE!";
                        }

                        break;




                    case Moves.O:
                        if (e.KeyChar == 88)
                        {

                            this.label1.Text = "";
                            Tris[2, 2] = "X";
                            lastMove = Moves.X;
                           // this.txt_22.Text = "X";
                            this.txt_22.Enabled = false;
                            if (IsWinner(Tris, "X"))// una volta che ho giocato verifico se ha vinto 
                            {
                                this.label1.Text = "B is winner";
                                this.txt_00.Enabled = false;
                                this.txt_01.Enabled = false;
                                this.txt_02.Enabled = false;
                                this.txt_10.Enabled = false;
                                this.txt_11.Enabled = false;
                                this.txt_12.Enabled = false;
                                this.txt_20.Enabled = false;
                                this.txt_21.Enabled = false;
                            }
                            if (!IsWinner(Tris, "O") && !IsWinner(Tris, "X") &&
                                  (txt_00.Enabled == false) && (txt_01.Enabled == false) &&
                                 (txt_02.Enabled == false) && (txt_11.Enabled == false) &&
                                 (txt_10.Enabled == false) && (txt_12.Enabled == false) &&
                                 (txt_20.Enabled == false) && (txt_21.Enabled == false) &&
                                  (txt_22.Enabled == false))
                                this.label1.Text = "IT'S A TIE!";
                        }
                        else
                        {


                            this.label1.Text = "E' il turno di B";
                            e.Handled = true;
                        }

                        break;
                    case Moves.NoMoveYet: // prima mossa puo accettare sia x che o

                        if (e.KeyChar == 88)
                        {
                            lastMove = Moves.X;
                            Tris[2, 2] = "X";
                            this.txt_22.Enabled = false;

                        }
                        else
                        {
                            lastMove = Moves.O;
                            Tris[2, 2] = "O";
                            this.txt_22.Enabled = false;
                        }

                        break;

                    default: // se le 3 precedenti non si verificano
                        break;
                }

                // gestisco tutto nel key press mettendo lo switch case qui 

            }
            else
            { e.Handled = true; }
        }

        #endregion

       
       
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

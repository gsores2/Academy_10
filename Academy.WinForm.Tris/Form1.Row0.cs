using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Academy.WinForm.Tris
{
   partial class Form1
    {
     #region "txt_00
        private void txt_00_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e) 
            // non controlla il cambio nella casella di teso, perchè cosi facendo non potrei cancellare
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
                this.label1.Text = "Inserire solo X e O";
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
                        if (e.KeyChar == 88) // se provo a reinserire una Xx
                        {

                            this.label1.Text = "E' il turno di A"; // se ho già messo X
                            e.Handled = true; // dopo che mi sono accorto che è il turno di B 
                        }
                        else
                        {
                            this.label1.Text = "";
                           
                            lastMove = Moves.O; // se giusto muove A
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
                this.label1.Text = "Inserire solo X e O";
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
                this.label1.Text = "Inserire solo X e O";
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

    }
}

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
                this.label1.Text = "Inserire solo X e O";
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
                this.label1.Text = "Inserire solo X e O";
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
                this.label1.Text = "Inserire solo X e O";
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
    }
}

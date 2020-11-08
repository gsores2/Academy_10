namespace Academy.Bank
{
    partial class ManageCCForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_CC = new System.Windows.Forms.Label();
            this.btn_cls_manage = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_saldo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_versa = new System.Windows.Forms.Button();
            this.btn_preleva = new System.Windows.Forms.Button();
            this.txt_importo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txt_beneficiario = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_bonifico = new System.Windows.Forms.Button();
            this.txt_importo_bonifico = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txt_movimenti = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_CC
            // 
            this.lbl_CC.AutoSize = true;
            this.lbl_CC.Location = new System.Drawing.Point(320, 29);
            this.lbl_CC.Name = "lbl_CC";
            this.lbl_CC.Size = new System.Drawing.Size(0, 20);
            this.lbl_CC.TabIndex = 0;
            // 
            // btn_cls_manage
            // 
            this.btn_cls_manage.Location = new System.Drawing.Point(668, 12);
            this.btn_cls_manage.Name = "btn_cls_manage";
            this.btn_cls_manage.Size = new System.Drawing.Size(75, 47);
            this.btn_cls_manage.TabIndex = 1;
            this.btn_cls_manage.Text = "close";
            this.btn_cls_manage.UseVisualStyleBackColor = true;
            this.btn_cls_manage.Click += new System.EventHandler(this.btn_cls_manage_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Gestione Conto Corrente Numero: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Saldo:";
            // 
            // lbl_saldo
            // 
            this.lbl_saldo.AutoSize = true;
            this.lbl_saldo.Location = new System.Drawing.Point(119, 97);
            this.lbl_saldo.Name = "lbl_saldo";
            this.lbl_saldo.Size = new System.Drawing.Size(0, 20);
            this.lbl_saldo.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightCoral;
            this.panel1.Controls.Add(this.btn_versa);
            this.panel1.Controls.Add(this.btn_preleva);
            this.panel1.Controls.Add(this.txt_importo);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(46, 161);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(274, 165);
            this.panel1.TabIndex = 5;
            // 
            // btn_versa
            // 
            this.btn_versa.Location = new System.Drawing.Point(158, 104);
            this.btn_versa.Name = "btn_versa";
            this.btn_versa.Size = new System.Drawing.Size(89, 30);
            this.btn_versa.TabIndex = 3;
            this.btn_versa.Text = "Versa";
            this.btn_versa.UseVisualStyleBackColor = true;
            this.btn_versa.Click += new System.EventHandler(this.btn_versa_Click);
            // 
            // btn_preleva
            // 
            this.btn_preleva.Location = new System.Drawing.Point(26, 104);
            this.btn_preleva.Name = "btn_preleva";
            this.btn_preleva.Size = new System.Drawing.Size(97, 30);
            this.btn_preleva.TabIndex = 2;
            this.btn_preleva.Text = "Preleva";
            this.btn_preleva.UseVisualStyleBackColor = true;
            this.btn_preleva.Click += new System.EventHandler(this.btn_preleva_Click);
            // 
            // txt_importo
            // 
            this.txt_importo.Location = new System.Drawing.Point(104, 22);
            this.txt_importo.Name = "txt_importo";
            this.txt_importo.Size = new System.Drawing.Size(100, 26);
            this.txt_importo.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "importo:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SandyBrown;
            this.panel2.Controls.Add(this.txt_beneficiario);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.btn_bonifico);
            this.panel2.Controls.Add(this.txt_importo_bonifico);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(362, 161);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(272, 161);
            this.panel2.TabIndex = 6;
            // 
            // txt_beneficiario
            // 
            this.txt_beneficiario.Location = new System.Drawing.Point(109, 67);
            this.txt_beneficiario.Name = "txt_beneficiario";
            this.txt_beneficiario.Size = new System.Drawing.Size(100, 26);
            this.txt_beneficiario.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "beneficiario:";
            // 
            // btn_bonifico
            // 
            this.btn_bonifico.Location = new System.Drawing.Point(109, 101);
            this.btn_bonifico.Name = "btn_bonifico";
            this.btn_bonifico.Size = new System.Drawing.Size(75, 30);
            this.btn_bonifico.TabIndex = 4;
            this.btn_bonifico.Text = "Bonifica";
            this.btn_bonifico.UseVisualStyleBackColor = true;
            this.btn_bonifico.Click += new System.EventHandler(this.btn_bonifico_Click);
            // 
            // txt_importo_bonifico
            // 
            this.txt_importo_bonifico.Location = new System.Drawing.Point(84, 25);
            this.txt_importo_bonifico.Name = "txt_importo_bonifico";
            this.txt_importo_bonifico.Size = new System.Drawing.Size(100, 26);
            this.txt_importo_bonifico.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "importo:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.PaleGreen;
            this.panel3.Controls.Add(this.txt_movimenti);
            this.panel3.Location = new System.Drawing.Point(46, 373);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(662, 100);
            this.panel3.TabIndex = 7;
            // 
            // txt_movimenti
            // 
            this.txt_movimenti.AcceptsReturn = true;
            this.txt_movimenti.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txt_movimenti.Location = new System.Drawing.Point(0, 0);
            this.txt_movimenti.Multiline = true;
            this.txt_movimenti.Name = "txt_movimenti";
            this.txt_movimenti.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_movimenti.Size = new System.Drawing.Size(662, 100);
            this.txt_movimenti.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(45, 341);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "MOVIMENTI";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(358, 125);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 20);
            this.label7.TabIndex = 9;
            this.label7.Text = "BONIFICO";
            // 
            // ManageCCForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 485);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbl_saldo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_cls_manage);
            this.Controls.Add(this.lbl_CC);
            this.Name = "ManageCCForm";
            this.Text = "ManageCCForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_CC;
        private System.Windows.Forms.Button btn_cls_manage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_saldo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_versa;
        private System.Windows.Forms.Button btn_preleva;
        private System.Windows.Forms.TextBox txt_importo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txt_beneficiario;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_bonifico;
        private System.Windows.Forms.TextBox txt_importo_bonifico;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_movimenti;
    }
}
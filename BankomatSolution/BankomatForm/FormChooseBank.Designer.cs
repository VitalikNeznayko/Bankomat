namespace BankomatForm
{
    partial class FormChooseBank
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
            this.cbBank = new System.Windows.Forms.ComboBox();
            this.cbAddress = new System.Windows.Forms.ComboBox();
            this.btnChoose = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panelChooseTerminal = new System.Windows.Forms.Panel();
            this.panelEnterAccount = new System.Windows.Forms.Panel();
            this.labelAddress = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnReg = new System.Windows.Forms.Button();
            this.btnAuth = new System.Windows.Forms.Button();
            this.panelChooseTerminal.SuspendLayout();
            this.panelEnterAccount.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbBank
            // 
            this.cbBank.FormattingEnabled = true;
            this.cbBank.Location = new System.Drawing.Point(12, 29);
            this.cbBank.Name = "cbBank";
            this.cbBank.Size = new System.Drawing.Size(258, 24);
            this.cbBank.TabIndex = 0;
            this.cbBank.SelectedIndexChanged += new System.EventHandler(this.cbBank_SelectedIndexChanged);
            // 
            // cbAddress
            // 
            this.cbAddress.FormattingEnabled = true;
            this.cbAddress.Location = new System.Drawing.Point(12, 88);
            this.cbAddress.Name = "cbAddress";
            this.cbAddress.Size = new System.Drawing.Size(258, 24);
            this.cbAddress.TabIndex = 1;
            // 
            // btnChoose
            // 
            this.btnChoose.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnChoose.Location = new System.Drawing.Point(11, 129);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(259, 82);
            this.btnChoose.TabIndex = 2;
            this.btnChoose.Text = "Обрати банкомат";
            this.btnChoose.UseVisualStyleBackColor = true;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(8, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Оберіть банк";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(12, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(162, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Оберіть банкомат";
            // 
            // panelChooseTerminal
            // 
            this.panelChooseTerminal.Controls.Add(this.label4);
            this.panelChooseTerminal.Controls.Add(this.label3);
            this.panelChooseTerminal.Controls.Add(this.btnChoose);
            this.panelChooseTerminal.Controls.Add(this.cbAddress);
            this.panelChooseTerminal.Controls.Add(this.cbBank);
            this.panelChooseTerminal.Location = new System.Drawing.Point(0, 0);
            this.panelChooseTerminal.Name = "panelChooseTerminal";
            this.panelChooseTerminal.Size = new System.Drawing.Size(281, 220);
            this.panelChooseTerminal.TabIndex = 5;
            // 
            // panelEnterAccount
            // 
            this.panelEnterAccount.Controls.Add(this.labelAddress);
            this.panelEnterAccount.Controls.Add(this.btnBack);
            this.panelEnterAccount.Controls.Add(this.btnReg);
            this.panelEnterAccount.Controls.Add(this.btnAuth);
            this.panelEnterAccount.Location = new System.Drawing.Point(0, 0);
            this.panelEnterAccount.Name = "panelEnterAccount";
            this.panelEnterAccount.Size = new System.Drawing.Size(281, 220);
            this.panelEnterAccount.TabIndex = 3;
            this.panelEnterAccount.Visible = false;
            // 
            // labelAddress
            // 
            this.labelAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAddress.Location = new System.Drawing.Point(66, 11);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(202, 39);
            this.labelAddress.TabIndex = 3;
            this.labelAddress.Text = "вул";
            this.labelAddress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnBack.Location = new System.Drawing.Point(10, 11);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(50, 42);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "<";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnReg
            // 
            this.btnReg.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnReg.Location = new System.Drawing.Point(12, 141);
            this.btnReg.Name = "btnReg";
            this.btnReg.Size = new System.Drawing.Size(258, 70);
            this.btnReg.TabIndex = 1;
            this.btnReg.Text = "Реєстрація";
            this.btnReg.UseVisualStyleBackColor = true;
            this.btnReg.Click += new System.EventHandler(this.btnReg_Click);
            // 
            // btnAuth
            // 
            this.btnAuth.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAuth.Location = new System.Drawing.Point(12, 62);
            this.btnAuth.Name = "btnAuth";
            this.btnAuth.Size = new System.Drawing.Size(258, 70);
            this.btnAuth.TabIndex = 0;
            this.btnAuth.Text = "Аутентифікація ";
            this.btnAuth.UseVisualStyleBackColor = true;
            this.btnAuth.Click += new System.EventHandler(this.btnAuth_Click);
            // 
            // FormChooseBank
            // 
            this.ClientSize = new System.Drawing.Size(282, 223);
            this.Controls.Add(this.panelEnterAccount);
            this.Controls.Add(this.panelChooseTerminal);
            this.MinimumSize = new System.Drawing.Size(300, 270);
            this.Name = "FormChooseBank";
            this.Text = "Банкомат";
            this.panelChooseTerminal.ResumeLayout(false);
            this.panelChooseTerminal.PerformLayout();
            this.panelEnterAccount.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbBank;
        private System.Windows.Forms.ComboBox cbAddress;
        private System.Windows.Forms.Button btnChoose;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panelChooseTerminal;
        private System.Windows.Forms.Panel panelEnterAccount;
        private System.Windows.Forms.Button btnReg;
        private System.Windows.Forms.Button btnAuth;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label labelAddress;
    }
}


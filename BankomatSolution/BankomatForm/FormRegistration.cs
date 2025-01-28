using BancomatClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace BankomatForm
{
    public partial class FormRegistration : Form
    {
        private Bank activeBank;
        
        public FormRegistration(Bank bank)
        {
            InitializeComponent();
            activeBank = bank;
        }
        private void btnReg_Click(object sender, EventArgs e)
        {
            bool check = false;
            check = activeBank.CreateNewAccount(tbName.Text, tbPinCode.Text);
            if (check)
            {
                this.Close();
            }
        }
    }
}

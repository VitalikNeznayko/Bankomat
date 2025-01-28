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

namespace BankomatForm
{
    public partial class FormAuthorization : Form
    {
        static Bank selectedBank;
        static Account currentAccount;
        static AutomatedTellerMachine activeBankomat;
        public FormAuthorization(Bank bank, AutomatedTellerMachine bankomat)
        {
            InitializeComponent();
            selectedBank = bank;
            activeBankomat = bankomat;
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            bool check = false;
            check = selectedBank.Auth(tbCardNumber.Text, tbPinCode.Text);

            if (check)
            {
                this.Hide();
                currentAccount = selectedBank.FindAccount(tbCardNumber.Text);
                FormBankomatMenu bankomatMenu = new FormBankomatMenu(selectedBank, currentAccount, activeBankomat);
                bankomatMenu.ShowDialog();
                this.Show();
            }
        }
    }
}


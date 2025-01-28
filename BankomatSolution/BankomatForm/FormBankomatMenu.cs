using System;
using BancomatClassLibrary;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection.Emit;

namespace BankomatForm
{
    public partial class FormBankomatMenu : Form
    {
        private Bank currrentBank;
        private Account currentAccount;
        private AutomatedTellerMachine activeBankomat;
        bool amountEnter = false;
        int indexOperation = 0;
        public FormBankomatMenu(Bank bank, Account account, AutomatedTellerMachine bankomat)
        {
            InitializeComponent();
            HidePanel();
            panelStart.Visible = true;
            activeBankomat = bankomat;
            currrentBank = bank;
            currentAccount = account;
            labelName.Text = account.Name;
            labelCardNumber.Text = account.CardNumber;
        }
        void HidePanel()
        {
            panelStart.Visible = false;
            panelEnterAmount.Visible = false;
            panelEnterCardNumber.Visible = false;
            panelShowBalance.Visible = false;
            panelPutMoney.Visible = false;
            panelWithDraw.Visible = false;
            labelAmountEnter.Text = "";
            labelCardEnter.Text = "";
        }
        private void btnNum1_Click(object sender, EventArgs e)
        {
            if (amountEnter)
            {
                labelAmountEnter.Text += 1;
            }
            else
            {
                labelCardEnter.Text += 1;
            }
        }
        private void btnNum2_Click(object sender, EventArgs e)
        {
            if (amountEnter)
            {
                labelAmountEnter.Text += 2;
            }
            else
            {
                labelCardEnter.Text += 2;
            }
        }
        private void btnNum3_Click(object sender, EventArgs e)
        {
            if (amountEnter)
            {
                labelAmountEnter.Text += 3;
            }
            else
            {
                labelCardEnter.Text += 3;
            }
        }
        private void btnNum4_Click(object sender, EventArgs e)
        {
            if (amountEnter)
            {
                labelAmountEnter.Text += 4;
            }
            else
            {
                labelCardEnter.Text += 4;
            }
        }
        private void btnNum5_Click(object sender, EventArgs e)
        {
            if (amountEnter)
            {
                labelAmountEnter.Text += 5;
            }
            else
            {
                labelCardEnter.Text += 5;
            }
        }
        private void btnNum6_Click(object sender, EventArgs e)
        {
            if (amountEnter)
            {
                labelAmountEnter.Text += 6;
            }
            else
            {
                labelCardEnter.Text += 6;
            }
        }
        private void btnNum7_Click(object sender, EventArgs e)
        {
            if (amountEnter)
            {
                labelAmountEnter.Text += 7;
            }
            else
            {
                labelCardEnter.Text += 7;
            }
        }
        private void btnNum8_Click(object sender, EventArgs e)
        {
            if (amountEnter)
            {
                labelAmountEnter.Text += 8;
            }
            else
            {
                labelCardEnter.Text += 8;
            }
        }
        private void btnNum9_Click(object sender, EventArgs e)
        {
            if (amountEnter)
            {
                labelAmountEnter.Text += 9;
            }
            else
            {
                labelCardEnter.Text += 9;
            }
        }
        private void btnNum0_Click(object sender, EventArgs e)
        {
            if (amountEnter)
            {
                labelAmountEnter.Text += 0;
            }
            else
            {
                labelCardEnter.Text += 0;
            }
        }
        private void btnX_Click(object sender, EventArgs e)
        {
            if (amountEnter)
            {
                labelAmountEnter.Text = "";
            }
            else
            {
                labelCardEnter.Text = "";
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            HidePanel();
            panelShowBalance.Visible = true;
            labelShowBalance.Text = currentAccount.CardBalance.ToString() + "грн";
        }


        private void btnPutMoney_Click(object sender, EventArgs e)
        {
            HidePanel();
            panelEnterAmount.Visible = true;
            indexOperation = 1;
            amountEnter = true;
        }

        private void btnWithDraw_Click(object sender, EventArgs e)
        {
            HidePanel();
            panelEnterAmount.Visible = true;
            indexOperation = 2;
            amountEnter = true;

        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            HidePanel();
            panelEnterCardNumber.Visible = true;
            indexOperation = 3;
            amountEnter = false;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            switch (indexOperation)
            {
                case 1:
                    double amountToPut;
                    if (double.TryParse(labelAmountEnter.Text, out amountToPut))
                    {
                        activeBankomat.PutMoney(currentAccount, amountToPut);
                        panelPutMoney.Visible = true;
                        labelPutMoney.Text = labelAmountEnter.Text + "грн";
                    }
                    indexOperation = 0;
                    break;
                case 2:
                    double amountToWithdraw;
                    if (double.TryParse(labelAmountEnter.Text, out amountToWithdraw))
                    {
                        if (activeBankomat.WithDrawMoney(currentAccount, amountToWithdraw))
                        {
                            panelWithDraw.Visible = true;
                        }
                    }
                    indexOperation = 0;

                    break;
                case 3:
                    panelEnterCardNumber.Visible = false;
                    panelEnterAmount.Visible = true;
                    amountEnter = true;

                    double amountToTransfer;
                    if (double.TryParse(labelAmountEnter.Text, out amountToTransfer) && amountToTransfer > 0)
                    {
                        currrentBank.TransferFunds(currentAccount.CardNumber, labelCardEnter.Text, amountToTransfer);
                        panelStart.Visible = true;
                        indexOperation = 0;
                    }
                    break;
                case 0:
                    HidePanel();
                    panelStart.Visible = true;
                    break;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace BancomatClassLibrary
{
    public class Bank
    {
        private static Random random = new Random();
        public string BankName { get; set; }
        public List<AutomatedTellerMachine> BankomatList { get; set; }
        public List<Account> Accounts { get; set; }

        public event EventHandler<MessageEventArgs> Message;

        public Bank(string name)
        {
            BankName = name;
            BankomatList = new List<AutomatedTellerMachine>();
            Accounts = new List<Account>();
        }

        public void AddNewBancomat(int bankId, string bankomatAddress, double bankomatBalance)
        {
            var newBankomat = new AutomatedTellerMachine(bankId, bankomatAddress, bankomatBalance);
            newBankomat.Message += this.Message;
            BankomatList.Add(newBankomat);
        }

        public bool CreateNewAccount(string name, string pinCode)
        {

            if(name == "")
            {
                Message?.Invoke(this, new MessageEventArgs("Ім'я не може бути пустим"));
                return false;
            }
            if (pinCode.Length != 4 || !pinCode.All(char.IsDigit))
            {
                Message?.Invoke(this, new MessageEventArgs("Невірний формат пін-коду"));
                return false;
            }

            var account = new Account(name, GenerateCardNumber(), pinCode);
            account.Message += Message;
            Accounts.Add(account);
            Message?.Invoke(this, new MessageEventArgs($"Новий аккаунт успішно створено для {name}. Номер рахунку: {account.CardNumber}"));
            return true;
        }

        public bool Auth(string accountNumber, string pinCode)
        {
            var account = Accounts.Find(a => a.CardNumber == accountNumber);
            if (account == null)
            {
                Message?.Invoke(this, new MessageEventArgs("Картка з таким номером відсутня"));
                return false;
            }
            if (pinCode != account.PinCode)
            {
                Message?.Invoke(this, new MessageEventArgs("Невірний пін-код"));
                return false;
            }
            Message?.Invoke(this, new MessageEventArgs("Аутентифікація успішна"));
            return true;
        }

        public void TransferFunds(string fromAccountNumber, string toAccountNumber, double amount)
        {
            var fromAccount = Accounts.Find(a => a.CardNumber == fromAccountNumber);
            var toAccount = Accounts.Find(a => a.CardNumber == toAccountNumber);

            if (fromAccount == toAccount)
            {
                Message?.Invoke(this, new MessageEventArgs("Переведення коштів на власний рахунок неможливе"));
                return;
            }
            if (fromAccount == null || toAccount == null)
            {
                Message?.Invoke(this, new MessageEventArgs("Даний рахунок не знайдено"));
                return;
            }

            if (fromAccount.Withdraw(amount))
            {
                toAccount.AddToBalance(amount);
                Message?.Invoke(this, new MessageEventArgs($"Перерахування {amount} грн від {fromAccount.Name} до {toAccount.Name} успішне"));
            }
            else
            {
                Message?.Invoke(this, new MessageEventArgs("Недостатньо коштів для перерахування"));
            }
        }

        private static string GenerateCardNumber()
        {
            return string.Concat(Enumerable.Range(0, 4).Select(_ => random.Next(0, 10).ToString())); 
        }

        public Account FindAccount(string accountNumber)
        {
            var activeAccount = Accounts.Find(a => a.CardNumber == accountNumber);
            if (activeAccount == null)
            {
                Message?.Invoke(this, new MessageEventArgs($"Картки з таким номером не існує, перевірте введення номера!!!"));
            }
            return activeAccount;
        }

        public string GetBankomatAddress(int index)
        {
            if (index < 0 || index >= BankomatList.Count)
                throw new ArgumentOutOfRangeException(nameof(index), "Неправильний індекс банкомата.");

            return "вул." + BankomatList[index].GetBankomatAddress();
        }
    }
}

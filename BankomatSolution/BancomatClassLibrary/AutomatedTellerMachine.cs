using System;

namespace BancomatClassLibrary
{
    public class AutomatedTellerMachine
    {
        public int BankId { get; private set; }
        public string BankomatAddress { get; private set; }
        public double BankomatBalance { get; private set; }
        public event EventHandler<MessageEventArgs> Message;

        public AutomatedTellerMachine(int bankId, string bankomatAddress, double bankomatBalance)
        {
            BankId = bankId;
            BankomatAddress = bankomatAddress;
            BankomatBalance = bankomatBalance;
        }

        public bool WithDrawMoney(Account account, double moneyToGet)
        {
            if (BankomatBalance >= moneyToGet)
            {
                if (account.Withdraw(moneyToGet))
                {
                    BankomatBalance -= moneyToGet;

                    Message?.Invoke(this, new MessageEventArgs($"З рахунку знято {moneyToGet} грн"));
                    return true;

                }
                return false;
            }
            Message?.Invoke(this, new MessageEventArgs($"На жаль, у банкоматі недостатньо коштів для зняття такої суми." +
                   $"\nБудь ласка, оберіть меншу суму або зверніться до іншого найближчого банкомату."));
            return false;

        }

        public bool PutMoney(Account account, double moneyToPut)
        {
            if (account.AddToBalance(moneyToPut))
            {
                BankomatBalance += moneyToPut;
                Message?.Invoke(this, new MessageEventArgs($"Баланс успішно поповнено на {moneyToPut} грн"));
                return true;
            }

            return false;
        }

        public string GetBankomatAddress()
        {
            return BankomatAddress;
        }
    }
}

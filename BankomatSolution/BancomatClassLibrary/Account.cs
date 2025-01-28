using System;


namespace BancomatClassLibrary
{

    public class Account
    {
        public string Name;
        public string CardNumber;
        public string PinCode;
        public double CardBalance;
        public EventHandler<MessageEventArgs> Message;
        public EventHandler<AddToBalanceArgs> AddToBalanceHandler;
        public EventHandler<DrawMoneyArgs> DrawMoneyHandler;

        public Account(string name, string cardNubber, string pinCode)
        {
            Name = name;
            CardNumber = cardNubber;
            PinCode = pinCode;
            CardBalance = 0.0;
        }
        public bool AddToBalance(double moneyCount)
        {
            AddToBalanceHandler?.Invoke(this, new AddToBalanceArgs("", moneyCount));
            if (moneyCount < 0)
            {
                Message?.Invoke(this, new MessageEventArgs($"Введенна сума не вірна, баланс неможливо поповнити"));
                return false;
            }
            else
            {
                CardBalance += moneyCount;
                return true;
            }
        }

        public void GetBalance()
        {
            Message?.Invoke(this, new MessageEventArgs($"Ваш баланс: {CardBalance} грн"));
        }

        public bool Withdraw(double moneyCount)
        {
            if (moneyCount < 0)
            {
                Message?.Invoke(this, new MessageEventArgs($"Не коректна сума для зняття коштів з балансу"));
                return false;
            }
            if (CardBalance < moneyCount)
            {
                Message?.Invoke(this, new MessageEventArgs("Недостатньо коштів на рахунку"));
                return false;
            }
            CardBalance -= moneyCount;
            return true;
        }


    }
}

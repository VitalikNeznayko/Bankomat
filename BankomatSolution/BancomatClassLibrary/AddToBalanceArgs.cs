using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancomatClassLibrary
{
    public class AddToBalanceArgs : EventArgs
    {
        public string Message { get; set; }
        public double MoneyToAdd { get; set; }

        public AddToBalanceArgs(string message, double moneyToAdd)
        {
            Message = message;
            MoneyToAdd = moneyToAdd;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancomatClassLibrary
{
    public class DrawMoneyArgs : EventArgs
    {
        public string Message { get; set; }
        public double MoneyToDraw { get; set; }

        public DrawMoneyArgs(string message, double moneyToDraw)
        {
            Message = message;
            MoneyToDraw = moneyToDraw;
        }

    }
}

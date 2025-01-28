using BancomatClassLibrary;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace BancomatConsoleApp
{
    internal class Program
    {
        static Bank[] banks = {
            new Bank("Приват банк"),
            new Bank("Моно банк"),
            new Bank("Ощад банк"),
        };

        static Bank selectedBank;
        static AutomatedTellerMachine activeBankomat;
        static Account currentAccount;

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            for (int i = 0; i < banks.Length - 1; i++)
            {
                banks[i].Message += BankMessageHandler;
            }

            banks[0].AddNewBancomat(1, "Велика Бердичiвська 52", 20000);
            banks[0].AddNewBancomat(1, "Вітрука 43", 0);
            banks[1].AddNewBancomat(2, "Київська 87", 1200);
            banks[2].AddNewBancomat(3, "Івана Гонти 65", 1200);
            banks[2].AddNewBancomat(3, "Михайла Грушевського 23", 1200);

            MenuChooseBank();
        }


        private static void DrawMenu(string[] items, int row, int col, int index)
        {
            Console.Clear();
            Console.SetCursorPosition(col, row);
            for (int i = 0; i < items.Length; i++)
            {
                Console.ForegroundColor = (i == index) ? ConsoleColor.Red : ConsoleColor.White;
                Console.WriteLine(items[i]);
            }
            Console.ResetColor();
            Console.WriteLine();
        }


        private static void MenuChooseBank()
        {
            Console.Clear();
            List<string> menuItems = new List<string>();
            int index = 0;
            int row = Console.CursorTop;
            int col = Console.CursorLeft;

            foreach (var bank in banks)
            {
                menuItems.Add(bank.BankName);
            }
            menuItems.Add("Вихід");
            while (true)
            {
                Console.Clear();
                DrawMenu(menuItems.ToArray(), row, col, index);
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.DownArrow:
                        index = (index + 1) % menuItems.Count;
                        break;
                    case ConsoleKey.UpArrow:
                        index = (index > 0) ? index - 1 : menuItems.Count - 1;
                        break;
                    case ConsoleKey.Enter:
                        if (index == menuItems.Count - 1)
                        {
                            return;
                        }
                        selectedBank = banks[index];
                        MenuChooseBankomat();
                        break;
                }
            }

        }

        private static void MenuChooseBankomat()
        {
            Console.Clear();
            List<string> menuItems = new List<string>();
            int index = 0;
            int row = Console.CursorTop;
            int col = Console.CursorLeft;

            for (int i = 0; i < selectedBank.BankomatList.Count; i++)
            {
                menuItems.Add(selectedBank.GetBankomatAddress(i));
            }
            menuItems.Add("Повернутися назад");
            while (true)
            {
                Console.Clear();
                DrawMenu(menuItems.ToArray(), row, col, index);
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.DownArrow:
                        index = (index + 1) % menuItems.Count;
                        break;
                    case ConsoleKey.UpArrow:
                        index = (index > 0) ? index - 1 : menuItems.Count - 1;
                        break;
                    case ConsoleKey.Enter:
                        if (index == menuItems.Count - 1)
                        {
                            MenuChooseBank();
                        }
                        else
                        {
                            activeBankomat = selectedBank.BankomatList[index];
                            MenuChooseAuth();
                        }
                        break;
                }
            }
        }

        private static void MenuChooseAuth()
        {
            Console.Clear();
            List<string> menuItems = new List<string> { "Авторизуватися", "Зареєструватися", "Повернутися назад" };
            int index = 0;
            int row = Console.CursorTop;
            int col = Console.CursorLeft;
            while (true)
            {
                Console.Clear();
                DrawMenu(menuItems.ToArray(), row, col, index);
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.DownArrow:
                        index = (index + 1) % menuItems.Count;
                        break;
                    case ConsoleKey.UpArrow:
                        index = (index > 0) ? index - 1 : menuItems.Count - 1;
                        break;
                    case ConsoleKey.Enter:
                        switch (index)
                        {
                            case 0:
                                if (Authefication())
                                    AccountMenu();
                                break;
                            case 1:
                                CreateNewAccount();
                                break;
                            case 2:
                                MenuChooseBankomat();
                                break;
                        }
                        break;
                }
            }
        }

        static void AccountMenu()
        {
            Console.Clear();
            List<string> menuItems = new List<string>() { "Переглянути баланс", "Зняти кошти",
                "Поповнити рахунок", "Перерахувати кошти", "Повернутися назад" };
            int index = 0;
            int row = Console.CursorTop;
            int col = Console.CursorLeft;
            while (true)
            {
                Console.Clear();
                DrawMenu(menuItems.ToArray(), row, col, index);
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.DownArrow:
                        index = (index + 1) % menuItems.Count;
                        break;
                    case ConsoleKey.UpArrow:
                        index = (index > 0) ? index - 1 : menuItems.Count - 1;
                        break;
                    case ConsoleKey.Enter:
                        switch (index)
                        {
                            case 0:
                                currentAccount.GetBalance();
                                break;
                            case 1:
                                Console.WriteLine("Введіть суму для зняття:");
                                if (int.TryParse(Console.ReadLine(), out int amountWithDraw))
                                {
                                    activeBankomat.WithDrawMoney(currentAccount, amountWithDraw);
                                }
                                else
                                {
                                    Console.WriteLine("Невірний формат суми.");
                                }
                                Console.ReadKey();
                                break;
                            case 2:
                                Console.WriteLine("Введіть суму для поповнення:");
                                if (int.TryParse(Console.ReadLine(), out int amountPut))
                                {
                                    activeBankomat.PutMoney(currentAccount, amountPut);
                                }
                                else
                                {
                                    Console.WriteLine("Невірний формат суми.");
                                }
                                break;
                            case 3:
                                Console.WriteLine("Введіть номер рахунку отримувача:");
                                string receiverAccountNumber = Console.ReadLine();
                                Console.WriteLine("Введіть суму для перерахування:");
                                int.TryParse(Console.ReadLine(), out int amountTransfer);
                                selectedBank.TransferFunds(currentAccount.CardNumber, receiverAccountNumber, amountTransfer);
                                break;
                            case 4:
                                return;
                        }
                        break;
                }
            }
        }

        static void CreateNewAccount()
        {
            while (true)
            {
                Console.WriteLine("Введіть своє ім'я:");
                string name = Console.ReadLine();
                Console.WriteLine("Введіть пін-код (4 цифри):");
                string pinCode = Console.ReadLine();

                if (pinCode.Length == 4)
                {
                    if (name != "")
                    {
                        selectedBank.CreateNewAccount(name, pinCode);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Помилка!! Ім'я не може бути пустим");
                    }
                }
                else
                {
                    Console.WriteLine("Помилка!! Пін-код повинен містити 4 цифри");
                }
                break;
            }
        }

        static bool Authefication()
        {
            Console.WriteLine("Введіть номер картки:");
            string accountNumber = Console.ReadLine();
            Console.WriteLine("Введіть пін-код:");
            string pinCode = Console.ReadLine();

            if (selectedBank.Auth(accountNumber, pinCode))
            {
                currentAccount = selectedBank.FindAccount(accountNumber);
                return true;
            }
            else
            {
                Console.WriteLine("Аутентифікація не вдалася.");
                return false;
            }
        }

        static void BankMessageHandler(object sender, MessageEventArgs e)
        {
            Console.WriteLine(e.Message);
            Console.ReadKey();
        }
    }
}

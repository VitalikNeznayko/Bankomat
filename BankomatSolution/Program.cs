using BancomatClassLibrary;

namespace BankomatConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bank[] banks = {
            new Bank(1, "Приват банк"),
            new Bank(2, "Моно банк"),
            new Bank(3, "Ощад банк"),
            };
            bool stop = false;
            bool check = false;

            Bankomat bankomat = new Bankomat(1,20000, "Велика Бердичiвська 52");
            banks[0].AddBankomat(bankomat);

            bankomat = new Bankomat(1, 0, "Вітрука 43");
            banks[0].AddBankomat(bankomat);

            bankomat = new Bankomat(2, 1200, "Київська 87");
            banks[1].AddBankomat(bankomat);

            bankomat = new Bankomat(3, 1200, "Івана Гонти 65");
            banks[3].AddBankomat(bankomat);

            bankomat = new Bankomat(3, 1200, "Михайла Грушевського 23");
            banks[3].AddBankomat(bankomat);
            do
            {
                Console.Clear();
                Console.WriteLine("+++Список банкiв++++");
                banks[0].PrintBanksConsole(banks);
                string AskMessage = "Оберiть банк: ";
                int k = CheckInt(AskMessage);
                
                if (k <= banks.Length)
                {
                    banks[k - 1].PrintBankomatListConsole();


                    AskMessage = "Оберiть банкомат: ";
                    int bNumber = CheckInt(AskMessage);
                  
                    if(bNumber <= banks[k - 1].BankomatsList.Length)
                    {
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("1 Авторизуватися\n" +
                                              "2 Зареєструватися\n" +
                                              "3 Вийти");
                            AskMessage = "=====>";
                            int n = CheckInt(AskMessage);

                            Account account = new Account();
                            account.OnError += PrintError;
                            switch (n)
                            {
                                case 1:
                                    AskMessage = "Введiть номер карти: ";
                                    int cardNum = CheckInt(AskMessage);
                                    AskMessage = "Введiть пароль карти: ";
                                    int pass = CheckInt(AskMessage);
                                    account = account.AutorizationApp(banks, cardNum, pass);
                                    Console.ReadKey();
                                    if (account != null)
                                    {
                                       
                                        do
                                        {
                                            Console.Clear();
                                            Console.WriteLine($"Вiтаємо {account.GetFullName()}!");

                                            Console.WriteLine("1 Зняти готiвку\n" +
                                                              "2 Поповнити карту\n" +
                                                              "3 Перевiрити баланс\n" +
                                                              "4 Переказати кошти\n" +
                                                              "5 Вийти");

                                            AskMessage = "======>";
                                            n = CheckInt(AskMessage);

                                            switch (n)
                                            {
                                                case 1:                    
                                                    AskMessage = "Введiть бажану суму: ";
                                                    int getM = CheckInt(AskMessage);

                                                    check = account.GetMoneyApp(banks[k - 1].BankomatsList[bNumber - 1], getM);
                                                    if (check == true)
                                                    {
                                                        Console.WriteLine("Не забудьте забрати вашi грошi!");
                                                    }
                                                    Console.ReadKey();
                                                    break;
                                                case 2:
                                                    
                                                    AskMessage = "Введiть бажану суму: ";
                                                    int putM = CheckInt(AskMessage);
                                                    account.PutMoneyApp(banks[k - 1].BankomatsList[bNumber - 1], putM);
                                                    Console.ReadKey();
                                                    break;
                                                case 3:
                                                    Console.WriteLine($"На вашому рахунку {account.GetCardBalance()}");
                                                    Console.ReadKey();
                                                    break;
                                                case 4:
                                                    AskMessage = "Введiть номер карти одержувача:";
                                                    int getterNumber = CheckInt(AskMessage);
                                                    AskMessage=("Введiть бажану суму переказу: ");
                                                    int shareSuma = CheckInt(AskMessage);
                                                    check = account.ShareMoneyApp(banks, getterNumber, shareSuma);
                                                    if (check == true)
                                                    {
                                                        Console.WriteLine($"На рахунок {getterNumber} перераховано {shareSuma}");
                                                    }
                                                    Console.ReadKey();
                                                    break;
                                                case 5:
                                                    stop = true;
                                                    break;
                                                default:
                                                    break;
                                            }
                                        }
                                        while (!stop);
                                    }

                                    stop = false;
                                    break;

                                case 2:
                                    Console.WriteLine("+++ Реєстрацiя акаунта +++");

                                    Console.Write("Введiть ваше прiзвище: ");
                                    string surname = Console.ReadLine();

                                    Console.Write("Введiть ваше iм'я: ");
                                    string name = Console.ReadLine();

                                    Console.Write("Введiть, як вас по батьковi: ");
                                    string lastName = Console.ReadLine();

                                    Console.Write("Введiть, вашу пошту: ");
                                    string email = Console.ReadLine();
                                    string acountPassword = "";
                                  

                                    Console.Write("Придумайте пароль для акаунта (8 i бiльше символiв): ");
                                    acountPassword = Console.ReadLine();                                
                                    Random rand = new Random();
                                    int cardNumber = rand.Next(100000, 1000000);
                                    Console.WriteLine($"Вам надано карту з номером: {cardNumber}");
                                    bool checkInput = false;
                                    int cardPassword = 0;
                                    do
                                    {
                                        Console.Write("\nПридумайте пароль для карти (4 цифри): ");
                                        string cardPasswordInput = Console.ReadLine();                            
                                        if (cardPasswordInput.Length == 4 && int.TryParse(cardPasswordInput, out cardPassword))
                                        {
                                            checkInput = true;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Пароль для карти має мiстити 4 цифри!");
                                            checkInput = false;
                                        }
                                    }
                                    while (!checkInput);
                                    account = new Account();
                                    account.RegistrationApp(surname, name,lastName, acountPassword, cardNumber, cardPassword);
                                    banks[k - 1].AddUser(account);
                                    if (account.GetFullName() != "  ")
                                    {
                                        Console.WriteLine($"Користувач {account.GetFullName()} доданий до банку {banks[k - 1].GetBankName()}.");
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Користувача не додано до банку {banks[k - 1].GetBankName()}.");
                                    }
                                    
                                    Console.ReadKey();
                                    break;
                                case 3:
                                    stop = true;
                                    break;
                                default:
                                    break;
                            }
                        }
                        while (!stop);
                    }
                    else
                    {
                        stop = true;
                    }
                }
                else
                {
                    stop = true;
                }
            }
            while (!stop);
        }
        static void PrintError(string message)
        {
            Console.WriteLine("Помилка: " + message);
        }
        static int CheckInt(string message)
        {
            int result = 0;
            bool f = true;
            do
            {
                Console.Write(message);
                string input = Console.ReadLine();
                f = int.TryParse(input, out result);
            }
            while (!f);

            return result;
        }

    }
}


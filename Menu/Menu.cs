using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Menu
{
    public delegate void Command();

    public class Menu
    {
        private Dictionary<string,Action> CommandList = new Dictionary<string,Action>();
        public delegate void Method(string info);
        static void ErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
      public static void LoadModule(string module_name)
        {
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("█");
            }
            Console.WriteLine($"Модуль {module_name} был загружен {DateTime.Now}");
        }
        public static void PrintInfo(string message)
        {
            Console.WriteLine();
            Console.WriteLine(message);
            Console.WriteLine();
        }
       
        public static void Welcome()
        {
            String[] welcome = new string[13]
            {
                "░░░░░▄▀▀▀▄░░░░░░░░ ",
                "▄███▀░◐░░░▌░░░░░░░ ",
                "░░░░▌░░░░░▐░░░░░░░ ",
                "░░░░▐░░░░░▐░░░░░░░ ",
                "░░░░▌░░░░░▐▄▄░░░░░ ",
                "░░░░▌░░░░▄▀▒▒▀▀▀▀▄",
                "░░░▐░░░░▐▒▒▒▒▒▒▒▒▀▀▄ ",
                "░░░▐░░░░▐▄▒▒▒▒▒▒▒▒▒▒▀▄",
                "░░░░▀▄░░░░▀▄▒▒▒▒▒▒▒▒▒▒▀▄ ",
                "░░░░░░▀▄▄▄▄▄█▄▄▄▄▄▄▄▄▄▄▄▀▄",
                "░░░░░░░░░░░▌▌░▌▌░░░░░ ",
                "░░░░░░░░░░░▌▌░▌▌░░░░░ ",
                "░░░░░░░░░▄▄▌▌▄▌▌░░░░░",
            };
            string[] welcome1 = new string[5]
            {
                "Запускаем гуся!",
                "Гусь работяга встает на работу",
                "Гусь работяга идет на работу",
                "Гусь работяга запускает систему",
                "Гусь готов к работе"
            };
            for (int i = 0; i < 5; i++)
            {
                foreach (string mes in welcome)
                {
                    Console.WriteLine(mes);
                    Thread.Sleep(50);
                }
                Console.WriteLine(welcome1[i]);
                Thread.Sleep(1000);
                Console.Clear();
            }
            foreach (string mes in welcome)
            {
                Console.WriteLine(mes);
                Thread.Sleep(100);
            }
            Console.WriteLine("Гусь-Работяга.OS");
            Console.WriteLine();
        }

        

        public static void PrintParts(ArrayList parts)
        {
            foreach (var part in parts)
            {
                PrintInfo(part.ToString());
            }
        }
        public static void Choise(List<Method> methods)
        {
            switch (Console.ReadLine())
            {
                case "1":
                    
                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "4":
                    break;
                default:
                    ErrorMessage("Выбран неверный элемент");
                    Choise(methods);
                    break;
            }
        }
        public void AddCommand(string command_name, Action function)
        {

            CommandList.Add(SystemInput(), function);
        }
        public  void CommandListPrint()
        {
            foreach (var item in CommandList)
            {
                Console.WriteLine($"Команда:{item.Key} Функция {item.Value}");
            }
            Console.WriteLine();
        }
        public string SystemInput()
        {
            Console.Write("$:===>");
            return Console.ReadLine();
        }
        public void CommandInput()
        {
            string input = SystemInput();
            if (CommandList.ContainsKey(input))
            {
                foreach (var item in CommandList)
                {
                    if (item.Key == input)
                    {
                        item.Value();
                     
                    }
                }
            }
            else
            {
                ErrorMessage($"Команды {input} нет в системе");
            }
            
            
        }

    }
}

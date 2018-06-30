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
        /// <summary>
        /// Имя пользователя
        /// </summary>
        public static string UserName;
        /// <summary>
        /// Доступ к системе
        /// </summary>
        public static string Access {
            get
            {
                if (isRoot) return "#"; else return "$";
            }
        }
        /// <summary>
        /// Полный доступ?
        /// </summary>
        public static bool isRoot;
        /// <summary>
        /// Список команд
        /// </summary>
        private Dictionary<string,Action> CommandList = new Dictionary<string,Action>();
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="username">Имя пользователя</param>
        /// <param name="access">Уровень доступа</param>
        public Menu(string username,bool rootAccess)
        {
            UserName = username;
            isRoot = rootAccess;
        }
        #region SystemMethods
        /// <summary>
        /// Сообщение об ошибке
        /// </summary>
        /// <param name="message">входящее сообщение</param>
        static void ErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
        /// <summary>
        /// Загрузка модуля
        /// </summary>
        /// <param name="module_name">наименование модуля</param>
        public static void LoadModule(string module_name)
        {
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("█");
            }
            Console.WriteLine($"Модуль {module_name} был загружен {DateTime.Now}");
        }
        /// <summary>
        /// Печать информации
        /// </summary>
        /// <param name="message"></param>
        public static void PrintInfo(string message)
        {
            Console.WriteLine();
            Console.WriteLine(message);
            Console.WriteLine();
        }
       /// <summary>
       /// Вступление для меню
       /// </summary>
        public static void Welcome()
        {
            int speed = 30;
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
                    Thread.Sleep(speed);
                }
                Console.WriteLine(welcome1[i]);
                Thread.Sleep(speed);
                Console.Clear();
            }
            foreach (string mes in welcome)
            {
                Console.WriteLine(mes);
                Thread.Sleep(speed);
                Console.Beep();
            }
            Console.WriteLine("Гусь-Работяга.OS");
            Console.WriteLine();
        }

        

        public  void PrintParts(ArrayList parts)
        {
            foreach (var part in parts)
            {
                LoadModule(part.ToString());
            }
        }
        
        public void AddCommand(string command_name, Action function)
        {
            try
            {
                CommandList.Add(command_name, function);
            }
            catch (Exception e)
            {
                ErrorMessage(e.Message);
            }
            
        }
        public  void CommandListPrint()
        {
            foreach (var item in CommandList)
            {
                Console.WriteLine($"Команда:{item.Key} Функция {item.Value}");
            }
            Console.WriteLine();
        }
        /// <summary>
        /// Системный ввод
        /// </summary>
        /// <returns></returns>
        public string SystemInput()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($@"{UserName}\\");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write($"{Access}>~");
            Console.ForegroundColor = ConsoleColor.White;
            return Console.ReadLine();
        }
        /// <summary>
        /// Печать любого списка
        /// </summary>
        /// <param name="collection"></param>
        public void PrintList(ICollection collection)
        {
            int index = 0;
            foreach(var item in collection)
            {
                Console.WriteLine($"[{index}] {item}");
                index++;
            }
        }
        public void PrintDirectorySystem()
        {
           
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
            this.CommandInput();
            
        }
        #endregion;

    }
}

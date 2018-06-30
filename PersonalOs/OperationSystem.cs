using System;
using System.Collections;
using System.Collections.Generic;

namespace PersonalOs
{
   public class OperationSystem
    {
        /// <summary>
        /// Список частей системы
        /// </summary>
        ArrayList PartsOfSystem;

        #region OtherSystemFiles
        /// <summary>
        /// Файловая система
        /// </summary>
        MPFS_FS.MPFS_FS FILE_SYSTEM;//Файловая система;
        /// <summary>
        /// Загрузчик
        /// </summary>
        BootLoader.BootLoader BOOT_LOADER;
        /// <summary>
        /// Ядро системы
        /// </summary>
        Kernel.Kernel KERNEL;
        /// <summary>
        /// Оболочка системы
        /// </summary>
        Menu.Menu EnviromentMenu;
        #endregion;
        

        /// <summary>
        /// Конструктор операционной системы
        /// </summary>
        public OperationSystem()
        {
           
            /* Инициализация загрузчика системы */
            BOOT_LOADER = new BootLoader.BootLoader();
            /* Инициализация ядра системы */
            KERNEL = new Kernel.Kernel(BOOT_LOADER.Status,16,30);
            /* Инициализация файловой системы */
            FILE_SYSTEM = new MPFS_FS.MPFS_FS(KERNEL.KernelStatus);

            /* Загрузка частей системы в модули */
            this.ModulesLoad();
            //Инициализация меню
            this.InitializeMenu();
        }
        /// <summary>
        /// Печать корневой директории
        /// </summary>
        public void PrintRootDirectory()
        {
            Menu.Menu.PrintInfo("Печать корневой директории");
            foreach (string item in FILE_SYSTEM.GetRootDirectory())
            {
                Menu.Menu.PrintInfo(item);
            }
        }
        public void NavigateToDirectory()
        {
            string path = EnviromentMenu.SystemInput();
            foreach (string item in FILE_SYSTEM.Move(path))
            {
                Menu.Menu.PrintInfo(item);
            }
        }
        /// <summary>
        /// Загрузка часей системы
        /// </summary>
        public void ModulesLoad()
        {
            Kernel.Kernel.Root ROOT_USER = new Kernel.Kernel.Root("Привет", "пока123");
            ROOT_USER.SaveUser(FILE_SYSTEM.WriteInfo);//Сохранение пользователя в файле

            EnviromentMenu = new Menu.Menu(ROOT_USER.Name,false);
            PartsOfSystem = new ArrayList();
            /* Добавление частей системы */
            PartsOfSystem.Add(BOOT_LOADER);
            PartsOfSystem.Add(KERNEL);
            PartsOfSystem.Add(FILE_SYSTEM);
            //Печать частей системы
            Menu.Menu.Welcome();
            EnviromentMenu.PrintParts(PartsOfSystem);
        }
        public void QuitSystem()
        {
            Menu.Menu.PrintInfo("Вы точно хотите выйти");
            Environment.Exit(Environment.ExitCode);
        }
        /// <summary>
        /// Инициализация меню в системе
        /// </summary>
        public void InitializeMenu()
        {
            EnviromentMenu.AddCommand("help", EnviromentMenu.CommandListPrint);
            EnviromentMenu.AddCommand("ls",PrintRootDirectory);
            EnviromentMenu.AddCommand("cd",NavigateToDirectory);
            EnviromentMenu.AddCommand("quit",QuitSystem);


            EnviromentMenu.CommandListPrint();
            EnviromentMenu.CommandInput();
        }
        
    }
}

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

           
            EnviromentMenu.AddCommand("help", EnviromentMenu.CommandListPrint);

            EnviromentMenu.CommandListPrint();

            EnviromentMenu.CommandInput();
            /* Корневой пользователь */ 
            Kernel.Kernel.Root ROOT_USER = new Kernel.Kernel.Root("Привет","пока123");
            /* Сохранение пользователя */

            ROOT_USER.SaveUser(FILE_SYSTEM.WriteInfo);
        }
        public void ModulesLoad()
        {
            EnviromentMenu = new Menu.Menu();
            PartsOfSystem = new ArrayList();
            /* Добавление частей системы */
            PartsOfSystem.Add(BOOT_LOADER);
            PartsOfSystem.Add(KERNEL);
            PartsOfSystem.Add(FILE_SYSTEM);
            //Печать частей системы
            Menu.Menu.PrintParts(PartsOfSystem);

            Menu.Menu.Welcome();
           
        }
        
    }
}

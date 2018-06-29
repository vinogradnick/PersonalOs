using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPFS_FS
{
    public class MPFS_FS
    {
        DirectoryInfo RootDirectory;
        /// <summary>
        /// Размер диска по умолчанию в 30 мб
        /// </summary>
        private static long disk_size = 30 * 1024 * 1024;
        /// <summary>
        /// Получение размера заполненого пространства
        /// </summary>
        public long disk_load=>new DirectoryInfo(RootDirectory.FullName).GetFiles("*.*", SearchOption.AllDirectories).Sum(file => file.Length);

        public MPFS_FS(bool status)
        {
            ///Если система существует
            if (Check_FileSystem() == true)
            {
               
            }
            else
            {
                Create_OS_Directory();
            }
        }
        /// <summary>
        /// Проверка файловой системы
        /// </summary>
        public bool Check_FileSystem()
        {
            /* Папка с системой не была создана */
            if (Directory.GetDirectories("OS") == null)
                return false;

            return true;//Система не была создана
        }
        /// <summary>
        /// Создание директории файловой системы
        /// </summary>
        private void Create_OS_Directory()
        {
            RootDirectory = new DirectoryInfo("OS");//Корневой каталог
            Directory.CreateDirectory($@"{RootDirectory.Name}\Modules");//Модули системы
            Directory.CreateDirectory($@"{RootDirectory.Name}\System");//Системная папка
            Directory.CreateDirectory($@"{RootDirectory.Name}\Journal");//Системный журнал
        }
        
    }
}

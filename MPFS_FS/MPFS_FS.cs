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
        /// <summary>
        /// Текущая директория
        /// </summary>
        public string _DIR;
        /// <summary>
        /// Корневая директория системы
        /// </summary>
        DirectoryInfo RootDirectory;
        /// <summary>
        /// Размер диска по умолчанию в 30 мб
        /// </summary>
        public readonly long disk_size = 30 * 1024 * 1024;
        /// <summary>
        /// Получение размера заполненого пространства
        /// </summary>
        public long disk_load;
        /// <summary>
        /// Конструктор системы по умолчанию
        /// </summary>
        /// <param name="status"></param>
        public MPFS_FS(bool status)
        {
            RootDirectory = new DirectoryInfo("OS");//Корневой каталог
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
            try
            {
                Directory.GetDirectories("OS");
                return true;

            }
            catch (Exception)
            {
                return false;//Система не была создана
            }


        }
        /// <summary>
        /// Создание директории файловой системы
        /// </summary>
        private void Create_OS_Directory()
        {
            Directory.CreateDirectory($@"OS");//Модули системы

            Directory.CreateDirectory($@"{RootDirectory.Name}\Modules");//Модули системы
            Directory.CreateDirectory($@"{RootDirectory.Name}\System");//Системная папка
            Directory.CreateDirectory($@"{RootDirectory.Name}\Journal");//Системный журнал
        }
        public override string ToString()
        {
            return $"Размер диска {disk_size} {disk_load}";
        }
        public List<string> ReadInfo(string path)
        {
            List<string> streamResult = new List<string>();
            try
            {

                StreamReader stream = new StreamReader(path);
                while (!stream.EndOfStream)
                {
                    streamResult.Add(stream.ReadLine());
                }
                stream.Close();
            }
            catch (Exception)
            {

            }
            return streamResult;
        }
        public void WriteInfo(string path,List<string> info)
        {
            try
            {
                StreamWriter writer = new StreamWriter(path);
                foreach (string item in info)
                {
                    writer.WriteLineAsync(item);

                }
                writer.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string[] Move(string directoryName)
        {
            try
            {
                return Directory.GetFileSystemEntries($@"{RootDirectory.FullName}\{directoryName}");

            }
            catch (Exception)
            {
                return new string[] { "Ошибка" };
            }
        }

        public string[] GetRootDirectory() => Directory.GetFileSystemEntries(RootDirectory.FullName);

    }
}

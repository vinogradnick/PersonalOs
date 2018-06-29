using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kernel
{
    /// <summary>
    /// Класс ядра операционной системы
    /// </summary>
    public class Kernel
    {
        
        /// <summary>
        /// Версия ядра
        /// </summary>
        private static readonly string Version;
        /// <summary>
        /// Именование ядра
        /// </summary>
        private static readonly string Name;
        /// <summary>
        /// Частота ядра
        /// </summary>
        private static readonly int Frequency;
        /// <summary>
        /// Загрузка ядра
        /// </summary>
        private static int WorkLoad { get; set; }
        /// <summary>
        /// Конструктор ядра 
        /// </summary>
        public Kernel() { }
        /// <summary>
        /// Конструктор ядра с параметрами
        /// </summary>
        /// <param name="status_load">Статус загрузки</param>
        /// <param name="ram_size">объем оперативной памяти</param>
        /// <param name="disk_size">объем дискового пространства</param>
        public Kernel(bool status_load,double ram_size,double disk_size)
        {
            /* Создание списка модулей 1/4 размера оперативной памяти */
            ListOfModules = new Stack<Module>((int)ram_size/4);//Создание списка модулей
        }
        /// <summary>
        /// Переопределение метода toString
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"Kernel_Name:{Name}, Frequency:{Frequency}, WorkLoad:{WorkLoad}%";
        /// <summary>
        /// Список служб и задач
        /// </summary>
        private Stack<Module> ListOfModules;
        /// <summary>
        /// Добавление модуля в память
        /// </summary>
        /// <param name="module">Модуль для загрузки</param>
        private void LoadModule(Module module)
        {
            ListOfModules.Push(module);//Добавление модуля в стэк
        }
    }
}

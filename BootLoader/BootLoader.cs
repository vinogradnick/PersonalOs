using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootLoader
{
    /// <summary>
    /// Загрузчик операционной системы
    /// </summary>
    public  class BootLoader
    {
        /// <summary>
        /// Версия загрузчика
        /// </summary>
        private static readonly string Version = "0.01";
        /// <summary>
        /// Имя загрузчика
        /// </summary>
        private static readonly string Name = "UEFI";
       public BootLoader()
        {
            Console.Beep();
            Status = true;
        }
        public bool Status { get; private set; }
        public override string ToString()
        {
            return $"{Version} {Name}";
        }
    }

    
}

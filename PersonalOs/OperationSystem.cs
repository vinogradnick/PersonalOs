using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalOs
{
    class OperationSystem
    {
        Kernel.Kernel Kernel = new Kernel.Kernel();
        BootLoader.BootLoader Boot = new BootLoader.BootLoader();

        public OperationSystem()
        {

        }
    }
}

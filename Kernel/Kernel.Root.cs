using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;

namespace Kernel
{
    public partial class Kernel
    {
        
       public class Root
        {
            /// <summary>
            /// Делегат записи информации в файл
            /// </summary>
            /// <param name="path"></param>
            /// <param name="list"></param>
            public  delegate void WriteFile(string path,List<string> list);
            /// <summary>
            /// Имя Root пользователя
            /// </summary>
            static string Name;
            /// <summary>
            /// Пароль рут пользователя
            /// </summary>
            static string Password;
            
            public Root(string name,string password)
            {
                Name = name;
                Password = password;
            }
            public void SaveUser(WriteFile write)
            {

                List<string> list = new List<string>() { Name, Password };
                write("root.txt",list);
            }
            
            
        }
    }
}

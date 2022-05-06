using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HomeWork_8_module
{
    internal class Program
    {
       const string Path = @"C:\Users\peyur\OneDrive\Рабочий стол\Delete";
       static DirectoryInfo dI = new DirectoryInfo(Path);
       static void Main(string[] args)
        {
            // В корне проекта мы имеем папку Delete, в которой есть 1) подпапки в которых файлы 2) и в самой папке файлы
            

            try
            {
                if (Check(Path))
                {
                    DeletDirectory(dI);
                }
                
            }
            catch (Exception)
            {

                Console.WriteLine("Папка и файлы внутри удалены");
            }


        }
   
        /// <summary>
        /// Метод удалаяет необходимую нам папку
        /// </summary>
        static void DeletDirectory(DirectoryInfo dI)
        {
                // Первым делом удаляем файлы из папки
                
                FileInfo[] fls = dI.GetFiles();
                foreach (FileInfo f in fls)
                {

                    f.Delete();
                }

                //Получаем подпапки

                DirectoryInfo[] dir = dI.GetDirectories();

                foreach (DirectoryInfo e in dir)
                {
                    // Удаляем файлы в подпапке если они есть

                    FileInfo[] File = e.GetFiles();
                    foreach (FileInfo f in File)
                    {

                        f.Delete();
                    }

                   
                    // Удаляем подпапку

                    e.Delete();

                    // Если папка пуста то удаляем
                    if (dI.GetDirectories().Length == 0)
                    {
                        
                        dI.Delete();
                    }

                    // Удаляем рекурсивно
                    DeletDirectory(dI);

                }
            
           

            

        }
    
        /// <summary>
        /// Метод позволяющий проверить путь к папке,а также использование файлов в течении 30 минут
        /// </summary>
        /// <param name="Path"></param>
        /// <returns></returns>
        static bool Check (string Path)
        {
            DateTime time = DateTime.Now;   
            bool check = false;
            
            
            if (Directory.Exists(Path))
            {
                FileInfo FI = new FileInfo(Path);
                DateTime timeCreate = FI.CreationTime;
                TimeSpan result = time - timeCreate;

                if (result.Minutes > 30)
                {
                    Console.WriteLine("Найдена директория которая неиспользовалась 30 минут");
                    check = true;
                }
                else
                {
                    Console.WriteLine("Файлы использовализь в течении 30 минут");
                    check = false;

                }
            }
        
            else
                Console.WriteLine("Проверьте указанный путь или присутствие папки");

            return check;
        }
    }
}

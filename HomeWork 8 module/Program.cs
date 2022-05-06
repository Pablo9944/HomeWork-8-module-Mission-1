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
            //Напишите программу, которая чистит нужную нам папку от файлов  и папок, которые не использовались более 30 минут
            // Путь к удалению необходимой папки и файлов внутри
            

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
           
                FileInfo[] fls = dI.GetFiles();
                foreach (FileInfo f in fls)
                {

                    f.Delete();
                }

                DirectoryInfo[] dir = dI.GetDirectories();

                foreach (DirectoryInfo e in dir)
                {
                    FileInfo[] File = e.GetFiles();
                    foreach (FileInfo f in File)
                    {

                        f.Delete();
                    }


                    e.Delete();
                    if (dI.GetDirectories().Length == 0)
                    {
                        dI.Delete();
                    }
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

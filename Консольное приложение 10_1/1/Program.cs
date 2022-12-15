using System;
using System.IO;

namespace _1
{
    class Program
    {
        static void Print(DirectoryInfo dir)
        {
            FileInfo[] info = dir.GetFiles();
            Console.WriteLine("Содержимое о файлах в папке \n");
            foreach (FileInfo file in info)
            {
                Console.WriteLine("Имя файла: " + file.Name.ToString() + '\n' +
                   "Расширение файла: " + file.Extension.ToString() + '\n' +
                    "Размер файла (в байтах): " + file.Length.ToString() + '\n' +
                    "Время создания файла: " + file.CreationTime.ToString() + '\n');
            } 
        }
        static void Print_1(DirectoryInfo dir)
        {
            FileInfo[] info3 = dir.GetFiles();

            foreach (FileInfo file in info3)
            {
                Console.WriteLine("Имя файла: " + file.Name.ToString() + '\n' +
                   "Расширение файла: " + file.Extension.ToString() + '\n' +
                    "Размер файла (в байтах): " + file.Length.ToString() + '\n' +
                    "Файл доступен только для чтения или нет (True - Только для чтения, False - для чтения и записи): " + file.IsReadOnly.ToString() + '\n' +
                   "Время создания файла: " + file.CreationTime.ToString() + '\n' +
                    "Последнее время записи файла: " + file.LastWriteTime.ToString()+'\n');
            }
        }
        static void Main(string[] args)
        {
            //Создание папок
            if (Directory.Exists("C:\\temp"))
            {
                Directory.Delete("C:\\temp", true);
            }
            else
            {
                Directory.CreateDirectory("C:\\temp");
            }
            Directory.CreateDirectory("C:\\temp\\K1");
            Directory.CreateDirectory("C:\\temp\\K2");
            //Создание файла t1.txt
            StreamWriter t1 = new StreamWriter("C:\\temp\\K1\\t1.txt", false);
            t1.WriteLine("Кузьминова Наталья Михайловна, 1983 года рождения, место жительства р.п.Гремячево");
            t1.Close();
            //Создание файла t2.txt
            StreamWriter t2 = new StreamWriter("C:\\temp\\K1\\t2.txt", false);
            t2.WriteLine("Кузьминов Виктор Иванович, 1982 года рождения, место жительства р.п.Гремячево");
            t2.Close();
            //Создание файла t3.txt
            StreamWriter t3 = new StreamWriter("C:\\temp\\K2\\t3.txt", false);
            string str;
            StreamReader sr_t1 = new StreamReader("C:\\temp\\K1\\t1.txt");
            str = sr_t1.ReadToEnd();
            sr_t1.Close();
            t3.WriteLine(str);
            StreamReader sr_t2 = new StreamReader("C:\\temp\\K1\\t2.txt");
            str = sr_t2.ReadToEnd();
            sr_t2.Close();
            t3.WriteLine(str);
            t3.Close();
            //Информация о файлах
            DirectoryInfo dir1 = new DirectoryInfo("C:\\temp\\K1");
            DirectoryInfo dir2 = new DirectoryInfo("C:\\temp\\K2");
            Print(dir1);
            Print(dir2);
            //Перемещение
            File.Move("C:\\temp\\K1\\t2.txt", "C:\\temp\\K2\\t2.txt");
            //Копирование с перезапесью(если файл есть)
            File.Copy("C:\\temp\\K1\\t1.txt", "C:\\temp\\K2\\t1.txt", true);
            //Переменование файла K2 в ALL
            Directory.Move("C:\\temp\\K2", "C:\\temp\\ALL");
            //Удаление папки K1 и все файлы в нём
            Directory.Delete("C:\\temp\\K1", true);

            Console.WriteLine("\nИнформация в папке ALL:\n");
            DirectoryInfo dir3 = new DirectoryInfo("C:\\temp\\ALL");
            Print_1(dir3);
        }
    }
}


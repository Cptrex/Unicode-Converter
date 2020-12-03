using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using Unicode_Converter;

namespace UnicodeConverter
{
    class Converter
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Введите название файла(с расширением): ");
                string fileName = Console.ReadLine();
                Console.Write("Введите путь к файлу: ");
                string path = Console.ReadLine();

                FileInputData TargetFile = new FileInputData(fileName, path);

                if (TargetFile.Size > 51200)
                {
                    Console.WriteLine("Размер файла превышает допустимое значение в 50 мб");
                }
                string readText = File.ReadAllText(TargetFile.InputPath);

                string dir = TargetFile.OutputPath + @"\OutputFolder";

                if (!Directory.Exists(dir))  Directory.CreateDirectory(dir);

                dir += @"\" + TargetFile.FullName;
                
                StreamWriter sw = null;
                if (!File.Exists(dir))
                {
                    sw = new StreamWriter(File.Open(dir, FileMode.CreateNew), Encoding.UTF8);
                    sw.Close();
                }
                using (StreamWriter file = new StreamWriter(dir, true, Encoding.UTF8))
                {
                    file.Write(readText);
                    file.Close();
                }
                foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(TargetFile))
                {
                    string name = descriptor.Name;
                    object value = descriptor.GetValue(TargetFile);
                    Console.WriteLine($"{name} = {value}");
                }
            }
            catch(Exception ex) { Console.WriteLine($"Что-то пошло не так! |{ex}|"); }
        }
    }
}
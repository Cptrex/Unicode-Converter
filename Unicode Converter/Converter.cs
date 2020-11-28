using System;
using System.ComponentModel;
using System.IO;
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
                string readText = File.ReadAllText(TargetFile.InputPath);
                Console.WriteLine(readText);
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
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Unicode_Converter
{
    class FileInputData
    {
        public string Name { get; set; }
        public string FullName { get; set; }
        public string InputPath { get; set; }
        public string OutputPath { get; set; }
        public string Encoding { get; set; }
        public long Size { get; set; } = 0; 
        public string Extension { get; set; }
       public FileInputData(string name, string inputPath)
        {
            FileInfo fi = new FileInfo(inputPath + @"\" + name);
            Size = fi.Length;
            Extension = fi.Extension;
            FullName = fi.Name;
            InputPath = fi.DirectoryName + @"\" + FullName;
            Name = FullName.Replace(fi.Extension, "");
            OutputPath = InputPath.Replace(FullName, "");
        }
    }
}
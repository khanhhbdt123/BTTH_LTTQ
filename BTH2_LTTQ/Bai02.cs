using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace BTH2_LTTQ
{
    class Bai02
    {
        public static void Run()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            Console.Write("Nhap duong dan thu muc: ");
            string path = Console.ReadLine();
            if (!Directory.Exists(path))
            {
                Console.WriteLine("Khong tim thay thu muc.");
                return;
            }
            DirectoryInfo dir = new DirectoryInfo(path);
            FileSystemInfo[] entries = dir.GetFileSystemInfos();
            Console.WriteLine("Directory of "+ path);
            foreach (var entry in entries)
            {
                string date = entry.LastWriteTime.ToString("dd/MM/yyyy  hh:mm tt");
                string type;
                string size = "";
                if (entry is DirectoryInfo)
                {
                    type = "<DIR>";
                }
                else
                {
                    FileInfo file = (FileInfo)entry;
                    type = "";
                    size = file.Length.ToString("N0");
                }
                string name = entry.Name;
                if (entry is DirectoryInfo)
                    Console.WriteLine(date + "    " + type.PadRight(15) + "   " + name);
                else
                    Console.WriteLine(date + "    " + size.PadLeft(15) + "   " + name);
            }
        }
    }
}
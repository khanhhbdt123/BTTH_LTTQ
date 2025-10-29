using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BTH2_LTTQ
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice;
            do
            {
                Console.WriteLine("===MENU===");
                Console.WriteLine("1. Bai 1.");
                Console.WriteLine("2. Bai 2.");
                Console.WriteLine("3. Bai 3.");
                Console.WriteLine("4. Bai 4.");
                Console.WriteLine("5. Bai 5.");
                Console.WriteLine("0. Thoat chuong trinh.");
                Console.Write("Nhap lua chon: ");
                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.Write("Lua chon khong hop le. Vui long nhap lai lua chon: ");
                }
                switch (choice)
                {
                    case 1:
                        Bai01.Run();
                        break;
                    case 2:
                        Bai02.Run();
                        break;
                    case 3:
                        Bai03.Run();
                        break;
                    case 4:
                        Bai04.Run();
                        break;
                    case 5:
                        Bai05.Run();
                        break;
                    case 0:
                        Console.WriteLine("Thoat chuong trinh.");
                        break;
                    default:
                        Console.WriteLine("Lua chon khong hop le!");
                        break;
                }
            }
            while (choice != 0);
        }
    }
}
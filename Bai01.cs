using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BTH2_LTTQ
{
    class Bai01
    {
        static bool ktNamNhuan(int nam)
        {
            return (nam % 400 == 0 || nam % 100 != 0 && nam % 4 == 0);
        }
        static bool ktHopLe(int thang, int nam)
        {
            if (thang < 1 || thang > 12) return false;
            if (nam < 1) return false;
            return true;
        }
        public static void Run()
        {
            Console.WriteLine("Nhap thang: ");
            if (!int.TryParse(Console.ReadLine(), out int thang))
            {
                Console.WriteLine("Thang vua nhap khong hop le.");
                return;
            }    
            Console.WriteLine("Nhap nam: ");
            if (!int.TryParse(Console.ReadLine(), out int nam))
            {
                Console.WriteLine("Nam vua nhap khong hop le.");
                return;
            }
            if (!ktHopLe(thang, nam))
            {
                Console.WriteLine("Thang nam vua nhap khong hop le.");
                return;
            }
            Console.WriteLine("In lich thang " + thang + " nam " + nam);
            Console.WriteLine("Sun Mon Tue Wed Thu Fri Sat");
            int[] soNgayTrongThang = { 31, ktNamNhuan(nam) ? 29 : 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            int soNgay = soNgayTrongThang[thang - 1];
            DateTime ngayDau = new DateTime(nam, thang, 1);
            int ngayBatDau = (int)ngayDau.DayOfWeek;
            for (int i = 0; i < ngayBatDau; i++)
                Console.Write("    ");
            for (int ngay = 1; ngay <= soNgay; ngay++)
            {
                if (ngay / 10 == 0) Console.Write(ngay + "   ");
                else if (ngay / 10 > 0) Console.Write(ngay + "  ");
                ngayBatDau++;
                if (ngayBatDau > 6)
                {
                   ngayBatDau = 0;
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
        }
    }
}
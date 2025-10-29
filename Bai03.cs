using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTH2_LTTQ
{
    class Bai03
    {
        static bool laSNT(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i * i <= n; i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }
        static void nhapMaTran(int[,]a, int n, int m)
        {
            Console.Write("Nhap cac phan tu cua ma tran (cac phan tu cach nhau bang dau cach): ");
            string[] parts = Console.ReadLine().Trim().Split(' ');
            int k = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    a[i, j] = int.Parse(parts[k++]);
            }    
        }
        static void xuatMaTran(int[,]a, int n, int m)
        {
            Console.WriteLine("Ma tran: ");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(a[i, j] + " ");
                }
                Console.WriteLine();
            }    
        }
        static void timKiemPhanTu(int[,] a, int n, int m)
        {
            Console.Write("Nhap phan tu can tim: ");
            int x;
            while (!int.TryParse(Console.ReadLine(), out x))
            {
                Console.Write("Nhap khong hop le! Nhap lai phan tu can tim kiem: ");
            }
            bool found = false;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (a[i, j] == x)
                    {
                        Console.WriteLine("Tim thay " + x + " tai dong " + (i + 1) + ", cot " + (j + 1));
                        found = true;
                    }
                }
            }
            if (!found)
                Console.WriteLine("Khong tim thay " + x + " trong ma tran.");
        }
        static void xuatSNT(int[,]a, int n, int m)
        {
            Console.Write("Cac phan tu la so nguyen to: ");
            HashSet<int> daXuat = new HashSet<int>();
            bool timSNT = false;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    int x = a[i, j];
                    if (laSNT(x) && !daXuat.Contains(x))
                    {
                        Console.Write(x + " ");
                        daXuat.Add(x);
                        timSNT = true;
                    }
                }
            }
            if (!timSNT) Console.WriteLine("Khong co so nguyen to trong ma tran.");
            else Console.WriteLine();
        }
        static void dongNhieuSNTNhat(int[,] a, int n, int m)
        {
            int dongMax = 0;
            int soSNTMax = 0;
            for (int i = 0; i < n; i++)
            {
                int dem = 0;
                for (int j = 0; j < m; j++)
                    if (laSNT(a[i, j])) dem++;
                if (dem > soSNTMax)
                {
                    soSNTMax = dem;
                    dongMax = i;
                }
            }
            if (soSNTMax == 0) Console.WriteLine("Khong co so nguyen to nao trong ma tran.");
            else Console.WriteLine("Dong co nhieu so nguyen to nhat la dong " + (dongMax + 1) + " co " + soSNTMax + " so nguyen to.");
        }
        public static void Run()
        {
            Console.Write("Nhap so dong: ");
            int n;
            while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
            {
                Console.Write("Nhap khong hop le! Vui long nhap lai so dong: ");
            }
            Console.Write("Nhap so cot: ");
            int m;
            while (!int.TryParse(Console.ReadLine(), out m) || m <= 0)
            {
                Console.Write("Nhap khong hop le! Vui long nhap lai so cot: ");
            }
            int[,] a = new int[n, m];
            nhapMaTran(a, n, m);
            xuatMaTran(a, n, m);
            int choice;
            do
            {
                Console.WriteLine("===MENU BAI 3===");
                Console.WriteLine("1. Tim kiem mot phan tu trong ma tran.");
                Console.WriteLine("2. Xuat cac phan tu la so nguyen to.");
                Console.WriteLine("3. Cho biet dong co nhieu so nguyen to nhat.");
                Console.WriteLine("0. Thoat chuong trinh bai 3.");
                Console.Write("Nhap lua chon: ");
                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.Write("Lua chon khong hop le! Vui long nhap lai lua chon: ");
                }
                switch (choice)
                {
                    case 1:
                        timKiemPhanTu(a, n, m);
                        break;
                    case 2:
                        xuatSNT(a, n, m);
                        break;
                    case 3:
                        dongNhieuSNTNhat(a, n, m);
                        break;
                    case 0:
                        Console.WriteLine("Thoat chuong trinh bai 3.");
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
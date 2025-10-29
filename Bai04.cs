using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTH2_LTTQ
{
    class cPhanSo
    {
        private int tu;
        private int mau;
        public cPhanSo(int Tu = 0, int Mau = 1)
        {
            if (Mau == 0) Mau = 1;
            tu = Tu;
            mau = Mau;
            RutGon();
        }
        public void Nhap()
        {
            Console.Write("Nhap tu so: ");
            while (!int.TryParse(Console.ReadLine(), out tu))
            {
                Console.Write("Tu vua nhap khong hop le. Vui long nhap lai tu: ");
            }
            Console.Write("Nhap mau so: ");
            while (!int.TryParse(Console.ReadLine(), out mau))
            {
                Console.Write("Mau vua nhap khong hop le. Vui long nhap lai mau: ");
            }
            if (mau == 0)
            {
                Console.WriteLine("Dat mac dinh mau = 1.");
                mau = 1;
            }
            RutGon();
        }
        public void Xuat()
        {
            if (mau == 1) Console.Write(tu);
            else Console.Write(tu + "/" + mau);
        }
        private int UCLN(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            while (b != 0)
            {
                int temp = a % b;
                a = b;
                b = temp;
            }
            return a;
        }
        private void RutGon()
        {
            int u = UCLN(tu, mau);
            tu /= u;
            mau /= u;
            if (mau < 0)
            {
                tu = -tu;
                mau = -mau;
            }    
        }
        public static cPhanSo operator + (cPhanSo a, cPhanSo b)
        {
            return new cPhanSo(a.tu * b.mau + a.mau * b.tu, a.mau * b.mau);
        }
        public static cPhanSo operator - (cPhanSo a, cPhanSo b)
        {
            return new cPhanSo(a.tu * b.mau - a.mau * b.tu, a.mau * b.mau);
        }
        public static cPhanSo operator * (cPhanSo a, cPhanSo b)
        {
            return new cPhanSo(a.tu * b.tu, a.mau * b.mau);
        }
        public static cPhanSo operator / (cPhanSo a, cPhanSo b)
        {
            if (b.tu == 0)
            {
                Console.WriteLine("Khong the thuc hien phep chia.");
                Console.Write("Tra ve phan so thu nhat: ");
                return a;
            }           
            return new cPhanSo(a.tu * b.mau, a.mau * b.tu);
        }
        public double GiaTri()
        {
            return (double)tu / mau;
        }
    }
    class Bai04
    {
        public static void Run()
        {
            int choice;
            do
            {
                Console.WriteLine("===MENU BAI 4===");
                Console.WriteLine("1. Nhap 2 phan so va xuat ket qua cong, tru, nhan, chia.");
                Console.WriteLine("2. Nhap day phan so, tim phan so lon nhat va sap xep tang dan.");
                Console.WriteLine("0. Thoat chuong trinh bai 4.");
                Console.Write("Nhap lua chon: ");
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Lua chon khong hop le!");
                    continue;
                }
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Nhap phan so thu nhat:");
                        cPhanSo a = new cPhanSo();
                        a.Nhap();
                        Console.WriteLine("Nhap phan so thu hai:");
                        cPhanSo b = new cPhanSo();
                        b.Nhap();
                        Console.Write("Tong 2 phan so: ");
                        (a + b).Xuat();
                        Console.WriteLine();
                        Console.Write("Hieu 2 phan so: ");
                        (a - b).Xuat();
                        Console.WriteLine();
                        Console.Write("Tich 2 phan so: ");
                        (a * b).Xuat();
                        Console.WriteLine();
                        Console.Write("Thuong 2 phan so: ");
                        (a / b).Xuat();
                        Console.WriteLine();
                        break;
                    case 2:
                        Console.Write("Nhap so luong phan so: ");
                        if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
                        {
                            Console.WriteLine("Nhap so luong khong hop le!");
                            break;
                        }
                        cPhanSo[] arr = new cPhanSo[n];
                        for (int i = 0; i < n; i++)
                        {
                            Console.WriteLine("Nhap phan so thu " + (i + 1));
                            arr[i] = new cPhanSo();
                            arr[i].Nhap();
                        }
                        cPhanSo max = arr[0];
                        for (int i = 1; i < n; i++)
                        {
                            if (arr[i].GiaTri() > max.GiaTri()) max = arr[i];
                        }
                        Console.Write("Phan so lon nhat trong day: "); max.Xuat();
                        Console.WriteLine();
                        for (int i = 0; i < n-1; i++)
                        {
                            for (int j = i + 1; j < n; j++)
                            {
                                if (arr[i].GiaTri() > arr[j].GiaTri())
                                {
                                    cPhanSo temp = arr[i];
                                    arr[i] = arr[j];
                                    arr[j] = temp;
                                }    
                            }    
                        }
                        Console.WriteLine("Day phan so sau khi sap xep tang dan:");
                        for (int i = 0; i < n; i++)
                        {
                            arr[i].Xuat();
                            if (i < n - 1) Console.Write(", ");
                        }
                        Console.WriteLine();
                        break;
                    case 0:
                        Console.WriteLine("Thoat chuong trinh bai 4.");
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
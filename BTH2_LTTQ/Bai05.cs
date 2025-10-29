using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTH2_LTTQ
{
    class KhuDat
    {
        private string DiaDiem;
        private double GiaBan;
        private double DienTich;
        public string layDiaDiem() { return DiaDiem; }
        public double layGiaBan() { return GiaBan; }
        public double layDienTich() { return DienTich; }
        public KhuDat() { }
        public KhuDat(string diaDiem, double giaBan, double dienTich)
        {
            DiaDiem = diaDiem;
            GiaBan = giaBan;
            DienTich = dienTich;
        }
        public virtual void Nhap()
        {
            Console.Write("Nhap dia diem: ");
            DiaDiem = Console.ReadLine();
            Console.Write("Nhap gia ban: ");
            GiaBan = double.Parse(Console.ReadLine());
            Console.Write("Nhap dien tich: ");
            DienTich = double.Parse(Console.ReadLine());
        }
        public virtual void Xuat()
        {
            Console.WriteLine("Dia diem: " + DiaDiem + ", gia ban: " + GiaBan + ", dien tich: " + DienTich);
        }
    }
    class NhaPho : KhuDat
    {
        private int NamXayDung;
        private int SoTang;
        public int layNamXayDung() { return NamXayDung; }
        public int laySoTang() { return SoTang; }
        public NhaPho() { }
        public NhaPho(string diaDiem, double giaBan, double dienTich, int namXayDung, int soTang) : base(diaDiem, giaBan, dienTich)
        {
            NamXayDung = namXayDung;
            SoTang = soTang;
        }
        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Nhap nam xay dung: ");
            NamXayDung = int.Parse(Console.ReadLine());
            Console.Write("Nhap so tang: ");
            SoTang = int.Parse(Console.ReadLine());
        }
        public override void Xuat()
        {
            base.Xuat();
            Console.WriteLine("Nam xay dung: " + NamXayDung + ", co " + SoTang + " tang. ");
        }
    }
    class ChungCu : KhuDat
    {
        private int Tang;
        public int layTang() { return Tang; }
        public ChungCu() { }
        public ChungCu(string diaDiem, double giaBan, double dienTich, int tang) : base(diaDiem, giaBan, dienTich)
        {
            Tang = tang;
        }
        public override void Nhap()
        {   
            base.Nhap();
            Console.Write("Nhap tang: ");
            Tang = int.Parse(Console.ReadLine());
        }
        public override void Xuat()
        {
            base.Xuat();
            Console.WriteLine("Tang: " + Tang);
        }
    }
    class QuanLyBDS
    {
        private KhuDat[] ds;
        private int n;
        public void NhapDanhSach()
        {
            Console.Write("Nhap so luong bat dong san: ");
            n=int.Parse(Console.ReadLine());
            ds = new KhuDat[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Nhap loai bat dong san thu " + (i + 1));
                Console.WriteLine("1. Khu dat.");
                Console.WriteLine("2. Nha pho.");
                Console.WriteLine("3. Chung cu.");
                Console.Write("Chon: ");
                int chon = int.Parse(Console.ReadLine());
                switch(chon)
                {
                    case 1:
                        ds[i] = new KhuDat();
                        break;
                    case 2:
                        ds[i] = new NhaPho();
                        break;
                    case 3:
                        ds[i] = new ChungCu();
                        break;
                    default:
                        Console.WriteLine("Lua chon khong hop le, mac dinh la khu dat.");
                        ds[i] = new KhuDat();
                        break;
                }
                ds[i].Nhap();
            } 
                
        }
        public void XuatDanhSach()
        {
            Console.WriteLine("===Danh sach bat dong san===");
            for (int i = 0;i < n; i++)
            {
                Console.WriteLine("Bat dong san thu " + (i + 1) + ": ");
                ds[i].Xuat();
            } 
                
        }
        public void TongGiaBanChoMoiLoai()
        {
            double tongGiaKD = 0, tongGiaNP = 0, tongGiaCC = 0;
            for (int i = 0; i < n; i++)
            {
                if (ds[i] is NhaPho)
                    tongGiaNP += ds[i].layGiaBan();
                else if (ds[i] is ChungCu)
                        tongGiaCC += ds[i].layGiaBan();
                else tongGiaKD += ds[i].layGiaBan();
            }
            Console.WriteLine("===Tong gia ban cho moi loai bat dong san===");
            Console.WriteLine("Khu dat: " + tongGiaKD + " VND");
            Console.WriteLine("Nha pho: " + tongGiaNP + " VND");
            Console.WriteLine("Chung cu: " + tongGiaCC + " VND");
        }
        public void XuatTheoDieuKien()
        {
            Console.WriteLine("===Cac bat dong san thoa dieu kien===");
            bool k = false;
            for (int i = 0; i < n; i++)
            {
                if (ds[i] is NhaPho)
                {
                    NhaPho NP = (NhaPho)ds[i];
                    if (NP.layDienTich() > 60 && NP.layNamXayDung() >= 2019)
                    {
                        NP.Xuat();
                        k = true;
                    }       
                }
                else if (!(ds[i] is NhaPho) && !(ds[i] is ChungCu))
                {
                    if (ds[i].layDienTich() > 100)
                    {
                        ds[i].Xuat();
                        k = true;
                    }
                }
            }
            if (!k)
            {
                Console.WriteLine("Khong co bat dong san nao thoa dieu kien.");
            }    
        }
        public void TimKiemBDS()
        {
            Console.Write("Nhap dia diem can tim: ");
            string DiaDiemTim = Console.ReadLine().ToLower();
            Console.Write("Nhap gia tim kiem: ");
            double GiaTim=double.Parse(Console.ReadLine());
            Console.Write("Nhap dien tich tim kiem: ");
            double DienTichTim = double.Parse(Console.ReadLine());
            bool found = false;
            Console.WriteLine("===Bat dong san thoa yeu cau tim kiem===");
            for (int i = 0; i < n; i++)
            {
                if ((ds[i] is NhaPho || ds[i] is ChungCu) && 
                    ds[i].layDiaDiem().ToLower().Contains(DiaDiemTim) &&
                    ds[i].layGiaBan() <= GiaTim &&
                    ds[i].layDienTich() >= DienTichTim)
                {
                    found = true;
                    Console.WriteLine("Bat dong san thu " + (i + 1) + " trong danh sach:");
                    ds[i].Xuat();
                }    
            }
            if (!found)
                Console.WriteLine("Khong tim thay bat dong san phu hop.");
        }
    }
    class Bai05
    {
        public static void Run()
        {
            QuanLyBDS quanLyBDS = new QuanLyBDS();
            int choice;
            do
            {
                Console.WriteLine("===MENU BAI 5===");
                Console.WriteLine("1. Nhap danh sach bat dong san.");
                Console.WriteLine("2. Xuat danh sach bat dong san.");
                Console.WriteLine("3. Tong gia ban cho moi loai bat dong san.");
                Console.WriteLine("4. Xuat danh sach khu dat / nha pho theo dieu kien.");
                Console.WriteLine("5. Tim kiem nha pho / chung cu.");
                Console.WriteLine("0. Thoat chuong trinh bai 5.");
                Console.Write("Nhap lua chon: ");
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Lua chon khong hop le!");
                    continue;
                }  
                switch(choice)
                {
                    case 1:
                        quanLyBDS.NhapDanhSach();
                        break;
                    case 2:
                        quanLyBDS.XuatDanhSach();
                        break;
                    case 3:
                        quanLyBDS.TongGiaBanChoMoiLoai();
                        break;
                    case 4:
                        quanLyBDS.XuatTheoDieuKien();
                        break;
                    case 5:
                        quanLyBDS.TimKiemBDS();
                        break;
                    case 0:
                        Console.WriteLine("Thoat chuong trinh bai 5.");
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
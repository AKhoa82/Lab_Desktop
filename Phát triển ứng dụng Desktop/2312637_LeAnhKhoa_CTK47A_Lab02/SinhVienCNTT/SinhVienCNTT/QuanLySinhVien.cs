using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SinhVienCNTT
{
    public delegate int SoSanh(object sv1, object sv2);
    public class QuanLySinhVien
    {
        public ArrayList dsSinhVien;
        public QuanLySinhVien()
        {
            dsSinhVien = new ArrayList();
        }
        public SinhVien this[int index]
        {
            get { return (SinhVien)this.dsSinhVien[index]; }
            set { dsSinhVien[index] = value; }
        }

        public void Them(SinhVien sv)
        {
            this.dsSinhVien.Add(sv);
        }

        public SinhVien Tim(object obj, SoSanh ss)
        {
            SinhVien svresult = null;
            foreach (SinhVien sv in dsSinhVien)
                if (ss(obj, sv) == 0) 
                {
                    svresult = sv;
                    break;
                }    
            return svresult;
        }

        public bool Sua(SinhVien svsua, object obj, SoSanh ss)
        {
            int i, count;
            bool kq = false;
            count = this.dsSinhVien.Count;
            for (i = 0; i < count; i++)
                if (ss(obj, this[i]) == 0)
                {
                    this[i] = svsua;
                    kq = true;
                    break;
                }
            return kq;
        }

        public void Xoa(object obj, SoSanh ss)
        {
            int i = dsSinhVien.Count - 1;
            for (; i >= 0; i--)
                if (ss(obj, this[i]) == 0)
                    this.dsSinhVien.RemoveAt(i);
        }

        public void DocTuFile(string filename)
        {
            dsSinhVien.Clear();
            string t;
            string[] s;
            SinhVien sv;
            using (StreamReader sr = new StreamReader(new FileStream(filename, FileMode.Open)))
            {
                while ((t = sr.ReadLine()) != null) 
                {
                    s = t.Split(';');
                    sv = new SinhVien();
                    sv.MSSV = s[0];
                    sv.HoTen = s[1];
                    sv.Phai = false;
                    if (s[2] == "1")
                        sv.Phai = true;
                    sv.NgaySinh = DateTime.ParseExact(s[3], "d/M/yyyy", CultureInfo.InvariantCulture);
                    sv.Lop = s[4];
                    sv.SoDienThoai = s[5];
                    sv.Email = s[6];
                    sv.DiaChi = s[7];
                    sv.Hinh = s[8];
                    this.Them(sv);
                }    
            } 
        }

        public void GhiVaoFile(string filename)
        {
            using (StreamWriter sw = new StreamWriter(filename))
            {
                foreach(SinhVien sv in dsSinhVien)
                {
                    string line = $"{sv.MSSV};{sv.HoTen};{(sv.Phai ? "1" : "0")};{sv.NgaySinh:dd/MM/yyyy};{sv.Lop};{sv.SoDienThoai};{sv.Email};{sv.DiaChi};{sv.Hinh}";
                    sw.WriteLine(line);
                }    
            }    
        }
    }
}

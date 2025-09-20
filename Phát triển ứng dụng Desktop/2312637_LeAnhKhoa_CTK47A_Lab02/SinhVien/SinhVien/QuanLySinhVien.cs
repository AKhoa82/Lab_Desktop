using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSinhVien
{
    public delegate int SoSanh(object sv1, object sv2);
    public class QuanLySinhVien
    {
        public List<SinhVien> dsSinhVien;
        public QuanLySinhVien()
        {
            dsSinhVien = new List<SinhVien>();
        }
        public SinhVien this[int index]
        {
            get { return this.dsSinhVien[index]; }
            set { dsSinhVien[index] = value; }
        }

        public void Them(SinhVien sv)
        {
            foreach (SinhVien s in dsSinhVien)
            {
                if (s.MaSo == sv.MaSo)
                {
                    MessageBox.Show("Mã sinh viên đã tồn tại, không thể thêm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            this.dsSinhVien.Add(sv);
        }
        public SinhVien Tim(object obj, SoSanh ss)
        {
            foreach (SinhVien sv in dsSinhVien)
                if (ss(obj, sv) == 0)
                    return sv;
            return null;
        }
        public bool Sua(SinhVien svsua, object obj, SoSanh ss)
        {
            for (int i = 0; i < dsSinhVien.Count; i++)
            {
                if (ss(obj, this[i]) == 0)
                {
                    this[i] = svsua;
                    return true;
                }
            }
            return false;
        }
        public void Xoa(object obj, SoSanh ss)
        {
            for (int i = dsSinhVien.Count - 1; i >= 0; i--) 
                if (ss(obj, this[i]) == 0)
                    this.dsSinhVien.RemoveAt(i);
        }
        public void DocTuFile(string filename)
        {
            string t;
            string[] s;
            SinhVien sv;
            using (StreamReader sr = new StreamReader(new FileStream(filename, FileMode.Open)))
            {
                while ((t = sr.ReadLine()) != null)
                {
                    s = t.Split(';');
                    sv = new SinhVien();
                    sv.MaSo = s[0];
                    sv.HoTen = s[1];
                    sv.NgaySinh = DateTime.ParseExact(s[2], "d/M/yyyy", CultureInfo.InvariantCulture);
                    sv.DiaChi = s[3];
                    sv.Lop = s[4];
                    sv.Hinh = s[5];
                    sv.GioiTinh = false;
                    if (s[6] == "1")
                        sv.GioiTinh = true;
                    string[] cn = s[7].Split(',');
                    foreach (string c in cn)
                        sv.ChuyenNganh.Add(c);
                    this.Them(sv);
                }
            }
        }
    }
}

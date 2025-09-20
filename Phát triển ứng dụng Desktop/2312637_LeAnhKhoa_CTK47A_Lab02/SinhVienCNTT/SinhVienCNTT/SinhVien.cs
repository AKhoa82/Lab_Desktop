using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinhVienCNTT
{
    public class SinhVien
    {
        public string MSSV { get; set; }
        public string HoTen {  get; set; }
        public bool Phai {  get; set; }
        public DateTime NgaySinh {  get; set; }
        public string Lop {  get; set; }
        public string SoDienThoai {  get; set; }
        public string Email {  get; set; }
        public string DiaChi {  get; set; }
        public string Hinh {  get; set; }

        public SinhVien()
        {
            
        }

        public SinhVien(string mSSV, string hoTen, bool phai, DateTime ngaySinh, string lop, string soDienThoai, string email, string diaChi, string hinh)
        {
            this.MSSV = mSSV;
            this.HoTen = hoTen;
            this.Phai = phai;
            this.NgaySinh = ngaySinh;
            this.Lop = lop;
            this.SoDienThoai = soDienThoai;
            this.Email = email;
            this.DiaChi = diaChi;
            this.Hinh = hinh;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocTapTinJSON
{
    public class StudentInfo
    {
        public string MSSV {  get; set; }
        public string HoTen {  get; set; }
        public int Tuoi {  get; set; }
        public double Diem {  get; set; }
        public bool TonGiao {  get; set; }
        public StudentInfo(string mSSV, string hoTen, int tuoi, double diem, bool tonGiao)
        {
            this.MSSV = mSSV;
            this.HoTen = hoTen;
            this.Tuoi = tuoi;
            this.Diem = diem;
            this.TonGiao = tonGiao;
        }
    }
}

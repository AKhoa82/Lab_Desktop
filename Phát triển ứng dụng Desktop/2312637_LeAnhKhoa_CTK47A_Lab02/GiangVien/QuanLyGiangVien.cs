using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiangVien
{
    public class QuanLyGiangVien
    {
        enum KieuTim 
        { 
            TheoMa, 
            TheoHoTen, 
            TheoSDT 
        }
        public delegate int SoSanh(object a, object b); 
        private List<GiangVien> dsGiangVien; 
        public GiangVien this[int index]
        {
            get { return dsGiangVien[index]; }
            set { dsGiangVien[index] = value; }
        }
        public QuanLyGiangVien() 
        { 
            dsGiangVien = new List<GiangVien>(); 
        }
        public void SapXep(SoSanh ss)
        {
            for (int i = 0; i < dsGiangVien.Count - 1; i++) 
                for (int j = i + 1; j < dsGiangVien.Count; j++) 
                    if (ss(dsGiangVien[i], dsGiangVien[j]) > 0) 
                    {
                        GiangVien gv = dsGiangVien[i];
                        dsGiangVien[i] = dsGiangVien[j];
                        dsGiangVien[j] = gv;
                    }    
        }
        //public void SapXep(SoSanh ss)
        //{
        //    dsGiangVien.Sort((x, y) => ss(x, y));
        //}
        public bool Them(GiangVien gv)
        {
            foreach (GiangVien item in dsGiangVien)
                if (item.MaSo == gv.MaSo)
                    return false;
            dsGiangVien.Add(gv);
            return true;
        }
        public GiangVien Tim(object temp,SoSanh ss)
        {
            foreach (GiangVien gv in dsGiangVien)
                if (ss(temp, gv) == 0)
                    return gv;
            return null;
        }
        public void Xoa(object temp,SoSanh ss)
        {
            for (int i = 0; i < dsGiangVien.Count; i++)
                if (ss(temp, dsGiangVien[i]) == 0) 
                {
                    dsGiangVien.RemoveAt(i);
                    return;
                }    
        }
    }
}

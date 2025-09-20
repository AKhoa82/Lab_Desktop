using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GiangVien
{
    public partial class frmTim : Form
    {
        private QuanLyGiangVien dsGV;
        public frmTim(QuanLyGiangVien dsgv)
        {
            InitializeComponent();
            dsGV = dsgv;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string giaTri = txtGiaTriTim.Text.Trim();
            if (string.IsNullOrEmpty(giaTri)) 
            {
                MessageBox.Show("Vui lòng nhập thông tin cần tìm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            QuanLyGiangVien.SoSanh ss = null;

            if (rdMaGV.Checked)
            {
                ss = delegate (object a, object b)
                {
                    return ((GiangVien)b).MaSo.CompareTo(a.ToString());
                };
            }
            else if (rdHoTen.Checked)
            {
                ss = delegate (object a, object b)
                {
                    return ((GiangVien)b).HoTen.CompareTo(a.ToString());
                };
            }
            else if (rdSoDT.Checked)
            {
                ss = delegate (object a, object b)
                {
                    return ((GiangVien)b).SoDT.CompareTo(a.ToString());
                };
            }

            GiangVien kq = dsGV.Tim(giaTri, ss);
            if (kq != null)
            {
                frmTBGiangVien frm = new frmTBGiangVien();
                frm.SetText(kq.ToString());
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

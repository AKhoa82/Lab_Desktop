using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SinhVien
{
    public enum KieuTuyChon
    {
        MaSV,
        HoTen,
        NgaySinh
    }

    public partial class frmTuyChon : Form
    {
        public KieuTuyChon Kieu { get; set; }
        public string ChuoiTim {  get; set; }
        public frmTuyChon()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSapXep_Click(object sender, EventArgs e)
        {
            if (rdMaSV.Checked)
                Kieu = KieuTuyChon.MaSV;
            else if (rdHoTen.Checked)
                Kieu = KieuTuyChon.HoTen;
            else if (rdNgaySinh.Checked)
                Kieu = KieuTuyChon.NgaySinh;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void frmTuyChon_Load(object sender, EventArgs e)
        {
            rdMaSV.Checked = true;
            Kieu = KieuTuyChon.MaSV;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtNhapThongTin.Text.Trim();
            if (string.IsNullOrEmpty(tuKhoa))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm!", "Thông báo");
                return;
            }

            ChuoiTim = tuKhoa; 

            if (rdMaSV.Checked)
                Kieu = KieuTuyChon.MaSV;
            else if (rdHoTen.Checked)
                Kieu = KieuTuyChon.HoTen;
            else if (rdNgaySinh.Checked)
                Kieu = KieuTuyChon.NgaySinh;
            else
            {
                MessageBox.Show("Vui lòng chọn kiểu tìm kiếm!", "Thông báo");
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

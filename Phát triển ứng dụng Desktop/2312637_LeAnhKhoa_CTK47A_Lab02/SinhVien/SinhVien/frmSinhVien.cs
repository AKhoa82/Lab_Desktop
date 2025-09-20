using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SinhVien;

namespace QLSinhVien
{
    public partial class frmSinhVien : Form
    {
        private QuanLySinhVien qlsv;
        public frmSinhVien()
        {
            InitializeComponent();
            qlsv = new QuanLySinhVien();
        }
        private void ThemSV(SinhVien sv)
        {
            ListViewItem lvitem = new ListViewItem(sv.MaSo);
            lvitem.SubItems.Add(sv.HoTen);
            lvitem.SubItems.Add(sv.NgaySinh.ToShortDateString());
            lvitem.SubItems.Add(sv.DiaChi);
            lvitem.SubItems.Add(sv.Lop);
            string gt = "Nữ";
            if (sv.GioiTinh)
                gt = "Nam";
            lvitem.SubItems.Add(gt);
            string cn = "";
            foreach (string s in sv.ChuyenNganh)
                cn += s + ",";
            if (!string.IsNullOrEmpty(cn))
                cn = cn.Substring(0, cn.Length - 1);
            lvitem.SubItems.Add(cn);
            lvitem.SubItems.Add(sv.Hinh);
            this.lvSinhVien.Items.Add(lvitem);
        }
        private void LoadListView()
        {
            this.lvSinhVien.Items.Clear();
            foreach (SinhVien sv in qlsv.dsSinhVien)
                ThemSV(sv);

            toolStripStatusLabel1.Text = "Tổng Sinh Viên: " + qlsv.dsSinhVien.Count.ToString();
        }
        private SinhVien GetSinhVien()
        {
            SinhVien sv = new SinhVien();
            bool gt = true;
            List<string> cn = new List<string>();
            sv.MaSo = this.mtxtMaSo.Text;
            sv.HoTen = this.txtHoTen.Text;
            sv.NgaySinh = this.dtpNgaySinh.Value;
            sv.DiaChi = this.txtDiaChi.Text;
            sv.Lop = this.cboLop.Text;
            sv.Hinh = this.txtHinh.Text;
            if (rdNu.Checked)
                gt = false;
            sv.GioiTinh = gt;
            for (int i = 0; i < this.clbChuyenNganh.Items.Count; i++)
                if (clbChuyenNganh.GetItemChecked(i))
                    cn.Add(clbChuyenNganh.Items[i].ToString());
            sv.ChuyenNganh = cn;
            return sv;
        }
        private SinhVien GetSinhVienLV(ListViewItem lvitem)
        {
            SinhVien sv = new SinhVien();
            sv.MaSo = lvitem.SubItems[0].Text;
            sv.HoTen = lvitem.SubItems[1].Text;
            sv.NgaySinh = DateTime.Parse(lvitem.SubItems[2].Text);
            sv.DiaChi = lvitem.SubItems[3].Text;
            sv.Lop = lvitem.SubItems[4].Text;
            sv.GioiTinh = false;
            if (lvitem.SubItems[5].Text == "Nam")
                sv.GioiTinh = true;
            List<string> cn = new List<string>();
            string[] s = lvitem.SubItems[6].Text.Split(',');
            foreach (string t in s)
                cn.Add(t);
            sv.ChuyenNganh = cn;
            sv.Hinh = lvitem.SubItems[7].Text;
            return sv;
        }
        private void ThietLapThongTin(SinhVien sv)
        {
            this.mtxtMaSo.Text = sv.MaSo;
            this.txtHoTen.Text = sv.HoTen;
            this.dtpNgaySinh.Value = sv.NgaySinh;
            this.txtDiaChi.Text = sv.DiaChi;
            this.cboLop.Text = sv.Lop;
            this.txtHinh.Text = sv.Hinh;
            this.pbHinh.ImageLocation = sv.Hinh;
            if (sv.GioiTinh)
                this.rdNam.Checked = true;
            else
                this.rdNu.Checked = true;
            for (int i = 0; i < this.clbChuyenNganh.Items.Count; i++)
                this.clbChuyenNganh.SetItemChecked(i, false);
            foreach (string s in sv.ChuyenNganh)
            {
                for (int i = 0; i < this.clbChuyenNganh.Items.Count; i++)
                    if (s.CompareTo(this.clbChuyenNganh.Items[i]) == 0)
                        this.clbChuyenNganh.SetItemChecked(i, true);
            }
        }

        private void lvSinhVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            int count = this.lvSinhVien.SelectedItems.Count;
            if (count > 0)
            {
                ListViewItem lvitem = this.lvSinhVien.SelectedItems[0];
                SinhVien sv = GetSinhVienLV(lvitem);
                ThietLapThongTin(sv);

                this.mtxtMaSo.ReadOnly = true;
            }
        }

        private void btnMacDinh_Click(object sender, EventArgs e)
        {
            this.mtxtMaSo.Text = "";
            this.mtxtMaSo.ReadOnly = false;
            this.txtHoTen.Text = "";
            this.dtpNgaySinh.Value = DateTime.Now;
            this.txtDiaChi.Text = "";
            this.cboLop.Text = this.cboLop.Items[0].ToString();
            this.txtHinh.Text = "";
            this.pbHinh.ImageLocation = "";
            this.rdNam.Checked = true;
            for (int i = 0; i < this.clbChuyenNganh.Items.Count - 1; i++)
                this.clbChuyenNganh.SetItemChecked(i, false);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private int SoSanhTheoMa(object sv1, object sv2)
        {
            SinhVien sv = sv2 as SinhVien;
            return sv.MaSo.CompareTo(sv1);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int count, i;
            ListViewItem lvitem;
            count = this.lvSinhVien.Items.Count - 1;
            for (i = count; i >= 0; i--)
            {
                lvitem = this.lvSinhVien.Items[i];
                if (lvitem.Checked)
                    qlsv.Xoa(lvitem.SubItems[0].Text, SoSanhTheoMa);
            }
            this.LoadListView();
            this.btnMacDinh.PerformClick();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SinhVien sv = GetSinhVien();
            bool kqsua;
            kqsua = qlsv.Sua(sv, sv.MaSo, SoSanhTheoMa);
            if (kqsua)
                this.LoadListView();
        }

        private void frmSinhVien_Load(object sender, EventArgs e)
        {
            qlsv = new QuanLySinhVien();
            qlsv.DocTuFile("DanhSachSV.txt");
            LoadListView();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Open File Image";
            ofd.FileName = "Hãy chọn file";
            ofd.Filter = "(*.bmp;*.jpg;*.png)|*.bmp;*.jpg;*.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pbHinh.Image = Image.FromFile(ofd.FileName);
                    txtHinh.Text = ofd.FileName;
                }
                catch (OutOfMemoryException)
                {
                    MessageBox.Show("Ảnh bạn chọn không đúng định dạng, mời chọn lại.", "Thông báo");
                }
            }
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void thêmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SinhVien sv = GetSinhVien();
            int oldCount = qlsv.dsSinhVien.Count;
            qlsv.Them(sv);

            if (qlsv.dsSinhVien.Count > oldCount)
            {
                ThemSV(sv);
                toolStripStatusLabel1.Text = "Tổng Sinh Viên: " + qlsv.dsSinhVien.Count.ToString();
            }
        }

        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnSua.PerformClick();
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnXoa.PerformClick();
        }

        private void lvSinhVien_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (lvSinhVien.SelectedItems.Count == 0)
                btnMacDinh.PerformClick();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            if (fd.ShowDialog() == DialogResult.OK)
                lvSinhVien.Font = fd.Font;
        }

        private void màuChữToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
                lvSinhVien.ForeColor = cd.Color;
        }

        private void sắpXếpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTuyChon frm = new frmTuyChon();
            foreach (Control c in frm.Controls)
            {
                if (c is GroupBox && c.Name == "groupBoxTimKiem")
                {
                    c.Enabled = false;
                    break;
                }    
            } 
            if (frm.ShowDialog() == DialogResult.OK)
            {
                switch (frm.Kieu)
                {
                    case KieuTuyChon.MaSV:
                        qlsv.dsSinhVien.Sort((sv1, sv2) => sv1.MaSo.CompareTo(sv2.MaSo));
                        break;
                    case KieuTuyChon.HoTen:
                        qlsv.dsSinhVien.Sort((sv1, sv2) => sv1.HoTen.CompareTo(sv2.HoTen));
                        break;
                    case KieuTuyChon.NgaySinh:
                        qlsv.dsSinhVien.Sort((sv1, sv2) => sv1.NgaySinh.CompareTo(sv2.NgaySinh));
                        break;
                }
                LoadListView();
            }

        }
        private List<SinhVien> TimKiemSinhVien(KieuTuyChon kieu, string tuKhoa)
        {
            switch (kieu)
            {
                case KieuTuyChon.MaSV:
                    return qlsv.dsSinhVien.Where(sv => sv.MaSo.ToLower().Contains(tuKhoa)).ToList();
                case KieuTuyChon.HoTen:
                    return qlsv.dsSinhVien.Where(sv => sv.HoTen.ToLower().Contains(tuKhoa)).ToList();
                case KieuTuyChon.NgaySinh:
                    if (DateTime.TryParse(tuKhoa, out DateTime ngay))
                        return qlsv.dsSinhVien.Where(sv => sv.NgaySinh.Date == ngay.Date).ToList();
                    else
                    {
                        MessageBox.Show("Ngày tìm kiếm không hợp lệ. Vui lòng nhập theo định dạng ngày/tháng/năm.", "Thông báo");
                        return null;
                    }

                default:
                    MessageBox.Show("Kiểu tìm kiếm không hợp lệ!", "Thông báo");
                    return null;
            }
        }
        private void HienThiKetQua(List<SinhVien> ketQua)
        {
            lvSinhVien.Items.Clear();
            foreach (var sv in ketQua)
                ThemSV(sv);
            toolStripStatusLabel1.Text = $"Tìm thấy {ketQua.Count} sinh viên";
        }

        private void tìmKiếmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTuyChon frm = new frmTuyChon();

            foreach (Control c in frm.Controls)
            {
                if (c is Button && c.Name == "btnSapXep")
                {
                    c.Enabled = false;
                    break;
                }
            }

            if (frm.ShowDialog() == DialogResult.OK)
            {
                string tuKhoa = frm.ChuoiTim?.Trim().ToLower() ?? "";

                if (string.IsNullOrEmpty(tuKhoa))
                {
                    MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm!", "Thông báo");
                    return;
                }

                List<SinhVien> ketQua = TimKiemSinhVien(frm.Kieu, tuKhoa);
                if (ketQua == null) 
                    return; 

                HienThiKetQua(ketQua);
                MessageBox.Show($"Số sinh viên tìm thấy: {ketQua.Count}", "Thông báo");
            }
        }
    }
}

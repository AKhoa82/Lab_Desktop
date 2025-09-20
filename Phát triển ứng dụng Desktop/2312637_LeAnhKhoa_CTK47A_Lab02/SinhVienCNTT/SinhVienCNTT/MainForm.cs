using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SinhVienCNTT
{
    public partial class MainForm : Form
    {
        private QuanLySinhVien qlsv;
        private bool isEditing = false;
        private bool danhSachBiThayDoi = false;
        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            qlsv = new QuanLySinhVien();
            qlsv.DocTuFile("DSNV.txt");
            LoadListView();
            lvSinhVien.ContextMenuStrip = contextMenuStrip1;
        }
        private void LoadListView()
        {
            this.lvSinhVien.Items.Clear();
            foreach (SinhVien sv in qlsv.dsSinhVien)
                ThemSV(sv);
        }
        private void ThemSV(SinhVien sv)
        {
            ListViewItem lvitem = new ListViewItem(sv.MSSV);
            lvitem.SubItems.Add(sv.HoTen);
            string phai = "Nữ";
            if (sv.Phai)
                phai = "Nam";
            lvitem.SubItems.Add(phai);
            lvitem.SubItems.Add(sv.NgaySinh.ToShortDateString());
            lvitem.SubItems.Add(sv.Lop);
            lvitem.SubItems.Add(sv.SoDienThoai);
            lvitem.SubItems.Add(sv.Email);
            lvitem.SubItems.Add(sv.DiaChi);
            lvitem.SubItems.Add(sv.Hinh);
            this.lvSinhVien.Items.Add(lvitem);
        }
        private SinhVien GetSinhVien()
        {
            SinhVien sv = new SinhVien();
            bool phai = true;
            sv.MSSV = this.mtxtMSSV.Text;
            sv.HoTen = this.txtHoTen.Text;
            if (rdNu.Checked)
                phai = false;
            sv.Phai = phai;
            sv.NgaySinh = this.dtpNgaySinh.Value;
            sv.Lop = this.cboLop.Text;
            sv.SoDienThoai = this.mtxtSĐT.Text;
            sv.Email = this.txtEmail.Text;
            sv.DiaChi = this.txtDiaChi.Text;
            sv.Hinh = this.txtHinh.Text;
            return sv;
        }
        private SinhVien GetSinhVienLV(ListViewItem lvitem)
        {
            SinhVien sv = new SinhVien();
            sv.MSSV = lvitem.SubItems[0].Text;
            sv.HoTen= lvitem.SubItems[1].Text;
            sv.Phai = false;
            if (lvitem.SubItems[2].Text == "Nam")
                sv.Phai = true;
            sv.NgaySinh = DateTime.Parse(lvitem.SubItems[3].Text);
            sv.Lop = lvitem.SubItems[4].Text;
            sv.SoDienThoai = lvitem.SubItems[5].Text;
            sv.Email = lvitem.SubItems[6].Text;
            sv.DiaChi = lvitem.SubItems[7].Text;
            sv.Hinh = lvitem.SubItems[8].Text;
            return sv;
        }
        private void ThietLapThongTin(SinhVien sv)
        {
            this.mtxtMSSV.Text = sv.MSSV;
            this.txtHoTen.Text = sv.HoTen;
            if (sv.Phai)
                this.rdNam.Checked = true;
            else
                this.rdNu.Checked = true;
            this.dtpNgaySinh.Value = sv.NgaySinh;
            this.cboLop.Text = sv.Lop;
            this.mtxtSĐT.Text = sv.SoDienThoai;
            this.txtEmail.Text = sv.Email;
            this.txtDiaChi.Text = sv.DiaChi;
            this.pbHinh.ImageLocation = sv.Hinh;
        }

        private void lvSinhVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            int count = this.lvSinhVien.SelectedItems.Count;
            if (count > 0)
            {
                ListViewItem lvitem = this.lvSinhVien.SelectedItems[0];
                SinhVien sv = GetSinhVienLV(lvitem);
                ThietLapThongTin(sv);
                mtxtMSSV.ReadOnly = true;
                isEditing = true;
            }
            else
                btnMacDinh.PerformClick();
        }

        private void btnMacDinh_Click(object sender, EventArgs e)
        {
            this.mtxtMSSV.Text = "";
            this.txtHoTen.Text = "";
            this.rdNam.Checked = true;
            this.dtpNgaySinh.Value = DateTime.Now;
            this.cboLop.Text = "";
            this.mtxtSĐT.Text = "";
            this.txtEmail.Text = "";
            this.txtDiaChi.Text = "";
            this.txtHinh.Text = "";
            this.pbHinh.Image = null;

            mtxtMSSV.ReadOnly = false;
            isEditing = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnChonHinh_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Open File Image";
            ofd.FileName = "Hãy chọn file";
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp|All files|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    txtHinh.Text = ofd.FileName;
                    pbHinh.ImageLocation = ofd.FileName;
                }
                catch (OutOfMemoryException)
                {
                    MessageBox.Show("Ảnh bạn chọn không đúng định dạng, mời chọn lại.", "Thông báo");
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            SinhVien sv = GetSinhVien();
            SoSanh ss = SoSanhTheoMSSV;

            if (string.IsNullOrWhiteSpace(sv.MSSV))
            {
                MessageBox.Show("Mã sinh viên không được để trống!", "Thông báo");
                return;
            }

            if (isEditing)
            {
                bool suaThanhCong = qlsv.Sua(sv, sv.MSSV, ss);
                if (!suaThanhCong)
                    MessageBox.Show("Sửa sinh viên thất bại!", "Lỗi");
            }
            else
            {
                SinhVien ktTrung = qlsv.Tim(sv.MSSV, ss);
                if (ktTrung != null)
                {
                    MessageBox.Show("Mã sinh viên đã tồn tại, vui lòng nhập mã khác!", "Thông báo");
                    return;
                }
                qlsv.Them(sv);
            }
            danhSachBiThayDoi = true;
            LoadListView();
            btnMacDinh.PerformClick();
        }
        private int SoSanhTheoMSSV(object obj1, object obj2)
        {
            string mssv = obj1 as string;
            SinhVien sv = obj2 as SinhVien;

            if (sv != null && mssv != null)
                return sv.MSSV.CompareTo(mssv);
            return -1;
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvSinhVien.SelectedItems.Count == 0)
                return;
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sinh viên đã chọn không?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                SoSanh ss = new SoSanh(SoSanhTheoMSSV);
                foreach (ListViewItem item in lvSinhVien.SelectedItems)
                    qlsv.Xoa(item.Text, ss);
                danhSachBiThayDoi = true;
                LoadListView();
                btnMacDinh.PerformClick();
            }
        }

        private void tảiLạiDanhSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            qlsv.DocTuFile("DSNV.txt");
            LoadListView();
            btnMacDinh.PerformClick();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (danhSachBiThayDoi)
            {
                var result = MessageBox.Show("Bạn có muốn lưu danh sách đã thay đổi?", "Xác nhận", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                    qlsv.GhiVaoFile("DSNV.txt");
                else if (result == DialogResult.Cancel)
                    e.Cancel = true;
            } 
        }
    }
}

using System.Drawing;
using System.Windows.Forms;

namespace GiangVien
{
    partial class frmTim
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpTimTheo = new System.Windows.Forms.GroupBox();
            this.rdMaGV = new System.Windows.Forms.RadioButton();
            this.rdHoTen = new System.Windows.Forms.RadioButton();
            this.rdSoDT = new System.Windows.Forms.RadioButton();
            this.lblNhap = new System.Windows.Forms.Label();
            this.txtGiaTriTim = new System.Windows.Forms.TextBox();
            this.btnTim = new System.Windows.Forms.Button();
            this.grpTimTheo.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpTimTheo
            // 
            this.grpTimTheo.Controls.Add(this.rdMaGV);
            this.grpTimTheo.Controls.Add(this.rdHoTen);
            this.grpTimTheo.Controls.Add(this.rdSoDT);
            this.grpTimTheo.Location = new System.Drawing.Point(20, 20);
            this.grpTimTheo.Name = "grpTimTheo";
            this.grpTimTheo.Size = new System.Drawing.Size(350, 60);
            this.grpTimTheo.TabIndex = 0;
            this.grpTimTheo.TabStop = false;
            this.grpTimTheo.Text = "Tìm theo";
            // 
            // rdMaGV
            // 
            this.rdMaGV.Checked = true;
            this.rdMaGV.Location = new System.Drawing.Point(10, 25);
            this.rdMaGV.Name = "rdMaGV";
            this.rdMaGV.Size = new System.Drawing.Size(104, 24);
            this.rdMaGV.TabIndex = 0;
            this.rdMaGV.TabStop = true;
            this.rdMaGV.Text = "Mã GV";
            // 
            // rdHoTen
            // 
            this.rdHoTen.Location = new System.Drawing.Point(120, 24);
            this.rdHoTen.Name = "rdHoTen";
            this.rdHoTen.Size = new System.Drawing.Size(84, 24);
            this.rdHoTen.TabIndex = 1;
            this.rdHoTen.Text = "Họ tên";
            // 
            // rdSoDT
            // 
            this.rdSoDT.Location = new System.Drawing.Point(210, 25);
            this.rdSoDT.Name = "rdSoDT";
            this.rdSoDT.Size = new System.Drawing.Size(124, 24);
            this.rdSoDT.TabIndex = 2;
            this.rdSoDT.Text = "Số điện thoại";
            // 
            // lblNhap
            // 
            this.lblNhap.AutoSize = true;
            this.lblNhap.Location = new System.Drawing.Point(32, 100);
            this.lblNhap.Name = "lblNhap";
            this.lblNhap.Size = new System.Drawing.Size(53, 17);
            this.lblNhap.TabIndex = 1;
            this.lblNhap.Text = "Mã GV";
            // 
            // txtGiaTriTim
            // 
            this.txtGiaTriTim.Location = new System.Drawing.Point(102, 95);
            this.txtGiaTriTim.Name = "txtGiaTriTim";
            this.txtGiaTriTim.Size = new System.Drawing.Size(170, 25);
            this.txtGiaTriTim.TabIndex = 2;
            // 
            // btnTim
            // 
            this.btnTim.Location = new System.Drawing.Point(282, 94);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(75, 23);
            this.btnTim.TabIndex = 3;
            this.btnTim.Text = "Tìm";
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // frmTim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 141);
            this.Controls.Add(this.grpTimTheo);
            this.Controls.Add(this.lblNhap);
            this.Controls.Add(this.txtGiaTriTim);
            this.Controls.Add(this.btnTim);
            this.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmTim";
            this.Text = "Tìm thông tin giảng viên";
            this.grpTimTheo.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private GroupBox grpTimTheo;
        private RadioButton rdMaGV;
        private RadioButton rdHoTen;
        private RadioButton rdSoDT;
        private Label lblNhap;
        private TextBox txtGiaTriTim;
        private Button btnTim;
    }
}
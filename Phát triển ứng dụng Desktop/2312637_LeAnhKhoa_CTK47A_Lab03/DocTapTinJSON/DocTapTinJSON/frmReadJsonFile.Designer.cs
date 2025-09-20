namespace DocTapTinJSON
{
    partial class frmReadJsonFile
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
            this.btnReadJSON = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnReadJSON
            // 
            this.btnReadJSON.BackColor = System.Drawing.Color.LightGray;
            this.btnReadJSON.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReadJSON.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReadJSON.Location = new System.Drawing.Point(207, 51);
            this.btnReadJSON.Name = "btnReadJSON";
            this.btnReadJSON.Size = new System.Drawing.Size(149, 34);
            this.btnReadJSON.TabIndex = 0;
            this.btnReadJSON.Text = "Đọc file JSON";
            this.btnReadJSON.UseVisualStyleBackColor = false;
            this.btnReadJSON.Click += new System.EventHandler(this.btnReadJSON_Click);
            // 
            // frmReadJsonFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 146);
            this.Controls.Add(this.btnReadJSON);
            this.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmReadJsonFile";
            this.Text = "frmReadJsonFile";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnReadJSON;
    }
}


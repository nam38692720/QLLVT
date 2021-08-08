namespace QLVT_DH.SimpleForm
{
    partial class frmTaoTaiKhoan
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnGridNV = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCreateAcc = new System.Windows.Forms.Button();
            this.rbUser = new System.Windows.Forms.RadioButton();
            this.rbCN = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbChiNhanh = new System.Windows.Forms.ComboBox();
            this.bdsDSPM = new System.Windows.Forms.BindingSource(this.components);
            this.qLVTDataSet = new QLVT_DH.QLVTDataSet();
            this.label1 = new System.Windows.Forms.Label();
            this.v_DS_PHANMANHTableAdapter = new QLVT_DH.QLVTDataSetTableAdapters.V_DS_PHANMANHTableAdapter();
            this.tableAdapterManager = new QLVT_DH.QLVTDataSetTableAdapters.TableAdapterManager();
            this.DS = new QLVT_DH.DS();
            this.bdsNV = new System.Windows.Forms.BindingSource(this.components);
            this.nHANVIENTableAdapter = new QLVT_DH.DSTableAdapters.NHANVIENTableAdapter();
            this.tableAdapterManager1 = new QLVT_DH.DSTableAdapters.TableAdapterManager();
            this.txtMaNV = new DevExpress.XtraEditors.TextEdit();
            this.txtUsername = new DevExpress.XtraEditors.TextEdit();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.txtRetype = new DevExpress.XtraEditors.TextEdit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDSPM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLVTDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsNV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaNV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsername.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRetype.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtRetype);
            this.panel1.Controls.Add(this.txtPassword);
            this.panel1.Controls.Add(this.txtUsername);
            this.panel1.Controls.Add(this.txtMaNV);
            this.panel1.Controls.Add(this.btnGridNV);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.btnCreateAcc);
            this.panel1.Controls.Add(this.rbUser);
            this.panel1.Controls.Add(this.rbCN);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmbChiNhanh);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(135, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(666, 525);
            this.panel1.TabIndex = 0;
            // 
            // btnGridNV
            // 
            this.btnGridNV.Location = new System.Drawing.Point(502, 137);
            this.btnGridNV.Name = "btnGridNV";
            this.btnGridNV.Size = new System.Drawing.Size(34, 22);
            this.btnGridNV.TabIndex = 14;
            this.btnGridNV.Text = "...";
            this.btnGridNV.UseVisualStyleBackColor = true;
            this.btnGridNV.Click += new System.EventHandler(this.btnGridNV_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(90, 336);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "Nhập lại Mật Khẩu:";
            // 
            // btnCreateAcc
            // 
            this.btnCreateAcc.Location = new System.Drawing.Point(153, 443);
            this.btnCreateAcc.Name = "btnCreateAcc";
            this.btnCreateAcc.Size = new System.Drawing.Size(259, 54);
            this.btnCreateAcc.TabIndex = 11;
            this.btnCreateAcc.Text = "Tạo Tài Khoản";
            this.btnCreateAcc.UseVisualStyleBackColor = true;
            this.btnCreateAcc.Click += new System.EventHandler(this.btnCreateAcc_Click);
            // 
            // rbUser
            // 
            this.rbUser.AutoSize = true;
            this.rbUser.Location = new System.Drawing.Point(332, 387);
            this.rbUser.Name = "rbUser";
            this.rbUser.Size = new System.Drawing.Size(59, 21);
            this.rbUser.TabIndex = 10;
            this.rbUser.TabStop = true;
            this.rbUser.Text = "User";
            this.rbUser.UseVisualStyleBackColor = true;
            this.rbUser.CheckedChanged += new System.EventHandler(this.rbUser_CheckedChanged);
            // 
            // rbCN
            // 
            this.rbCN.AutoSize = true;
            this.rbCN.Location = new System.Drawing.Point(198, 387);
            this.rbCN.Name = "rbCN";
            this.rbCN.Size = new System.Drawing.Size(95, 21);
            this.rbCN.TabIndex = 9;
            this.rbCN.TabStop = true;
            this.rbCN.Text = "Chi Nhánh";
            this.rbCN.UseVisualStyleBackColor = true;
            this.rbCN.CheckedChanged += new System.EventHandler(this.rbCN_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(90, 273);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "Mật Khẩu:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(90, 214);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Tài Khoản:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(90, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Chi Nhánh:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(90, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nhân Viên:";
            // 
            // cmbChiNhanh
            // 
            this.cmbChiNhanh.DataSource = this.bdsDSPM;
            this.cmbChiNhanh.DisplayMember = "TENSERVER";
            this.cmbChiNhanh.FormattingEnabled = true;
            this.cmbChiNhanh.Location = new System.Drawing.Point(242, 82);
            this.cmbChiNhanh.Name = "cmbChiNhanh";
            this.cmbChiNhanh.Size = new System.Drawing.Size(193, 24);
            this.cmbChiNhanh.TabIndex = 1;
            this.cmbChiNhanh.ValueMember = "TENCN";
            // 
            // bdsDSPM
            // 
            this.bdsDSPM.DataMember = "V_DS_PHANMANH";
            this.bdsDSPM.DataSource = this.qLVTDataSet;
            // 
            // qLVTDataSet
            // 
            this.qLVTDataSet.DataSetName = "QLVTDataSet";
            this.qLVTDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(190, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tạo Tài Khoản";
            // 
            // v_DS_PHANMANHTableAdapter
            // 
            this.v_DS_PHANMANHTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = QLVT_DH.QLVTDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // DS
            // 
            this.DS.DataSetName = "DS";
            this.DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bdsNV
            // 
            this.bdsNV.DataMember = "NHANVIEN";
            this.bdsNV.DataSource = this.DS;
            // 
            // nHANVIENTableAdapter
            // 
            this.nHANVIENTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager1
            // 
            this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager1.ChiNhanhTableAdapter = null;
            this.tableAdapterManager1.CTDDHTableAdapter = null;
            this.tableAdapterManager1.CTPNTableAdapter = null;
            this.tableAdapterManager1.CTPXTableAdapter = null;
            this.tableAdapterManager1.DATHANGTableAdapter = null;
            this.tableAdapterManager1.KhoTableAdapter = null;
            this.tableAdapterManager1.NHANVIENTableAdapter = this.nHANVIENTableAdapter;
            this.tableAdapterManager1.PHIEUNHAPTableAdapter = null;
            this.tableAdapterManager1.PHIEUXUATTableAdapter = null;
            this.tableAdapterManager1.UpdateOrder = QLVT_DH.DSTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager1.VattuTableAdapter = null;
            // 
            // txtMaNV
            // 
            this.txtMaNV.Location = new System.Drawing.Point(242, 140);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(193, 22);
            this.txtMaNV.TabIndex = 15;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(242, 211);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(193, 22);
            this.txtUsername.TabIndex = 16;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(242, 270);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(193, 22);
            this.txtPassword.TabIndex = 17;
            // 
            // txtRetype
            // 
            this.txtRetype.Location = new System.Drawing.Point(242, 333);
            this.txtRetype.Name = "txtRetype";
            this.txtRetype.Size = new System.Drawing.Size(193, 22);
            this.txtRetype.TabIndex = 18;
            // 
            // frmTaoTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 597);
            this.Controls.Add(this.panel1);
            this.Name = "frmTaoTaiKhoan";
            this.Text = "frnTaoTaiKhoan";
            this.Load += new System.EventHandler(this.frnTaoTaiKhoan_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDSPM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLVTDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsNV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaNV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsername.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRetype.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private QLVTDataSet qLVTDataSet;
        private System.Windows.Forms.BindingSource bdsDSPM;
        private QLVTDataSetTableAdapters.V_DS_PHANMANHTableAdapter v_DS_PHANMANHTableAdapter;
        private QLVTDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbChiNhanh;
        private System.Windows.Forms.Button btnCreateAcc;
        private System.Windows.Forms.RadioButton rbUser;
        private System.Windows.Forms.RadioButton rbCN;
        private System.Windows.Forms.Label label6;
        private DS DS;
        private System.Windows.Forms.BindingSource bdsNV;
        private DSTableAdapters.NHANVIENTableAdapter nHANVIENTableAdapter;
        private DSTableAdapters.TableAdapterManager tableAdapterManager1;
        private System.Windows.Forms.Button btnGridNV;
        private DevExpress.XtraEditors.TextEdit txtRetype;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.TextEdit txtUsername;
        public DevExpress.XtraEditors.TextEdit txtMaNV;
    }
}
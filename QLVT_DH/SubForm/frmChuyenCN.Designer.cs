namespace QLVT_DH.SubForm
{
    partial class frmChuyenCN
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
            this.qLVTDataSet = new QLVT_DH.QLVTDataSet();
            this.bds_dspm = new System.Windows.Forms.BindingSource(this.components);
            this.v_DS_PHANMANHTableAdapter = new QLVT_DH.QLVTDataSetTableAdapters.V_DS_PHANMANHTableAdapter();
            this.tableAdapterManager = new QLVT_DH.QLVTDataSetTableAdapters.TableAdapterManager();
            this.cmbChiNhanh = new System.Windows.Forms.ComboBox();
            this.btnChuyenCN = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.qLVTDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bds_dspm)).BeginInit();
            this.SuspendLayout();
            // 
            // qLVTDataSet
            // 
            this.qLVTDataSet.DataSetName = "QLVTDataSet";
            this.qLVTDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bds_dspm
            // 
            this.bds_dspm.DataMember = "V_DS_PHANMANH";
            this.bds_dspm.DataSource = this.qLVTDataSet;
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
            // cmbChiNhanh
            // 
            this.cmbChiNhanh.DataSource = this.bds_dspm;
            this.cmbChiNhanh.DisplayMember = "TENCN";
            this.cmbChiNhanh.FormattingEnabled = true;
            this.cmbChiNhanh.Location = new System.Drawing.Point(80, 70);
            this.cmbChiNhanh.Name = "cmbChiNhanh";
            this.cmbChiNhanh.Size = new System.Drawing.Size(300, 24);
            this.cmbChiNhanh.TabIndex = 1;
            this.cmbChiNhanh.ValueMember = "TENSERVER";
            // 
            // btnChuyenCN
            // 
            this.btnChuyenCN.Location = new System.Drawing.Point(80, 154);
            this.btnChuyenCN.Name = "btnChuyenCN";
            this.btnChuyenCN.Size = new System.Drawing.Size(300, 23);
            this.btnChuyenCN.TabIndex = 2;
            this.btnChuyenCN.Text = "Chuyển chi nhánh";
            this.btnChuyenCN.UseVisualStyleBackColor = true;
            this.btnChuyenCN.Click += new System.EventHandler(this.btnChuyenCN_Click);
            // 
            // frmChuyenCN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 260);
            this.Controls.Add(this.btnChuyenCN);
            this.Controls.Add(this.cmbChiNhanh);
            this.Name = "frmChuyenCN";
            this.Text = "frmChuyenCN";
            this.Load += new System.EventHandler(this.frmChuyenCN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qLVTDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bds_dspm)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private QLVTDataSet qLVTDataSet;
        private System.Windows.Forms.BindingSource bds_dspm;
        private QLVTDataSetTableAdapters.V_DS_PHANMANHTableAdapter v_DS_PHANMANHTableAdapter;
        private QLVTDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.ComboBox cmbChiNhanh;
        private System.Windows.Forms.Button btnChuyenCN;
    }
}
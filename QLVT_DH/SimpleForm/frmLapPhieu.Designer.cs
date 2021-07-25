namespace QLVT_DH.SimpleForm
{
    partial class frmLapPhieu
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
            System.Windows.Forms.Label hOTENKHLabel;
            System.Windows.Forms.Label mAKHOLabel;
            System.Windows.Forms.Label nhaCCLabel;
            System.Windows.Forms.Label mAKHOLabel1;
            System.Windows.Forms.Label masoDDHLabel1;
            System.Windows.Forms.Label mAPXLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLapPhieu));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbChiNhanh = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DS = new QLVT_DH.DS();
            this.tableAdapterManager = new QLVT_DH.DSTableAdapters.TableAdapterManager();
            this.cTDDHTableAdapter = new QLVT_DH.DSTableAdapters.CTDDHTableAdapter();
            this.cTPNTableAdapter = new QLVT_DH.DSTableAdapters.CTPNTableAdapter();
            this.cTPXTableAdapter = new QLVT_DH.DSTableAdapters.CTPXTableAdapter();
            this.datHangTableAdapter = new QLVT_DH.DSTableAdapters.DATHANGTableAdapter();
            this.phieuNhapTableAdapter = new QLVT_DH.DSTableAdapters.PHIEUNHAPTableAdapter();
            this.phieuXuatTableAdapter = new QLVT_DH.DSTableAdapters.PHIEUXUATTableAdapter();
            this.bdsDH = new System.Windows.Forms.BindingSource(this.components);
            this.gridDDH = new DevExpress.XtraGrid.GridControl();
            this.gvDDH = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMasoDDH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNGAY1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNhaCC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMAKHO1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMANV1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bdsPX = new System.Windows.Forms.BindingSource(this.components);
            this.gridPX = new DevExpress.XtraGrid.GridControl();
            this.gvPX = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMAPX = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNGAY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHOTENKH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMAKHO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMANV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDDH = new DevExpress.XtraEditors.GroupControl();
            this.gridCTDDH = new DevExpress.XtraGrid.GridControl();
            this.bdsCTDDH = new System.Windows.Forms.BindingSource(this.components);
            this.gvCTDDH = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMasoDDH1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMAVT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSOLUONG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDONGIA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gbInfoDDH = new System.Windows.Forms.GroupBox();
            this.txtMaDDH = new System.Windows.Forms.TextBox();
            this.btnGridKho = new System.Windows.Forms.Button();
            this.txtMaKho_DH = new DevExpress.XtraEditors.TextEdit();
            this.txtNhaCC = new DevExpress.XtraEditors.TextEdit();
            this.gcPX = new DevExpress.XtraEditors.GroupControl();
            this.gridCTPX = new DevExpress.XtraGrid.GridControl();
            this.bdsCTPX = new System.Windows.Forms.BindingSource(this.components);
            this.gvCTPX = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMAPX1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMAVT1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSOLUONG1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDONGIA1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gbInfoPX = new System.Windows.Forms.GroupBox();
            this.txtMaPX = new System.Windows.Forms.TextBox();
            this.btnGridKho2 = new System.Windows.Forms.Button();
            this.txtMaKho_PX = new DevExpress.XtraEditors.TextEdit();
            this.txtTenKh = new DevExpress.XtraEditors.TextEdit();
            this.gcPN = new DevExpress.XtraEditors.GroupControl();
            this.gridCTPN = new DevExpress.XtraGrid.GridControl();
            this.bdsCTPN = new System.Windows.Forms.BindingSource(this.components);
            this.gvCTPN = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMAPN1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMAVT2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSOLUONG2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDONGIA2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridPN = new DevExpress.XtraGrid.GridControl();
            this.bdsPN = new System.Windows.Forms.BindingSource(this.components);
            this.gvPN = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMAPN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNGAY2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMasoDDH2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMAKHO2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMANV2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnThem = new DevExpress.XtraBars.BarButtonItem();
            this.btnSua = new DevExpress.XtraBars.BarButtonItem();
            this.btnXoa = new DevExpress.XtraBars.BarButtonItem();
            this.btnReload = new DevExpress.XtraBars.BarButtonItem();
            this.btnGhi = new DevExpress.XtraBars.BarButtonItem();
            this.btnUndo = new DevExpress.XtraBars.BarButtonItem();
            this.btnSwitch = new DevExpress.XtraBars.BarSubItem();
            this.btnDDH = new DevExpress.XtraBars.BarButtonItem();
            this.btnPN = new DevExpress.XtraBars.BarButtonItem();
            this.btnPX = new DevExpress.XtraBars.BarButtonItem();
            this.btnThoat = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.cmsChecked = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsCTDDH = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miThemCTDDH = new System.Windows.Forms.ToolStripMenuItem();
            hOTENKHLabel = new System.Windows.Forms.Label();
            mAKHOLabel = new System.Windows.Forms.Label();
            nhaCCLabel = new System.Windows.Forms.Label();
            mAKHOLabel1 = new System.Windows.Forms.Label();
            masoDDHLabel1 = new System.Windows.Forms.Label();
            mAPXLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDDH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDDH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsPX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDDH)).BeginInit();
            this.gcDDH.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCTDDH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsCTDDH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCTDDH)).BeginInit();
            this.gbInfoDDH.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaKho_DH.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNhaCC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPX)).BeginInit();
            this.gcPX.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCTPX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsCTPX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCTPX)).BeginInit();
            this.gbInfoPX.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaKho_PX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenKh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPN)).BeginInit();
            this.gcPN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCTPN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsCTPN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCTPN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsPN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.cmsCTDDH.SuspendLayout();
            this.SuspendLayout();
            // 
            // hOTENKHLabel
            // 
            hOTENKHLabel.AutoSize = true;
            hOTENKHLabel.Location = new System.Drawing.Point(114, 105);
            hOTENKHLabel.Name = "hOTENKHLabel";
            hOTENKHLabel.Size = new System.Drawing.Size(52, 17);
            hOTENKHLabel.TabIndex = 2;
            hOTENKHLabel.Text = "Tên KH";
            // 
            // mAKHOLabel
            // 
            mAKHOLabel.AutoSize = true;
            mAKHOLabel.Location = new System.Drawing.Point(117, 152);
            mAKHOLabel.Name = "mAKHOLabel";
            mAKHOLabel.Size = new System.Drawing.Size(53, 17);
            mAKHOLabel.TabIndex = 4;
            mAKHOLabel.Text = "Mã Kho";
            // 
            // nhaCCLabel
            // 
            nhaCCLabel.AutoSize = true;
            nhaCCLabel.Location = new System.Drawing.Point(113, 111);
            nhaCCLabel.Name = "nhaCCLabel";
            nhaCCLabel.Size = new System.Drawing.Size(59, 17);
            nhaCCLabel.TabIndex = 2;
            nhaCCLabel.Text = "Nhà CC:";
            // 
            // mAKHOLabel1
            // 
            mAKHOLabel1.AutoSize = true;
            mAKHOLabel1.Location = new System.Drawing.Point(114, 162);
            mAKHOLabel1.Name = "mAKHOLabel1";
            mAKHOLabel1.Size = new System.Drawing.Size(58, 17);
            mAKHOLabel1.TabIndex = 4;
            mAKHOLabel1.Text = "Mã Kho:";
            // 
            // masoDDHLabel1
            // 
            masoDDHLabel1.AutoSize = true;
            masoDDHLabel1.Location = new System.Drawing.Point(114, 61);
            masoDDHLabel1.Name = "masoDDHLabel1";
            masoDDHLabel1.Size = new System.Drawing.Size(63, 17);
            masoDDHLabel1.TabIndex = 7;
            masoDDHLabel1.Text = "Mã ĐĐH:";
            // 
            // mAPXLabel
            // 
            mAPXLabel.AutoSize = true;
            mAPXLabel.Location = new System.Drawing.Point(117, 58);
            mAPXLabel.Name = "mAPXLabel";
            mAPXLabel.Size = new System.Drawing.Size(50, 17);
            mAPXLabel.TabIndex = 6;
            mAPXLabel.Text = "Mã PX:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbChiNhanh);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1320, 76);
            this.panel1.TabIndex = 4;
            // 
            // cmbChiNhanh
            // 
            this.cmbChiNhanh.FormattingEnabled = true;
            this.cmbChiNhanh.Location = new System.Drawing.Point(522, 25);
            this.cmbChiNhanh.Name = "cmbChiNhanh";
            this.cmbChiNhanh.Size = new System.Drawing.Size(393, 24);
            this.cmbChiNhanh.TabIndex = 1;
            this.cmbChiNhanh.SelectedIndexChanged += new System.EventHandler(this.cmbChiNhanh_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(384, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "ChiNhanh";
            // 
            // DS
            // 
            this.DS.DataSetName = "DS";
            this.DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.ChiNhanhTableAdapter = null;
            this.tableAdapterManager.CTDDHTableAdapter = this.cTDDHTableAdapter;
            this.tableAdapterManager.CTPNTableAdapter = this.cTPNTableAdapter;
            this.tableAdapterManager.CTPXTableAdapter = this.cTPXTableAdapter;
            this.tableAdapterManager.DATHANGTableAdapter = this.datHangTableAdapter;
            this.tableAdapterManager.KhoTableAdapter = null;
            this.tableAdapterManager.NHANVIENTableAdapter = null;
            this.tableAdapterManager.PHIEUNHAPTableAdapter = this.phieuNhapTableAdapter;
            this.tableAdapterManager.PHIEUXUATTableAdapter = this.phieuXuatTableAdapter;
            this.tableAdapterManager.UpdateOrder = QLVT_DH.DSTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.VattuTableAdapter = null;
            // 
            // cTDDHTableAdapter
            // 
            this.cTDDHTableAdapter.ClearBeforeFill = true;
            // 
            // cTPNTableAdapter
            // 
            this.cTPNTableAdapter.ClearBeforeFill = true;
            // 
            // cTPXTableAdapter
            // 
            this.cTPXTableAdapter.ClearBeforeFill = true;
            // 
            // datHangTableAdapter
            // 
            this.datHangTableAdapter.ClearBeforeFill = true;
            // 
            // phieuNhapTableAdapter
            // 
            this.phieuNhapTableAdapter.ClearBeforeFill = true;
            // 
            // phieuXuatTableAdapter
            // 
            this.phieuXuatTableAdapter.ClearBeforeFill = true;
            // 
            // bdsDH
            // 
            this.bdsDH.DataMember = "DATHANG";
            this.bdsDH.DataSource = this.DS;
            // 
            // gridDDH
            // 
            this.gridDDH.DataSource = this.bdsDH;
            this.gridDDH.Dock = System.Windows.Forms.DockStyle.Top;
            this.gridDDH.Location = new System.Drawing.Point(0, 106);
            this.gridDDH.MainView = this.gvDDH;
            this.gridDDH.Name = "gridDDH";
            this.gridDDH.Size = new System.Drawing.Size(1320, 220);
            this.gridDDH.TabIndex = 5;
            this.gridDDH.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDDH});
            // 
            // gvDDH
            // 
            this.gvDDH.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMasoDDH,
            this.colNGAY1,
            this.colNhaCC,
            this.colMAKHO1,
            this.colMANV1});
            this.gvDDH.GridControl = this.gridDDH;
            this.gvDDH.Name = "gvDDH";
            // 
            // colMasoDDH
            // 
            this.colMasoDDH.FieldName = "MasoDDH";
            this.colMasoDDH.MinWidth = 25;
            this.colMasoDDH.Name = "colMasoDDH";
            this.colMasoDDH.OptionsColumn.AllowEdit = false;
            this.colMasoDDH.OptionsColumn.AllowFocus = false;
            this.colMasoDDH.Visible = true;
            this.colMasoDDH.VisibleIndex = 0;
            this.colMasoDDH.Width = 94;
            // 
            // colNGAY1
            // 
            this.colNGAY1.FieldName = "NGAY";
            this.colNGAY1.MinWidth = 25;
            this.colNGAY1.Name = "colNGAY1";
            this.colNGAY1.OptionsColumn.AllowEdit = false;
            this.colNGAY1.OptionsColumn.AllowFocus = false;
            this.colNGAY1.Visible = true;
            this.colNGAY1.VisibleIndex = 1;
            this.colNGAY1.Width = 94;
            // 
            // colNhaCC
            // 
            this.colNhaCC.FieldName = "NhaCC";
            this.colNhaCC.MinWidth = 25;
            this.colNhaCC.Name = "colNhaCC";
            this.colNhaCC.OptionsColumn.AllowEdit = false;
            this.colNhaCC.OptionsColumn.AllowFocus = false;
            this.colNhaCC.Visible = true;
            this.colNhaCC.VisibleIndex = 2;
            this.colNhaCC.Width = 94;
            // 
            // colMAKHO1
            // 
            this.colMAKHO1.FieldName = "MAKHO";
            this.colMAKHO1.MinWidth = 25;
            this.colMAKHO1.Name = "colMAKHO1";
            this.colMAKHO1.OptionsColumn.AllowEdit = false;
            this.colMAKHO1.OptionsColumn.AllowFocus = false;
            this.colMAKHO1.Visible = true;
            this.colMAKHO1.VisibleIndex = 3;
            this.colMAKHO1.Width = 94;
            // 
            // colMANV1
            // 
            this.colMANV1.FieldName = "MANV";
            this.colMANV1.MinWidth = 25;
            this.colMANV1.Name = "colMANV1";
            this.colMANV1.OptionsColumn.AllowEdit = false;
            this.colMANV1.OptionsColumn.AllowFocus = false;
            this.colMANV1.Visible = true;
            this.colMANV1.VisibleIndex = 4;
            this.colMANV1.Width = 94;
            // 
            // bdsPX
            // 
            this.bdsPX.DataMember = "PHIEUXUAT";
            this.bdsPX.DataSource = this.DS;
            // 
            // gridPX
            // 
            this.gridPX.DataSource = this.bdsPX;
            this.gridPX.Dock = System.Windows.Forms.DockStyle.Top;
            this.gridPX.Location = new System.Drawing.Point(0, 326);
            this.gridPX.MainView = this.gvPX;
            this.gridPX.Name = "gridPX";
            this.gridPX.Size = new System.Drawing.Size(1320, 220);
            this.gridPX.TabIndex = 6;
            this.gridPX.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPX});
            // 
            // gvPX
            // 
            this.gvPX.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMAPX,
            this.colNGAY,
            this.colHOTENKH,
            this.colMAKHO,
            this.colMANV});
            this.gvPX.GridControl = this.gridPX;
            this.gvPX.Name = "gvPX";
            // 
            // colMAPX
            // 
            this.colMAPX.FieldName = "MAPX";
            this.colMAPX.MinWidth = 25;
            this.colMAPX.Name = "colMAPX";
            this.colMAPX.OptionsColumn.AllowEdit = false;
            this.colMAPX.OptionsColumn.AllowFocus = false;
            this.colMAPX.Visible = true;
            this.colMAPX.VisibleIndex = 0;
            this.colMAPX.Width = 94;
            // 
            // colNGAY
            // 
            this.colNGAY.FieldName = "NGAY";
            this.colNGAY.MinWidth = 25;
            this.colNGAY.Name = "colNGAY";
            this.colNGAY.OptionsColumn.AllowEdit = false;
            this.colNGAY.OptionsColumn.AllowFocus = false;
            this.colNGAY.Visible = true;
            this.colNGAY.VisibleIndex = 1;
            this.colNGAY.Width = 94;
            // 
            // colHOTENKH
            // 
            this.colHOTENKH.FieldName = "HOTENKH";
            this.colHOTENKH.MinWidth = 25;
            this.colHOTENKH.Name = "colHOTENKH";
            this.colHOTENKH.OptionsColumn.AllowEdit = false;
            this.colHOTENKH.OptionsColumn.AllowFocus = false;
            this.colHOTENKH.Visible = true;
            this.colHOTENKH.VisibleIndex = 2;
            this.colHOTENKH.Width = 94;
            // 
            // colMAKHO
            // 
            this.colMAKHO.FieldName = "MAKHO";
            this.colMAKHO.MinWidth = 25;
            this.colMAKHO.Name = "colMAKHO";
            this.colMAKHO.OptionsColumn.AllowEdit = false;
            this.colMAKHO.OptionsColumn.AllowFocus = false;
            this.colMAKHO.Visible = true;
            this.colMAKHO.VisibleIndex = 3;
            this.colMAKHO.Width = 94;
            // 
            // colMANV
            // 
            this.colMANV.FieldName = "MANV";
            this.colMANV.MinWidth = 25;
            this.colMANV.Name = "colMANV";
            this.colMANV.OptionsColumn.AllowEdit = false;
            this.colMANV.OptionsColumn.AllowFocus = false;
            this.colMANV.Visible = true;
            this.colMANV.VisibleIndex = 4;
            this.colMANV.Width = 94;
            // 
            // gcDDH
            // 
            this.gcDDH.Controls.Add(this.gridCTDDH);
            this.gcDDH.Controls.Add(this.gbInfoDDH);
            this.gcDDH.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcDDH.Location = new System.Drawing.Point(0, 546);
            this.gcDDH.Name = "gcDDH";
            this.gcDDH.Size = new System.Drawing.Size(1320, 243);
            this.gcDDH.TabIndex = 8;
            this.gcDDH.Text = "Đơn Đặt Hàng";
            // 
            // gridCTDDH
            // 
            this.gridCTDDH.DataSource = this.bdsCTDDH;
            this.gridCTDDH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCTDDH.Location = new System.Drawing.Point(469, 28);
            this.gridCTDDH.MainView = this.gvCTDDH;
            this.gridCTDDH.Name = "gridCTDDH";
            this.gridCTDDH.Size = new System.Drawing.Size(849, 213);
            this.gridCTDDH.TabIndex = 1;
            this.gridCTDDH.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCTDDH});
            this.gridCTDDH.MouseHover += new System.EventHandler(this.gridCTDDH_MouseHover);
            // 
            // bdsCTDDH
            // 
            this.bdsCTDDH.DataMember = "CTDDH";
            this.bdsCTDDH.DataSource = this.DS;
            // 
            // gvCTDDH
            // 
            this.gvCTDDH.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMasoDDH1,
            this.colMAVT,
            this.colSOLUONG,
            this.colDONGIA});
            this.gvCTDDH.GridControl = this.gridCTDDH;
            this.gvCTDDH.Name = "gvCTDDH";
            // 
            // colMasoDDH1
            // 
            this.colMasoDDH1.FieldName = "MasoDDH";
            this.colMasoDDH1.MinWidth = 25;
            this.colMasoDDH1.Name = "colMasoDDH1";
            this.colMasoDDH1.Visible = true;
            this.colMasoDDH1.VisibleIndex = 0;
            this.colMasoDDH1.Width = 94;
            // 
            // colMAVT
            // 
            this.colMAVT.FieldName = "MAVT";
            this.colMAVT.MinWidth = 25;
            this.colMAVT.Name = "colMAVT";
            this.colMAVT.Visible = true;
            this.colMAVT.VisibleIndex = 1;
            this.colMAVT.Width = 94;
            // 
            // colSOLUONG
            // 
            this.colSOLUONG.FieldName = "SOLUONG";
            this.colSOLUONG.MinWidth = 25;
            this.colSOLUONG.Name = "colSOLUONG";
            this.colSOLUONG.Visible = true;
            this.colSOLUONG.VisibleIndex = 2;
            this.colSOLUONG.Width = 94;
            // 
            // colDONGIA
            // 
            this.colDONGIA.FieldName = "DONGIA";
            this.colDONGIA.MinWidth = 25;
            this.colDONGIA.Name = "colDONGIA";
            this.colDONGIA.Visible = true;
            this.colDONGIA.VisibleIndex = 3;
            this.colDONGIA.Width = 94;
            // 
            // gbInfoDDH
            // 
            this.gbInfoDDH.Controls.Add(masoDDHLabel1);
            this.gbInfoDDH.Controls.Add(this.txtMaDDH);
            this.gbInfoDDH.Controls.Add(this.btnGridKho);
            this.gbInfoDDH.Controls.Add(mAKHOLabel1);
            this.gbInfoDDH.Controls.Add(this.txtMaKho_DH);
            this.gbInfoDDH.Controls.Add(nhaCCLabel);
            this.gbInfoDDH.Controls.Add(this.txtNhaCC);
            this.gbInfoDDH.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbInfoDDH.Location = new System.Drawing.Point(2, 28);
            this.gbInfoDDH.Name = "gbInfoDDH";
            this.gbInfoDDH.Size = new System.Drawing.Size(467, 213);
            this.gbInfoDDH.TabIndex = 0;
            this.gbInfoDDH.TabStop = false;
            this.gbInfoDDH.Text = "Thông tin";
            // 
            // txtMaDDH
            // 
            this.txtMaDDH.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsDH, "MasoDDH", true));
            this.txtMaDDH.Location = new System.Drawing.Point(197, 58);
            this.txtMaDDH.Name = "txtMaDDH";
            this.txtMaDDH.Size = new System.Drawing.Size(122, 23);
            this.txtMaDDH.TabIndex = 8;
            // 
            // btnGridKho
            // 
            this.btnGridKho.Location = new System.Drawing.Point(349, 159);
            this.btnGridKho.Name = "btnGridKho";
            this.btnGridKho.Size = new System.Drawing.Size(34, 23);
            this.btnGridKho.TabIndex = 7;
            this.btnGridKho.Text = "...";
            this.btnGridKho.UseVisualStyleBackColor = true;
            this.btnGridKho.Click += new System.EventHandler(this.btnGridKho_Click);
            // 
            // txtMaKho_DH
            // 
            this.txtMaKho_DH.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsDH, "MAKHO", true));
            this.txtMaKho_DH.Location = new System.Drawing.Point(196, 157);
            this.txtMaKho_DH.Name = "txtMaKho_DH";
            this.txtMaKho_DH.Properties.ReadOnly = true;
            this.txtMaKho_DH.Size = new System.Drawing.Size(125, 22);
            this.txtMaKho_DH.TabIndex = 5;
            // 
            // txtNhaCC
            // 
            this.txtNhaCC.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsDH, "NhaCC", true));
            this.txtNhaCC.Location = new System.Drawing.Point(196, 106);
            this.txtNhaCC.Name = "txtNhaCC";
            this.txtNhaCC.Size = new System.Drawing.Size(125, 22);
            this.txtNhaCC.TabIndex = 3;
            // 
            // gcPX
            // 
            this.gcPX.Controls.Add(this.gridCTPX);
            this.gcPX.Controls.Add(this.gbInfoPX);
            this.gcPX.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcPX.Location = new System.Drawing.Point(0, 789);
            this.gcPX.Name = "gcPX";
            this.gcPX.Size = new System.Drawing.Size(1320, 264);
            this.gcPX.TabIndex = 9;
            this.gcPX.Text = "Phiếu xuất";
            // 
            // gridCTPX
            // 
            this.gridCTPX.DataSource = this.bdsCTPX;
            this.gridCTPX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCTPX.Location = new System.Drawing.Point(489, 28);
            this.gridCTPX.MainView = this.gvCTPX;
            this.gridCTPX.Name = "gridCTPX";
            this.gridCTPX.Size = new System.Drawing.Size(829, 234);
            this.gridCTPX.TabIndex = 1;
            this.gridCTPX.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCTPX});
            // 
            // bdsCTPX
            // 
            this.bdsCTPX.DataMember = "CTPX";
            this.bdsCTPX.DataSource = this.DS;
            // 
            // gvCTPX
            // 
            this.gvCTPX.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMAPX1,
            this.colMAVT1,
            this.colSOLUONG1,
            this.colDONGIA1});
            this.gvCTPX.GridControl = this.gridCTPX;
            this.gvCTPX.Name = "gvCTPX";
            // 
            // colMAPX1
            // 
            this.colMAPX1.FieldName = "MAPX";
            this.colMAPX1.MinWidth = 25;
            this.colMAPX1.Name = "colMAPX1";
            this.colMAPX1.Visible = true;
            this.colMAPX1.VisibleIndex = 0;
            this.colMAPX1.Width = 94;
            // 
            // colMAVT1
            // 
            this.colMAVT1.FieldName = "MAVT";
            this.colMAVT1.MinWidth = 25;
            this.colMAVT1.Name = "colMAVT1";
            this.colMAVT1.Visible = true;
            this.colMAVT1.VisibleIndex = 1;
            this.colMAVT1.Width = 94;
            // 
            // colSOLUONG1
            // 
            this.colSOLUONG1.FieldName = "SOLUONG";
            this.colSOLUONG1.MinWidth = 25;
            this.colSOLUONG1.Name = "colSOLUONG1";
            this.colSOLUONG1.Visible = true;
            this.colSOLUONG1.VisibleIndex = 2;
            this.colSOLUONG1.Width = 94;
            // 
            // colDONGIA1
            // 
            this.colDONGIA1.FieldName = "DONGIA";
            this.colDONGIA1.MinWidth = 25;
            this.colDONGIA1.Name = "colDONGIA1";
            this.colDONGIA1.Visible = true;
            this.colDONGIA1.VisibleIndex = 3;
            this.colDONGIA1.Width = 94;
            // 
            // gbInfoPX
            // 
            this.gbInfoPX.Controls.Add(mAPXLabel);
            this.gbInfoPX.Controls.Add(this.txtMaPX);
            this.gbInfoPX.Controls.Add(this.btnGridKho2);
            this.gbInfoPX.Controls.Add(mAKHOLabel);
            this.gbInfoPX.Controls.Add(this.txtMaKho_PX);
            this.gbInfoPX.Controls.Add(hOTENKHLabel);
            this.gbInfoPX.Controls.Add(this.txtTenKh);
            this.gbInfoPX.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbInfoPX.Location = new System.Drawing.Point(2, 28);
            this.gbInfoPX.Name = "gbInfoPX";
            this.gbInfoPX.Size = new System.Drawing.Size(487, 234);
            this.gbInfoPX.TabIndex = 0;
            this.gbInfoPX.TabStop = false;
            this.gbInfoPX.Text = "Thông tin";
            // 
            // txtMaPX
            // 
            this.txtMaPX.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsPX, "MAPX", true));
            this.txtMaPX.Location = new System.Drawing.Point(194, 55);
            this.txtMaPX.Name = "txtMaPX";
            this.txtMaPX.Size = new System.Drawing.Size(125, 23);
            this.txtMaPX.TabIndex = 7;
            // 
            // btnGridKho2
            // 
            this.btnGridKho2.Location = new System.Drawing.Point(341, 152);
            this.btnGridKho2.Name = "btnGridKho2";
            this.btnGridKho2.Size = new System.Drawing.Size(34, 23);
            this.btnGridKho2.TabIndex = 6;
            this.btnGridKho2.Text = "...";
            this.btnGridKho2.UseVisualStyleBackColor = true;
            this.btnGridKho2.Click += new System.EventHandler(this.btnGridKho_Click);
            // 
            // txtMaKho_PX
            // 
            this.txtMaKho_PX.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsPX, "MAKHO", true));
            this.txtMaKho_PX.Location = new System.Drawing.Point(194, 149);
            this.txtMaKho_PX.Name = "txtMaKho_PX";
            this.txtMaKho_PX.Properties.ReadOnly = true;
            this.txtMaKho_PX.Size = new System.Drawing.Size(125, 22);
            this.txtMaKho_PX.TabIndex = 5;
            // 
            // txtTenKh
            // 
            this.txtTenKh.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsPX, "HOTENKH", true));
            this.txtTenKh.Location = new System.Drawing.Point(194, 102);
            this.txtTenKh.Name = "txtTenKh";
            this.txtTenKh.Size = new System.Drawing.Size(125, 22);
            this.txtTenKh.TabIndex = 3;
            // 
            // gcPN
            // 
            this.gcPN.Controls.Add(this.gridCTPN);
            this.gcPN.Controls.Add(this.gridPN);
            this.gcPN.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcPN.Location = new System.Drawing.Point(0, 1053);
            this.gcPN.Name = "gcPN";
            this.gcPN.Size = new System.Drawing.Size(1320, 363);
            this.gcPN.TabIndex = 10;
            this.gcPN.Text = "Phiếu Nhập";
            // 
            // gridCTPN
            // 
            this.gridCTPN.DataSource = this.bdsCTPN;
            this.gridCTPN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCTPN.Location = new System.Drawing.Point(690, 28);
            this.gridCTPN.MainView = this.gvCTPN;
            this.gridCTPN.Name = "gridCTPN";
            this.gridCTPN.Size = new System.Drawing.Size(628, 333);
            this.gridCTPN.TabIndex = 1;
            this.gridCTPN.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCTPN});
            // 
            // bdsCTPN
            // 
            this.bdsCTPN.DataMember = "CTPN";
            this.bdsCTPN.DataSource = this.DS;
            // 
            // gvCTPN
            // 
            this.gvCTPN.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMAPN1,
            this.colMAVT2,
            this.colSOLUONG2,
            this.colDONGIA2});
            this.gvCTPN.GridControl = this.gridCTPN;
            this.gvCTPN.Name = "gvCTPN";
            // 
            // colMAPN1
            // 
            this.colMAPN1.FieldName = "MAPN";
            this.colMAPN1.MinWidth = 25;
            this.colMAPN1.Name = "colMAPN1";
            this.colMAPN1.Visible = true;
            this.colMAPN1.VisibleIndex = 0;
            this.colMAPN1.Width = 94;
            // 
            // colMAVT2
            // 
            this.colMAVT2.FieldName = "MAVT";
            this.colMAVT2.MinWidth = 25;
            this.colMAVT2.Name = "colMAVT2";
            this.colMAVT2.Visible = true;
            this.colMAVT2.VisibleIndex = 1;
            this.colMAVT2.Width = 94;
            // 
            // colSOLUONG2
            // 
            this.colSOLUONG2.FieldName = "SOLUONG";
            this.colSOLUONG2.MinWidth = 25;
            this.colSOLUONG2.Name = "colSOLUONG2";
            this.colSOLUONG2.Visible = true;
            this.colSOLUONG2.VisibleIndex = 2;
            this.colSOLUONG2.Width = 94;
            // 
            // colDONGIA2
            // 
            this.colDONGIA2.FieldName = "DONGIA";
            this.colDONGIA2.MinWidth = 25;
            this.colDONGIA2.Name = "colDONGIA2";
            this.colDONGIA2.Visible = true;
            this.colDONGIA2.VisibleIndex = 3;
            this.colDONGIA2.Width = 94;
            // 
            // gridPN
            // 
            this.gridPN.DataSource = this.bdsPN;
            this.gridPN.Dock = System.Windows.Forms.DockStyle.Left;
            this.gridPN.Location = new System.Drawing.Point(2, 28);
            this.gridPN.MainView = this.gvPN;
            this.gridPN.Name = "gridPN";
            this.gridPN.Size = new System.Drawing.Size(688, 333);
            this.gridPN.TabIndex = 0;
            this.gridPN.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPN});
            // 
            // bdsPN
            // 
            this.bdsPN.DataMember = "PHIEUNHAP";
            this.bdsPN.DataSource = this.DS;
            // 
            // gvPN
            // 
            this.gvPN.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMAPN,
            this.colNGAY2,
            this.colMasoDDH2,
            this.colMAKHO2,
            this.colMANV2});
            this.gvPN.GridControl = this.gridPN;
            this.gvPN.Name = "gvPN";
            // 
            // colMAPN
            // 
            this.colMAPN.FieldName = "MAPN";
            this.colMAPN.MinWidth = 25;
            this.colMAPN.Name = "colMAPN";
            this.colMAPN.Visible = true;
            this.colMAPN.VisibleIndex = 0;
            this.colMAPN.Width = 94;
            // 
            // colNGAY2
            // 
            this.colNGAY2.FieldName = "NGAY";
            this.colNGAY2.MinWidth = 25;
            this.colNGAY2.Name = "colNGAY2";
            this.colNGAY2.Visible = true;
            this.colNGAY2.VisibleIndex = 1;
            this.colNGAY2.Width = 94;
            // 
            // colMasoDDH2
            // 
            this.colMasoDDH2.FieldName = "MasoDDH";
            this.colMasoDDH2.MinWidth = 25;
            this.colMasoDDH2.Name = "colMasoDDH2";
            this.colMasoDDH2.Visible = true;
            this.colMasoDDH2.VisibleIndex = 2;
            this.colMasoDDH2.Width = 94;
            // 
            // colMAKHO2
            // 
            this.colMAKHO2.FieldName = "MAKHO";
            this.colMAKHO2.MinWidth = 25;
            this.colMAKHO2.Name = "colMAKHO2";
            this.colMAKHO2.Visible = true;
            this.colMAKHO2.VisibleIndex = 3;
            this.colMAKHO2.Width = 94;
            // 
            // colMANV2
            // 
            this.colMANV2.FieldName = "MANV";
            this.colMANV2.MinWidth = 25;
            this.colMANV2.Name = "colMANV2";
            this.colMANV2.Visible = true;
            this.colMANV2.VisibleIndex = 4;
            this.colMANV2.Width = 94;
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnThem,
            this.btnSua,
            this.btnXoa,
            this.btnReload,
            this.btnGhi,
            this.btnUndo,
            this.btnSwitch,
            this.btnThoat,
            this.btnDDH,
            this.btnPN,
            this.btnPX});
            this.barManager1.MaxItemId = 11;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnSua, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnXoa, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnReload, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(((DevExpress.XtraBars.BarLinkUserDefines)((DevExpress.XtraBars.BarLinkUserDefines.Caption | DevExpress.XtraBars.BarLinkUserDefines.PaintStyle))), this.btnGhi, "Ghi", false, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnUndo, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnSwitch, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThoat, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.Text = "Tools";
            // 
            // btnThem
            // 
            this.btnThem.Caption = "Thêm";
            this.btnThem.Id = 0;
            this.btnThem.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnThem.ImageOptions.SvgImage")));
            this.btnThem.Name = "btnThem";
            this.btnThem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThem_ItemClick);
            // 
            // btnSua
            // 
            this.btnSua.Caption = "Sửa";
            this.btnSua.Id = 1;
            this.btnSua.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSua.ImageOptions.SvgImage")));
            this.btnSua.Name = "btnSua";
            // 
            // btnXoa
            // 
            this.btnXoa.Caption = "Xóa";
            this.btnXoa.Id = 2;
            this.btnXoa.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.ImageOptions.Image")));
            this.btnXoa.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnXoa.ImageOptions.LargeImage")));
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnXoa_ItemClick);
            // 
            // btnReload
            // 
            this.btnReload.Caption = "Reload";
            this.btnReload.Id = 3;
            this.btnReload.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnReload.ImageOptions.SvgImage")));
            this.btnReload.Name = "btnReload";
            // 
            // btnGhi
            // 
            this.btnGhi.Caption = "barButtonItem8";
            this.btnGhi.Id = 4;
            this.btnGhi.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnGhi.ImageOptions.SvgImage")));
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGhi_ItemClick);
            // 
            // btnUndo
            // 
            this.btnUndo.Caption = "Undo";
            this.btnUndo.Id = 5;
            this.btnUndo.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnUndo.ImageOptions.SvgImage")));
            this.btnUndo.Name = "btnUndo";
            // 
            // btnSwitch
            // 
            this.btnSwitch.Caption = "Lập Phiếu";
            this.btnSwitch.Id = 6;
            this.btnSwitch.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSwitch.ImageOptions.SvgImage")));
            this.btnSwitch.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDDH),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnPN),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Caption, this.btnPX, "Phiếu Xuất")});
            this.btnSwitch.Name = "btnSwitch";
            // 
            // btnDDH
            // 
            this.btnDDH.Caption = "Đơn Đặt Hàng";
            this.btnDDH.Id = 8;
            this.btnDDH.Name = "btnDDH";
            this.btnDDH.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDDH_ItemClick);
            // 
            // btnPN
            // 
            this.btnPN.Caption = "Phiếu Nhập";
            this.btnPN.Id = 9;
            this.btnPN.Name = "btnPN";
            this.btnPN.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPN_ItemClick);
            // 
            // btnPX
            // 
            this.btnPX.Caption = "barButtonItem7";
            this.btnPX.Id = 10;
            this.btnPX.Name = "btnPX";
            this.btnPX.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPX_ItemClick);
            // 
            // btnThoat
            // 
            this.btnThoat.Caption = "Thoát";
            this.btnThoat.Id = 7;
            this.btnThoat.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnThoat.ImageOptions.SvgImage")));
            this.btnThoat.Name = "btnThoat";
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1320, 30);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 1416);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1320, 20);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 30);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 1386);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1320, 30);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 1386);
            // 
            // cmsChecked
            // 
            this.cmsChecked.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsChecked.Name = "cmsChecked";
            this.cmsChecked.Size = new System.Drawing.Size(61, 4);
            // 
            // cmsCTDDH
            // 
            this.cmsCTDDH.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsCTDDH.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miThemCTDDH});
            this.cmsCTDDH.Name = "cmsCTDDH";
            this.cmsCTDDH.Size = new System.Drawing.Size(221, 28);
            // 
            // miThemCTDDH
            // 
            this.miThemCTDDH.Name = "miThemCTDDH";
            this.miThemCTDDH.Size = new System.Drawing.Size(220, 24);
            this.miThemCTDDH.Text = "Thêm chi tiết đơn ĐH";
            // 
            // frmLapPhieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1341, 972);
            this.Controls.Add(this.gcPN);
            this.Controls.Add(this.gcPX);
            this.Controls.Add(this.gcDDH);
            this.Controls.Add(this.gridPX);
            this.Controls.Add(this.gridDDH);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmLapPhieu";
            this.Text = "frmLapPhieu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmLapPhieu_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDDH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDDH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsPX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDDH)).EndInit();
            this.gcDDH.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCTDDH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsCTDDH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCTDDH)).EndInit();
            this.gbInfoDDH.ResumeLayout(false);
            this.gbInfoDDH.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaKho_DH.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNhaCC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPX)).EndInit();
            this.gcPX.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCTPX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsCTPX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCTPX)).EndInit();
            this.gbInfoPX.ResumeLayout(false);
            this.gbInfoPX.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaKho_PX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenKh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPN)).EndInit();
            this.gcPN.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCTPN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsCTPN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCTPN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsPN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.cmsCTDDH.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbChiNhanh;
        private System.Windows.Forms.Label label1;
        private DS DS;
        private DSTableAdapters.TableAdapterManager tableAdapterManager;
        private DSTableAdapters.DATHANGTableAdapter datHangTableAdapter;
        private System.Windows.Forms.BindingSource bdsDH;
        private DevExpress.XtraGrid.GridControl gridDDH;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDDH;
        private DSTableAdapters.PHIEUXUATTableAdapter phieuXuatTableAdapter;
        private System.Windows.Forms.BindingSource bdsPX;
        private DevExpress.XtraGrid.GridControl gridPX;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPX;
        private DevExpress.XtraGrid.Columns.GridColumn colMAPX;
        private DevExpress.XtraGrid.Columns.GridColumn colNGAY;
        private DevExpress.XtraGrid.Columns.GridColumn colHOTENKH;
        private DevExpress.XtraGrid.Columns.GridColumn colMAKHO;
        private DevExpress.XtraGrid.Columns.GridColumn colMANV;
        private DevExpress.XtraGrid.Columns.GridColumn colMasoDDH;
        private DevExpress.XtraGrid.Columns.GridColumn colNGAY1;
        private DevExpress.XtraGrid.Columns.GridColumn colNhaCC;
        private DevExpress.XtraGrid.Columns.GridColumn colMAKHO1;
        private DevExpress.XtraGrid.Columns.GridColumn colMANV1;
        private DevExpress.XtraEditors.GroupControl gcDDH;
        private System.Windows.Forms.GroupBox gbInfoDDH;
        private DSTableAdapters.CTDDHTableAdapter cTDDHTableAdapter;
        private System.Windows.Forms.BindingSource bdsCTDDH;
        private DevExpress.XtraEditors.GroupControl gcPX;
        private DevExpress.XtraGrid.GridControl gridCTDDH;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCTDDH;
        private DevExpress.XtraGrid.Columns.GridColumn colMasoDDH1;
        private DevExpress.XtraGrid.Columns.GridColumn colMAVT;
        private DevExpress.XtraGrid.Columns.GridColumn colSOLUONG;
        private DevExpress.XtraGrid.Columns.GridColumn colDONGIA;
        private System.Windows.Forms.GroupBox gbInfoPX;
        private DSTableAdapters.CTPXTableAdapter cTPXTableAdapter;
        private System.Windows.Forms.BindingSource bdsCTPX;
        private DevExpress.XtraGrid.GridControl gridCTPX;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCTPX;
        private DevExpress.XtraGrid.Columns.GridColumn colMAPX1;
        private DevExpress.XtraGrid.Columns.GridColumn colMAVT1;
        private DevExpress.XtraGrid.Columns.GridColumn colSOLUONG1;
        private DevExpress.XtraGrid.Columns.GridColumn colDONGIA1;
        private DevExpress.XtraEditors.GroupControl gcPN;
        private DSTableAdapters.PHIEUNHAPTableAdapter phieuNhapTableAdapter;
        private System.Windows.Forms.BindingSource bdsPN;
        private DevExpress.XtraGrid.GridControl gridPN;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPN;
        private DevExpress.XtraGrid.Columns.GridColumn colMAPN;
        private DevExpress.XtraGrid.Columns.GridColumn colNGAY2;
        private DevExpress.XtraGrid.Columns.GridColumn colMasoDDH2;
        private DevExpress.XtraGrid.Columns.GridColumn colMAKHO2;
        private DevExpress.XtraGrid.Columns.GridColumn colMANV2;
        private DSTableAdapters.CTPNTableAdapter cTPNTableAdapter;
        private System.Windows.Forms.BindingSource bdsCTPN;
        private DevExpress.XtraGrid.GridControl gridCTPN;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCTPN;
        private DevExpress.XtraGrid.Columns.GridColumn colMAPN1;
        private DevExpress.XtraGrid.Columns.GridColumn colMAVT2;
        private DevExpress.XtraGrid.Columns.GridColumn colSOLUONG2;
        private DevExpress.XtraGrid.Columns.GridColumn colDONGIA2;
        private DevExpress.XtraEditors.TextEdit txtTenKh;
        private System.Windows.Forms.Button btnGridKho2;
        private System.Windows.Forms.Button btnGridKho;
        private DevExpress.XtraEditors.TextEdit txtNhaCC;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem btnThem;
        private DevExpress.XtraBars.BarButtonItem btnSua;
        private DevExpress.XtraBars.BarButtonItem btnXoa;
        private DevExpress.XtraBars.BarButtonItem btnReload;
        private DevExpress.XtraBars.BarButtonItem btnGhi;
        private DevExpress.XtraBars.BarButtonItem btnUndo;
        private DevExpress.XtraBars.BarButtonItem btnDDH;
        private DevExpress.XtraBars.BarButtonItem btnPN;
        private DevExpress.XtraBars.BarButtonItem btnPX;
        private DevExpress.XtraBars.BarButtonItem btnThoat;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        public DevExpress.XtraBars.BarSubItem btnSwitch;
        private System.Windows.Forms.TextBox txtMaDDH;
        private System.Windows.Forms.TextBox txtMaPX;
        public DevExpress.XtraEditors.TextEdit txtMaKho_PX;
        public DevExpress.XtraEditors.TextEdit txtMaKho_DH;
        private System.Windows.Forms.ContextMenuStrip cmsChecked;
        private System.Windows.Forms.ContextMenuStrip cmsCTDDH;
        private System.Windows.Forms.ToolStripMenuItem miThemCTDDH;
    }
}
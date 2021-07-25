namespace QLVT_DH.SimpleForm
{
    partial class frmDonDatHang
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
            System.Windows.Forms.Label masoDDHLabel;
            System.Windows.Forms.Label nhaCCLabel;
            System.Windows.Forms.Label mAKHOLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDonDatHang));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnThem = new DevExpress.XtraBars.BarButtonItem();
            this.btnSua = new DevExpress.XtraBars.BarButtonItem();
            this.btnXoa = new DevExpress.XtraBars.BarButtonItem();
            this.btnGhi = new DevExpress.XtraBars.BarButtonItem();
            this.btnUndo = new DevExpress.XtraBars.BarButtonItem();
            this.btnReload = new DevExpress.XtraBars.BarButtonItem();
            this.btnThemCTDDH = new DevExpress.XtraBars.BarButtonItem();
            this.btnGhiCTDDH = new DevExpress.XtraBars.BarButtonItem();
            this.btnXoaCTDDH = new DevExpress.XtraBars.BarButtonItem();
            this.btnThoat = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbChiNhanh = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DS = new QLVT_DH.DS();
            this.bdsDH = new System.Windows.Forms.BindingSource(this.components);
            this.datHangTableAdapter = new QLVT_DH.DSTableAdapters.DATHANGTableAdapter();
            this.tableAdapterManager = new QLVT_DH.DSTableAdapters.TableAdapterManager();
            this.gridDDH = new DevExpress.XtraGrid.GridControl();
            this.gvDH = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMasoDDH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNGAY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNhaCC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMAKHO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMANV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcInfoDDH = new System.Windows.Forms.GroupBox();
            this.cTDDHGridControl = new DevExpress.XtraGrid.GridControl();
            this.bdsCTDDH = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMasoDDH1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMAVT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSOLUONG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDONGIA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gbInfoDDH = new System.Windows.Forms.GroupBox();
            this.btnGridKho = new System.Windows.Forms.Button();
            this.txtMaKho = new DevExpress.XtraEditors.TextEdit();
            this.txtMaNCC = new DevExpress.XtraEditors.TextEdit();
            this.txtMaDDH = new System.Windows.Forms.TextBox();
            this.cTDDHTableAdapter = new QLVT_DH.DSTableAdapters.CTDDHTableAdapter();
            this.bdsPN = new System.Windows.Forms.BindingSource(this.components);
            this.pHIEUNHAPTableAdapter = new QLVT_DH.DSTableAdapters.PHIEUNHAPTableAdapter();
            this.btnBreak = new DevExpress.XtraBars.BarButtonItem();
            masoDDHLabel = new System.Windows.Forms.Label();
            nhaCCLabel = new System.Windows.Forms.Label();
            mAKHOLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDDH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDH)).BeginInit();
            this.gcInfoDDH.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cTDDHGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsCTDDH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.gbInfoDDH.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaKho.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaNCC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsPN)).BeginInit();
            this.SuspendLayout();
            // 
            // masoDDHLabel
            // 
            masoDDHLabel.AutoSize = true;
            masoDDHLabel.Location = new System.Drawing.Point(42, 87);
            masoDDHLabel.Name = "masoDDHLabel";
            masoDDHLabel.Size = new System.Drawing.Size(80, 17);
            masoDDHLabel.TabIndex = 0;
            masoDDHLabel.Text = "Maso DDH:";
            // 
            // nhaCCLabel
            // 
            nhaCCLabel.AutoSize = true;
            nhaCCLabel.Location = new System.Drawing.Point(44, 134);
            nhaCCLabel.Name = "nhaCCLabel";
            nhaCCLabel.Size = new System.Drawing.Size(60, 17);
            nhaCCLabel.TabIndex = 2;
            nhaCCLabel.Text = "Nha CC:";
            // 
            // mAKHOLabel
            // 
            mAKHOLabel.AutoSize = true;
            mAKHOLabel.Location = new System.Drawing.Point(45, 187);
            mAKHOLabel.Name = "mAKHOLabel";
            mAKHOLabel.Size = new System.Drawing.Size(62, 17);
            mAKHOLabel.TabIndex = 4;
            mAKHOLabel.Text = "MAKHO:";
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
            this.btnXoa,
            this.btnGhi,
            this.btnUndo,
            this.btnReload,
            this.btnSua,
            this.btnThoat,
            this.btnThemCTDDH,
            this.btnGhiCTDDH,
            this.btnXoaCTDDH,
            this.btnBreak});
            this.barManager1.MaxItemId = 12;
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnGhi, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnUndo, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnReload, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnBreak, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThemCTDDH, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnGhiCTDDH, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnXoaCTDDH, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
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
            this.btnSua.Id = 5;
            this.btnSua.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSua.ImageOptions.SvgImage")));
            this.btnSua.Name = "btnSua";
            this.btnSua.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSua_ItemClick);
            // 
            // btnXoa
            // 
            this.btnXoa.Caption = "Xóa";
            this.btnXoa.Id = 1;
            this.btnXoa.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.ImageOptions.Image")));
            this.btnXoa.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnXoa.ImageOptions.LargeImage")));
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnXoa_ItemClick);
            // 
            // btnGhi
            // 
            this.btnGhi.Caption = "Ghi";
            this.btnGhi.Id = 2;
            this.btnGhi.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnGhi.ImageOptions.SvgImage")));
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGhi_ItemClick);
            // 
            // btnUndo
            // 
            this.btnUndo.Caption = "Undo";
            this.btnUndo.Id = 3;
            this.btnUndo.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnUndo.ImageOptions.SvgImage")));
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnUndo_ItemClick);
            // 
            // btnReload
            // 
            this.btnReload.Caption = "Reload";
            this.btnReload.Id = 4;
            this.btnReload.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnReload.ImageOptions.SvgImage")));
            this.btnReload.Name = "btnReload";
            this.btnReload.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnReload_ItemClick);
            // 
            // btnThemCTDDH
            // 
            this.btnThemCTDDH.Caption = "Thêm CTĐĐH";
            this.btnThemCTDDH.Id = 7;
            this.btnThemCTDDH.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThemCTDDH.ImageOptions.Image")));
            this.btnThemCTDDH.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnThemCTDDH.ImageOptions.LargeImage")));
            this.btnThemCTDDH.Name = "btnThemCTDDH";
            this.btnThemCTDDH.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThemCTDDH_ItemClick);
            // 
            // btnGhiCTDDH
            // 
            this.btnGhiCTDDH.Caption = "Ghi CTDĐH";
            this.btnGhiCTDDH.Id = 8;
            this.btnGhiCTDDH.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGhiCTDDH.ImageOptions.Image")));
            this.btnGhiCTDDH.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnGhiCTDDH.ImageOptions.LargeImage")));
            this.btnGhiCTDDH.Name = "btnGhiCTDDH";
            this.btnGhiCTDDH.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGhiCTDDH_ItemClick);
            // 
            // btnXoaCTDDH
            // 
            this.btnXoaCTDDH.Caption = "Xóa CTDDH";
            this.btnXoaCTDDH.Id = 9;
            this.btnXoaCTDDH.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnXoaCTDDH.ImageOptions.Image")));
            this.btnXoaCTDDH.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnXoaCTDDH.ImageOptions.LargeImage")));
            this.btnXoaCTDDH.Name = "btnXoaCTDDH";
            this.btnXoaCTDDH.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnXoaCTDDH_ItemClick);
            // 
            // btnThoat
            // 
            this.btnThoat.Caption = "Thoát";
            this.btnThoat.Id = 6;
            this.btnThoat.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnThoat.ImageOptions.SvgImage")));
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThoat_ItemClick);
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
            this.barDockControlTop.Size = new System.Drawing.Size(1236, 30);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 662);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1236, 20);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 30);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 632);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1236, 30);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 632);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbChiNhanh);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1236, 97);
            this.panel1.TabIndex = 4;
            // 
            // cmbChiNhanh
            // 
            this.cmbChiNhanh.FormattingEnabled = true;
            this.cmbChiNhanh.Location = new System.Drawing.Point(412, 31);
            this.cmbChiNhanh.Name = "cmbChiNhanh";
            this.cmbChiNhanh.Size = new System.Drawing.Size(268, 24);
            this.cmbChiNhanh.TabIndex = 1;
            this.cmbChiNhanh.SelectedIndexChanged += new System.EventHandler(this.cmbChiNhanh_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(215, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chi Nhánh";
            // 
            // DS
            // 
            this.DS.DataSetName = "DS";
            this.DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bdsDH
            // 
            this.bdsDH.DataMember = "DATHANG";
            this.bdsDH.DataSource = this.DS;
            // 
            // datHangTableAdapter
            // 
            this.datHangTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.ChiNhanhTableAdapter = null;
            this.tableAdapterManager.CTDDHTableAdapter = null;
            this.tableAdapterManager.CTPNTableAdapter = null;
            this.tableAdapterManager.CTPXTableAdapter = null;
            this.tableAdapterManager.DATHANGTableAdapter = this.datHangTableAdapter;
            this.tableAdapterManager.KhoTableAdapter = null;
            this.tableAdapterManager.NHANVIENTableAdapter = null;
            this.tableAdapterManager.PHIEUNHAPTableAdapter = null;
            this.tableAdapterManager.PHIEUXUATTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = QLVT_DH.DSTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.VattuTableAdapter = null;
            // 
            // gridDDH
            // 
            this.gridDDH.DataSource = this.bdsDH;
            this.gridDDH.Dock = System.Windows.Forms.DockStyle.Top;
            this.gridDDH.Location = new System.Drawing.Point(0, 127);
            this.gridDDH.MainView = this.gvDH;
            this.gridDDH.MenuManager = this.barManager1;
            this.gridDDH.Name = "gridDDH";
            this.gridDDH.Size = new System.Drawing.Size(1236, 303);
            this.gridDDH.TabIndex = 6;
            this.gridDDH.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDH});
            // 
            // gvDH
            // 
            this.gvDH.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMasoDDH,
            this.colNGAY,
            this.colNhaCC,
            this.colMAKHO,
            this.colMANV});
            this.gvDH.GridControl = this.gridDDH;
            this.gvDH.Name = "gvDH";
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
            // gcInfoDDH
            // 
            this.gcInfoDDH.Controls.Add(this.cTDDHGridControl);
            this.gcInfoDDH.Controls.Add(this.gbInfoDDH);
            this.gcInfoDDH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcInfoDDH.Location = new System.Drawing.Point(0, 430);
            this.gcInfoDDH.Name = "gcInfoDDH";
            this.gcInfoDDH.Size = new System.Drawing.Size(1236, 232);
            this.gcInfoDDH.TabIndex = 7;
            this.gcInfoDDH.TabStop = false;
            // 
            // cTDDHGridControl
            // 
            this.cTDDHGridControl.DataSource = this.bdsCTDDH;
            this.cTDDHGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cTDDHGridControl.Location = new System.Drawing.Point(467, 18);
            this.cTDDHGridControl.MainView = this.gridView1;
            this.cTDDHGridControl.MenuManager = this.barManager1;
            this.cTDDHGridControl.Name = "cTDDHGridControl";
            this.cTDDHGridControl.Size = new System.Drawing.Size(766, 211);
            this.cTDDHGridControl.TabIndex = 1;
            this.cTDDHGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // bdsCTDDH
            // 
            this.bdsCTDDH.DataMember = "FK_CTDDH_DatHang";
            this.bdsCTDDH.DataSource = this.bdsDH;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMasoDDH1,
            this.colMAVT,
            this.colSOLUONG,
            this.colDONGIA});
            this.gridView1.GridControl = this.cTDDHGridControl;
            this.gridView1.Name = "gridView1";
            // 
            // colMasoDDH1
            // 
            this.colMasoDDH1.FieldName = "MasoDDH";
            this.colMasoDDH1.MinWidth = 25;
            this.colMasoDDH1.Name = "colMasoDDH1";
            this.colMasoDDH1.OptionsColumn.AllowEdit = false;
            this.colMasoDDH1.OptionsColumn.AllowFocus = false;
            this.colMasoDDH1.Visible = true;
            this.colMasoDDH1.VisibleIndex = 0;
            this.colMasoDDH1.Width = 94;
            // 
            // colMAVT
            // 
            this.colMAVT.FieldName = "MAVT";
            this.colMAVT.MinWidth = 25;
            this.colMAVT.Name = "colMAVT";
            this.colMAVT.OptionsColumn.AllowEdit = false;
            this.colMAVT.OptionsColumn.AllowFocus = false;
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
            this.gbInfoDDH.Controls.Add(this.btnGridKho);
            this.gbInfoDDH.Controls.Add(mAKHOLabel);
            this.gbInfoDDH.Controls.Add(this.txtMaKho);
            this.gbInfoDDH.Controls.Add(nhaCCLabel);
            this.gbInfoDDH.Controls.Add(this.txtMaNCC);
            this.gbInfoDDH.Controls.Add(masoDDHLabel);
            this.gbInfoDDH.Controls.Add(this.txtMaDDH);
            this.gbInfoDDH.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbInfoDDH.Location = new System.Drawing.Point(3, 18);
            this.gbInfoDDH.Name = "gbInfoDDH";
            this.gbInfoDDH.Size = new System.Drawing.Size(464, 211);
            this.gbInfoDDH.TabIndex = 0;
            this.gbInfoDDH.TabStop = false;
            this.gbInfoDDH.Text = "Thông tin";
            // 
            // btnGridKho
            // 
            this.btnGridKho.Location = new System.Drawing.Point(359, 187);
            this.btnGridKho.Name = "btnGridKho";
            this.btnGridKho.Size = new System.Drawing.Size(30, 23);
            this.btnGridKho.TabIndex = 6;
            this.btnGridKho.Text = "...";
            this.btnGridKho.UseVisualStyleBackColor = true;
            this.btnGridKho.Click += new System.EventHandler(this.btnGridKho_Click);
            // 
            // txtMaKho
            // 
            this.txtMaKho.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsDH, "MAKHO", true));
            this.txtMaKho.Location = new System.Drawing.Point(143, 182);
            this.txtMaKho.MenuManager = this.barManager1;
            this.txtMaKho.Name = "txtMaKho";
            this.txtMaKho.Properties.ReadOnly = true;
            this.txtMaKho.Size = new System.Drawing.Size(195, 22);
            this.txtMaKho.TabIndex = 5;
            this.txtMaKho.UseWaitCursor = true;
            // 
            // txtMaNCC
            // 
            this.txtMaNCC.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsDH, "NhaCC", true));
            this.txtMaNCC.Location = new System.Drawing.Point(143, 131);
            this.txtMaNCC.MenuManager = this.barManager1;
            this.txtMaNCC.Name = "txtMaNCC";
            this.txtMaNCC.Size = new System.Drawing.Size(195, 22);
            this.txtMaNCC.TabIndex = 3;
            // 
            // txtMaDDH
            // 
            this.txtMaDDH.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsDH, "MasoDDH", true));
            this.txtMaDDH.Location = new System.Drawing.Point(143, 84);
            this.txtMaDDH.Name = "txtMaDDH";
            this.txtMaDDH.Size = new System.Drawing.Size(195, 22);
            this.txtMaDDH.TabIndex = 1;
            // 
            // cTDDHTableAdapter
            // 
            this.cTDDHTableAdapter.ClearBeforeFill = true;
            // 
            // bdsPN
            // 
            this.bdsPN.DataMember = "FK_PhieuNhap_DatHang";
            this.bdsPN.DataSource = this.bdsDH;
            // 
            // pHIEUNHAPTableAdapter
            // 
            this.pHIEUNHAPTableAdapter.ClearBeforeFill = true;
            // 
            // btnBreak
            // 
            this.btnBreak.Caption = "Break";
            this.btnBreak.Id = 11;
            this.btnBreak.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBreak.ImageOptions.Image")));
            this.btnBreak.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnBreak.ImageOptions.LargeImage")));
            this.btnBreak.Name = "btnBreak";
            this.btnBreak.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBreak_ItemClick);
            // 
            // frmDonDatHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1236, 682);
            this.Controls.Add(this.gcInfoDDH);
            this.Controls.Add(this.gridDDH);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmDonDatHang";
            this.Text = "frmDonDatHang";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDonDatHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDDH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDH)).EndInit();
            this.gcInfoDDH.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cTDDHGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsCTDDH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.gbInfoDDH.ResumeLayout(false);
            this.gbInfoDDH.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaKho.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaNCC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsPN)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem btnThem;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnXoa;
        private DevExpress.XtraBars.BarButtonItem btnGhi;
        private DevExpress.XtraBars.BarButtonItem btnUndo;
        private DevExpress.XtraBars.BarButtonItem btnReload;
        private DevExpress.XtraBars.BarButtonItem btnSua;
        private DevExpress.XtraBars.BarButtonItem btnThoat;
        private System.Windows.Forms.BindingSource bdsDH;
        private DS DS;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbChiNhanh;
        private System.Windows.Forms.Label label1;
        private DSTableAdapters.DATHANGTableAdapter datHangTableAdapter;
        private DSTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.GroupBox gcInfoDDH;
        private DevExpress.XtraGrid.GridControl gridDDH;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDH;
        private DevExpress.XtraGrid.Columns.GridColumn colMasoDDH;
        private DevExpress.XtraGrid.Columns.GridColumn colNGAY;
        private DevExpress.XtraGrid.Columns.GridColumn colNhaCC;
        private DevExpress.XtraGrid.Columns.GridColumn colMAKHO;
        private DevExpress.XtraGrid.Columns.GridColumn colMANV;
        private System.Windows.Forms.GroupBox gbInfoDDH;
        private DevExpress.XtraEditors.TextEdit txtMaNCC;
        private System.Windows.Forms.TextBox txtMaDDH;
        private System.Windows.Forms.Button btnGridKho;
        public DevExpress.XtraEditors.TextEdit txtMaKho;
        private System.Windows.Forms.BindingSource bdsCTDDH;
        private DSTableAdapters.CTDDHTableAdapter cTDDHTableAdapter;
        private DevExpress.XtraGrid.GridControl cTDDHGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colMasoDDH1;
        private DevExpress.XtraGrid.Columns.GridColumn colMAVT;
        private DevExpress.XtraGrid.Columns.GridColumn colSOLUONG;
        private DevExpress.XtraGrid.Columns.GridColumn colDONGIA;
        private System.Windows.Forms.BindingSource bdsPN;
        private DSTableAdapters.PHIEUNHAPTableAdapter pHIEUNHAPTableAdapter;
        private DevExpress.XtraBars.BarButtonItem btnThemCTDDH;
        private DevExpress.XtraBars.BarButtonItem btnGhiCTDDH;
        private DevExpress.XtraBars.BarButtonItem btnXoaCTDDH;
        private DevExpress.XtraBars.BarButtonItem btnBreak;
    }
}
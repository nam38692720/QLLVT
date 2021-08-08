namespace QLVT_DH
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barButtonItem_ListEmployee = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_listProduct = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_ListKho = new DevExpress.XtraBars.BarButtonItem();
            this.btnLapDDH = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_CreateAccount = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_out = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_DSNV = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_DSVT = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_CTSLNX = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_DHCPN = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_HDNV = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_THNX = new DevExpress.XtraBars.BarButtonItem();
            this.btnLapPX = new DevExpress.XtraBars.BarButtonItem();
            this.btnPN = new DevExpress.XtraBars.BarButtonItem();
            this.DanhSach = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.TENNV = new System.Windows.Forms.ToolStripStatusLabel();
            this.MANV = new System.Windows.Forms.ToolStripStatusLabel();
            this.ROLE = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.barButtonItem_ListEmployee,
            this.barButtonItem_listProduct,
            this.barButtonItem_ListKho,
            this.btnLapDDH,
            this.barButtonItem_CreateAccount,
            this.barButtonItem_out,
            this.barButtonItem_DSNV,
            this.barButtonItem_DSVT,
            this.barButtonItem_CTSLNX,
            this.barButtonItem_DHCPN,
            this.barButtonItem_HDNV,
            this.barButtonItem_THNX,
            this.btnLapPX,
            this.btnPN});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ribbonControl1.MaxItemId = 16;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.DanhSach,
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(1204, 193);
            // 
            // barButtonItem_ListEmployee
            // 
            this.barButtonItem_ListEmployee.Caption = "Nhân viên";
            this.barButtonItem_ListEmployee.Id = 1;
            this.barButtonItem_ListEmployee.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem_ListEmployee.ImageOptions.SvgImage")));
            this.barButtonItem_ListEmployee.Name = "barButtonItem_ListEmployee";
            this.barButtonItem_ListEmployee.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItem_ListEmployee.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_ListEmployee_ItemClick);
            // 
            // barButtonItem_listProduct
            // 
            this.barButtonItem_listProduct.Caption = "Vật tư";
            this.barButtonItem_listProduct.Id = 2;
            this.barButtonItem_listProduct.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem_listProduct.ImageOptions.SvgImage")));
            this.barButtonItem_listProduct.Name = "barButtonItem_listProduct";
            this.barButtonItem_listProduct.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItem_listProduct.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_listProduct_ItemClick);
            // 
            // barButtonItem_ListKho
            // 
            this.barButtonItem_ListKho.Caption = "Kho";
            this.barButtonItem_ListKho.Id = 3;
            this.barButtonItem_ListKho.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem_ListKho.ImageOptions.SvgImage")));
            this.barButtonItem_ListKho.Name = "barButtonItem_ListKho";
            this.barButtonItem_ListKho.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItem_ListKho.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_ListKho_ItemClick);
            // 
            // btnLapDDH
            // 
            this.btnLapDDH.Caption = "Đơn Đặt Hàng";
            this.btnLapDDH.Id = 5;
            this.btnLapDDH.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLapDDH.ImageOptions.Image")));
            this.btnLapDDH.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnLapDDH.ImageOptions.LargeImage")));
            this.btnLapDDH.Name = "btnLapDDH";
            this.btnLapDDH.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnLapDDH.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLapPhieu_ItemClick);
            // 
            // barButtonItem_CreateAccount
            // 
            this.barButtonItem_CreateAccount.Caption = "Thêm tài khoản";
            this.barButtonItem_CreateAccount.Id = 6;
            this.barButtonItem_CreateAccount.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem_CreateAccount.ImageOptions.SvgImage")));
            this.barButtonItem_CreateAccount.Name = "barButtonItem_CreateAccount";
            this.barButtonItem_CreateAccount.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItem_CreateAccount.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_CreateAccount_ItemClick);
            // 
            // barButtonItem_out
            // 
            this.barButtonItem_out.Caption = "Đăng xuất";
            this.barButtonItem_out.Id = 7;
            this.barButtonItem_out.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem_out.ImageOptions.Image")));
            this.barButtonItem_out.Name = "barButtonItem_out";
            this.barButtonItem_out.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItem_out.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_out_ItemClick);
            // 
            // barButtonItem_DSNV
            // 
            this.barButtonItem_DSNV.Caption = "Danh Sách Nhân Viên";
            this.barButtonItem_DSNV.Id = 8;
            this.barButtonItem_DSNV.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem_DSNV.ImageOptions.SvgImage")));
            this.barButtonItem_DSNV.Name = "barButtonItem_DSNV";
            this.barButtonItem_DSNV.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItem_DSNV.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_DSNV_ItemClick);
            // 
            // barButtonItem_DSVT
            // 
            this.barButtonItem_DSVT.Caption = "Danh Sách Vật Tư";
            this.barButtonItem_DSVT.Id = 9;
            this.barButtonItem_DSVT.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem_DSVT.ImageOptions.SvgImage")));
            this.barButtonItem_DSVT.Name = "barButtonItem_DSVT";
            this.barButtonItem_DSVT.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItem_DSVT.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_DSVT_ItemClick);
            // 
            // barButtonItem_CTSLNX
            // 
            this.barButtonItem_CTSLNX.Caption = "Chi Tiết SL Nhập Xuất";
            this.barButtonItem_CTSLNX.Id = 10;
            this.barButtonItem_CTSLNX.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem_CTSLNX.ImageOptions.SvgImage")));
            this.barButtonItem_CTSLNX.Name = "barButtonItem_CTSLNX";
            this.barButtonItem_CTSLNX.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItem_DHCPN
            // 
            this.barButtonItem_DHCPN.Caption = "Đơn ĐH Chưa Có Phiếu Nhập";
            this.barButtonItem_DHCPN.Id = 11;
            this.barButtonItem_DHCPN.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem_DHCPN.ImageOptions.SvgImage")));
            this.barButtonItem_DHCPN.Name = "barButtonItem_DHCPN";
            this.barButtonItem_DHCPN.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItem_DHCPN.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_DHCPN_ItemClick);
            // 
            // barButtonItem_HDNV
            // 
            this.barButtonItem_HDNV.Caption = "Hoạt Động Nhân Viên";
            this.barButtonItem_HDNV.Id = 12;
            this.barButtonItem_HDNV.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem_HDNV.ImageOptions.SvgImage")));
            this.barButtonItem_HDNV.Name = "barButtonItem_HDNV";
            this.barButtonItem_HDNV.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItem_THNX
            // 
            this.barButtonItem_THNX.Caption = "Tổng Hợp Nhập Xuất";
            this.barButtonItem_THNX.Id = 13;
            this.barButtonItem_THNX.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem_THNX.ImageOptions.SvgImage")));
            this.barButtonItem_THNX.Name = "barButtonItem_THNX";
            this.barButtonItem_THNX.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItem_THNX.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_THNX_ItemClick);
            // 
            // btnLapPX
            // 
            this.btnLapPX.Caption = "Phiếu Xuất";
            this.btnLapPX.Id = 14;
            this.btnLapPX.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLapPX.ImageOptions.Image")));
            this.btnLapPX.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnLapPX.ImageOptions.LargeImage")));
            this.btnLapPX.Name = "btnLapPX";
            this.btnLapPX.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnLapPX.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLapPX_ItemClick);
            // 
            // btnPN
            // 
            this.btnPN.Caption = "Phiếu Nhập";
            this.btnPN.Id = 15;
            this.btnPN.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPN.ImageOptions.Image")));
            this.btnPN.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnPN.ImageOptions.LargeImage")));
            this.btnPN.Name = "btnPN";
            this.btnPN.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnPN.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPN_ItemClick);
            // 
            // DanhSach
            // 
            this.DanhSach.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup3});
            this.DanhSach.Name = "DanhSach";
            this.DanhSach.Text = "Danh sách";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem_ListEmployee);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem_listProduct);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem_ListKho);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnLapDDH);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnLapPX);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnPN);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonItem_CreateAccount);
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonItem_out);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Báo cáo";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem_DSNV);
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem_DSVT);
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem_CTSLNX);
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem_DHCPN);
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem_HDNV);
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem_THNX);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TENNV,
            this.MANV,
            this.ROLE});
            this.statusStrip1.Location = new System.Drawing.Point(0, 572);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1204, 25);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // TENNV
            // 
            this.TENNV.Name = "TENNV";
            this.TENNV.Size = new System.Drawing.Size(59, 20);
            this.TENNV.Text = "TENNV:";
            // 
            // MANV
            // 
            this.MANV.Name = "MANV";
            this.MANV.Size = new System.Drawing.Size(55, 20);
            this.MANV.Text = "MANV:";
            // 
            // ROLE
            // 
            this.ROLE.Name = "ROLE";
            this.ROLE.Size = new System.Drawing.Size(47, 20);
            this.ROLE.Text = "ROLE:";
            // 
            // statusStrip2
            // 
            this.statusStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip2.Location = new System.Drawing.Point(0, 550);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(1204, 22);
            this.statusStrip2.TabIndex = 3;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1204, 597);
            this.Controls.Add(this.statusStrip2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ribbonControl1);
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmMain";
            this.Ribbon = this.ribbonControl1;
            this.Text = "Quản Lí Vật Tư";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage DanhSach;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel TENNV;
        private System.Windows.Forms.ToolStripStatusLabel MANV;
        private System.Windows.Forms.ToolStripStatusLabel ROLE;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_ListEmployee;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_listProduct;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_ListKho;
        private DevExpress.XtraBars.BarButtonItem btnLapDDH;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_CreateAccount;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_out;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_DSNV;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_DSVT;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_CTSLNX;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_DHCPN;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_HDNV;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_THNX;
        public System.Windows.Forms.Timer timer1;
        private DevExpress.XtraBars.BarButtonItem btnLapPX;
        private DevExpress.XtraBars.BarButtonItem btnPN;
    }
}


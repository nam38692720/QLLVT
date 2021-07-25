using QLVT_DH.SimpleForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;

namespace QLVT_DH
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();
            MANV.Text = "Mã nhân viên: " + Program.username;
            TENNV.Text = "Họ Tên: " + Program.mHoten;
            ROLE.Text = "Chức vụ: " + Program.mGroup;
        }
        private Form CheckExists(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
                if (f.GetType() == ftype)
                    return f;
            return null;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void barButtonItem_ListKho_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form form = this.CheckExists(typeof(frmKho));
            if (form != null) form.Activate();
            else
            {
                frmKho frmKho = new frmKho();
                frmKho.MdiParent = this;
                frmKho.Show();
            }
        }

        private void barButtonItem_out_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
   
            this.Close();
            frmDangNhap f = new frmDangNhap();
            f.Show();
        }

        private void barButtonItem_ListEmployee_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frmChinh = this.CheckExists(typeof(frmNhanVien));
            if (frmChinh != null) frmChinh.Activate();
            else
            {
                frmNhanVien frmNhanVien = new frmNhanVien();
                frmNhanVien.MdiParent = this;
                frmNhanVien.Show();
            }
        }

        private void btnLapPhieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Form form = this.CheckExists(typeof(frmLapPhieu));
            //if (form != null) form.Activate();
            //else
            //{
            //    Program.frmLapPhieu = new frmLapPhieu();
            //    Program.frmLapPhieu.MdiParent = this;
            //    Program.frmLapPhieu.Show();
            //    Program.frmLapPhieu.btnSwitch.Links[0].Caption = "Đặt Hàng";
            //}

            Form form = this.CheckExists(typeof(frmDonDatHang));
            if (form != null) form.Activate();
            else
            {
                Program.frmDonDatHang = new frmDonDatHang();
                Program.frmDonDatHang.MdiParent = this;
                Program.frmDonDatHang.Show();
                //Program.frmLapPhieu.btnSwitch.Links[0].Caption = "Đặt Hàng";
            }
        }

        private void barButtonItem_DSVT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraReport1 rp = new XtraReport1();
            ReportPrintTool print = new ReportPrintTool(rp);
            print.ShowPreviewDialog();
        }


        private void btnLapPX_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form form = this.CheckExists(typeof(frmPhieuXuat));
            if (form != null) form.Activate();
            else
            {
                Program.frmPhieuXuat = new frmPhieuXuat();
                Program.frmPhieuXuat.MdiParent = this;
                Program.frmPhieuXuat.Show();
            }
        }

        private void btnPN_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form form = this.CheckExists(typeof(frmLapPhieu));
            if (form != null) form.Activate();
            else
            {
                Program.frmLapPhieu = new frmLapPhieu();
                Program.frmLapPhieu.MdiParent = this;
                Program.frmLapPhieu.Show();
                Program.frmLapPhieu.btnSwitch.Links[0].Caption = "Đặt Hàng";
            }
        }

        //public bool checkFromExit(Form form)
        //{
        //    Form formCheck = this.CheckExists(typeof(form));
        //    if (formCheck != null) return true;
        //    else return false;
        //}
    }
}

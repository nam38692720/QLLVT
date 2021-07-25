using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using QLVT_DH.SubForm;

namespace QLVT_DH.SimpleForm
{
    public partial class frmLapPhieu : Form
    {
        // Do form phiếu thiết kế theo kiểu tổng hợp của 3 loại phiếu,
        // nên tùy vào user chọn phiếu nào hệ thống sẽ gán binding source tương ứng
        BindingSource current_bds = null;
        GridControl current_gc = null;
        GroupBox current_gb = null; // Khu vực điền thông tin phiếu
        string type = "";


        int position = 0;
        string maCN = "";

        // Undo Type
        String THEM_BTN = "_them"; // Click btn thêm
        String THEMPN_BTN = "_thempn"; // Click menu item thêm phiếu nhập
        String XOA_BTN = "_xoa"; // Click btn xóa
        String GHI_BTN = "_ghi"; // Click btn ghi
        String GHIPN_BTN = "_pn"; // Click menu item ghi phiếu nhập
        public string GHI_CTP_BTN = "_ctp"; // Click btn ghi của subform chi tiết phiếu xuất/ddh
        public bool check_ctp = false; // để biết là đang CRUD trên các table chi tiết phiếu

        // Stack
        public Stack<String> historyDDH;
        public Stack<String> historyPX;
        public Stack<String> historyPN;

        public frmLapPhieu()
        {
            InitializeComponent();
        }

        private void themFunc()
        {
            current_bds.AddNew();
            btnThem.Enabled = btnXoa.Enabled = btnSwitch.Enabled = false;
            current_gc.Enabled = btnReload.Enabled = false;
            current_gb.Enabled = btnGhi.Enabled = true;
            ((DataRowView)current_bds[current_bds.Position])["MANV"] = Program.maNV;
            ((DataRowView)current_bds[current_bds.Position])["NGAY"] = DateTime.Today;
        }

        // ------ UNDO ------
        private void pushHistory(string data)
        {
            if (btnSwitch.Links[0].Caption.Equals("Đặt Hàng"))
            {
                historyDDH.Push(data);
            }
            else if (btnSwitch.Links[0].Caption.Equals("Phiếu Xuất"))
            {
                historyPX.Push(data);
            }
            else if (btnSwitch.Links[0].Caption.Equals("Phiếu Nhập"))
            {
                historyPN.Push(data);
            }
        }

        private void cTDDHBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsCTDDH.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);

        }

        private void frmLapPhieu_Load(object sender, EventArgs e)
        {
            
            gridDDH.Height = 380;
            gridPX.Height = 380;
            gcDDH.Height = 240;
            gcDDH.Height = 240;
            gcPN.Height = 240;

            DS.EnforceConstraints = false;
           
            // TODO: This line of code loads data into the 'dS.DATHANG' table. You can move, or remove it, as needed.
            this.datHangTableAdapter.Connection.ConnectionString = Program.connstr;
            this.datHangTableAdapter.Fill(this.DS.DATHANG);
            this.cTDDHTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTDDHTableAdapter.Fill(this.DS.CTDDH);

            // TODO: This line of code loads data into the 'dS.PHIEUXUAT' table. You can move, or remove it, as needed.
            this.phieuXuatTableAdapter.Connection.ConnectionString = Program.connstr;
            this.phieuXuatTableAdapter.Fill(this.DS.PHIEUXUAT);
            this.cTPXTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTPXTableAdapter.Fill(this.DS.CTPX);

            // TODO: This line of code loads data into the 'DS.CTPN' table. You can move, or remove it, as needed.
            this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
            this.phieuNhapTableAdapter.Fill(this.DS.PHIEUNHAP);
            this.cTPNTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTPNTableAdapter.Fill(this.DS.CTPN);

            if (Program.bds_dspm.Count == 3) Program.bds_dspm.RemoveAt(2);

            cmbChiNhanh.DataSource = Program.bds_dspm;  // sao chép bds_dspm đã load ở form đăng nhập  qua
            cmbChiNhanh.DisplayMember = "TENCN";
            cmbChiNhanh.ValueMember = "TENSERVER";
            cmbChiNhanh.SelectedIndex = Program.mChiNhanh;


            if (Program.mGroup == "CONGTY")
            {
                cmbChiNhanh.Enabled = true;  // bật tắt theo phân quyền
                btnThem.Enabled = btnXoa.Enabled = btnGhi.Enabled = btnUndo.Enabled = false;
                gbInfoDDH.Enabled = gbInfoPX.Enabled = false;
            }
            else if (Program.mGroup == "CHINHANH" || Program.mGroup == "USER")
            {
                cmbChiNhanh.Enabled = false;
                gbInfoDDH.Enabled = gbInfoPX.Enabled = btnGhi.Enabled = false;
            }

            switchPanel("Đặt Hàng", gcDDH, gridDDH);

            // Gán DataSource
            if (btnSwitch.Links[0].Caption.Equals("Phiếu Xuất"))
            {
                current_bds = bdsPX;
                current_gc = gridPX;
                current_gb = gbInfoPX;
                type = "MAPX";
            }
            else
            {
                current_bds = bdsDH;
                current_gc = gridDDH;
                current_gb = gbInfoDDH;
                type = "MasoDDH";
            }

            historyDDH = new Stack<string>();
            historyPX = new Stack<string>();
            historyPN = new Stack<string>();
        }

        private void btnDDH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            switchPanel("Đặt Hàng", gcDDH, gridDDH);
            //btnThem.Enabled = btnXoa.Enabled = true;
            if (Program.mGroup == "CONGTY")
            {
                cmbChiNhanh.Enabled = true;  // bật tắt theo phân quyền
                btnThem.Enabled = btnXoa.Enabled = btnGhi.Enabled = btnUndo.Enabled = false;
                gbInfoDDH.Enabled = gbInfoPX.Enabled = false;
            }
            else if (Program.mGroup == "CHINHANH" || Program.mGroup == "USER")
            {
                cmbChiNhanh.Enabled = false;
                gbInfoDDH.Enabled = gbInfoPX.Enabled = btnGhi.Enabled = false;
                btnThem.Enabled = btnXoa.Enabled = btnGhi.Enabled = true;
            }
            // Gán data sources
            current_bds = bdsDH;
            current_gc = gridDDH;
            current_gb = gbInfoDDH;
            type = "MasoDDH";
        }

        private void switchPanel(string type, GroupControl groupControl, GridControl gridControl)
        {
            btnSwitch.Links[0].Caption = type;
            //btnSwitch.Links[0].ImageOptions.Image = image;
            gcDDH.Visible = false;
            gcPX.Visible = false;
            gcPN.Visible = false;
            gridDDH.Visible = false;
            gridPX.Visible = false;
            gridControl.Visible = true;
            groupControl.Visible = true;
        }

        private void btnPN_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            switchPanel("Phiếu Nhập", gcPN, gridDDH);
            btnThem.Enabled = btnXoa.Enabled = btnGhi.Enabled = false;

            current_bds = bdsDH;
            type = "MasoDDH";
        }

        private void btnPX_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            switchPanel("Phiếu Xuất", gcPX, gridPX);
            //btnThem.Enabled = btnXoa.Enabled = true;
            if (Program.mGroup == "CONGTY")
            {
                cmbChiNhanh.Enabled = true;  // bật tắt theo phân quyền
                btnThem.Enabled = btnXoa.Enabled = btnGhi.Enabled = btnUndo.Enabled = false;
                gbInfoDDH.Enabled = gbInfoPX.Enabled = false;
            }
            else if (Program.mGroup == "CHINHANH" || Program.mGroup == "USER")
            {
                cmbChiNhanh.Enabled = false;
                gbInfoDDH.Enabled = gbInfoPX.Enabled = btnGhi.Enabled = false;
                btnThem.Enabled = btnXoa.Enabled = btnGhi.Enabled = true;
            }

            // Gán data sources
            current_bds = bdsPX;
            current_gc = gridPX;
            current_gb = gbInfoPX;
            type = "MAPX";
        }

        private void gridDDH_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }

        private void cmbChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Trường hợp chưa kịp chọn CN, thuộc tính index ở combobox sẽ thay đổi
            // "System.Data.DataRowView" sẽ xuất hiện và tất nhiên hệ thống sẽ không thể
            // nhận diện được tên server "System.Data.DataRowView".
            if (cmbChiNhanh.SelectedValue.ToString() == "System.Data.DataRowView") return;
            if (cmbChiNhanh.SelectedValue.ToString() == null) return;

            // Lấy tên server
            Program.servername = cmbChiNhanh.SelectedValue.ToString();

            // Nếu tên server khác với tên server ngoài đăng nhập, thì ta phải sử dụng HTKN
            if (cmbChiNhanh.SelectedIndex != Program.mChiNhanh)
            {
                Program.mlogin = Program.remotelogin;
                Program.password = Program.remotepassword;
            }
            else
            {
                Program.mlogin = Program.mloginDN;
                Program.password = Program.passwordDN;
            }

            if (Program.KetNoi() == 0)
                MessageBox.Show("Lỗi kết nối về chi nhánh mới", "", MessageBoxButtons.OK);
            else
            {
                this.cTDDHTableAdapter.Connection.ConnectionString = Program.connstr;
                this.cTDDHTableAdapter.Fill(this.DS.CTDDH);
                this.datHangTableAdapter.Connection.ConnectionString = Program.connstr;
                this.datHangTableAdapter.Fill(this.DS.DATHANG);
                this.phieuXuatTableAdapter.Connection.ConnectionString = Program.connstr;
                this.phieuXuatTableAdapter.Fill(this.DS.PHIEUXUAT);
                this.cTPXTableAdapter.Connection.ConnectionString = Program.connstr;
                this.cTPXTableAdapter.Fill(this.DS.CTPX);
                //maCN = ((DataRowView)bdsDH[0])["MACN"].ToString();
            }
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Giữ lại vị trí trước khi CRUD
            position = current_bds.Position;
            themFunc();

            pushHistory(THEM_BTN);
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int maNhanVien = int.Parse(((DataRowView)current_bds[current_bds.Position])["MANV"].ToString());

            //if (check_owner(current_bds, type.Equals("MAPX") ? gvPX : gvDDH)) {
            if (Program.maNV == maNhanVien)
            {
                string maPhieu = "";
                if (btnSwitch.Links[0].Caption.Equals("Phiếu Xuất"))
                {
                    //type = "MAPX";
                    if (bdsCTPX.Count > 0)
                    {
                        MessageBox.Show("Không thể xóa phiếu này vì đã lập chi tiết phiếu xuất", "Lỗi",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    //type = "MasoDDH";
                    if (bdsCTDDH.Count > 0)
                    {
                        MessageBox.Show("Không thể xóa đơn đặt hàng này vì đã lập chi tiết DDH", "Lỗi",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (bdsPN.Count > 0)
                    {
                        MessageBox.Show("Không thể xóa đơn đặt hàng này vì đã lập phiếu nhập", "Lỗi",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                DialogResult dr = MessageBox.Show("Bạn có thực sự muốn xóa phiếu/đơn này không?", "Xác nhận",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        maPhieu = ((DataRowView)current_bds[current_bds.Position])[type].ToString().Trim();
                        string ngay = ((DataRowView)current_bds[current_bds.Position])[1].ToString().Trim();
                        string name = ((DataRowView)current_bds[current_bds.Position])[2].ToString().Trim();
                        string maKho = ((DataRowView)current_bds[current_bds.Position])[4].ToString().Trim();

                        current_bds.RemoveCurrent();
                        if (btnSwitch.Links[0].Caption.Equals("Phiếu Xuất"))
                        {
                            this.phieuXuatTableAdapter.Update(this.DS.PHIEUXUAT);
                            historyPX.Push(XOA_BTN + "#%" + maPhieu + "#%" + ngay + "#%" + name + "#%" + maKho);
                        }
                        else
                        {
                            this.datHangTableAdapter.Update(this.DS.DATHANG);
                            historyDDH.Push(XOA_BTN + "#%" + maPhieu + "#%" + ngay + "#%" + name + "#%" + maKho);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi xảy ra trong quá trình xóa. Vui lòng thử lại!\n" + ex.Message, "Thông báo lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.phieuXuatTableAdapter.Fill(this.DS.PHIEUXUAT);
                        this.datHangTableAdapter.Fill(this.DS.DATHANG);
                        current_bds.Position = current_bds.Find(type, maPhieu);
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn không có quyền xóa phiếu/đơn này!", "Lỗi",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (current_bds.Count == 0) btnXoa.Enabled = false;
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // TODO: thêm ddh, phiếu xuất dùng chung hàm
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                TextBox tb_maPhieu = null;
                if (btnSwitch.Links[0].Caption.Equals("Phiếu Xuất"))
                {
                    current_bds = bdsPX;
                    tb_maPhieu = txtMaPX;
                    type = "MAPX";
                    current_gc = gridPX;
                    current_gb = gbInfoPX;
                }
                else
                {
                    current_bds = bdsDH;
                    tb_maPhieu = txtMaDDH;
                    type = "MasoDDH";
                    current_gc = gridDDH;
                    current_gb = gbInfoDDH;
                }
                if (Program.KetNoi() == 0) return;

                String query = "DECLARE	@return_value int " +
                               "EXEC @return_value = [dbo].[SP_CHECKID] " +
                               "@p1, @p2 " +
                               "SELECT 'Return Value' = @return_value";
                SqlCommand sqlCommand = new SqlCommand(query, Program.conn);
                sqlCommand.Parameters.AddWithValue("@p1", tb_maPhieu.Text);
                sqlCommand.Parameters.AddWithValue("@p2", type);
                SqlDataReader dataReader = null;

                try
                {
                    dataReader = sqlCommand.ExecuteReader();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thực thi database thất bại!\n" + ex.Message, "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // Đọc và lấy result
                dataReader.Read();
                int result_value = int.Parse(dataReader.GetValue(0).ToString());
                dataReader.Close();

                // Check ràng buộc mã các phiếu
                int indexMaPhieu = current_bds.Find(type, tb_maPhieu.Text);
                int indexCurrent = current_bds.Position;
                if (result_value == 1 && (indexMaPhieu != indexCurrent))
                {
                    MessageBox.Show("Mã phiếu đã tồn tại ở chi chánh hiện tại!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (result_value == 2)
                {
                    MessageBox.Show("Mã phiếu đã tồn tại ở chi chánh khác!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    DialogResult dr = MessageBox.Show("Bạn có chắc muốn ghi dữ liệu vào Database?", "Thông báo",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (dr == DialogResult.OK)
                    {
                        try
                        {
                            
                            current_gb.Enabled = false;
                            btnThem.Enabled = btnXoa.Enabled = current_gc.Enabled = true;
                            btnReload.Enabled = btnGhi.Enabled = btnSwitch.Enabled = true;
                            
                            current_bds.EndEdit();

                            if (btnSwitch.Links[0].Caption.Equals("Phiếu Xuất"))
                            {
                                this.phieuXuatTableAdapter.Update(this.DS.PHIEUXUAT);
                                historyPX.Push(GHI_BTN + "#%" + tb_maPhieu.Text);
                            }
                            else
                            {
                                this.datHangTableAdapter.Update(this.DS.DATHANG);
                                historyDDH.Push(GHI_BTN + "#%" + tb_maPhieu.Text);
                            }
                            current_bds.Position = position;
                            //timer giong settimeout
                            //Program.frmMain.timer1.Enabled = true;
                        }
                        catch (Exception ex)
                        {
                            // Khi Update database lỗi thì xóa record vừa thêm trong bds
                            current_bds.RemoveCurrent();
                            MessageBox.Show("Thất bại. Vui lòng kiểm tra lại!\n" + ex.Message, "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void btnGridKho_Click(object sender, EventArgs e)
        {
            Program.subFrmKho = new subFrmKho();
            Program.subFrmKho.Show();
            //Program.frmMain.Enabled = false;
        }

        private void gridCTDDH_MouseHover(object sender, EventArgs e)
        {
            gridCTDDH.ContextMenuStrip = check_owner(bdsDH, gvDDH) ? cmsCTDDH : cmsChecked;
        }

        private bool check_owner(BindingSource current_bds, GridView current_gv)
        {
            int maNV = 0;
            if (current_gv.GetRowCellValue(current_bds.Position, "MANV") != null)
            {
                maNV = int.Parse(current_gv.GetRowCellValue(current_bds.Position, "MANV").ToString().Trim());
            }
            return (maNV == Program.maNV);
        }
    }
}

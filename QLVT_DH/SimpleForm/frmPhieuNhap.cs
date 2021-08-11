using QLVT_DH.SubForm;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLVT_DH.SimpleForm
{
    public partial class frmPhieuNhap : Form
    {
        int position = 0;
        string maCN = "";
        public Stack undolist = new Stack();
        public frmPhieuNhap()
        {
            InitializeComponent();
        }

        private void pHIEUNHAPBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsPN.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);

        }

        private void frmPhieuNhap_Load(object sender, EventArgs e)
        {
            DS.EnforceConstraints = false;

            // TODO: This line of code loads data into the 'dS.PHIEUNHAP' table. You can move, or remove it, as needed.
            this.phieuNhapableAdapter.Connection.ConnectionString = Program.connstr;
            this.phieuNhapableAdapter.Fill(this.DS.PHIEUNHAP);

            // TODO: This line of code loads data into the 'DS.CTPN' table. You can move, or remove it, as needed.
            this.cTPNTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTPNTableAdapter.Fill(this.DS.CTPN);

            // TODO: This line of code loads data into the 'DS.DATHANG' table. You can move, or remove it, as needed.
            this.dATHANGTableAdapter.Connection.ConnectionString = Program.connstr;
            this.dATHANGTableAdapter.Fill(this.DS.DATHANG);

            // TODO: This line of code loads data into the 'DS.CTDDH' table. You can move, or remove it, as needed.
            this.cTDDHTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTDDHTableAdapter.Fill(this.DS.CTDDH);

            bdsDH.Position = bdsDH.Find("MasoDDH", ((DataRowView)bdsPN[bdsPN.Position])["MasoDDH"]);

            if (Program.bds_dspm.Count == 3) Program.bds_dspm.RemoveAt(2);

            cmbChiNhanh.DataSource = Program.bds_dspm;  // sao chép bds_dspm đã load ở form đăng nhập  qua
            cmbChiNhanh.DisplayMember = "TENCN";
            cmbChiNhanh.ValueMember = "TENSERVER";
            cmbChiNhanh.SelectedIndex = Program.mChiNhanh;

            if (Program.mGroup == "CONGTY")
            {
                cmbChiNhanh.Enabled = true;  // bật tắt theo phân quyền
                btnThem.Enabled = btnXoa.Enabled = btnGhi.Enabled = btnUndo.Enabled = btnSua.Enabled = false;
                ctmsThemCPN.Enabled = ctmsSuaCTPN.Enabled = ctmsXoaCTPN.Enabled = false;
                gbInfoPN.Enabled = false;
            }
            else if (Program.mGroup == "CHINHANH" || Program.mGroup == "USER")
            {
                cmbChiNhanh.Enabled = false;
                gbInfoPN.Enabled = btnGhi.Enabled = false;
            }

            //Mặc định vừa vào groupbox không dx hiện để tránh lỗi sửa các dòng cũ chưa lưu đi qua dòng khác
            btnUndo.Enabled /*= btnBreak.Enabled*/ = false;
            btnBreak.Enabled = false;

            // cmb và label này chỉ dùng khi thêm nên ẩn đi
            cmbMaDDH.Visible = lbMaDDH.Visible = false;   

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
                this.phieuNhapableAdapter.Connection.ConnectionString = Program.connstr;
                this.phieuNhapableAdapter.Fill(this.DS.PHIEUNHAP);

                // TODO: This line of code loads data into the 'DS.CTPN' table. You can move, or remove it, as needed.
                this.cTPNTableAdapter.Connection.ConnectionString = Program.connstr;
                this.cTPNTableAdapter.Fill(this.DS.CTPN);
                //maCN = ((DataRowView)bdsDH[0])["MACN"].ToString();
            }
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnUndo.Enabled = btnReload.Enabled = false;
            ctmsThemCPN.Enabled = ctmsSuaCTPN.Enabled = ctmsXoaCTPN.Enabled = false;
            txtMaPN.Enabled = btnBreak.Enabled = true;

            gbInfoPN.Enabled = btnGhi.Enabled = true;
            bdsPN.AddNew();
            ((DataRowView)bdsPN[bdsPN.Position])["NGAY"] = DateTime.Today;
            ((DataRowView)bdsPN[bdsPN.Position])["MANV"] = Program.maNV;
            undolist.Push("INSERT");

            // cmb và label này chỉ dùng khi thêm
            cmbMaDDH.Visible = lbMaDDH.Visible = true;
            // Giả click
            cmbMaDDH.SelectedIndex = 1;
            cmbMaDDH.SelectedIndex = 0;
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                string statement = null;
                if (undolist.Count != 0) statement = undolist.Pop().ToString();

                if (statement == "EDIT")
                {
                    undolist.Push("EDIT");
                    this.bdsPN.EndEdit();
                    this.phieuNhapableAdapter.Update(this.DS.PHIEUNHAP);
                    bdsPN.Position = position;

                    btnSua.Enabled = btnThem.Enabled = btnXoa.Enabled = btnReload.Enabled = btnUndo.Enabled = true;
                    ctmsThemCPN.Enabled = ctmsSuaCTPN.Enabled = ctmsXoaCTPN.Enabled = true;
                    gbInfoPN.Enabled = btnGhi.Enabled = btnBreak.Enabled = false;
                    gridPN.Enabled = true;
                    return;
                }
                else
                {
                    undolist.Push("INSERT");
                }


                int checkexits = bdsPN.Find("MasoDDH", cmbMaDDH.Text);
                //vì trong 1 phiếu nhập chỉ dùng 1 đơn đặt hàng : đề bài MasoDDH unique
                // check bằng với bdsPN.Count vì khi thêm 1 row mới thì trong row đó sẽ có mã ddh này 
                //còn nếu checkexits < bds.count thì đã tồn tại
                if (checkexits < bdsPN.Count-1 && checkexits > -1)
                {
                    MessageBox.Show("Mã số đơn đặt hàng đã tạo ở 1 phiếu nhập khác rồi!\n", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (Program.KetNoi() == 0) return;
                String query = "DECLARE	@return_value int " +
                               "EXEC @return_value = [dbo].[SP_CHECKTRUNG] " +
                               "@p1, @p2 " +
                               "SELECT 'Return Value' = @return_value";
                SqlCommand sqlCommand = new SqlCommand(query, Program.conn);
                sqlCommand.Parameters.AddWithValue("@p1", txtMaPN.Text);
                sqlCommand.Parameters.AddWithValue("@p2", "MaPN");
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
                int indexMaPhieu = bdsPN.Find("MaPN", txtMaPN.Text);
                int indexCurrent = bdsPN.Position;
                if (result_value == 1 && (indexMaPhieu != indexCurrent))
                {
                    MessageBox.Show("Mã phiếu đã tồn tại ở chi chánh hiện tại!", "Thông báo",
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
                            btnThem.Enabled = btnXoa.Enabled = gridPN.Enabled = gbInfoPN.Enabled = btnSua.Enabled = true;
                            btnReload.Enabled = btnThoat.Enabled = true;
                                ctmsThemCPN.Enabled = ctmsSuaCTPN.Enabled = ctmsXoaCTPN.Enabled = true;
                            btnUndo.Enabled = true;
                            btnBreak.Enabled = false;
                            gbInfoPN.Enabled = false;
                            //lấy ra mã đơn đặt hàng từ combo box đã chọn do cmb này lấy datasource từ table DATHANG
                            ((DataRowView)bdsPN[bdsPN.Position])[2] = cmbMaDDH.Text.ToString();
                           
                            

                            bdsPN.EndEdit();
                            this.phieuNhapableAdapter.Update(this.DS.PHIEUNHAP);
                            undolist.Pop();
                            undolist.Push(txtMaPN.Text);
                            undolist.Push("INSERT");
                            bdsPN.Position = position;

                            /*btnSua.Enabled =*/


                            btnGhi.Enabled = false;
                            cmbMaDDH.Visible = lbMaDDH.Visible = false;
                        }
                        catch (Exception ex)
                        {
                            // Khi Update database lỗi thì xóa record vừa thêm trong bds
                            bdsPN.RemoveCurrent();
                            MessageBox.Show("Thất bại. Vui lòng kiểm tra lại!\n" + ex.Message, "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void masoDDHComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnGridKho_Click(object sender, EventArgs e)
        {
            Program.subFrmKho = new subFrmKho();
            Program.subFrmKho.Show();
        }

        private void btnTest_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            position = bdsPN.Position;
            txtMaPN.Enabled = false;
            ctmsThemCPN.Enabled = ctmsSuaCTPN.Enabled = ctmsXoaCTPN.Enabled = false;
            btnSua.Enabled = btnThem.Enabled = btnXoa.Enabled = btnReload.Enabled = false;
            gbInfoPN.Enabled = btnGhi.Enabled = btnBreak.Enabled = true;
            gridPN.Enabled = false;

            String maPhieu = ((DataRowView)bdsPN[bdsPN.Position])["MaPN"].ToString().Trim();
            string ngay = ((DataRowView)bdsPN[bdsPN.Position])[1].ToString().Trim();
            string MaDDH = ((DataRowView)bdsPN[bdsPN.Position])[2].ToString().Trim();
            string maKho = ((DataRowView)bdsPN[bdsPN.Position])[3].ToString().Trim();

            undolist.Push(maPhieu + "#" + ngay + "#" + MaDDH + "#"  + maKho);
            undolist.Push("EDIT");
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int maNhanVien = int.Parse(((DataRowView)bdsPN[bdsPN.Position])["MANV"].ToString());

            if (Program.maNV == maNhanVien)
            {
                string maPhieu = "";
                if (bdsCTPN.Count > 0)
                {
                    MessageBox.Show("Không thể xóa phiếu này vì đã lập chi tiết phiếu nhập", "Lỗi",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult dr = MessageBox.Show("Bạn có thực sự muốn xóa phiếu/đơn này không?", "Xác nhận",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    try
                    {

                        maPhieu = ((DataRowView)bdsPN[bdsPN.Position])["MaPN"].ToString().Trim();
                        string ngay = ((DataRowView)bdsPN[bdsPN.Position])[1].ToString().Trim();
                        string MaDDH = ((DataRowView)bdsPN[bdsPN.Position])[2].ToString().Trim();
                        string maKho = ((DataRowView)bdsPN[bdsPN.Position])[3].ToString().Trim();

                        bdsPN.RemoveCurrent();
                        this.phieuNhapableAdapter.Update(this.DS.PHIEUNHAP);
                        undolist.Push(maPhieu + "#" + ngay + "#" + MaDDH + "#" + maKho);
                        undolist.Push("DELETE");

                        btnUndo.Enabled = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi xảy ra trong quá trình xóa. Vui lòng thử lại!\n" + ex.Message, "Thông báo lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.phieuNhapableAdapter.Fill(this.DS.PHIEUNHAP);
                        bdsPN.Position = bdsPN.Find("MaPN", maPhieu);
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

            if (bdsPN.Count == 0) btnXoa.Enabled = false;
        }

        private void btnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (undolist.Count > 0)
            {
                String statement = undolist.Pop().ToString();
                if (statement.Equals("DELETE"))
                {
                    this.bdsPN.AddNew();
                    String TT = undolist.Pop().ToString();
                    String[] TT_PX = TT.Split('#');

                    ((DataRowView)bdsPN[bdsPN.Position])[0] = TT_PX[0];
                    ((DataRowView)bdsPN[bdsPN.Position])[1] = TT_PX[1];
                    ((DataRowView)bdsPN[bdsPN.Position])[2] = TT_PX[2];
                    ((DataRowView)bdsPN[bdsPN.Position])[3] = TT_PX[3];
                    ((DataRowView)bdsPN[bdsPN.Position])[4] = Program.maNV;
                    this.bdsPN.EndEdit();
                    this.phieuNhapableAdapter.Update(this.DS.PHIEUNHAP);
                }
                else if (statement.Equals("INSERT"))
                {
                    String MaPN = undolist.Pop().ToString();
                    int vitrixoa = bdsPN.Find("MaPN", MaPN);
                    bdsPN.Position = vitrixoa;
                    bdsPN.RemoveCurrent();
                    this.phieuNhapableAdapter.Update(this.DS.PHIEUNHAP);
                }
                else if (statement.Equals("EDIT"))
                {
                    String TT = undolist.Pop().ToString();
                    String[] TT_PX = TT.Split('#');
                    bdsPN.Position = bdsPN.Find("MaPN", TT_PX[0]);

                    ((DataRowView)bdsPN[bdsPN.Position])[0] = TT_PX[0];
                    ((DataRowView)bdsPN[bdsPN.Position])[1] = TT_PX[1];
                    ((DataRowView)bdsPN[bdsPN.Position])[2] = TT_PX[2];
                    ((DataRowView)bdsPN[bdsPN.Position])[3] = TT_PX[3];
                    ((DataRowView)bdsPN[bdsPN.Position])[4] = Program.maNV;

                    this.bdsPN.EndEdit();
                    this.phieuNhapableAdapter.Update(this.DS.PHIEUNHAP);
                }
            }
            if (undolist.Count == 0) btnUndo.Enabled = false;
        }

        private void btnThemCTPN_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsDH.Position = bdsDH.Find("MasoDDH", cmbMaDDH.Text.Trim());
            if(bdsCTDDH.Count == 0)
            {
                MessageBox.Show("Đơn đặt hàng này không có sản phẩm nên không thể thêm chi tiết phiếu nhập", "Lỗi",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Program.subFrmCTPN = new subFrmCTPN();
            Program.subFrmCTPN.Show();
            undolist.Push("THEMCTPN");
        }

        private void btnSuaCTPN_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(bdsCTPN.Count == 0)
            {
                MessageBox.Show("Phiếu nhập này không có chi tiết phiếu nhập để sửa", "Lỗi",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Program.subFrmCTPN = new subFrmCTPN();
            Program.subFrmCTPN.Show();
            undolist.Push("SUACTPN");
        }

        private void btnXoaCTPN_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có thực sự muốn xóa chi tiết phiếu nhập này không", "Xác nhận",
                   MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                bdsCTPN.RemoveCurrent();
                this.cTPNTableAdapter.Update(this.DS.CTPN);
            }
        }
        public BindingSource getBdsPN()
        {
            return this.bdsPN;
        }

        public BindingSource getBdsCTPN()
        {
            return this.bdsCTPN;
        }

        public BindingSource getBdsDH()
        {
            return this.bdsDH;
        }

        public BindingSource getbdsCTDDH()
        {
            return this.bdsCTDDH;
        }
        public DS getDataset()
        {
            return this.DS;
        }


        private void gvPN_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            bdsDH.Position = bdsDH.Find("MasoDDH", cmbMaDDH.Text.Trim());
        }

        private void btnBreak_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string statement = undolist.Pop().ToString();
            if (statement == "EDIT")
                undolist.Pop();

            bdsPN.CancelEdit();//hủy cho cả thêm và sửa

            bdsPN.Position = position;
            btnSua.Enabled = btnThem.Enabled = btnXoa.Enabled = btnReload.Enabled = true;
            ctmsThemCPN.Enabled = ctmsSuaCTPN.Enabled = ctmsXoaCTPN.Enabled = true;
            gbInfoPN.Enabled = btnBreak.Enabled = false;
            gridPN.Enabled = true;
            //sau khi break ra thì phải trả validate về none để k hiển thi nữa
            ValidateChildren(ValidationConstraints.None);
        }

        private void ctmsThemCPN_Click(object sender, EventArgs e)
        {
            bdsDH.Position = bdsDH.Find("MasoDDH", cmbMaDDH.Text.Trim());
            if (bdsCTDDH.Count == 0)
            {
                MessageBox.Show("Đơn đặt hàng này không có sản phẩm nên không thể thêm chi tiết phiếu nhập", "Lỗi",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Program.subFrmCTPN = new subFrmCTPN();
            Program.subFrmCTPN.Show();
            undolist.Push("THEMCTPN");
        }

        private void ctmsSuaCTPN_Click(object sender, EventArgs e)
        {
            if (bdsCTPN.Count == 0)
            {
                MessageBox.Show("Phiếu nhập này không có chi tiết phiếu nhập để sửa", "Lỗi",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Program.subFrmCTPN = new subFrmCTPN();
            Program.subFrmCTPN.Show();
            undolist.Push("SUACTPN");
        }

        private void ctmsXoaCTPN_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có thực sự muốn xóa chi tiết phiếu nhập này không", "Xác nhận",
                   MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                bdsCTPN.RemoveCurrent();
                this.cTPNTableAdapter.Update(this.DS.CTPN);
            }
        }

        private void txtMaPN_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaPN.Text))
            {
                e.Cancel = true;
                txtMaPN.Focus();
                errorProvider1.SetError(txtMaPN, "Mã PN không được để trống!");
            }
            else if (txtMaPN.Text.Trim().Contains(" "))
            {
                e.Cancel = true;
                txtMaPN.Focus();
                errorProvider1.SetError(txtMaPN, "Mã PN không được chứa khoảng trắng!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtMaPN, "");
            }
        }

        private void txtMaKho_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaKho.Text))
            {
                e.Cancel = true;
                txtMaKho.Focus();
                errorProvider1.SetError(txtMaKho, "Mã kho không được để trống!");
            }
            else if (txtMaKho.Text.Trim().Contains("#"))
            {
                e.Cancel = true;
                txtMaKho.Focus();
                errorProvider1.SetError(txtMaKho, "Mã kho không được chứa ký tự đặc biệt!");
            }
            else if (txtMaKho.Text.Length > 4)
            {
                e.Cancel = true;
                txtMaKho.Focus();
                errorProvider1.SetError(txtMaKho, "Mã kho không được quá 4 kí tự");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtMaKho, "");
            }
        }
    }
}

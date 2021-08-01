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
    public partial class frmDonDatHang : Form
    {
        int position = 0;
        string maCN = "";
        Stack undolist = new Stack();

        public frmDonDatHang()
        {
            InitializeComponent();
        }

        private void dATHANGBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsDH.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);

        }

        private void frmDonDatHang_Load(object sender, EventArgs e)
        {
            DS.EnforceConstraints = false;

            // TODO: This line of code loads data into the 'dS.DATHANG' table. You can move, or remove it, as needed.
            this.datHangTableAdapter.Connection.ConnectionString = Program.connstr;
            this.datHangTableAdapter.Fill(this.DS.DATHANG);

            // TODO: This line of code loads data into the 'DS.PHIEUNHAP' table. You can move, or remove it, as needed.
            this.pHIEUNHAPTableAdapter.Connection.ConnectionString = Program.connstr;
            this.pHIEUNHAPTableAdapter.Fill(this.DS.PHIEUNHAP);
            // TODO: This line of code loads data into the 'DS.CTDDH' table. You can move, or remove it, as needed.
            this.cTDDHTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTDDHTableAdapter.Fill(this.DS.CTDDH);

            if (Program.bds_dspm.Count == 3) Program.bds_dspm.RemoveAt(2);

            cmbChiNhanh.DataSource = Program.bds_dspm;  // sao chép bds_dspm đã load ở form đăng nhập  qua
            cmbChiNhanh.DisplayMember = "TENCN";
            cmbChiNhanh.ValueMember = "TENSERVER";
            cmbChiNhanh.SelectedIndex = Program.mChiNhanh;


            if (Program.mGroup == "CONGTY")
            {
                cmbChiNhanh.Enabled = true;  // bật tắt theo phân quyền
                btnThem.Enabled = btnXoa.Enabled = btnUndo.Enabled = false;
                gbInfoDDH.Enabled  = false;
            }
            else if (Program.mGroup == "CHINHANH" || Program.mGroup == "USER")
            {
                cmbChiNhanh.Enabled = false;
                gbInfoDDH.Enabled = false;
            }

            //Mặc định vừa vào groupbox không dx hiện để tránh lỗi sửa các dòng cũ chưa lưu đi qua dòng khác
            btnUndo.Enabled = btnBreak.Enabled = btnGhi.Enabled = false;
            gbInfoDDH.Enabled = false;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnUndo.Enabled = btnReload.Enabled = btnThemCTDDH.Enabled = btnGhiCTDDH.Enabled = btnXoaCTDDH.Enabled = false;
            txtMaDDH.Enabled = btnBreak.Enabled = true;
            
            gbInfoDDH.Enabled= btnGhi.Enabled = true;
            bdsDH.AddNew();
            ((DataRowView)bdsDH[bdsDH.Position])["NGAY"] = DateTime.Today;
            ((DataRowView)bdsDH[bdsDH.Position])["MANV"] = Program.maNV;
            undolist.Push("INSERT");
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string statement = null;
            if (undolist.Count != 0) statement = undolist.Pop().ToString();

            if (statement == "EDIT")
            {
                undolist.Push("EDIT");
                this.bdsDH.EndEdit();
                this.datHangTableAdapter.Update(this.DS.DATHANG);
                bdsDH.Position = position;

                btnSua.Enabled = btnThem.Enabled = btnXoa.Enabled = btnReload.Enabled = btnUndo.Enabled = btnThemCTDDH.Enabled = btnGhiCTDDH.Enabled = btnXoaCTDDH.Enabled = true;
                gbInfoDDH.Enabled = btnGhi.Enabled = false;
                gridDDH.Enabled = true;
                return;
            }
            else
            {
                undolist.Push("INSERT");
            }


            if (ValidateChildren(ValidationConstraints.Enabled))
            {

                if (Program.KetNoi() == 0) return;
                String query = "DECLARE	@return_value int " +
                               "EXEC @return_value = [dbo].[SP_CHECKID] " +
                               "@p1, @p2 " +
                               "SELECT 'Return Value' = @return_value";
                SqlCommand sqlCommand = new SqlCommand(query, Program.conn);
                sqlCommand.Parameters.AddWithValue("@p1", txtMaDDH.Text);
                sqlCommand.Parameters.AddWithValue("@p2", "MasoDDH");
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
                int indexMaPhieu = bdsDH.Find("MasoDDH", txtMaDDH.Text);
                int indexCurrent = bdsDH.Position;
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
                            btnThem.Enabled = btnXoa.Enabled = gridDDH.Enabled = gbInfoDDH.Enabled = true;
                            btnReload.Enabled = btnGhi.Enabled = true;
                            btnUndo.Enabled = true;


                            bdsDH.EndEdit();
                            this.datHangTableAdapter.Update(this.DS.DATHANG);
                            undolist.Pop();
                            undolist.Push(txtMaDDH.Text);
                            undolist.Push("INSERT");
                            bdsDH.Position = position;

                            btnThemCTDDH.Enabled = btnGhiCTDDH.Enabled = btnXoaCTDDH.Enabled = true;
                            /*btnSua.Enabled =*/ btnThoat.Enabled = true;
                            btnGhi.Enabled = false; 
                        }
                        catch (Exception ex)
                        {
                            // Khi Update database lỗi thì xóa record vừa thêm trong bds
                            bdsDH.RemoveCurrent();
                            MessageBox.Show("Thất bại. Vui lòng kiểm tra lại!\n" + ex.Message, "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void btnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (undolist.Count > 0)
            {
                String statement = undolist.Pop().ToString();
                if (statement.Equals("DELETE"))
                {
                    this.bdsDH.AddNew();
                    String TT = undolist.Pop().ToString();
                    String[] TT_DDH = TT.Split('#');

                    ((DataRowView)bdsDH[bdsDH.Position])[0] = TT_DDH[0];
                    ((DataRowView)bdsDH[bdsDH.Position])[1] = TT_DDH[1];
                    ((DataRowView)bdsDH[bdsDH.Position])[2] = TT_DDH[2];
                    ((DataRowView)bdsDH[bdsDH.Position])[3] = TT_DDH[3];
                    ((DataRowView)bdsDH[bdsDH.Position])[4] = Program.maNV;
                    this.bdsDH.EndEdit();
                    this.datHangTableAdapter.Update(this.DS.DATHANG);
                }
                else if (statement.Equals("INSERT"))
                {
                    String MasoDDH = undolist.Pop().ToString();
                    int vitrixoa = bdsDH.Find("MasoDDH", MasoDDH);
                    bdsDH.Position = vitrixoa;
                    bdsDH.RemoveCurrent();
                    this.datHangTableAdapter.Update(this.DS.DATHANG);
                }
                else if (statement.Equals("EDIT"))
                {
                    String TT = undolist.Pop().ToString();
                    String[] TT_DDH = TT.Split('#');
                    bdsDH.Position = bdsDH.Find("MasoDDH", TT_DDH[0]);

                    ((DataRowView)bdsDH[bdsDH.Position])[0] = TT_DDH[0];
                    ((DataRowView)bdsDH[bdsDH.Position])[1] = TT_DDH[1];
                    ((DataRowView)bdsDH[bdsDH.Position])[2] = TT_DDH[2];
                    ((DataRowView)bdsDH[bdsDH.Position])[3] = TT_DDH[3];
                    ((DataRowView)bdsDH[bdsDH.Position])[4] = Program.maNV;

                    this.bdsDH.EndEdit();
                    this.datHangTableAdapter.Update(this.DS.DATHANG);
                }
            }
            if (undolist.Count == 0) btnUndo.Enabled = false;
        }

        private void btnGridKho_Click(object sender, EventArgs e)
        {
            Program.subFrmKho = new subFrmKho();
            Program.subFrmKho.Show();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int maNhanVien = int.Parse(((DataRowView)bdsDH[bdsDH.Position])["MANV"].ToString());

            if (Program.maNV == maNhanVien)
            {
                string maPhieu = "";

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

                DialogResult dr = MessageBox.Show("Bạn có thực sự muốn xóa phiếu/đơn này không?", "Xác nhận",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        maPhieu = ((DataRowView)bdsDH[bdsDH.Position])["MasoDDH"].ToString().Trim();
                        string ngay = ((DataRowView)bdsDH[bdsDH.Position])[1].ToString().Trim();
                        string name = ((DataRowView)bdsDH[bdsDH.Position])[2].ToString().Trim();
                        string maKho = ((DataRowView)bdsDH[bdsDH.Position])[3].ToString().Trim();

                        bdsDH.RemoveCurrent();
                        this.datHangTableAdapter.Update(this.DS.DATHANG);
                        undolist.Push(maPhieu + "#" + ngay + "#" + name + "#" + maKho);
                        undolist.Push("DELETE");
                        btnUndo.Enabled = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi xảy ra trong quá trình xóa. Vui lòng thử lại!\n" + ex.Message, "Thông báo lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.datHangTableAdapter.Fill(this.DS.DATHANG);
                        bdsDH.Position = bdsDH.Find("MasoDDH", maPhieu);
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

            if (bdsDH.Count == 0) btnXoa.Enabled = false;
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.datHangTableAdapter.Fill(this.DS.DATHANG);
                this.cTDDHTableAdapter.Fill(this.DS.CTDDH);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Reload :" + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            position = bdsDH.Position;
            txtMaDDH.Enabled = false;
            btnThemCTDDH.Enabled = btnGhiCTDDH.Enabled = btnXoaCTDDH.Enabled = false;
            btnSua.Enabled = btnThem.Enabled = btnXoa.Enabled = btnReload.Enabled = false;
            gbInfoDDH.Enabled = btnGhi.Enabled = true;
            gridDDH.Enabled = false;
            btnBreak.Enabled = true;

            string maPhieu = ((DataRowView)bdsDH[bdsDH.Position])["MasoDDH"].ToString().Trim();
            string ngay = ((DataRowView)bdsDH[bdsDH.Position])[1].ToString().Trim();
            string name = ((DataRowView)bdsDH[bdsDH.Position])[2].ToString().Trim();
            string maKho = ((DataRowView)bdsDH[bdsDH.Position])[3].ToString().Trim();

            undolist.Push(maPhieu + "#" + ngay + "#" + name + "#" + maKho);
            undolist.Push("EDIT");
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
                //maCN = ((DataRowView)bdsDH[0])["MACN"].ToString();
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnThemCTDDH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Program.subFrmCTDDH = new subFrmCTDDH();
            Program.subFrmCTDDH.Show();
            //bdsCTDDH.AddNew();
            //btnGhiCTDDH.Enabled = true;
        }

        public BindingSource getBdsCTDDH()
        {
            return this.bdsCTDDH;
        }
        public DS getDataset()
        {
            return this.DS;
        }
        public BindingSource getBdsDDH()
        {
            return this.bdsDH;
        }

        private void btnGhiCTDDH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có thực sự muốn ghi dữ liệu này vào database?", "Xác nhận",
                   MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                this.bdsCTDDH.EndEdit();
                this.cTDDHTableAdapter.Update(this.DS.CTDDH);
                bdsCTDDH.Position = position;
            }
        }

        private void btnXoaCTDDH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có thực sự muốn xóa chi tiết đơn đặt hàng này không?", "Xác nhận",
                   MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                bdsCTDDH.RemoveCurrent();
                this.cTDDHTableAdapter.Update(this.DS.CTDDH);
            }
        }

        private void btnBreak_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string statement = undolist.Pop().ToString();
            if (statement == "EDIT")
            {
                undolist.Pop();
                bdsDH.CancelEdit();
            }
            else
            {
                bdsDH.RemoveCurrent();
            }

            bdsDH.Position = position;
            btnSua.Enabled = btnThem.Enabled = btnXoa.Enabled = btnReload.Enabled = true;
            btnThemCTDDH.Enabled = btnGhiCTDDH.Enabled = btnXoaCTDDH.Enabled = true;
            gbInfoDDH.Enabled = btnBreak.Enabled = false;
            gridDDH.Enabled = true;
        }

        private void txtMaDDH_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaDDH.Text))
            {
                e.Cancel = true;
                txtMaDDH.Focus();
                errorProvider1.SetError(txtMaDDH, "Mã DH không được để trống!");
            }
            else if (txtMaDDH.Text.Trim().Contains(" "))
            {
                e.Cancel = true;
                txtMaDDH.Focus();
                errorProvider1.SetError(txtMaDDH, "Mã DH không được chứa khoảng trắng!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtMaDDH, "");
            }
        }

        private void txtMaNCC_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNCC.Text))
            {
                e.Cancel = true;
                txtMaNCC.Focus();
                errorProvider1.SetError(txtMaNCC, "Nhà cung cấp không được để trống!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtMaNCC, "");
            }
        }
    }
}

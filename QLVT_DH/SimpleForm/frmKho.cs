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
    public partial class frmKho : Form
    {
        int position = 0;
        string maCN = "";
        Stack undolist = new Stack();

        public frmKho()
        {
            InitializeComponent();
        }

        private void khoBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsKho.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);

        }

        private void frmKho_Load(object sender, EventArgs e)
        {
            DS.EnforceConstraints = false;

            // TODO: This line of code loads data into the 'dS.Kho' table. You can move, or remove it, as needed.
            this.khoTableAdapter.Connection.ConnectionString = Program.connstr;
            this.khoTableAdapter.Fill(this.DS.Kho);


            // TODO: This line of code loads data into the 'DS.DATHANG' table. You can move, or remove it, as needed.
            this.datHangTableAdapter.Connection.ConnectionString = Program.connstr;
            this.datHangTableAdapter.Fill(this.DS.DATHANG);
            // TODO: This line of code loads data into the 'DS.PHIEUNHAP' table. You can move, or remove it, as needed.
            this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
            this.phieuNhapTableAdapter.Fill(this.DS.PHIEUNHAP);
            // TODO: This line of code loads data into the 'DS.PHIEUXUAT' table. You can move, or remove it, as needed.
            this.phieuXuatTableAdapter.Connection.ConnectionString = Program.connstr;
            this.phieuXuatTableAdapter.Fill(this.DS.PHIEUXUAT);

            if (Program.bds_dspm.Count == 3) Program.bds_dspm.RemoveAt(2);

            if (Program.mGroup == "CONGTY")
            {
                btnThem.Enabled = btnXoa.Enabled = btnGhi.Enabled = btnUndo.Enabled = btnSua.Enabled = false;
                txtTenKho.Enabled = txtMaKho.Enabled = txtDiaChi.Enabled = false;
            }
            else if (Program.mGroup == "CHINHANH" || Program.mGroup == "USER")
            {
                cmbChiNhanh.Enabled = txtMaKho.Enabled = false;
            }

            maCN = (((DataRowView)bdsKho[0])["MACN"].ToString()); // lúc đúng lúc sai

            this.cmbChiNhanh.DataSource = Program.bds_dspm; // DataSource của comboBox_ChiNhanh tham chiếu đến bindingSource ở LoginForm
            cmbChiNhanh.DisplayMember = "TENCN";
            cmbChiNhanh.ValueMember = "TENSERVER";
            cmbChiNhanh.SelectedIndex = Program.mChiNhanh;

            //Mặc định vừa vào groupbox không dx hiện để tránh lỗi sửa các dòng cũ chưa lưu đi qua dòng khác
            btnUndo.Enabled = btnBreak.Enabled = false;
            gcInfoKho.Enabled = false;
            txtMaKho.Enabled = false;

        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            position = bdsKho.Position;
            gcInfoKho.Enabled = txtMaKho.Enabled = true;
            bdsKho.AddNew();
            txtMaCN.Text = maCN;

            btnThem.Enabled = btnXoa.Enabled = btnReload.Enabled = btnThoat.Enabled = gridKho.Enabled = btnSua.Enabled = btnUndo.Enabled  = false;
            btnGhi.Enabled = btnBreak.Enabled = true;

            undolist.Push("INSERT");
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            position = bdsKho.Position;
            btnSua.Enabled = btnThem.Enabled = btnXoa.Enabled  = btnReload.Enabled = false;
            gcInfoKho.Enabled = btnGhi.Enabled = btnBreak.Enabled = true;
            gridKho.Enabled = false;

            undolist.Push(txtMaKho.Text + "#" + txtTenKho.Text + "#" + txtDiaChi.Text);
            undolist.Push("EDIT");
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string statement = null;
            if (undolist.Count != 0) statement = undolist.Pop().ToString();

            if (statement == "EDIT")
            {
                undolist.Push("EDIT");
                this.bdsKho.EndEdit();
                this.khoTableAdapter.Update(this.DS.Kho);
                bdsKho.Position = position;

                btnSua.Enabled = btnThem.Enabled = btnXoa.Enabled  = btnReload.Enabled = btnUndo.Enabled = true;
                gcInfoKho.Enabled = btnGhi.Enabled = false;
                gridKho.Enabled = true;
                return;
            }
            else
            {
                undolist.Push("INSERT");
            }

            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                txtMaKho.Text = txtMaKho.Text.Trim();
                String MaKho = txtMaKho.Text;

                if (Program.KetNoi() == 0) return;
                // == Query tìm MaKho ==
                String query_MaKho = "DECLARE	@return_value int " +
                               "EXEC @return_value = [dbo].[SP_CHECKID_TRACUU] " +
                               "@p1, @p2 " +
                               "SELECT 'Return Value' = @return_value";
                SqlCommand sqlCommand = new SqlCommand(query_MaKho, Program.conn);
                sqlCommand.Parameters.AddWithValue("@p1", MaKho);
                sqlCommand.Parameters.AddWithValue("@p2", "MaKho");
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
                int result_value_MaKho = int.Parse(dataReader.GetValue(0).ToString());
                dataReader.Close();
                // Check ràng buộc MaKho
                int indexMaKho = bdsKho.Find("MaKho", txtMaKho.Text);

                int indexCurrent = bdsKho.Position;
                if (result_value_MaKho == 1 && (indexMaKho != indexCurrent))
                {
                    MessageBox.Show("Mã nhân viên đã tồn tại!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else
                {
                    DialogResult dr = MessageBox.Show("Bạn có chắc muốn ghi dữ liệu vào Database?", "Thông báo",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (dr == DialogResult.OK)
                    {
                        try
                        {
                            //Program.flagCloseFormMaKho = true; //Bật cờ cho phép tắt Form NV
                            btnThem.Enabled = btnXoa.Enabled = gridKho.Enabled = gcInfoKho.Enabled = true;
                            btnReload.Enabled = btnGhi.Enabled = true;
                            btnUndo.Enabled = true;
                            this.bdsKho.EndEdit();
                            this.khoTableAdapter.Update(this.DS.Kho);
                            undolist.Pop();
                            undolist.Push(MaKho);
                            undolist.Push("INSERT");
                            bdsKho.Position = position;
                            //Program.frmMain.timer1.Enabled = true;

                            btnSua.Enabled  = btnThoat.Enabled = true;
                            btnGhi.Enabled = false;
                        }
                        catch (Exception ex)
                        {
                            // Khi Update database lỗi thì xóa record vừa thêm trong bds
                            bdsKho.RemoveCurrent();
                            MessageBox.Show("Thất bại. Vui lòng kiểm tra lại!\n" + ex.Message, "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string maKho = "";

            if (bdsDH.Count > 0)
            {
                MessageBox.Show("Không thể xóa kho vì đã lập đơn đặt hàng", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (bdsPN.Count > 0)
            {
                MessageBox.Show("Không thể xóa kho vì đã lập phiếu nhập", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (bdsPX.Count > 0)
            {
                MessageBox.Show("Không thể xóa kho vì đã lập phiếu xuất", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult dr = MessageBox.Show("Bạn có thực sự muốn xóa kho này không?", "Xác nhận",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                try
                {
                    maKho = ((DataRowView)bdsKho[bdsKho.Position])["MAKHO"].ToString();
                    //string tenKho = ((DataRowView)bdsKho[bdsKho.Position])["TENKHO"].ToString();
                    //string diaChi = ((DataRowView)bdsKho[bdsKho.Position])["DIACHI"].ToString();
                    undolist.Push(txtMaKho.Text + "#" + txtTenKho.Text + "#" + txtDiaChi.Text);
                    undolist.Push("DELETE");

                    bdsKho.RemoveCurrent();
                    
                    this.khoTableAdapter.Update(this.DS.Kho);
                    

                    btnUndo.Enabled = true;
                    //history_kho.Push(XOA_BTN + "#%" + maKho + "#%" + tenKho + "#%" + diaChi);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xảy ra trong quá trình xóa. Vui lòng thử lại!\n" + ex.Message, "Thông báo lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.khoTableAdapter.Fill(this.DS.Kho);
                    bdsKho.Position = bdsKho.Find("MAKHO", maKho);
                    return;
                }
            }

            if (bdsKho.Count == 0) btnXoa.Enabled = false;
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.khoTableAdapter.Fill(this.DS.Kho);
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (undolist.Count > 0)
            {
                String statement = undolist.Pop().ToString();
                if (statement.Equals("DELETE"))
                {
                    //btnThem.Enabled = btnXoa.Enabled = nhanVienGridControl.Enabled = btnReload.Enabled = btnThoat.Enabled = false;
                    //btnUndo.Enabled = gcInfoNhanVien.Enabled = btnGhi.Enabled = true;
                    this.bdsKho.AddNew();
                    String TT = undolist.Pop().ToString();
                    String[] TT_Kho = TT.Split('#');
                    txtMaKho.Text = TT_Kho[0];
                    txtTenKho.Text = TT_Kho[1];
                    txtDiaChi.Text = TT_Kho[2];
                    txtMaCN.Text = maCN;
                    this.bdsKho.EndEdit();
                    this.khoTableAdapter.Update(this.DS.Kho);
                }
                else if (statement.Equals("INSERT"))
                {
                    String maNV = undolist.Pop().ToString();
                    int vitrixoa = bdsKho.Find("MAKHO", maNV);
                    bdsKho.Position = vitrixoa;
                    bdsKho.RemoveCurrent();
                    this.khoTableAdapter.Update(this.DS.Kho);
                }
                else if (statement.Equals("EDIT"))
                {


                    String TT = undolist.Pop().ToString();
                    String[] TT_Kho = TT.Split('#');
                    bdsKho.Position = bdsKho.Find("MAKHO", TT_Kho[0]);

                    txtMaKho.Text = TT_Kho[0];
                    txtTenKho.Text = TT_Kho[1];
                    txtDiaChi.Text = TT_Kho[2];
                    txtMaCN.Text = maCN;

                    this.bdsKho.EndEdit();
                    this.khoTableAdapter.Update(this.DS.Kho);
                }
            }
            if (undolist.Count == 0) btnUndo.Enabled = false;
        }

        private void btnBreak_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string statement = undolist.Pop().ToString();
            if (statement == "EDIT")
            {
                undolist.Pop();
                bdsKho.CancelEdit();
            }
            else
            {
                bdsKho.RemoveCurrent();
            }

            bdsKho.Position = position;
            btnSua.Enabled = btnThem.Enabled = btnXoa.Enabled = btnReload.Enabled  = true;
            gcInfoKho.Enabled = btnBreak.Enabled = false;
            gridKho.Enabled = true;
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

        private void txtTenKho_Validating(object sender, CancelEventArgs e)
        {
            if (txtTenKho.Text.Trim().Contains("#"))
            {
                e.Cancel = true;
                txtTenKho.Focus();
                errorProvider1.SetError(txtTenKho, "Mã kho không được chứa ký tự đặc biệt!");
            }
            else if (txtTenKho.Text.Length > 30)
            {
                e.Cancel = true;
                txtTenKho.Focus();
                errorProvider1.SetError(txtTenKho, "Tên kho không được quá 30 kí tự");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtMaKho, "");
            }
        }

        private void txtDiaChi_Validating(object sender, CancelEventArgs e)
        {
            if (txtDiaChi.Text.Trim().Contains("#"))
            {
                e.Cancel = true;
                txtDiaChi.Focus();
                errorProvider1.SetError(txtDiaChi, "Mã kho không được chứa ký tự đặc biệt!");
            }
            else if (txtDiaChi.Text.Length > 100)
            {
                e.Cancel = true;
                txtDiaChi.Focus();
                errorProvider1.SetError(txtDiaChi, "Tên kho không được quá 100 kí tự");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtDiaChi, "");
            }
        }

        private void cmbChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbChiNhanh.SelectedValue.ToString() == "System.Data.DataRowView") return;

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
                this.khoTableAdapter.Connection.ConnectionString = Program.connstr;
                this.khoTableAdapter.Fill(this.DS.Kho);
                maCN = ((DataRowView)bdsKho[0])["MACN"].ToString();
            }
        }
    }
}

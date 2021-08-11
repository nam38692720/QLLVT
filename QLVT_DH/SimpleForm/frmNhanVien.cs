using DevExpress.XtraEditors;
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
    public partial class frmNhanVien : Form
    {
        int position = 0;
        string maCN = "";
        Stack undolist = new Stack();

        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.nhanvienTableAdapter.Fill(this.DS.NHANVIEN);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Reload :" + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            position = bdsNV.Position;
            gcInfoNhanVien.Enabled = txtMaNV.Enabled = true;
            bdsNV.AddNew();
            txtMaCN.Text = maCN;
            dateNgaySinh.EditValue = "";
            cbTTXoa.Checked = false;

            btnThem.Enabled = btnXoa.Enabled = btnReload.Enabled = btnUndo.Enabled = btnThoat.Enabled = gridNhanVien.Enabled= btnSua.Enabled = btnChuyenChiNhanh.Enabled = false;
            btnGhi.Enabled = btnBreak.Enabled = true;

            undolist.Push("INSERT");
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
                    this.bdsNV.EndEdit();
                    this.nhanvienTableAdapter.Update(this.DS.NHANVIEN);
                    bdsNV.Position = position;

                    btnSua.Enabled = btnThem.Enabled = btnXoa.Enabled = btnChuyenChiNhanh.Enabled = btnReload.Enabled = btnUndo.Enabled = true;
                    gcInfoNhanVien.Enabled = btnGhi.Enabled = false;
                    gridNhanVien.Enabled = true;
                    return;
                }
                else
                {
                    undolist.Push("INSERT");
                }



                txtMaNV.Text = txtMaNV.Text.Trim();
                int maNV = int.Parse(txtMaNV.Text);

                if (Program.KetNoi() == 0) return;
                // == Query tìm MANV ==
                String query_MANV = "DECLARE	@return_value int " +
                               "EXEC @return_value = [dbo].[SP_CHECKTRUNG] " +
                               "@p1, @p2 " +
                               "SELECT 'Return Value' = @return_value";
                SqlCommand sqlCommand = new SqlCommand(query_MANV, Program.conn);
                sqlCommand.Parameters.AddWithValue("@p1", maNV);
                sqlCommand.Parameters.AddWithValue("@p2", "MANV");
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
                int result_value_MANV = int.Parse(dataReader.GetValue(0).ToString());
                dataReader.Close();
                // Check ràng buộc MANV
                int indexMaNV = bdsNV.Find("MANV", txtMaNV.Text);

                int indexCurrent = bdsNV.Position;
                if (result_value_MANV == 1 && (indexMaNV != indexCurrent))
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
                            //Program.flagCloseFormKho = true; //Bật cờ cho phép tắt Form NV
                            btnThem.Enabled = btnXoa.Enabled = gridNhanVien.Enabled = gcInfoNhanVien.Enabled = true;
                            btnReload.Enabled = btnGhi.Enabled = true;
                            btnUndo.Enabled = true;
                            this.bdsNV.EndEdit();
                            this.nhanvienTableAdapter.Update(this.DS.NHANVIEN);
                            undolist.Pop();
                            undolist.Push(maNV);
                            undolist.Push("INSERT");
                            bdsNV.Position = position;
                            //Program.frmMain.timer1.Enabled = true;

                            btnSua.Enabled = btnChuyenChiNhanh.Enabled = btnThoat.Enabled = btnUndo.Enabled = true;
                            btnGhi.Enabled = false;
                        }
                        catch (Exception ex)
                        {
                            // Khi Update database lỗi thì xóa record vừa thêm trong bds
                            bdsNV.RemoveCurrent();
                            MessageBox.Show("Thất bại. Vui lòng kiểm tra lại!\n" + ex.Message, "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
            }
        }
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            position = bdsNV.Position;
            btnSua.Enabled = btnThem.Enabled = btnXoa.Enabled = btnChuyenChiNhanh.Enabled = btnReload.Enabled = false;
            gcInfoNhanVien.Enabled = btnGhi.Enabled = btnBreak.Enabled = true;
            gridNhanVien.Enabled = false;
            

            String NV_info = txtMaNV.Text.Trim() + "#" + txtHo.Text.Trim() + "#" + txtTen.Text.Trim() + "#" + txtMaCN.Text.Trim() + "#" +
                            dateNgaySinh.Text + "#" + txtDiaChi.Text.Trim() + "#" + txtLuong.Text.Trim();
            undolist.Push(NV_info);
            undolist.Push("EDIT");
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string maNV = "";

            if (cbTTXoa.Checked == true)
            {
                MessageBox.Show("Nhân viên đã bị xóa, đang ở chi nhánh khác", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (bdsDH.Count > 0)
            {
                MessageBox.Show("Không thể xóa nhân viên vì đã lập đơn đặt hàng", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (bdsPN.Count > 0)
            {
                MessageBox.Show("Không thể xóa nhân viên vì đã lập phiếu nhập", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (bdsPX.Count > 0)
            {
                MessageBox.Show("Không thể xóa nhân viên vì đã lập phiếu xuất", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult dr = MessageBox.Show("Bạn có thực sự muốn xóa nhân viên này không?", "Xác nhận",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                try
                {
                    String NV_info = txtMaNV.Text.Trim() + "#" + txtHo.Text.Trim() + "#" + txtTen.Text.Trim() + "#" + txtMaCN.Text.Trim() + "#" +
                            dateNgaySinh.Text + "#" + txtDiaChi.Text.Trim() + "#" + txtLuong.Text.Trim();
                    Console.WriteLine(NV_info);
                    maNV = ((DataRowView)bdsNV[bdsNV.Position])["MANV"].ToString();
                    undolist.Push(NV_info);
                    undolist.Push("DELETE");

                    bdsNV.RemoveCurrent();
                    btnUndo.Enabled = true;
                    


                    Program.mlogin = Program.remotelogin;
                    Program.password = Program.remotepassword;
                    if (Program.KetNoi() == 0)
                        MessageBox.Show("Lỗi kết nối về chi nhánh mới", "", MessageBoxButtons.OK);


                    Program.conn = new SqlConnection(Program.connstr);
                    Program.conn.Open();
                    SqlCommand cmd = new SqlCommand("Xoa_Login", Program.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@USRNAME", maNV));
                    SqlDataReader myReader = null;
                    try
                    {
                        myReader = cmd.ExecuteReader();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    this.nhanvienTableAdapter.Update(this.DS.NHANVIEN);
                    Program.mlogin = Program.mloginDN;
                    Program.password = Program.passwordDN;
                    if (Program.KetNoi() == 0)
                        MessageBox.Show("Lỗi kết nối về chi nhánh mới", "", MessageBoxButtons.OK);

                    this.nhanvienTableAdapter.Update(this.DS.NHANVIEN);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xảy ra trong quá trình xóa. Vui lòng thử lại!\n" + ex.Message, "Thông báo lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.nhanvienTableAdapter.Fill(this.DS.NHANVIEN);
                    bdsNV.Position = bdsNV.Find("MANV", maNV);
                    return;
                }
            }
        }

        String CNchuyen;
        public void GETVALUE(String index)
        {
            CNchuyen = index;
            Console.WriteLine("CHI NHANH DUOC CHON LA: " + CNchuyen);
            if (CNchuyen != Program.servername)
            {
                String maCN = "";
                if (CNchuyen.Contains("2")) maCN = "CN2";
                else if (CNchuyen.Contains("1")) maCN = "CN1";

                String maNV = ((DataRowView)bdsNV[bdsNV.Position])["MANV"].ToString();
                Console.WriteLine(maNV);
                Program.conn = new SqlConnection(Program.connstr);
                Program.conn.Open();
                SqlCommand cmd = new SqlCommand("SP_CHUYENCHINHANH_NV", Program.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MANV", maNV));
                cmd.Parameters.Add(new SqlParameter("@MACN", maCN));
                SqlDataReader myReader = null;
                try
                {
                    myReader = cmd.ExecuteReader();
                    MessageBox.Show("Chuyển nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    undolist.Push(maNV + "#" + CNchuyen);
                    undolist.Push("CHUYENCN");
                    this.nhanvienTableAdapter.Fill(this.DS.NHANVIEN);
                    btnUndo.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else MessageBox.Show("Vui lòng chọn CN khác chi nhánh hiện tại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnChuyenChiNhanh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int trangThaiXoa = int.Parse(((DataRowView)bdsNV[bdsNV.Position])["TrangThaiXoa"].ToString());
            if (trangThaiXoa == 0)
            {
                frmChuyenCN pickCN = new frmChuyenCN();
                pickCN.mydata = new frmChuyenCN.GETDATA(GETVALUE);
                pickCN.ShowDialog();
            }
            else
            {
                MessageBox.Show("Nhân viên hiện không có ở chi nhánh này", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
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
                    this.bdsNV.AddNew();
                    String TT = undolist.Pop().ToString();
                    String[] TT_NV = TT.Split('#');
                    txtMaNV.Text = TT_NV[0];
                    txtHo.Text = TT_NV[1];
                    txtTen.Text = TT_NV[2];
                    txtMaCN.Text = TT_NV[3];
                    dateNgaySinh.Text = TT_NV[4];
                    txtDiaChi.Text = TT_NV[5];
                    txtLuong.Text = TT_NV[6];
                    cbTTXoa.Checked = false;
                    this.bdsNV.EndEdit();
                    this.nhanvienTableAdapter.Update(this.DS.NHANVIEN);
                }
                else if (statement.Equals("INSERT"))
                {
                    String maNV = undolist.Pop().ToString();
                    int vitrixoa = bdsNV.Find("MANV", maNV);
                    bdsNV.Position = vitrixoa;
                    bdsNV.RemoveCurrent();
                }
                else if (statement.Equals("EDIT"))
                {
                    

                    String TT = undolist.Pop().ToString();
                    String[] TT_NV = TT.Split('#');

                    bdsNV.Position = bdsNV.Find("MANV", TT_NV[0]);
                    txtMaNV.Text = TT_NV[0];
                    txtHo.Text = TT_NV[1];
                    txtTen.Text = TT_NV[2];
                    txtMaCN.Text = TT_NV[3];
                    dateNgaySinh.Text = TT_NV[4];
                    txtDiaChi.Text = TT_NV[5];
                    txtLuong.Text = TT_NV[6];
                    cbTTXoa.Checked = false;
                    this.bdsNV.EndEdit();
                    this.nhanvienTableAdapter.Update(this.DS.NHANVIEN);
                }
                else if (statement.Equals("CHUYENCN"))
                {
                    String info = undolist.Pop().ToString();
                    String[] info_CN = info.Split('#');
                    Console.WriteLine(info_CN[0] + " " + info_CN[1]);
                    String servername_temp = Program.servername;

                    Program.servername = info_CN[1].ToString();

                    Program.mlogin = Program.remotelogin;
                    Program.password = Program.remotepassword;


                    if (Program.KetNoi() == 0)
                        MessageBox.Show("Lỗi kết nối về chi nhánh mới", "", MessageBoxButtons.OK);
                    String maNV = info_CN[0].ToString();
                    String maCN = "";
                    if (info_CN[1].ToString().Contains("2")) maCN = "CN1";
                    else if (info_CN[1].ToString().Contains("1")) maCN = "CN2";
                    Program.conn = new SqlConnection(Program.connstr);
                    Program.conn.Open();
                    SqlCommand cmd = new SqlCommand("SP_CHUYENCHINHANH_NV", Program.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@MANV", maNV));
                    cmd.Parameters.Add(new SqlParameter("@MACN", maCN));
                    SqlDataReader myReader = null;
                    try
                    {
                        myReader = cmd.ExecuteReader();
                        MessageBox.Show("Chuyển nhân viên trở về thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.nhanvienTableAdapter.Fill(this.DS.NHANVIEN);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        if (Program.servername != servername_temp)
                        {
                            Program.servername = servername_temp;
                            Program.mlogin = Program.mloginDN;
                            Program.password = Program.passwordDN;
                            if (Program.KetNoi() == 0)
                                MessageBox.Show("Lỗi kết nối về chi nhánh mới", "", MessageBoxButtons.OK);
                        }

                    }

                }
                this.nhanvienTableAdapter.Update(this.DS.NHANVIEN);
            }
            if (undolist.Count == 0) btnUndo.Enabled = false;
        }

        private void nHANVIENBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsNV.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);

        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {

            DS.EnforceConstraints = false;

            // TODO: This line of code loads data into the 'dS.NHANVIEN' table. You can move, or remove it, as needed.
            this.nhanvienTableAdapter.Connection.ConnectionString = Program.connstr;
            this.nhanvienTableAdapter.Fill(this.DS.NHANVIEN);


            // TODO: This line of code loads data into the 'DS.DATHANG' table. You can move, or remove it, as needed.
            this.datHangTableAdapter.Connection.ConnectionString = Program.connstr;
            this.datHangTableAdapter.Fill(this.DS.DATHANG);
            // TODO: This line of code loads data into the 'DS.PHIEUNHAP' table. You can move, or remove it, as needed.
            this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
            this.phieuNhapTableAdapter.Fill(this.DS.PHIEUNHAP);
            // TODO: This line of code loads data into the 'DS.PHIEUXUAT' table. You can move, or remove it, as needed.
            this.phieuXuatTableAdapter.Connection.ConnectionString = Program.connstr;
            this.phieuXuatTableAdapter.Fill(this.DS.PHIEUXUAT);

            if(Program.bds_dspm.Count ==3)
            {
                Program.bds_dspm.RemoveAt(2);
            }


            maCN = ((DataRowView)bdsNV[0])["MACN"].ToString(); // Lúc đúng lúc sai, tìm cách khác.


            cmbChiNhanh.DataSource = Program.bds_dspm;  // sao chép bds_dspm đã load ở form đăng nhập  qua
            cmbChiNhanh.DisplayMember = "TENCN";
            cmbChiNhanh.ValueMember = "TENSERVER";
            cmbChiNhanh.SelectedIndex = Program.mChiNhanh;

            // Phân Quyền
            // TODO: CONGTY thì comboBox sáng lên, các nút chức năng PHẢI mờ
            //       Không phải công ty thì comboBox mờ, các nút chức năng cần thiết PHẢI sáng.
            if (Program.mGroup == "CONGTY")
            {
                cmbChiNhanh.Enabled = true;  // bật tắt theo phân quyền
                btnThem.Enabled = btnXoa.Enabled = btnGhi.Enabled = btnSua.Enabled = false;
                btnUndo.Enabled = btnChuyenChiNhanh.Enabled = gcInfoNhanVien.Enabled = false;
            }
            else if (Program.mGroup == "CHINHANH" || Program.mGroup == "USER")
            {
                cmbChiNhanh.Enabled = btnUndo.Enabled = txtMaNV.Enabled = false;
            }

            txtMaCN.Enabled = btnGhi.Enabled = gcInfoNhanVien.Enabled = false;
            btnBreak.Enabled = false;
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnBreak_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string statement = undolist.Pop().ToString();
            if (statement == "EDIT")
                undolist.Pop();

            bdsNV.CancelEdit();//hủy cho cả thêm và sửa


            bdsNV.Position = position;
            btnSua.Enabled = btnThem.Enabled = btnXoa.Enabled = btnReload.Enabled = true;
            gcInfoNhanVien.Enabled = btnBreak.Enabled = false;
            gridNhanVien.Enabled = true;
            //sau khi break ra thì phải trả validate về none để k hiển thi nữa
            ValidateChildren(ValidationConstraints.None);
                
        }
        private bool Validate(DateEdit date, string str)
        {
            if (date.Text.Trim().Equals(""))
            {
                MessageBox.Show(str, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                date.Focus();
                return false;
            }
            return true;
        }

        private void txtMaNV_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNV.Text))
            {
                e.Cancel = true;
                txtMaNV.Focus();
                errorProvider1.SetError(txtMaNV, "Mã nhân viên không được để trống!");
            }
            else if (txtMaNV.Text.Trim().Contains(" "))
            {
                e.Cancel = true;
                txtMaNV.Focus();
                errorProvider1.SetError(txtMaNV, "Mã nhân viên không được chứa khoảng trắng!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtMaNV, "");
            }
        }

        private void txtMaCN_Validating(object sender, CancelEventArgs e)
        {

        }

        private void txtHo_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHo.Text))
            {
                e.Cancel = true;
                txtHo.Focus();
                errorProvider1.SetError(txtHo, "Họ nhân viên không được để trống!");
            }
            else if (txtHo.Text.Trim().Contains("#"))
            {
                e.Cancel = true;
                txtHo.Focus();
                errorProvider1.SetError(txtHo, "Họ nhân viên không được chứa ký tự đặc biệt!");
            }
            else if (txtHo.Text.Length > 40)
            {
                e.Cancel = true;
                txtHo.Focus();
                errorProvider1.SetError(txtHo, "Họ nhân viên không được quá 40 kí tự");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtHo, "");
            }
        }

        private void txtTen_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTen.Text))
            {
                e.Cancel = true;
                txtTen.Focus();
                errorProvider1.SetError(txtTen, "Tên nhân viên không được để trống!");
            }
            else if (txtTen.Text.Trim().Contains("#"))
            {
                e.Cancel = true;
                txtTen.Focus();
                errorProvider1.SetError(txtTen, "Tên nhân viên không được chứa ký tự đặc biệt!");
            }
            else if (txtTen.Text.Length > 10)
            {
                e.Cancel = true;
                txtTen.Focus();
                errorProvider1.SetError(txtTen, "Tên nhân viên không được quá 10 kí tự");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtTen, "");
            }
        }
        private static int CalculateAge(DateTime dateOfBirth)
        {
            int age = 0;
            age = DateTime.Now.Year - dateOfBirth.Year;
            if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
                age = age - 1;

            return age;
        }

        private void dateNgaySinh_Validating(object sender, CancelEventArgs e)
        {
            if (CalculateAge(dateNgaySinh.DateTime) > 60)
            {
                e.Cancel = true;
                dateNgaySinh.Focus();
                errorProvider1.SetError(dateNgaySinh, "Ngày sinh không hợp lệ!");
            }
            else if (CalculateAge(dateNgaySinh.DateTime) < 18)
            {
                e.Cancel = true;
                dateNgaySinh.Focus();
                errorProvider1.SetError(dateNgaySinh, "Nhân viên phải lớn hơn hoặc bằng 18 tuổi!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(dateNgaySinh, "");
            }
        }

        private void txtLuong_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLuong.Text))
            {
                e.Cancel = true;
                txtLuong.Focus();
                errorProvider1.SetError(txtMaNV, "Mã nhân viên không được để trống!");
            }
            else if (txtLuong.Text.Trim().Contains(" "))
            {
                e.Cancel = true;
                txtLuong.Focus();
                errorProvider1.SetError(txtLuong, "Mã nhân viên không được chứa khoảng trắng!");
            }
            //else if(int.Parse(txtLuong.Text.Trim()) < 4000000)
            //{
            //    e.Cancel = true;
            //    txtLuong.Focus();
            //    errorProvider1.SetError(txtLuong, "Lương phải lơn hơn hoặc bằng 4.000.000");
            //}
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtLuong, "");
            }
        }

        private void txtDiaChi_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                e.Cancel = true;
                txtDiaChi.Focus();
                errorProvider1.SetError(txtDiaChi, "Địa chỉ không được để trống!");
            }
            else if (txtDiaChi.Text.Trim().Contains("#"))
            {
                e.Cancel = true;
                txtDiaChi.Focus();
                errorProvider1.SetError(txtDiaChi, "Địa chỉ không được chứa ký tự đặc biệt!");
            }
            else if (txtDiaChi.Text.Length > 100)
            {
                e.Cancel = true;
                txtDiaChi.Focus();
                errorProvider1.SetError(txtDiaChi, "Địa chỉ không được quá 100 kí tự");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtDiaChi, "");
            }
        }
        private void txtTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if ( !char.IsNumber(e.KeyChar) && !char.IsDigit(e.KeyChar))
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtHo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
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
                // TODO: This line of code loads data into the 'dS.NHANVIEN' table. You can move, or remove it, as needed.
                this.nhanvienTableAdapter.Connection.ConnectionString = Program.connstr;
                this.nhanvienTableAdapter.Fill(this.DS.NHANVIEN);


                // TODO: This line of code loads data into the 'DS.DATHANG' table. You can move, or remove it, as needed.
                this.datHangTableAdapter.Connection.ConnectionString = Program.connstr;
                this.datHangTableAdapter.Fill(this.DS.DATHANG);
                // TODO: This line of code loads data into the 'DS.PHIEUNHAP' table. You can move, or remove it, as needed.
                this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
                this.phieuNhapTableAdapter.Fill(this.DS.PHIEUNHAP);
                // TODO: This line of code loads data into the 'DS.PHIEUXUAT' table. You can move, or remove it, as needed.
                this.phieuXuatTableAdapter.Connection.ConnectionString = Program.connstr;
                this.phieuXuatTableAdapter.Fill(this.DS.PHIEUXUAT);
            }
        }
    }
}

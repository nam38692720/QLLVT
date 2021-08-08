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
    public partial class frmVatTu : Form
    {
        int position = 0;
        Stack undolist = new Stack();
        public frmVatTu()
        {
            InitializeComponent();
        }

        private void vattuBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsVT.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);

        }

        private void frmVatTu_Load(object sender, EventArgs e)
        {
            DS.EnforceConstraints = false;

            // TODO: This line of code loads data into the 'dS.Vattu' table. You can move, or remove it, as needed.
            this.vattuTableAdapter.Connection.ConnectionString = Program.connstr;
            this.vattuTableAdapter.Fill(this.DS.Vattu);

            // TODO: This line of code loads data into the 'dS.CTDDH' table. You can move, or remove it, as needed.
            this.cTDDHTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTDDHTableAdapter.Fill(this.DS.CTDDH);
            // TODO: This line of code loads data into the 'dS.CTPN' table. You can move, or remove it, as needed.
            this.cTPNTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTPNTableAdapter.Fill(this.DS.CTPN);
            // TODO: This line of code loads data into the 'dS.CTPX' table. You can move, or remove it, as needed.
            this.cTPXTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTPXTableAdapter.Fill(this.DS.CTPX);

            if (Program.mGroup == "CONGTY")
            {
                btnThem.Enabled = btnXoa.Enabled = btnGhi.Enabled = btnSua.Enabled = false;
            }

            txtMaVT.Enabled = btnUndo.Enabled = false;

            //Mặc định vừa vào groupbox không dx hiện để tránh lỗi sửa các dòng cũ chưa lưu đi qua dòng khác
            btnUndo.Enabled = btnBreak.Enabled = false;
            gcInfoVT.Enabled = false;
            txtMaVT.Enabled = false;

        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            position = bdsVT.Position;
            gcInfoVT.Enabled = txtMaVT.Enabled = true;
            bdsVT.AddNew();
            //txtMaCN.Text = maCN;
            //dateNgaySinh.EditValue = "";
            //cbTTXoa.Checked = false;
            numSL.Value = 0;

            btnThem.Enabled = btnXoa.Enabled = btnReload.Enabled = btnUndo.Enabled = btnThoat.Enabled = gridVT.Enabled = btnSua.Enabled = false;
            btnGhi.Enabled = btnBreak.Enabled = true;

            undolist.Push("INSERT");
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string statement = null;
            if (undolist.Count != 0) statement = undolist.Pop().ToString();

            if (statement == "EDIT")
            {
                undolist.Push("EDIT");
                this.bdsVT.EndEdit();
                this.vattuTableAdapter.Update(this.DS.Vattu);
                bdsVT.Position = position;

                btnSua.Enabled = btnThem.Enabled = btnXoa.Enabled = btnReload.Enabled = btnUndo.Enabled = true;
                gcInfoVT.Enabled = btnGhi.Enabled = false;
                gridVT.Enabled = true;
                return;
            }
            else
            {
                undolist.Push("INSERT");
            }

            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                txtMaVT.Text = txtMaVT.Text.Trim();
                String MaVT = txtMaVT.Text;
                if (Program.KetNoi() == 0) return;

                // == Query tìm MANV ==
                String query_MaVT = "DECLARE	@return_value int " +
                               "EXEC @return_value = [dbo].[SP_CHECKID_TRACUU] " +
                               "@p1, @p2 " +
                               "SELECT 'Return Value' = @return_value";
                SqlCommand sqlCommand = new SqlCommand(query_MaVT, Program.conn);
                sqlCommand.Parameters.AddWithValue("@p1", MaVT);
                sqlCommand.Parameters.AddWithValue("@p2", "MAVT");
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
                int indexMaNV = bdsVT.Find("MAVT", txtMaVT.Text);

                int indexCurrent = bdsVT.Position;
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
                            btnThem.Enabled = btnXoa.Enabled = gridVT.Enabled = gcInfoVT.Enabled = true;
                            btnReload.Enabled = btnGhi.Enabled = true;
                            btnUndo.Enabled = true;
                            this.bdsVT.EndEdit();
                            this.vattuTableAdapter.Update(this.DS.Vattu);
                            undolist.Pop();
                            undolist.Push(MaVT);
                            undolist.Push("INSERT");
                            bdsVT.Position = position;
                        }
                        catch (Exception ex)
                        {
                            // Khi Update database lỗi thì xóa record vừa thêm trong bds
                            bdsVT.RemoveCurrent();
                            MessageBox.Show("Thất bại. Vui lòng kiểm tra lại!\n" + ex.Message, "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            position = bdsVT.Position;
            btnSua.Enabled = btnThem.Enabled = btnXoa.Enabled = btnReload.Enabled = false;
            gcInfoVT.Enabled = btnGhi.Enabled = btnBreak.Enabled = true;
            gridVT.Enabled = false;

            undolist.Push(txtMaVT.Text + "#" + txtDVT.Text + "#" + txtTenVT.Text + "#" + numSL.Value);
            undolist.Push("EDIT");
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string mavt = "";
            if (bdsCTPX.Count > 0)
            {
                MessageBox.Show("Không thể xóa CTPX vì đã lập PX có CTPX này rồi", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (bdsCTPN.Count > 0)
            {
                MessageBox.Show("Không thể xóa CTPN vì đã lập PX có CTPN này rồi", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (bdsCTDDH.Count > 0)
            {
                MessageBox.Show("Không thể xóa CTDDH vì đã lập PX có CTDDH này rồi", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show("Bạn có thực sự muốn xóa kho này không?", "Xác nhận",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                try
                {
                    mavt = ((DataRowView)bdsVT[bdsVT.Position])["MAVT"].ToString();
                    //string tenKho = ((DataRowView)bdsKho[bdsKho.Position])["TENKHO"].ToString();
                    //string diaChi = ((DataRowView)bdsKho[bdsKho.Position])["DIACHI"].ToString();
                    undolist.Push(txtMaVT.Text + "#" + txtDVT.Text + "#" + txtTenVT.Text + "#" + numSL.Value);
                    undolist.Push("DELETE");

                    bdsVT.RemoveCurrent();

                    this.vattuTableAdapter.Update(this.DS.Vattu);


                    btnUndo.Enabled = true;
                    //history_kho.Push(XOA_BTN + "#%" + maKho + "#%" + tenKho + "#%" + diaChi);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xảy ra trong quá trình xóa. Vui lòng thử lại!\n" + ex.Message, "Thông báo lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.vattuTableAdapter.Fill(this.DS.Vattu);
                    bdsVT.Position = bdsVT.Find("MAVT", mavt);
                    return;
                }
            }

            if (bdsVT.Count == 0) btnXoa.Enabled = false;
        }

        private void btnBreak_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string statement = undolist.Pop().ToString();
            if (statement == "EDIT")
            {
                undolist.Pop();
                bdsVT.CancelEdit();
            }
            else
            {
                bdsVT.RemoveCurrent();
            }

            bdsVT.Position = position;
            btnSua.Enabled = btnThem.Enabled = btnXoa.Enabled = btnReload.Enabled = true;
            gcInfoVT.Enabled = btnBreak.Enabled = false;
            gridVT.Enabled = true;
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.vattuTableAdapter.Fill(this.DS.Vattu);
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
                    this.bdsVT.AddNew();
                    String TT = undolist.Pop().ToString();
                    //undolist.Push(txtMaVT.Text + "#" + txtDVT.Text + "#" + txtTenVT.Text + "#" + numSL.Value);
                    String[] TT_VT = TT.Split('#');
                    txtMaVT.Text = TT_VT[0];
                    txtDVT.Text = TT_VT[1];
                    txtTenVT.Text = TT_VT[2];
                    numSL.Value = int.Parse(TT_VT[3]);
                    this.bdsVT.EndEdit();
                    this.vattuTableAdapter.Update(this.DS.Vattu);
                }
                else if (statement.Equals("INSERT"))
                {
                    String maVT = undolist.Pop().ToString();
                    int vitrixoa = bdsVT.Find("MAVT", maVT);
                    bdsVT.Position = vitrixoa;
                    bdsVT.RemoveCurrent();
                    this.vattuTableAdapter.Update(this.DS.Vattu);
                }
                else if (statement.Equals("EDIT"))
                {
                    String TT = undolist.Pop().ToString();
                    String[] TT_VT = TT.Split('#');
                    bdsVT.Position = bdsVT.Find("MAKHO", TT_VT[0]);
                    txtMaVT.Text = TT_VT[0];
                    txtDVT.Text = TT_VT[1];
                    txtTenVT.Text = TT_VT[2];
                    numSL.Value = int.Parse(TT_VT[3]);
                    this.bdsVT.EndEdit();
                    this.vattuTableAdapter.Update(this.DS.Vattu);
                }
            }
            if (undolist.Count == 0) btnUndo.Enabled = false;
        }
    }
}

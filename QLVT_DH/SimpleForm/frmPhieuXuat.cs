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
    public partial class frmPhieuXuat : Form
    {
        int position = 0;
        string maCN = "";
        public Stack undolist = new Stack();
        public frmPhieuXuat()
        {
            InitializeComponent();
        }

        private void pHIEUXUATBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsPX.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);

        }

        private void frmPhieuXuat_Load(object sender, EventArgs e)
        {

            DS.EnforceConstraints = false;

            // TODO: This line of code loads data into the 'dS.PHIEUXUAT' table. You can move, or remove it, as needed.
            this.phieuXuatTableAdapter.Connection.ConnectionString = Program.connstr;
            this.phieuXuatTableAdapter.Fill(this.DS.PHIEUXUAT);

            // TODO: This line of code loads data into the 'DS.CTPX' table. You can move, or remove it, as needed.
            this.cTPXTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTPXTableAdapter.Fill(this.DS.CTPX);


            if (Program.bds_dspm.Count == 3) Program.bds_dspm.RemoveAt(2);

            cmbChiNhanh.DataSource = Program.bds_dspm;  // sao chép bds_dspm đã load ở form đăng nhập  qua
            cmbChiNhanh.DisplayMember = "TENCN";
            cmbChiNhanh.ValueMember = "TENSERVER";
            cmbChiNhanh.SelectedIndex = Program.mChiNhanh;


            if (Program.mGroup == "CONGTY")
            {
                cmbChiNhanh.Enabled = true;  // bật tắt theo phân quyền
                btnThem.Enabled = btnXoa.Enabled = btnGhi.Enabled = btnUndo.Enabled = false;
                gbInfoPX.Enabled = false;
            }
            else if (Program.mGroup == "CHINHANH" || Program.mGroup == "USER")
            {
                cmbChiNhanh.Enabled = false;
                gbInfoPX.Enabled = btnGhi.Enabled = false;
            }

            //Mặc định vừa vào groupbox không dx hiện để tránh lỗi sửa các dòng cũ chưa lưu đi qua dòng khác
            btnUndo.Enabled /*= btnBreak.Enabled*/ = false;
            gbInfoPX.Enabled = false;
            btnBreak.Enabled = false;
        }


        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnUndo.Enabled = btnReload.Enabled = btnThemCTPX.Enabled = btnSuaCTPX.Enabled = btnXoaCTPX.Enabled = false;
            txtMaPX.Enabled = btnBreak.Enabled = true;

            gbInfoPX.Enabled = btnGhi.Enabled = true;
            bdsPX.AddNew();
            ((DataRowView)bdsPX[bdsPX.Position])["NGAY"] = DateTime.Today;
            ((DataRowView)bdsPX[bdsPX.Position])["MANV"] = Program.maNV;
            undolist.Push("INSERT");
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string statement = null;
            if (undolist.Count != 0) statement = undolist.Pop().ToString();

            if (statement == "EDIT")
            {
                undolist.Push("EDIT");
                this.bdsPX.EndEdit();
                this.phieuXuatTableAdapter.Update(this.DS.PHIEUXUAT);
                bdsPX.Position = position;

                btnSua.Enabled = btnThem.Enabled = btnXoa.Enabled = btnReload.Enabled = btnUndo.Enabled = btnThemCTPX.Enabled = btnSuaCTPX.Enabled = btnXoaCTPX.Enabled = true;
                gbInfoPX.Enabled = btnGhi.Enabled = btnBreak.Enabled = false;
                gridPX.Enabled = true;
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
                sqlCommand.Parameters.AddWithValue("@p1", txtMaPX.Text);
                sqlCommand.Parameters.AddWithValue("@p2", "MaPX");
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
                int indexMaPhieu = bdsPX.Find("MaPX", txtMaPX.Text);
                int indexCurrent = bdsPX.Position;
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
                            btnThem.Enabled = btnXoa.Enabled = gridPX.Enabled = gbInfoPX.Enabled = true;
                            btnReload.Enabled = btnThoat.Enabled = btnThemCTPX.Enabled = btnSuaCTPX.Enabled = btnXoaCTPX.Enabled = true;
                            btnUndo.Enabled = true;
                            btnBreak.Enabled = false;

                            bdsPX.EndEdit();
                            this.phieuXuatTableAdapter.Update(this.DS.PHIEUXUAT);
                            undolist.Pop();
                            undolist.Push(txtMaPX.Text);
                            undolist.Push("INSERT");
                            bdsPX.Position = position;

                            /*btnSua.Enabled =*/
                            
                            btnGhi.Enabled = false;
                        }
                        catch (Exception ex)
                        {
                            // Khi Update database lỗi thì xóa record vừa thêm trong bds
                            bdsPX.RemoveCurrent();
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
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            position = bdsPX.Position;
            txtMaPX.Enabled = false;
            btnThemCTPX.Enabled = btnSuaCTPX.Enabled = btnXoaCTPX.Enabled = false;
            btnSua.Enabled = btnThem.Enabled = btnXoa.Enabled = btnReload.Enabled = false;
            gbInfoPX.Enabled = btnGhi.Enabled = btnBreak.Enabled = true;
            gridPX.Enabled = false;

            String maPhieu = ((DataRowView)bdsPX[bdsPX.Position])["MaPX"].ToString().Trim();
            string ngay = ((DataRowView)bdsPX[bdsPX.Position])[1].ToString().Trim();
            string name = ((DataRowView)bdsPX[bdsPX.Position])[2].ToString().Trim();
            string maKho = ((DataRowView)bdsPX[bdsPX.Position])[3].ToString().Trim();

            undolist.Push(maPhieu + "#" + ngay + "#" + name + "#" + maKho);
            undolist.Push("EDIT");
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int maNhanVien = int.Parse(((DataRowView)bdsPX[bdsPX.Position])["MANV"].ToString());

            if (Program.maNV == maNhanVien)
            {
                string maPhieu = "";
                if (bdsCTPX.Count > 0)
                {
                    MessageBox.Show("Không thể xóa phiếu này vì đã lập chi tiết phiếu xuất", "Lỗi",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult dr = MessageBox.Show("Bạn có thực sự muốn xóa phiếu/đơn này không?", "Xác nhận",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        maPhieu = ((DataRowView)bdsPX[bdsPX.Position])["MaPX"].ToString().Trim();
                        string ngay = ((DataRowView)bdsPX[bdsPX.Position])[1].ToString().Trim();
                        string name = ((DataRowView)bdsPX[bdsPX.Position])[2].ToString().Trim();
                        string maKho = ((DataRowView)bdsPX[bdsPX.Position])[3].ToString().Trim();

                        bdsPX.RemoveCurrent();
                        this.phieuXuatTableAdapter.Update(this.DS.PHIEUXUAT);
                        undolist.Push(maPhieu + "#" + ngay + "#" + name + "#" + maKho);
                        undolist.Push("DELETE");

                        btnUndo.Enabled = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi xảy ra trong quá trình xóa. Vui lòng thử lại!\n" + ex.Message, "Thông báo lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.phieuXuatTableAdapter.Fill(this.DS.PHIEUXUAT);
                        bdsPX.Position = bdsPX.Find("MaPX", maPhieu);
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

            if (bdsPX.Count == 0) btnXoa.Enabled = false;
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.phieuXuatTableAdapter.Fill(this.DS.PHIEUXUAT);
                this.cTPXTableAdapter.Fill(this.DS.CTPX);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Reload :" + ex.Message, "", MessageBoxButtons.OK);
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
                    this.bdsPX.AddNew();
                    String TT = undolist.Pop().ToString();
                    String[] TT_PX = TT.Split('#');

                    ((DataRowView)bdsPX[bdsPX.Position])[0] = TT_PX[0];
                    ((DataRowView)bdsPX[bdsPX.Position])[1] = TT_PX[1];
                    ((DataRowView)bdsPX[bdsPX.Position])[2] = TT_PX[2];
                    ((DataRowView)bdsPX[bdsPX.Position])[3] = TT_PX[3];
                    ((DataRowView)bdsPX[bdsPX.Position])[4] = Program.maNV;
                    this.bdsPX.EndEdit();
                    this.phieuXuatTableAdapter.Update(this.DS.PHIEUXUAT);
                }
                else if (statement.Equals("INSERT"))
                {
                    String MaPX = undolist.Pop().ToString();
                    int vitrixoa = bdsPX.Find("MaPX", MaPX);
                    bdsPX.Position = vitrixoa;
                    bdsPX.RemoveCurrent();
                    this.phieuXuatTableAdapter.Update(this.DS.PHIEUXUAT);
                }
                else if (statement.Equals("EDIT"))
                {
                    String TT = undolist.Pop().ToString();
                    String[] TT_PX = TT.Split('#');
                    bdsPX.Position = bdsPX.Find("MaPX", TT_PX[0]);

                    ((DataRowView)bdsPX[bdsPX.Position])[0] = TT_PX[0];
                    ((DataRowView)bdsPX[bdsPX.Position])[1] = TT_PX[1];
                    ((DataRowView)bdsPX[bdsPX.Position])[2] = TT_PX[2];
                    ((DataRowView)bdsPX[bdsPX.Position])[3] = TT_PX[3];
                    ((DataRowView)bdsPX[bdsPX.Position])[4] = Program.maNV;

                    this.bdsPX.EndEdit();
                    this.phieuXuatTableAdapter.Update(this.DS.PHIEUXUAT);
                }
            }
            if (undolist.Count == 0) btnUndo.Enabled = false;
        }

        private void btnThemCTPX_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Program.subFrmCTPX = new subFrmCTPX();
            Program.subFrmCTPX.Show();
            undolist.Push("THEMCTPX");
        }

        public BindingSource getBdsPX()
        {
            return this.bdsPX;
        }

        public BindingSource getBdsCTPX()
        {
            return this.bdsCTPX;
        }
        public DS getDataset()
        {
            return this.DS;
        }

        private void btnXoaCTPX_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có thực sự muốn xóa chi tiết phiếu xuất này không", "Xác nhận",
                   MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                bdsCTPX.RemoveCurrent();
                this.cTPXTableAdapter.Update(this.DS.CTPX);
            }
        }

        private void btnSuaCTPX_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Program.subFrmCTPX = new subFrmCTPX();
            Program.subFrmCTPX.Show();
            undolist.Push("SUACTPX");
        }

        private void btnBreak_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string statement = undolist.Pop().ToString();
            if (statement == "EDIT")
            {
                undolist.Pop();
                bdsPX.CancelEdit();
            }
            else
            {
                bdsPX.RemoveCurrent();
            }

            bdsPX.Position = position;
            btnSua.Enabled = btnThem.Enabled = btnXoa.Enabled = btnReload.Enabled = true;
            btnThemCTPX.Enabled = btnSuaCTPX.Enabled = btnXoaCTPX.Enabled = true;
            gbInfoPX.Enabled = btnBreak.Enabled = false;
            gridPX.Enabled = true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLVT_DH.SimpleForm
{
    public partial class subFrmCTPX : Form
    {
        String statememt;
        int SLCu;
        public subFrmCTPX()
        {
            InitializeComponent();
        }
        private string getDataRow(BindingSource bindingSource, string column)
        {
            return ((DataRowView)bindingSource[bindingSource.Position])[column].ToString().Trim();
        }

        private void vattuBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsVT.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);

        }

        private void subFrmCTPX_Load(object sender, EventArgs e)
        {
            DS.EnforceConstraints = false;

            // TODO: This line of code loads data into the 'dS.Vattu' table. You can move, or remove it, as needed.
            this.vattuTableAdapter.Connection.ConnectionString = Program.connstr;
            this.vattuTableAdapter.Fill(this.DS.Vattu);

            // TODO: This line of code loads data into the 'DS.PHIEUXUAT' table. You can move, or remove it, as needed.
            this.vattuTableAdapter.Connection.ConnectionString = Program.connstr;
            this.pHIEUXUATTableAdapter.Fill(this.DS.PHIEUXUAT);
            // TODO: This line of code loads data into the 'dS.CTPX' table. You can move, or remove it, as needed.
            this.cTPXTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTPXTableAdapter.Fill(this.DS.CTPX);

            this.bdsPX.DataSource = Program.frmPhieuXuat.getBdsPX();
            this.bdsCTPX.DataSource = Program.frmPhieuXuat.getBdsCTPX();

            

            txtMaVT.Enabled = txtMaPX.Enabled = false;
        }

        private void gvVT_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            txtMaVT.Text = getDataRow(bdsVT, "MAVT");
        }

        private void subFrmCTPX_Shown(object sender, EventArgs e)
        {
            statememt = Program.frmPhieuXuat.undolist.Pop().ToString();
            if(statememt == "THEMCTPX")
            {
                this.bdsCTPX.AddNew();
                txtMaPX.Text = getDataRow(bdsCTPX, "MaPX");
                txtMaVT.Text = getDataRow(bdsVT, "MAVT");
                numSL.Value = 1;
                numDG.Value = 0;
            }
            else
            {
                txtMaPX.Text = getDataRow(bdsCTPX, "MaPX");
                txtMaVT.Text = getDataRow(bdsCTPX, "MAVT");
                string maVT = getDataRow(bdsCTPX, "MAVT");
                bdsVT.Position = bdsVT.Find("MAVT", maVT);
                //lưu lại biến số lượng ban đầu để check lúc ghi
                numSL.Value = SLCu = int.Parse(getDataRow(bdsCTPX, "SOLUONG"));
                numDG.Value = int.Parse(getDataRow(bdsCTPX, "DONGIA"));
            }
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                int indexMaVT = bdsCTPX.Find("MAVT", txtMaVT.Text);
                if (indexMaVT != -1 && (indexMaVT != bdsCTPX.Position))
                {
                    MessageBox.Show("Đã tồn tại mã vật tư cùng với mã đơn hàng!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // lấy ra số lượng vật tư để kiểm tra
                int SLVT = int.Parse(getDataRow(bdsVT, "SOLUONGTON"));
                if(statememt == "THEMCTPX")
                {
                    if (numSL.Value > SLVT)
                    {   // trường hợp thêm
                        MessageBox.Show("Số lượng phiếu xuất nhập nhiều hơn số lượng hàng tồn kho!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    if(numSL.Value - SLCu > SLVT)
                    {   // trường hợp sửa
                        MessageBox.Show("Số lượng phiếu xuất nhập nhiều hơn số lượng hàng tồn kho!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                DialogResult dr = MessageBox.Show("Bạn có chắc muốn ghi dữ liệu vào Database?", "Thông báo",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        ((DataRowView)bdsCTPX[bdsCTPX.Position])["MAPX"] = txtMaPX.Text.ToString().Trim();
                        ((DataRowView)bdsCTPX[bdsCTPX.Position])["MAVT"] = txtMaVT.Text.ToString().Trim();
                        ((DataRowView)bdsCTPX[bdsCTPX.Position])["SOLUONG"] = int.Parse(numSL.Value.ToString());
                        ((DataRowView)bdsCTPX[bdsCTPX.Position])["DONGIA"] = float.Parse(numDG.Value.ToString());
                        
                        // Thực hiện việc ghi dữ liệu
                        this.bdsCTPX.EndEdit();
                        this.cTPXTableAdapter.Update(Program.frmPhieuXuat.getDataset().CTPX);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ghi dữ liệu thất lại. Vui lòng kiểm tra lại!\n" + ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        // Lỗi thì phải cho AddNew, nếu không thì dữ liệu sẽ là dữ liệu của mẩu tin cuối
                        BindingSource bdsPX = Program.frmPhieuXuat.getBdsPX();
                        string MaPX = getDataRow(bdsPX, "MaPX");
                        txtMaPX.Text = MaPX;
                        this.bdsCTPX.AddNew();
                        txtMaVT.Text = getDataRow(bdsVT, "MAVT");
                        numSL.Value = 1;
                        numDG.Value = 0;
                    }
                }
            }
        }

        private void subFrmCTPX_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(statememt == "THEMCTPX")
            {
                bdsCTPX.CancelEdit();
            }
        }

        private void numSL_Validating(object sender, CancelEventArgs e)
        {
            if (numSL.Value < 0)
            {
                e.Cancel = true;
                numSL.Focus();
                errorProvider1.SetError(numSL, "Số lượng phải lớn hơn 0!");
            }
        }

        private void numDG_Validating(object sender, CancelEventArgs e)
        {
            if (numDG.Value == 0)
            {
                e.Cancel = true;
                numDG.Focus();
                errorProvider1.SetError(numDG, "Đơn giá phải lớn hơn 0!");
            }
        }
    }
}

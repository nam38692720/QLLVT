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
        String stamemt;
        private bool updateSuccess = false;
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

            // TODO: This line of code loads data into the 'dS.CTPX' table. You can move, or remove it, as needed.
            this.cTPXTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTPXTableAdapter.Fill(this.DS.CTPX);

            this.bdsCTPX.DataSource = Program.frmPhieuXuat.getBdsCTPX();

            txtMaVT.Enabled = txtMaPX.Enabled = false;
        }

        private void gvVT_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            txtMaVT.Text = getDataRow(bdsVT, "MAVT");
        }

        private void subFrmCTPX_Shown(object sender, EventArgs e)
        {
            BindingSource bdsPX = Program.frmPhieuXuat.getBdsPX();
            stamemt = Program.frmPhieuXuat.undolist.Pop().ToString();
            if(stamemt == "THEMCTPX")
            {
                this.bdsCTPX.AddNew();
                txtMaPX.Text = getDataRow(bdsPX, "MaPX");
                txtMaVT.Text = getDataRow(bdsVT, "MAVT");
                numSL.Value = 1;
                numDG.Value = 0;
            }
            else
            {
                txtMaPX.Text = getDataRow(bdsCTPX, "MaPX");
                txtMaVT.Text = getDataRow(bdsCTPX, "MAVT");
                numSL.Value = int.Parse(getDataRow(bdsCTPX, "SOLUONG"));
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
                if (numSL.Value > SLVT)
                {
                    MessageBox.Show("Số lượng phiếu xuất nhập nhiều hơn số lượng hàng tồn kho!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DialogResult dr = MessageBox.Show("Bạn có chắc muốn ghi dữ liệu vào Database?", "Thông báo",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        ((DataRowView)bdsCTPX[bdsCTPX.Position])[0] = txtMaPX.Text;
                        ((DataRowView)bdsCTPX[bdsCTPX.Position])[1] = txtMaVT.Text;
                        ((DataRowView)bdsCTPX[bdsCTPX.Position])[2] = numSL.Value;
                        ((DataRowView)bdsCTPX[bdsCTPX.Position])[3] = numDG.Value;
                        // Thực hiện việc ghi dữ liệu
                        this.bdsCTPX.EndEdit();
                        this.cTPXTableAdapter.Update(Program.frmPhieuXuat.getDataset().CTPX);
                        updateSuccess = true;
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
    }
}

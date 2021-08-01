using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLVT_DH.SubForm
{
    public partial class subFrmCTPN : Form
    {
        string statement;
        public subFrmCTPN()
        {
            InitializeComponent();
        }

        private void cTPNBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsCTPN.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);

        }

        private void subFrmCTPN_Load(object sender, EventArgs e)
        {
            DS.EnforceConstraints = false;

            // TODO: This line of code loads data into the 'dS.CTPN' table. You can move, or remove it, as needed.
            this.cTPNTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTPNTableAdapter.Fill(this.DS.CTPN);

            // TODO: This line of code loads data into the 'dS.DATHANG' table. You can move, or remove it, as needed.
            this.datHangTableAdapter.Connection.ConnectionString = Program.connstr;
            this.datHangTableAdapter.Fill(this.DS.DATHANG);
            // TODO: This line of code loads data into the 'DS.CTDDH' table. You can move, or remove it, as needed.
            this.cTDDHTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTDDHTableAdapter.Fill(this.DS.CTDDH);
            


            

            this.bdsCTPN.DataSource = Program.frmPhieuNhap.getBdsCTPN();
            this.bdsCTDDH.DataSource = Program.frmPhieuNhap.getbdsCTDDH();

            txtMaVT.Enabled = txtMaPN.Enabled = numDG.Enabled = false;
        }

        private string getDataRow(BindingSource bindingSource, string column)
        {
            return ((DataRowView)bindingSource[bindingSource.Position])[column].ToString().Trim();
        }

        private void gvVT_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            txtMaVT.Text = getDataRow(bdsCTDDH, "MAVT");
        }

        private void subFrmCTPN_Shown(object sender, EventArgs e)
        {
            BindingSource bdsPN = Program.frmPhieuNhap.getBdsPN();
            statement = Program.frmPhieuNhap.undolist.Pop().ToString();
            if (statement == "THEMCTPN")
            {
                this.bdsCTPN.AddNew();
                txtMaPN.Text = getDataRow(bdsPN, "MaPN");
                txtMaVT.Text = getDataRow(bdsCTDDH, "MAVT");
                numSL.Value = 1;
                numDG.Value = int.Parse(getDataRow(bdsCTDDH, "DONGIA"));
            }
            else
            {
                txtMaPN.Text = getDataRow(bdsPN, "MaPN");
                txtMaVT.Text = getDataRow(bdsCTDDH, "MAVT");
                numSL.Value = int.Parse(getDataRow(bdsCTPN, "SOLUONG"));
                numDG.Value = int.Parse(getDataRow(bdsCTDDH, "DONGIA"));
            }
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                int indexMaVT = bdsCTPN.Find("MAVT", txtMaVT.Text);
                if (indexMaVT != -1 && (indexMaVT != bdsCTPN.Position))
                {
                    MessageBox.Show("Đã tồn tại mã vật tư cùng với mã đơn hàng!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // lấy ra số lượng vật tư để kiểm tra
                int SLVT = int.Parse(getDataRow(bdsCTDDH, "SOLUONG"));
                if (numSL.Value > SLVT)
                {
                    MessageBox.Show("Số lượng phiếu nhập phải ít hơn số lượng của đơn đặt hàng!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DialogResult dr = MessageBox.Show("Bạn có chắc muốn ghi dữ liệu vào Database?", "Thông báo",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        ((DataRowView)bdsCTPN[bdsCTPN.Position])[0] = txtMaPN.Text;
                        ((DataRowView)bdsCTPN[bdsCTPN.Position])[1] = txtMaVT.Text;
                        ((DataRowView)bdsCTPN[bdsCTPN.Position])[2] = numSL.Value;
                        ((DataRowView)bdsCTPN[bdsCTPN.Position])[3] = numDG.Value;
                        // Thực hiện việc ghi dữ liệu
                        this.bdsCTPN.EndEdit();
                        this.cTPNTableAdapter.Update(Program.frmPhieuNhap.getDataset().CTPN);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ghi dữ liệu thất lại. Vui lòng kiểm tra lại!\n" + ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        // Lỗi thì phải cho AddNew, nếu không thì dữ liệu sẽ là dữ liệu của mẩu tin cuối
                        BindingSource bdsPX = Program.frmPhieuXuat.getBdsPX();
                        string MaPX = getDataRow(bdsPX, "MaPX");
                        txtMaPN.Text = MaPX;
                        this.bdsCTPN.AddNew();
                        txtMaVT.Text = getDataRow(bdsCTDDH, "MAVT");
                        numSL.Value = 1;
                        numDG.Value = 0;
                    }
                }
            }
        }

        private void gvCTDDH_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            txtMaVT.Text = getDataRow(bdsCTDDH, "MAVT");
            numDG.Value = int.Parse(getDataRow(bdsCTDDH, "DONGIA"));
        }

        private void subFrmCTPN_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(statement == "THEMCTPN")
            {
                bdsCTPN.CancelEdit();
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

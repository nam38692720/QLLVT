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
    public partial class subFrmCTDDH : Form
    {
        private bool updateSuccess = false;
        public subFrmCTDDH()
        {
            InitializeComponent();
        }

        private void vattuBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsVT.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);

        }
        private string getDataRow(BindingSource bindingSource, string column)
        {
            return ((DataRowView)bindingSource[bindingSource.Position])[column].ToString().Trim();
        }

        private void subFrmCTDDH_Load(object sender, EventArgs e)
        {
            DS.EnforceConstraints = false;

            // TODO: This line of code loads data into the 'dS.Vattu' table. You can move, or remove it, as needed.
            this.vattuTableAdapter.Connection.ConnectionString = Program.connstr;
            this.vattuTableAdapter.Fill(this.DS.Vattu);

            // TODO: This line of code loads data into the 'dS.CTDDH' table. You can move, or remove it, as needed.
            this.cTDDHTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTDDHTableAdapter.Fill(this.DS.CTDDH);

            this.bdsCTDDH.DataSource = Program.frmDonDatHang.getBdsCTDDH();

            txtMaVT.Enabled = txtMaDDH.Enabled = false;
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                int indexMaVT = bdsCTDDH.Find("MAVT", txtMaVT.Text);
                if (indexMaVT != -1 && (indexMaVT != bdsCTDDH.Position))
                {
                    MessageBox.Show("Đã tồn tại mã vật tư cùng với mã đơn hàng!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DialogResult dr = MessageBox.Show("Bạn có chắc muốn ghi dữ liệu vào Database?", "Thông báo",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        // Do là bds CTDDH đi theo bds DDH, nên phải giữ lại mã DDH để có thể tìm lại vị trí
                        // của mẩu tin mà mình vừa thực hiện thêm Chi tiết DDH, rồi sau đó mới thực hiện undo.
                        // Chứ nếu con trỏ không đứng đúng mẩu tin vừa mới thêm CTDDH, thì nó sẽ sai.

                        //string maDDH = ((DataRowView)bdsCTDDH[bdsCTDDH.Position])[0].ToString().Trim();
                        //string maVatTu = ((DataRowView)bdsCTDDH[bdsCTDDH.Position])[1].ToString().Trim();

                        // Thực hiện việc ghi dữ liệu
                        this.bdsCTDDH.EndEdit();
                        this.cTDDHTableAdapter.Update(Program.frmDonDatHang.getDataset().CTDDH);
                        updateSuccess = true;

                        //string data_backup = Program.frmDonDatHang.GHI_CTP_BTN + "#%" + maDDH + "#%" + maVatTu;
                        //Program.frmDonDatHang.historyDDH.Push(data_backup);
                        //Program.formLapPhieu.check_ctp = true;
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ghi dữ liệu thất lại. Vui lòng kiểm tra lại!\n" + ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        // Lỗi thì phải cho AddNew, nếu không thì dữ liệu sẽ là dữ liệu của mẩu tin cuối
                        BindingSource current_DDH = Program.frmDonDatHang.getBdsDDH();
                        string maSoDDH = getDataRow(current_DDH, "MasoDDH");
                        txtMaDDH.Text = maSoDDH;
                        this.bdsCTDDH.AddNew();
                        txtMaVT.Text = getDataRow(bdsVT, "MAVT");
                        numSL.Value = 1;
                        numDG.Value = 0;
                    }
                }
            }
        }

        private void subFrmCTDDH_Shown(object sender, EventArgs e)
        {
            this.bdsCTDDH.AddNew();

            BindingSource bdsDH = Program.frmDonDatHang.getBdsDDH();

            string maSoDDH = getDataRow(bdsDH, "MasoDDH");
            txtMaDDH.Text = maSoDDH;
            txtMaVT.Text = getDataRow(bdsVT, "MAVT");
            numSL.Value = 1;
            //numDG.Value = numDG.Minimum;
            numDG.Value = 0;
        }

        private void gvVT_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            txtMaVT.Text = getDataRow(bdsVT, "MAVT");
        }
    }
}

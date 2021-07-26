using QLVT_DH.SimpleForm;
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
    public partial class subFrmKho : Form
    {
        public subFrmKho()
        {
            InitializeComponent();
        }

        private void khoBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsKho.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);

        }

        private void subFrmKho_Load(object sender, EventArgs e)
        {

            // Không kiểm tra khóa ngoại
            dS.EnforceConstraints = false;

            // TODO: This line of code loads data into the 'dS.Kho' table. You can move, or remove it, as needed.
            this.khoTableAdapter.Connection.ConnectionString = Program.connstr;
            this.khoTableAdapter.Fill(this.dS.Kho);

        }
        private void btnKho_Click(object sender, EventArgs e)
        {
            String maKho = ((DataRowView)bdsKho.Current)["MAKHO"].ToString();
            
            var formDH = Application.OpenForms.OfType<frmDonDatHang>().FirstOrDefault();
            // do 2 form phiếu xuất và đơn đặt hàng dùng chung nên cần check form có tồn tại hay không để set textMaKho
            if (formDH != null)
            {
                Program.frmDonDatHang.txtMaKho.Text = maKho;//chọn mã kho cho đơn đặt hàng
            }
            
            var formPX = Application.OpenForms.OfType<frmPhieuXuat>().FirstOrDefault();
            if(formPX !=null)
            {
                Program.frmPhieuXuat.txtMaKho.Text = maKho;//chọn mã kho cho phiếu xuất
            }

            var formPN = Application.OpenForms.OfType<frmPhieuNhap>().FirstOrDefault();
            if (formPN != null)
            {
                Program.frmPhieuNhap.txtMaKho.Text = maKho;//chọn mã kho cho phiếu nhập
            }
            this.Close();
        }
    }
}

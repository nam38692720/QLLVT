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
    public partial class subFrmNV : Form
    {
        public subFrmNV()
        {
            InitializeComponent();
        }

        private void nHANVIENBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsNV.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);

        }

        private void subFrmNV_Load(object sender, EventArgs e)
        {

            DS.EnforceConstraints = false;

            // TODO: This line of code loads data into the 'dS.NHANVIEN' table. You can move, or remove it, as needed.
            this.nHANVIENTableAdapter.Connection.ConnectionString = Program.connstr;
            this.nHANVIENTableAdapter.Fill(this.DS.NHANVIEN);

            
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string MANV = ((DataRowView)bdsNV.Current)["MANV"].ToString();

            Program.FrmCreateAcc.txtMaNV.Text = MANV;

            this.Close();
        }
    }
}

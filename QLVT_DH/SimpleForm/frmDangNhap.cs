using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;

namespace QLVT_DH.SimpleForm
{
    public partial class frmDangNhap : DevExpress.XtraEditors.XtraForm
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLVTDataSet.V_DS_PHANMANH' table. You can move, or remove it, as needed.
            this.v_DS_PHANMANHTableAdapter.Fill(this.qLVTDataSet.V_DS_PHANMANH);
            cmbChiNhanh.SelectedIndex = 1;//để giả click
            cmbChiNhanh.SelectedIndex = 0;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtDangNhap.Text.Trim() == "")
            {
                MessageBox.Show("Tài khoản đăng nhập không được rỗng", "báo lỗi đăng nhập", MessageBoxButtons.OK);
                txtDangNhap.Focus();
                return;
            }
            Program.mlogin = txtDangNhap.Text;
            Program.password = txtPass.Text;
            if (Program.KetNoi() == 0) return;

            Program.mChiNhanh = cmbChiNhanh.SelectedIndex;
            SqlDataReader myReader;

            String strlenh = " exec SP_DANGNHAP '" + Program.mlogin + "'";
            myReader = Program.ExecSqlDataReader(strlenh);
            Program.bds_dspm = bds_DSPM;
            Program.mloginDN = Program.mlogin;
            Program.passwordDN = Program.password;
            if (myReader == null) return;
            myReader.Read();

            Program.username = myReader.GetString(0); // lay user name
            Program.maNV =int.Parse(Program.username);
            if (Convert.IsDBNull(Program.username))
            {
                MessageBox.Show("Login bạn không có quyền truy cập dữ liệu \n Bạn xem lại", " ", MessageBoxButtons.OK);
                return;
            }

            Program.mHoten = myReader.GetString(1);
            Program.mGroup = myReader.GetString(2);


            myReader.Close();
            Program.conn.Close();

            MessageBox.Show("Đăng nhập thành công", " ", MessageBoxButtons.OK);

            frmMain f = new frmMain();
            f.Show();

            this.Hide();
        }

        private void cmbChiNhanh_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cmbChiNhanh.SelectedIndex != -1) Program.servername = cmbChiNhanh.SelectedValue.ToString();
        }
    }
}
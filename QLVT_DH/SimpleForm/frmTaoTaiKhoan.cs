using QLVT_DH.SubForm;
using System;
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
    public partial class frmTaoTaiKhoan : Form
    {
        public frmTaoTaiKhoan()
        {
            InitializeComponent();
        }

        private void frnTaoTaiKhoan_Load(object sender, EventArgs e)
        {

            DS.EnforceConstraints = false;
            // TODO: This line of code loads data into the 'qLVTDataSet.V_DS_PHANMANH' table. You can move, or remove it, as needed.
            this.v_DS_PHANMANHTableAdapter.Fill(this.qLVTDataSet.V_DS_PHANMANH);

            // TODO: This line of code loads data into the 'dS.NHANVIEN' table. You can move, or remove it, as needed.
            this.nHANVIENTableAdapter.Connection.ConnectionString = Program.connstr;
            this.nHANVIENTableAdapter.Fill(this.DS.NHANVIEN);

            if (Program.mGroup == "CONGTY")
            {
                //this.label4.Visible = false;
                //this.radioButton_ChiNhanh.Visible = false;
                this.rbUser.Visible = false;
                this.rbCN.Text = "CÔNG TY";
                this.rbCN.Checked = true;
                this.cmbChiNhanh.Enabled = true;
            }
            else
            {
                this.cmbChiNhanh.Enabled = false;
                this.rbCN.Checked = true;
            }
            //txtMaNV1.Text = "";
            //txtMaNV.Enabled = false;
            //txtMaNV1.Text = "";
        }

        private void rbCN_CheckedChanged(object sender, EventArgs e)
        {
            if (Program.mGroup == "CONGTY")
            {
                rbCN.Checked = true;
            }
            else if (rbUser.Checked == true) rbUser.Checked = false;
        }

        private void rbUser_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCN.Checked == true) rbCN.Checked = false;
        }

        private void btnCreateAcc_Click(object sender, EventArgs e)
        {
            if(txtPassword.Text.Equals(txtRetype.Text))
            {
                String login = txtUsername.Text.Trim();
                String password = txtPassword.Text.Trim();
                //int username = (int)comboBox_NV.SelectedValue;
                int username = int.Parse(txtUsername.Text.Trim());
                String role = "";
                //if (comboBox_Role.SelectedIndex == 0) role = "CONGTY";
                //else if (comboBox_Role.SelectedIndex == 1) role = "CHINHANH";
                //else if (comboBox_Role.SelectedIndex == 2) role = "USER";
                if (Program.mGroup == "CONGTY") role = "CONGTY";
                else
                {
                    if (rbCN.Checked == true) role = "CHINHANH";
                    else if (rbUser.Checked == true) role = "USER";
                }
                Console.WriteLine(login + "  " + password + "   " + username + "    " + role);

                Program.conn = new SqlConnection(Program.connstr);
                Program.conn.Open();
                SqlCommand cmd = new SqlCommand("SP_TAOTAIKHOAN", Program.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@LGNAME", login));
                cmd.Parameters.Add(new SqlParameter("@PASS", password));
                cmd.Parameters.Add(new SqlParameter("@USERNAME", username));
                cmd.Parameters.Add(new SqlParameter("@ROLE", role));
                SqlDataReader myReader = null;
                //String strleng = "EXEC SP_TAOTAIKHOAN '" + login + "','"+password+"','"+username+"','"+role+"'";
                try
                {
                    myReader = cmd.ExecuteReader();
                    MessageBox.Show("Tạo tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SqlException)
                {
                    //MessageBox.Show(e.Message);
                }
            }
            else
            {
                MessageBox.Show("Mật khẩu nhập lại không trùng!\nVui lòng nhập lại!\n", "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGridNV_Click(object sender, EventArgs e)
        {
            Program.subFrmNV = new subFrmNV();
            Program.subFrmNV.Show();
        }
    }
}

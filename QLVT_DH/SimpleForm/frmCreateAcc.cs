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
    public partial class frmCreateAcc : Form
    {
        public frmCreateAcc()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.subFrmNV = new subFrmNV();
            Program.subFrmNV.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            // TODO: This line of code loads data into the 'qLVTDataSet.V_DS_PHANMANH' table. You can move, or remove it, as needed.
            this.v_DS_PHANMANHTableAdapter.Fill(this.qLVTDataSet.V_DS_PHANMANH);


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

            txtMaNV.Enabled = false;
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
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                if (txtPassword.Text.Equals(txtRetype.Text))
                {
                    String login = txtUsername.Text.Trim();
                    String password = txtPassword.Text.Trim();
                    //int username = (int)comboBox_NV.SelectedValue;
                    int username = int.Parse(txtMaNV.Text.Trim());
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

                    if (Program.KetNoi() == 0) return;
                    // == Query tìm MaKho ==
                    String query_Create_Acc = "DECLARE	@return_value int " +
                                   "EXEC	@return_value = [dbo].[SP_TAOACCOUNT] " +
                                   "@LGNAME, @PASS, @USERNAME, @ROLE " +
                                   "SELECT 'Return Value' = @return_value";
                    SqlCommand sqlCommand = new SqlCommand(query_Create_Acc, Program.conn);
                    sqlCommand.Parameters.AddWithValue("@LGNAME", login);
                    sqlCommand.Parameters.AddWithValue("@PASS", password);
                    sqlCommand.Parameters.AddWithValue("@USERNAME", username);
                    sqlCommand.Parameters.AddWithValue("@ROLE", role);
                    SqlDataReader dataReader = null;

                    try
                    {
                        dataReader = sqlCommand.ExecuteReader();
                        MessageBox.Show("Tạo tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Thực thi database thất bại!\n" + ex.Message, "Thông báo",
                             MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Mật khẩu nhập lại không trùng!\nVui lòng nhập lại!\n", "Lỗi",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtMaNV_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNV.Text))
            {
                e.Cancel = true;
                txtMaNV.Focus();
                errorProvider1.SetError(txtMaNV, "Mã nhân viên không được để trống!");
            }
            else if (txtMaNV.Text.Trim().Contains(" "))
            {
                e.Cancel = true;
                txtMaNV.Focus();
                errorProvider1.SetError(txtMaNV, "Mã nhân viên không được chứa khoảng trắng!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtMaNV, "");
            }
        }

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                e.Cancel = true;
                txtUsername.Focus();
                errorProvider1.SetError(txtUsername, "UserName Không được để trống!");
            }
            else if (txtUsername.Text.Trim().Contains(" "))
            {
                e.Cancel = true;
                txtUsername.Focus();
                errorProvider1.SetError(txtUsername, "UserName không được chứa khoảng trắng!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtUsername, "");
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                e.Cancel = true;
                txtPassword.Focus();
                errorProvider1.SetError(txtPassword, "Password Không được để trống!");
            }
            else if (txtPassword.Text.Trim().Contains(" "))
            {
                e.Cancel = true;
                txtPassword.Focus();
                errorProvider1.SetError(txtPassword, "Password không được chứa khoảng trắng!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPassword, "");
            }
        }

        private void txtRetype_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRetype.Text))
            {
                e.Cancel = true;
                txtRetype.Focus();
                errorProvider1.SetError(txtRetype, "Mật khẩu nhập lại Không được để trống!");
            }
            else if (txtRetype.Text.Trim().Contains(" "))
            {
                e.Cancel = true;
                txtRetype.Focus();
                errorProvider1.SetError(txtRetype, "Mật khẩu nhập lại không được chứa khoảng trắng!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtRetype, "");
            }
        }
    }
}

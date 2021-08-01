using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLVT_DH.Reports
{
    public partial class frmSupportCommon : Form
    {
        private int choice;
        public frmSupportCommon(int choice)
        {
            InitializeComponent();
            if ((choice == 4) || (choice == 1) || (choice == 6))
            {
                if (Program.mGroup != "CONGTY")
                {
                    cmbChiNhanh.Visible = false;
                    lbChiNhanh.Visible = false;
                }
            }
            else
            {
                cmbChiNhanh.Enabled = false;
                cmbChiNhanh.Visible = false;
                lbChiNhanh.Enabled = false;
                lbChiNhanh.Visible = false;
            }
            this.choice = choice;
        }

        private void frmSupportCommon_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLVTDataSet.V_DS_PHANMANH' table. You can move, or remove it, as needed.
            this.v_DS_PHANMANHTableAdapter.Fill(this.qLVTDataSet.V_DS_PHANMANH);

        }

        private void v_DS_PHANMANHComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbChiNhanh.SelectedValue.ToString() == "System.Data.DataRowView") return;

            // Lấy tên server
            Program.servername = cmbChiNhanh.SelectedValue.ToString();

            // Nếu tên server khác với tên server ngoài đăng nhập, thì ta phải sử dụng HTKN
            if (cmbChiNhanh.SelectedIndex != Program.mChiNhanh)
            {
                Program.mlogin = Program.remotelogin;
                Program.password = Program.remotepassword;
            }
            else
            {
                Program.mlogin = Program.mloginDN;
                Program.password = Program.passwordDN;
            }

            if (Program.KetNoi() == 0)
                MessageBox.Show("Lỗi kết nối về chi nhánh mới", "", MessageBoxButtons.OK);
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if(choice == 1)
            {
                xtrp_DSNV report = new xtrp_DSNV();
                ReportPrintTool printTool = new ReportPrintTool(report);
                printTool.ShowPreviewDialog();
            }
            else if(choice == 4)
            {
                xtrp_DDH_ChuaCo_PN report_DSkhongPN = new xtrp_DDH_ChuaCo_PN();
                ReportPrintTool printTool_DSkhongPN = new ReportPrintTool(report_DSkhongPN);
                printTool_DSkhongPN.ShowPreviewDialog();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if(choice == 1)
            {
                xtrp_DSNV report_DSNV = new xtrp_DSNV();
                try
                {
                    if (File.Exists(@"D:\Reports\ReportDSNhanVien.pdf"))
                    {
                        DialogResult dr = MessageBox.Show("File ReportDSNhanVien.pdf tại ổ D đã có!\nBạn có muốn ghi đè?",
                            "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dr == DialogResult.Yes)
                        {
                            report_DSNV.ExportToPdf(@"D:\Reports\ReportDSNhanVien.pdf");
                            MessageBox.Show("File ReportDSNhanVien.pdf đã được ghi thành công tại ổ D",
                    "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                    else
                    {
                        report_DSNV.ExportToPdf(@"D:\Reports\ReportDSNhanVien.pdf");
                        MessageBox.Show("File ReportDSNhanVien.pdf đã được ghi thành công tại ổ D",
                    "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (IOException ex)
                {
                    MessageBox.Show("Vui lòng đóng file ReportDSNhanVien.pdf",
                        "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }
            }
            else if(choice == 4)
            {
                xtrp_DDH_ChuaCo_PN report_DH = new xtrp_DDH_ChuaCo_PN();
                try
                {
                    if (File.Exists(@"D:\Reports\ReportDHChuaCoPN.pdf"))
                    {
                        DialogResult dr = MessageBox.Show("File ReportDHChuaCoPN.pdf tại ổ D đã có!\nBạn có muốn ghi đè?",
                            "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dr == DialogResult.Yes)
                        {
                            report_DH.ExportToPdf(@"D:\Reports\ReportDHChuaCoPN.pdf");
                            MessageBox.Show("File ReportDH.pdf đã được ghi thành công tại ổ D",
                    "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        report_DH.ExportToPdf(@"D:\Reports\ReportDHChuaCoPN.pdf");
                        MessageBox.Show("File ReportDH.pdf đã được ghi thành công tại ổ D",
                    "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (IOException ex)
                {
                    MessageBox.Show("Vui lòng đóng file ReportDHChuaCoPN.pdf",
                        "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }
            }
        }
    }
}

using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLVT_DH.Reports
{
    public partial class frmSupport_THNX : Form
    {
        public frmSupport_THNX()
        {
            InitializeComponent();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            xtrp_REPORTTonghopNhapXuat_NV report_TonghopNhapXuat = new xtrp_REPORTTonghopNhapXuat_NV(dateEditStart.DateTime, dateEditEnd.DateTime);
            ReportPrintTool printTool_TonghopNhapXuat = new ReportPrintTool(report_TonghopNhapXuat);
            printTool_TonghopNhapXuat.ShowPreviewDialog();
        }

        private void frmSupport_THNX_Load(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace QLVT_DH.Reports
{
    public partial class xtrp_DDH_ChuaCo_PN : DevExpress.XtraReports.UI.XtraReport
    {
        public xtrp_DDH_ChuaCo_PN()
        {
            InitializeComponent();
            this.sqlDataSource1.Connection.ConnectionString = Program.connstr;
            this.sqlDataSource1.Fill();
        }

    }
}

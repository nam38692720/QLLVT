using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace QLVT_DH
{
    public partial class XtraReport1 : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport1()
        {
            InitializeComponent();

            qLVTDataSet1.EnforceConstraints = false;

            this.sP_RP_DSVATTUTableAdapter.Connection.ConnectionString = Program.connstr;
            this.sP_RP_DSVATTUTableAdapter.Fill(this.qLVTDataSet1.SP_RP_DSVATTU);

        }

    }
}

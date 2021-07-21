﻿using System;
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
    public partial class frmChuyenCN : Form
    {
        public frmChuyenCN()
        {
            InitializeComponent();
        }

        private void frmChuyenCN_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLVTDataSet.V_DS_PHANMANH' table. You can move, or remove it, as needed.
            this.v_DS_PHANMANHTableAdapter.Fill(this.qLVTDataSet.V_DS_PHANMANH);

            if (bds_dspm.Count == 3) bds_dspm.RemoveAt(2);
        }

        public delegate void GETDATA(String index);
        public GETDATA mydata;
       

        private void btnChuyenCN_Click(object sender, EventArgs e)
        {
            mydata(cmbChiNhanh.SelectedValue.ToString());

            this.Close();
        }
    }
}

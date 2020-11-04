using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FORM
{
    public partial class FRM_WS_OUT_BY_TRIP : Form
    {
        public FRM_WS_OUT_BY_TRIP()
        {
            InitializeComponent();
        }
        public void BindingData(DataTable dt)
        {
            try
            {
                lblTrip1.Text = "0 PRS";
                lblTrip2.Text = "0 PRS";
                lblTrip3.Text = "0 PRS";
                lblTrip4.Text = "0 PRS";
                if (dt!= null && dt.Rows.Count> 0)
                {
                    lblTrip1.Text = string.Concat(string.Format("{0:n0}", dt.Rows[0][0].ToString()), " PRS");
                    lblTrip2.Text = string.Concat(string.Format("{0:n0}", dt.Rows[1][0].ToString()), " PRS");
                    lblTrip3.Text = string.Concat(string.Format("{0:n0}", dt.Rows[2][0].ToString()), " PRS");
                    lblTrip4.Text = string.Concat(string.Format("{0:n0}", dt.Rows[3][0].ToString()), " PRS");
                }
            }
            catch
            {

            }
        }
    }
}

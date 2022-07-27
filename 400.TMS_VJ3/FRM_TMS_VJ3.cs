using DevExpress.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace FORM
{
    public partial class FRM_TMS_VJ3 : Form
    {
        public FRM_TMS_VJ3()
        {

            InitializeComponent();
            lblVersion.Text = "2022.07.20.1";
            CheckForIllegalCrossThreadCalls = false;//tránh việc đụng độ khi sử dụng tài nguyên giữa các thread

        }
        int iUpdateCar = 0;
        public delegate void InvokeDelegate();
        int Car1_XStart = 659, Car1_Yoriginal = 40, Car1_XEnd = 338,
           Car2_XStart = 1233, Car2_Yoriginal = 40, Car2_XEnd = 1500;
        int XCar1 = 659, XCar2 = 1233; //Di chuyen X khong di chuyen Y.

        #region DB
        private DataTable SELECT_TMS_DATA(string ARG_PROC_NAME, string ARG_QTYPE, string ARG_DATE)
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                MyOraDB.ConnectName = COM.OraDB.ConnectDB.LMES;
                System.Data.DataSet ds_ret;

                string process_name = string.Format("PKG_TMS_TANPHU.{0}", ARG_PROC_NAME);
                MyOraDB.ReDim_Parameter(3);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "ARG_QTYPE";
                MyOraDB.Parameter_Name[1] = "ARG_DATE";
                MyOraDB.Parameter_Name[2] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (char)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ARG_QTYPE;
                MyOraDB.Parameter_Values[1] = ARG_DATE;
                MyOraDB.Parameter_Values[2] = "";

                MyOraDB.Add_Select_Parameter(true);
                ds_ret = MyOraDB.Exe_Select_Procedure();

                if (ds_ret == null) return null;
                return ds_ret.Tables[0];
            }
            catch
            {
                return null;
            }
        }
        private DataTable SELECT_TMS_SET_DATA(string ARG_PROC_NAME, string ARG_QTYPE,string ARG_PLANT_CD, string ARG_DATE)
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                MyOraDB.ConnectName = COM.OraDB.ConnectDB.LMES;
                System.Data.DataSet ds_ret;

                string process_name = string.Format("PKG_TMS_TANPHU.{0}", ARG_PROC_NAME);
                MyOraDB.ReDim_Parameter(4);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "ARG_QTYPE";
                MyOraDB.Parameter_Name[1] = "ARG_PLANT_CD";
                MyOraDB.Parameter_Name[2] = "ARG_DATE";
                MyOraDB.Parameter_Name[3] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (char)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ARG_QTYPE;
                MyOraDB.Parameter_Values[1] = ARG_PLANT_CD;
                MyOraDB.Parameter_Values[2] = ARG_DATE;
                MyOraDB.Parameter_Values[3] = "";

                MyOraDB.Add_Select_Parameter(true);
                ds_ret = MyOraDB.Exe_Select_Procedure();

                if (ds_ret == null) return null;
                return ds_ret.Tables[0];
            }
            catch
            {
                return null;
            }
        }

        private DataTable SELECT_TMS_BOTTOM_OUTGOING(string ARG_PROC_NAME, string ARG_QTYPE, string ARG_DATE, string ARG_PLANT_CD)
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                MyOraDB.ConnectName = COM.OraDB.ConnectDB.LMES;
                System.Data.DataSet ds_ret;

                string process_name = string.Format("PKG_TMS_LONGTHANH.{0}", ARG_PROC_NAME);
                MyOraDB.ReDim_Parameter(4);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "ARG_QTYPE";
                MyOraDB.Parameter_Name[1] = "ARG_DATE";
                MyOraDB.Parameter_Name[2] = "ARG_PLANT_CD";
                MyOraDB.Parameter_Name[3] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (char)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ARG_QTYPE;
                MyOraDB.Parameter_Values[1] = ARG_DATE;
                MyOraDB.Parameter_Values[2] = ARG_PLANT_CD;
                MyOraDB.Parameter_Values[3] = "";

                MyOraDB.Add_Select_Parameter(true);
                ds_ret = MyOraDB.Exe_Select_Procedure();

                if (ds_ret == null) return null;
                return ds_ret.Tables[0];
            }
            catch
            {
                return null;
            }
        }
        #endregion

        private void FRM_TMS_VJ3_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                iUpdateCar = 60;
                BindingData();
            }
        }

        private void BindingData()
        {
            BindingCarTripWithOutQty();
            BindingOutgoingQtyByAssDate();
            BindingUpperOutgoingGrid();
            BindingUpperFSTotal("2110");
            BindingUpperFSTotal("2120");
            // BindingUpperFSGrid();

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "Minimized";
        }

        private void lblDate_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BindingCarTripWithOutQty()
        {
            try
            {
                DataTable dt = SELECT_TMS_DATA("SELECT_CAR_TRIP_WITH_OQTY", "", ""); //Get Car Depart & Arrival Time
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (dt.Select("GATE_DPT = 'VJ3' AND GATE_ARR = 'VJ1_NEW' AND ORD_TRIP = 1").Count() > 0)
                    {
                        DataTable dtTmp = dt.Select("GATE_DPT = 'VJ3' AND GATE_ARR = 'VJ1_NEW' AND ORD_TRIP = 1").CopyToDataTable();
                        lblVJ3_VJ1_ARR_Trip1.Text = dtTmp.Rows[0]["ARR_HMS"].ToString();
                        lblVJ3_VJ1_DPT_Trip1.Text =string.Concat( dtTmp.Rows[0]["DPT_HMS"].ToString()," (",string.Format("{0:n0}", dtTmp.Rows[0]["O_QTY"])," Prs)");
                    }

                    if (dt.Select("GATE_DPT = 'VJ3' AND GATE_ARR = 'VJ2_LE' AND ORD_TRIP = 1").Count() > 0)
                    {
                        DataTable dtTmp = dt.Select("GATE_DPT = 'VJ3' AND GATE_ARR = 'VJ2_LE' AND ORD_TRIP = 1").CopyToDataTable();
                        lblVJ3_VJ2_ARR_Trip1.Text = dtTmp.Rows[0]["ARR_HMS"].ToString();
                        lblVJ3_VJ2_DPT_Trip1.Text = string.Concat(dtTmp.Rows[0]["DPT_HMS"].ToString(), " (", string.Format("{0:n0}", dtTmp.Rows[0]["O_QTY"]), " Prs)");
                    }

                    if (dt.Select("GATE_DPT = 'VJ3' AND GATE_ARR = 'VJ2_LE' AND ORD_TRIP = 2").Count() > 0)
                    {
                        DataTable dtTmp = dt.Select("GATE_DPT = 'VJ3' AND GATE_ARR = 'VJ2_LE' AND ORD_TRIP = 2").CopyToDataTable();
                        lblVJ3_VJ2_ARR_Trip2.Text = dtTmp.Rows[0]["ARR_HMS"].ToString();
                        lblVJ3_VJ2_DPT_Trip2.Text = string.Concat(dtTmp.Rows[0]["DPT_HMS"].ToString(), " (", string.Format("{0:n0}", dtTmp.Rows[0]["O_QTY"]), " Prs)");
                    }
                }
            }
            catch
            {
              
            }
            
        }
        private void BindingOutgoingQtyByAssDate()
        {
            try
            {
                ClearControls();
                DataTable dt = SELECT_TMS_DATA("SELECT_OUTGOING_BY_ASY_DATE", "", ""); //Get Outgoing Quantity by Assembly Date
                if (dt != null && dt.Rows.Count > 1)
                {
                    if (dt.Select("FA_PLANT_CD = '2110'").Count() > 0)
                    {
                        DataTable dtTemp = dt.Select("FA_PLANT_CD = '2110'").CopyToDataTable();
                        lb_total.Text = string.Format("{0:n0}", dtTemp.Rows[0]["TOTAL"]);
                        lb_DD.Text = string.Format("{0:n0}", dtTemp.Rows[0]["DD"]);
                        lb_D1.Text = string.Format("{0:n0}", dtTemp.Rows[0]["D1"]);
                        lb_D2.Text = string.Format("{0:n0}", dtTemp.Rows[0]["D2"]);
                        lb_D3.Text = string.Format("{0:n0}", dtTemp.Rows[0]["D3"]);
                    }

                    if (dt.Select("FA_PLANT_CD = '2120'").Count() > 0)
                    {
                        DataTable dtTemp = dt.Select("FA_PLANT_CD = '2120'").CopyToDataTable();
                        lb_total2.Text = string.Format("{0:n0}", dtTemp.Rows[0]["TOTAL"]);
                        lb_DD_2.Text = string.Format("{0:n0}", dtTemp.Rows[0]["DD"]);
                        lb_D1_2.Text = string.Format("{0:n0}", dtTemp.Rows[0]["D1"]);
                        lb_D2_2.Text = string.Format("{0:n0}", dtTemp.Rows[0]["D2"]);
                        lb_D3_2.Text = string.Format("{0:n0}", dtTemp.Rows[0]["D3"]);
                    }
                }
            }
            catch
            {

            }
        }
        private void BindingOutgoingCarTime()
        {
            try
            {
                DataTable dt = SELECT_TMS_DATA("SELECT_CAR_TRIP_TIME", "", ""); //Get Car Depart & Arrival Time
                lblTimeLapseVJ3_VJ1.Text = lblTimeLapseVJ3_VJ2.Text = "Not Yet Depart";
                if (dt != null && dt.Rows.Count > 0)
                {

                    if (dt.Select("GATE_DPT = 'VJ3' AND GATE_ARR = 'VJ1_NEW'").Count() > 0)
                    {
                        DataTable dtTmp = dt.Select("GATE_DPT = 'VJ3' AND GATE_ARR = 'VJ1_NEW'").CopyToDataTable();
                        lblBT_Current_Qty.Text = string.Concat("Upper Current Trip: ", string.Format("{0:n0}", dtTmp.Rows[0]["QTY"]), " Prs");
                        if (string.IsNullOrEmpty(dtTmp.Rows[0]["ARR_HMS"].ToString()))
                        {
                            int EndlapseMinutes = 180;
                            XCar1 = Car1_XStart - Convert.ToInt32(dtTmp.Rows[0]["DPT_MIN"]) * 2;
                            lblTimeLapseVJ3_VJ1.Text = "Remain: " + ((EndlapseMinutes - Convert.ToInt32(dtTmp.Rows[0]["DPT_MIN"]))<=0?0: (EndlapseMinutes - Convert.ToInt32(dtTmp.Rows[0]["DPT_MIN"]))) + " Minutes";
                            btnCar.Location = new Point(XCar1 < Car1_XEnd ? Car1_XEnd : XCar1, Car1_Yoriginal);
                           
                        }
                        else
                        {
                            lblTimeLapseVJ3_VJ1.Text = "Arrival Already!";
                            btnCar.Location = new Point(Car1_XEnd, Car1_Yoriginal);
                            lblBT_Current_Qty.Text = "";
                        }
                    }
                }

                if (dt != null && dt.Rows.Count > 0)
                {
                    if (dt.Select("GATE_DPT = 'VJ3' AND GATE_ARR = 'VJ2_LE'").Count() > 0)
                    {
                        DataTable dtTmp = dt.Select("GATE_DPT = 'VJ3' AND GATE_ARR = 'VJ2_LE'").CopyToDataTable();
                        lblUpper_Current_Qty.Text = string.Concat("Upper Current Trip: ", string.Format("{0:n0}", dtTmp.Rows[0]["QTY"]), " Prs");
                        if (string.IsNullOrEmpty(dtTmp.Rows[0]["ARR_HMS"].ToString()))
                        {
                            int EndlapseMinutes = 60;
                            XCar2 = Car2_XStart + Convert.ToInt32(dtTmp.Rows[0]["DPT_MIN"]) * 5;
                            lblTimeLapseVJ3_VJ2.Text = "Remain: " + ((EndlapseMinutes - Convert.ToInt32(dtTmp.Rows[0]["DPT_MIN"])) <= 0 ? 0 : (EndlapseMinutes - Convert.ToInt32(dtTmp.Rows[0]["DPT_MIN"]))) + " Minutes";
                            btnCar2.Location = new Point(XCar2 > Car2_XEnd ? Car2_XEnd : XCar2, Car2_Yoriginal);
                        }
                        else
                        {
                            lblTimeLapseVJ3_VJ2.Text = "Arrival Already!";
                            btnCar2.Location = new Point(Car2_XEnd,Car2_Yoriginal);
                            lblUpper_Current_Qty.Text = " ";
                        }
                    }
                }
            }
            catch
            {


            }
        }

        private void btnCar_Click(object sender, EventArgs e)
        {
            FRM_VJ3_VJ1_MAPS maps = new FRM_VJ3_VJ1_MAPS();
            maps.ShowDialog();
        }

        private void btnCar2_Click(object sender, EventArgs e)
        {
            FRM_VJ3_VJ2_MAPS maps = new FRM_VJ3_VJ2_MAPS();
            maps.ShowDialog();
        }

        private void btnS_VJ3VJ1_Time_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "402";
            ComVar.Var._strValue1 = "2110";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "402";
            ComVar.Var._strValue1 = "2120";
        }

        private void lblVJ3_VJ2_DPT_Trip2_Click(object sender, EventArgs e)
        {

        }

        private void lblVJ3_VJ2_DPT_Trip1_Click(object sender, EventArgs e)
        {

        }

        private void btnVJ3VJ1Set_Click(object sender, EventArgs e)
        {
            BindingUpperFSGrid("2110");
            flyoutPanel1.OptionsButtonPanel.Buttons[1].Properties.Caption = "Upper & Finish sole Set Tân Phú - Vĩnh Cửu";
            flyoutPanel1.ShowPopup();
        }

        private void btnVJ3VJ2Set_Click(object sender, EventArgs e)
        {
            BindingUpperFSGrid("2120");
            flyoutPanel1.OptionsButtonPanel.Buttons[1].Properties.Caption = "Upper & Finish sole Set Tân Phú - Long Thành";
            flyoutPanel1.ShowPopup();
        }

        private void flyoutPanel1_ButtonClick(object sender, DevExpress.Utils.FlyoutPanelButtonClickEventArgs e)
        {
            string tag = e.Button.Tag.ToString();
            switch (tag)
            {
                case "close":
                    (sender as FlyoutPanel).HidePopup();
                    break;
                
            }
        }

        private void ClearControls()
        {
            lb_total.Text = "";
            lb_DD.Text = "";
            lb_D1.Text = "";
            lb_D2.Text = "";
            lb_D3.Text = "";

            lb_total2.Text = "";
            lb_DD_2.Text = "";
            lb_D1_2.Text = "";
            lb_D2_2.Text = "";
            lb_D3_2.Text = "";
        }

        private void gvwUpperFS_Set_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                string ItemClassVal = gvwUpperFS_Set.GetRowCellValue(e.RowHandle, gvwUpperFS_Set.Columns["ITEM_CLASS"]).ToString();
                if (e.Column.FieldName.Equals("ITEM_CLASS") || e.Column.FieldName.Equals("QTY"))
                {
                    if (ItemClassVal.Equals("Assembly Set"))
                    {
                        e.Appearance.BackColor = Color.FromArgb(40, 95, 158);
                        e.Appearance.ForeColor = Color.Yellow;
                    }
                }
            }
            catch
            {

            }
        }

        private void BindingUpperOutgoingGrid()
        {
            try
            {
                DataTable dt = SELECT_TMS_DATA("SELECT_OUTGOING_LIST", "", "");
                if (dt != null && dt.Rows.Count > 1)
                {
                    if (dt.Select("FA_PLANT_CD = '2110' AND FA_WC_CD IS NOT NULL").Count() > 0)
                    {
                        DataTable dtTemp = dt.Select("FA_PLANT_CD = '2110' AND FA_WC_CD IS NOT NULL","FA_WC_CD,ERP_FA_WC_CD").CopyToDataTable();
                        grdUpperVJ1.DataSource = dtTemp;
                    }
                    if (dt.Select("FA_PLANT_CD = '2120' AND FA_WC_CD IS NOT NULL").Count() > 0)
                    {
                        DataTable dtTemp = dt.Select("FA_PLANT_CD = '2120'  AND FA_WC_CD IS NOT NULL", "FA_WC_CD,ERP_FA_WC_CD").CopyToDataTable();
                        grdUpperVJ2.DataSource = dtTemp;
                    }
                }
            }
            catch
            {

            }
        }
        private void BindingUpperFSGrid(string ARG_PLANT_CD)
        {
            try
            {
                DataTable dt = SELECT_TMS_SET_DATA("SELECT_OUTGOING_SET_FSS_LIST", "", ARG_PLANT_CD, "");
                    if (dt != null && dt.Rows.Count > 1)
                {
                    var average = dt.AsEnumerable().Average(x => x.Field<decimal>("SET_RATIO"));
                    switch (ARG_PLANT_CD)
                    {
                        case "2110":
                            btnVJ3VJ1Set.Text = "Set Ratio: " + Math.Round(average, 1) + "%";
                            break;
                        case "2120":
                            btnVJ3VJ2Set.Text = "Set Ratio: " + Math.Round(average, 1) + "%";
                            break;
                    }
                    grdUpperFS_Set.DataSource = dt;
                    //if (dt.Select("FA_PLANT_CD = '2110'").Count() > 0)
                    //{
                    //    DataTable dtTemp = dt.Select("FA_PLANT_CD = '2110'", "FA_WC_CD,ERP_FA_WC_CD").CopyToDataTable();
                    //    var average = dtTemp.AsEnumerable().Average(x => x.Field<decimal>("SET_RATIO"));
                    //    tabPane1.Pages[1].Caption = btnVJ3VJ1Set.Text = "Upper & Finish Sole Set (Ratio: " + Math.Round(average, 1) + "%)";
                    //    grdUpperFS_VJ1.DataSource = dtTemp;
                    //}
                    //if (dt.Select("FA_PLANT_CD = '2120'").Count() > 0)
                    //{
                    //    DataTable dtTemp = dt.Select("FA_PLANT_CD = '2120'", "FA_WC_CD,ERP_FA_WC_CD").CopyToDataTable();
                    //    var average = dtTemp.AsEnumerable().Average(x => x.Field<decimal>("SET_RATIO"));
                    //    tabPane2.Pages[1].Caption = btnVJ3VJ2Set.Text =  "Upper & Finish Sole Set (Ratio: " + Math.Round(average, 1) + "%)";

                    //    grdUpperFSVJ2.DataSource = dtTemp;
                    //}
                }
            }
            catch(Exception ex)
            {

            }
        }


        private void BindingUpperFSTotal(string ARG_PLANT_CD)
        {
            try
            {
                DataTable dt = SELECT_TMS_SET_DATA("SELECT_OUTGOING_SET_FSS_LIST", "", ARG_PLANT_CD, "");
                if (dt != null && dt.Rows.Count > 1)
                {
                    var average = dt.AsEnumerable().Average(x => x.Field<decimal>("SET_RATIO"));
                    switch (ARG_PLANT_CD)
                    {
                        case "2110":
                            btnVJ3VJ1Set.Text = "Set Ratio: " + Math.Round(average, 1) + "%";
                            flyoutPanel1.OptionsButtonPanel.Buttons[1].Properties.Caption = "Vĩnh Cửu";
                            break;
                        case "2120":
                            btnVJ3VJ2Set.Text = "Set Ratio: " + Math.Round(average, 1) + "%";
                            flyoutPanel1.OptionsButtonPanel.Buttons[1].Properties.Caption = "Long Thành";
                            break;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void tmrCarRun_Tick(object sender, EventArgs e)
        {
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));
            iUpdateCar++;
            if (iUpdateCar >= 60)
            {
                iUpdateCar = 0;
                BindingOutgoingCarTime();

                //Thread t = new Thread(() =>
                // {
                //     btnCar.BeginInvoke(new InvokeDelegate(Xe1Chay));
                //     btnCar2.BeginInvoke(new InvokeDelegate(Xe2Chay));
                // });
                //t.IsBackground = true;
                //t.Start();
            }
        }

        public void Xe1Chay()
        {
            if (XCar1 < Car1_XEnd)
                XCar1 = Car1_XStart;

            btnCar.Location = new Point(XCar1, Car1_Yoriginal);
            btnCar.Text = XCar1.ToString();
        }

        public void Xe2Chay()
        {
            if (XCar2 > Car2_XEnd)
                XCar2 = Car2_XStart;
            btnCar2.Location = new Point(XCar2, Car2_Yoriginal);
            btnCar2.Text = XCar2.ToString();
        }


    }
}

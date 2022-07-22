using DevExpress.Utils;
using DevExpress.XtraCharts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FORM
{
    public partial class FRM_DELI_STATUS_V6_DETAIL : Form
    {
        public FRM_DELI_STATUS_V6_DETAIL()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;//tránh việc đụng độ khi sử dụng tài nguyên giữa các thread
            tmrDate.Stop();
            tmrAnimation.Stop();
        }
        #region Variable
        int cCount = 0, cAnimated = 0;
        Random r = new Random();
        #endregion
        #region DB
        private DataSet SELECT_TMS_DATA(string ARG_PROC_NAME, string ARG_QTYPE, string ARG_DATE,string ARG_PLANT_CD)
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                MyOraDB.ConnectName = COM.OraDB.ConnectDB.LMES;
                System.Data.DataSet ds_ret;

                string process_name = string.Format("PKG_TMS_TANPHU.{0}", ARG_PROC_NAME);
                MyOraDB.ReDim_Parameter(7);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "ARG_QTYPE";
                MyOraDB.Parameter_Name[1] = "ARG_DATE";
                MyOraDB.Parameter_Name[2] = "ARG_PLANT_CD";
                MyOraDB.Parameter_Name[3] = "OUT_CURSOR1";
                MyOraDB.Parameter_Name[4] = "OUT_CURSOR2";
                MyOraDB.Parameter_Name[5] = "OUT_CURSOR3";
                MyOraDB.Parameter_Name[6] = "OUT_CURSOR4";

                MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (char)OracleType.Cursor;
                MyOraDB.Parameter_Type[4] = (char)OracleType.Cursor;
                MyOraDB.Parameter_Type[5] = (char)OracleType.Cursor;
                MyOraDB.Parameter_Type[6] = (char)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ARG_QTYPE;
                MyOraDB.Parameter_Values[1] = ARG_DATE;
                MyOraDB.Parameter_Values[2] = ARG_PLANT_CD;
                MyOraDB.Parameter_Values[3] = "";
                MyOraDB.Parameter_Values[4] = "";
                MyOraDB.Parameter_Values[5] = "";
                MyOraDB.Parameter_Values[6] = "";

                MyOraDB.Add_Select_Parameter(true);
                ds_ret = MyOraDB.Exe_Select_Procedure();

                if (ds_ret == null) return null;
                return ds_ret;
            }
            catch
            {
                return null;
            }
        }
        #endregion
        private void BindingLabelRData(Label lbl, int min, int max)
        {
            lbl.Text = string.Format("{0:n0}", r.Next(min, max));
        }

        private async Task BindingData4Chart(string Qtype)
        {
            try
            {
                splashScreenManager1.ShowWaitForm();
                lblOutgoing.Text = "OUTGOING TODAY";
                lblPlan.Text = "TOTAL PLAN";
                lblInventory.Text = "INVENTORY";
                lblShortage.Text = "SHORTAGE";
               
                    DataSet ds = SELECT_TMS_DATA("SELECT_UPPER_STATUS","", "", ComVar.Var._strValue1);


                //switch (Qtype)
                //{
                //    case "INVENTORY":
                //        lblInventory_Total.Text = "0";
                //        int InvQty = 0;
                //        if (dt.Rows.Count > 0)
                //        {
                //            foreach (DataRow dr in dt.Rows)
                //            {
                //                InvQty += Convert.ToInt32(dr["WIP_QTY"]);
                //            }
                //            lblInventory_Total.Text = string.Format("{0:n0}", InvQty);
                //        }
                        
                //        chartINV.DataSource = dt;
                //        chartINV.Series[0].ArgumentDataMember = "LINE_NM";
                //        chartINV.Series[0].ValueDataMembers.AddRange(new string[] { "WIP_QTY" });
                //        chartINV.Titles[0].Text = "Inventory Status By Plant";
                //        ((DevExpress.XtraCharts.XYDiagram)chartINV.Diagram).AxisX.Title.Text = "Plant";
                //        ((DevExpress.XtraCharts.XYDiagram)chartINV.Diagram).AxisX.QualitativeScaleOptions.AutoGrid = false;
                //        break;
                //    case "OUTGOING":
                //        lblOutgoing_Total.Text = "0";
                //        if (dt.Rows.Count > 0)
                //            lblOutgoing_Total.Text = string.Format("{0:n0}", Convert.ToInt32(dt.Compute("SUM(O_QTY)", "")));
                //        chartOutgoing.DataSource = dt;
                //        chartOutgoing.Series[0].ArgumentDataMember = "LINE_NM";
                //        chartOutgoing.Series[0].ValueDataMembers.AddRange(new string[] { "O_QTY" });
                //        ((DevExpress.XtraCharts.XYDiagram)chartOutgoing.Diagram).AxisX.Title.Text = "Plant";
                //        chartOutgoing.Titles[0].Text = "Outgoing Status By Plant";
                //        ((DevExpress.XtraCharts.XYDiagram)chartOutgoing.Diagram).AxisX.QualitativeScaleOptions.AutoGrid = false;
                //        break;
                //    case "SHORTAGE":

                //        int shrQty = 0,planQty=0;
                //        lblShortage_Total.Text = "0";
                //        lblPlan_Total.Text = "0";
                //        if (dt.Rows.Count > 0)
                //        {
                //            foreach (DataRow dr in dt.Rows)
                //            {
                //                shrQty += Convert.ToInt32(dr["SHR_QTY"]);
                //                planQty += Convert.ToInt32(dr["PLAN_QTY"]);
                //            }
                //            lblShortage_Total.Text = string.Format("{0:n0}", shrQty);
                //            lblPlan_Total.Text = string.Format("{0:n0}", planQty);
                //        }
                //        chartShortage.DataSource = dt;
                //        chartShortage.Series[0].ArgumentDataMember = "LINE_NM";
                //        chartShortage.Series[0].ValueDataMembers.AddRange(new string[] { "PLAN_QTY" });
                //        chartShortage.Series[1].ArgumentDataMember = "LINE_NM";
                //        chartShortage.Series[1].ValueDataMembers.AddRange(new string[] { "SHR_QTY" });

                //        ((XYDiagram)chartShortage.Diagram).AxisY.Title.Visibility = DefaultBoolean.True;
                //        ((XYDiagram)chartShortage.Diagram).AxisY.Title.Text = "Prs";
                //        chartShortage.Titles[0].Text = "Shortage Status By Plant";
                //        ((DevExpress.XtraCharts.XYDiagram)chartShortage.Diagram).AxisX.Title.Text = "Plant";
                //        ((DevExpress.XtraCharts.XYDiagram)chartShortage.Diagram).AxisX.QualitativeScaleOptions.AutoGrid = false;
                //        if (dt.Rows.Count >= 11)
                //        {
                //            ((XYDiagram)chartShortage.Diagram).AxisX.VisualRange.SetMinMaxValues(dt.Rows[0]["LINE_NM"], dt.Rows[10]["LINE_NM"]);
                //        }
                      //  break;
                //}
                splashScreenManager1.CloseWaitForm();
            }
            catch(Exception ex)
            {
                splashScreenManager1.CloseWaitForm();
                MessageBox.Show(ex.Message);
            }
        }

        private async void BindingData()
        {
         
            var Task1 = BindingData4Chart("INVENTORY");
            var Task2 = BindingData4Chart("OUTGOING");
            var Task3 = BindingData4Chart("SHORTAGE");

            await Task.WhenAll(Task1, Task2, Task3);
        }

        private  void BindingData2()
        {
            //var Task1 = BindingData4Chart2();
            //await Task.WhenAll(Task1);
            //Thread t = new Thread(() =>
            //{

            //});
            //t.Start();
            BindingData4Chart2();
        }

        private void BindingData4Chart2()
        {
            try
            {
                splashScreenManager1.ShowWaitForm();
             //   DatabaseTMS db = new DatabaseTMS();
                DataTable dt = new DataTable();
                DataTable dtTemp = new DataTable();

                lblOutgoing.Text = "TOTAL OUTGOING";
                lblPlan.Text = "TOTAL PLAN";
                lblInventory.Text = "INVENTORY";
                lblShortage.Text = "TOTAL SHORTAGE";

                DataSet ds = SELECT_TMS_DATA("SELECT_UPPER_STATUS", "", "", ComVar.Var._strValue1);
                dt = ds.Tables[0];
                lblOutgoing_Total.Text = "0"; chartOutgoing.DataSource = null;
                if (dt != null && dt.Rows.Count > 0)
                {
                   
                    var result = from tab in dt.AsEnumerable()
                                 group tab by tab["LABEL_YMD"]
                    into groupDt
                                 select new
                                 {
                                     DAYDAY = groupDt.Key,
                                     O_QTY = groupDt.Sum((r) => decimal.Parse(r["QTY"].ToString()))
                                 };
                    DataTable boundTable = LINQResultToDataTable(result);
                    //Binding Outgoing
                    lblOutgoing_Total.Text = "0";
                    if (dt.Rows.Count > 0)
                        lblOutgoing_Total.Text = string.Format("{0:n0}", Convert.ToInt32(boundTable.Compute("SUM(O_QTY)", "")));
                    chartOutgoing.DataSource = boundTable;
                    chartOutgoing.Series[0].ArgumentDataMember = "DAYDAY";
                    chartOutgoing.Series[0].ValueDataMembers.AddRange(new string[] { "O_QTY" });
                    chartOutgoing.Titles[0].Text = "Outgoing Status By Assembly Day";
                    ((DevExpress.XtraCharts.XYDiagram)chartOutgoing.Diagram).AxisX.Title.Text = "Assembly Day";

                    ((DevExpress.XtraCharts.XYDiagram)chartOutgoing.Diagram).AxisX.QualitativeScaleOptions.AutoGrid = false;
                }
                //Inventory
                dt = ds.Tables[1];
                lblInventory_Total.Text = "0"; chartINV.DataSource = null;
                if (dt != null && dt.Rows.Count > 0)
                {
                    lblInventory_Total.Text = "0";
                    lblInventory_Total.Text = string.Format("{0:n0}", dt.Rows[0]["TOTAL"]);

                    chartINV.DataSource = dt;
                    chartINV.Series[0].ArgumentDataMember = "STYLE_CD";
                    chartINV.Series[0].ValueDataMembers.AddRange(new string[] { "QTY" });
                    chartINV.Titles[0].Text = "Inventory Status By Style Code";
                    ((DevExpress.XtraCharts.XYDiagram)chartINV.Diagram).AxisX.Title.Text = "Style Code";
                    ((DevExpress.XtraCharts.XYDiagram)chartINV.Diagram).AxisX.QualitativeScaleOptions.AutoGrid = false;
                }
                //Shortage
                lblShortage_Total.Text = "0";
                lblPlan_Total.Text = "0";
                chartShortage.DataSource = null;
                if (ds.Tables[3] != null && ds.Tables[3].Rows.Count > 0)
                {
                    dt = ds.Tables[3]; // Pivot(ds.Tables[5], ds.Tables[3].Columns["DIV"], ds.Tables[3].Columns["QTY"]).Select("", "ASY_YMD").CopyToDataTable();

                    int shrQty = 0, planQty = 0;
                    lblShortage_Total.Text = "0";
                    lblPlan_Total.Text = "0";
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            shrQty += Convert.ToInt32(dr["SHORT_QTY"]);
                            planQty += Convert.ToInt32(dr["PLAN_QTY"]);
                        }
                        lblShortage_Total.Text = string.Format("{0:n0}", shrQty);
                        lblPlan_Total.Text = string.Format("{0:n0}", ds.Tables[2].Rows[0][0]);
                    }
                    chartShortage.DataSource = dt;
                    chartShortage.Series[0].ArgumentDataMember = "LABEL_YMD";
                    chartShortage.Series[0].ValueDataMembers.AddRange(new string[] { "PLAN_QTY" });
                    chartShortage.Series[1].ArgumentDataMember = "LABEL_YMD";
                    chartShortage.Series[1].ValueDataMembers.AddRange(new string[] { "SHORT_QTY" });

                    ((XYDiagram)chartShortage.Diagram).AxisY.Title.Visibility = DefaultBoolean.True;
                    ((XYDiagram)chartShortage.Diagram).AxisY.Title.Text = "Prs";
                    chartShortage.Titles[0].Text = "Shortage Status By Assembly Day";
                    ((DevExpress.XtraCharts.XYDiagram)chartShortage.Diagram).AxisX.Title.Text = "Assembly Date";
                    ((DevExpress.XtraCharts.XYDiagram)chartShortage.Diagram).AxisX.QualitativeScaleOptions.AutoGrid = false;
                }
                splashScreenManager1.CloseWaitForm();

            }
            catch//(Exception ex)
            {
                splashScreenManager1.CloseWaitForm();
              //  MessageBox.Show(ex.Message);
            }
        }
        public DataTable LINQResultToDataTable<T>(IEnumerable<T> Linqlist)
        {
            DataTable dt = new DataTable();
            PropertyInfo[] columns = null;

            if (Linqlist == null) return dt;

            foreach (T Record in Linqlist)
            {

                if (columns == null)
                {
                    columns = Record.GetType().GetProperties();
                    foreach (PropertyInfo GetProperty in columns)
                    {
                        Type colType = GetProperty.PropertyType;

                        if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition()
                        == typeof(Nullable<>)))
                        {
                            colType = colType.GetGenericArguments()[0];
                        }

                        dt.Columns.Add(new DataColumn(GetProperty.Name, colType));
                    }
                }

                DataRow dr = dt.NewRow();

                foreach (PropertyInfo pinfo in columns)
                {
                    dr[pinfo.Name] = pinfo.GetValue(Record, null) == null ? DBNull.Value : pinfo.GetValue
                    (Record, null);
                }

                dt.Rows.Add(dr);
            }
            return dt;
        }
        DataTable Pivot(DataTable dt, DataColumn pivotColumn, DataColumn pivotValue)
        {
            // find primary key columns 
            //(i.e. everything but pivot column and pivot value)
            DataTable temp = dt.Copy();
            temp.Columns.Remove(pivotColumn.ColumnName);
            temp.Columns.Remove(pivotValue.ColumnName);
            string[] pkColumnNames = temp.Columns.Cast<DataColumn>()
            .Select(c => c.ColumnName)
            .ToArray();

            // prep results table
            DataTable result = temp.DefaultView.ToTable(true, pkColumnNames).Copy();
            result.PrimaryKey = result.Columns.Cast<DataColumn>().ToArray();
            dt.AsEnumerable()
            .Select(r => r[pivotColumn.ColumnName].ToString())
            .Distinct().ToList()
            .ForEach(c => result.Columns.Add(c, pivotValue.DataType));
            //.ForEach(c => result.Columns.Add(c, pivotColumn.DataType));

            // load it
            foreach (DataRow row in dt.Rows)
            {
                // find row to update
                DataRow aggRow = result.Rows.Find(
                pkColumnNames
                .Select(c => row[c])
                .ToArray());
                // the aggregate used here is LATEST 
                // adjust the next line if you want (SUM, MAX, etc...)
                aggRow[row[pivotColumn.ColumnName].ToString()] = row[pivotValue.ColumnName];


            }

            return result;
        }

        private void tmrDate_Tick(object sender, EventArgs e)
        {
            cCount++;
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss")); //Gán dữ liệu giờ cho label ngày giờ
            if (cCount >= 60)
            {
                cCount = 0;
                //Binding Data
                tmrAnimation.Start();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "400";
            tmrDate.Stop();
        }

        private void FRM_DELI_STATUS_V6_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                switch (ComVar.Var._strValue1)
                {
                    case "2110":
                        lblTitle.Text = "Upper VJ3 (Tân Phú) - VJ1 (Vĩnh Cửu) Delivery Detail";
                        break;
                    case "2120":
                        lblTitle.Text = "Upper VJ3 (Tân Phú) - VJ2 (Long Thành) Delivery Detail";
                        break;
                }
                lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss")); //Gán dữ liệu giờ cho label ngày giờ
                cCount = 60;
                tmrDate.Start();
            }
            else
            {
                tmrDate.Stop();
            }
        }

        private void tmrAnimation_Tick(object sender, EventArgs e)
        {
            cAnimated++;

            #region Annimation
            BindingLabelRData(lblOutgoing_Total, 10000, 999999);
            BindingLabelRData(lblInventory_Total, 10000, 999999);
            BindingLabelRData(lblPlan_Total, 10000, 999999);
            BindingLabelRData(lblShortage_Total, 10000, 999999);

            #endregion

            if (cAnimated >= 10)
            {
                cAnimated = 0;
                tmrAnimation.Stop();
                //if (ComVar.Var._strValue1.Equals("ALL"))
                //    BindingData(); //Get Data for All Factory
                //else
                    BindingData2(); //Get Data for Each workshop detail
            }
        }
    }
}

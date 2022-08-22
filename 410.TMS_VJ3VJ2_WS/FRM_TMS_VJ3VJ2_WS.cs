using DevExpress.Data;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FORM
{
    public partial class FRM_TMS_VJ3VJ2_WS : Form
    {
        public FRM_TMS_VJ3VJ2_WS()
        {
            InitializeComponent();
        }

        DataTable _dtXML = new DataTable();
        int iCount = 0;
        #region DB
        private System.Data.DataSet Select_Ora_Grid_Train()
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                System.Data.DataSet ds_ret;

                string process_name = "MES.SP_TMS_TRAIN_TIME";
                //ARGMODE
                MyOraDB.ReDim_Parameter(2);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "V_P_YMD";
                MyOraDB.Parameter_Name[1] = "CV_1";

                // MyOraDB.Parameter_Name[3] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (char)OracleType.Cursor;
                // MyOraDB.Parameter_Type[3] = (char)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = DateTime.Now.ToString("yyyyMMdd");
                MyOraDB.Parameter_Values[1] = "";
                // MyOraDB.Parameter_Values[3] = "";
                // MyOraDB.Parameter_Values[3] = "";


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
        private DataTable SELECT_TMS_DATA(string ARG_PROC_NAME, string ARG_QTYPE, string ARG_PLANT_CD, string ARG_DATE)
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                MyOraDB.ConnectName = COM.OraDB.ConnectDB.LMES;
                System.Data.DataSet ds_ret;

                string process_name = string.Format("{0}", ARG_PROC_NAME);
                MyOraDB.ReDim_Parameter(4);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "ARG_QTYPE";
                MyOraDB.Parameter_Name[1] = "ARG_DATE";
                MyOraDB.Parameter_Name[2] = "ARG_LINE_CD";
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

        private DataTable SELECT_TMS_DATA(string ARG_PROC_NAME, string ARG_QTYPE, string ARG_DATE, string ARG_PLANT_CD, string ARG_LINE_CD)
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                MyOraDB.ConnectName = COM.OraDB.ConnectDB.LMES;
                System.Data.DataSet ds_ret;

                string process_name = string.Format("{0}", ARG_PROC_NAME);
                MyOraDB.ReDim_Parameter(5);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "ARG_QTYPE";
                MyOraDB.Parameter_Name[1] = "ARG_DATE";
                MyOraDB.Parameter_Name[2] = "ARG_PLANT_CD";
                MyOraDB.Parameter_Name[3] = "ARG_LINE_CD";
                MyOraDB.Parameter_Name[4] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[4] = (char)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ARG_QTYPE;
                MyOraDB.Parameter_Values[1] = ARG_DATE;
                MyOraDB.Parameter_Values[2] = ARG_PLANT_CD;
                MyOraDB.Parameter_Values[3] = ARG_LINE_CD;
                MyOraDB.Parameter_Values[4] = "";

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
        private DataTable SELECT_TMS_DATA(string ARG_PROC_NAME, string ARG_QTYPE, string ARG_DATE)
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                MyOraDB.ConnectName = COM.OraDB.ConnectDB.LMES;
                System.Data.DataSet ds_ret;

                string process_name = string.Format("{0}", ARG_PROC_NAME);
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

        private DataTable SELECT_TMS_TO_PLANT_DATA(string ARG_PROC_NAME, string ARG_QTYPE, string ARG_DATE, string ARG_LINE_CD)
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                MyOraDB.ConnectName = COM.OraDB.ConnectDB.LMES;
                System.Data.DataSet ds_ret;

                string process_name = string.Format("{0}", ARG_PROC_NAME);
                MyOraDB.ReDim_Parameter(4);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "ARG_QTYPE";
                MyOraDB.Parameter_Name[1] = "ARG_DATE";
                MyOraDB.Parameter_Name[2] = "ARG_LINE_CD";
                MyOraDB.Parameter_Name[3] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (char)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ARG_QTYPE;
                MyOraDB.Parameter_Values[1] = ARG_DATE;
                MyOraDB.Parameter_Values[2] = ARG_LINE_CD;
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

        #region CAR + OUTGOING QUANTITY
        private void BingdingCarFromVJ2_VJ1()
        {
            try
            {
                DataTable dt = SELECT_TMS_DATA("PKG_TMS_VINHCUU.SELECT_CAR_VJ2_TO_PLANT_LIST", "", "", "", _dtXML.Rows[0]["LOC_CD"].ToString());
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(dt.Rows[0]["QTY"].ToString()))
                        lblVJ2_dpt_trip1.Text = string.Concat(dt.Rows[0]["DPT_HMS"], " (", string.Format("{0:n0}", dt.Rows[0]["QTY"]), ")");
                    if (!string.IsNullOrEmpty(dt.Rows[1]["QTY"].ToString()))
                        lblVJ2_dpt_trip2.Text = string.Concat(dt.Rows[1]["DPT_HMS"], " (", string.Format("{0:n0}", dt.Rows[1]["QTY"]), ")");
                    if (!string.IsNullOrEmpty(dt.Rows[2]["QTY"].ToString()))
                        lblVJ2_dpt_trip3.Text = string.Concat(dt.Rows[2]["DPT_HMS"], " (", string.Format("{0:n0}", dt.Rows[2]["QTY"]), ")");
                    if (!string.IsNullOrEmpty(dt.Rows[3]["QTY"].ToString()))
                        lblVJ2_dpt_trip4.Text = string.Concat(dt.Rows[3]["DPT_HMS"], " (", string.Format("{0:n0}", dt.Rows[3]["QTY"]), ")");
                    if (!string.IsNullOrEmpty(dt.Rows[4]["QTY"].ToString()))
                        lblVJ2_dpt_trip5.Text = string.Concat(dt.Rows[4]["DPT_HMS"], " (", string.Format("{0:n0}", dt.Rows[4]["QTY"]), ")");

                    lblVJ1_arr_trip1.Text = string.Concat(dt.Rows[0]["ARR_HMS"]);
                    lblVJ1_arr_trip2.Text = string.Concat(dt.Rows[1]["ARR_HMS"]);
                    lblVJ1_arr_trip3.Text = string.Concat(dt.Rows[2]["ARR_HMS"]);
                    lblVJ1_arr_trip4.Text = string.Concat(dt.Rows[3]["ARR_HMS"]);
                    lblVJ1_arr_trip5.Text = string.Concat(dt.Rows[4]["ARR_HMS"]);


                    lblVJ2_dpt_trip1.BackColor = Color.White;
                    lblVJ2_dpt_trip2.BackColor = Color.White;
                    lblVJ2_dpt_trip3.BackColor = Color.White;
                    lblVJ2_dpt_trip4.BackColor = Color.White;
                    lblVJ2_dpt_trip5.BackColor = Color.White;

                    lblVJ1_arr_trip1.BackColor = Color.White;
                    lblVJ1_arr_trip2.BackColor = Color.White;
                    lblVJ1_arr_trip3.BackColor = Color.White;
                    lblVJ1_arr_trip4.BackColor = Color.White;
                    lblVJ1_arr_trip5.BackColor = Color.White;

                    switch (dt.Rows[0]["CUR_TRIP"].ToString())
                    {
                        case "1":
                            lblVJ2_dpt_trip1.BackColor = Color.Yellow;
                            lblVJ1_arr_trip1.BackColor = Color.Yellow;
                            break;
                        case "2":
                            lblVJ2_dpt_trip2.BackColor = Color.Yellow;
                            lblVJ1_arr_trip2.BackColor = Color.Yellow;
                            break;
                        case "3":
                            lblVJ2_dpt_trip3.BackColor = Color.Yellow;
                            lblVJ1_arr_trip3.BackColor = Color.Yellow;
                            break;
                        case "4":
                            lblVJ2_dpt_trip4.BackColor = Color.Yellow;
                            lblVJ1_arr_trip4.BackColor = Color.Yellow;
                            break;
                        case "5":
                            lblVJ2_dpt_trip5.BackColor = Color.Yellow;
                            lblVJ1_arr_trip5.BackColor = Color.Yellow;
                            break;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void BingdingCarFromVJ3_VJ1()
        {
            try
            {
                DataTable dt = SELECT_TMS_DATA("PKG_TMS_VINHCUU.SELECT_CAR_VJ3_TO_PLANT_LIST", "", "", "", _dtXML.Rows[0]["LOC_CD"].ToString());
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(dt.Rows[0]["QTY"].ToString()))
                        lblVJ3_dpt_trip1.Text = string.Concat(dt.Rows[0]["DPT_HMS"], " (", string.Format("{0:n0}", dt.Rows[0]["QTY"]), ")");
                    if (!string.IsNullOrEmpty(dt.Rows[1]["QTY"].ToString()))
                        lblVJ3_dpt_trip2.Text = string.Concat(dt.Rows[1]["DPT_HMS"], " (", string.Format("{0:n0}", dt.Rows[1]["QTY"]), ")");

                    lblVJ3VJ1_arr_trip1.Text = string.Concat(dt.Rows[0]["ARR_HMS"]);
                    lblVJ3VJ1_arr_trip2.Text = string.Concat(dt.Rows[1]["ARR_HMS"]);


                    lblVJ3_dpt_trip1.BackColor = Color.White;
                    lblVJ3_dpt_trip2.BackColor = Color.White;


                    lblVJ3VJ1_arr_trip1.BackColor = Color.White;
                    lblVJ3VJ1_arr_trip2.BackColor = Color.White;

                    switch (dt.Rows[0]["CUR_TRIP"].ToString())
                    {
                        case "1":
                            lblVJ3_dpt_trip1.BackColor = Color.Yellow;
                            lblVJ3VJ1_arr_trip1.BackColor = Color.Yellow;
                            break;
                        case "2":
                            lblVJ3_dpt_trip2.BackColor = Color.Yellow;
                            lblVJ3VJ1_arr_trip2.BackColor = Color.Yellow;
                            break;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region GridControl
        private void BindingGridVJ2UpperData()
        {
            try
            {
                DataTable dt = SELECT_TMS_DATA("PKG_TMS_LONGTHANH.SELECT_LT_UPPER_OUT_LIST", _dtXML.Rows[0]["LOC_CD"].ToString(), "");
                if (dt != null && dt.Rows.Count > 1)
                {

                    grdVJ2Upper.DataSource = dt;
                    GridColumnSummaryItem siRecordDate = new GridColumnSummaryItem();
                    siRecordDate.SummaryType = SummaryItemType.Custom;
                    siRecordDate.FieldName = "QTY";
                    siRecordDate.DisplayFormat = "{0:n0} Prs";


                    int Total = 0;
                    gvwVJ2Upper.CustomSummaryCalculate += (sender, e) =>
                    {

                        GridView view = sender as GridView;
                        if (e.IsTotalSummary)
                        {
                            switch (e.SummaryProcess)
                            {
                                case CustomSummaryProcess.Start:
                                    Total = 0;
                                    break;
                                case CustomSummaryProcess.Calculate:
                                    bool isTotal = view.GetRowCellValue(e.RowHandle, view.Columns["PLANT_NM"]).Equals("TOTAL");
                                    if (isTotal)
                                    {
                                        Total += Convert.ToInt32(view.GetRowCellValue(e.RowHandle, view.Columns["QTY"]).ToString());
                                    }
                                    break;
                                case CustomSummaryProcess.Finalize:
                                    e.TotalValue = Total;
                                    break;
                                default:
                                    break;
                            }
                        }
                    };
                    gvwVJ2Upper.Columns["QTY"].Summary.Clear();
                    gvwVJ2Upper.Columns["QTY"].Summary.Add(siRecordDate);
                }
            }
            catch
            {

            }
        }

        private void BindingGridVJ3UpperData()
        {
            try
            {
                DataTable dt = SELECT_TMS_TO_PLANT_DATA("PKG_TMS_TANPHU.SELECT_OUTGOING_TO_PLANT_LIST", "", "", _dtXML.Rows[0]["LOC_CD"].ToString());
                if (dt != null && dt.Rows.Count > 1)
                {

                    grdVJ3Upper.DataSource = dt;
                    GridColumnSummaryItem siRecordDate = new GridColumnSummaryItem();
                    siRecordDate.SummaryType = SummaryItemType.Custom;
                    siRecordDate.FieldName = "QTY";
                    siRecordDate.DisplayFormat = "{0:n0} Prs";


                    int Total = 0;
                    gvwVJ3Upper.CustomSummaryCalculate += (sender, e) =>
                    {

                        GridView view = sender as GridView;
                        if (e.IsTotalSummary)
                        {
                            switch (e.SummaryProcess)
                            {
                                case CustomSummaryProcess.Start:
                                    Total = 0;
                                    break;
                                case CustomSummaryProcess.Calculate:
                                    bool isTotal = view.GetRowCellValue(e.RowHandle, view.Columns["PLANT_NM"]).Equals("TOTAL");
                                    if (isTotal)
                                    {
                                        Total += Convert.ToInt32(view.GetRowCellValue(e.RowHandle, view.Columns["QTY"]).ToString());
                                    }
                                    break;
                                case CustomSummaryProcess.Finalize:
                                    e.TotalValue = Total;
                                    break;
                                default:
                                    break;
                            }
                        }
                    };
                    gvwVJ3Upper.Columns["QTY"].Summary.Clear();
                    gvwVJ3Upper.Columns["QTY"].Summary.Add(siRecordDate);
                }
            }
            catch
            {

            }
        }

        private void BingdingVJ3OutByAsyDate()
        {
            try
            {


                DataTable dt = SELECT_TMS_DATA("PKG_TMS_TANPHU.SELECT_OUT_ASY_DATE_LIST", "", _dtXML.Rows[0]["LOC_CD"].ToString(), "");
                if (dt != null && dt.Rows.Count > 0)
                {

                    lb_total2.Text = string.Format("{0:n0}", dt.Rows[0]["TOTAL"]);
                    lb_DD_2.Text = string.Format("{0:n0}", dt.Rows[0]["DD"]);
                    lb_D1_2.Text = string.Format("{0:n0}", dt.Rows[0]["D1"]);
                    lb_D2_2.Text = string.Format("{0:n0}", dt.Rows[0]["D2"]);
                    lb_D3_2.Text = string.Format("{0:n0}", dt.Rows[0]["D3"]);
                }

            }
            catch (Exception ex)
            {


            }
        }

        private void BingdingVJ2OutByAsyDate()
        {
            try
            {

                DataTable dt = SELECT_TMS_DATA("PKG_TMS_LONGTHANH.SELECT_OUT_ASY_DATE_LIST", "", _dtXML.Rows[0]["LOC_CD"].ToString(), "");
                if (dt != null && dt.Rows.Count > 0)
                {

                    lb_total.Text = string.Format("{0:n0}", dt.Rows[0]["TOTAL"]);
                    lb_DD.Text = string.Format("{0:n0}", dt.Rows[0]["DD"]);
                    lb_D1.Text = string.Format("{0:n0}", dt.Rows[0]["D1"]);
                    lb_D2.Text = string.Format("{0:n0}", dt.Rows[0]["D2"]);
                    lb_D3.Text = string.Format("{0:n0}", dt.Rows[0]["D3"]);
                }

            }
            catch (Exception ex)
            {


            }
        }

        private void BindingBottomToPlantList()
        {
            try
            {
                DataTable dt = SELECT_TMS_DATA("PKG_TMS_VINHCUU.SELECT_BOTTOM_TO_PLANT_LIST", "", "", "", _dtXML.Rows[0]["LOC_CD"].ToString());
                if (dt != null && dt.Rows.Count > 0)
                {
                    grdBottomVJ1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {

                throw;
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

        #endregion

        private void FRM_TMS_VJ3VJ2_WS_Load(object sender, EventArgs e)
        {
            try
            {
                _dtXML = ComVar.Func.ReadXML(Application.StartupPath + "\\Config.XML", "MAIN");
            }
            catch (Exception ex)
            {


            }
        }

        private void tmr_Tick(object sender, EventArgs e)
        {
            iCount++;
            if (iCount >= 60)
            {
                iCount = 0;
                BindingCarRun();
                BindingCarRun2();
            }
        }

        private void BindingCarRun()
        {
            try
            {
                DataTable dt = SELECT_TMS_DATA("PKG_TMS_VINHCUU.SELECT_CAR_VJ2_DPT", "", "", "", _dtXML.Rows[0]["LOC_CD"].ToString());
                if (dt != null && dt.Rows.Count > 0)
                {
                    int Minutes = Convert.ToInt32(dt.Rows[0]["DPT_MINUTES"]);
                    if (Minutes >= 60)
                    {
                        lblTimeLapseVJ2_VJ1.Text = string.Format("Allready Arrived To Vinh Cuu");
                        btnCar.Location = new Point(656, btnCar.Location.Y);

                    }
                    else
                    {
                        lblTimeLapseVJ2_VJ1.Text = string.Format("Remain: {0} minutes to arrival", (60 - Minutes));
                        btnCar.Location = new Point(335 + (Minutes * 5), btnCar.Location.Y);
                    }

                }
                else
                {
                    btnCar.Location = new Point(656, btnCar.Location.Y);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void BindingCarRun2()
        {
            try
            {
                DataTable dt = SELECT_TMS_DATA("PKG_TMS_VINHCUU.SELECT_CAR_VJ3_DPT", "", "", "", _dtXML.Rows[0]["LOC_CD"].ToString());
                if (dt != null && dt.Rows.Count > 0)
                {
                    int Minutes = Convert.ToInt32(dt.Rows[0]["DPT_MINUTES"]);
                    if (Minutes >= 180)
                    {
                        lblTimeLapseVJ3_VJ1.Text = string.Format("Allready Arrived To Vinh Cuu");
                        btnCar2.Location = new Point(1220, btnCar2.Location.Y);

                    }
                    else
                    {
                        lblTimeLapseVJ3_VJ1.Text = string.Format("Remain: {0} minutes to arrival", (180 - Minutes));
                        btnCar2.Location = new Point(1499 - (Minutes * 2), btnCar2.Location.Y);
                    }

                }
                else
                {
                    btnCar2.Location = new Point(1220, btnCar.Location.Y);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void FRM_TMS_VJ3VJ2_WS_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {

                try
                {
                    splashScreenManager1.ShowWaitForm();
                    label22.Text = "2022.08.22.1";
                    iCount = 60;
                    ClearControls();
                    BingdingCarFromVJ2_VJ1();
                    BingdingCarFromVJ3_VJ1();
                    BindingBottomToPlantList();
                    BindingGridVJ2UpperData();
                    BindingGridVJ3UpperData();
                    BingdingVJ2OutByAsyDate();
                    BingdingVJ3OutByAsyDate();

                }
                catch
                {

                }
                finally
                {
                    splashScreenManager1.CloseWaitForm();
                }
            }
        }
    }
}

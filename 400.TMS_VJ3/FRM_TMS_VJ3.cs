using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OracleClient;

namespace FORM
{
    public partial class FRM_TMS_VJ3 : Form
    {
        public FRM_TMS_VJ3()
        {
            InitializeComponent();
            tmrBanner.Stop();
            tmrBanner2.Stop();
        }
        #region Variable
        DataTable _dtXML = new DataTable();
        int cCount = 0;
        string S_TIME, AR_YN1 = "";
        string S_TIME2, AR_YN2 = "";
        string VThread = "PHUOC";
        #endregion


        private DataTable SELECT_QTY_BY_ASSYDATE(string Line, string Mline, string location) //Gán giá trị cho Label Asy Date
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                System.Data.DataSet ds_ret;

                string process_name = "MES.SP_TMS_LT_ASY_TOTAL";
                //ARGMODE
                MyOraDB.ReDim_Parameter(6);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "V_P_LINE";
                MyOraDB.Parameter_Name[1] = "V_P_MLINE";
                MyOraDB.Parameter_Name[2] = "V_P_YMD";
                MyOraDB.Parameter_Name[3] = "V_P_TRIP";
                MyOraDB.Parameter_Name[4] = "V_P_LOCATION";
                MyOraDB.Parameter_Name[5] = "CV_1";

                MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[4] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[5] = (char)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = Line;
                MyOraDB.Parameter_Values[1] = Mline;
                MyOraDB.Parameter_Values[2] = DateTime.Now.ToString("yyyyMMdd");
                MyOraDB.Parameter_Values[3] = "001";
                MyOraDB.Parameter_Values[4] = location;
                MyOraDB.Parameter_Values[5] = "";
                // MyOraDB.Parameter_Values[3] = "";
                // MyOraDB.Parameter_Values[3] = "";


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
        private DataTable Select_Ora_Grid_Ratio(string Line, string Mline, string location)
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                System.Data.DataSet ds_ret;

                string process_name = "MES.SP_TMS_LT_VC_RATIO";
                //ARGMODE
                MyOraDB.ReDim_Parameter(6);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "V_P_LINE";
                MyOraDB.Parameter_Name[1] = "V_P_MLINE";
                MyOraDB.Parameter_Name[2] = "V_P_YMD";
                MyOraDB.Parameter_Name[3] = "V_P_TRIP";
                MyOraDB.Parameter_Name[4] = "V_P_LOCATION";
                // MyOraDB.Parameter_Name[3] = "CV_1";
                MyOraDB.Parameter_Name[5] = "CV_1";

                MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[4] = (char)OracleType.VarChar;
                // MyOraDB.Parameter_Type[2] = (char)OracleType.VarChar;    
                MyOraDB.Parameter_Type[5] = (char)OracleType.Cursor;
                // MyOraDB.Parameter_Type[3] = (char)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = Line;
                MyOraDB.Parameter_Values[1] = Mline;
                MyOraDB.Parameter_Values[2] = DateTime.Now.ToString("yyyyMMdd");
                MyOraDB.Parameter_Values[3] = "001";
                MyOraDB.Parameter_Values[4] = location;
                MyOraDB.Parameter_Values[5] = "";
                // MyOraDB.Parameter_Values[3] = "";
                // MyOraDB.Parameter_Values[3] = "";

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
        private DataTable SELECT_DATA_GRID(string Line, string Mline, string Location)
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                System.Data.DataSet ds_ret;

                string process_name = "MES.SP_TMS_LT";
                //ARGMODE
                MyOraDB.ReDim_Parameter(5);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "V_P_LINE";
                MyOraDB.Parameter_Name[1] = "V_P_MLINE";
                MyOraDB.Parameter_Name[2] = "V_P_YMD";
                MyOraDB.Parameter_Name[3] = "V_P_LOCATION";
                MyOraDB.Parameter_Name[4] = "CV_1";

                MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[4] = (char)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = Line;
                MyOraDB.Parameter_Values[1] = Mline;
                MyOraDB.Parameter_Values[2] = DateTime.Now.ToString("yyyyMMdd");
                MyOraDB.Parameter_Values[3] = Location;
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

        private DataTable Select_Train_Time(string Qtype, string Factory)
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                System.Data.DataSet ds_ret;
                string process_name = "MES.PKG_TMS_HOME.TMS_GET_DEPART_TIME";
                MyOraDB.ReDim_Parameter(3);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "ARG_QTYPE";
                MyOraDB.Parameter_Name[1] = "ARG_FAC";
                MyOraDB.Parameter_Name[2] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (char)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = Qtype;
                MyOraDB.Parameter_Values[1] = Factory;
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
        private DataTable Select_qty_Trip()
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                System.Data.DataSet ds_ret;

                string process_name = "MES.SP_TMS_LT_TOTAL_TRIP";
                //ARGMODE
                MyOraDB.ReDim_Parameter(3);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "V_P_YMD";
                MyOraDB.Parameter_Name[1] = "V_P_LOCATION";
                MyOraDB.Parameter_Name[2] = "CV_1";

                MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (char)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = DateTime.Now.ToString("yyyyMMdd");
                MyOraDB.Parameter_Values[1] = "VJ3";
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

        private DataTable SELECT_TMS_VJ3_TRIP_TIME()
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                System.Data.DataSet ds_ret;

                string process_name = "MES.SP_VJ3_TMS_TRIP_TIME";
                MyOraDB.ReDim_Parameter(1);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (char)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = "";

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
        private DataTable SELECT_VJ3_LT_TRIP_TIME() //vj3 -> vj2 depart time
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                System.Data.DataSet ds_ret;

                string process_name = "MES.SP_VJ3_LT_TRIP_TIME";
                MyOraDB.ReDim_Parameter(1);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (char)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = "";

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


        private void BindingQty2AsyDate(string Line, string Mline, string Location)
        {
            //reset label qty về 0
            splashScreenManager1.ShowWaitForm();
            S_TIME = "";
            btnCar.Text = "0 Prs";
            lb_total.Text = "0 Prs (0%)";
            lb_DD.Text = "0 Prs (0%)";
            lb_D1.Text = "0 Prs (0%)";
            lb_D2.Text = "0 Prs (0%)";
            lb_D3.Text = "0 Prs (0%)";
            try
            {
                DataTable dtTripTime = SELECT_TMS_VJ3_TRIP_TIME(); //No parameter

                if (dtTripTime.Rows.Count > 0 && dtTripTime != null)
                {
                    AR_YN1 = dtTripTime.Rows[0]["AR_YN"].ToString();
                    if (dtTripTime.Rows[0]["DP_YN"].ToString().Equals("1"))
                        S_TIME = dtTripTime.Rows[0]["S_TIME"].ToString();
                    else
                        S_TIME = "";

                    btnS_VJ3VJ1_Time.Text = dtTripTime.Rows[0]["S_TIME"].ToString().Replace("::", "");
                    btnE_VJ3VJ1_Time.Text = dtTripTime.Rows[0]["E_TIME"].ToString().Replace("::", "");
                    FormatFontSize10Label(btnS_VJ3VJ1_Time);
                    FormatFontSize10Label(btnE_VJ3VJ1_Time);

                }
                DataTable dtTripTime2 = SELECT_VJ3_LT_TRIP_TIME(); //No parameter
                if (dtTripTime2.Rows.Count > 0 && dtTripTime2 != null)
                {
                    AR_YN2 = dtTripTime2.Rows[0]["AR_YN"].ToString();
                    if (dtTripTime2.Rows[0]["DP_YN"].ToString().Equals("1"))
                        S_TIME2 = dtTripTime2.Rows[0]["S_TIME"].ToString();
                    else
                        S_TIME2 = "";

                    btnS_VJ3VJ2_Time.Text = dtTripTime2.Rows[0]["S_TIME"].ToString().Replace("::", "");
                    btnE_VJ3VJ2_Time.Text = dtTripTime2.Rows[0]["E_TIME"].ToString().Replace("::", "");

                    FormatFontSize10Label(btnS_VJ3VJ2_Time);
                    FormatFontSize10Label(btnE_VJ3VJ2_Time);
                }

                DataTable dt = SELECT_QTY_BY_ASSYDATE(Line, Mline, Location);
                if (dt != null && dt.Rows.Count > 0)
                {
                    lb_total.Text = btnCar.Text = dt.Rows[0]["TOTAL"].ToString();
                    lb_DD.Text = dt.Rows[0]["QTY_DD"].ToString();
                    lb_D1.Text = dt.Rows[0]["QTY_D1"].ToString();
                    lb_D2.Text = dt.Rows[0]["QTY_D2"].ToString();
                    lb_D3.Text = dt.Rows[0]["QTY_D3"].ToString();
                }
                DataTable dt2 = SELECT_QTY_BY_ASSYDATE(Line, Mline, "VJ3_LT");
                if (dt2 != null && dt2.Rows.Count > 0)
                {
                    lb2_total.Text = btnCar2.Text = string.Concat(string.Format("{0:n0}", dt2.Rows[0]["TOTAL"]), " PRS");
                    lb2_DD.Text = string.Concat(string.Format("{0:n0}", dt2.Rows[0]["QTY_DD"]), " PRS ", "(", string.Format("{0:n1}", dt2.Rows[0]["RATIO_DD"]), "%)");
                    lb2_D1.Text = string.Concat(string.Format("{0:n0}", dt2.Rows[0]["QTY_D1"]), " PRS ", "(", string.Format("{0:n1}", dt2.Rows[0]["RATIO_D1"]), "%)");
                    lb2_D2.Text = string.Concat(string.Format("{0:n0}", dt2.Rows[0]["QTY_D2"]), " PRS ", "(", string.Format("{0:n1}", dt2.Rows[0]["RATIO_D2"]), "%)");
                    lb2_D3.Text = string.Concat(string.Format("{0:n0}", dt2.Rows[0]["QTY_D3"]), " PRS ", "(", string.Format("{0:n1}", dt2.Rows[0]["RATIO_D3"]), "%)");
                }
                splashScreenManager1.CloseWaitForm();
            }
            catch { splashScreenManager1.CloseWaitForm(); }
        }
        private void FormatFontSize10Label(Button btn)
        {
            if (btn.Text.Length > 10)
            {
                btn.Font = new Font("DS-Digital", 40, FontStyle.Bold);
                btn.ForeColor = Color.Yellow;
            }
            else
            {
                btn.Font = new Font("DS-Digital", 55, FontStyle.Bold);
                btn.ForeColor = Color.Yellow;
            }
        }
        private void BindingData2Grid(string Line, string Mline, string Location)
        {
            try
            {
                splashScreenManager1.ShowWaitForm();
               
                DataTable dt = SELECT_DATA_GRID(Line, Mline, Location);
                if (VThread.Equals("DEPART"))
                    dt = dt.Select("COMPONENT = 'UPPER'").CopyToDataTable();

                if (dt != null && dt.Rows.Count > 0)
                {
                    grdBase.DataSource = dt;
                    gvwBase.Columns[0].AppearanceHeader.BackColor = Color.FromArgb(128, 128, 128);
                    gvwBase.Columns[0].AppearanceHeader.BackColor2 = Color.FromArgb(128, 128, 128);
                    gvwBase.Columns[0].AppearanceHeader.ForeColor = Color.White;
                    gvwBase.Columns[3].AppearanceHeader.BackColor = Color.FromArgb(128, 128, 128);
                    gvwBase.Columns[3].AppearanceHeader.BackColor2 = Color.FromArgb(128, 128, 128);
                    gvwBase.Columns[3].AppearanceHeader.ForeColor = Color.White;
                    gvwBase.Columns[4].AppearanceHeader.BackColor = Color.FromArgb(128, 128, 128);
                    gvwBase.Columns[4].AppearanceHeader.BackColor2 = Color.FromArgb(128, 128, 128);
                    gvwBase.Columns[4].AppearanceHeader.ForeColor = Color.White;
                    gvwBase.Columns[5].AppearanceHeader.BackColor = Color.FromArgb(128, 128, 128);
                    gvwBase.Columns[5].AppearanceHeader.BackColor2 = Color.FromArgb(128, 128, 128);
                    gvwBase.Columns[5].AppearanceHeader.ForeColor = Color.White;
                    gvwBase.Columns[6].AppearanceHeader.BackColor = Color.FromArgb(128, 128, 128);
                    gvwBase.Columns[6].AppearanceHeader.BackColor2 = Color.FromArgb(128, 128, 128);
                    gvwBase.Columns[6].AppearanceHeader.ForeColor = Color.White;
                    gvwBase.Columns[7].AppearanceHeader.BackColor = Color.FromArgb(57, 190, 29);
                    gvwBase.Columns[7].AppearanceHeader.BackColor2 = Color.FromArgb(57, 190, 29);
                    gvwBase.Columns[7].AppearanceHeader.ForeColor = Color.White;
                    gvwBase.Columns[8].AppearanceHeader.BackColor = Color.FromArgb(255, 127, 0);
                    gvwBase.Columns[8].AppearanceHeader.BackColor2 = Color.FromArgb(255, 127, 0);
                    gvwBase.Columns[8].AppearanceHeader.ForeColor = Color.White;
                    for (int i = 0; i < gvwBase.Columns.Count; i++)
                    {
                        gvwBase.Columns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gvwBase.Columns[i].AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                        gvwBase.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gvwBase.Columns[i].AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                        gvwBase.Columns["TRIP"].Visible = false;
                        gvwBase.Columns["LINE"].Width = 100;
                        gvwBase.Columns["SET"].Width = 250;
                        gvwBase.Columns["MODEL"].Width = 500;
                        gvwBase.Columns["START TIME"].Visible = false;
                        gvwBase.Columns["ARRIVAL TIME"].Visible = false;
                        gvwBase.Columns["LINE_CD"].Visible = false;
                        gvwBase.Columns["MLINE_CD"].Visible = false;
                        gvwBase.Columns["SET_RATIO"].Visible = false;
                         if (VThread.Equals("DEPART"))
                         {
                             gvwBase.Columns["INCOMING QTY"].Caption = "UPPER OUTGOING";
                             gvwBase.Columns["COMPONENT"].Visible = false;
                         }
                        else
                         {
                             gvwBase.Columns["INCOMING QTY"].Caption = "INCOMING QTY";
                             gvwBase.Columns["COMPONENT"].Visible = true;
                         }
                    }
                    gvwBase.OptionsView.AllowCellMerge = true;
                }
                DataTable data_ratio = Select_Ora_Grid_Ratio(Line, Mline, Location);
                if (data_ratio.Rows.Count < 1)
                {
                    lblTP_VC_Ratio.Text = "RATIO: 0%";
                }
                else
                {
                    lblTP_VC_Ratio.Text = string.Concat("RATIO: ", data_ratio.Rows[0][0], "%");
                }

                DataTable data_ratio2 = Select_Ora_Grid_Ratio(Line, Mline, "VJ3_LT");

                if (data_ratio2.Rows.Count < 1)
                {
                    lblTP_LT_Ratio.Text = "RATIO: 0%";
                }
                else
                {
                    lblTP_LT_Ratio.Text = string.Concat("RATIO: ", data_ratio2.Rows[0][0], "%");
                }
                splashScreenManager1.CloseWaitForm();
            }
            catch { splashScreenManager1.CloseWaitForm(); }
        }


        string LTDepartTime;
        public void GetDepartTime(string ButtonCode)
        {
            DataTable dt = new DataTable();
            DataTable dtQua = new DataTable();
            dt = SELECT_TMS_VJ3_TRIP_TIME();
            dtQua = Select_qty_Trip();
            if (dt.Rows.Count > 0 && dt != null)
                LTDepartTime = dt.Rows[0]["DP_TIME"].ToString();
            if (dtQua.Rows.Count > 0 && dtQua != null)
            {
                string Qty = string.Concat(string.Format("{0:n0}", dtQua.Rows[0]["QTY"]), " Prs");
                btnCar.Text = Qty;
            }
            else
                btnCar.Text = "";
        }
        private void FRM_TMS_VJ3_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                ComVar.Var._bValue1 = false;
                cCount = 60;
                tmrDate.Start();
            }
            else
            { tmrDate.Stop(); }
        }

        private void tmrDate_Tick(object sender, EventArgs e)
        {
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            cCount++;
            if (cCount >= 60)
            {
                BindingQty2AsyDate(ComVar.Var._strValue1, ComVar.Var._strValue2, ComVar.Var._strValue3);
                BindingData2Grid(ComVar.Var._strValue1, ComVar.Var._strValue2, ComVar.Var._strValue3);
                tmrBanner.Start();
                tmrBanner2.Start();
                cCount = 0;
            }

        }
        private void FRM_TMS_VJ3_Load(object sender, EventArgs e)
        {
            tmrBanner.Stop();
            _dtXML = ComVar.Func.ReadXML(Application.StartupPath + "\\Config.XML", "MAIN");
            ComVar.Var._strValue3 = "VJ3";
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            VThread = _dtXML.Rows[0]["THREAD"].ToString();
        }

        private void GawRatio_DoubleClick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {

                this.Cursor = Cursors.Default;
            }

            catch (Exception)
            {


            }
        }
        //Custom Grid
        private void gvwBase_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {
            try
            {
                if (e.RowHandle1 < 0 || gvwBase.RowCount == 0)
                    return;

                e.Merge = false;
                e.Handled = true;


                if (e.Column.FieldName == "TRIP")
                {
                    string line1 = gvwBase.GetRowCellValue(e.RowHandle1, "TRIP").ToString().Trim();
                    string line2 = gvwBase.GetRowCellValue(e.RowHandle2, "TRIP").ToString().Trim();
                    if (line1 == line2)
                    {
                        e.Merge = true;
                    }
                    else
                    {
                        e.Merge = false;
                    }
                }
                if (e.Column.FieldName == "LINE")
                {
                    string line1 = gvwBase.GetRowCellValue(e.RowHandle1, "LINE").ToString().Trim();
                    string line2 = gvwBase.GetRowCellValue(e.RowHandle2, "LINE").ToString().Trim();

                    if (line1 == line2)
                    {
                        e.Merge = true;
                    }
                    else
                    {
                        e.Merge = false;
                    }
                }

                if (e.Column.FieldName == "SET")
                {
                    string line1 = gvwBase.GetRowCellValue(e.RowHandle1, "LINE").ToString().Trim();
                    string line2 = gvwBase.GetRowCellValue(e.RowHandle2, "LINE").ToString().Trim();
                    string set1 = gvwBase.GetRowCellValue(e.RowHandle1, "SET").ToString().Trim();
                    string set2 = gvwBase.GetRowCellValue(e.RowHandle2, "SET").ToString().Trim();
                    string trip1 = gvwBase.GetRowCellValue(e.RowHandle1, "TRIP").ToString().Trim();
                    string trip2 = gvwBase.GetRowCellValue(e.RowHandle2, "TRIP").ToString().Trim();
                    string STYLE1 = gvwBase.GetRowCellValue(e.RowHandle1, "STYLE").ToString().Trim();
                    string STYLE2 = gvwBase.GetRowCellValue(e.RowHandle2, "STYLE").ToString().Trim();
                    if (set1 == set2 && trip1 == trip2 && STYLE1 == STYLE2 && line1 == line2)
                    {
                        e.Merge = true;
                    }
                    else
                    {
                        e.Merge = false;
                    }
                }

                if (e.Column.FieldName == "MODEL")
                {
                    string trip1 = gvwBase.GetRowCellValue(e.RowHandle1, "LINE").ToString().Trim();
                    string trip2 = gvwBase.GetRowCellValue(e.RowHandle2, "LINE").ToString().Trim();

                    string model1 = gvwBase.GetRowCellValue(e.RowHandle1, "MODEL").ToString().Trim();
                    string model2 = gvwBase.GetRowCellValue(e.RowHandle2, "MODEL").ToString().Trim();
                    if (trip1 == trip2 && model1 == model2)
                    {
                        e.Merge = true;
                    }
                    else
                    {
                        e.Merge = false;
                    }
                }
                if (e.Column.FieldName == "STYLE")
                {
                    string STYLE1 = gvwBase.GetRowCellValue(e.RowHandle1, "STYLE").ToString().Trim();
                    string STYLE2 = gvwBase.GetRowCellValue(e.RowHandle2, "STYLE").ToString().Trim();
                    string model1 = gvwBase.GetRowCellValue(e.RowHandle1, "MODEL").ToString().Trim();
                    string model2 = gvwBase.GetRowCellValue(e.RowHandle2, "MODEL").ToString().Trim();
                    string line1 = gvwBase.GetRowCellValue(e.RowHandle1, "LINE").ToString().Trim();
                    string line2 = gvwBase.GetRowCellValue(e.RowHandle2, "LINE").ToString().Trim();

                    string trip1 = gvwBase.GetRowCellValue(e.RowHandle1, "TRIP").ToString().Trim();
                    string trip2 = gvwBase.GetRowCellValue(e.RowHandle2, "TRIP").ToString().Trim();
                    if (trip1 == trip2 && STYLE1 == STYLE2 && model1 == model2 && line1 == line2)
                    {
                        e.Merge = true;
                    }
                    else
                    {
                        e.Merge = false;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void gvwBase_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "SET")
            {
                if (gvwBase.GetRowCellValue(e.RowHandle, "SET").ToString().Contains("100%"))
                {

                }
                else
                {
                    e.Appearance.BackColor = Color.Red;
                    e.Appearance.ForeColor = Color.White;
                }
            }
            if (e.Column.FieldName == "COMPONENT" || e.Column.FieldName == "INCOMING QTY")
            {
                if (!VThread.Equals("DEPART"))
                if (gvwBase.GetRowCellValue(e.RowHandle, "COMPONENT").ToString().ToUpper().Contains("UPPER"))
                {

                    e.Appearance.BackColor = Color.LightSkyBlue;
                    e.Appearance.ForeColor = Color.White;
                }
            }
        }

        private void gvwBase_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (e.Clicks < 2 || e.Column.FieldName != "SET")
                return;
            FRM_TMS_CAR_LT_POP pop = new FRM_TMS_CAR_LT_POP();
            pop.v_date = DateTime.Now.ToString("yyyyMMdd");
            pop.v_Trip = gvwBase.GetRowCellValue(e.RowHandle, "TRIP").ToString();
            pop.v_STYLE_CD = gvwBase.GetRowCellValue(e.RowHandle, "STYLE").ToString();
            pop.v_LINE_CD = gvwBase.GetRowCellValue(e.RowHandle, "LINE_CD").ToString();
            pop.v_MLINE_CD = gvwBase.GetRowCellValue(e.RowHandle, "MLINE_CD").ToString();
            pop.v_p_location = ComVar.Var._strValue3;
            this.Cursor = Cursors.Default;
            pop.ShowDialog();

        }

        private void lblDate_DoubleClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblTitle_DoubleClick(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "Minimized";
        }
        #region Pic Car Variable
        int angle = 0;
        int rotSpeed = 1;
        int location_car = 0;
        int location_lb = 0;

        int location_car2 = 0;
        int location_lb2 = 0;

        int minutes = 0;
        int minutes2 = 0;
        Point carorigin = new Point(345, 68);  // my origin
        Point carorigin2 = new Point(345, 239);  // my origin
        #endregion
        private void tmrCar_Tick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(S_TIME) && !S_TIME.Equals("::"))
            {
                try
                {

                    DateTime startTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(S_TIME.Substring(0, 2)), Convert.ToInt32(S_TIME.Substring(3, 2)), 00);
                    DateTime endTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                    Convert.ToInt32(DateTime.Now.ToString("HH")), Convert.ToInt32(DateTime.Now.ToString("mm")), 00);
                    TimeSpan span = endTime.Subtract(startTime);
                    minutes = Convert.ToInt32(span.TotalMinutes);
                }
                catch
                {
                    minutes = 0;
                }
                if (AR_YN1.Equals("0"))
                {
                    if (minutes >= 180 || btnCar.Location.X >= 1085)
                    {
                        btnCar.Location = new Point(1085, 68);
                    }
                    else
                    {
                        tmrBanner.Start();
                        location_car = 345 + minutes * 3 + 40;
                        btnCar.Location = new Point(location_car, 72);
                    }
                }
                else
                {
                    btnCar.Location = new Point(1085, 68);
                }
            }
            else
            {
                btnCar.Location = carorigin;
            }
        }
        private void tmrCar2_Tick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(S_TIME2) && !S_TIME2.Equals("::"))
            {
                try
                {
                    DateTime startTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(S_TIME2.Substring(0, 2)), Convert.ToInt32(S_TIME2.Substring(3, 2)), 00);
                    DateTime endTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                    Convert.ToInt32(DateTime.Now.ToString("HH")), Convert.ToInt32(DateTime.Now.ToString("mm")), 00);
                    TimeSpan span = endTime.Subtract(startTime);
                    minutes2 = Convert.ToInt32(span.TotalMinutes);
                }
                catch
                { minutes2 = 0; }
                if (AR_YN2.Equals("0"))
                {
                    if (minutes2 >= 180 || btnCar2.Location.X >= 1085)
                    {
                        btnCar2.Location = new Point(1085, 239);
                    }
                    else
                    {
                        location_car2 = 345 + minutes2 * 3 + 40;
                        btnCar2.Location = new Point(location_car2, 239);
                    }
                }
                else
                {
                    btnCar2.Location = new Point(1085, 239);
                }
            }
            else
            {
                btnCar2.Location = carorigin2;
            }
        }
        #region Gauges
        int _iStartText = 0, _iStartText2 = 0;
        private void runTextModel()
        {
            if (AR_YN1.Equals("0"))
            {
                if ((minutes != 0 && minutes <= 180 && !string.IsNullOrEmpty(minutes.ToString())) && btnCar.Location.X <= 1085)
                    scrollingLabel1(string.Concat((180 - minutes), " minutes left arrive to Vinh Cuu"));
                else if (minutes >= 180 || btnCar.Location.X >= 1085)
                    scrollingLabel1("Truck arrived at Vinh Cuu");
            }
            else
                scrollingLabel1("Truck arrived at Vinh Cuu");

        }
        private void runTextModel2()
        {
            if (AR_YN2.Equals("0"))
            {
                if ((minutes2 != 0 && minutes2 <= 180 && !string.IsNullOrEmpty(minutes2.ToString())) && btnCar2.Location.X <= 1085)
                    scrollingLabel2(string.Concat((180 - minutes2), " minutes left arrive to Long Thanh"));
                else if (minutes2 >= 180 || btnCar2.Location.X >= 1085)
                    scrollingLabel2("Truck arrived at Long Thanh");
            }
            else
                scrollingLabel2("Truck arrived at Long Thanh");

        }
        private void addTextGauge(string arg_str, Label lblDestimated1)
        {
            if (arg_str.Length <= 10)
            {
                arg_str = arg_str.PadRight(10, ' ');
            }

            if (_iStartText + 1 > arg_str.Length)
            {
                _iStartText = 0;
            }

            lblDestimated1.Text += arg_str.Substring(_iStartText, 1);
        }
        private void addTextGauge2(string arg_str, Label lblDestimated1)
        {
            if (arg_str.Length <= 20)
            {
                arg_str = arg_str.PadRight(20, ' ');
            }

            if (_iStartText2 + 1 > arg_str.Length)
            {
                _iStartText2 = 0;
            }

            lblDestimated2.Text += arg_str.Substring(_iStartText2, 1);
        }
        int iScroll = 0, iScroll2 = 0;
        private void scrollingLabel1(string strText)
        {
            iScroll = iScroll + 1;
            int iLmt = strText.Length - iScroll;
            if (iLmt < 15)
            {
                iScroll = 0;
            }
            string str = strText.Substring(iScroll, 15);
            lblDestimated1.Text = str.ToUpper();
        }
        private void scrollingLabel2(string strText)
        {
            iScroll2 = iScroll2 + 1;
            int iLmt = strText.Length - iScroll2;
            if (iLmt < 15)
            {
                iScroll2 = 0;
            }
            string str = strText.Substring(iScroll2, 15);
            lblDestimated2.Text = str.ToUpper();
        }
        #endregion

        private void tmrBanner_Tick(object sender, EventArgs e)
        {
            runTextModel();

        }
        private void tmrBanner2_Tick(object sender, EventArgs e)
        {
            runTextModel2();
        }
        private void cmdBack_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "342";
        }

        private void lblTP_VC_Ratio_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            ComVar.Var.callForm = "401";
            this.Cursor = Cursors.Default;
        }

        private void lblTP_LT_Ratio_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            ComVar.Var._Value = "phuocxechay";
            ComVar.Var.callForm = "701";
            this.Cursor = Cursors.Default;
        }


    }
}

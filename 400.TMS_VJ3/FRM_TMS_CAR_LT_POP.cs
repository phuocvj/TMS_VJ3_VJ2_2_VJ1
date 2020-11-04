using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OracleClient;
using DevExpress.XtraGrid.Views.BandedGrid;

namespace FORM
{
    public partial class FRM_TMS_CAR_LT_POP : Form
    {
     
        Point origin = new Point(550, 65);  // my origin
        Point Lighting = new Point(556, 1011);
        string MLINE = ComVar.Var._strValue2;
        public FRM_TMS_CAR_LT_POP()
        {
            InitializeComponent();
        }

        private void FRM_TMS_CAR_LT_NEW_Load(object sender, EventArgs e)
        {
            load_Data();
        }
        private void GoFullscreen()
        {
           

        }
        //#region DB


        private void load_Data()
        {
            try
            {
                splashScreenManager1.ShowWaitForm();
               
                DataTable data = Select_Ora_Grid().Tables[0];
                CreateSizeGrid(grdBase, gvwBase1, data);
                grdBase.DataSource = data;
                gvwBase1.Columns[0].OwnerBand.Width = 280;
                gvwBase1.Columns[1].OwnerBand.Width = 100;

                gvwBase1.Columns[0].OwnerBand.AppearanceHeader.BackColor = Color.FromArgb(128, 128, 128);
                gvwBase1.Columns[0].OwnerBand.AppearanceHeader.BackColor2 = Color.FromArgb(128, 128, 128);
                gvwBase1.Columns[0].OwnerBand.AppearanceHeader.ForeColor = Color.White;
                gvwBase1.Columns[1].OwnerBand.AppearanceHeader.BackColor = Color.FromArgb(128, 128, 128);
                gvwBase1.Columns[1].OwnerBand.AppearanceHeader.BackColor2 = Color.FromArgb(128, 128, 128);
                gvwBase1.Columns[1].OwnerBand.AppearanceHeader.ForeColor = Color.White;

                
               
                for (int i = 0; i < gvwBase1.Columns.Count; i++)
                {
                    gvwBase1.Columns[i].OptionsColumn.AllowEdit = false;
                    gvwBase1.Columns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gvwBase1.Columns[i].AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    gvwBase1.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gvwBase1.Columns[i].AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    gvwBase1.Columns[i].OwnerBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gvwBase1.Columns[i].OwnerBand.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    gvwBase1.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;

                 
                    if (i > 0)
                    {
                        gvwBase1.Columns[i].OwnerBand.AppearanceHeader.BackColor = Color.FromArgb(57, 190, 29);
                        gvwBase1.Columns[i].OwnerBand.AppearanceHeader.BackColor2 = Color.FromArgb(57, 190, 29);
                        gvwBase1.Columns[i].OwnerBand.AppearanceHeader.ForeColor = Color.White;


                        gvwBase1.Columns[i].OwnerBand.AppearanceHeader.BackColor = Color.FromArgb(255, 127, 0);
                        gvwBase1.Columns[i].OwnerBand.AppearanceHeader.BackColor2 = Color.FromArgb(255, 127, 0);
                        gvwBase1.Columns[i].OwnerBand.AppearanceHeader.ForeColor = Color.White;


                      //  gvwBase1.Columns[i].OwnerBand.


                        gvwBase1.Columns[i].Width = (grdBase.Width - gvwBase1.Columns[0].OwnerBand.Width) / (gvwBase1.Columns.Count - 1);
                        gvwBase1.Columns[i].OwnerBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gvwBase1.Columns[i].OwnerBand.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;

                        gvwBase1.Columns[i].OwnerBand.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                    }

                    gvwBase1.Columns[0].OwnerBand.Width = 278;
                   


                }
              
                splashScreenManager1.CloseWaitForm();
              //  gvwBase1.OptionsView.AllowCellMerge = true;
            }
            catch
            { splashScreenManager1.CloseWaitForm(); }
        }

        public void CreateSizeGrid(DevExpress.XtraGrid.GridControl gridControl, BandedGridView gridView, DataTable dt)
        {
            //gridControl.Hide();
            gridView.BeginDataUpdate();
            try
            {
                bool flag = false;
                gridView.OptionsView.ShowGroupPanel = false;
                gridView.OptionsView.AllowCellMerge = true;
                gridView.Columns.Clear();
                gridView.Bands.Clear();
                gridView.OptionsView.ShowColumnHeaders = false;
                gridView.OptionsView.ColumnAutoWidth = false;
                DevExpress.XtraGrid.Views.BandedGrid.GridBand[] band_parent = new DevExpress.XtraGrid.Views.BandedGrid.GridBand[dt.Columns.Count];
                DevExpress.XtraGrid.Views.BandedGrid.GridBand[] band_child = new DevExpress.XtraGrid.Views.BandedGrid.GridBand[dt.Columns.Count - 2];
              
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    band_parent[i] = new GridBand() { Caption = dt.Columns[i].ColumnName.ToString() };
                    gridView.Bands.Add(band_parent[i]);
                    band_parent[i].Columns.Add(new BandedGridColumn() { FieldName = dt.Columns[i].ColumnName.ToString(), Visible = true, Caption = band_parent[i].Caption });
                   
                }
                band_parent[0].RowCount = 2;
                gridView.OptionsView.ColumnAutoWidth = false;
                
            }
            catch (Exception EX)
            {
                //throw EX;
            }
            gridView.EndDataUpdate();
            gridView.ExpandAllGroups();
        }
        


        private void gvwBase1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
           

            if (e.RowHandle % 2 == 0)
            {
               // e.Appearance.BackColor = Color.FromArgb(185, 217, 249);
                e.Appearance.BackColor = Color.FromArgb(219, 251, 255);
            }
            //if (gvwBase.GetRowCellValue(e.RowHandle, "SIZE") != null)
            //{
                if (e.RowHandle > 0 && e.Column.ColumnHandle > 0 )
                {
                    if (e.CellValue.ToString() != gvwBase1.GetRowCellValue(0, e.Column).ToString())
                    {
                       
                        e.Appearance.ForeColor = Color.Red; 
                    }
                }
           // }
        }

        private void bgw_ER_Check_DoWork(object sender, DoWorkEventArgs e)
        {
            
        }

        private void cbdate_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                  load_Data();
            }
            catch
            {

            }
        }

        private void tmr_rotate_er_check_Tick(object sender, EventArgs e)
        {
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //   runTextModel();
        }

        private void runTextModel()
        {
          
        }

        private void addTextGauge(string arg_str, DevExpress.XtraGauges.Win.Gauges.Digital.DigitalGauge gauge)
        {

           
        }

        private void splMain_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public string v_Trip;
        public string v_STYLE_CD;
        public string v_CMP_CD_IN;
        public string v_date;
        public string LINE;
        public string v_LINE_CD;
        public string v_MLINE_CD;
        public string v_p_location;


        private System.Data.DataSet Select_Ora_Grid()
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                System.Data.DataSet ds_ret;

                string process_name = "MES.SP_TMS_LT_POP_SHORT";
                //ARGMODE
                MyOraDB.ReDim_Parameter(7);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "V_P_LINE";
                MyOraDB.Parameter_Name[1] = "V_P_MLINE";
                MyOraDB.Parameter_Name[2] = "V_P_YMD";
                MyOraDB.Parameter_Name[3] = "V_P_TRIP";
                MyOraDB.Parameter_Name[4] = "V_P_STYLE_CD";
                MyOraDB.Parameter_Name[5] = "V_P_LOCATION";
            //    MyOraDB.Parameter_Name[4] = "V_P_CMP_CD";
                MyOraDB.Parameter_Name[6] = "CV_1";
                // MyOraDB.Parameter_Name[3] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[4] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[5] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[6] = (char)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = v_LINE_CD;
                MyOraDB.Parameter_Values[1] = v_MLINE_CD;
                MyOraDB.Parameter_Values[2] = v_date;
                MyOraDB.Parameter_Values[3] = v_Trip;
                MyOraDB.Parameter_Values[4] = v_STYLE_CD;
                MyOraDB.Parameter_Values[5] = v_p_location;
                MyOraDB.Parameter_Values[6] = "";


                MyOraDB.Add_Select_Parameter(true);
                ds_ret = MyOraDB.Exe_Select_Procedure();
                  if (ds_ret == null)
                   return null;
                 return ds_ret;
            }
            catch
            {
                  return null;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FRM_TMS_CAR_LT_POP_VisibleChanged(object sender, EventArgs e)
        {
           
        }

       

      







    }

}

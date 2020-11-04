﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OracleClient;
using System.Reflection;
using System.Threading;

namespace MAIN
{
    public partial class RunINE : Form
    {
        public RunINE()
        {
            InitializeComponent();
            
        }

       // Dictionary<string, int> _dtn = new Dictionary<string, int>();
       // int _iFrm = 0;
        DataTable _dt = null;
        DataTable _dtXML = null;
        int _changeTime = 0;
        int _changeTimeLimit = 30;
       
        Dictionary<int, string> _dtnForm;
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
               
                _dtXML = ComVar.Func.ReadXML(Application.StartupPath + "\\Config.XML", "MAIN");
                
                 GoFullscreen(Convert.ToInt32(_dtXML.Rows[0]["Monitor"].ToString()));
      
                    

              //  run1DllForTest();
               runAllDllRegister();
                
            }
            catch (Exception ex)
            {
                ComVar.Var.writeToLog(this.Name + "/Load_Form :    " + ex.ToString());
            }
            finally
            {
                CloseSplash();
                // this.Activate();
            }


        }

        /// <summary>
        /// Run 1 form using Test
        /// </summary>
        private void run1DllForTest()
        {
            Assembly assembly = Assembly.LoadFile(Application.StartupPath + @"\DLL\TMS_VJ3.DLL");
            Type type = assembly.GetType("FORM.FRM_TMS_VJ3");

            Form form = (Form)Activator.CreateInstance(type);

            form.FormBorderStyle = FormBorderStyle.None;
            form.TopLevel = false;
            form.AutoScroll = false;
            pnMain.Controls.Add(form);
            form.Show();
        }


        #region Add Form

        private void runAllDllRegister()
        {
            try
            {
                
                if (_dtXML.Rows[0]["FlashScreen"].ToString() == "true")
                    ShowSplash();
                if (_dtXML.Rows[0]["Auto_Download"].ToString() == "true")
                {
                    Auto_Download frmDownload = new Auto_Download();
                    frmDownload.DowloadFile();
                }

                _dt = SEL_GET_FORM(_dtXML.Rows[0]["grpForm"].ToString());
                ComVar.Var.ValueChanged += new ComVar.Var.ValueChangedEventHandler(callForm);
               // _dtnForm = new Dictionary<int,string>;
                for (int i = 0; i < _dt.Rows.Count; i++)
                {
                    if (_dt.Rows[i]["SHOW_YN"].ToString() == "Y")
                    {
                        addForm(_dt.Rows[i]["DLL_NM"].ToString(), _dt.Rows[i]["CLASS_NM"].ToString());
                       // _dtnForm.Add(i,
                        // pnMain.Controls[i].Show();
                    }
                }

                ComVar.Var._Frm_Curr = pnMain.Controls[0].Name;
                pnMain.Controls[0].Show();
            }
            catch (Exception ex)
            {
                ComVar.Var.writeToLog(this.Name + "/InitForm  :   " + ex.ToString());
            }
        }

        private void addForm(string argDll, string argClass)
        {
            try
            {
                Assembly assembly = Assembly.LoadFile(Application.StartupPath + @"\DLL\" + argDll + ".DLL");
                Type type = assembly.GetType("FORM." + argClass);

                Form form = (Form)Activator.CreateInstance(type);
                form.Name = argDll.ToUpper() + "." + argClass.ToUpper();
                form.FormBorderStyle = FormBorderStyle.None;
                form.TopLevel = false;
                form.AutoScroll = false;
                pnMain.Controls.Add(form);
               // form.Show();
               // form.Hide();
               // _dtn.Add(argDll.ToUpper() + "." +argClass.ToUpper(), _iFrm);
                
               // _iFrm++;
            }
            catch (Exception ex)
            {
                ComVar.Var.writeToLog(this.Name + " :  SEPHIROTH.PROC_STB_GET_FORM   " + ex.ToString());
            }
        }
        
        private string getFormName(string argSeq)
        {
            for (int i = 0; i < _dt.Rows.Count; i++)
            {
                if (_dt.Rows[i]["SEQ"].ToString() == argSeq)
                {
                    return _dt.Rows[i]["DLL_NM"].ToString() + "." + _dt.Rows[i]["CLASS_NM"].ToString();
                }
            }
            return "";
        }

        private void callForm(string argForm)
        {
            Control ctr = null;
            string strForm = "";
            

             
            try
            {
                switch  (argForm)
                {
                    case "":
                        break;
                    case "Minimized":
                        this.WindowState = FormWindowState.Minimized;
                        break;
                    case "Closed":
                        Application.Exit();
                        break;
                    default:
                        strForm = getFormName(argForm);
                        ctr = pnMain.Controls.Find(strForm, false).FirstOrDefault();
                        if (ctr == null)
                        {
                            string[] str = strForm.Split('.');
                            addForm(str[0], str[1]);
                            pnMain.Controls.Find(strForm, false).FirstOrDefault().Show();
                        }
                        else
                            ctr.Show();
                             pnMain.Controls.Find(ComVar.Var._Frm_Curr.ToUpper(), false).FirstOrDefault().Hide();
                             ComVar.Var._Frm_Curr = strForm;
                        break;
                }
            }
            catch (Exception ex)
            {
                ComVar.Var.writeToLog(this.Name + "/callForm :    " + ex.ToString());
                return;
            }

            //try
            //{
            //    pnMain.Controls.Find(ComVar.Var._Frm_Curr.ToUpper(), false).FirstOrDefault().Hide();
            //    ComVar.Var._Frm_Curr = strForm;
            //}
            //catch (Exception ex)
            //{

            //    ComVar.Var.writeToLog(this.Name + "/callForm :    " + ex.ToString());
            //}
        }

        
        #endregion Add Form

        private void GoFullscreen(int ArgMonitor)
        {

            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Screen[] S = Screen.AllScreens;
            if (S.Length > 1)
            {
                this.Bounds = S[ArgMonitor - 1].Bounds;
            }
            else
                this.Bounds = S[0].Bounds;


        }

        #region DB
        public DataTable SEL_GET_FORM(string argGrp)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;

            try
            {
                string process_name = "SEPHIROTH.PROC_STB_GET_FORM";

                MyOraDB.ReDim_Parameter(2);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "ARG_GRP";
                MyOraDB.Parameter_Name[1] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = argGrp;
                MyOraDB.Parameter_Values[1] = "";

                MyOraDB.Add_Select_Parameter(true);
                ds_ret = MyOraDB.Exe_Select_Procedure();

                if (ds_ret == null) return null;
                return ds_ret.Tables[process_name];
            }
            catch (Exception ex)
            {
                ComVar.Var.writeToLog(this.Name + "/SEL_GET_FORM :  " + ex.ToString());
                return null;
            }
        }
        #endregion DB

        #region Flash Form
        // Thredding.
        private static Thread _splashThread;
        private static FormFlash _splashForm;


        // Show the Splash Screen (Loading...)     
        public static void ShowSplash()
        {
            try
            {
                if (_splashThread == null)
                {
                    // show the form in a new thread           
                    _splashThread = new Thread(new ThreadStart(DoShowSplash));
                    _splashThread.IsBackground = true;
                    _splashThread.Start();
                }
            }
            catch
            {}
           
        }

        // Called by the thread   
        private static void DoShowSplash()
        {
            try
            {
                if (_splashForm == null)
                {
                    _splashForm = new FormFlash();
                    _splashForm.StartPosition = FormStartPosition.CenterScreen;
                    _splashForm.TopMost = true;
                }
                // create a new message pump on this thread (started from ShowSplash)       
                Application.Run(_splashForm);
            }
            catch
            { 
            }
            
        }

        // Close the splash (Loading...) screen   
        public static void CloseSplash()
        {
            try
            {
                // Need to call on the thread that launched this splash       
                if (_splashForm.InvokeRequired)
                    _splashForm.Invoke(new MethodInvoker(CloseSplash));
                else
                    Application.ExitThread();
            }
            catch 
            {}
            
        }

        #endregion 

        private void timer1_Tick(object sender, EventArgs e)
        {
            _changeTime++;
            
        }

    }
}

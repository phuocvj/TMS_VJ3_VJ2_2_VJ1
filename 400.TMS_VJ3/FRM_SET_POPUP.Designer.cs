namespace FORM
{
    partial class FRM_SET_POPUP
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flyoutPanel1 = new DevExpress.Utils.FlyoutPanel();
            this.flyoutPanelControl1 = new DevExpress.Utils.FlyoutPanelControl();
            this.grdUpperFS_Set = new DevExpress.XtraGrid.GridControl();
            this.gvwUpperFS_Set = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ITEMS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SET_RATIO = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanel1)).BeginInit();
            this.flyoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanelControl1)).BeginInit();
            this.flyoutPanelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdUpperFS_Set)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwUpperFS_Set)).BeginInit();
            this.SuspendLayout();
            // 
            // flyoutPanel1
            // 
            this.flyoutPanel1.Controls.Add(this.flyoutPanelControl1);
            this.flyoutPanel1.Location = new System.Drawing.Point(26, 20);
            this.flyoutPanel1.Name = "flyoutPanel1";
            this.flyoutPanel1.Size = new System.Drawing.Size(975, 497);
            this.flyoutPanel1.TabIndex = 229;
            // 
            // flyoutPanelControl1
            // 
            this.flyoutPanelControl1.Controls.Add(this.grdUpperFS_Set);
            this.flyoutPanelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flyoutPanelControl1.FlyoutPanel = this.flyoutPanel1;
            this.flyoutPanelControl1.Location = new System.Drawing.Point(0, 0);
            this.flyoutPanelControl1.Name = "flyoutPanelControl1";
            this.flyoutPanelControl1.Size = new System.Drawing.Size(975, 497);
            this.flyoutPanelControl1.TabIndex = 0;
            // 
            // grdUpperFS_Set
            // 
            this.grdUpperFS_Set.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdUpperFS_Set.Font = new System.Drawing.Font("Calibri", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdUpperFS_Set.Location = new System.Drawing.Point(2, 2);
            this.grdUpperFS_Set.MainView = this.gvwUpperFS_Set;
            this.grdUpperFS_Set.Name = "grdUpperFS_Set";
            this.grdUpperFS_Set.Size = new System.Drawing.Size(971, 493);
            this.grdUpperFS_Set.TabIndex = 2;
            this.grdUpperFS_Set.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvwUpperFS_Set});
            // 
            // gvwUpperFS_Set
            // 
            this.gvwUpperFS_Set.Appearance.FooterPanel.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold);
            this.gvwUpperFS_Set.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Blue;
            this.gvwUpperFS_Set.Appearance.FooterPanel.Options.UseFont = true;
            this.gvwUpperFS_Set.Appearance.FooterPanel.Options.UseForeColor = true;
            this.gvwUpperFS_Set.Appearance.Row.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvwUpperFS_Set.Appearance.Row.Options.UseFont = true;
            this.gvwUpperFS_Set.ColumnPanelRowHeight = 35;
            this.gvwUpperFS_Set.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.ITEMS,
            this.gridColumn12,
            this.SET_RATIO});
            this.gvwUpperFS_Set.GridControl = this.grdUpperFS_Set;
            this.gvwUpperFS_Set.Name = "gvwUpperFS_Set";
            this.gvwUpperFS_Set.OptionsBehavior.AllowPixelScrolling = DevExpress.Utils.DefaultBoolean.True;
            this.gvwUpperFS_Set.OptionsBehavior.AllowSortAnimation = DevExpress.Utils.DefaultBoolean.True;
            this.gvwUpperFS_Set.OptionsBehavior.Editable = false;
            this.gvwUpperFS_Set.OptionsBehavior.ReadOnly = true;
            this.gvwUpperFS_Set.OptionsCustomization.AllowColumnMoving = false;
            this.gvwUpperFS_Set.OptionsCustomization.AllowFilter = false;
            this.gvwUpperFS_Set.OptionsCustomization.AllowGroup = false;
            this.gvwUpperFS_Set.OptionsCustomization.AllowSort = false;
            this.gvwUpperFS_Set.OptionsDetail.EnableMasterViewMode = false;
            this.gvwUpperFS_Set.OptionsView.AllowCellMerge = true;
            this.gvwUpperFS_Set.OptionsView.ShowGroupPanel = false;
            this.gvwUpperFS_Set.OptionsView.ShowIndicator = false;
            this.gvwUpperFS_Set.RowHeight = 30;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "FA_WC_CD";
            this.gridColumn7.FieldName = "FA_WC_CD";
            this.gridColumn7.Name = "gridColumn7";
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "ERP_FA_WC_CD";
            this.gridColumn8.FieldName = "ERP_FA_WC_CD";
            this.gridColumn8.Name = "gridColumn8";
            // 
            // gridColumn9
            // 
            this.gridColumn9.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn9.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn9.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn9.AppearanceHeader.Options.UseFont = true;
            this.gridColumn9.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn9.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn9.Caption = "Plant";
            this.gridColumn9.FieldName = "PLANT_NM";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 0;
            this.gridColumn9.Width = 199;
            // 
            // gridColumn10
            // 
            this.gridColumn10.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn10.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridColumn10.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn10.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn10.AppearanceHeader.Options.UseFont = true;
            this.gridColumn10.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn10.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn10.Caption = "Style Name";
            this.gridColumn10.FieldName = "STYLE_NAME";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 1;
            this.gridColumn10.Width = 199;
            // 
            // gridColumn11
            // 
            this.gridColumn11.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn11.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn11.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn11.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn11.AppearanceHeader.Options.UseFont = true;
            this.gridColumn11.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn11.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn11.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn11.Caption = "Style Code";
            this.gridColumn11.FieldName = "STYLE_CD";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 2;
            this.gridColumn11.Width = 232;
            // 
            // ITEMS
            // 
            this.ITEMS.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold);
            this.ITEMS.AppearanceHeader.Options.UseFont = true;
            this.ITEMS.AppearanceHeader.Options.UseTextOptions = true;
            this.ITEMS.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ITEMS.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.ITEMS.Caption = "Items";
            this.ITEMS.FieldName = "ITEM_CLASS";
            this.ITEMS.Name = "ITEMS";
            this.ITEMS.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.ITEMS.Visible = true;
            this.ITEMS.VisibleIndex = 3;
            this.ITEMS.Width = 64;
            // 
            // gridColumn12
            // 
            this.gridColumn12.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn12.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn12.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn12.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn12.AppearanceHeader.Options.UseFont = true;
            this.gridColumn12.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn12.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn12.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn12.Caption = "Quantity (Prs)";
            this.gridColumn12.DisplayFormat.FormatString = "{0:n0}";
            this.gridColumn12.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn12.FieldName = "QTY";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn12.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "QTY", "Total: {0:n0} Prs")});
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 4;
            this.gridColumn12.Width = 134;
            // 
            // SET_RATIO
            // 
            this.SET_RATIO.AppearanceCell.Options.UseTextOptions = true;
            this.SET_RATIO.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.SET_RATIO.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.SET_RATIO.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold);
            this.SET_RATIO.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.SET_RATIO.AppearanceHeader.Options.UseFont = true;
            this.SET_RATIO.AppearanceHeader.Options.UseForeColor = true;
            this.SET_RATIO.AppearanceHeader.Options.UseTextOptions = true;
            this.SET_RATIO.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.SET_RATIO.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.SET_RATIO.Caption = "Set Ratio";
            this.SET_RATIO.DisplayFormat.FormatString = "{0:n1}";
            this.SET_RATIO.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.SET_RATIO.FieldName = "SET_RATIO";
            this.SET_RATIO.Name = "SET_RATIO";
            this.SET_RATIO.Visible = true;
            this.SET_RATIO.VisibleIndex = 5;
            this.SET_RATIO.Width = 103;
            // 
            // FRM_SET_POPUP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 537);
            this.Controls.Add(this.flyoutPanel1);
            this.Name = "FRM_SET_POPUP";
            this.Text = "FRM_SET_POPUP";
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanel1)).EndInit();
            this.flyoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanelControl1)).EndInit();
            this.flyoutPanelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdUpperFS_Set)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwUpperFS_Set)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.FlyoutPanel flyoutPanel1;
        private DevExpress.Utils.FlyoutPanelControl flyoutPanelControl1;
        private DevExpress.XtraGrid.GridControl grdUpperFS_Set;
        private DevExpress.XtraGrid.Views.Grid.GridView gvwUpperFS_Set;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn ITEMS;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn SET_RATIO;
    }
}
namespace test2
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MapViewer = new ESRI.ArcGIS.Controls.AxMapControl();
            this.TOCControl = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.MainMap = new ESRI.ArcGIS.Controls.AxMapControl();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAddData = new System.Windows.Forms.ToolStripMenuItem();
            this.空间ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBuffer = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSpatialQuery = new System.Windows.Forms.ToolStripMenuItem();
            this.渲染ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuColor = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSymbol = new System.Windows.Forms.ToolStripMenuItem();
            this.专题图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUniqueValue = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuClassBreak = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDotDensity = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLabel = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAnnotation = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ShowWind = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStrip = new System.Windows.Forms.ToolStrip();
            this.tbnAddData = new System.Windows.Forms.ToolStripButton();
            this.tbnDefault = new System.Windows.Forms.ToolStripButton();
            this.tbnPan = new System.Windows.Forms.ToolStripButton();
            this.tbnZoomIn = new System.Windows.Forms.ToolStripButton();
            this.tbnZoomOut = new System.Windows.Forms.ToolStripButton();
            this.tbnFeatureSelect = new System.Windows.Forms.ToolStripButton();
            this.tbnIdentify = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbnFixedZoomIn = new System.Windows.Forms.ToolStripButton();
            this.tbnFixedZoomOut = new System.Windows.Forms.ToolStripButton();
            this.tbnFullExtent = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tbnClearSel = new System.Windows.Forms.ToolStripButton();
            this.tbnAttributeQuery = new System.Windows.Forms.ToolStripButton();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.coordinateLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnAddFeature = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.MapViewer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TOCControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainMap)).BeginInit();
            this.MenuStrip.SuspendLayout();
            this.ToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            this.StatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MapViewer
            // 
            this.MapViewer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.MapViewer.Location = new System.Drawing.Point(1, 311);
            this.MapViewer.Name = "MapViewer";
            this.MapViewer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("MapViewer.OcxState")));
            this.MapViewer.Size = new System.Drawing.Size(185, 143);
            this.MapViewer.TabIndex = 0;
            this.MapViewer.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.MapViewer_OnMouseDown);
            // 
            // TOCControl
            // 
            this.TOCControl.Location = new System.Drawing.Point(1, 53);
            this.TOCControl.Name = "TOCControl";
            this.TOCControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("TOCControl.OcxState")));
            this.TOCControl.Size = new System.Drawing.Size(185, 252);
            this.TOCControl.TabIndex = 2;
            this.TOCControl.OnMouseDown += new ESRI.ArcGIS.Controls.ITOCControlEvents_Ax_OnMouseDownEventHandler(this.TOCControl_OnMouseDown);
            // 
            // MainMap
            // 
            this.MainMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainMap.Location = new System.Drawing.Point(192, 53);
            this.MainMap.Name = "MainMap";
            this.MainMap.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("MainMap.OcxState")));
            this.MainMap.Size = new System.Drawing.Size(723, 401);
            this.MainMap.TabIndex = 3;
            this.MainMap.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.MainMap_OnMouseDown);
            this.MainMap.OnMouseUp += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseUpEventHandler(this.MainMap_OnMouseUp);
            this.MainMap.OnMouseMove += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseMoveEventHandler(this.MainMap_OnMouseMove);
            this.MainMap.OnAfterDraw += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnAfterDrawEventHandler(this.MainMap_OnAfterDraw);
            this.MainMap.OnExtentUpdated += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnExtentUpdatedEventHandler(this.MainMap_OnExtentUpdated);
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.空间ToolStripMenuItem,
            this.渲染ToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(917, 25);
            this.MenuStrip.TabIndex = 4;
            this.MenuStrip.Text = "MenuStrip";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAddData});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(44, 21);
            this.menuFile.Text = "文件";
            this.menuFile.ToolTipText = "文件";
            // 
            // menuAddData
            // 
            this.menuAddData.Name = "menuAddData";
            this.menuAddData.Size = new System.Drawing.Size(124, 22);
            this.menuAddData.Text = "添加数据";
            this.menuAddData.ToolTipText = "添加数据";
            this.menuAddData.Click += new System.EventHandler(this.mnuAddData);
            // 
            // 空间ToolStripMenuItem
            // 
            this.空间ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuBuffer,
            this.mnuSpatialQuery});
            this.空间ToolStripMenuItem.Name = "空间ToolStripMenuItem";
            this.空间ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.空间ToolStripMenuItem.Text = "空间";
            // 
            // mnuBuffer
            // 
            this.mnuBuffer.Name = "mnuBuffer";
            this.mnuBuffer.Size = new System.Drawing.Size(136, 22);
            this.mnuBuffer.Text = "创建缓冲区";
            this.mnuBuffer.Click += new System.EventHandler(this.mnuBuffer_Click);
            // 
            // mnuSpatialQuery
            // 
            this.mnuSpatialQuery.Name = "mnuSpatialQuery";
            this.mnuSpatialQuery.Size = new System.Drawing.Size(136, 22);
            this.mnuSpatialQuery.Text = "空间查询";
            this.mnuSpatialQuery.Click += new System.EventHandler(this.mnuSpatialQuery_Click);
            // 
            // 渲染ToolStripMenuItem
            // 
            this.渲染ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuColor,
            this.mnuSymbol,
            this.专题图ToolStripMenuItem,
            this.mnuLabel,
            this.mnuAnnotation,
            this.toolStripSeparator3,
            this.ShowWind});
            this.渲染ToolStripMenuItem.Name = "渲染ToolStripMenuItem";
            this.渲染ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.渲染ToolStripMenuItem.Text = "渲染";
            // 
            // mnuColor
            // 
            this.mnuColor.Name = "mnuColor";
            this.mnuColor.Size = new System.Drawing.Size(124, 22);
            this.mnuColor.Text = "设置颜色";
            this.mnuColor.Click += new System.EventHandler(this.mnuColor_Click);
            // 
            // mnuSymbol
            // 
            this.mnuSymbol.Name = "mnuSymbol";
            this.mnuSymbol.Size = new System.Drawing.Size(124, 22);
            this.mnuSymbol.Text = "设置符号";
            this.mnuSymbol.Click += new System.EventHandler(this.mnuSymbol_Click);
            // 
            // 专题图ToolStripMenuItem
            // 
            this.专题图ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuUniqueValue,
            this.mnuClassBreak,
            this.mnuDotDensity});
            this.专题图ToolStripMenuItem.Name = "专题图ToolStripMenuItem";
            this.专题图ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.专题图ToolStripMenuItem.Text = "专题图";
            // 
            // mnuUniqueValue
            // 
            this.mnuUniqueValue.Name = "mnuUniqueValue";
            this.mnuUniqueValue.Size = new System.Drawing.Size(173, 22);
            this.mnuUniqueValue.Text = "UniqueValue着色";
            this.mnuUniqueValue.Click += new System.EventHandler(this.mnuUniqueValue_Click);
            // 
            // mnuClassBreak
            // 
            this.mnuClassBreak.Name = "mnuClassBreak";
            this.mnuClassBreak.Size = new System.Drawing.Size(173, 22);
            this.mnuClassBreak.Text = "ClassBreak着色";
            this.mnuClassBreak.Click += new System.EventHandler(this.mnuClassBreak_Click);
            // 
            // mnuDotDensity
            // 
            this.mnuDotDensity.Name = "mnuDotDensity";
            this.mnuDotDensity.Size = new System.Drawing.Size(173, 22);
            this.mnuDotDensity.Text = "DotDensity着色";
            this.mnuDotDensity.Click += new System.EventHandler(this.mnuDotDensity_Click);
            // 
            // mnuLabel
            // 
            this.mnuLabel.Name = "mnuLabel";
            this.mnuLabel.Size = new System.Drawing.Size(124, 22);
            this.mnuLabel.Text = "标记";
            this.mnuLabel.Click += new System.EventHandler(this.mnuLabel_Click);
            // 
            // mnuAnnotation
            // 
            this.mnuAnnotation.Name = "mnuAnnotation";
            this.mnuAnnotation.Size = new System.Drawing.Size(124, 22);
            this.mnuAnnotation.Text = "标注";
            this.mnuAnnotation.Click += new System.EventHandler(this.mnuAnnotation_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(121, 6);
            // 
            // ShowWind
            // 
            this.ShowWind.Name = "ShowWind";
            this.ShowWind.Size = new System.Drawing.Size(124, 22);
            this.ShowWind.Text = "显示风场";
            this.ShowWind.Click += new System.EventHandler(this.ShowWind_Click);
            // 
            // ToolStrip
            // 
            this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbnAddData,
            this.tbnDefault,
            this.tbnPan,
            this.tbnZoomIn,
            this.tbnZoomOut,
            this.tbnFeatureSelect,
            this.tbnIdentify,
            this.toolStripSeparator1,
            this.tbnFixedZoomIn,
            this.tbnFixedZoomOut,
            this.tbnFullExtent,
            this.toolStripSeparator2,
            this.tbnClearSel,
            this.tbnAttributeQuery,
            this.btnAddFeature});
            this.ToolStrip.Location = new System.Drawing.Point(0, 25);
            this.ToolStrip.Name = "ToolStrip";
            this.ToolStrip.Size = new System.Drawing.Size(917, 25);
            this.ToolStrip.TabIndex = 5;
            this.ToolStrip.Text = "ToolStrip";
            // 
            // tbnAddData
            // 
            this.tbnAddData.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbnAddData.Image = ((System.Drawing.Image)(resources.GetObject("tbnAddData.Image")));
            this.tbnAddData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbnAddData.Name = "tbnAddData";
            this.tbnAddData.Size = new System.Drawing.Size(23, 22);
            this.tbnAddData.Text = "添加数据";
            this.tbnAddData.ToolTipText = "添加数据";
            this.tbnAddData.Click += new System.EventHandler(this.tbnAddData_Click);
            // 
            // tbnDefault
            // 
            this.tbnDefault.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbnDefault.Image = ((System.Drawing.Image)(resources.GetObject("tbnDefault.Image")));
            this.tbnDefault.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbnDefault.Name = "tbnDefault";
            this.tbnDefault.Size = new System.Drawing.Size(23, 22);
            this.tbnDefault.Text = "选择";
            this.tbnDefault.ToolTipText = "选择";
            this.tbnDefault.Click += new System.EventHandler(this.tbnDefault_Click);
            // 
            // tbnPan
            // 
            this.tbnPan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbnPan.Image = ((System.Drawing.Image)(resources.GetObject("tbnPan.Image")));
            this.tbnPan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbnPan.Name = "tbnPan";
            this.tbnPan.Size = new System.Drawing.Size(23, 22);
            this.tbnPan.Text = "漫游";
            this.tbnPan.ToolTipText = "漫游";
            this.tbnPan.Click += new System.EventHandler(this.tbnPan_Click);
            // 
            // tbnZoomIn
            // 
            this.tbnZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbnZoomIn.Image = ((System.Drawing.Image)(resources.GetObject("tbnZoomIn.Image")));
            this.tbnZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbnZoomIn.Name = "tbnZoomIn";
            this.tbnZoomIn.Size = new System.Drawing.Size(23, 22);
            this.tbnZoomIn.Text = "放大";
            this.tbnZoomIn.ToolTipText = "放大";
            this.tbnZoomIn.Click += new System.EventHandler(this.tbnZoomIn_Click);
            // 
            // tbnZoomOut
            // 
            this.tbnZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbnZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("tbnZoomOut.Image")));
            this.tbnZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbnZoomOut.Name = "tbnZoomOut";
            this.tbnZoomOut.Size = new System.Drawing.Size(23, 22);
            this.tbnZoomOut.Text = "缩小";
            this.tbnZoomOut.ToolTipText = "缩小";
            this.tbnZoomOut.Click += new System.EventHandler(this.tbnZoomOut_Click);
            // 
            // tbnFeatureSelect
            // 
            this.tbnFeatureSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbnFeatureSelect.Image = ((System.Drawing.Image)(resources.GetObject("tbnFeatureSelect.Image")));
            this.tbnFeatureSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbnFeatureSelect.Name = "tbnFeatureSelect";
            this.tbnFeatureSelect.Size = new System.Drawing.Size(23, 22);
            this.tbnFeatureSelect.Text = "Feature Select";
            this.tbnFeatureSelect.ToolTipText = "Feature Select";
            this.tbnFeatureSelect.Click += new System.EventHandler(this.tbnFeatureSelect_Click);
            // 
            // tbnIdentify
            // 
            this.tbnIdentify.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbnIdentify.Image = ((System.Drawing.Image)(resources.GetObject("tbnIdentify.Image")));
            this.tbnIdentify.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbnIdentify.Name = "tbnIdentify";
            this.tbnIdentify.Size = new System.Drawing.Size(23, 22);
            this.tbnIdentify.Text = "Identify";
            this.tbnIdentify.ToolTipText = "Identify";
            this.tbnIdentify.Click += new System.EventHandler(this.tbnIdentify_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tbnFixedZoomIn
            // 
            this.tbnFixedZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbnFixedZoomIn.Image = ((System.Drawing.Image)(resources.GetObject("tbnFixedZoomIn.Image")));
            this.tbnFixedZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbnFixedZoomIn.Name = "tbnFixedZoomIn";
            this.tbnFixedZoomIn.Size = new System.Drawing.Size(23, 22);
            this.tbnFixedZoomIn.Text = "中心放大";
            this.tbnFixedZoomIn.ToolTipText = "中心放大";
            this.tbnFixedZoomIn.Click += new System.EventHandler(this.tbnFixedZoomIn_Click);
            // 
            // tbnFixedZoomOut
            // 
            this.tbnFixedZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbnFixedZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("tbnFixedZoomOut.Image")));
            this.tbnFixedZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbnFixedZoomOut.Name = "tbnFixedZoomOut";
            this.tbnFixedZoomOut.Size = new System.Drawing.Size(23, 22);
            this.tbnFixedZoomOut.Text = "中心缩小";
            this.tbnFixedZoomOut.ToolTipText = "中心缩小";
            this.tbnFixedZoomOut.Click += new System.EventHandler(this.tbnFixedZoomOut_Click);
            // 
            // tbnFullExtent
            // 
            this.tbnFullExtent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbnFullExtent.Image = ((System.Drawing.Image)(resources.GetObject("tbnFullExtent.Image")));
            this.tbnFullExtent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbnFullExtent.Name = "tbnFullExtent";
            this.tbnFullExtent.Size = new System.Drawing.Size(23, 22);
            this.tbnFullExtent.Text = "全图";
            this.tbnFullExtent.ToolTipText = "全图";
            this.tbnFullExtent.Click += new System.EventHandler(this.tbnFullExtent_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tbnClearSel
            // 
            this.tbnClearSel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbnClearSel.Image = ((System.Drawing.Image)(resources.GetObject("tbnClearSel.Image")));
            this.tbnClearSel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbnClearSel.Name = "tbnClearSel";
            this.tbnClearSel.Size = new System.Drawing.Size(23, 22);
            this.tbnClearSel.Text = "清除选择";
            this.tbnClearSel.Click += new System.EventHandler(this.tbnClearSel_Click);
            // 
            // tbnAttributeQuery
            // 
            this.tbnAttributeQuery.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbnAttributeQuery.Image = ((System.Drawing.Image)(resources.GetObject("tbnAttributeQuery.Image")));
            this.tbnAttributeQuery.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbnAttributeQuery.Name = "tbnAttributeQuery";
            this.tbnAttributeQuery.Size = new System.Drawing.Size(23, 22);
            this.tbnAttributeQuery.Text = "属性查询";
            this.tbnAttributeQuery.ToolTipText = "属性查询";
            this.tbnAttributeQuery.Click += new System.EventHandler(this.tbnAttributeQuery_Click);
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(492, 246);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 6;
            // 
            // StatusStrip
            // 
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.coordinateLabel});
            this.StatusStrip.Location = new System.Drawing.Point(0, 457);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(917, 22);
            this.StatusStrip.TabIndex = 7;
            this.StatusStrip.Text = "StatusStrip";
            // 
            // coordinateLabel
            // 
            this.coordinateLabel.Name = "coordinateLabel";
            this.coordinateLabel.Size = new System.Drawing.Size(44, 17);
            this.coordinateLabel.Text = "坐标：";
            // 
            // btnAddFeature
            // 
            this.btnAddFeature.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddFeature.Image = ((System.Drawing.Image)(resources.GetObject("btnAddFeature.Image")));
            this.btnAddFeature.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddFeature.Name = "btnAddFeature";
            this.btnAddFeature.Size = new System.Drawing.Size(23, 22);
            this.btnAddFeature.Text = "添加要素";
            this.btnAddFeature.Click += new System.EventHandler(this.btnAddFeature_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 479);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.axLicenseControl1);
            this.Controls.Add(this.ToolStrip);
            this.Controls.Add(this.MainMap);
            this.Controls.Add(this.TOCControl);
            this.Controls.Add(this.MapViewer);
            this.Controls.Add(this.MenuStrip);
            this.MainMenuStrip = this.MenuStrip;
            this.Name = "MainForm";
            this.Text = "ArcGIS二次开发";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MapViewer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TOCControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainMap)).EndInit();
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.ToolStrip.ResumeLayout(false);
            this.ToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ESRI.ArcGIS.Controls.AxMapControl MapViewer;
        private ESRI.ArcGIS.Controls.AxTOCControl TOCControl;
        private ESRI.ArcGIS.Controls.AxMapControl MainMap;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStrip ToolStrip;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuAddData;
        private System.Windows.Forms.ToolStripButton tbnAddData;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel coordinateLabel;
        private System.Windows.Forms.ToolStripButton tbnDefault;
        private System.Windows.Forms.ToolStripButton tbnPan;
        private System.Windows.Forms.ToolStripButton tbnZoomIn;
        private System.Windows.Forms.ToolStripButton tbnZoomOut;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tbnFixedZoomIn;
        private System.Windows.Forms.ToolStripButton tbnFixedZoomOut;
        private System.Windows.Forms.ToolStripButton tbnFullExtent;
        private System.Windows.Forms.ToolStripButton tbnFeatureSelect;
        private System.Windows.Forms.ToolStripButton tbnIdentify;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tbnClearSel;
        private System.Windows.Forms.ToolStripButton tbnAttributeQuery;
        private System.Windows.Forms.ToolStripMenuItem 空间ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuBuffer;
        private System.Windows.Forms.ToolStripMenuItem mnuSpatialQuery;
        private System.Windows.Forms.ToolStripMenuItem 渲染ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuColor;
        private System.Windows.Forms.ToolStripMenuItem mnuSymbol;
        private System.Windows.Forms.ToolStripMenuItem 专题图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuUniqueValue;
        private System.Windows.Forms.ToolStripMenuItem mnuClassBreak;
        private System.Windows.Forms.ToolStripMenuItem mnuDotDensity;
        private System.Windows.Forms.ToolStripMenuItem mnuLabel;
        private System.Windows.Forms.ToolStripMenuItem mnuAnnotation;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem ShowWind;
        private System.Windows.Forms.ToolStripButton btnAddFeature;
    }
}


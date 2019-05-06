using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display; 

namespace test2
{
    public partial class MainForm : Form
    {
        private IEnvelope m_pEnvelope = null;
        private GISTool m_curTool = GISTool.Default;
        private ESRI.ArcGIS.Controls.ControlsSelectFeaturesToolClass m_selectTool = new ControlsSelectFeaturesToolClass();

        public MainForm()
        {
            InitializeComponent();
        }
        
        private void MainForm_Load(object sender, EventArgs e)
        {
            TOCControl.SetBuddyControl(MainMap);
            TOCControl.EnableLayerDragDrop = true;

            ContextMenuStrip tocContextMenuStrip = new System.Windows.Forms.ContextMenuStrip();
            TOCControl.ContextMenuStrip = tocContextMenuStrip;

            TOCControl.ContextMenuStrip.Items.Add("缩放到图层", null, TOCContextMenuItem_ZoomToLayer);
            TOCControl.ContextMenuStrip.Items.Add("删除图层", null, TOCContextMenuItem_RemoveLayer);

            m_selectTool.OnCreate(MainMap.Object);
        }

        private void tbnAddData_Click(object sender, EventArgs e)
        {   //添加数据
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = "shp";
            openFileDialog.Filter = "shp 文件|*.shp";

            if (DialogResult.OK != openFileDialog.ShowDialog()) return;

            // 得到Shapefile文件所在的目录.
            string strDir = System.IO.Path.GetDirectoryName(openFileDialog.FileName);
            // 得到Shapefile文件的名字,.shp后缀.
            string strShpFile = System.IO.Path.GetFileNameWithoutExtension(openFileDialog.FileName);

            IWorkspaceFactory pWSF = new ShapefileWorkspaceFactory();
            IPropertySet pPropertySet = new PropertySetClass();
            pPropertySet.SetProperty("DATABASE", strDir);

            try
            {
                IWorkspace pWorkspace = pWSF.Open(pPropertySet, 0);
                IFeatureWorkspace pFeatureWorkspace = pWorkspace as IFeatureWorkspace;
                IFeatureClass pFeatureClass = pFeatureWorkspace.OpenFeatureClass(strShpFile);
                IFeatureLayer pFeatureLayer = new FeatureLayerClass();
                pFeatureLayer.FeatureClass = pFeatureClass;
                pFeatureLayer.Name = pFeatureClass.AliasName;
                MainMap.AddLayer(pFeatureLayer as ILayer);
                MapViewer.AddLayer(pFeatureLayer as ILayer);
            }
            catch (COMException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void mnuAddData(object sender, EventArgs e)
        {
            tbnAddData_Click(sender, e);
        }

        private void MainMap_OnExtentUpdated(object sender, IMapControlEvents2_OnExtentUpdatedEvent e)
        {
            MapViewer.ActiveView.Refresh();
            m_pEnvelope = e.newEnvelope as IEnvelope;
        }

        private void MainMap_OnAfterDraw(object sender, IMapControlEvents2_OnAfterDrawEvent e)
        {
            // 绘制红色鹰眼框
            object pSym = null;
            SimpleLineSymbol pOutlineSym;
            IRgbColor pColor;

            pColor = new RgbColorClass();
            pColor.Red = 255;
            pColor.Blue = 0;
            pColor.Green = 0;
            pSym = new SimpleFillSymbolClass();
            ISimpleFillSymbol pSym1 = pSym as ISimpleFillSymbol;
            pSym1.Style = esriSimpleFillStyle.esriSFSHollow;

            pOutlineSym = new SimpleLineSymbolClass();
            pOutlineSym.Width = 1;
            pOutlineSym.Style = esriSimpleLineStyle.esriSLSSolid;
            pOutlineSym.Color = pColor;
            pSym1.Outline = pOutlineSym;

            if (m_pEnvelope == null) return;
            MapViewer.DrawShape(m_pEnvelope as IGeometry, ref pSym);
        }

        private void MapViewer_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            ESRI.ArcGIS.Geometry.Point pPoint = new ESRI.ArcGIS.Geometry.PointClass();
            pPoint.PutCoords(e.mapX, e.mapY);
            MainMap.CenterAt(pPoint);
        }

        private void MainMap_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            coordinateLabel.Text = "坐标 X = " + e.mapX.ToString("F6") + "  Y = " + e.mapY.ToString("F6");

            switch (m_curTool)
            {
                case GISTool.Select:
                    m_selectTool.OnMouseMove(e.button, e.shift, e.x, e.y);
                    break;
            }
        }

        private void tbnDefault_Click(object sender, EventArgs e)
        {
            MainMap.MousePointer = esriControlsMousePointer.esriPointerDefault;
            m_curTool = GISTool.Default; 
        }

        private void tbnPan_Click(object sender, EventArgs e)
        {
            MainMap.MousePointer = esriControlsMousePointer.esriPointerPan;
            m_curTool = GISTool.Pan;
        }

        private void tbnZoomIn_Click(object sender, EventArgs e)
        {
            MainMap.MousePointer = esriControlsMousePointer.esriPointerZoomIn;
            m_curTool = GISTool.ZoomIn;
        }

        private void tbnZoomOut_Click(object sender, EventArgs e)
        {
            MainMap.MousePointer = esriControlsMousePointer.esriPointerZoomOut;
            m_curTool = GISTool.ZoomOut;
        }

        private void tbnFixedZoomIn_Click(object sender, EventArgs e)
        {
            IEnvelope pEnvelope = MainMap.ActiveView.Extent;
            pEnvelope.Expand(0.5, 0.5, true);
            MainMap.ActiveView.Extent = pEnvelope;
            MainMap.ActiveView.Refresh();
        }

        private void tbnFixedZoomOut_Click(object sender, EventArgs e)
        {
            IEnvelope pEnvelope = MainMap.ActiveView.Extent;
            pEnvelope.Expand(1.5, 1.5, true);
            MainMap.ActiveView.Extent = pEnvelope;
            MainMap.ActiveView.Refresh();
        }

        private void tbnFullExtent_Click(object sender, EventArgs e)
        {
            IEnvelope pEnvelope = MainMap.ActiveView.FullExtent;
            MainMap.ActiveView.Extent = pEnvelope;
            MainMap.ActiveView.Refresh();
        }

        private void MainMap_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            IEnvelope pEnvelope = null;

            switch (m_curTool)
            {
                case GISTool.Default:

                    break;

                case GISTool.ZoomIn:
                    pEnvelope = MainMap.TrackRectangle();
                    MainMap.ActiveView.Extent = pEnvelope;
                    MainMap.ActiveView.Refresh();
                    break;

                case GISTool.ZoomOut:
                    pEnvelope = MainMap.TrackRectangle();
                    IMap pMap = MainMap.Map;
                    IActiveView pActiveView = pMap as IActiveView;
                    double newWidth = pActiveView.Extent.Width * (pActiveView.Extent.Width / pEnvelope.Width);
                    double newHeight = pActiveView.Extent.Height * (pActiveView.Extent.Height / pEnvelope.Height);

                    IEnvelope pEnvelope1 = new EnvelopeClass();
                    pEnvelope1.PutCoords(pActiveView.Extent.XMin - ((pEnvelope.XMin - pActiveView.Extent.XMin) * (pActiveView.Extent.Width / pEnvelope.Width)),
                       pActiveView.Extent.YMin - ((pEnvelope.YMin - pActiveView.Extent.YMin) * (pActiveView.Extent.Height / pEnvelope.Height)),
                      (pActiveView.Extent.XMin - ((pEnvelope.XMin - pActiveView.Extent.XMin) * (pActiveView.Extent.Width / pEnvelope.Width))) + newWidth,
                    (pActiveView.Extent.YMin - ((pEnvelope.YMin - pActiveView.Extent.YMin) * (pActiveView.Extent.Height / pEnvelope.Height))) + newHeight);

                    pActiveView.Extent = pEnvelope1;
                    pActiveView.Refresh();
                    break;

                case GISTool.Pan:
                    MainMap.Pan();
                    break;

                case GISTool.Select:
                    m_selectTool.OnMouseDown(e.button, e.shift, e.x, e.y);
                    break;

                case GISTool.Identify:
                    AOUtil.Identify(MainMap, e.x, e.y);
                    break;
            }
        }

        private void tbnFeatureSelect_Click(object sender, EventArgs e)
        {
            MainMap.MousePointer = esriControlsMousePointer.esriPointerArrowQuestion;
            m_curTool = GISTool.Select; 
        }

        private void tbnIdentify_Click(object sender, EventArgs e)
        {
            MainMap.MousePointer = esriControlsMousePointer.esriPointerIdentify;
            m_curTool = GISTool.Identify; 
        }

        private void MainMap_OnMouseUp(object sender, IMapControlEvents2_OnMouseUpEvent e)
        {
            switch (m_curTool)
            {
                case GISTool.Select:
                    m_selectTool.OnMouseUp(e.button, e.shift, e.x, e.y);
                    break;
            }
        }

        private void tbnClearSel_Click(object sender, EventArgs e)
        {
            MainMap.Map.ClearSelection();
            MainMap.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, MainMap.Extent);
        }

        private void tbnAttributeQuery_Click(object sender, EventArgs e)
        {
            QueryForm fm = new QueryForm(MainMap);
            fm.Show(); 
        }

        private void mnuBuffer_Click(object sender, EventArgs e)
        {
            BufferForm fm = new BufferForm(MainMap);
            fm.Show(); 
        }

        private void mnuSpatialQuery_Click(object sender, EventArgs e)
        {
            SpatialQueryForm fm = new SpatialQueryForm(MainMap);
            fm.Show(); 
        }

        private void mnuColor_Click(object sender, EventArgs e)
        {
            ILayer pLayer = MainMap.get_Layer(0);

            IGeoFeatureLayer pGeoFeatureLayer = pLayer as IGeoFeatureLayer;
            IFeatureRenderer pFeatureRender = pGeoFeatureLayer.Renderer;
            ISimpleRenderer pSimpleRender = pFeatureRender as ISimpleRenderer;
            ISimpleFillSymbol pSym = pSimpleRender.Symbol as ISimpleFillSymbol;

            IRgbColor pRGBColor = new RgbColorClass();
            pRGBColor.Red = 200;
            pRGBColor.Green = 10;
            pRGBColor.Blue = 50;

            pSym.Color = pRGBColor as IColor;
            MainMap.ActiveView.Refresh();
        }

        private void mnuSymbol_Click(object sender, EventArgs e)
        {
            ILayer pLayer = MainMap.get_Layer(0);

            IGeoFeatureLayer pGeoFeatureLayer = pLayer as IGeoFeatureLayer;
            IFeatureRenderer pFeatureRender = pGeoFeatureLayer.Renderer;
            ISimpleRenderer pSimpleRender = pFeatureRender as ISimpleRenderer;

            ILineFillSymbol pLineFillSymbol = new LineFillSymbolClass();
            ILineSymbol pLineSymbol = new SimpleLineSymbolClass();

            IRgbColor pRgbColor = new RgbColorClass();
            pRgbColor.Red = 96;
            pRgbColor.Green = 96;
            pRgbColor.Blue = 196;

            pLineSymbol.Color = pRgbColor as IColor;
            pLineSymbol.Width = 2;
            pLineFillSymbol.LineSymbol = pLineSymbol;
            pLineFillSymbol.Outline = pLineSymbol;

            pSimpleRender.Symbol = pLineFillSymbol as ISymbol;
            MainMap.ActiveView.Refresh(); 
        }

        private void mnuUniqueValue_Click(object sender, EventArgs e)
        {
            ILayer pLayer = MainMap.get_Layer(0);
            ITable pTable = pLayer as ITable;

            IUniqueValueRenderer pUniqueValueRender = new UniqueValueRendererClass();
            pUniqueValueRender.FieldCount = 1;
            pUniqueValueRender.set_Field(0, "ADCODE99");

            int fldIndex = pTable.Fields.FindField("ADCODE99");

            // 产生一个随机的色带
            IRandomColorRamp pColorRamp = new RandomColorRampClass();
            pColorRamp.StartHue = 0;
            pColorRamp.MinValue = 99;
            pColorRamp.MinSaturation = 15;
            pColorRamp.EndHue = 360;
            pColorRamp.MaxValue = 100;
            pColorRamp.MinSaturation = 30;

            // 任意产生50种颜色
            pColorRamp.Size = 50;

            bool bOK;
            pColorRamp.CreateRamp(out bOK);

            IEnumColors pEnumRamp = pColorRamp.Colors;
            IColor pNextUniqueColor = null;

            IQueryFilter pQueryFilter = new QueryFilterClass();
            pQueryFilter.AddField("ADCODE99");

            ICursor pCursor = pTable.Search(pQueryFilter, true);
            IRow pRow = pCursor.NextRow();
            while (pRow != null)
            {
                IRowBuffer pRowBuffer = pRow as IRowBuffer;
                System.Object cValue = pRowBuffer.get_Value(fldIndex);

                pNextUniqueColor = pEnumRamp.Next();
                if (pNextUniqueColor == null)
                {
                    pEnumRamp.Reset();
                    pNextUniqueColor = pEnumRamp.Next();
                }


                ISimpleFillSymbol pSym = new SimpleFillSymbolClass();
                pSym.Color = pNextUniqueColor;

                pUniqueValueRender.AddValue(cValue.ToString(), "", pSym as ISymbol);
                pRow = pCursor.NextRow();
            }

            IGeoFeatureLayer pGeoFeatureLayer = pLayer as IGeoFeatureLayer;
            pGeoFeatureLayer.Renderer = pUniqueValueRender as IFeatureRenderer;
            MainMap.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
        }

        private void mnuClassBreak_Click(object sender, EventArgs e)
        {
            ILayer pLayer = MainMap.get_Layer(0);
            ITable pTable = pLayer as ITable;
            IGeoFeatureLayer pGeoFeatureLayer = pLayer as IGeoFeatureLayer;

            int classCount = 6;
            ITableHistogram pTableHistogram;
            IBasicHistogram pBasicHistogram;

            pTableHistogram = new BasicTableHistogramClass();
            //按照 数值字段分级
            pTableHistogram.Table = pTable;
            pTableHistogram.Field = "AREA";
            pBasicHistogram = pTableHistogram as IBasicHistogram;

            object values;
            object frequencys;
            //先统计每个值和各个值出现的次数
            pBasicHistogram.GetHistogram(out values, out frequencys);
            //创建等间距分级对象
            IClassifyGEN classifyGEN = new EqualIntervalClass();
            //用统计结果进行分级 ，级别数目为classCount
            classifyGEN.Classify(values, frequencys, ref classCount);
            //获得分级结果,是个 双精度类型数组 
            double[] classes;
            classes = classifyGEN.ClassBreaks as double[];

            IEnumColors enumColors = CreateAlgorithmicColorRamp(classes.Length).Colors;
            IColor pColor;

            IClassBreaksRenderer pClassBreaksRenderer = new ClassBreaksRendererClass();
            pClassBreaksRenderer.Field = "AREA";
            pClassBreaksRenderer.BreakCount = classCount;
            pClassBreaksRenderer.SortClassesAscending = true;

            ISimpleFillSymbol simpleFillSymbol;
            for (int i = 0; i < classes.Length - 1; i++)
            {
                pColor = enumColors.Next();
                simpleFillSymbol = new SimpleFillSymbolClass();
                simpleFillSymbol.Color = pColor;
                simpleFillSymbol.Style = esriSimpleFillStyle.esriSFSSolid;

                pClassBreaksRenderer.set_Symbol(i, simpleFillSymbol as ISymbol);
                pClassBreaksRenderer.set_Break(i, classes[i + 1]);
            }

            pGeoFeatureLayer.Renderer = pClassBreaksRenderer as IFeatureRenderer;
            MainMap.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null); 
        }

        private void mnuDotDensity_Click(object sender, EventArgs e)
        {
            ILayer pLayer = MainMap.get_Layer(0);
            ITable pTable = pLayer as ITable;
            IGeoFeatureLayer pGeoFeatureLayer = pLayer as IGeoFeatureLayer;

            IDotDensityRenderer pDotDensityRender = new DotDensityRendererClass();
            IRendererFields pRendererFields = pDotDensityRender as IRendererFields;
            pRendererFields.AddField("AREA");

            // 建立一个用于填充的点符号
            IDotDensityFillSymbol pDotDensityFillSymbol = new DotDensityFillSymbolClass();
            pDotDensityFillSymbol.DotSize = 3;

            IRgbColor pRgbColor = new RgbColorClass();
            pRgbColor.Red = 0;
            pRgbColor.Green = 0;
            pRgbColor.Blue = 0;

            IColor pColor = pRgbColor as IColor;
            pDotDensityFillSymbol.Color = pColor;

            pRgbColor = new RgbColorClass();
            pRgbColor.Red = 239;
            pRgbColor.Green = 228;
            pRgbColor.Blue = 190;
            pColor = pRgbColor as IColor;
            pDotDensityFillSymbol.BackgroundColor = pColor;

            ISymbolArray pSymbolArray = pDotDensityFillSymbol as ISymbolArray;
            ISimpleMarkerSymbol pMarkerSymbol = new SimpleMarkerSymbolClass();
            pMarkerSymbol.Style = esriSimpleMarkerStyle.esriSMSSquare;

            pRgbColor = new RgbColorClass();
            pRgbColor.Red = 0;
            pRgbColor.Green = 0;
            pRgbColor.Blue = 0;
            pColor = pRgbColor as IColor;
            pMarkerSymbol.Color = pColor;
            pSymbolArray.AddSymbol(pMarkerSymbol as ISymbol);

            // 开始着色
            pDotDensityRender.DotDensitySymbol = pDotDensityFillSymbol;
            pDotDensityRender.DotValue = 2;
            pGeoFeatureLayer.Renderer = pDotDensityRender as IFeatureRenderer;
            MainMap.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
        }

        //创建颜色带
        private IColorRamp CreateAlgorithmicColorRamp(int count)
        {
            //创建一个新AlgorithmicColorRampClass对象
            IAlgorithmicColorRamp algColorRamp = new AlgorithmicColorRampClass();
            IRgbColor fromColor = new RgbColorClass();
            IRgbColor toColor = new RgbColorClass();
            //创建起始颜色对象
            fromColor.Red = 255;
            fromColor.Green = 0;
            fromColor.Blue = 0;
            //创建终止颜色对象           
            toColor.Red = 0;
            toColor.Green = 0;
            toColor.Blue = 255;
            //设置AlgorithmicColorRampClass的起止颜色属性
            algColorRamp.ToColor = fromColor;
            algColorRamp.FromColor = toColor;
            //设置梯度类型
            algColorRamp.Algorithm = esriColorRampAlgorithm.esriCIELabAlgorithm;
            //设置颜色带颜色数量
            algColorRamp.Size = count;
            //创建颜色带
            bool bture = true;
            algColorRamp.CreateRamp(out bture);
            return algColorRamp;
        }

        private void mnuLabel_Click(object sender, EventArgs e)
        {
            IGraphicsContainer pGraphicsContainer = MainMap.Map as IGraphicsContainer;
            ILayer pLayer = MainMap.get_Layer(0);
            IFeatureLayer pFeatureLayer = pLayer as IFeatureLayer;
            IFeatureClass pFeatureClass = pFeatureLayer.FeatureClass;

            int fldIndex = pFeatureClass.Fields.FindField("ADCODE93");

            IFeatureCursor pFeatureCursor = pFeatureClass.Search(null, false);
            IFeature pFeature = pFeatureCursor.NextFeature();
            while (pFeature != null)
            {
                IEnvelope pEnvelope = pFeature.Shape.Envelope;
                IPoint pPoint = new PointClass();
                pPoint.PutCoords(pEnvelope.XMin + pEnvelope.Width / 2, pEnvelope.YMin + pEnvelope.Height / 2);

                stdole.IFontDisp pFont = new stdole.StdFontClass() as stdole.IFontDisp;
                pFont.Name = "宋体";
                pFont.Size = 9;

                IRgbColor pColor = new RgbColorClass();
                pColor.Red = 110;
                pColor.Blue = 200;
                pColor.Green = 60;

                ITextSymbol pTextSymbol = new TextSymbolClass();
                pTextSymbol.Font = pFont;
                pTextSymbol.Color = pColor as IColor;

                ITextElement pTextElement = new TextElementClass();
                pTextElement.Text = pFeature.get_Value(fldIndex).ToString();
                pTextElement.ScaleText = true;
                pTextElement.Symbol = pTextSymbol;
                IElement pElement = pTextElement as IElement;
                pElement.Geometry = pPoint;
                pGraphicsContainer.AddElement(pElement, 0);

                pFeature = pFeatureCursor.NextFeature();
            }
            System.Runtime.InteropServices.Marshal.ReleaseComObject(pFeatureCursor);
            GC.Collect();
            GC.WaitForPendingFinalizers();

            MainMap.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }

        private void mnuAnnotation_Click(object sender, EventArgs e)
        {
            IGraphicsContainer pGraphicsContainer = MainMap.Map as IGraphicsContainer;
            ILayer pLayer = MainMap.get_Layer(0);
            IGeoFeatureLayer pGeoFeatureLayer = pLayer as IGeoFeatureLayer;

            // 清空当前图层标注集合
            IAnnotateLayerPropertiesCollection pAnnoProps = pGeoFeatureLayer.AnnotationProperties;
            pAnnoProps.Clear();

            // 建立标注文本符号
            stdole.IFontDisp pFont = new stdole.StdFontClass() as stdole.IFontDisp;
            pFont.Name = "宋体";
            pFont.Size = 9;

            IRgbColor pColor = new RgbColorClass();
            pColor.Red = 250;
            pColor.Blue = 10;
            pColor.Green = 50;

            ITextSymbol pTextSymbol = new TextSymbolClass();
            pTextSymbol.Font = pFont;
            pTextSymbol.Color = pColor as IColor;

            // 设置标注位置
            ILineLabelPosition pPosition = new LineLabelPositionClass();
            pPosition.Parallel = false;
            pPosition.Perpendicular = false;

            ILineLabelPlacementPriorities pPlacement = new LineLabelPlacementPrioritiesClass();
            IBasicOverposterLayerProperties pBasic = new BasicOverposterLayerProperties();
            pBasic.FeatureType = esriBasicOverposterFeatureType.esriOverposterPolyline;
            pBasic.LineLabelPosition = pPosition;

            // 新建一个图层标注引擎对象
            ILabelEngineLayerProperties pLabelEngine = new LabelEngineLayerPropertiesClass();
            pLabelEngine.Symbol = pTextSymbol;
            pLabelEngine.BasicOverposterLayerProperties = pBasic;
            pLabelEngine.IsExpressionSimple = true;
            pLabelEngine.Expression = "[ADCODE93]";
            IAnnotateLayerProperties pAnnoLayerProps = pLabelEngine as IAnnotateLayerProperties;
            pAnnoProps.Add(pAnnoLayerProps);
            pGeoFeatureLayer.DisplayAnnotation = true;

            MainMap.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }

        private void ShowWind_Click(object sender, EventArgs e)
        {
            ILayer pLayer = MainMap.get_Layer(0);
            IFeatureLayer pFeatureLayer = pLayer as IFeatureLayer;
            IFeatureClass pFeatureClass = pFeatureLayer.FeatureClass;

            int indexDir = pFeatureClass.Fields.FindField("Dir");
            int indexSpeed = pFeatureClass.Fields.FindField("Speed");

            ISymbol pSymbol = AOUtil.FetchSymbol("dir");
            IGeoFeatureLayer pGeoFeatureLayer = pFeatureLayer as IGeoFeatureLayer;
            ISimpleRenderer pSimpleRenderer = pGeoFeatureLayer.Renderer as ISimpleRenderer;
            pSimpleRenderer.Symbol = pSymbol;

            IRotationRenderer pRotationRender = pSimpleRenderer as IRotationRenderer;
            pRotationRender.RotationField = "dir";

            ISizeRenderer pSizeRender = pSimpleRenderer as ISizeRenderer;
            pSizeRender.SizeRendererExpression = "[Speed]";
            pSizeRender.SizeRendererFlags = 1;

            MainMap.Refresh();
        }

        private void btnAddFeature_Click(object sender, EventArgs e)
        {
            IPoint pPoint1 = new PointClass();
            pPoint1.PutCoords(82.1935, 21.5459);

            IPoint pPoint2 = new PointClass();
            pPoint2.PutCoords(89.0913, 21.6609);

            IPoint pPoint3 = new PointClass();
            pPoint3.PutCoords(88.9763, 15.6828);

            IPoint pPoint4 = new PointClass();
            pPoint4.PutCoords(79.7793, 15.5679);

            // 创建一个环
            IRing pRing = new RingClass(); 
            ISegmentCollection pSegmentCollection = pRing as ISegmentCollection; 
            
            object Missing1 = Type.Missing;
            object Missing2 = Type.Missing;
 
            ILine pLine = new LineClass();
            pLine.PutCoords(pPoint1, pPoint2);
            pSegmentCollection.AddSegment(pLine as ISegment, ref Missing1, ref Missing2);

            pLine = new LineClass();
            pLine.PutCoords(pPoint2, pPoint3);
            pSegmentCollection.AddSegment(pLine as ISegment, ref Missing1, ref Missing2);

            pLine = new LineClass();
            pLine.PutCoords(pPoint3, pPoint4);
            pSegmentCollection.AddSegment(pLine as ISegment, ref Missing1, ref Missing2);

            pLine = new LineClass();
            pLine.PutCoords(pPoint4, pPoint1);
            pSegmentCollection.AddSegment(pLine as ISegment, ref Missing1, ref Missing2);

            pRing.Close();
 
            // 创建多边形
            IPolygon pPolygon = new PolygonClass();
            IGeometryCollection pGeometryCollection = pPolygon as IGeometryCollection;
            pGeometryCollection.AddGeometry(pRing, ref Missing1, ref Missing2);

            // 显示多边形
            ISimpleFillSymbol pSimpleFillSymbol = new SimpleFillSymbolClass();
            IRgbColor pColor = new RgbColorClass();
            pColor.Red = 255;
            pColor.Blue = 0;
            pColor.Green = 0;

            pSimpleFillSymbol.Style = esriSimpleFillStyle.esriSFSDiagonalCross;
            pSimpleFillSymbol.Color = pColor;

            IFillShapeElement pFillShapeElement = new PolygonElementClass();
            pFillShapeElement.Symbol = pSimpleFillSymbol;

            IElement pElement = pFillShapeElement as IElement;
            pElement.Geometry = pPolygon as IGeometry;

            IGraphicsContainer pGraphicsContainer = MainMap.Map as IGraphicsContainer;
            pGraphicsContainer.AddElement(pElement, 0);
            MainMap.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }

        private void TOCContextMenuItem_RemoveLayer(object sender, EventArgs e)
        {
            ESRI.ArcGIS.Controls.esriTOCControlItem pItem = ESRI.ArcGIS.Controls.esriTOCControlItem.esriTOCControlItemNone;
            ESRI.ArcGIS.Carto.ILayer pLayer = null;
            ESRI.ArcGIS.Carto.IBasicMap pMap = null;
            object pIndex = null;
            object pOther = null;

            TOCControl.GetSelectedItem(ref pItem, ref pMap, ref pLayer, ref pIndex, ref pOther);
            if (pLayer != null)
            {
                MainMap.Map.DeleteLayer(pLayer);
            }
        }

        private void TOCContextMenuItem_ZoomToLayer(object sender, EventArgs e)
        {
            esriTOCControlItem pItem = ESRI.ArcGIS.Controls.esriTOCControlItem.esriTOCControlItemNone;
            ILayer pLayer = null;
            IBasicMap pMap = null;
            object pIndex = null;
            object pOther = null;

            TOCControl.GetSelectedItem(ref pItem, ref pMap, ref pLayer, ref pIndex, ref pOther);
            if (pLayer != null)
            {

                IGeoDataset pGeoDataset = pLayer as IGeoDataset;
                MainMap.ActiveView.Extent = pGeoDataset.Extent;
                MainMap.ActiveView.Refresh();
            }
        }

        private void TOCControl_OnMouseDown(object sender, ITOCControlEvents_OnMouseDownEvent e)
        {
            if (e.button == 2)
            {
                TOCControl.ContextMenuStrip.Show(TOCControl, e.x, e.y);
            }
        }

    }
}

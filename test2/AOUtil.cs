using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display; 

namespace test2
{
    public enum GISTool
    {
        Default = 0,
        Pan = 1,
        ZoomIn = 2,
        ZoomOut = 3,
        Select = 4,
        Identify = 5
    }

    public class AOUtil
    {
        private static double SEARCHTOLPIXELS = 4;
        private static IdentifyForm m_identifyForm = null;

        // 根据像素容差计算地图坐标单位容差值
        public static double ConvertPixelsToMapUnits(IActiveView pActiveView, double pixelUnits)
        {
            tagRECT deviceRect = pActiveView.ScreenDisplay.DisplayTransformation.get_DeviceFrame();
            int pixelExtent = deviceRect.right - deviceRect.left;
            double realWorldDisplayExtent = pActiveView.ScreenDisplay.DisplayTransformation.VisibleBounds.Width;
            double sizeOfOnePixel = realWorldDisplayExtent / pixelExtent;
            return pixelUnits * sizeOfOnePixel;
        }

        // 点选要素
        public static void SelectByPoint(AxMapControl axMapControl, int x, int y)
        {
            IActiveView pActiveView = axMapControl.ActiveView;
            IPoint pPoint = pActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(x, y);
            IEnvelope pEnvelope = pPoint.Envelope;

            double tolDistance = ConvertPixelsToMapUnits(pActiveView, SEARCHTOLPIXELS);
            pEnvelope.Width = tolDistance;
            pEnvelope.Height = tolDistance;
            pEnvelope.CenterAt(pPoint);

            IGeometry pGeometry = pEnvelope as IGeometry;
            pGeometry.SpatialReference = axMapControl.Map.SpatialReference;
            axMapControl.Map.SelectByShape(pGeometry, null, false);
            pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, pActiveView.Extent);
        }

        // 查询要素属性
        public static void Identify(AxMapControl axMapControl, int x, int y)
        {
            // 先点选要素
            SelectByPoint(axMapControl, x, y);

            if (m_identifyForm == null)
                m_identifyForm = new IdentifyForm(axMapControl);

            m_identifyForm.Show();
            m_identifyForm.BringToFront();
            m_identifyForm.RefillContent();
        }

        public static IGeometry GetSelectGeometry(AxMapControl axMapControl)
        {

            for (int i = 0; i < axMapControl.LayerCount; i++)
            {
                IFeatureLayer pFeatureLayer = axMapControl.get_Layer(i) as IFeatureLayer;
                IFeatureSelection pFeatureSelection = pFeatureLayer as IFeatureSelection;
                ISelectionSet pSelectionSet = pFeatureSelection.SelectionSet;

                ICursor pCursor = null;
                pSelectionSet.Search(null, false, out pCursor);
                IFeatureCursor pFeatureCursor = pCursor as IFeatureCursor;
                IFeature pFeature = pFeatureCursor.NextFeature();

                System.Runtime.InteropServices.Marshal.ReleaseComObject(pFeatureCursor);
                GC.Collect();
                GC.WaitForPendingFinalizers();

                if (pFeature != null) return pFeature.Shape;
            }

            return null;
        }

        // 从符号
        public static ISymbol FetchSymbol(string name)
        {
            string strStartPath = System.Windows.Forms.Application.StartupPath;
            IStyleGallery pStyleGallery = new ServerStyleGalleryClass();
            IStyleGalleryStorage pStyleGalleryStorage = pStyleGallery as IStyleGalleryStorage;
            pStyleGalleryStorage.AddFile(strStartPath + "\\mlb.ServerStyle");

            IEnumStyleGalleryItem pEnumStyleGalleryItem = pStyleGallery.get_Items("Marker Symbols", strStartPath + "\\mlb.ServerStyle", null);

            ISymbol pSymbol = null;
            pEnumStyleGalleryItem.Reset();
            IStyleGalleryItem pStyleGalleryItem = pEnumStyleGalleryItem.Next();


            while (pStyleGalleryItem != null)
            {
                if (pStyleGalleryItem.Name == name)
                {
                    //获取符号
                    pSymbol = pStyleGalleryItem.Item as ISymbol;
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(pEnumStyleGalleryItem);
                    break;
                }

                pStyleGalleryItem = pEnumStyleGalleryItem.Next();
            }

            return pSymbol;
        }


    }
}

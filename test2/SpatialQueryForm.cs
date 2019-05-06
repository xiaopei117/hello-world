using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display; 

namespace test2
{
    public partial class SpatialQueryForm : Form
    {
        AxMapControl m_axMapControl;
        public SpatialQueryForm(AxMapControl axMapControl)
        {
            InitializeComponent();

            m_axMapControl = axMapControl; 
        }

        private void SpatialQueryForm_Load(object sender, EventArgs e)
        {
            comboLayers.Items.Clear();

            for (int i = 0; i < m_axMapControl.LayerCount; i++)
            {
                ILayer pLayer = m_axMapControl.get_Layer(i);
                comboLayers.Items.Add(pLayer.Name);

                comboLayers.SelectedIndex = 0;
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            ISpatialFilter pSpatialFilter = new SpatialFilterClass();
            pSpatialFilter.SearchOrder = esriSearchOrder.esriSearchOrderSpatial;

            if (radioIntersect.Checked == true)
                pSpatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;

            if (radioContain.Checked == true)
                pSpatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelContains;

            if (radioTouch.Checked == true)
                pSpatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelTouches;

            pSpatialFilter.Geometry = AOUtil.GetSelectGeometry(m_axMapControl);

            ILayer pLayer = GetLayerByName(comboLayers.SelectedItem.ToString());
            IFeatureLayer pFeatureLayer = pLayer as IFeatureLayer;
            IFeatureSelection pFeatureSelection = pLayer as IFeatureSelection;

            pSpatialFilter.GeometryField = pFeatureLayer.FeatureClass.ShapeFieldName;
            pFeatureSelection.Clear();
            pFeatureSelection.SelectFeatures(pSpatialFilter, esriSelectionResultEnum.esriSelectionResultNew, false);
            m_axMapControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);

            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        // 从名字获取层
        private ILayer GetLayerByName(String name)
        {
            for (int i = 0; i < m_axMapControl.LayerCount; i++)
            {
                ILayer pLayer = m_axMapControl.get_Layer(i);
                if (pLayer.Name == name) return pLayer;
            }

            return null;
        }
    }
}

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
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geodatabase; 

namespace test2
{
    public partial class IdentifyForm : Form
    {
        AxMapControl m_axMapControl;

        public IdentifyForm(AxMapControl axMapControl)
        {
            InitializeComponent();
            m_axMapControl = axMapControl; 
        }

        private void comboLayerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboLayerList.Items.Count == 0) return;

            lstContent.Items.Clear();
            lstContent.Columns.Clear();

            ILayer pLayer = GetLayerByName(comboLayerList.SelectedItem.ToString());
            IFeatureLayer pFeatureLayer = pLayer as IFeatureLayer;
            if (pFeatureLayer == null) return;

            IFeatureClass pFeatureClass = pFeatureLayer.FeatureClass;
            IFields pFields = pFeatureClass.Fields;

            for (int i = 0; i < pFields.FieldCount; i++)
            {
                lstContent.Columns.Add(pFields.get_Field(i).AliasName);
            }

            IFeatureSelection pFeatureSelection = pFeatureLayer as IFeatureSelection;
            ISelectionSet pSelectionSet = pFeatureSelection.SelectionSet;

            ICursor pCursor = null;
            pSelectionSet.Search(null, false, out pCursor);
            IFeatureCursor pFeatureCursor = pCursor as IFeatureCursor;

            IFeature pFeature = pFeatureCursor.NextFeature();
            while (pFeature != null)
            {
                ListViewItem item = null;
                for (int i = 0; i < pFields.FieldCount; i++)
                {
                    if (pFields.get_Field(i).Type != esriFieldType.esriFieldTypeGeometry)
                    {
                        if (i == 0)
                        {
                            item = lstContent.Items.Add(pFeature.get_Value(i).ToString());
                        }
                        else
                        {
                            item.SubItems.Add(pFeature.get_Value(i).ToString());
                        }
                    }
                }
                pFeature = pFeatureCursor.NextFeature();
            }
        }

        private void lstContent_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tbnClose_Click(object sender, EventArgs e)
        {
            Hide();
        }

        public void RefillContent()
        {
            comboLayerList.Items.Clear();
   
            bool bFirst = false;
            for(int i=0; i<m_axMapControl.LayerCount; i++)
            {
                IFeatureLayer pFeatureLayer = m_axMapControl.get_Layer(i) as IFeatureLayer;
                if (pFeatureLayer != null)
                {
                    IFeatureSelection pFeatureSelection = pFeatureLayer as IFeatureSelection;
                    ISelectionSet pSelectionSet = pFeatureSelection.SelectionSet;  
                    if (pSelectionSet.Count > 0)
                    {
                        comboLayerList.Items.Add(pFeatureLayer.Name);
                        if (!bFirst)
                            comboLayerList.SelectedIndex = 0; 
                    }
                }
            }
        }

        private ILayer GetLayerByName(String name)
        {
            for (int i = 0; i < m_axMapControl.LayerCount; i++)
            {
                ILayer pLayer = m_axMapControl.get_Layer(i);
                if (pLayer.Name == name) return pLayer;
            }

            return null;
        }

        private void IdentifyForm_Load(object sender, EventArgs e)
        {

        }
    }
}

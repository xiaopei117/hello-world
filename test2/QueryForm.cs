using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geodatabase; 

namespace test2
{
    public partial class QueryForm : Form
    {
        private AxMapControl m_axMapControl;
        public QueryForm(AxMapControl axMapControl)
        {
            InitializeComponent();
            m_axMapControl = axMapControl;
        }

        private void QueryForm_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < m_axMapControl.LayerCount; i++)
            {
                ILayer pLayer = m_axMapControl.get_Layer(i);
                if (pLayer.Visible)
                    comboLayers.Items.Add(pLayer.Name);
            }

            comboOperator.Items.Add("=");
            comboOperator.Items.Add("<");
            comboOperator.Items.Add(">");
            comboOperator.Items.Add("<=");
            comboOperator.Items.Add(">=");
            comboOperator.Items.Add("Like");

            comboOperator.SelectedIndex = 0;
        }

        private void comboLayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboLayers.Items.Count == 0) return;

            ILayer pLayer = m_axMapControl.get_Layer(comboLayers.SelectedIndex);
            IFeatureLayer pFeatureLayer = pLayer as IFeatureLayer;
            if (pFeatureLayer == null) return;

            IFeatureClass pFeatureClass = pFeatureLayer.FeatureClass;
            IFields pFields = pFeatureClass.Fields;

            comboFields.Items.Clear();
            for (int i = 0; i < pFields.FieldCount; i++)
            {
                IField pField = pFields.get_Field(i);
                if (pField.Type != esriFieldType.esriFieldTypeGeometry)
                    comboFields.Items.Add(pField.Name);
            }
            comboFields.SelectedIndex = 0;
        }

        private void comboFields_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboValue.Items.Clear();
            ILayer pLayer = m_axMapControl.get_Layer(comboLayers.SelectedIndex);
            IFeatureLayer pFeatureLayer = pLayer as IFeatureLayer;
            if (pFeatureLayer == null) return;

            IFeatureClass pFeatureClass = pFeatureLayer.FeatureClass;
            IFields pFields = pFeatureClass.Fields;

            IFeatureCursor pFeatureCursor = pFeatureClass.Search(null, false);
            IFeature pFeature = pFeatureCursor.NextFeature();

            int indexField = pFields.FindFieldByAliasName(comboFields.Text);
            while (pFeature != null)
            {
                comboValue.Items.Add(pFeature.get_Value(indexField));
                pFeature = pFeatureCursor.NextFeature();
            }

            System.Runtime.InteropServices.Marshal.ReleaseComObject(pFeatureCursor);
            GC.Collect();
            GC.WaitForPendingFinalizers();

            comboValue.Text = "<选择字段值>";
        }

        private void comboOperator_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboValue_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (comboLayers.Text.Length == 0)
            {
                MessageBox.Show("请选择一个图层");
                return;
            }

            if (comboFields.Text == "<选择字段值>")
            {
                MessageBox.Show("请选择一个合适的字段值");
                return;
            }

            ILayer pLayer = m_axMapControl.get_Layer(comboLayers.SelectedIndex);
            IFeatureLayer pFeatureLayer = pLayer as IFeatureLayer;
            IFeatureClass pFeatureClass = pFeatureLayer.FeatureClass;
            IFields pFields = pFeatureClass.Fields;
            IField pField = pFields.get_Field(pFields.FindFieldByAliasName(comboFields.Text));

            IQueryFilter pQueryFilter = new QueryFilterClass();
            if (pField.Type == esriFieldType.esriFieldTypeString)
                pQueryFilter.WhereClause = comboFields.Text + " " + comboOperator.Text + " '" + comboValue.Text + "'";
            else
                pQueryFilter.WhereClause = comboFields.Text + " " + comboOperator.Text + " " + comboValue.Text;

            IFeatureSelection pFeatureSelection = pFeatureLayer as IFeatureSelection;
            pFeatureSelection.SelectFeatures(pQueryFilter, esriSelectionResultEnum.esriSelectionResultNew, false);
            ISelectionSet pSelectionSet = pFeatureSelection.SelectionSet;
            m_axMapControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, m_axMapControl.ActiveView.Extent);

            // 显示查询要素的属性
            lsvContent.Columns.Clear();
            lsvContent.Items.Clear();

            for (int i = 0; i < pFields.FieldCount; i++)
            {
                lsvContent.Columns.Add(pFields.get_Field(i).AliasName);
            }

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
                            item = lsvContent.Items.Add(pFeature.get_Value(i).ToString());
                        }
                        else
                        {
                            item.SubItems.Add(pFeature.get_Value(i).ToString());
                        }
                    }
                }
                pFeature = pFeatureCursor.NextFeature();
            }
            System.Runtime.InteropServices.Marshal.ReleaseComObject(pFeatureCursor);
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        

    }
}

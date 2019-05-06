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
    public partial class BufferForm : Form
    {
        AxMapControl m_axMapControl;
        public BufferForm(AxMapControl axMapControl)
        {
            InitializeComponent();
            m_axMapControl = axMapControl; 
        }

        private void BufferForm_Load(object sender, EventArgs e)
        {

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            IGeometry pGeometry = AOUtil.GetSelectGeometry(m_axMapControl);
            if (pGeometry == null) return;

            double bufferDis = Convert.ToDouble(txtBuffer.Text);

            ITopologicalOperator pTopologicalOperator = pGeometry as ITopologicalOperator;
            IGeometry pBufferGeometry = pTopologicalOperator.Buffer(bufferDis);
            m_axMapControl.DrawShape(pBufferGeometry); 
        }
    }
}

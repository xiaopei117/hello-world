namespace test2
{
    partial class SpatialQueryForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioIntersect = new System.Windows.Forms.RadioButton();
            this.radioContain = new System.Windows.Forms.RadioButton();
            this.radioTouch = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.comboLayers = new System.Windows.Forms.ComboBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboLayers);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.radioTouch);
            this.groupBox1.Controls.Add(this.radioContain);
            this.groupBox1.Controls.Add(this.radioIntersect);
            this.groupBox1.Location = new System.Drawing.Point(5, -2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(231, 95);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // radioIntersect
            // 
            this.radioIntersect.AutoSize = true;
            this.radioIntersect.Location = new System.Drawing.Point(6, 20);
            this.radioIntersect.Name = "radioIntersect";
            this.radioIntersect.Size = new System.Drawing.Size(47, 16);
            this.radioIntersect.TabIndex = 0;
            this.radioIntersect.Text = "相交";
            this.radioIntersect.UseVisualStyleBackColor = true;
            // 
            // radioContain
            // 
            this.radioContain.AutoSize = true;
            this.radioContain.Location = new System.Drawing.Point(6, 42);
            this.radioContain.Name = "radioContain";
            this.radioContain.Size = new System.Drawing.Size(47, 16);
            this.radioContain.TabIndex = 1;
            this.radioContain.Text = "包含";
            this.radioContain.UseVisualStyleBackColor = true;
            // 
            // radioTouch
            // 
            this.radioTouch.AutoSize = true;
            this.radioTouch.Checked = true;
            this.radioTouch.Location = new System.Drawing.Point(6, 64);
            this.radioTouch.Name = "radioTouch";
            this.radioTouch.Size = new System.Drawing.Size(47, 16);
            this.radioTouch.TabIndex = 1;
            this.radioTouch.TabStop = true;
            this.radioTouch.Text = "相邻";
            this.radioTouch.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(99, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "目标图层";
            // 
            // comboLayers
            // 
            this.comboLayers.FormattingEnabled = true;
            this.comboLayers.Location = new System.Drawing.Point(101, 51);
            this.comboLayers.Name = "comboLayers";
            this.comboLayers.Size = new System.Drawing.Size(121, 20);
            this.comboLayers.TabIndex = 3;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(80, 99);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 1;
            this.btnConfirm.Text = "确定";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(161, 99);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // SpatialQueryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(241, 127);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.groupBox1);
            this.Name = "SpatialQueryForm";
            this.Text = "空间关系查询";
            this.Load += new System.EventHandler(this.SpatialQueryForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboLayers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioTouch;
        private System.Windows.Forms.RadioButton radioContain;
        private System.Windows.Forms.RadioButton radioIntersect;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
    }
}
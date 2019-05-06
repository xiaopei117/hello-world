namespace test2
{
    partial class IdentifyForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboLayerList = new System.Windows.Forms.ComboBox();
            this.lstContent = new System.Windows.Forms.ListView();
            this.tbnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "图层";
            // 
            // comboLayerList
            // 
            this.comboLayerList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboLayerList.FormattingEnabled = true;
            this.comboLayerList.Location = new System.Drawing.Point(48, 10);
            this.comboLayerList.Name = "comboLayerList";
            this.comboLayerList.Size = new System.Drawing.Size(153, 20);
            this.comboLayerList.TabIndex = 1;
            this.comboLayerList.SelectedIndexChanged += new System.EventHandler(this.comboLayerList_SelectedIndexChanged);
            // 
            // lstContent
            // 
            this.lstContent.GridLines = true;
            this.lstContent.Location = new System.Drawing.Point(15, 36);
            this.lstContent.Name = "lstContent";
            this.lstContent.Size = new System.Drawing.Size(528, 279);
            this.lstContent.TabIndex = 2;
            this.lstContent.UseCompatibleStateImageBehavior = false;
            this.lstContent.View = System.Windows.Forms.View.Details;
            this.lstContent.SelectedIndexChanged += new System.EventHandler(this.lstContent_SelectedIndexChanged);
            // 
            // tbnClose
            // 
            this.tbnClose.Location = new System.Drawing.Point(485, 321);
            this.tbnClose.Name = "tbnClose";
            this.tbnClose.Size = new System.Drawing.Size(58, 23);
            this.tbnClose.TabIndex = 3;
            this.tbnClose.Text = "关闭";
            this.tbnClose.UseVisualStyleBackColor = true;
            this.tbnClose.Click += new System.EventHandler(this.tbnClose_Click);
            // 
            // IdentifyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 346);
            this.Controls.Add(this.tbnClose);
            this.Controls.Add(this.lstContent);
            this.Controls.Add(this.comboLayerList);
            this.Controls.Add(this.label1);
            this.Name = "IdentifyForm";
            this.Text = "要素内容查询";
            this.Load += new System.EventHandler(this.IdentifyForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboLayerList;
        private System.Windows.Forms.ListView lstContent;
        private System.Windows.Forms.Button tbnClose;
    }
}
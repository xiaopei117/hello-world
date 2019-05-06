namespace test2
{
    partial class QueryForm
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
            this.GroupBoxSelect = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboValue = new System.Windows.Forms.ComboBox();
            this.comboOperator = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboFields = new System.Windows.Forms.ComboBox();
            this.comboLayers = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lsvContent = new System.Windows.Forms.ListView();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.GroupBoxSelect.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBoxSelect
            // 
            this.GroupBoxSelect.Controls.Add(this.label4);
            this.GroupBoxSelect.Controls.Add(this.comboValue);
            this.GroupBoxSelect.Controls.Add(this.comboOperator);
            this.GroupBoxSelect.Controls.Add(this.label3);
            this.GroupBoxSelect.Controls.Add(this.comboFields);
            this.GroupBoxSelect.Controls.Add(this.comboLayers);
            this.GroupBoxSelect.Controls.Add(this.label2);
            this.GroupBoxSelect.Controls.Add(this.label1);
            this.GroupBoxSelect.Location = new System.Drawing.Point(2, 1);
            this.GroupBoxSelect.Name = "GroupBoxSelect";
            this.GroupBoxSelect.Size = new System.Drawing.Size(520, 79);
            this.GroupBoxSelect.TabIndex = 0;
            this.GroupBoxSelect.TabStop = false;
            this.GroupBoxSelect.Text = "查询条件";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(345, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "属性值";
            // 
            // comboValue
            // 
            this.comboValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboValue.FormattingEnabled = true;
            this.comboValue.Location = new System.Drawing.Point(392, 48);
            this.comboValue.Name = "comboValue";
            this.comboValue.Size = new System.Drawing.Size(121, 20);
            this.comboValue.TabIndex = 6;
            this.comboValue.SelectedIndexChanged += new System.EventHandler(this.comboValue_SelectedIndexChanged);
            // 
            // comboOperator
            // 
            this.comboOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboOperator.FormattingEnabled = true;
            this.comboOperator.Location = new System.Drawing.Point(252, 48);
            this.comboOperator.Name = "comboOperator";
            this.comboOperator.Size = new System.Drawing.Size(76, 20);
            this.comboOperator.TabIndex = 5;
            this.comboOperator.SelectedIndexChanged += new System.EventHandler(this.comboOperator_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(205, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "运算符";
            // 
            // comboFields
            // 
            this.comboFields.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboFields.FormattingEnabled = true;
            this.comboFields.Location = new System.Drawing.Point(69, 48);
            this.comboFields.Name = "comboFields";
            this.comboFields.Size = new System.Drawing.Size(121, 20);
            this.comboFields.TabIndex = 3;
            this.comboFields.SelectedIndexChanged += new System.EventHandler(this.comboFields_SelectedIndexChanged);
            // 
            // comboLayers
            // 
            this.comboLayers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboLayers.FormattingEnabled = true;
            this.comboLayers.Location = new System.Drawing.Point(69, 22);
            this.comboLayers.Name = "comboLayers";
            this.comboLayers.Size = new System.Drawing.Size(121, 20);
            this.comboLayers.TabIndex = 2;
            this.comboLayers.SelectedIndexChanged += new System.EventHandler(this.comboLayers_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "属性字段";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "选择图层";
            // 
            // lsvContent
            // 
            this.lsvContent.GridLines = true;
            this.lsvContent.Location = new System.Drawing.Point(2, 87);
            this.lsvContent.Name = "lsvContent";
            this.lsvContent.Size = new System.Drawing.Size(520, 234);
            this.lsvContent.TabIndex = 1;
            this.lsvContent.UseCompatibleStateImageBehavior = false;
            this.lsvContent.View = System.Windows.Forms.View.Details;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(366, 327);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 2;
            this.btnConfirm.Text = "查询";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(447, 327);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "关闭";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // QueryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 353);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.lsvContent);
            this.Controls.Add(this.GroupBoxSelect);
            this.Name = "QueryForm";
            this.Text = "属性表达式查询";
            this.Load += new System.EventHandler(this.QueryForm_Load);
            this.GroupBoxSelect.ResumeLayout(false);
            this.GroupBoxSelect.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GroupBoxSelect;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboValue;
        private System.Windows.Forms.ComboBox comboOperator;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboFields;
        private System.Windows.Forms.ComboBox comboLayers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lsvContent;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
    }
}
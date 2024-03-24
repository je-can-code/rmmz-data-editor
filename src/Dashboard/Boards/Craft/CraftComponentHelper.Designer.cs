namespace JMZ.Dashboard.Boards.Craft
{
    partial class CraftComponentHelper
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
            labelTypes = new Label();
            comboBoxTypes = new ComboBox();
            labelComponents = new Label();
            groupBoxResult = new GroupBox();
            textBoxCurrentCount = new TextBox();
            labelCurrentQuantity = new Label();
            textBoxCurrentId = new TextBox();
            labelCurrentId = new Label();
            labelCurrentType = new Label();
            textBoxCurrentType = new TextBox();
            labelQuantity = new Label();
            numQuantity = new NumericUpDown();
            textBoxDataFilter = new TextBox();
            listBoxComponents = new ListBox();
            labelDataFilter = new Label();
            groupBoxComponents = new GroupBox();
            groupBoxResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            groupBoxComponents.SuspendLayout();
            SuspendLayout();
            // 
            // labelTypes
            // 
            labelTypes.AutoSize = true;
            labelTypes.Location = new Point(11, 34);
            labelTypes.Margin = new Padding(6, 0, 6, 0);
            labelTypes.Name = "labelTypes";
            labelTypes.Size = new Size(78, 29);
            labelTypes.TabIndex = 1;
            labelTypes.Text = "Types";
            // 
            // comboBoxTypes
            // 
            comboBoxTypes.Font = new Font("Victor Mono SemiBold", 10.124999F, FontStyle.Bold, GraphicsUnit.Point);
            comboBoxTypes.FormattingEnabled = true;
            comboBoxTypes.Location = new Point(11, 73);
            comboBoxTypes.Margin = new Padding(6);
            comboBoxTypes.Name = "comboBoxTypes";
            comboBoxTypes.Size = new Size(160, 41);
            comboBoxTypes.TabIndex = 2;
            // 
            // labelComponents
            // 
            labelComponents.AutoSize = true;
            labelComponents.Location = new Point(15, 228);
            labelComponents.Margin = new Padding(6, 0, 6, 0);
            labelComponents.Name = "labelComponents";
            labelComponents.Size = new Size(65, 29);
            labelComponents.TabIndex = 4;
            labelComponents.Text = "Data";
            // 
            // groupBoxResult
            // 
            groupBoxResult.Controls.Add(textBoxCurrentCount);
            groupBoxResult.Controls.Add(labelCurrentQuantity);
            groupBoxResult.Controls.Add(textBoxCurrentId);
            groupBoxResult.Controls.Add(labelCurrentId);
            groupBoxResult.Controls.Add(labelCurrentType);
            groupBoxResult.Controls.Add(textBoxCurrentType);
            groupBoxResult.Font = new Font("Cascadia Code", 10.125F, FontStyle.Regular, GraphicsUnit.Point);
            groupBoxResult.Location = new Point(37, 15);
            groupBoxResult.Margin = new Padding(6);
            groupBoxResult.Name = "groupBoxResult";
            groupBoxResult.Padding = new Padding(6);
            groupBoxResult.Size = new Size(434, 232);
            groupBoxResult.TabIndex = 5;
            groupBoxResult.TabStop = false;
            groupBoxResult.Text = "Current Component";
            // 
            // textBoxCurrentCount
            // 
            textBoxCurrentCount.BorderStyle = BorderStyle.FixedSingle;
            textBoxCurrentCount.Enabled = false;
            textBoxCurrentCount.Font = new Font("Victor Mono SemiBold", 10.124999F, FontStyle.Bold, GraphicsUnit.Point);
            textBoxCurrentCount.Location = new Point(113, 175);
            textBoxCurrentCount.Margin = new Padding(6);
            textBoxCurrentCount.Name = "textBoxCurrentCount";
            textBoxCurrentCount.Size = new Size(184, 46);
            textBoxCurrentCount.TabIndex = 13;
            // 
            // labelCurrentQuantity
            // 
            labelCurrentQuantity.AutoSize = true;
            labelCurrentQuantity.Font = new Font("Cascadia Code", 10.125F, FontStyle.Regular, GraphicsUnit.Point);
            labelCurrentQuantity.Location = new Point(15, 177);
            labelCurrentQuantity.Margin = new Padding(6, 0, 6, 0);
            labelCurrentQuantity.Name = "labelCurrentQuantity";
            labelCurrentQuantity.Size = new Size(95, 35);
            labelCurrentQuantity.TabIndex = 12;
            labelCurrentQuantity.Text = "Count";
            // 
            // textBoxCurrentId
            // 
            textBoxCurrentId.BorderStyle = BorderStyle.FixedSingle;
            textBoxCurrentId.Enabled = false;
            textBoxCurrentId.Font = new Font("Victor Mono SemiBold", 10.124999F, FontStyle.Bold, GraphicsUnit.Point);
            textBoxCurrentId.Location = new Point(113, 113);
            textBoxCurrentId.Margin = new Padding(6);
            textBoxCurrentId.Name = "textBoxCurrentId";
            textBoxCurrentId.Size = new Size(184, 46);
            textBoxCurrentId.TabIndex = 11;
            // 
            // labelCurrentId
            // 
            labelCurrentId.AutoSize = true;
            labelCurrentId.Font = new Font("Cascadia Code", 10.125F, FontStyle.Regular, GraphicsUnit.Point);
            labelCurrentId.Location = new Point(59, 115);
            labelCurrentId.Margin = new Padding(6, 0, 6, 0);
            labelCurrentId.Name = "labelCurrentId";
            labelCurrentId.Size = new Size(47, 35);
            labelCurrentId.TabIndex = 10;
            labelCurrentId.Text = "Id";
            // 
            // labelCurrentType
            // 
            labelCurrentType.AutoSize = true;
            labelCurrentType.Font = new Font("Cascadia Code", 10.125F, FontStyle.Regular, GraphicsUnit.Point);
            labelCurrentType.Location = new Point(30, 53);
            labelCurrentType.Margin = new Padding(6, 0, 6, 0);
            labelCurrentType.Name = "labelCurrentType";
            labelCurrentType.Size = new Size(79, 35);
            labelCurrentType.TabIndex = 9;
            labelCurrentType.Text = "Type";
            // 
            // textBoxCurrentType
            // 
            textBoxCurrentType.BorderStyle = BorderStyle.FixedSingle;
            textBoxCurrentType.Enabled = false;
            textBoxCurrentType.Font = new Font("Victor Mono SemiBold", 10.124999F, FontStyle.Bold, GraphicsUnit.Point);
            textBoxCurrentType.Location = new Point(113, 51);
            textBoxCurrentType.Margin = new Padding(6);
            textBoxCurrentType.Name = "textBoxCurrentType";
            textBoxCurrentType.Size = new Size(184, 46);
            textBoxCurrentType.TabIndex = 8;
            // 
            // labelQuantity
            // 
            labelQuantity.AutoSize = true;
            labelQuantity.Location = new Point(215, 34);
            labelQuantity.Margin = new Padding(6, 0, 6, 0);
            labelQuantity.Name = "labelQuantity";
            labelQuantity.Size = new Size(182, 29);
            labelQuantity.TabIndex = 6;
            labelQuantity.Text = "Amount/Chance";
            // 
            // numQuantity
            // 
            numQuantity.Font = new Font("Cascadia Code", 10.125F, FontStyle.Regular, GraphicsUnit.Point);
            numQuantity.Location = new Point(215, 73);
            numQuantity.Margin = new Padding(11, 13, 11, 13);
            numQuantity.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
            numQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(202, 39);
            numQuantity.TabIndex = 7;
            numQuantity.TextAlign = HorizontalAlignment.Center;
            numQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // textBoxDataFilter
            // 
            textBoxDataFilter.Font = new Font("Victor Mono SemiBold", 10.124999F, FontStyle.Bold, GraphicsUnit.Point);
            textBoxDataFilter.Location = new Point(15, 173);
            textBoxDataFilter.Margin = new Padding(6);
            textBoxDataFilter.Name = "textBoxDataFilter";
            textBoxDataFilter.Size = new Size(402, 46);
            textBoxDataFilter.TabIndex = 8;
            // 
            // listBoxComponents
            // 
            listBoxComponents.BorderStyle = BorderStyle.FixedSingle;
            listBoxComponents.Font = new Font("Victor Mono SemiBold", 10.124999F, FontStyle.Bold, GraphicsUnit.Point);
            listBoxComponents.FormattingEnabled = true;
            listBoxComponents.ItemHeight = 33;
            listBoxComponents.Location = new Point(15, 267);
            listBoxComponents.Margin = new Padding(6);
            listBoxComponents.Name = "listBoxComponents";
            listBoxComponents.Size = new Size(402, 959);
            listBoxComponents.TabIndex = 9;
            // 
            // labelDataFilter
            // 
            labelDataFilter.AutoSize = true;
            labelDataFilter.Location = new Point(15, 134);
            labelDataFilter.Margin = new Padding(6, 0, 6, 0);
            labelDataFilter.Name = "labelDataFilter";
            labelDataFilter.Size = new Size(91, 29);
            labelDataFilter.TabIndex = 10;
            labelDataFilter.Text = "Search";
            // 
            // groupBoxComponents
            // 
            groupBoxComponents.Controls.Add(listBoxComponents);
            groupBoxComponents.Controls.Add(numQuantity);
            groupBoxComponents.Controls.Add(labelDataFilter);
            groupBoxComponents.Controls.Add(labelQuantity);
            groupBoxComponents.Controls.Add(labelComponents);
            groupBoxComponents.Controls.Add(textBoxDataFilter);
            groupBoxComponents.Controls.Add(comboBoxTypes);
            groupBoxComponents.Controls.Add(labelTypes);
            groupBoxComponents.Font = new Font("Cascadia Code", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            groupBoxComponents.Location = new Point(37, 259);
            groupBoxComponents.Margin = new Padding(6);
            groupBoxComponents.Name = "groupBoxComponents";
            groupBoxComponents.Padding = new Padding(6);
            groupBoxComponents.Size = new Size(434, 1243);
            groupBoxComponents.TabIndex = 11;
            groupBoxComponents.TabStop = false;
            groupBoxComponents.Text = "Component Data";
            // 
            // CraftComponentHelper
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(513, 1537);
            Controls.Add(groupBoxComponents);
            Controls.Add(groupBoxResult);
            Margin = new Padding(6);
            Name = "CraftComponentHelper";
            Text = "Component Helper";
            groupBoxResult.ResumeLayout(false);
            groupBoxResult.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            groupBoxComponents.ResumeLayout(false);
            groupBoxComponents.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label labelTypes;
        private ComboBox comboBoxTypes;
        private Label labelComponents;
        private GroupBox groupBoxResult;
        private Label labelQuantity;
        private NumericUpDown numQuantity;
        private TextBox textBoxCurrentCount;
        private Label labelCurrentQuantity;
        private TextBox textBoxCurrentId;
        private Label labelCurrentId;
        private Label labelCurrentType;
        private TextBox textBoxCurrentType;
        private TextBox textBoxDataFilter;
        private ListBox listBoxComponents;
        private Label labelDataFilter;
        private GroupBox groupBoxComponents;
    }
}
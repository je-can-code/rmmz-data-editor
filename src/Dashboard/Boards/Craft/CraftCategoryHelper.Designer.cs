namespace JMZ.Dashboard.Boards.Craft
{
    partial class CraftCategoryHelper
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
            groupBox_coreData = new GroupBox();
            labelDescription = new Label();
            textBoxDescription = new TextBox();
            checkBoxUnlockedByDefault = new CheckBox();
            textBoxKey = new TextBox();
            label_key = new Label();
            textBoxName = new TextBox();
            label_name = new Label();
            numIconIndex = new NumericUpDown();
            label_iconIndex = new Label();
            listBoxCategories = new ListBox();
            labelCategories = new Label();
            buttonAddCategory = new Button();
            buttonDeleteCategory = new Button();
            groupBox_coreData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numIconIndex).BeginInit();
            SuspendLayout();
            // 
            // groupBox_coreData
            // 
            groupBox_coreData.Controls.Add(labelDescription);
            groupBox_coreData.Controls.Add(textBoxDescription);
            groupBox_coreData.Controls.Add(checkBoxUnlockedByDefault);
            groupBox_coreData.Controls.Add(textBoxKey);
            groupBox_coreData.Controls.Add(label_key);
            groupBox_coreData.Controls.Add(textBoxName);
            groupBox_coreData.Controls.Add(label_name);
            groupBox_coreData.Controls.Add(numIconIndex);
            groupBox_coreData.Controls.Add(label_iconIndex);
            groupBox_coreData.Font = new Font("Cascadia Code", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox_coreData.Location = new Point(390, 26);
            groupBox_coreData.Margin = new Padding(6);
            groupBox_coreData.Name = "groupBox_coreData";
            groupBox_coreData.Padding = new Padding(6);
            groupBox_coreData.Size = new Size(1467, 835);
            groupBox_coreData.TabIndex = 56;
            groupBox_coreData.TabStop = false;
            groupBox_coreData.Text = "Core Data";
            // 
            // labelDescription
            // 
            labelDescription.AutoSize = true;
            labelDescription.Font = new Font("Cascadia Code", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            labelDescription.Location = new Point(11, 243);
            labelDescription.Margin = new Padding(6, 0, 6, 0);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(156, 29);
            labelDescription.TabIndex = 61;
            labelDescription.Text = "Description";
            // 
            // textBoxDescription
            // 
            textBoxDescription.Font = new Font("Cascadia Code", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxDescription.Location = new Point(11, 282);
            textBoxDescription.Margin = new Padding(6);
            textBoxDescription.Multiline = true;
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.Size = new Size(1444, 541);
            textBoxDescription.TabIndex = 60;
            // 
            // checkBoxUnlockedByDefault
            // 
            checkBoxUnlockedByDefault.AutoSize = true;
            checkBoxUnlockedByDefault.Font = new Font("Cascadia Code", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            checkBoxUnlockedByDefault.Location = new Point(500, 81);
            checkBoxUnlockedByDefault.Margin = new Padding(6);
            checkBoxUnlockedByDefault.Name = "checkBoxUnlockedByDefault";
            checkBoxUnlockedByDefault.Size = new Size(292, 33);
            checkBoxUnlockedByDefault.TabIndex = 31;
            checkBoxUnlockedByDefault.Text = "Unlocked By Default";
            checkBoxUnlockedByDefault.UseVisualStyleBackColor = false;
            // 
            // textBoxKey
            // 
            textBoxKey.BorderStyle = BorderStyle.FixedSingle;
            textBoxKey.Font = new Font("Cascadia Code", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxKey.Location = new Point(11, 81);
            textBoxKey.Margin = new Padding(6);
            textBoxKey.Name = "textBoxKey";
            textBoxKey.Size = new Size(206, 33);
            textBoxKey.TabIndex = 2;
            // 
            // label_key
            // 
            label_key.AutoSize = true;
            label_key.Font = new Font("Cascadia Code", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            label_key.Location = new Point(11, 43);
            label_key.Margin = new Padding(6, 0, 6, 0);
            label_key.Name = "label_key";
            label_key.Size = new Size(52, 29);
            label_key.TabIndex = 3;
            label_key.Text = "Key";
            // 
            // textBoxName
            // 
            textBoxName.BorderStyle = BorderStyle.FixedSingle;
            textBoxName.Font = new Font("Cascadia Code", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxName.Location = new Point(11, 181);
            textBoxName.Margin = new Padding(6);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(425, 33);
            textBoxName.TabIndex = 4;
            // 
            // label_name
            // 
            label_name.AutoSize = true;
            label_name.Font = new Font("Cascadia Code", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            label_name.Location = new Point(13, 143);
            label_name.Margin = new Padding(6, 0, 6, 0);
            label_name.Name = "label_name";
            label_name.Size = new Size(65, 29);
            label_name.TabIndex = 5;
            label_name.Text = "Name";
            // 
            // numIconIndex
            // 
            numIconIndex.Font = new Font("Cascadia Code", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            numIconIndex.Location = new Point(293, 81);
            numIconIndex.Margin = new Padding(6);
            numIconIndex.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            numIconIndex.Minimum = new decimal(new int[] { 1, 0, 0, int.MinValue });
            numIconIndex.Name = "numIconIndex";
            numIconIndex.Size = new Size(121, 33);
            numIconIndex.TabIndex = 6;
            // 
            // label_iconIndex
            // 
            label_iconIndex.AutoSize = true;
            label_iconIndex.Font = new Font("Cascadia Code", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            label_iconIndex.Location = new Point(293, 43);
            label_iconIndex.Margin = new Padding(6, 0, 6, 0);
            label_iconIndex.Name = "label_iconIndex";
            label_iconIndex.Size = new Size(65, 29);
            label_iconIndex.TabIndex = 7;
            label_iconIndex.Text = "Icon";
            // 
            // listBoxCategories
            // 
            listBoxCategories.Font = new Font("Victor Mono SemiBold", 10.124999F, FontStyle.Bold, GraphicsUnit.Point);
            listBoxCategories.ItemHeight = 33;
            listBoxCategories.Location = new Point(22, 85);
            listBoxCategories.Margin = new Padding(6);
            listBoxCategories.Name = "listBoxCategories";
            listBoxCategories.Size = new Size(353, 697);
            listBoxCategories.TabIndex = 57;
            // 
            // labelCategories
            // 
            labelCategories.AutoSize = true;
            labelCategories.Font = new Font("Cascadia Code", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            labelCategories.Location = new Point(37, 19);
            labelCategories.Margin = new Padding(6, 0, 6, 0);
            labelCategories.Name = "labelCategories";
            labelCategories.Size = new Size(349, 56);
            labelCategories.TabIndex = 58;
            labelCategories.Text = "CATEGORY KEYS";
            // 
            // buttonAddCategory
            // 
            buttonAddCategory.Font = new Font("Cascadia Code", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            buttonAddCategory.ForeColor = Color.Green;
            buttonAddCategory.Location = new Point(174, 799);
            buttonAddCategory.Margin = new Padding(6);
            buttonAddCategory.Name = "buttonAddCategory";
            buttonAddCategory.Size = new Size(201, 62);
            buttonAddCategory.TabIndex = 67;
            buttonAddCategory.Text = "➕";
            buttonAddCategory.UseVisualStyleBackColor = true;
            buttonAddCategory.Click += buttonAddCategory_Click;
            // 
            // buttonDeleteCategory
            // 
            buttonDeleteCategory.Font = new Font("Cascadia Code", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            buttonDeleteCategory.ForeColor = Color.Red;
            buttonDeleteCategory.Location = new Point(22, 799);
            buttonDeleteCategory.Margin = new Padding(6);
            buttonDeleteCategory.Name = "buttonDeleteCategory";
            buttonDeleteCategory.Size = new Size(145, 62);
            buttonDeleteCategory.TabIndex = 66;
            buttonDeleteCategory.Text = "❌";
            buttonDeleteCategory.UseVisualStyleBackColor = true;
            buttonDeleteCategory.Click += buttonDeleteCategory_Click;
            // 
            // CraftCategoryHelper
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1872, 876);
            Controls.Add(buttonAddCategory);
            Controls.Add(buttonDeleteCategory);
            Controls.Add(listBoxCategories);
            Controls.Add(labelCategories);
            Controls.Add(groupBox_coreData);
            Margin = new Padding(6);
            Name = "CraftCategoryHelper";
            Text = "Crafting Category Helper";
            groupBox_coreData.ResumeLayout(false);
            groupBox_coreData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numIconIndex).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox_coreData;
        private Label labelDescription;
        private TextBox textBoxDescription;
        private CheckBox checkBoxUnlockedByDefault;
        private TextBox textBoxKey;
        private Label label_key;
        private TextBox textBoxName;
        private Label label_name;
        private NumericUpDown numIconIndex;
        private Label label_iconIndex;
        private ListBox listBoxCategories;
        private Label labelCategories;
        private Button buttonAddCategory;
        private Button buttonDeleteCategory;
    }
}
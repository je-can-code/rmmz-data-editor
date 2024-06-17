namespace JMZ.Dashboard.Boards.Craft
{
    partial class CraftBoard
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
            listboxRecipes = new ListBox();
            groupBox_coreData = new GroupBox();
            buttonCategoryHelper = new Button();
            buttonDeleteCategory = new Button();
            buttonAddCategory = new Button();
            listBoxCategories = new ListBox();
            labelDescription = new Label();
            textBoxDescription = new TextBox();
            checkBox_maskedUntilCrafted = new CheckBox();
            checkBox_unlockedByDefault = new CheckBox();
            textBox_key = new TextBox();
            label_key = new Label();
            textBox_name = new TextBox();
            label_name = new Label();
            num_iconIndex = new NumericUpDown();
            label_iconIndex = new Label();
            groupBoxComponents = new GroupBox();
            labelHelpOutput = new Label();
            labelHelpTools = new Label();
            labelHelpIngredients = new Label();
            buttonDeleteOutput = new Button();
            buttonCloneToOutputs = new Button();
            buttonDeleteTool = new Button();
            buttonCloneToTools = new Button();
            listBoxIngredients = new ListBox();
            buttonDeleteIngredient = new Button();
            buttonCloneToIngredients = new Button();
            buttonComponentHelper = new Button();
            labelOutput = new Label();
            labelTools = new Label();
            labelIngredients = new Label();
            listBoxTools = new ListBox();
            listBoxOutput = new ListBox();
            labelRecipes = new Label();
            buttonAddRecipe = new Button();
            buttonDeleteRecipe = new Button();
            buttonCloneRecipe = new Button();
            groupBox_coreData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)num_iconIndex).BeginInit();
            groupBoxComponents.SuspendLayout();
            SuspendLayout();
            // 
            // listboxRecipes
            // 
            listboxRecipes.Font = new Font("Victor Mono SemiBold", 10.124999F, FontStyle.Bold);
            listboxRecipes.ItemHeight = 33;
            listboxRecipes.Location = new Point(17, 85);
            listboxRecipes.Margin = new Padding(6);
            listboxRecipes.Name = "listboxRecipes";
            listboxRecipes.Size = new Size(452, 1126);
            listboxRecipes.TabIndex = 60;
            // 
            // groupBox_coreData
            // 
            groupBox_coreData.Controls.Add(buttonCategoryHelper);
            groupBox_coreData.Controls.Add(buttonDeleteCategory);
            groupBox_coreData.Controls.Add(buttonAddCategory);
            groupBox_coreData.Controls.Add(listBoxCategories);
            groupBox_coreData.Controls.Add(labelDescription);
            groupBox_coreData.Controls.Add(textBoxDescription);
            groupBox_coreData.Controls.Add(checkBox_maskedUntilCrafted);
            groupBox_coreData.Controls.Add(checkBox_unlockedByDefault);
            groupBox_coreData.Controls.Add(textBox_key);
            groupBox_coreData.Controls.Add(label_key);
            groupBox_coreData.Controls.Add(textBox_name);
            groupBox_coreData.Controls.Add(label_name);
            groupBox_coreData.Controls.Add(num_iconIndex);
            groupBox_coreData.Controls.Add(label_iconIndex);
            groupBox_coreData.Font = new Font("Cascadia Code", 8.25F);
            groupBox_coreData.Location = new Point(481, 19);
            groupBox_coreData.Margin = new Padding(6);
            groupBox_coreData.Name = "groupBox_coreData";
            groupBox_coreData.Padding = new Padding(6);
            groupBox_coreData.Size = new Size(1298, 448);
            groupBox_coreData.TabIndex = 62;
            groupBox_coreData.TabStop = false;
            groupBox_coreData.Text = "Core Data";
            // 
            // buttonCategoryHelper
            // 
            buttonCategoryHelper.FlatStyle = FlatStyle.Flat;
            buttonCategoryHelper.Font = new Font("Cascadia Code", 8.25F);
            buttonCategoryHelper.Location = new Point(948, 32);
            buttonCategoryHelper.Margin = new Padding(6);
            buttonCategoryHelper.Name = "buttonCategoryHelper";
            buttonCategoryHelper.Size = new Size(332, 53);
            buttonCategoryHelper.TabIndex = 70;
            buttonCategoryHelper.Text = "Summon Category Helper";
            buttonCategoryHelper.UseVisualStyleBackColor = true;
            buttonCategoryHelper.Click += buttonCategoryHelper_Click;
            // 
            // buttonDeleteCategory
            // 
            buttonDeleteCategory.FlatStyle = FlatStyle.Popup;
            buttonDeleteCategory.Font = new Font("Cascadia Code", 8.25F);
            buttonDeleteCategory.ForeColor = Color.Red;
            buttonDeleteCategory.Location = new Point(1204, 349);
            buttonDeleteCategory.Margin = new Padding(6);
            buttonDeleteCategory.Name = "buttonDeleteCategory";
            buttonDeleteCategory.Size = new Size(76, 74);
            buttonDeleteCategory.TabIndex = 72;
            buttonDeleteCategory.Text = "❌";
            buttonDeleteCategory.UseVisualStyleBackColor = true;
            buttonDeleteCategory.Click += buttonDeleteCategory_Click;
            // 
            // buttonAddCategory
            // 
            buttonAddCategory.FlatStyle = FlatStyle.Popup;
            buttonAddCategory.Font = new Font("Cascadia Code", 12F);
            buttonAddCategory.ForeColor = Color.CornflowerBlue;
            buttonAddCategory.Location = new Point(948, 349);
            buttonAddCategory.Margin = new Padding(6);
            buttonAddCategory.Name = "buttonAddCategory";
            buttonAddCategory.Size = new Size(244, 74);
            buttonAddCategory.TabIndex = 71;
            buttonAddCategory.TabStop = false;
            buttonAddCategory.Text = "📩";
            buttonAddCategory.UseVisualStyleBackColor = true;
            buttonAddCategory.Click += buttonAddCategory_Click;
            // 
            // listBoxCategories
            // 
            listBoxCategories.Font = new Font("Victor Mono SemiBold", 10.124999F, FontStyle.Bold);
            listBoxCategories.FormattingEnabled = true;
            listBoxCategories.ItemHeight = 33;
            listBoxCategories.Location = new Point(948, 97);
            listBoxCategories.Margin = new Padding(6);
            listBoxCategories.Name = "listBoxCategories";
            listBoxCategories.Size = new Size(332, 235);
            listBoxCategories.TabIndex = 70;
            // 
            // labelDescription
            // 
            labelDescription.AutoSize = true;
            labelDescription.Font = new Font("Cascadia Code", 8.25F);
            labelDescription.Location = new Point(11, 243);
            labelDescription.Margin = new Padding(6, 0, 6, 0);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(156, 29);
            labelDescription.TabIndex = 61;
            labelDescription.Text = "Description";
            // 
            // textBoxDescription
            // 
            textBoxDescription.Font = new Font("Cascadia Code", 9.75F);
            textBoxDescription.Location = new Point(11, 282);
            textBoxDescription.Margin = new Padding(6);
            textBoxDescription.Multiline = true;
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.Size = new Size(925, 141);
            textBoxDescription.TabIndex = 60;
            // 
            // checkBox_maskedUntilCrafted
            // 
            checkBox_maskedUntilCrafted.AutoSize = true;
            checkBox_maskedUntilCrafted.Checked = true;
            checkBox_maskedUntilCrafted.CheckState = CheckState.Checked;
            checkBox_maskedUntilCrafted.Font = new Font("Cascadia Code", 8.25F);
            checkBox_maskedUntilCrafted.Location = new Point(514, 216);
            checkBox_maskedUntilCrafted.Margin = new Padding(6);
            checkBox_maskedUntilCrafted.Name = "checkBox_maskedUntilCrafted";
            checkBox_maskedUntilCrafted.Size = new Size(305, 33);
            checkBox_maskedUntilCrafted.TabIndex = 32;
            checkBox_maskedUntilCrafted.Text = "Masked Until Crafted";
            checkBox_maskedUntilCrafted.UseVisualStyleBackColor = false;
            // 
            // checkBox_unlockedByDefault
            // 
            checkBox_unlockedByDefault.AutoSize = true;
            checkBox_unlockedByDefault.Font = new Font("Cascadia Code", 8.25F);
            checkBox_unlockedByDefault.Location = new Point(514, 157);
            checkBox_unlockedByDefault.Margin = new Padding(6);
            checkBox_unlockedByDefault.Name = "checkBox_unlockedByDefault";
            checkBox_unlockedByDefault.Size = new Size(292, 33);
            checkBox_unlockedByDefault.TabIndex = 31;
            checkBox_unlockedByDefault.Text = "Unlocked By Default";
            checkBox_unlockedByDefault.UseVisualStyleBackColor = false;
            // 
            // textBox_key
            // 
            textBox_key.BorderStyle = BorderStyle.FixedSingle;
            textBox_key.Font = new Font("Cascadia Code", 8.25F);
            textBox_key.Location = new Point(11, 81);
            textBox_key.Margin = new Padding(6);
            textBox_key.Name = "textBox_key";
            textBox_key.Size = new Size(424, 33);
            textBox_key.TabIndex = 2;
            textBox_key.TextChanged += UpdateKey;
            // 
            // label_key
            // 
            label_key.AutoSize = true;
            label_key.Font = new Font("Cascadia Code", 8.25F);
            label_key.Location = new Point(11, 43);
            label_key.Margin = new Padding(6, 0, 6, 0);
            label_key.Name = "label_key";
            label_key.Size = new Size(52, 29);
            label_key.TabIndex = 3;
            label_key.Text = "Key";
            // 
            // textBox_name
            // 
            textBox_name.BorderStyle = BorderStyle.FixedSingle;
            textBox_name.Font = new Font("Cascadia Code", 8.25F);
            textBox_name.Location = new Point(11, 181);
            textBox_name.Margin = new Padding(6);
            textBox_name.Name = "textBox_name";
            textBox_name.Size = new Size(425, 33);
            textBox_name.TabIndex = 4;
            textBox_name.TextChanged += UpdateName;
            // 
            // label_name
            // 
            label_name.AutoSize = true;
            label_name.Font = new Font("Cascadia Code", 8.25F);
            label_name.Location = new Point(13, 143);
            label_name.Margin = new Padding(6, 0, 6, 0);
            label_name.Name = "label_name";
            label_name.Size = new Size(65, 29);
            label_name.TabIndex = 5;
            label_name.Text = "Name";
            // 
            // num_iconIndex
            // 
            num_iconIndex.Font = new Font("Cascadia Code", 10.125F);
            num_iconIndex.Location = new Point(514, 81);
            num_iconIndex.Margin = new Padding(11, 13, 11, 13);
            num_iconIndex.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            num_iconIndex.Minimum = new decimal(new int[] { 1, 0, 0, int.MinValue });
            num_iconIndex.Name = "num_iconIndex";
            num_iconIndex.Size = new Size(225, 39);
            num_iconIndex.TabIndex = 6;
            num_iconIndex.TextAlign = HorizontalAlignment.Center;
            // 
            // label_iconIndex
            // 
            label_iconIndex.AutoSize = true;
            label_iconIndex.Font = new Font("Cascadia Code", 8.25F);
            label_iconIndex.Location = new Point(514, 39);
            label_iconIndex.Margin = new Padding(6, 0, 6, 0);
            label_iconIndex.Name = "label_iconIndex";
            label_iconIndex.Size = new Size(65, 29);
            label_iconIndex.TabIndex = 7;
            label_iconIndex.Text = "Icon";
            // 
            // groupBoxComponents
            // 
            groupBoxComponents.Controls.Add(labelHelpOutput);
            groupBoxComponents.Controls.Add(labelHelpTools);
            groupBoxComponents.Controls.Add(labelHelpIngredients);
            groupBoxComponents.Controls.Add(buttonDeleteOutput);
            groupBoxComponents.Controls.Add(buttonCloneToOutputs);
            groupBoxComponents.Controls.Add(buttonDeleteTool);
            groupBoxComponents.Controls.Add(buttonCloneToTools);
            groupBoxComponents.Controls.Add(listBoxIngredients);
            groupBoxComponents.Controls.Add(buttonDeleteIngredient);
            groupBoxComponents.Controls.Add(buttonCloneToIngredients);
            groupBoxComponents.Controls.Add(buttonComponentHelper);
            groupBoxComponents.Controls.Add(labelOutput);
            groupBoxComponents.Controls.Add(labelTools);
            groupBoxComponents.Controls.Add(labelIngredients);
            groupBoxComponents.Controls.Add(listBoxTools);
            groupBoxComponents.Controls.Add(listBoxOutput);
            groupBoxComponents.Font = new Font("Cascadia Code", 8.25F);
            groupBoxComponents.Location = new Point(481, 482);
            groupBoxComponents.Margin = new Padding(6);
            groupBoxComponents.Name = "groupBoxComponents";
            groupBoxComponents.Padding = new Padding(6);
            groupBoxComponents.Size = new Size(2097, 821);
            groupBoxComponents.TabIndex = 63;
            groupBoxComponents.TabStop = false;
            groupBoxComponents.Text = "Component Data";
            // 
            // labelHelpOutput
            // 
            labelHelpOutput.AutoSize = true;
            labelHelpOutput.Font = new Font("Cascadia Code", 9.75F);
            labelHelpOutput.ForeColor = Color.Goldenrod;
            labelHelpOutput.Location = new Point(1525, 16);
            labelHelpOutput.Margin = new Padding(6, 0, 6, 0);
            labelHelpOutput.Name = "labelHelpOutput";
            labelHelpOutput.Size = new Size(49, 34);
            labelHelpOutput.TabIndex = 71;
            labelHelpOutput.Text = "❓";
            // 
            // labelHelpTools
            // 
            labelHelpTools.AutoSize = true;
            labelHelpTools.Font = new Font("Cascadia Code", 9.75F);
            labelHelpTools.ForeColor = Color.Goldenrod;
            labelHelpTools.Location = new Point(795, 14);
            labelHelpTools.Margin = new Padding(6, 0, 6, 0);
            labelHelpTools.Name = "labelHelpTools";
            labelHelpTools.Size = new Size(49, 34);
            labelHelpTools.TabIndex = 70;
            labelHelpTools.Text = "❓";
            // 
            // labelHelpIngredients
            // 
            labelHelpIngredients.AutoSize = true;
            labelHelpIngredients.Font = new Font("Cascadia Code", 9.75F);
            labelHelpIngredients.ForeColor = Color.Goldenrod;
            labelHelpIngredients.Location = new Point(158, 32);
            labelHelpIngredients.Margin = new Padding(6, 0, 6, 0);
            labelHelpIngredients.Name = "labelHelpIngredients";
            labelHelpIngredients.Size = new Size(49, 34);
            labelHelpIngredients.TabIndex = 66;
            labelHelpIngredients.Text = "❓";
            // 
            // buttonDeleteOutput
            // 
            buttonDeleteOutput.FlatStyle = FlatStyle.Popup;
            buttonDeleteOutput.Font = new Font("Cascadia Code", 12F);
            buttonDeleteOutput.ForeColor = Color.Red;
            buttonDeleteOutput.Location = new Point(1867, 553);
            buttonDeleteOutput.Margin = new Padding(6);
            buttonDeleteOutput.Name = "buttonDeleteOutput";
            buttonDeleteOutput.Size = new Size(127, 72);
            buttonDeleteOutput.TabIndex = 69;
            buttonDeleteOutput.Text = "❌";
            buttonDeleteOutput.UseVisualStyleBackColor = true;
            buttonDeleteOutput.Click += buttonDeleteOutput_Click;
            // 
            // buttonCloneToOutputs
            // 
            buttonCloneToOutputs.FlatStyle = FlatStyle.Popup;
            buttonCloneToOutputs.Font = new Font("Cascadia Code", 12F);
            buttonCloneToOutputs.ForeColor = Color.Blue;
            buttonCloneToOutputs.Location = new Point(1525, 553);
            buttonCloneToOutputs.Margin = new Padding(6);
            buttonCloneToOutputs.Name = "buttonCloneToOutputs";
            buttonCloneToOutputs.Size = new Size(330, 72);
            buttonCloneToOutputs.TabIndex = 68;
            buttonCloneToOutputs.Text = "📩";
            buttonCloneToOutputs.UseVisualStyleBackColor = true;
            buttonCloneToOutputs.Click += buttonCloneToOutputs_Click;
            // 
            // buttonDeleteTool
            // 
            buttonDeleteTool.FlatStyle = FlatStyle.Popup;
            buttonDeleteTool.Font = new Font("Cascadia Code", 8.25F);
            buttonDeleteTool.ForeColor = Color.Red;
            buttonDeleteTool.Location = new Point(1180, 555);
            buttonDeleteTool.Margin = new Padding(6);
            buttonDeleteTool.Name = "buttonDeleteTool";
            buttonDeleteTool.Size = new Size(148, 72);
            buttonDeleteTool.TabIndex = 67;
            buttonDeleteTool.Text = "❌";
            buttonDeleteTool.UseVisualStyleBackColor = true;
            buttonDeleteTool.Click += buttonDeleteTool_Click;
            // 
            // buttonCloneToTools
            // 
            buttonCloneToTools.FlatStyle = FlatStyle.Popup;
            buttonCloneToTools.Font = new Font("Cascadia Code", 12F);
            buttonCloneToTools.ForeColor = Color.Blue;
            buttonCloneToTools.Location = new Point(816, 555);
            buttonCloneToTools.Margin = new Padding(6);
            buttonCloneToTools.Name = "buttonCloneToTools";
            buttonCloneToTools.Size = new Size(352, 72);
            buttonCloneToTools.TabIndex = 66;
            buttonCloneToTools.Text = "📩";
            buttonCloneToTools.UseVisualStyleBackColor = true;
            buttonCloneToTools.Click += buttonCloneToTools_Click;
            // 
            // listBoxIngredients
            // 
            listBoxIngredients.Font = new Font("Victor Mono SemiBold", 10.124999F, FontStyle.Bold);
            listBoxIngredients.FormattingEnabled = true;
            listBoxIngredients.ItemHeight = 33;
            listBoxIngredients.Location = new Point(11, 75);
            listBoxIngredients.Margin = new Padding(6);
            listBoxIngredients.Name = "listBoxIngredients";
            listBoxIngredients.Size = new Size(679, 466);
            listBoxIngredients.TabIndex = 65;
            // 
            // buttonDeleteIngredient
            // 
            buttonDeleteIngredient.FlatStyle = FlatStyle.Popup;
            buttonDeleteIngredient.Font = new Font("Cascadia Code", 12F);
            buttonDeleteIngredient.ForeColor = Color.Red;
            buttonDeleteIngredient.Location = new Point(428, 555);
            buttonDeleteIngredient.Margin = new Padding(6);
            buttonDeleteIngredient.Name = "buttonDeleteIngredient";
            buttonDeleteIngredient.Size = new Size(154, 72);
            buttonDeleteIngredient.TabIndex = 64;
            buttonDeleteIngredient.Text = "❌";
            buttonDeleteIngredient.UseVisualStyleBackColor = true;
            buttonDeleteIngredient.Click += buttonDeleteIngredient_Click;
            // 
            // buttonCloneToIngredients
            // 
            buttonCloneToIngredients.FlatStyle = FlatStyle.Popup;
            buttonCloneToIngredients.Font = new Font("Cascadia Code", 12F);
            buttonCloneToIngredients.ForeColor = Color.Blue;
            buttonCloneToIngredients.Location = new Point(93, 555);
            buttonCloneToIngredients.Margin = new Padding(6);
            buttonCloneToIngredients.Name = "buttonCloneToIngredients";
            buttonCloneToIngredients.Size = new Size(323, 72);
            buttonCloneToIngredients.TabIndex = 63;
            buttonCloneToIngredients.Text = "📩";
            buttonCloneToIngredients.UseVisualStyleBackColor = true;
            buttonCloneToIngredients.Click += buttonCloneToIngredients_Click;
            // 
            // buttonComponentHelper
            // 
            buttonComponentHelper.FlatStyle = FlatStyle.Flat;
            buttonComponentHelper.Font = new Font("Cascadia Code", 12F);
            buttonComponentHelper.Location = new Point(337, 682);
            buttonComponentHelper.Margin = new Padding(6);
            buttonComponentHelper.Name = "buttonComponentHelper";
            buttonComponentHelper.Size = new Size(1275, 127);
            buttonComponentHelper.TabIndex = 60;
            buttonComponentHelper.Text = "Summon Component Helper";
            buttonComponentHelper.UseVisualStyleBackColor = true;
            buttonComponentHelper.Click += buttonComponentHelper_Click;
            // 
            // labelOutput
            // 
            labelOutput.AutoSize = true;
            labelOutput.Font = new Font("Cascadia Code", 8.25F);
            labelOutput.Location = new Point(1434, 20);
            labelOutput.Margin = new Padding(6, 0, 6, 0);
            labelOutput.Name = "labelOutput";
            labelOutput.Size = new Size(91, 29);
            labelOutput.TabIndex = 61;
            labelOutput.Text = "OUTPUT";
            // 
            // labelTools
            // 
            labelTools.AutoSize = true;
            labelTools.Font = new Font("Cascadia Code", 8.25F);
            labelTools.Location = new Point(715, 14);
            labelTools.Margin = new Padding(6, 0, 6, 0);
            labelTools.Name = "labelTools";
            labelTools.Size = new Size(78, 29);
            labelTools.TabIndex = 60;
            labelTools.Text = "TOOLS";
            // 
            // labelIngredients
            // 
            labelIngredients.AutoSize = true;
            labelIngredients.Font = new Font("Cascadia Code", 8.25F);
            labelIngredients.Location = new Point(11, 36);
            labelIngredients.Margin = new Padding(6, 0, 6, 0);
            labelIngredients.Name = "labelIngredients";
            labelIngredients.Size = new Size(156, 29);
            labelIngredients.TabIndex = 59;
            labelIngredients.Text = "INGREDIENTS";
            // 
            // listBoxTools
            // 
            listBoxTools.Font = new Font("Victor Mono SemiBold", 10.124999F, FontStyle.Bold);
            listBoxTools.FormattingEnabled = true;
            listBoxTools.ItemHeight = 33;
            listBoxTools.Location = new Point(702, 75);
            listBoxTools.Margin = new Padding(6);
            listBoxTools.Name = "listBoxTools";
            listBoxTools.Size = new Size(720, 466);
            listBoxTools.TabIndex = 57;
            // 
            // listBoxOutput
            // 
            listBoxOutput.Font = new Font("Victor Mono SemiBold", 10.124999F, FontStyle.Bold);
            listBoxOutput.FormattingEnabled = true;
            listBoxOutput.ItemHeight = 33;
            listBoxOutput.Location = new Point(1434, 75);
            listBoxOutput.Margin = new Padding(6);
            listBoxOutput.Name = "listBoxOutput";
            listBoxOutput.Size = new Size(651, 466);
            listBoxOutput.TabIndex = 58;
            // 
            // labelRecipes
            // 
            labelRecipes.AutoSize = true;
            labelRecipes.Font = new Font("Cascadia Code", 15.75F);
            labelRecipes.Location = new Point(48, 19);
            labelRecipes.Margin = new Padding(6, 0, 6, 0);
            labelRecipes.Name = "labelRecipes";
            labelRecipes.Size = new Size(299, 56);
            labelRecipes.TabIndex = 61;
            labelRecipes.Text = "RECIPE KEYS";
            // 
            // buttonAddRecipe
            // 
            buttonAddRecipe.Font = new Font("Cascadia Code", 8.25F);
            buttonAddRecipe.ForeColor = Color.Green;
            buttonAddRecipe.Location = new Point(319, 1227);
            buttonAddRecipe.Margin = new Padding(6);
            buttonAddRecipe.Name = "buttonAddRecipe";
            buttonAddRecipe.Size = new Size(150, 62);
            buttonAddRecipe.TabIndex = 65;
            buttonAddRecipe.Text = "✨";
            buttonAddRecipe.UseVisualStyleBackColor = true;
            buttonAddRecipe.Click += buttonAddRecipe_Click;
            // 
            // buttonDeleteRecipe
            // 
            buttonDeleteRecipe.Font = new Font("Cascadia Code", 8.25F);
            buttonDeleteRecipe.ForeColor = Color.Red;
            buttonDeleteRecipe.Location = new Point(17, 1227);
            buttonDeleteRecipe.Margin = new Padding(6);
            buttonDeleteRecipe.Name = "buttonDeleteRecipe";
            buttonDeleteRecipe.Size = new Size(109, 62);
            buttonDeleteRecipe.TabIndex = 64;
            buttonDeleteRecipe.Text = "❌";
            buttonDeleteRecipe.UseVisualStyleBackColor = true;
            buttonDeleteRecipe.Click += buttonDeleteRecipe_Click;
            // 
            // buttonCloneRecipe
            // 
            buttonCloneRecipe.Font = new Font("Cascadia Code", 9.75F, FontStyle.Bold);
            buttonCloneRecipe.ForeColor = Color.CornflowerBlue;
            buttonCloneRecipe.Location = new Point(138, 1227);
            buttonCloneRecipe.Margin = new Padding(6);
            buttonCloneRecipe.Name = "buttonCloneRecipe";
            buttonCloneRecipe.Size = new Size(169, 62);
            buttonCloneRecipe.TabIndex = 66;
            buttonCloneRecipe.Text = "📄📄";
            buttonCloneRecipe.UseVisualStyleBackColor = true;
            buttonCloneRecipe.Click += buttonCloneRecipe_Click;
            // 
            // CraftBoard
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2593, 1318);
            Controls.Add(buttonCloneRecipe);
            Controls.Add(buttonAddRecipe);
            Controls.Add(buttonDeleteRecipe);
            Controls.Add(listboxRecipes);
            Controls.Add(groupBox_coreData);
            Controls.Add(groupBoxComponents);
            Controls.Add(labelRecipes);
            Margin = new Padding(6);
            Name = "CraftBoard";
            Text = "Crafting Recipe Editor";
            groupBox_coreData.ResumeLayout(false);
            groupBox_coreData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)num_iconIndex).EndInit();
            groupBoxComponents.ResumeLayout(false);
            groupBoxComponents.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listboxRecipes;
        private GroupBox groupBox_coreData;
        private Button buttonCategoryHelper;
        private Button buttonDeleteCategory;
        private Button buttonAddCategory;
        private ListBox listBoxCategories;
        private Label labelDescription;
        private TextBox textBoxDescription;
        private CheckBox checkBox_maskedUntilCrafted;
        private CheckBox checkBox_unlockedByDefault;
        private TextBox textBox_key;
        private Label label_key;
        private TextBox textBox_name;
        private Label label_name;
        private NumericUpDown num_iconIndex;
        private Label label_iconIndex;
        private GroupBox groupBoxComponents;
        private Button buttonDeleteOutput;
        private Button buttonCloneToOutputs;
        private Button buttonDeleteTool;
        private Button buttonCloneToTools;
        private ListBox listBoxIngredients;
        private Button buttonDeleteIngredient;
        private Button buttonCloneToIngredients;
        private Button buttonComponentHelper;
        private Label labelOutput;
        private Label labelTools;
        private Label labelIngredients;
        private ListBox listBoxTools;
        private ListBox listBoxOutput;
        private Label labelRecipes;
        private Button buttonAddRecipe;
        private Button buttonDeleteRecipe;
        private Label labelHelpOutput;
        private Label labelHelpTools;
        private Label labelHelpIngredients;
        private Button buttonCloneRecipe;
    }
}
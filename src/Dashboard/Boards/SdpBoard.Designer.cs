namespace JMZ.Dashboard.Boards
{
    partial class SdpBoard
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
            listBox_Sdps = new ListBox();
            textBox_key = new TextBox();
            label_key = new Label();
            label_name = new Label();
            textBox_name = new TextBox();
            num_iconIndex = new NumericUpDown();
            label_iconIndex = new Label();
            checkBox_unlockedByDefault = new CheckBox();
            label_maxRank = new Label();
            num_maxRank = new NumericUpDown();
            label_flatGrowth = new Label();
            num_flatGrowth = new NumericUpDown();
            label_multGrowth = new Label();
            num_multGrowth = new NumericUpDown();
            label_description = new Label();
            textBox_description = new TextBox();
            label_flavorText = new Label();
            textBox_flavorText = new TextBox();
            listBox_parameters = new ListBox();
            listBox_rewards = new ListBox();
            groupBox_parameterData = new GroupBox();
            comboBox_parameter = new ComboBox();
            label_parameter = new Label();
            checkBox_isCore = new CheckBox();
            checkBox_isFlat = new CheckBox();
            label_ = new Label();
            num_paramGrowthPerRank = new NumericUpDown();
            button_addParameter = new Button();
            button_removeParameter = new Button();
            groupBox_rewardData = new GroupBox();
            textBox_rewardName = new TextBox();
            label1 = new Label();
            button_addReward = new Button();
            button_removeReward = new Button();
            textBox_rewardEffect = new TextBox();
            label_rewardEffect = new Label();
            label_rankRequiredForReward = new Label();
            num_rewardRankRequired = new NumericUpDown();
            button_addSdp = new Button();
            button_removeSdp = new Button();
            groupBox_coreData = new GroupBox();
            comboBox_rarity = new ComboBox();
            label_rarity = new Label();
            groupBox_costData = new GroupBox();
            num_baseCost = new NumericUpDown();
            label_baseCost = new Label();
            groupBox_descriptionData = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)num_iconIndex).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num_maxRank).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num_flatGrowth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num_multGrowth).BeginInit();
            groupBox_parameterData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)num_paramGrowthPerRank).BeginInit();
            groupBox_rewardData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)num_rewardRankRequired).BeginInit();
            groupBox_coreData.SuspendLayout();
            groupBox_costData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)num_baseCost).BeginInit();
            groupBox_descriptionData.SuspendLayout();
            SuspendLayout();
            // 
            // listBox_Sdps
            // 
            listBox_Sdps.Font = new Font("Victor Mono SemiBold", 10.124999F, FontStyle.Bold);
            listBox_Sdps.ItemHeight = 33;
            listBox_Sdps.Location = new Point(22, 26);
            listBox_Sdps.Margin = new Padding(6);
            listBox_Sdps.Name = "listBox_Sdps";
            listBox_Sdps.Size = new Size(469, 730);
            listBox_Sdps.TabIndex = 1;
            // 
            // textBox_key
            // 
            textBox_key.BorderStyle = BorderStyle.FixedSingle;
            textBox_key.Font = new Font("Cascadia Code", 8.25F);
            textBox_key.Location = new Point(134, 32);
            textBox_key.Margin = new Padding(6);
            textBox_key.Name = "textBox_key";
            textBox_key.Size = new Size(206, 33);
            textBox_key.TabIndex = 2;
            // 
            // label_key
            // 
            label_key.AutoSize = true;
            label_key.Font = new Font("Cascadia Code", 8.25F);
            label_key.Location = new Point(74, 38);
            label_key.Margin = new Padding(6, 0, 6, 0);
            label_key.Name = "label_key";
            label_key.Size = new Size(52, 29);
            label_key.TabIndex = 3;
            label_key.Text = "Key";
            // 
            // label_name
            // 
            label_name.AutoSize = true;
            label_name.Font = new Font("Cascadia Code", 8.25F);
            label_name.Location = new Point(11, 100);
            label_name.Margin = new Padding(6, 0, 6, 0);
            label_name.Name = "label_name";
            label_name.Size = new Size(65, 29);
            label_name.TabIndex = 5;
            label_name.Text = "Name";
            // 
            // textBox_name
            // 
            textBox_name.BorderStyle = BorderStyle.FixedSingle;
            textBox_name.Font = new Font("Cascadia Code", 8.25F);
            textBox_name.Location = new Point(74, 94);
            textBox_name.Margin = new Padding(6);
            textBox_name.Name = "textBox_name";
            textBox_name.Size = new Size(266, 33);
            textBox_name.TabIndex = 4;
            // 
            // num_iconIndex
            // 
            num_iconIndex.Font = new Font("Cascadia Code", 8.25F);
            num_iconIndex.Location = new Point(162, 156);
            num_iconIndex.Margin = new Padding(6);
            num_iconIndex.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            num_iconIndex.Name = "num_iconIndex";
            num_iconIndex.Size = new Size(180, 33);
            num_iconIndex.TabIndex = 6;
            // 
            // label_iconIndex
            // 
            label_iconIndex.AutoSize = true;
            label_iconIndex.Font = new Font("Cascadia Code", 8.25F);
            label_iconIndex.Location = new Point(7, 160);
            label_iconIndex.Margin = new Padding(6, 0, 6, 0);
            label_iconIndex.Name = "label_iconIndex";
            label_iconIndex.Size = new Size(143, 29);
            label_iconIndex.TabIndex = 7;
            label_iconIndex.Text = "Icon Index";
            // 
            // checkBox_unlockedByDefault
            // 
            checkBox_unlockedByDefault.AutoSize = true;
            checkBox_unlockedByDefault.Font = new Font("Cascadia Code", 8.25F);
            checkBox_unlockedByDefault.Location = new Point(11, 218);
            checkBox_unlockedByDefault.Margin = new Padding(6);
            checkBox_unlockedByDefault.Name = "checkBox_unlockedByDefault";
            checkBox_unlockedByDefault.Size = new Size(292, 33);
            checkBox_unlockedByDefault.TabIndex = 31;
            checkBox_unlockedByDefault.Text = "Unlocked By Default";
            checkBox_unlockedByDefault.UseVisualStyleBackColor = false;
            // 
            // label_maxRank
            // 
            label_maxRank.AutoSize = true;
            label_maxRank.Font = new Font("Cascadia Code", 8.25F);
            label_maxRank.Location = new Point(50, 51);
            label_maxRank.Margin = new Padding(6, 0, 6, 0);
            label_maxRank.Name = "label_maxRank";
            label_maxRank.Size = new Size(117, 29);
            label_maxRank.TabIndex = 33;
            label_maxRank.Text = "Max Rank";
            // 
            // num_maxRank
            // 
            num_maxRank.Font = new Font("Cascadia Code", 8.25F);
            num_maxRank.Location = new Point(178, 47);
            num_maxRank.Margin = new Padding(6);
            num_maxRank.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            num_maxRank.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            num_maxRank.Name = "num_maxRank";
            num_maxRank.Size = new Size(186, 33);
            num_maxRank.TabIndex = 32;
            num_maxRank.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label_flatGrowth
            // 
            label_flatGrowth.AutoSize = true;
            label_flatGrowth.Font = new Font("Cascadia Code", 8.25F);
            label_flatGrowth.Location = new Point(102, 224);
            label_flatGrowth.Margin = new Padding(6, 0, 6, 0);
            label_flatGrowth.Name = "label_flatGrowth";
            label_flatGrowth.Size = new Size(65, 29);
            label_flatGrowth.TabIndex = 35;
            label_flatGrowth.Text = "Flat";
            // 
            // num_flatGrowth
            // 
            num_flatGrowth.Font = new Font("Cascadia Code", 8.25F);
            num_flatGrowth.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            num_flatGrowth.Location = new Point(178, 220);
            num_flatGrowth.Margin = new Padding(6);
            num_flatGrowth.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            num_flatGrowth.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            num_flatGrowth.Name = "num_flatGrowth";
            num_flatGrowth.Size = new Size(186, 33);
            num_flatGrowth.TabIndex = 34;
            num_flatGrowth.Value = new decimal(new int[] { 50, 0, 0, 0 });
            // 
            // label_multGrowth
            // 
            label_multGrowth.AutoSize = true;
            label_multGrowth.Font = new Font("Cascadia Code", 8.25F);
            label_multGrowth.Location = new Point(24, 290);
            label_multGrowth.Margin = new Padding(6, 0, 6, 0);
            label_multGrowth.Name = "label_multGrowth";
            label_multGrowth.Size = new Size(143, 29);
            label_multGrowth.TabIndex = 37;
            label_multGrowth.Text = "Multiplier";
            // 
            // num_multGrowth
            // 
            num_multGrowth.DecimalPlaces = 2;
            num_multGrowth.Font = new Font("Cascadia Code", 8.25F);
            num_multGrowth.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            num_multGrowth.Location = new Point(178, 286);
            num_multGrowth.Margin = new Padding(6);
            num_multGrowth.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            num_multGrowth.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            num_multGrowth.Name = "num_multGrowth";
            num_multGrowth.Size = new Size(186, 33);
            num_multGrowth.TabIndex = 36;
            num_multGrowth.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label_description
            // 
            label_description.AutoSize = true;
            label_description.Font = new Font("Cascadia Code", 8.25F);
            label_description.Location = new Point(4, 247);
            label_description.Margin = new Padding(6, 0, 6, 0);
            label_description.Name = "label_description";
            label_description.Size = new Size(156, 29);
            label_description.TabIndex = 39;
            label_description.Text = "Description";
            // 
            // textBox_description
            // 
            textBox_description.Font = new Font("Cascadia Code", 8.25F);
            textBox_description.Location = new Point(11, 290);
            textBox_description.Margin = new Padding(6);
            textBox_description.Multiline = true;
            textBox_description.Name = "textBox_description";
            textBox_description.Size = new Size(756, 217);
            textBox_description.TabIndex = 38;
            // 
            // label_flavorText
            // 
            label_flavorText.AutoSize = true;
            label_flavorText.Font = new Font("Cascadia Code", 8.25F);
            label_flavorText.Location = new Point(11, 34);
            label_flavorText.Margin = new Padding(6, 0, 6, 0);
            label_flavorText.Name = "label_flavorText";
            label_flavorText.Size = new Size(156, 29);
            label_flavorText.TabIndex = 41;
            label_flavorText.Text = "Flavor Text";
            // 
            // textBox_flavorText
            // 
            textBox_flavorText.Font = new Font("Cascadia Code", 8.25F);
            textBox_flavorText.Location = new Point(11, 73);
            textBox_flavorText.Margin = new Padding(6);
            textBox_flavorText.Multiline = true;
            textBox_flavorText.Name = "textBox_flavorText";
            textBox_flavorText.Size = new Size(756, 164);
            textBox_flavorText.TabIndex = 40;
            // 
            // listBox_parameters
            // 
            listBox_parameters.Font = new Font("Cascadia Code", 8.25F);
            listBox_parameters.FormattingEnabled = true;
            listBox_parameters.ItemHeight = 29;
            listBox_parameters.Location = new Point(11, 53);
            listBox_parameters.Margin = new Padding(6);
            listBox_parameters.Name = "listBox_parameters";
            listBox_parameters.Size = new Size(300, 323);
            listBox_parameters.TabIndex = 42;
            // 
            // listBox_rewards
            // 
            listBox_rewards.Font = new Font("Cascadia Code", 8.25F);
            listBox_rewards.FormattingEnabled = true;
            listBox_rewards.ItemHeight = 29;
            listBox_rewards.Location = new Point(11, 47);
            listBox_rewards.Margin = new Padding(6);
            listBox_rewards.Name = "listBox_rewards";
            listBox_rewards.Size = new Size(367, 149);
            listBox_rewards.TabIndex = 43;
            // 
            // groupBox_parameterData
            // 
            groupBox_parameterData.Controls.Add(comboBox_parameter);
            groupBox_parameterData.Controls.Add(label_parameter);
            groupBox_parameterData.Controls.Add(checkBox_isCore);
            groupBox_parameterData.Controls.Add(checkBox_isFlat);
            groupBox_parameterData.Controls.Add(label_);
            groupBox_parameterData.Controls.Add(num_paramGrowthPerRank);
            groupBox_parameterData.Controls.Add(button_addParameter);
            groupBox_parameterData.Controls.Add(button_removeParameter);
            groupBox_parameterData.Controls.Add(listBox_parameters);
            groupBox_parameterData.Font = new Font("Cascadia Code", 8.25F);
            groupBox_parameterData.Location = new Point(503, 399);
            groupBox_parameterData.Margin = new Padding(6);
            groupBox_parameterData.Name = "groupBox_parameterData";
            groupBox_parameterData.Padding = new Padding(6);
            groupBox_parameterData.Size = new Size(667, 482);
            groupBox_parameterData.TabIndex = 44;
            groupBox_parameterData.TabStop = false;
            groupBox_parameterData.Text = "Parameter Data";
            // 
            // comboBox_parameter
            // 
            comboBox_parameter.Font = new Font("Cascadia Code", 8.25F);
            comboBox_parameter.FormattingEnabled = true;
            comboBox_parameter.Location = new Point(323, 339);
            comboBox_parameter.Margin = new Padding(6);
            comboBox_parameter.Name = "comboBox_parameter";
            comboBox_parameter.Size = new Size(271, 37);
            comboBox_parameter.TabIndex = 57;
            // 
            // label_parameter
            // 
            label_parameter.AutoSize = true;
            label_parameter.Font = new Font("Cascadia Code", 8.25F);
            label_parameter.Location = new Point(323, 298);
            label_parameter.Margin = new Padding(6, 0, 6, 0);
            label_parameter.Name = "label_parameter";
            label_parameter.Size = new Size(130, 29);
            label_parameter.TabIndex = 56;
            label_parameter.Text = "Parameter";
            // 
            // checkBox_isCore
            // 
            checkBox_isCore.Appearance = Appearance.Button;
            checkBox_isCore.FlatStyle = FlatStyle.Flat;
            checkBox_isCore.Font = new Font("Cascadia Code", 8.25F);
            checkBox_isCore.Location = new Point(323, 38);
            checkBox_isCore.Margin = new Padding(6);
            checkBox_isCore.Name = "checkBox_isCore";
            checkBox_isCore.Size = new Size(332, 39);
            checkBox_isCore.TabIndex = 55;
            checkBox_isCore.Text = "Is Core Parameter";
            checkBox_isCore.TextAlign = ContentAlignment.MiddleCenter;
            checkBox_isCore.UseVisualStyleBackColor = false;
            // 
            // checkBox_isFlat
            // 
            checkBox_isFlat.Appearance = Appearance.Button;
            checkBox_isFlat.FlatStyle = FlatStyle.Flat;
            checkBox_isFlat.Font = new Font("Cascadia Code", 8.25F);
            checkBox_isFlat.Location = new Point(323, 99);
            checkBox_isFlat.Margin = new Padding(6);
            checkBox_isFlat.Name = "checkBox_isFlat";
            checkBox_isFlat.Size = new Size(332, 39);
            checkBox_isFlat.TabIndex = 54;
            checkBox_isFlat.Text = "Is Percent Growth";
            checkBox_isFlat.TextAlign = ContentAlignment.MiddleCenter;
            checkBox_isFlat.UseVisualStyleBackColor = false;
            // 
            // label_
            // 
            label_.AutoSize = true;
            label_.Font = new Font("Cascadia Code", 8.25F);
            label_.Location = new Point(323, 166);
            label_.Margin = new Padding(6, 0, 6, 0);
            label_.Name = "label_";
            label_.Size = new Size(208, 29);
            label_.TabIndex = 53;
            label_.Text = "Growth Per Rank";
            // 
            // num_paramGrowthPerRank
            // 
            num_paramGrowthPerRank.DecimalPlaces = 2;
            num_paramGrowthPerRank.Font = new Font("Cascadia Code", 8.25F);
            num_paramGrowthPerRank.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            num_paramGrowthPerRank.Location = new Point(323, 206);
            num_paramGrowthPerRank.Margin = new Padding(6);
            num_paramGrowthPerRank.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            num_paramGrowthPerRank.Minimum = new decimal(new int[] { 9999, 0, 0, int.MinValue });
            num_paramGrowthPerRank.Name = "num_paramGrowthPerRank";
            num_paramGrowthPerRank.Size = new Size(186, 33);
            num_paramGrowthPerRank.TabIndex = 52;
            // 
            // button_addParameter
            // 
            button_addParameter.Font = new Font("Cascadia Code", 8.25F);
            button_addParameter.ForeColor = Color.Green;
            button_addParameter.Location = new Point(162, 420);
            button_addParameter.Margin = new Padding(6);
            button_addParameter.Name = "button_addParameter";
            button_addParameter.Size = new Size(149, 49);
            button_addParameter.TabIndex = 51;
            button_addParameter.Text = "✨";
            button_addParameter.UseVisualStyleBackColor = true;
            button_addParameter.Click += button_addParameter_Click;
            // 
            // button_removeParameter
            // 
            button_removeParameter.Font = new Font("Cascadia Code", 8.25F);
            button_removeParameter.ForeColor = Color.Red;
            button_removeParameter.Location = new Point(12, 420);
            button_removeParameter.Margin = new Padding(6);
            button_removeParameter.Name = "button_removeParameter";
            button_removeParameter.Size = new Size(138, 49);
            button_removeParameter.TabIndex = 50;
            button_removeParameter.Text = "❌";
            button_removeParameter.UseVisualStyleBackColor = true;
            button_removeParameter.Click += button_removeParameter_Click;
            // 
            // groupBox_rewardData
            // 
            groupBox_rewardData.Controls.Add(textBox_rewardName);
            groupBox_rewardData.Controls.Add(label1);
            groupBox_rewardData.Controls.Add(button_addReward);
            groupBox_rewardData.Controls.Add(button_removeReward);
            groupBox_rewardData.Controls.Add(textBox_rewardEffect);
            groupBox_rewardData.Controls.Add(label_rewardEffect);
            groupBox_rewardData.Controls.Add(label_rankRequiredForReward);
            groupBox_rewardData.Controls.Add(num_rewardRankRequired);
            groupBox_rewardData.Controls.Add(listBox_rewards);
            groupBox_rewardData.Font = new Font("Cascadia Code", 8.25F);
            groupBox_rewardData.Location = new Point(1182, 563);
            groupBox_rewardData.Margin = new Padding(6);
            groupBox_rewardData.Name = "groupBox_rewardData";
            groupBox_rewardData.Padding = new Padding(6);
            groupBox_rewardData.Size = new Size(1049, 318);
            groupBox_rewardData.TabIndex = 43;
            groupBox_rewardData.TabStop = false;
            groupBox_rewardData.Text = "Reward Data";
            // 
            // textBox_rewardName
            // 
            textBox_rewardName.Font = new Font("Cascadia Code", 8.25F);
            textBox_rewardName.Location = new Point(466, 36);
            textBox_rewardName.Margin = new Padding(6);
            textBox_rewardName.Name = "textBox_rewardName";
            textBox_rewardName.Size = new Size(377, 33);
            textBox_rewardName.TabIndex = 50;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Cascadia Code", 8.25F);
            label1.Location = new Point(390, 49);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(65, 29);
            label1.TabIndex = 51;
            label1.Text = "Name";
            // 
            // button_addReward
            // 
            button_addReward.Font = new Font("Cascadia Code", 8.25F);
            button_addReward.ForeColor = Color.Green;
            button_addReward.Location = new Point(179, 257);
            button_addReward.Margin = new Padding(6);
            button_addReward.Name = "button_addReward";
            button_addReward.Size = new Size(199, 49);
            button_addReward.TabIndex = 49;
            button_addReward.Text = "✨";
            button_addReward.UseVisualStyleBackColor = true;
            button_addReward.Click += button_addReward_Click;
            // 
            // button_removeReward
            // 
            button_removeReward.Font = new Font("Cascadia Code", 8.25F);
            button_removeReward.ForeColor = Color.Red;
            button_removeReward.Location = new Point(11, 256);
            button_removeReward.Margin = new Padding(6);
            button_removeReward.Name = "button_removeReward";
            button_removeReward.Size = new Size(156, 49);
            button_removeReward.TabIndex = 48;
            button_removeReward.Text = "❌";
            button_removeReward.UseVisualStyleBackColor = true;
            button_removeReward.Click += button_removeReward_Click;
            // 
            // textBox_rewardEffect
            // 
            textBox_rewardEffect.Font = new Font("Cascadia Code", 8.25F);
            textBox_rewardEffect.Location = new Point(390, 132);
            textBox_rewardEffect.Margin = new Padding(6);
            textBox_rewardEffect.Multiline = true;
            textBox_rewardEffect.Name = "textBox_rewardEffect";
            textBox_rewardEffect.Size = new Size(647, 173);
            textBox_rewardEffect.TabIndex = 45;
            // 
            // label_rewardEffect
            // 
            label_rewardEffect.AutoSize = true;
            label_rewardEffect.Font = new Font("Cascadia Code", 8.25F);
            label_rewardEffect.Location = new Point(390, 89);
            label_rewardEffect.Margin = new Padding(6, 0, 6, 0);
            label_rewardEffect.Name = "label_rewardEffect";
            label_rewardEffect.Size = new Size(91, 29);
            label_rewardEffect.TabIndex = 47;
            label_rewardEffect.Text = "Effect";
            // 
            // label_rankRequiredForReward
            // 
            label_rankRequiredForReward.AutoSize = true;
            label_rankRequiredForReward.Font = new Font("Cascadia Code", 8.25F);
            label_rankRequiredForReward.Location = new Point(858, 23);
            label_rankRequiredForReward.Margin = new Padding(6, 0, 6, 0);
            label_rankRequiredForReward.Name = "label_rankRequiredForReward";
            label_rankRequiredForReward.Size = new Size(182, 29);
            label_rankRequiredForReward.TabIndex = 45;
            label_rankRequiredForReward.Text = "Rank Required";
            // 
            // num_rewardRankRequired
            // 
            num_rewardRankRequired.Font = new Font("Cascadia Code", 8.25F);
            num_rewardRankRequired.Location = new Point(858, 62);
            num_rewardRankRequired.Margin = new Padding(6);
            num_rewardRankRequired.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            num_rewardRankRequired.Minimum = new decimal(new int[] { 1, 0, 0, int.MinValue });
            num_rewardRankRequired.Name = "num_rewardRankRequired";
            num_rewardRankRequired.Size = new Size(154, 33);
            num_rewardRankRequired.TabIndex = 44;
            // 
            // button_addSdp
            // 
            button_addSdp.Font = new Font("Cascadia Code", 8.25F);
            button_addSdp.ForeColor = Color.Green;
            button_addSdp.Location = new Point(328, 819);
            button_addSdp.Margin = new Padding(6);
            button_addSdp.Name = "button_addSdp";
            button_addSdp.Size = new Size(163, 62);
            button_addSdp.TabIndex = 53;
            button_addSdp.Text = "✨";
            button_addSdp.UseVisualStyleBackColor = true;
            button_addSdp.Click += button_addSdp_Click;
            // 
            // button_removeSdp
            // 
            button_removeSdp.Font = new Font("Cascadia Code", 8.25F);
            button_removeSdp.ForeColor = Color.Red;
            button_removeSdp.Location = new Point(15, 819);
            button_removeSdp.Margin = new Padding(6);
            button_removeSdp.Name = "button_removeSdp";
            button_removeSdp.Size = new Size(119, 62);
            button_removeSdp.TabIndex = 52;
            button_removeSdp.Text = "❌";
            button_removeSdp.UseVisualStyleBackColor = true;
            button_removeSdp.Click += button_removeSdp_Click;
            // 
            // groupBox_coreData
            // 
            groupBox_coreData.Controls.Add(comboBox_rarity);
            groupBox_coreData.Controls.Add(label_rarity);
            groupBox_coreData.Controls.Add(checkBox_unlockedByDefault);
            groupBox_coreData.Controls.Add(textBox_key);
            groupBox_coreData.Controls.Add(label_key);
            groupBox_coreData.Controls.Add(textBox_name);
            groupBox_coreData.Controls.Add(label_name);
            groupBox_coreData.Controls.Add(num_iconIndex);
            groupBox_coreData.Controls.Add(label_iconIndex);
            groupBox_coreData.Font = new Font("Cascadia Code", 8.25F);
            groupBox_coreData.Location = new Point(503, 31);
            groupBox_coreData.Margin = new Padding(6);
            groupBox_coreData.Name = "groupBox_coreData";
            groupBox_coreData.Padding = new Padding(6);
            groupBox_coreData.Size = new Size(353, 356);
            groupBox_coreData.TabIndex = 54;
            groupBox_coreData.TabStop = false;
            groupBox_coreData.Text = "Core Data";
            // 
            // comboBox_rarity
            // 
            comboBox_rarity.Font = new Font("Cascadia Code", 8.25F);
            comboBox_rarity.FormattingEnabled = true;
            comboBox_rarity.Location = new Point(113, 279);
            comboBox_rarity.Margin = new Padding(6);
            comboBox_rarity.Name = "comboBox_rarity";
            comboBox_rarity.Size = new Size(225, 37);
            comboBox_rarity.TabIndex = 58;
            // 
            // label_rarity
            // 
            label_rarity.AutoSize = true;
            label_rarity.Font = new Font("Cascadia Code", 8.25F);
            label_rarity.Location = new Point(11, 286);
            label_rarity.Margin = new Padding(6, 0, 6, 0);
            label_rarity.Name = "label_rarity";
            label_rarity.Size = new Size(91, 29);
            label_rarity.TabIndex = 57;
            label_rarity.Text = "Rarity";
            // 
            // groupBox_costData
            // 
            groupBox_costData.Controls.Add(num_baseCost);
            groupBox_costData.Controls.Add(label_baseCost);
            groupBox_costData.Controls.Add(label_maxRank);
            groupBox_costData.Controls.Add(num_maxRank);
            groupBox_costData.Controls.Add(num_multGrowth);
            groupBox_costData.Controls.Add(num_flatGrowth);
            groupBox_costData.Controls.Add(label_flatGrowth);
            groupBox_costData.Controls.Add(label_multGrowth);
            groupBox_costData.Font = new Font("Cascadia Code", 8.25F);
            groupBox_costData.Location = new Point(915, 26);
            groupBox_costData.Margin = new Padding(6);
            groupBox_costData.Name = "groupBox_costData";
            groupBox_costData.Padding = new Padding(6);
            groupBox_costData.Size = new Size(378, 356);
            groupBox_costData.TabIndex = 58;
            groupBox_costData.TabStop = false;
            groupBox_costData.Text = "Cost Data";
            // 
            // num_baseCost
            // 
            num_baseCost.Font = new Font("Cascadia Code", 8.25F);
            num_baseCost.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            num_baseCost.Location = new Point(178, 151);
            num_baseCost.Margin = new Padding(6);
            num_baseCost.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            num_baseCost.Name = "num_baseCost";
            num_baseCost.Size = new Size(186, 33);
            num_baseCost.TabIndex = 38;
            num_baseCost.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // label_baseCost
            // 
            label_baseCost.AutoSize = true;
            label_baseCost.Font = new Font("Cascadia Code", 8.25F);
            label_baseCost.Location = new Point(102, 156);
            label_baseCost.Margin = new Padding(6, 0, 6, 0);
            label_baseCost.Name = "label_baseCost";
            label_baseCost.Size = new Size(65, 29);
            label_baseCost.TabIndex = 39;
            label_baseCost.Text = "Base";
            // 
            // groupBox_descriptionData
            // 
            groupBox_descriptionData.Controls.Add(textBox_flavorText);
            groupBox_descriptionData.Controls.Add(label_flavorText);
            groupBox_descriptionData.Controls.Add(textBox_description);
            groupBox_descriptionData.Controls.Add(label_description);
            groupBox_descriptionData.Font = new Font("Cascadia Code", 8.25F);
            groupBox_descriptionData.Location = new Point(1305, 26);
            groupBox_descriptionData.Margin = new Padding(6);
            groupBox_descriptionData.Name = "groupBox_descriptionData";
            groupBox_descriptionData.Padding = new Padding(6);
            groupBox_descriptionData.Size = new Size(926, 523);
            groupBox_descriptionData.TabIndex = 59;
            groupBox_descriptionData.TabStop = false;
            groupBox_descriptionData.Text = "Description Data";
            // 
            // SdpBoard
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2246, 896);
            Controls.Add(groupBox_descriptionData);
            Controls.Add(groupBox_costData);
            Controls.Add(groupBox_coreData);
            Controls.Add(button_addSdp);
            Controls.Add(button_removeSdp);
            Controls.Add(groupBox_rewardData);
            Controls.Add(groupBox_parameterData);
            Controls.Add(listBox_Sdps);
            Margin = new Padding(6);
            Name = "SdpBoard";
            Text = "SDP Configuration";
            ((System.ComponentModel.ISupportInitialize)num_iconIndex).EndInit();
            ((System.ComponentModel.ISupportInitialize)num_maxRank).EndInit();
            ((System.ComponentModel.ISupportInitialize)num_flatGrowth).EndInit();
            ((System.ComponentModel.ISupportInitialize)num_multGrowth).EndInit();
            groupBox_parameterData.ResumeLayout(false);
            groupBox_parameterData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)num_paramGrowthPerRank).EndInit();
            groupBox_rewardData.ResumeLayout(false);
            groupBox_rewardData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)num_rewardRankRequired).EndInit();
            groupBox_coreData.ResumeLayout(false);
            groupBox_coreData.PerformLayout();
            groupBox_costData.ResumeLayout(false);
            groupBox_costData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)num_baseCost).EndInit();
            groupBox_descriptionData.ResumeLayout(false);
            groupBox_descriptionData.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBox_Sdps;
        private TextBox textBox_key;
        private Label label_key;
        private Label label_name;
        private TextBox textBox_name;
        private NumericUpDown num_iconIndex;
        private Label label_iconIndex;
        private CheckBox checkBox_unlockedByDefault;
        private Label label_maxRank;
        private NumericUpDown num_maxRank;
        private Label label_flatGrowth;
        private NumericUpDown num_flatGrowth;
        private Label label_multGrowth;
        private NumericUpDown num_multGrowth;
        private Label label_description;
        private TextBox textBox_description;
        private Label label_flavorText;
        private TextBox textBox_flavorText;
        private ListBox listBox_parameters;
        private ListBox listBox_rewards;
        private GroupBox groupBox_parameterData;
        private Button button_addParameter;
        private Button button_removeParameter;
        private GroupBox groupBox_rewardData;
        private Button button_addReward;
        private Button button_removeReward;
        private TextBox textBox_rewardEffect;
        private Label label_rewardEffect;
        private Label label_rankRequiredForReward;
        private NumericUpDown num_rewardRankRequired;
        private CheckBox checkBox_isCore;
        private CheckBox checkBox_isFlat;
        private Label label_;
        private NumericUpDown num_paramGrowthPerRank;
        private ComboBox comboBox_parameter;
        private Label label_parameter;
        private TextBox textBox_rewardName;
        private Label label1;
        private Button button_addSdp;
        private Button button_removeSdp;
        private GroupBox groupBox_coreData;
        private GroupBox groupBox_costData;
        private GroupBox groupBox_descriptionData;
        private NumericUpDown num_baseCost;
        private Label label_baseCost;
        private ComboBox comboBox_rarity;
        private Label label_rarity;
    }
}
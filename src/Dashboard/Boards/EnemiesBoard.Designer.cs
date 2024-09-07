using JMZ.Rmmz.Data.Models.db.implementations;

namespace JMZ.Dashboard.Boards
{
    partial class EnemiesBoard
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
            components = new System.ComponentModel.Container();
            listBoxEnemies = new ListBox();
            weaponBindingSource = new BindingSource(components);
            labelId = new Label();
            labelTextId = new Label();
            groupBoxCoreData = new GroupBox();
            numParamLuck = new NumericUpDown();
            labelParamLuck = new Label();
            numParamSpeed = new NumericUpDown();
            labelParamSpeed = new Label();
            numParamResistance = new NumericUpDown();
            labelParamResistance = new Label();
            numParamForce = new NumericUpDown();
            labelParamForce = new Label();
            numParamEndurance = new NumericUpDown();
            labelParamEndurance = new Label();
            numParamPower = new NumericUpDown();
            labelParamPower = new Label();
            numMaxHp = new NumericUpDown();
            labelMaxTp = new Label();
            numMaxTp = new NumericUpDown();
            labelMaxMp = new Label();
            numMaxMp = new NumericUpDown();
            labelMaxHp = new Label();
            numLevel = new NumericUpDown();
            label1 = new Label();
            textBoxName = new TextBox();
            labelName = new Label();
            groupBoxDropData = new GroupBox();
            buttonDeleteDrop = new Button();
            buttonCloneToDrops = new Button();
            labelBasicDrops = new Label();
            buttonDropHelper = new Button();
            listBoxDrops = new ListBox();
            numGold = new NumericUpDown();
            labelExperience = new Label();
            labelGold = new Label();
            numExperience = new NumericUpDown();
            labelSdpPoints = new Label();
            numSdpPoints = new NumericUpDown();
            groupBoxSdpData = new GroupBox();
            groupBoxSdpPanelDrop = new GroupBox();
            buttonRemoveSdpData = new Button();
            buttonUpdateSdpData = new Button();
            buttonCloneToSdpDrop = new Button();
            labelSdpItemIdValue = new Label();
            labelSdpItemId = new Label();
            label2 = new Label();
            numSdpChance = new NumericUpDown();
            checkBoxHasPanelDrop = new CheckBox();
            labelSdpKey = new Label();
            textSdpKey = new TextBox();
            groupBoxJabsData = new GroupBox();
            checkBoxAiTraitReckless = new CheckBox();
            checkBoxAiTraitLeader = new CheckBox();
            checkBoxAiTraitFollower = new CheckBox();
            checkBoxAiTraitCareful = new CheckBox();
            checkBoxAiTraitHealer = new CheckBox();
            labelAlertDuration = new Label();
            numAlertDuration = new NumericUpDown();
            labelVisionAlerted = new Label();
            labelVisionBase = new Label();
            numJabsPursuitAlerted = new NumericUpDown();
            numJabsSightAlerted = new NumericUpDown();
            numJabsPursuit = new NumericUpDown();
            label3 = new Label();
            numJabsSight = new NumericUpDown();
            labelJabsSight = new Label();
            checkBoxAiTraitExecutor = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)weaponBindingSource).BeginInit();
            groupBoxCoreData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numParamLuck).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numParamSpeed).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numParamResistance).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numParamForce).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numParamEndurance).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numParamPower).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numMaxHp).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numMaxTp).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numMaxMp).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numLevel).BeginInit();
            groupBoxDropData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numGold).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numExperience).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSdpPoints).BeginInit();
            groupBoxSdpData.SuspendLayout();
            groupBoxSdpPanelDrop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numSdpChance).BeginInit();
            groupBoxJabsData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numAlertDuration).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numJabsPursuitAlerted).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numJabsSightAlerted).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numJabsPursuit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numJabsSight).BeginInit();
            SuspendLayout();
            // 
            // listBoxEnemies
            // 
            listBoxEnemies.Font = new Font("Victor Mono SemiBold", 10.124999F, FontStyle.Bold);
            listBoxEnemies.FormattingEnabled = true;
            listBoxEnemies.ItemHeight = 33;
            listBoxEnemies.Location = new Point(22, 26);
            listBoxEnemies.Margin = new Padding(6);
            listBoxEnemies.Name = "listBoxEnemies";
            listBoxEnemies.Size = new Size(353, 1027);
            listBoxEnemies.TabIndex = 0;
            // 
            // weaponBindingSource
            // 
            weaponBindingSource.DataSource = typeof(RPG_Weapon);
            // 
            // labelId
            // 
            labelId.AutoSize = true;
            labelId.Location = new Point(286, 31);
            labelId.Margin = new Padding(6, 0, 6, 0);
            labelId.Name = "labelId";
            labelId.Size = new Size(39, 29);
            labelId.TabIndex = 4;
            labelId.Text = "Id";
            // 
            // labelTextId
            // 
            labelTextId.AutoSize = true;
            labelTextId.Location = new Point(337, 31);
            labelTextId.Margin = new Padding(6, 0, 6, 0);
            labelTextId.Name = "labelTextId";
            labelTextId.Size = new Size(52, 29);
            labelTextId.TabIndex = 5;
            labelTextId.Text = "n/a";
            // 
            // groupBoxCoreData
            // 
            groupBoxCoreData.Controls.Add(numParamLuck);
            groupBoxCoreData.Controls.Add(labelParamLuck);
            groupBoxCoreData.Controls.Add(numParamSpeed);
            groupBoxCoreData.Controls.Add(labelParamSpeed);
            groupBoxCoreData.Controls.Add(numParamResistance);
            groupBoxCoreData.Controls.Add(labelParamResistance);
            groupBoxCoreData.Controls.Add(numParamForce);
            groupBoxCoreData.Controls.Add(labelParamForce);
            groupBoxCoreData.Controls.Add(numParamEndurance);
            groupBoxCoreData.Controls.Add(labelParamEndurance);
            groupBoxCoreData.Controls.Add(numParamPower);
            groupBoxCoreData.Controls.Add(labelParamPower);
            groupBoxCoreData.Controls.Add(numMaxHp);
            groupBoxCoreData.Controls.Add(labelMaxTp);
            groupBoxCoreData.Controls.Add(numMaxTp);
            groupBoxCoreData.Controls.Add(labelMaxMp);
            groupBoxCoreData.Controls.Add(numMaxMp);
            groupBoxCoreData.Controls.Add(labelMaxHp);
            groupBoxCoreData.Controls.Add(numLevel);
            groupBoxCoreData.Controls.Add(label1);
            groupBoxCoreData.Controls.Add(labelTextId);
            groupBoxCoreData.Controls.Add(labelId);
            groupBoxCoreData.Controls.Add(textBoxName);
            groupBoxCoreData.Controls.Add(labelName);
            groupBoxCoreData.Font = new Font("Cascadia Code", 8.25F);
            groupBoxCoreData.Location = new Point(387, 26);
            groupBoxCoreData.Margin = new Padding(6);
            groupBoxCoreData.Name = "groupBoxCoreData";
            groupBoxCoreData.Padding = new Padding(6);
            groupBoxCoreData.Size = new Size(401, 1028);
            groupBoxCoreData.TabIndex = 55;
            groupBoxCoreData.TabStop = false;
            groupBoxCoreData.Text = "Core Data";
            // 
            // numParamLuck
            // 
            numParamLuck.Font = new Font("Cascadia Code", 10.125F);
            numParamLuck.Location = new Point(189, 719);
            numParamLuck.Margin = new Padding(11, 13, 11, 13);
            numParamLuck.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            numParamLuck.Name = "numParamLuck";
            numParamLuck.Size = new Size(195, 39);
            numParamLuck.TabIndex = 30;
            numParamLuck.TextAlign = HorizontalAlignment.Center;
            // 
            // labelParamLuck
            // 
            labelParamLuck.AutoSize = true;
            labelParamLuck.Font = new Font("Cascadia Code", 8.25F);
            labelParamLuck.Location = new Point(81, 726);
            labelParamLuck.Margin = new Padding(6, 0, 6, 0);
            labelParamLuck.Name = "labelParamLuck";
            labelParamLuck.Size = new Size(65, 29);
            labelParamLuck.TabIndex = 29;
            labelParamLuck.Text = "Luck";
            // 
            // numParamSpeed
            // 
            numParamSpeed.Font = new Font("Cascadia Code", 10.125F);
            numParamSpeed.Location = new Point(189, 668);
            numParamSpeed.Margin = new Padding(11, 13, 11, 13);
            numParamSpeed.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            numParamSpeed.Name = "numParamSpeed";
            numParamSpeed.Size = new Size(195, 39);
            numParamSpeed.TabIndex = 28;
            numParamSpeed.TextAlign = HorizontalAlignment.Center;
            // 
            // labelParamSpeed
            // 
            labelParamSpeed.AutoSize = true;
            labelParamSpeed.Font = new Font("Cascadia Code", 8.25F);
            labelParamSpeed.Location = new Point(81, 675);
            labelParamSpeed.Margin = new Padding(6, 0, 6, 0);
            labelParamSpeed.Name = "labelParamSpeed";
            labelParamSpeed.Size = new Size(78, 29);
            labelParamSpeed.TabIndex = 27;
            labelParamSpeed.Text = "Speed";
            // 
            // numParamResistance
            // 
            numParamResistance.Font = new Font("Cascadia Code", 10.125F);
            numParamResistance.Location = new Point(189, 585);
            numParamResistance.Margin = new Padding(11, 13, 11, 13);
            numParamResistance.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            numParamResistance.Name = "numParamResistance";
            numParamResistance.Size = new Size(195, 39);
            numParamResistance.TabIndex = 26;
            numParamResistance.TextAlign = HorizontalAlignment.Center;
            // 
            // labelParamResistance
            // 
            labelParamResistance.AutoSize = true;
            labelParamResistance.Font = new Font("Cascadia Code", 8.25F);
            labelParamResistance.Location = new Point(29, 592);
            labelParamResistance.Margin = new Padding(6, 0, 6, 0);
            labelParamResistance.Name = "labelParamResistance";
            labelParamResistance.Size = new Size(143, 29);
            labelParamResistance.TabIndex = 25;
            labelParamResistance.Text = "Resistance";
            // 
            // numParamForce
            // 
            numParamForce.Font = new Font("Cascadia Code", 10.125F);
            numParamForce.Location = new Point(189, 533);
            numParamForce.Margin = new Padding(11, 13, 11, 13);
            numParamForce.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            numParamForce.Name = "numParamForce";
            numParamForce.Size = new Size(195, 39);
            numParamForce.TabIndex = 24;
            numParamForce.TextAlign = HorizontalAlignment.Center;
            // 
            // labelParamForce
            // 
            labelParamForce.AutoSize = true;
            labelParamForce.Font = new Font("Cascadia Code", 8.25F);
            labelParamForce.Location = new Point(94, 540);
            labelParamForce.Margin = new Padding(6, 0, 6, 0);
            labelParamForce.Name = "labelParamForce";
            labelParamForce.Size = new Size(78, 29);
            labelParamForce.TabIndex = 23;
            labelParamForce.Text = "Force";
            // 
            // numParamEndurance
            // 
            numParamEndurance.Font = new Font("Cascadia Code", 10.125F);
            numParamEndurance.Location = new Point(189, 468);
            numParamEndurance.Margin = new Padding(11, 13, 11, 13);
            numParamEndurance.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            numParamEndurance.Name = "numParamEndurance";
            numParamEndurance.Size = new Size(195, 39);
            numParamEndurance.TabIndex = 22;
            numParamEndurance.TextAlign = HorizontalAlignment.Center;
            // 
            // labelParamEndurance
            // 
            labelParamEndurance.AutoSize = true;
            labelParamEndurance.Font = new Font("Cascadia Code", 8.25F);
            labelParamEndurance.Location = new Point(42, 475);
            labelParamEndurance.Margin = new Padding(6, 0, 6, 0);
            labelParamEndurance.Name = "labelParamEndurance";
            labelParamEndurance.Size = new Size(130, 29);
            labelParamEndurance.TabIndex = 21;
            labelParamEndurance.Text = "Endurance";
            // 
            // numParamPower
            // 
            numParamPower.Font = new Font("Cascadia Code", 10.125F);
            numParamPower.Location = new Point(189, 417);
            numParamPower.Margin = new Padding(11, 13, 11, 13);
            numParamPower.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            numParamPower.Name = "numParamPower";
            numParamPower.Size = new Size(195, 39);
            numParamPower.TabIndex = 20;
            numParamPower.TextAlign = HorizontalAlignment.Center;
            // 
            // labelParamPower
            // 
            labelParamPower.AutoSize = true;
            labelParamPower.Font = new Font("Cascadia Code", 8.25F);
            labelParamPower.Location = new Point(94, 424);
            labelParamPower.Margin = new Padding(6, 0, 6, 0);
            labelParamPower.Name = "labelParamPower";
            labelParamPower.Size = new Size(78, 29);
            labelParamPower.TabIndex = 19;
            labelParamPower.Text = "Power";
            // 
            // numMaxHp
            // 
            numMaxHp.Font = new Font("Cascadia Code", 10.125F);
            numMaxHp.Location = new Point(129, 221);
            numMaxHp.Margin = new Padding(11, 13, 11, 13);
            numMaxHp.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
            numMaxHp.Name = "numMaxHp";
            numMaxHp.Size = new Size(255, 39);
            numMaxHp.TabIndex = 18;
            numMaxHp.TextAlign = HorizontalAlignment.Center;
            // 
            // labelMaxTp
            // 
            labelMaxTp.AutoSize = true;
            labelMaxTp.Font = new Font("Cascadia Code", 8.25F);
            labelMaxTp.Location = new Point(73, 330);
            labelMaxTp.Margin = new Padding(6, 0, 6, 0);
            labelMaxTp.Name = "labelMaxTp";
            labelMaxTp.Size = new Size(39, 29);
            labelMaxTp.TabIndex = 17;
            labelMaxTp.Text = "TP";
            // 
            // numMaxTp
            // 
            numMaxTp.Font = new Font("Cascadia Code", 10.125F);
            numMaxTp.Location = new Point(129, 323);
            numMaxTp.Margin = new Padding(11, 13, 11, 13);
            numMaxTp.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
            numMaxTp.Name = "numMaxTp";
            numMaxTp.Size = new Size(255, 39);
            numMaxTp.TabIndex = 16;
            numMaxTp.TextAlign = HorizontalAlignment.Center;
            // 
            // labelMaxMp
            // 
            labelMaxMp.AutoSize = true;
            labelMaxMp.Font = new Font("Cascadia Code", 8.25F);
            labelMaxMp.Location = new Point(73, 278);
            labelMaxMp.Margin = new Padding(6, 0, 6, 0);
            labelMaxMp.Name = "labelMaxMp";
            labelMaxMp.Size = new Size(39, 29);
            labelMaxMp.TabIndex = 15;
            labelMaxMp.Text = "MP";
            // 
            // numMaxMp
            // 
            numMaxMp.Font = new Font("Cascadia Code", 10.125F);
            numMaxMp.Location = new Point(129, 271);
            numMaxMp.Margin = new Padding(11, 13, 11, 13);
            numMaxMp.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
            numMaxMp.Name = "numMaxMp";
            numMaxMp.Size = new Size(255, 39);
            numMaxMp.TabIndex = 14;
            numMaxMp.TextAlign = HorizontalAlignment.Center;
            // 
            // labelMaxHp
            // 
            labelMaxHp.AutoSize = true;
            labelMaxHp.Font = new Font("Cascadia Code", 8.25F);
            labelMaxHp.Location = new Point(73, 228);
            labelMaxHp.Margin = new Padding(6, 0, 6, 0);
            labelMaxHp.Name = "labelMaxHp";
            labelMaxHp.Size = new Size(39, 29);
            labelMaxHp.TabIndex = 13;
            labelMaxHp.Text = "HP";
            // 
            // numLevel
            // 
            numLevel.Font = new Font("Cascadia Code", 10.125F);
            numLevel.Location = new Point(17, 131);
            numLevel.Margin = new Padding(11, 13, 11, 13);
            numLevel.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            numLevel.Name = "numLevel";
            numLevel.Size = new Size(149, 39);
            numLevel.TabIndex = 8;
            numLevel.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Cascadia Code", 8.25F);
            label1.Location = new Point(14, 105);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(78, 29);
            label1.TabIndex = 7;
            label1.Text = "Level";
            // 
            // textBoxName
            // 
            textBoxName.BorderStyle = BorderStyle.FixedSingle;
            textBoxName.Font = new Font("Cascadia Code", 8.25F);
            textBoxName.Location = new Point(14, 66);
            textBoxName.Margin = new Padding(6);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(375, 33);
            textBoxName.TabIndex = 4;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Font = new Font("Cascadia Code", 8.25F);
            labelName.Location = new Point(14, 31);
            labelName.Margin = new Padding(6, 0, 6, 0);
            labelName.Name = "labelName";
            labelName.Size = new Size(65, 29);
            labelName.TabIndex = 5;
            labelName.Text = "Name";
            // 
            // groupBoxDropData
            // 
            groupBoxDropData.Controls.Add(buttonDeleteDrop);
            groupBoxDropData.Controls.Add(buttonCloneToDrops);
            groupBoxDropData.Controls.Add(labelBasicDrops);
            groupBoxDropData.Controls.Add(buttonDropHelper);
            groupBoxDropData.Controls.Add(listBoxDrops);
            groupBoxDropData.Controls.Add(numGold);
            groupBoxDropData.Controls.Add(labelExperience);
            groupBoxDropData.Controls.Add(labelGold);
            groupBoxDropData.Controls.Add(numExperience);
            groupBoxDropData.Font = new Font("Cascadia Code", 8.25F);
            groupBoxDropData.Location = new Point(809, 26);
            groupBoxDropData.Margin = new Padding(6);
            groupBoxDropData.Name = "groupBoxDropData";
            groupBoxDropData.Padding = new Padding(6);
            groupBoxDropData.Size = new Size(557, 1028);
            groupBoxDropData.TabIndex = 56;
            groupBoxDropData.TabStop = false;
            groupBoxDropData.Text = "Drop Data";
            // 
            // buttonDeleteDrop
            // 
            buttonDeleteDrop.FlatStyle = FlatStyle.Popup;
            buttonDeleteDrop.Font = new Font("Cascadia Code", 12F);
            buttonDeleteDrop.ForeColor = Color.Red;
            buttonDeleteDrop.Location = new Point(334, 839);
            buttonDeleteDrop.Margin = new Padding(6);
            buttonDeleteDrop.Name = "buttonDeleteDrop";
            buttonDeleteDrop.Size = new Size(211, 76);
            buttonDeleteDrop.TabIndex = 65;
            buttonDeleteDrop.Text = "❌";
            buttonDeleteDrop.UseVisualStyleBackColor = true;
            buttonDeleteDrop.Click += buttonDeleteDrop_Click;
            // 
            // buttonCloneToDrops
            // 
            buttonCloneToDrops.FlatStyle = FlatStyle.Popup;
            buttonCloneToDrops.Font = new Font("Cascadia Code", 12F);
            buttonCloneToDrops.ForeColor = Color.Blue;
            buttonCloneToDrops.Location = new Point(12, 839);
            buttonCloneToDrops.Margin = new Padding(6);
            buttonCloneToDrops.Name = "buttonCloneToDrops";
            buttonCloneToDrops.Size = new Size(310, 76);
            buttonCloneToDrops.TabIndex = 64;
            buttonCloneToDrops.Text = "📩";
            buttonCloneToDrops.UseVisualStyleBackColor = true;
            buttonCloneToDrops.Click += buttonCloneToDrops_Click;
            // 
            // labelBasicDrops
            // 
            labelBasicDrops.AutoSize = true;
            labelBasicDrops.Font = new Font("Cascadia Code", 10.125F, FontStyle.Bold);
            labelBasicDrops.Location = new Point(12, 129);
            labelBasicDrops.Margin = new Padding(6, 0, 6, 0);
            labelBasicDrops.Name = "labelBasicDrops";
            labelBasicDrops.Size = new Size(191, 35);
            labelBasicDrops.TabIndex = 6;
            labelBasicDrops.Text = "Basic Drops";
            // 
            // buttonDropHelper
            // 
            buttonDropHelper.FlatStyle = FlatStyle.Flat;
            buttonDropHelper.Font = new Font("Cascadia Code", 12F);
            buttonDropHelper.Location = new Point(12, 931);
            buttonDropHelper.Margin = new Padding(6);
            buttonDropHelper.Name = "buttonDropHelper";
            buttonDropHelper.Size = new Size(533, 85);
            buttonDropHelper.TabIndex = 61;
            buttonDropHelper.Text = "Summon Drop Helper";
            buttonDropHelper.UseVisualStyleBackColor = true;
            buttonDropHelper.Click += buttonDropHelper_Click;
            // 
            // listBoxDrops
            // 
            listBoxDrops.FormattingEnabled = true;
            listBoxDrops.ItemHeight = 29;
            listBoxDrops.Location = new Point(12, 170);
            listBoxDrops.Margin = new Padding(6);
            listBoxDrops.Name = "listBoxDrops";
            listBoxDrops.Size = new Size(533, 526);
            listBoxDrops.TabIndex = 57;
            // 
            // numGold
            // 
            numGold.Font = new Font("Cascadia Code", 10.125F);
            numGold.Location = new Point(304, 70);
            numGold.Margin = new Padding(11, 13, 11, 13);
            numGold.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
            numGold.Name = "numGold";
            numGold.Size = new Size(241, 39);
            numGold.TabIndex = 12;
            numGold.TextAlign = HorizontalAlignment.Center;
            // 
            // labelExperience
            // 
            labelExperience.AutoSize = true;
            labelExperience.Font = new Font("Cascadia Code", 8.25F);
            labelExperience.Location = new Point(17, 41);
            labelExperience.Margin = new Padding(6, 0, 6, 0);
            labelExperience.Name = "labelExperience";
            labelExperience.Size = new Size(52, 29);
            labelExperience.TabIndex = 9;
            labelExperience.Text = "Exp";
            // 
            // labelGold
            // 
            labelGold.AutoSize = true;
            labelGold.Font = new Font("Cascadia Code", 8.25F);
            labelGold.Location = new Point(304, 41);
            labelGold.Margin = new Padding(6, 0, 6, 0);
            labelGold.Name = "labelGold";
            labelGold.Size = new Size(65, 29);
            labelGold.TabIndex = 11;
            labelGold.Text = "Gold";
            // 
            // numExperience
            // 
            numExperience.Font = new Font("Cascadia Code", 10.125F);
            numExperience.Location = new Point(17, 70);
            numExperience.Margin = new Padding(11, 13, 11, 13);
            numExperience.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
            numExperience.Name = "numExperience";
            numExperience.Size = new Size(241, 39);
            numExperience.TabIndex = 10;
            numExperience.TextAlign = HorizontalAlignment.Center;
            // 
            // labelSdpPoints
            // 
            labelSdpPoints.AutoSize = true;
            labelSdpPoints.Font = new Font("Cascadia Code", 8.25F);
            labelSdpPoints.Location = new Point(9, 49);
            labelSdpPoints.Margin = new Padding(6, 0, 6, 0);
            labelSdpPoints.Name = "labelSdpPoints";
            labelSdpPoints.Size = new Size(91, 29);
            labelSdpPoints.TabIndex = 66;
            labelSdpPoints.Text = "Points";
            // 
            // numSdpPoints
            // 
            numSdpPoints.Font = new Font("Cascadia Code", 10.125F);
            numSdpPoints.Location = new Point(117, 42);
            numSdpPoints.Margin = new Padding(11, 13, 11, 13);
            numSdpPoints.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
            numSdpPoints.Name = "numSdpPoints";
            numSdpPoints.Size = new Size(241, 39);
            numSdpPoints.TabIndex = 67;
            numSdpPoints.TextAlign = HorizontalAlignment.Center;
            // 
            // groupBoxSdpData
            // 
            groupBoxSdpData.Controls.Add(groupBoxSdpPanelDrop);
            groupBoxSdpData.Controls.Add(labelSdpPoints);
            groupBoxSdpData.Controls.Add(numSdpPoints);
            groupBoxSdpData.Font = new Font("Victor Mono SemiBold", 10.124999F, FontStyle.Bold);
            groupBoxSdpData.Location = new Point(1386, 26);
            groupBoxSdpData.Name = "groupBoxSdpData";
            groupBoxSdpData.Size = new Size(558, 397);
            groupBoxSdpData.TabIndex = 57;
            groupBoxSdpData.TabStop = false;
            groupBoxSdpData.Text = "SDP Data";
            // 
            // groupBoxSdpPanelDrop
            // 
            groupBoxSdpPanelDrop.Controls.Add(buttonRemoveSdpData);
            groupBoxSdpPanelDrop.Controls.Add(buttonUpdateSdpData);
            groupBoxSdpPanelDrop.Controls.Add(buttonCloneToSdpDrop);
            groupBoxSdpPanelDrop.Controls.Add(labelSdpItemIdValue);
            groupBoxSdpPanelDrop.Controls.Add(labelSdpItemId);
            groupBoxSdpPanelDrop.Controls.Add(label2);
            groupBoxSdpPanelDrop.Controls.Add(numSdpChance);
            groupBoxSdpPanelDrop.Controls.Add(checkBoxHasPanelDrop);
            groupBoxSdpPanelDrop.Controls.Add(labelSdpKey);
            groupBoxSdpPanelDrop.Controls.Add(textSdpKey);
            groupBoxSdpPanelDrop.Font = new Font("Cascadia Code", 8.25F);
            groupBoxSdpPanelDrop.Location = new Point(9, 97);
            groupBoxSdpPanelDrop.Name = "groupBoxSdpPanelDrop";
            groupBoxSdpPanelDrop.Size = new Size(534, 290);
            groupBoxSdpPanelDrop.TabIndex = 70;
            groupBoxSdpPanelDrop.TabStop = false;
            groupBoxSdpPanelDrop.Text = "Panel Drop Data";
            // 
            // buttonRemoveSdpData
            // 
            buttonRemoveSdpData.FlatStyle = FlatStyle.Popup;
            buttonRemoveSdpData.Font = new Font("Cascadia Code", 12F);
            buttonRemoveSdpData.ForeColor = Color.Red;
            buttonRemoveSdpData.Location = new Point(342, 221);
            buttonRemoveSdpData.Margin = new Padding(6);
            buttonRemoveSdpData.Name = "buttonRemoveSdpData";
            buttonRemoveSdpData.Size = new Size(183, 60);
            buttonRemoveSdpData.TabIndex = 76;
            buttonRemoveSdpData.Text = "💥";
            buttonRemoveSdpData.UseVisualStyleBackColor = true;
            buttonRemoveSdpData.Click += buttonRemoveSdpData_Click;
            // 
            // buttonUpdateSdpData
            // 
            buttonUpdateSdpData.FlatStyle = FlatStyle.Popup;
            buttonUpdateSdpData.Font = new Font("Cascadia Code", 12F);
            buttonUpdateSdpData.ForeColor = Color.Lime;
            buttonUpdateSdpData.Location = new Point(9, 221);
            buttonUpdateSdpData.Margin = new Padding(6);
            buttonUpdateSdpData.Name = "buttonUpdateSdpData";
            buttonUpdateSdpData.Size = new Size(321, 60);
            buttonUpdateSdpData.TabIndex = 75;
            buttonUpdateSdpData.Text = "💾";
            buttonUpdateSdpData.UseVisualStyleBackColor = true;
            buttonUpdateSdpData.Click += buttonUpdateSdpData_Click;
            // 
            // buttonCloneToSdpDrop
            // 
            buttonCloneToSdpDrop.FlatStyle = FlatStyle.Popup;
            buttonCloneToSdpDrop.Font = new Font("Cascadia Code", 12F);
            buttonCloneToSdpDrop.ForeColor = Color.Blue;
            buttonCloneToSdpDrop.Location = new Point(407, 124);
            buttonCloneToSdpDrop.Margin = new Padding(6);
            buttonCloneToSdpDrop.Name = "buttonCloneToSdpDrop";
            buttonCloneToSdpDrop.Size = new Size(74, 60);
            buttonCloneToSdpDrop.TabIndex = 74;
            buttonCloneToSdpDrop.Text = "📩";
            buttonCloneToSdpDrop.UseVisualStyleBackColor = true;
            buttonCloneToSdpDrop.Click += buttonCloneToSdpDrop_Click;
            // 
            // labelSdpItemIdValue
            // 
            labelSdpItemIdValue.AutoSize = true;
            labelSdpItemIdValue.Location = new Point(407, 73);
            labelSdpItemIdValue.Margin = new Padding(6, 0, 6, 0);
            labelSdpItemIdValue.Name = "labelSdpItemIdValue";
            labelSdpItemIdValue.Size = new Size(52, 29);
            labelSdpItemIdValue.TabIndex = 73;
            labelSdpItemIdValue.Text = "n/a";
            // 
            // labelSdpItemId
            // 
            labelSdpItemId.AutoSize = true;
            labelSdpItemId.Location = new Point(366, 29);
            labelSdpItemId.Margin = new Padding(6, 0, 6, 0);
            labelSdpItemId.Name = "labelSdpItemId";
            labelSdpItemId.Size = new Size(143, 29);
            labelSdpItemId.TabIndex = 72;
            labelSdpItemId.Text = "SDP ItemId";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Cascadia Code", 8.25F);
            label2.Location = new Point(29, 156);
            label2.Margin = new Padding(6, 0, 6, 0);
            label2.Name = "label2";
            label2.Size = new Size(91, 29);
            label2.TabIndex = 70;
            label2.Text = "Chance";
            // 
            // numSdpChance
            // 
            numSdpChance.Font = new Font("Cascadia Code", 10.125F);
            numSdpChance.Location = new Point(137, 149);
            numSdpChance.Margin = new Padding(11, 13, 11, 13);
            numSdpChance.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numSdpChance.Name = "numSdpChance";
            numSdpChance.Size = new Size(193, 39);
            numSdpChance.TabIndex = 71;
            numSdpChance.TextAlign = HorizontalAlignment.Center;
            numSdpChance.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // checkBoxHasPanelDrop
            // 
            checkBoxHasPanelDrop.AutoSize = true;
            checkBoxHasPanelDrop.Location = new Point(25, 52);
            checkBoxHasPanelDrop.Name = "checkBoxHasPanelDrop";
            checkBoxHasPanelDrop.Size = new Size(227, 33);
            checkBoxHasPanelDrop.TabIndex = 58;
            checkBoxHasPanelDrop.Text = "Has Panel Drop";
            checkBoxHasPanelDrop.UseVisualStyleBackColor = true;
            checkBoxHasPanelDrop.CheckedChanged += checkBoxHasPanelDrop_CheckedChanged;
            // 
            // labelSdpKey
            // 
            labelSdpKey.AutoSize = true;
            labelSdpKey.Font = new Font("Cascadia Code", 8.25F);
            labelSdpKey.Location = new Point(25, 99);
            labelSdpKey.Margin = new Padding(6, 0, 6, 0);
            labelSdpKey.Name = "labelSdpKey";
            labelSdpKey.Size = new Size(52, 29);
            labelSdpKey.TabIndex = 69;
            labelSdpKey.Text = "Key";
            // 
            // textSdpKey
            // 
            textSdpKey.BorderStyle = BorderStyle.FixedSingle;
            textSdpKey.Font = new Font("Cascadia Code", 8.25F);
            textSdpKey.Location = new Point(89, 97);
            textSdpKey.Margin = new Padding(6);
            textSdpKey.MaxLength = 64;
            textSdpKey.Name = "textSdpKey";
            textSdpKey.Size = new Size(241, 33);
            textSdpKey.TabIndex = 68;
            // 
            // groupBoxJabsData
            // 
            groupBoxJabsData.Controls.Add(checkBoxAiTraitExecutor);
            groupBoxJabsData.Controls.Add(checkBoxAiTraitReckless);
            groupBoxJabsData.Controls.Add(checkBoxAiTraitLeader);
            groupBoxJabsData.Controls.Add(checkBoxAiTraitFollower);
            groupBoxJabsData.Controls.Add(checkBoxAiTraitCareful);
            groupBoxJabsData.Controls.Add(checkBoxAiTraitHealer);
            groupBoxJabsData.Controls.Add(labelAlertDuration);
            groupBoxJabsData.Controls.Add(numAlertDuration);
            groupBoxJabsData.Controls.Add(labelVisionAlerted);
            groupBoxJabsData.Controls.Add(labelVisionBase);
            groupBoxJabsData.Controls.Add(numJabsPursuitAlerted);
            groupBoxJabsData.Controls.Add(numJabsSightAlerted);
            groupBoxJabsData.Controls.Add(numJabsPursuit);
            groupBoxJabsData.Controls.Add(label3);
            groupBoxJabsData.Controls.Add(numJabsSight);
            groupBoxJabsData.Controls.Add(labelJabsSight);
            groupBoxJabsData.Font = new Font("Victor Mono SemiBold", 10.124999F, FontStyle.Bold);
            groupBoxJabsData.Location = new Point(1386, 429);
            groupBoxJabsData.Name = "groupBoxJabsData";
            groupBoxJabsData.Size = new Size(558, 624);
            groupBoxJabsData.TabIndex = 31;
            groupBoxJabsData.TabStop = false;
            groupBoxJabsData.Text = "JABS Data";
            // 
            // checkBoxAiTraitReckless
            // 
            checkBoxAiTraitReckless.AutoSize = true;
            checkBoxAiTraitReckless.Location = new Point(18, 447);
            checkBoxAiTraitReckless.Name = "checkBoxAiTraitReckless";
            checkBoxAiTraitReckless.Size = new Size(227, 37);
            checkBoxAiTraitReckless.TabIndex = 63;
            checkBoxAiTraitReckless.Text = "AI: Reckless";
            checkBoxAiTraitReckless.UseVisualStyleBackColor = true;
            // 
            // checkBoxAiTraitLeader
            // 
            checkBoxAiTraitLeader.AutoSize = true;
            checkBoxAiTraitLeader.Location = new Point(18, 490);
            checkBoxAiTraitLeader.Name = "checkBoxAiTraitLeader";
            checkBoxAiTraitLeader.Size = new Size(197, 37);
            checkBoxAiTraitLeader.TabIndex = 62;
            checkBoxAiTraitLeader.Text = "AI: Leader";
            checkBoxAiTraitLeader.UseVisualStyleBackColor = true;
            // 
            // checkBoxAiTraitFollower
            // 
            checkBoxAiTraitFollower.AutoSize = true;
            checkBoxAiTraitFollower.Location = new Point(271, 490);
            checkBoxAiTraitFollower.Name = "checkBoxAiTraitFollower";
            checkBoxAiTraitFollower.Size = new Size(227, 37);
            checkBoxAiTraitFollower.TabIndex = 61;
            checkBoxAiTraitFollower.Text = "AI: Follower";
            checkBoxAiTraitFollower.UseVisualStyleBackColor = true;
            // 
            // checkBoxAiTraitCareful
            // 
            checkBoxAiTraitCareful.AutoSize = true;
            checkBoxAiTraitCareful.Location = new Point(18, 404);
            checkBoxAiTraitCareful.Name = "checkBoxAiTraitCareful";
            checkBoxAiTraitCareful.Size = new Size(212, 37);
            checkBoxAiTraitCareful.TabIndex = 60;
            checkBoxAiTraitCareful.Text = "AI: Careful";
            checkBoxAiTraitCareful.UseVisualStyleBackColor = true;
            // 
            // checkBoxAiTraitHealer
            // 
            checkBoxAiTraitHealer.AutoSize = true;
            checkBoxAiTraitHealer.Location = new Point(271, 447);
            checkBoxAiTraitHealer.Name = "checkBoxAiTraitHealer";
            checkBoxAiTraitHealer.Size = new Size(197, 37);
            checkBoxAiTraitHealer.TabIndex = 59;
            checkBoxAiTraitHealer.Text = "AI: Healer";
            checkBoxAiTraitHealer.UseVisualStyleBackColor = true;
            // 
            // labelAlertDuration
            // 
            labelAlertDuration.AutoSize = true;
            labelAlertDuration.Font = new Font("Cascadia Code", 8.25F);
            labelAlertDuration.Location = new Point(300, 224);
            labelAlertDuration.Margin = new Padding(6, 0, 6, 0);
            labelAlertDuration.Name = "labelAlertDuration";
            labelAlertDuration.Size = new Size(117, 29);
            labelAlertDuration.TabIndex = 28;
            labelAlertDuration.Text = "Duration";
            // 
            // numAlertDuration
            // 
            numAlertDuration.Font = new Font("Cascadia Code", 10.125F);
            numAlertDuration.Location = new Point(300, 254);
            numAlertDuration.Margin = new Padding(11, 13, 11, 13);
            numAlertDuration.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            numAlertDuration.Minimum = new decimal(new int[] { 1, 0, 0, int.MinValue });
            numAlertDuration.Name = "numAlertDuration";
            numAlertDuration.Size = new Size(190, 39);
            numAlertDuration.TabIndex = 27;
            numAlertDuration.TextAlign = HorizontalAlignment.Center;
            numAlertDuration.Value = new decimal(new int[] { 1, 0, 0, int.MinValue });
            // 
            // labelVisionAlerted
            // 
            labelVisionAlerted.AutoSize = true;
            labelVisionAlerted.Font = new Font("Cascadia Code", 8.25F);
            labelVisionAlerted.Location = new Point(325, 55);
            labelVisionAlerted.Margin = new Padding(6, 0, 6, 0);
            labelVisionAlerted.Name = "labelVisionAlerted";
            labelVisionAlerted.Size = new Size(104, 29);
            labelVisionAlerted.TabIndex = 26;
            labelVisionAlerted.Text = "Alerted";
            // 
            // labelVisionBase
            // 
            labelVisionBase.AutoSize = true;
            labelVisionBase.Font = new Font("Cascadia Code", 8.25F);
            labelVisionBase.Location = new Point(156, 55);
            labelVisionBase.Margin = new Padding(6, 0, 6, 0);
            labelVisionBase.Name = "labelVisionBase";
            labelVisionBase.Size = new Size(65, 29);
            labelVisionBase.TabIndex = 25;
            labelVisionBase.Text = "Base";
            // 
            // numJabsPursuitAlerted
            // 
            numJabsPursuitAlerted.Font = new Font("Cascadia Code", 10.125F);
            numJabsPursuitAlerted.Location = new Point(300, 162);
            numJabsPursuitAlerted.Margin = new Padding(11, 13, 11, 13);
            numJabsPursuitAlerted.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            numJabsPursuitAlerted.Minimum = new decimal(new int[] { 1, 0, 0, int.MinValue });
            numJabsPursuitAlerted.Name = "numJabsPursuitAlerted";
            numJabsPursuitAlerted.Size = new Size(143, 39);
            numJabsPursuitAlerted.TabIndex = 24;
            numJabsPursuitAlerted.TextAlign = HorizontalAlignment.Center;
            numJabsPursuitAlerted.Value = new decimal(new int[] { 1, 0, 0, int.MinValue });
            // 
            // numJabsSightAlerted
            // 
            numJabsSightAlerted.Font = new Font("Cascadia Code", 10.125F);
            numJabsSightAlerted.Location = new Point(300, 97);
            numJabsSightAlerted.Margin = new Padding(11, 13, 11, 13);
            numJabsSightAlerted.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            numJabsSightAlerted.Minimum = new decimal(new int[] { 1, 0, 0, int.MinValue });
            numJabsSightAlerted.Name = "numJabsSightAlerted";
            numJabsSightAlerted.Size = new Size(143, 39);
            numJabsSightAlerted.TabIndex = 23;
            numJabsSightAlerted.TextAlign = HorizontalAlignment.Center;
            numJabsSightAlerted.Value = new decimal(new int[] { 1, 0, 0, int.MinValue });
            // 
            // numJabsPursuit
            // 
            numJabsPursuit.Font = new Font("Cascadia Code", 10.125F);
            numJabsPursuit.Location = new Point(135, 162);
            numJabsPursuit.Margin = new Padding(11, 13, 11, 13);
            numJabsPursuit.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            numJabsPursuit.Minimum = new decimal(new int[] { 1, 0, 0, int.MinValue });
            numJabsPursuit.Name = "numJabsPursuit";
            numJabsPursuit.Size = new Size(143, 39);
            numJabsPursuit.TabIndex = 22;
            numJabsPursuit.TextAlign = HorizontalAlignment.Center;
            numJabsPursuit.Value = new decimal(new int[] { 1, 0, 0, int.MinValue });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Cascadia Code", 8.25F);
            label3.Location = new Point(14, 169);
            label3.Margin = new Padding(6, 0, 6, 0);
            label3.Name = "label3";
            label3.Size = new Size(104, 29);
            label3.TabIndex = 21;
            label3.Text = "Pursuit";
            // 
            // numJabsSight
            // 
            numJabsSight.Font = new Font("Cascadia Code", 10.125F);
            numJabsSight.Location = new Point(135, 97);
            numJabsSight.Margin = new Padding(11, 13, 11, 13);
            numJabsSight.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            numJabsSight.Minimum = new decimal(new int[] { 1, 0, 0, int.MinValue });
            numJabsSight.Name = "numJabsSight";
            numJabsSight.Size = new Size(143, 39);
            numJabsSight.TabIndex = 20;
            numJabsSight.TextAlign = HorizontalAlignment.Center;
            numJabsSight.Value = new decimal(new int[] { 1, 0, 0, int.MinValue });
            // 
            // labelJabsSight
            // 
            labelJabsSight.AutoSize = true;
            labelJabsSight.Font = new Font("Cascadia Code", 8.25F);
            labelJabsSight.Location = new Point(40, 104);
            labelJabsSight.Margin = new Padding(6, 0, 6, 0);
            labelJabsSight.Name = "labelJabsSight";
            labelJabsSight.Size = new Size(78, 29);
            labelJabsSight.TabIndex = 19;
            labelJabsSight.Text = "Sight";
            // 
            // checkBoxAiTraitExecutor
            // 
            checkBoxAiTraitExecutor.AutoSize = true;
            checkBoxAiTraitExecutor.Location = new Point(271, 404);
            checkBoxAiTraitExecutor.Name = "checkBoxAiTraitExecutor";
            checkBoxAiTraitExecutor.Size = new Size(227, 37);
            checkBoxAiTraitExecutor.TabIndex = 64;
            checkBoxAiTraitExecutor.Text = "AI: Executor";
            checkBoxAiTraitExecutor.UseVisualStyleBackColor = true;
            // 
            // EnemiesBoard
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1976, 1074);
            Controls.Add(groupBoxJabsData);
            Controls.Add(groupBoxSdpData);
            Controls.Add(groupBoxDropData);
            Controls.Add(groupBoxCoreData);
            Controls.Add(listBoxEnemies);
            Margin = new Padding(6);
            Name = "EnemiesBoard";
            Text = "Enemy Data";
            ((System.ComponentModel.ISupportInitialize)weaponBindingSource).EndInit();
            groupBoxCoreData.ResumeLayout(false);
            groupBoxCoreData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numParamLuck).EndInit();
            ((System.ComponentModel.ISupportInitialize)numParamSpeed).EndInit();
            ((System.ComponentModel.ISupportInitialize)numParamResistance).EndInit();
            ((System.ComponentModel.ISupportInitialize)numParamForce).EndInit();
            ((System.ComponentModel.ISupportInitialize)numParamEndurance).EndInit();
            ((System.ComponentModel.ISupportInitialize)numParamPower).EndInit();
            ((System.ComponentModel.ISupportInitialize)numMaxHp).EndInit();
            ((System.ComponentModel.ISupportInitialize)numMaxTp).EndInit();
            ((System.ComponentModel.ISupportInitialize)numMaxMp).EndInit();
            ((System.ComponentModel.ISupportInitialize)numLevel).EndInit();
            groupBoxDropData.ResumeLayout(false);
            groupBoxDropData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numGold).EndInit();
            ((System.ComponentModel.ISupportInitialize)numExperience).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSdpPoints).EndInit();
            groupBoxSdpData.ResumeLayout(false);
            groupBoxSdpData.PerformLayout();
            groupBoxSdpPanelDrop.ResumeLayout(false);
            groupBoxSdpPanelDrop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numSdpChance).EndInit();
            groupBoxJabsData.ResumeLayout(false);
            groupBoxJabsData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numAlertDuration).EndInit();
            ((System.ComponentModel.ISupportInitialize)numJabsPursuitAlerted).EndInit();
            ((System.ComponentModel.ISupportInitialize)numJabsSightAlerted).EndInit();
            ((System.ComponentModel.ISupportInitialize)numJabsPursuit).EndInit();
            ((System.ComponentModel.ISupportInitialize)numJabsSight).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBoxEnemies;
        private BindingSource weaponBindingSource;
        private Label labelId;
        private Label labelTextId;
        private GroupBox groupBoxCoreData;
        private TextBox textBoxName;
        private Label labelName;
        private GroupBox groupBoxDropData;
        private ListBox listBoxDrops;
        private Label labelBasicDrops;
        private Button buttonDropHelper;
        private Button buttonCloneToDrops;
        private Button buttonDeleteDrop;
        private Label label1;
        private NumericUpDown numLevel;
        private NumericUpDown numGold;
        private Label labelGold;
        private NumericUpDown numExperience;
        private Label labelExperience;
        private Label labelMaxHp;
        private NumericUpDown numMaxHp;
        private Label labelMaxTp;
        private NumericUpDown numMaxTp;
        private Label labelMaxMp;
        private NumericUpDown numMaxMp;
        private Label labelSdpPoints;
        private NumericUpDown numSdpPoints;
        private GroupBox groupBoxSdpData;
        private GroupBox groupBoxSdpPanelDrop;
        private Label labelSdpKey;
        private TextBox textSdpKey;
        private Label label2;
        private NumericUpDown numSdpChance;
        private CheckBox checkBoxHasPanelDrop;
        private Button buttonCloneToSdpDrop;
        private Label labelSdpItemIdValue;
        private Label labelSdpItemId;
        private NumericUpDown numParamLuck;
        private Label labelParamLuck;
        private NumericUpDown numParamSpeed;
        private Label labelParamSpeed;
        private NumericUpDown numParamResistance;
        private Label labelParamResistance;
        private NumericUpDown numParamForce;
        private Label labelParamForce;
        private NumericUpDown numParamEndurance;
        private Label labelParamEndurance;
        private NumericUpDown numParamPower;
        private Label labelParamPower;
        private Button buttonRemoveSdpData;
        private Button buttonUpdateSdpData;
        private GroupBox groupBoxJabsData;
        private NumericUpDown numJabsPursuit;
        private Label label3;
        private NumericUpDown numJabsSight;
        private Label labelJabsSight;
        private Label labelVisionAlerted;
        private Label labelVisionBase;
        private NumericUpDown numJabsPursuitAlerted;
        private NumericUpDown numJabsSightAlerted;
        private Label labelAlertDuration;
        private NumericUpDown numAlertDuration;
        private CheckBox checkBoxAiTraitReckless;
        private CheckBox checkBoxAiTraitLeader;
        private CheckBox checkBoxAiTraitFollower;
        private CheckBox checkBoxAiTraitCareful;
        private CheckBox checkBoxAiTraitHealer;
        private CheckBox checkBoxAiTraitExecutor;
    }
}
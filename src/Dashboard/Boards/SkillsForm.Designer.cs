using System.ComponentModel;

namespace Dashboard.Boards;

partial class SkillsForm
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
            this.listboxSkills = new System.Windows.Forms.ListBox();
            this.label_skillIdValue = new System.Windows.Forms.Label();
            this.label_skillId = new System.Windows.Forms.Label();
            this.label_skillName = new System.Windows.Forms.Label();
            this.textBox_skillName = new System.Windows.Forms.TextBox();
            this.label_radius = new System.Windows.Forms.Label();
            this.num_radius = new System.Windows.Forms.NumericUpDown();
            this.num_proximity = new System.Windows.Forms.NumericUpDown();
            this.label_proximity = new System.Windows.Forms.Label();
            this.num_cooldown = new System.Windows.Forms.NumericUpDown();
            this.label_cooldown = new System.Windows.Forms.Label();
            this.num_actionId = new System.Windows.Forms.NumericUpDown();
            this.label_actionId = new System.Windows.Forms.Label();
            this.num_castAnimation = new System.Windows.Forms.NumericUpDown();
            this.label_castAnimation = new System.Windows.Forms.Label();
            this.num_duration = new System.Windows.Forms.NumericUpDown();
            this.label_duration = new System.Windows.Forms.Label();
            this.groupBox_combo = new System.Windows.Forms.GroupBox();
            this.checkBox_freeCombo = new System.Windows.Forms.CheckBox();
            this.num_comboDelay = new System.Windows.Forms.NumericUpDown();
            this.label_comboDelay = new System.Windows.Forms.Label();
            this.num_comboSkill = new System.Windows.Forms.NumericUpDown();
            this.label_comboSkill = new System.Windows.Forms.Label();
            this.groupBox_mapData = new System.Windows.Forms.GroupBox();
            this.label_hitbox = new System.Windows.Forms.Label();
            this.comboBox_hitbox = new System.Windows.Forms.ComboBox();
            this.groupBox_targetingData = new System.Windows.Forms.GroupBox();
            this.groupBox_piercingData = new System.Windows.Forms.GroupBox();
            this.num_piercingDelay = new System.Windows.Forms.NumericUpDown();
            this.num_piercingCount = new System.Windows.Forms.NumericUpDown();
            this.label_piercingCount = new System.Windows.Forms.Label();
            this.label_piercingDelay = new System.Windows.Forms.Label();
            this.groupBox_usageData = new System.Windows.Forms.GroupBox();
            this.groupBox_poseData = new System.Windows.Forms.GroupBox();
            this.num_poseDuration = new System.Windows.Forms.NumericUpDown();
            this.label_poseDuration = new System.Windows.Forms.Label();
            this.num_poseIndex = new System.Windows.Forms.NumericUpDown();
            this.label_poseIndex = new System.Windows.Forms.Label();
            this.label_poseSuffix = new System.Windows.Forms.Label();
            this.textBox_poseSuffix = new System.Windows.Forms.TextBox();
            this.checkBox_hideFromJabsMenu = new System.Windows.Forms.CheckBox();
            this.textBox_skillExtend = new System.Windows.Forms.TextBox();
            this.label_skillExtend = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.num_radius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_proximity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_cooldown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_actionId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_castAnimation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_duration)).BeginInit();
            this.groupBox_combo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_comboDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_comboSkill)).BeginInit();
            this.groupBox_mapData.SuspendLayout();
            this.groupBox_targetingData.SuspendLayout();
            this.groupBox_piercingData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_piercingDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_piercingCount)).BeginInit();
            this.groupBox_usageData.SuspendLayout();
            this.groupBox_poseData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_poseDuration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_poseIndex)).BeginInit();
            this.SuspendLayout();
            // 
            // listboxSkills
            // 
            this.listboxSkills.FormattingEnabled = true;
            this.listboxSkills.ItemHeight = 15;
            this.listboxSkills.Location = new System.Drawing.Point(12, 12);
            this.listboxSkills.Name = "listboxSkills";
            this.listboxSkills.Size = new System.Drawing.Size(192, 484);
            this.listboxSkills.TabIndex = 1;
            // 
            // label_skillIdValue
            // 
            this.label_skillIdValue.AutoSize = true;
            this.label_skillIdValue.Location = new System.Drawing.Point(233, 12);
            this.label_skillIdValue.Name = "label_skillIdValue";
            this.label_skillIdValue.Size = new System.Drawing.Size(25, 15);
            this.label_skillIdValue.TabIndex = 11;
            this.label_skillIdValue.Text = "n/a";
            // 
            // label_skillId
            // 
            this.label_skillId.AutoSize = true;
            this.label_skillId.Location = new System.Drawing.Point(210, 12);
            this.label_skillId.Name = "label_skillId";
            this.label_skillId.Size = new System.Drawing.Size(17, 15);
            this.label_skillId.TabIndex = 10;
            this.label_skillId.Text = "Id";
            // 
            // label_skillName
            // 
            this.label_skillName.AutoSize = true;
            this.label_skillName.Location = new System.Drawing.Point(210, 39);
            this.label_skillName.Name = "label_skillName";
            this.label_skillName.Size = new System.Drawing.Size(39, 15);
            this.label_skillName.TabIndex = 9;
            this.label_skillName.Text = "Name";
            // 
            // textBox_skillName
            // 
            this.textBox_skillName.Location = new System.Drawing.Point(210, 57);
            this.textBox_skillName.Name = "textBox_skillName";
            this.textBox_skillName.Size = new System.Drawing.Size(195, 23);
            this.textBox_skillName.TabIndex = 8;
            // 
            // label_radius
            // 
            this.label_radius.AutoSize = true;
            this.label_radius.Location = new System.Drawing.Point(23, 24);
            this.label_radius.Name = "label_radius";
            this.label_radius.Size = new System.Drawing.Size(42, 15);
            this.label_radius.TabIndex = 12;
            this.label_radius.Text = "Radius";
            // 
            // num_radius
            // 
            this.num_radius.DecimalPlaces = 1;
            this.num_radius.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.num_radius.Location = new System.Drawing.Point(71, 22);
            this.num_radius.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.num_radius.Name = "num_radius";
            this.num_radius.Size = new System.Drawing.Size(48, 23);
            this.num_radius.TabIndex = 13;
            this.num_radius.Value = new decimal(new int[] {
            15,
            0,
            0,
            65536});
            // 
            // num_proximity
            // 
            this.num_proximity.DecimalPlaces = 1;
            this.num_proximity.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.num_proximity.Location = new System.Drawing.Point(71, 51);
            this.num_proximity.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.num_proximity.Name = "num_proximity";
            this.num_proximity.Size = new System.Drawing.Size(45, 23);
            this.num_proximity.TabIndex = 15;
            this.num_proximity.Value = new decimal(new int[] {
            15,
            0,
            0,
            65536});
            // 
            // label_proximity
            // 
            this.label_proximity.AutoSize = true;
            this.label_proximity.Location = new System.Drawing.Point(7, 53);
            this.label_proximity.Name = "label_proximity";
            this.label_proximity.Size = new System.Drawing.Size(58, 15);
            this.label_proximity.TabIndex = 14;
            this.label_proximity.Text = "Proximity";
            // 
            // num_cooldown
            // 
            this.num_cooldown.Location = new System.Drawing.Point(99, 20);
            this.num_cooldown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.num_cooldown.Name = "num_cooldown";
            this.num_cooldown.Size = new System.Drawing.Size(53, 23);
            this.num_cooldown.TabIndex = 17;
            this.num_cooldown.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // label_cooldown
            // 
            this.label_cooldown.AutoSize = true;
            this.label_cooldown.Location = new System.Drawing.Point(31, 24);
            this.label_cooldown.Name = "label_cooldown";
            this.label_cooldown.Size = new System.Drawing.Size(62, 15);
            this.label_cooldown.TabIndex = 16;
            this.label_cooldown.Text = "Cooldown";
            // 
            // num_actionId
            // 
            this.num_actionId.Location = new System.Drawing.Point(71, 20);
            this.num_actionId.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.num_actionId.Name = "num_actionId";
            this.num_actionId.Size = new System.Drawing.Size(56, 23);
            this.num_actionId.TabIndex = 19;
            this.num_actionId.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label_actionId
            // 
            this.label_actionId.AutoSize = true;
            this.label_actionId.Location = new System.Drawing.Point(9, 24);
            this.label_actionId.Name = "label_actionId";
            this.label_actionId.Size = new System.Drawing.Size(56, 15);
            this.label_actionId.TabIndex = 18;
            this.label_actionId.Text = "Action ID";
            // 
            // num_castAnimation
            // 
            this.num_castAnimation.Location = new System.Drawing.Point(100, 51);
            this.num_castAnimation.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.num_castAnimation.Name = "num_castAnimation";
            this.num_castAnimation.Size = new System.Drawing.Size(52, 23);
            this.num_castAnimation.TabIndex = 21;
            this.num_castAnimation.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label_castAnimation
            // 
            this.label_castAnimation.AutoSize = true;
            this.label_castAnimation.Location = new System.Drawing.Point(6, 53);
            this.label_castAnimation.Name = "label_castAnimation";
            this.label_castAnimation.Size = new System.Drawing.Size(89, 15);
            this.label_castAnimation.TabIndex = 20;
            this.label_castAnimation.Text = "Cast Animation";
            // 
            // num_duration
            // 
            this.num_duration.Location = new System.Drawing.Point(71, 51);
            this.num_duration.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.num_duration.Name = "num_duration";
            this.num_duration.Size = new System.Drawing.Size(56, 23);
            this.num_duration.TabIndex = 23;
            this.num_duration.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // label_duration
            // 
            this.label_duration.AutoSize = true;
            this.label_duration.Location = new System.Drawing.Point(12, 53);
            this.label_duration.Name = "label_duration";
            this.label_duration.Size = new System.Drawing.Size(53, 15);
            this.label_duration.TabIndex = 22;
            this.label_duration.Text = "Duration";
            // 
            // groupBox_combo
            // 
            this.groupBox_combo.Controls.Add(this.checkBox_freeCombo);
            this.groupBox_combo.Controls.Add(this.num_comboDelay);
            this.groupBox_combo.Controls.Add(this.label_comboDelay);
            this.groupBox_combo.Controls.Add(this.num_comboSkill);
            this.groupBox_combo.Controls.Add(this.label_comboSkill);
            this.groupBox_combo.Location = new System.Drawing.Point(210, 195);
            this.groupBox_combo.Name = "groupBox_combo";
            this.groupBox_combo.Size = new System.Drawing.Size(171, 107);
            this.groupBox_combo.TabIndex = 24;
            this.groupBox_combo.TabStop = false;
            this.groupBox_combo.Text = "COMBO DATA";
            // 
            // checkBox_freeCombo
            // 
            this.checkBox_freeCombo.AutoSize = true;
            this.checkBox_freeCombo.Location = new System.Drawing.Point(14, 78);
            this.checkBox_freeCombo.Name = "checkBox_freeCombo";
            this.checkBox_freeCombo.Size = new System.Drawing.Size(136, 19);
            this.checkBox_freeCombo.TabIndex = 29;
            this.checkBox_freeCombo.Text = "Free Combo Enabled";
            this.checkBox_freeCombo.UseVisualStyleBackColor = false;
            // 
            // num_comboDelay
            // 
            this.num_comboDelay.Location = new System.Drawing.Point(91, 49);
            this.num_comboDelay.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.num_comboDelay.Name = "num_comboDelay";
            this.num_comboDelay.Size = new System.Drawing.Size(62, 23);
            this.num_comboDelay.TabIndex = 28;
            this.num_comboDelay.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label_comboDelay
            // 
            this.label_comboDelay.AutoSize = true;
            this.label_comboDelay.Location = new System.Drawing.Point(6, 51);
            this.label_comboDelay.Name = "label_comboDelay";
            this.label_comboDelay.Size = new System.Drawing.Size(79, 15);
            this.label_comboDelay.TabIndex = 27;
            this.label_comboDelay.Text = "Combo Delay";
            // 
            // num_comboSkill
            // 
            this.num_comboSkill.Location = new System.Drawing.Point(91, 20);
            this.num_comboSkill.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.num_comboSkill.Name = "num_comboSkill";
            this.num_comboSkill.Size = new System.Drawing.Size(62, 23);
            this.num_comboSkill.TabIndex = 26;
            this.num_comboSkill.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label_comboSkill
            // 
            this.label_comboSkill.AutoSize = true;
            this.label_comboSkill.Location = new System.Drawing.Point(14, 24);
            this.label_comboSkill.Name = "label_comboSkill";
            this.label_comboSkill.Size = new System.Drawing.Size(71, 15);
            this.label_comboSkill.TabIndex = 25;
            this.label_comboSkill.Text = "Combo Skill";
            // 
            // groupBox_mapData
            // 
            this.groupBox_mapData.Controls.Add(this.num_actionId);
            this.groupBox_mapData.Controls.Add(this.label_actionId);
            this.groupBox_mapData.Controls.Add(this.num_duration);
            this.groupBox_mapData.Controls.Add(this.label_duration);
            this.groupBox_mapData.Location = new System.Drawing.Point(398, 195);
            this.groupBox_mapData.Name = "groupBox_mapData";
            this.groupBox_mapData.Size = new System.Drawing.Size(158, 85);
            this.groupBox_mapData.TabIndex = 25;
            this.groupBox_mapData.TabStop = false;
            this.groupBox_mapData.Text = "MAP DATA";
            // 
            // label_hitbox
            // 
            this.label_hitbox.AutoSize = true;
            this.label_hitbox.Location = new System.Drawing.Point(138, 24);
            this.label_hitbox.Name = "label_hitbox";
            this.label_hitbox.Size = new System.Drawing.Size(43, 15);
            this.label_hitbox.TabIndex = 26;
            this.label_hitbox.Text = "Hitbox";
            // 
            // comboBox_hitbox
            // 
            this.comboBox_hitbox.FormattingEnabled = true;
            this.comboBox_hitbox.Location = new System.Drawing.Point(187, 22);
            this.comboBox_hitbox.Name = "comboBox_hitbox";
            this.comboBox_hitbox.Size = new System.Drawing.Size(121, 23);
            this.comboBox_hitbox.TabIndex = 27;
            // 
            // groupBox_targetingData
            // 
            this.groupBox_targetingData.Controls.Add(this.num_radius);
            this.groupBox_targetingData.Controls.Add(this.comboBox_hitbox);
            this.groupBox_targetingData.Controls.Add(this.label_hitbox);
            this.groupBox_targetingData.Controls.Add(this.label_radius);
            this.groupBox_targetingData.Controls.Add(this.label_proximity);
            this.groupBox_targetingData.Controls.Add(this.num_proximity);
            this.groupBox_targetingData.Location = new System.Drawing.Point(210, 104);
            this.groupBox_targetingData.Name = "groupBox_targetingData";
            this.groupBox_targetingData.Size = new System.Drawing.Size(346, 85);
            this.groupBox_targetingData.TabIndex = 28;
            this.groupBox_targetingData.TabStop = false;
            this.groupBox_targetingData.Text = "TARGETING DATA";
            // 
            // groupBox_piercingData
            // 
            this.groupBox_piercingData.Controls.Add(this.num_piercingDelay);
            this.groupBox_piercingData.Controls.Add(this.num_piercingCount);
            this.groupBox_piercingData.Controls.Add(this.label_piercingCount);
            this.groupBox_piercingData.Controls.Add(this.label_piercingDelay);
            this.groupBox_piercingData.Location = new System.Drawing.Point(210, 308);
            this.groupBox_piercingData.Name = "groupBox_piercingData";
            this.groupBox_piercingData.Size = new System.Drawing.Size(171, 88);
            this.groupBox_piercingData.TabIndex = 29;
            this.groupBox_piercingData.TabStop = false;
            this.groupBox_piercingData.Text = "PIERCING DATA";
            // 
            // num_piercingDelay
            // 
            this.num_piercingDelay.Location = new System.Drawing.Point(88, 54);
            this.num_piercingDelay.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.num_piercingDelay.Name = "num_piercingDelay";
            this.num_piercingDelay.Size = new System.Drawing.Size(48, 23);
            this.num_piercingDelay.TabIndex = 31;
            this.num_piercingDelay.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // num_piercingCount
            // 
            this.num_piercingCount.Location = new System.Drawing.Point(88, 25);
            this.num_piercingCount.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.num_piercingCount.Name = "num_piercingCount";
            this.num_piercingCount.Size = new System.Drawing.Size(48, 23);
            this.num_piercingCount.TabIndex = 29;
            this.num_piercingCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label_piercingCount
            // 
            this.label_piercingCount.AutoSize = true;
            this.label_piercingCount.Location = new System.Drawing.Point(7, 27);
            this.label_piercingCount.Name = "label_piercingCount";
            this.label_piercingCount.Size = new System.Drawing.Size(75, 15);
            this.label_piercingCount.TabIndex = 28;
            this.label_piercingCount.Text = "Pierce Count";
            // 
            // label_piercingDelay
            // 
            this.label_piercingDelay.AutoSize = true;
            this.label_piercingDelay.Location = new System.Drawing.Point(7, 56);
            this.label_piercingDelay.Name = "label_piercingDelay";
            this.label_piercingDelay.Size = new System.Drawing.Size(71, 15);
            this.label_piercingDelay.TabIndex = 30;
            this.label_piercingDelay.Text = "Pierce Delay";
            // 
            // groupBox_usageData
            // 
            this.groupBox_usageData.Controls.Add(this.label_cooldown);
            this.groupBox_usageData.Controls.Add(this.num_cooldown);
            this.groupBox_usageData.Controls.Add(this.num_castAnimation);
            this.groupBox_usageData.Controls.Add(this.label_castAnimation);
            this.groupBox_usageData.Location = new System.Drawing.Point(398, 308);
            this.groupBox_usageData.Name = "groupBox_usageData";
            this.groupBox_usageData.Size = new System.Drawing.Size(158, 85);
            this.groupBox_usageData.TabIndex = 30;
            this.groupBox_usageData.TabStop = false;
            this.groupBox_usageData.Text = "USAGE DATA";
            // 
            // groupBox_poseData
            // 
            this.groupBox_poseData.Controls.Add(this.num_poseDuration);
            this.groupBox_poseData.Controls.Add(this.label_poseDuration);
            this.groupBox_poseData.Controls.Add(this.num_poseIndex);
            this.groupBox_poseData.Controls.Add(this.label_poseIndex);
            this.groupBox_poseData.Controls.Add(this.label_poseSuffix);
            this.groupBox_poseData.Controls.Add(this.textBox_poseSuffix);
            this.groupBox_poseData.Location = new System.Drawing.Point(562, 104);
            this.groupBox_poseData.Name = "groupBox_poseData";
            this.groupBox_poseData.Size = new System.Drawing.Size(176, 110);
            this.groupBox_poseData.TabIndex = 31;
            this.groupBox_poseData.TabStop = false;
            this.groupBox_poseData.Text = "POSE DATA";
            // 
            // num_poseDuration
            // 
            this.num_poseDuration.Location = new System.Drawing.Point(67, 75);
            this.num_poseDuration.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.num_poseDuration.Name = "num_poseDuration";
            this.num_poseDuration.Size = new System.Drawing.Size(56, 23);
            this.num_poseDuration.TabIndex = 25;
            this.num_poseDuration.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // label_poseDuration
            // 
            this.label_poseDuration.AutoSize = true;
            this.label_poseDuration.Location = new System.Drawing.Point(8, 77);
            this.label_poseDuration.Name = "label_poseDuration";
            this.label_poseDuration.Size = new System.Drawing.Size(53, 15);
            this.label_poseDuration.TabIndex = 24;
            this.label_poseDuration.Text = "Duration";
            // 
            // num_poseIndex
            // 
            this.num_poseIndex.Location = new System.Drawing.Point(67, 46);
            this.num_poseIndex.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.num_poseIndex.Name = "num_poseIndex";
            this.num_poseIndex.Size = new System.Drawing.Size(56, 23);
            this.num_poseIndex.TabIndex = 24;
            this.num_poseIndex.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label_poseIndex
            // 
            this.label_poseIndex.AutoSize = true;
            this.label_poseIndex.Location = new System.Drawing.Point(25, 48);
            this.label_poseIndex.Name = "label_poseIndex";
            this.label_poseIndex.Size = new System.Drawing.Size(36, 15);
            this.label_poseIndex.TabIndex = 33;
            this.label_poseIndex.Text = "Index";
            // 
            // label_poseSuffix
            // 
            this.label_poseSuffix.AutoSize = true;
            this.label_poseSuffix.Location = new System.Drawing.Point(24, 20);
            this.label_poseSuffix.Name = "label_poseSuffix";
            this.label_poseSuffix.Size = new System.Drawing.Size(37, 15);
            this.label_poseSuffix.TabIndex = 32;
            this.label_poseSuffix.Text = "Suffix";
            // 
            // textBox_poseSuffix
            // 
            this.textBox_poseSuffix.Location = new System.Drawing.Point(67, 17);
            this.textBox_poseSuffix.Name = "textBox_poseSuffix";
            this.textBox_poseSuffix.Size = new System.Drawing.Size(97, 23);
            this.textBox_poseSuffix.TabIndex = 32;
            // 
            // checkBox_hideFromJabsMenu
            // 
            this.checkBox_hideFromJabsMenu.AutoSize = true;
            this.checkBox_hideFromJabsMenu.Location = new System.Drawing.Point(429, 57);
            this.checkBox_hideFromJabsMenu.Name = "checkBox_hideFromJabsMenu";
            this.checkBox_hideFromJabsMenu.Size = new System.Drawing.Size(190, 19);
            this.checkBox_hideFromJabsMenu.TabIndex = 30;
            this.checkBox_hideFromJabsMenu.Text = "Hidden from JABS Quick Menu";
            this.checkBox_hideFromJabsMenu.UseVisualStyleBackColor = false;
            // 
            // textBox_skillExtend
            // 
            this.textBox_skillExtend.Location = new System.Drawing.Point(410, 12);
            this.textBox_skillExtend.Name = "textBox_skillExtend";
            this.textBox_skillExtend.Size = new System.Drawing.Size(328, 23);
            this.textBox_skillExtend.TabIndex = 32;
            // 
            // label_skillExtend
            // 
            this.label_skillExtend.AutoSize = true;
            this.label_skillExtend.Location = new System.Drawing.Point(324, 15);
            this.label_skillExtend.Name = "label_skillExtend";
            this.label_skillExtend.Size = new System.Drawing.Size(80, 15);
            this.label_skillExtend.TabIndex = 33;
            this.label_skillExtend.Text = "Extends Skills:";
            // 
            // SkillsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 511);
            this.Controls.Add(this.label_skillExtend);
            this.Controls.Add(this.textBox_skillExtend);
            this.Controls.Add(this.checkBox_hideFromJabsMenu);
            this.Controls.Add(this.groupBox_poseData);
            this.Controls.Add(this.groupBox_usageData);
            this.Controls.Add(this.groupBox_piercingData);
            this.Controls.Add(this.groupBox_targetingData);
            this.Controls.Add(this.groupBox_mapData);
            this.Controls.Add(this.groupBox_combo);
            this.Controls.Add(this.label_skillIdValue);
            this.Controls.Add(this.label_skillId);
            this.Controls.Add(this.label_skillName);
            this.Controls.Add(this.textBox_skillName);
            this.Controls.Add(this.listboxSkills);
            this.Name = "SkillsForm";
            this.Text = "Skill Data";
            ((System.ComponentModel.ISupportInitialize)(this.num_radius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_proximity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_cooldown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_actionId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_castAnimation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_duration)).EndInit();
            this.groupBox_combo.ResumeLayout(false);
            this.groupBox_combo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_comboDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_comboSkill)).EndInit();
            this.groupBox_mapData.ResumeLayout(false);
            this.groupBox_mapData.PerformLayout();
            this.groupBox_targetingData.ResumeLayout(false);
            this.groupBox_targetingData.PerformLayout();
            this.groupBox_piercingData.ResumeLayout(false);
            this.groupBox_piercingData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_piercingDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_piercingCount)).EndInit();
            this.groupBox_usageData.ResumeLayout(false);
            this.groupBox_usageData.PerformLayout();
            this.groupBox_poseData.ResumeLayout(false);
            this.groupBox_poseData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_poseDuration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_poseIndex)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox listboxSkills;
        private Label label_skillIdValue;
        private Label label_skillId;
        private Label label_skillName;
        private TextBox textBox_skillName;
    private Label label_radius;
    private NumericUpDown num_radius;
    private NumericUpDown num_proximity;
    private Label label_proximity;
    private NumericUpDown num_cooldown;
    private Label label_cooldown;
    private NumericUpDown num_actionId;
    private Label label_actionId;
    private NumericUpDown num_castAnimation;
    private Label label_castAnimation;
    private NumericUpDown num_duration;
    private Label label_duration;
    private GroupBox groupBox_combo;
    private NumericUpDown num_comboDelay;
    private Label label_comboDelay;
    private NumericUpDown num_comboSkill;
    private Label label_comboSkill;
    private GroupBox groupBox_mapData;
    private Label label_hitbox;
    private ComboBox comboBox_hitbox;
    private CheckBox checkBox_freeCombo;
    private GroupBox groupBox_targetingData;
    private GroupBox groupBox_piercingData;
    private NumericUpDown num_piercingCount;
    private Label label_piercingCount;
    private Label label_piercingDelay;
    private NumericUpDown num_piercingDelay;
    private GroupBox groupBox_usageData;
    private GroupBox groupBox_poseData;
    private NumericUpDown num_poseDuration;
    private Label label_poseDuration;
    private NumericUpDown num_poseIndex;
    private Label label_poseIndex;
    private Label label_poseSuffix;
    private TextBox textBox_poseSuffix;
    private CheckBox checkBox_hideFromJabsMenu;
    private TextBox textBox_skillExtend;
    private Label label_skillExtend;
}
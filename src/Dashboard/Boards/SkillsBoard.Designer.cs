using System.ComponentModel;

namespace JMZ.Dashboard.Boards;

partial class SkillsBoard
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
        components = new Container();
        listboxSkills = new ListBox();
        label_skillIdValue = new Label();
        label_skillId = new Label();
        label_skillName = new Label();
        textBox_skillName = new TextBox();
        label_radius = new Label();
        num_radius = new NumericUpDown();
        num_proximity = new NumericUpDown();
        label_proximity = new Label();
        num_cooldown = new NumericUpDown();
        label_cooldown = new Label();
        num_actionId = new NumericUpDown();
        label_actionId = new Label();
        num_castAnimation = new NumericUpDown();
        label_castAnimation = new Label();
        num_duration = new NumericUpDown();
        label_duration = new Label();
        groupBox_combo = new GroupBox();
        checkBox_comboStarter = new CheckBox();
        checkBox_freeCombo = new CheckBox();
        num_comboDelay = new NumericUpDown();
        label_comboDelay = new Label();
        num_comboSkill = new NumericUpDown();
        label_comboSkill = new Label();
        groupBox_mapData = new GroupBox();
        checkBox_hideFromJabsMenu = new CheckBox();
        label_hitbox = new Label();
        comboBox_hitbox = new ComboBox();
        groupBox_targetingData = new GroupBox();
        checkBox_direct = new CheckBox();
        groupBox_piercingData = new GroupBox();
        num_piercingDelay = new NumericUpDown();
        num_piercingCount = new NumericUpDown();
        label_piercingCount = new Label();
        label_piercingDelay = new Label();
        groupBox_usageData = new GroupBox();
        num_castTime = new NumericUpDown();
        label_castTime = new Label();
        checkBox_canGapClose = new CheckBox();
        checkBox_aiSkillExclude = new CheckBox();
        groupBox_poseData = new GroupBox();
        num_poseDuration = new NumericUpDown();
        label_poseDuration = new Label();
        num_poseIndex = new NumericUpDown();
        label_poseIndex = new Label();
        label_poseSuffix = new Label();
        textBox_poseSuffix = new TextBox();
        textBox_skillExtend = new TextBox();
        toolTip_skillsForm = new ToolTip(components);
        tabControl_skills = new TabControl();
        tabPage_jabs = new TabPage();
        tabPage_skillExtend = new TabPage();
        groupBox_skillExtends = new GroupBox();
        label_skillExtend = new Label();
        ((ISupportInitialize)num_radius).BeginInit();
        ((ISupportInitialize)num_proximity).BeginInit();
        ((ISupportInitialize)num_cooldown).BeginInit();
        ((ISupportInitialize)num_actionId).BeginInit();
        ((ISupportInitialize)num_castAnimation).BeginInit();
        ((ISupportInitialize)num_duration).BeginInit();
        groupBox_combo.SuspendLayout();
        ((ISupportInitialize)num_comboDelay).BeginInit();
        ((ISupportInitialize)num_comboSkill).BeginInit();
        groupBox_mapData.SuspendLayout();
        groupBox_targetingData.SuspendLayout();
        groupBox_piercingData.SuspendLayout();
        ((ISupportInitialize)num_piercingDelay).BeginInit();
        ((ISupportInitialize)num_piercingCount).BeginInit();
        groupBox_usageData.SuspendLayout();
        ((ISupportInitialize)num_castTime).BeginInit();
        groupBox_poseData.SuspendLayout();
        ((ISupportInitialize)num_poseDuration).BeginInit();
        ((ISupportInitialize)num_poseIndex).BeginInit();
        tabControl_skills.SuspendLayout();
        tabPage_jabs.SuspendLayout();
        tabPage_skillExtend.SuspendLayout();
        groupBox_skillExtends.SuspendLayout();
        SuspendLayout();
        // 
        // listboxSkills
        // 
        listboxSkills.Font = new Font("Victor Mono", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
        listboxSkills.FormattingEnabled = true;
        listboxSkills.Location = new Point(12, 12);
        listboxSkills.Name = "listboxSkills";
        listboxSkills.Size = new Size(192, 472);
        listboxSkills.TabIndex = 1;
        // 
        // label_skillIdValue
        // 
        label_skillIdValue.AutoSize = true;
        label_skillIdValue.Font = new Font("Victor Mono", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
        label_skillIdValue.Location = new Point(233, 12);
        label_skillIdValue.Name = "label_skillIdValue";
        label_skillIdValue.Size = new Size(28, 16);
        label_skillIdValue.TabIndex = 11;
        label_skillIdValue.Text = "n/a";
        // 
        // label_skillId
        // 
        label_skillId.AutoSize = true;
        label_skillId.Font = new Font("Victor Mono", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
        label_skillId.Location = new Point(210, 12);
        label_skillId.Name = "label_skillId";
        label_skillId.Size = new Size(21, 16);
        label_skillId.TabIndex = 10;
        label_skillId.Text = "Id";
        // 
        // label_skillName
        // 
        label_skillName.AutoSize = true;
        label_skillName.Font = new Font("Victor Mono", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
        label_skillName.Location = new Point(354, 15);
        label_skillName.Name = "label_skillName";
        label_skillName.Size = new Size(35, 16);
        label_skillName.TabIndex = 9;
        label_skillName.Text = "Name";
        // 
        // textBox_skillName
        // 
        textBox_skillName.Font = new Font("Victor Mono", 12F, FontStyle.Regular, GraphicsUnit.Point);
        textBox_skillName.Location = new Point(395, 9);
        textBox_skillName.Name = "textBox_skillName";
        textBox_skillName.Size = new Size(195, 30);
        textBox_skillName.TabIndex = 8;
        // 
        // label_radius
        // 
        label_radius.AutoSize = true;
        label_radius.Font = new Font("Victor Mono", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
        label_radius.Location = new Point(28, 48);
        label_radius.Name = "label_radius";
        label_radius.Size = new Size(49, 16);
        label_radius.TabIndex = 12;
        label_radius.Text = "Radius";
        // 
        // num_radius
        // 
        num_radius.DecimalPlaces = 1;
        num_radius.Font = new Font("Victor Mono", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
        num_radius.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
        num_radius.Location = new Point(83, 46);
        num_radius.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
        num_radius.Minimum = new decimal(new int[] { 1, 0, 0, -2147418112 });
        num_radius.Name = "num_radius";
        num_radius.Size = new Size(48, 26);
        num_radius.TabIndex = 13;
        num_radius.Value = new decimal(new int[] { 15, 0, 0, 65536 });
        // 
        // num_proximity
        // 
        num_proximity.DecimalPlaces = 1;
        num_proximity.Font = new Font("Victor Mono", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
        num_proximity.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
        num_proximity.Location = new Point(83, 75);
        num_proximity.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
        num_proximity.Name = "num_proximity";
        num_proximity.Size = new Size(45, 26);
        num_proximity.TabIndex = 15;
        num_proximity.Value = new decimal(new int[] { 15, 0, 0, 65536 });
        // 
        // label_proximity
        // 
        label_proximity.AutoSize = true;
        label_proximity.Font = new Font("Victor Mono", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
        label_proximity.Location = new Point(7, 77);
        label_proximity.Name = "label_proximity";
        label_proximity.Size = new Size(70, 16);
        label_proximity.TabIndex = 14;
        label_proximity.Text = "Proximity";
        // 
        // num_cooldown
        // 
        num_cooldown.Font = new Font("Victor Mono", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
        num_cooldown.Location = new Point(116, 20);
        num_cooldown.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
        num_cooldown.Name = "num_cooldown";
        num_cooldown.Size = new Size(53, 26);
        num_cooldown.TabIndex = 17;
        num_cooldown.Value = new decimal(new int[] { 60, 0, 0, 0 });
        // 
        // label_cooldown
        // 
        label_cooldown.AutoSize = true;
        label_cooldown.Font = new Font("Victor Mono", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
        label_cooldown.Location = new Point(47, 24);
        label_cooldown.Name = "label_cooldown";
        label_cooldown.Size = new Size(63, 16);
        label_cooldown.TabIndex = 16;
        label_cooldown.Text = "Cooldown";
        // 
        // num_actionId
        // 
        num_actionId.Font = new Font("Victor Mono", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
        num_actionId.Location = new Point(85, 21);
        num_actionId.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
        num_actionId.Name = "num_actionId";
        num_actionId.Size = new Size(56, 26);
        num_actionId.TabIndex = 19;
        num_actionId.Value = new decimal(new int[] { 3, 0, 0, 0 });
        // 
        // label_actionId
        // 
        label_actionId.AutoSize = true;
        label_actionId.Font = new Font("Victor Mono", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
        label_actionId.Location = new Point(9, 24);
        label_actionId.Name = "label_actionId";
        label_actionId.Size = new Size(70, 16);
        label_actionId.TabIndex = 18;
        label_actionId.Text = "Action ID";
        // 
        // num_castAnimation
        // 
        num_castAnimation.Font = new Font("Victor Mono", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
        num_castAnimation.Location = new Point(117, 52);
        num_castAnimation.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
        num_castAnimation.Name = "num_castAnimation";
        num_castAnimation.Size = new Size(52, 26);
        num_castAnimation.TabIndex = 21;
        num_castAnimation.Value = new decimal(new int[] { 3, 0, 0, 0 });
        // 
        // label_castAnimation
        // 
        label_castAnimation.AutoSize = true;
        label_castAnimation.Font = new Font("Victor Mono", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
        label_castAnimation.Location = new Point(6, 54);
        label_castAnimation.Name = "label_castAnimation";
        label_castAnimation.Size = new Size(105, 16);
        label_castAnimation.TabIndex = 20;
        label_castAnimation.Text = "Cast Animation";
        // 
        // num_duration
        // 
        num_duration.Font = new Font("Victor Mono", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
        num_duration.Location = new Point(85, 53);
        num_duration.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
        num_duration.Name = "num_duration";
        num_duration.Size = new Size(56, 26);
        num_duration.TabIndex = 23;
        num_duration.Value = new decimal(new int[] { 15, 0, 0, 0 });
        // 
        // label_duration
        // 
        label_duration.AutoSize = true;
        label_duration.Font = new Font("Victor Mono", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
        label_duration.Location = new Point(16, 53);
        label_duration.Name = "label_duration";
        label_duration.Size = new Size(63, 16);
        label_duration.TabIndex = 22;
        label_duration.Text = "Duration";
        // 
        // groupBox_combo
        // 
        groupBox_combo.Controls.Add(checkBox_comboStarter);
        groupBox_combo.Controls.Add(checkBox_freeCombo);
        groupBox_combo.Controls.Add(num_comboDelay);
        groupBox_combo.Controls.Add(label_comboDelay);
        groupBox_combo.Controls.Add(num_comboSkill);
        groupBox_combo.Controls.Add(label_comboSkill);
        groupBox_combo.Font = new Font("Victor Mono", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
        groupBox_combo.Location = new Point(204, 167);
        groupBox_combo.Name = "groupBox_combo";
        groupBox_combo.Size = new Size(185, 130);
        groupBox_combo.TabIndex = 24;
        groupBox_combo.TabStop = false;
        groupBox_combo.Text = "COMBO DATA";
        // 
        // checkBox_comboStarter
        // 
        checkBox_comboStarter.AutoSize = true;
        checkBox_comboStarter.Font = new Font("Victor Mono", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
        checkBox_comboStarter.Location = new Point(14, 79);
        checkBox_comboStarter.Name = "checkBox_comboStarter";
        checkBox_comboStarter.Size = new Size(138, 20);
        checkBox_comboStarter.TabIndex = 30;
        checkBox_comboStarter.Text = "AI Combo Starter";
        toolTip_skillsForm.SetToolTip(checkBox_comboStarter, "fffffff");
        checkBox_comboStarter.UseVisualStyleBackColor = false;
        // 
        // checkBox_freeCombo
        // 
        checkBox_freeCombo.AutoSize = true;
        checkBox_freeCombo.Font = new Font("Victor Mono", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
        checkBox_freeCombo.Location = new Point(14, 104);
        checkBox_freeCombo.Name = "checkBox_freeCombo";
        checkBox_freeCombo.Size = new Size(152, 20);
        checkBox_freeCombo.TabIndex = 29;
        checkBox_freeCombo.Text = "Free Combo Enabled";
        toolTip_skillsForm.SetToolTip(checkBox_freeCombo, "vvvvvvv");
        checkBox_freeCombo.UseVisualStyleBackColor = false;
        // 
        // num_comboDelay
        // 
        num_comboDelay.Font = new Font("Victor Mono", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
        num_comboDelay.Location = new Point(101, 51);
        num_comboDelay.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
        num_comboDelay.Name = "num_comboDelay";
        num_comboDelay.Size = new Size(62, 26);
        num_comboDelay.TabIndex = 28;
        num_comboDelay.Value = new decimal(new int[] { 2, 0, 0, 0 });
        // 
        // label_comboDelay
        // 
        label_comboDelay.AutoSize = true;
        label_comboDelay.Font = new Font("Victor Mono", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
        label_comboDelay.Location = new Point(11, 56);
        label_comboDelay.Name = "label_comboDelay";
        label_comboDelay.Size = new Size(84, 16);
        label_comboDelay.TabIndex = 27;
        label_comboDelay.Text = "Combo Delay";
        // 
        // num_comboSkill
        // 
        num_comboSkill.Font = new Font("Victor Mono", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
        num_comboSkill.Location = new Point(101, 22);
        num_comboSkill.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
        num_comboSkill.Name = "num_comboSkill";
        num_comboSkill.Size = new Size(62, 26);
        num_comboSkill.TabIndex = 26;
        num_comboSkill.Value = new decimal(new int[] { 2, 0, 0, 0 });
        // 
        // label_comboSkill
        // 
        label_comboSkill.AutoSize = true;
        label_comboSkill.Font = new Font("Victor Mono", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
        label_comboSkill.Location = new Point(11, 27);
        label_comboSkill.Name = "label_comboSkill";
        label_comboSkill.Size = new Size(84, 16);
        label_comboSkill.TabIndex = 25;
        label_comboSkill.Text = "Combo Skill";
        // 
        // groupBox_mapData
        // 
        groupBox_mapData.Controls.Add(num_actionId);
        groupBox_mapData.Controls.Add(checkBox_hideFromJabsMenu);
        groupBox_mapData.Controls.Add(label_actionId);
        groupBox_mapData.Controls.Add(num_duration);
        groupBox_mapData.Controls.Add(label_duration);
        groupBox_mapData.Font = new Font("Victor Mono", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
        groupBox_mapData.Location = new Point(3, 300);
        groupBox_mapData.Name = "groupBox_mapData";
        groupBox_mapData.Size = new Size(185, 111);
        groupBox_mapData.TabIndex = 25;
        groupBox_mapData.TabStop = false;
        groupBox_mapData.Text = "MAP DATA";
        // 
        // checkBox_hideFromJabsMenu
        // 
        checkBox_hideFromJabsMenu.AutoSize = true;
        checkBox_hideFromJabsMenu.Font = new Font("Victor Mono", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
        checkBox_hideFromJabsMenu.Location = new Point(6, 80);
        checkBox_hideFromJabsMenu.Name = "checkBox_hideFromJabsMenu";
        checkBox_hideFromJabsMenu.Size = new Size(180, 20);
        checkBox_hideFromJabsMenu.TabIndex = 30;
        checkBox_hideFromJabsMenu.Text = "Hidden from Quick Menu";
        checkBox_hideFromJabsMenu.UseVisualStyleBackColor = false;
        // 
        // label_hitbox
        // 
        label_hitbox.AutoSize = true;
        label_hitbox.Font = new Font("Victor Mono", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
        label_hitbox.Location = new Point(9, 111);
        label_hitbox.Name = "label_hitbox";
        label_hitbox.Size = new Size(49, 16);
        label_hitbox.TabIndex = 26;
        label_hitbox.Text = "Hitbox";
        // 
        // comboBox_hitbox
        // 
        comboBox_hitbox.Font = new Font("Victor Mono", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
        comboBox_hitbox.FormattingEnabled = true;
        comboBox_hitbox.Location = new Point(58, 107);
        comboBox_hitbox.Name = "comboBox_hitbox";
        comboBox_hitbox.Size = new Size(121, 24);
        comboBox_hitbox.TabIndex = 27;
        // 
        // groupBox_targetingData
        // 
        groupBox_targetingData.Controls.Add(checkBox_direct);
        groupBox_targetingData.Controls.Add(num_radius);
        groupBox_targetingData.Controls.Add(comboBox_hitbox);
        groupBox_targetingData.Controls.Add(label_hitbox);
        groupBox_targetingData.Controls.Add(label_radius);
        groupBox_targetingData.Controls.Add(label_proximity);
        groupBox_targetingData.Controls.Add(num_proximity);
        groupBox_targetingData.Font = new Font("Victor Mono", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
        groupBox_targetingData.Location = new Point(204, 7);
        groupBox_targetingData.Name = "groupBox_targetingData";
        groupBox_targetingData.Size = new Size(185, 140);
        groupBox_targetingData.TabIndex = 28;
        groupBox_targetingData.TabStop = false;
        groupBox_targetingData.Text = "TARGETING DATA";
        // 
        // checkBox_direct
        // 
        checkBox_direct.AutoSize = true;
        checkBox_direct.Font = new Font("Victor Mono", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
        checkBox_direct.Location = new Point(6, 17);
        checkBox_direct.Name = "checkBox_direct";
        checkBox_direct.Size = new Size(138, 20);
        checkBox_direct.TabIndex = 35;
        checkBox_direct.Text = "Direct Targeting";
        toolTip_skillsForm.SetToolTip(checkBox_direct, "fffffff");
        checkBox_direct.UseVisualStyleBackColor = false;
        // 
        // groupBox_piercingData
        // 
        groupBox_piercingData.Controls.Add(num_piercingDelay);
        groupBox_piercingData.Controls.Add(num_piercingCount);
        groupBox_piercingData.Controls.Add(label_piercingCount);
        groupBox_piercingData.Controls.Add(label_piercingDelay);
        groupBox_piercingData.Font = new Font("Victor Mono", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
        groupBox_piercingData.Location = new Point(3, 194);
        groupBox_piercingData.Name = "groupBox_piercingData";
        groupBox_piercingData.Size = new Size(185, 88);
        groupBox_piercingData.TabIndex = 29;
        groupBox_piercingData.TabStop = false;
        groupBox_piercingData.Text = "PIERCING DATA";
        // 
        // num_piercingDelay
        // 
        num_piercingDelay.Font = new Font("Victor Mono", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
        num_piercingDelay.Location = new Point(104, 54);
        num_piercingDelay.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
        num_piercingDelay.Name = "num_piercingDelay";
        num_piercingDelay.Size = new Size(48, 26);
        num_piercingDelay.TabIndex = 31;
        num_piercingDelay.Value = new decimal(new int[] { 1, 0, 0, 0 });
        // 
        // num_piercingCount
        // 
        num_piercingCount.Font = new Font("Victor Mono", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
        num_piercingCount.Location = new Point(104, 25);
        num_piercingCount.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
        num_piercingCount.Name = "num_piercingCount";
        num_piercingCount.Size = new Size(48, 26);
        num_piercingCount.TabIndex = 29;
        num_piercingCount.Value = new decimal(new int[] { 1, 0, 0, 0 });
        // 
        // label_piercingCount
        // 
        label_piercingCount.AutoSize = true;
        label_piercingCount.Font = new Font("Victor Mono", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
        label_piercingCount.Location = new Point(7, 30);
        label_piercingCount.Name = "label_piercingCount";
        label_piercingCount.Size = new Size(91, 16);
        label_piercingCount.TabIndex = 28;
        label_piercingCount.Text = "Pierce Count";
        // 
        // label_piercingDelay
        // 
        label_piercingDelay.AutoSize = true;
        label_piercingDelay.Font = new Font("Victor Mono", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
        label_piercingDelay.Location = new Point(7, 56);
        label_piercingDelay.Name = "label_piercingDelay";
        label_piercingDelay.Size = new Size(91, 16);
        label_piercingDelay.TabIndex = 30;
        label_piercingDelay.Text = "Pierce Delay";
        // 
        // groupBox_usageData
        // 
        groupBox_usageData.Controls.Add(num_castTime);
        groupBox_usageData.Controls.Add(label_castTime);
        groupBox_usageData.Controls.Add(checkBox_canGapClose);
        groupBox_usageData.Controls.Add(checkBox_aiSkillExclude);
        groupBox_usageData.Controls.Add(label_cooldown);
        groupBox_usageData.Controls.Add(num_cooldown);
        groupBox_usageData.Controls.Add(num_castAnimation);
        groupBox_usageData.Controls.Add(label_castAnimation);
        groupBox_usageData.Font = new Font("Victor Mono", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
        groupBox_usageData.Location = new Point(3, 3);
        groupBox_usageData.Name = "groupBox_usageData";
        groupBox_usageData.Size = new Size(185, 174);
        groupBox_usageData.TabIndex = 30;
        groupBox_usageData.TabStop = false;
        groupBox_usageData.Text = "USAGE DATA";
        // 
        // num_castTime
        // 
        num_castTime.Font = new Font("Victor Mono", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
        num_castTime.Location = new Point(117, 84);
        num_castTime.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
        num_castTime.Name = "num_castTime";
        num_castTime.Size = new Size(52, 26);
        num_castTime.TabIndex = 34;
        num_castTime.Value = new decimal(new int[] { 3, 0, 0, 0 });
        // 
        // label_castTime
        // 
        label_castTime.AutoSize = true;
        label_castTime.Font = new Font("Victor Mono", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
        label_castTime.Location = new Point(41, 88);
        label_castTime.Name = "label_castTime";
        label_castTime.Size = new Size(70, 16);
        label_castTime.TabIndex = 33;
        label_castTime.Text = "Cast Time";
        // 
        // checkBox_canGapClose
        // 
        checkBox_canGapClose.AutoSize = true;
        checkBox_canGapClose.Font = new Font("Victor Mono", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
        checkBox_canGapClose.Location = new Point(5, 149);
        checkBox_canGapClose.Name = "checkBox_canGapClose";
        checkBox_canGapClose.Size = new Size(110, 20);
        checkBox_canGapClose.TabIndex = 32;
        checkBox_canGapClose.Text = "Can Gapclose";
        toolTip_skillsForm.SetToolTip(checkBox_canGapClose, "fffffff");
        checkBox_canGapClose.UseVisualStyleBackColor = false;
        // 
        // checkBox_aiSkillExclude
        // 
        checkBox_aiSkillExclude.AutoSize = true;
        checkBox_aiSkillExclude.Font = new Font("Victor Mono", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
        checkBox_aiSkillExclude.Location = new Point(6, 123);
        checkBox_aiSkillExclude.Name = "checkBox_aiSkillExclude";
        checkBox_aiSkillExclude.Size = new Size(131, 20);
        checkBox_aiSkillExclude.TabIndex = 31;
        checkBox_aiSkillExclude.Text = "Exclude from AI";
        toolTip_skillsForm.SetToolTip(checkBox_aiSkillExclude, "fffffff");
        checkBox_aiSkillExclude.UseVisualStyleBackColor = false;
        // 
        // groupBox_poseData
        // 
        groupBox_poseData.Controls.Add(num_poseDuration);
        groupBox_poseData.Controls.Add(label_poseDuration);
        groupBox_poseData.Controls.Add(num_poseIndex);
        groupBox_poseData.Controls.Add(label_poseIndex);
        groupBox_poseData.Controls.Add(label_poseSuffix);
        groupBox_poseData.Controls.Add(textBox_poseSuffix);
        groupBox_poseData.Font = new Font("Victor Mono", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
        groupBox_poseData.Location = new Point(405, 7);
        groupBox_poseData.Name = "groupBox_poseData";
        groupBox_poseData.Size = new Size(185, 110);
        groupBox_poseData.TabIndex = 31;
        groupBox_poseData.TabStop = false;
        groupBox_poseData.Text = "POSE DATA";
        // 
        // num_poseDuration
        // 
        num_poseDuration.Font = new Font("Victor Mono", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
        num_poseDuration.Location = new Point(79, 75);
        num_poseDuration.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
        num_poseDuration.Name = "num_poseDuration";
        num_poseDuration.Size = new Size(56, 26);
        num_poseDuration.TabIndex = 25;
        num_poseDuration.Value = new decimal(new int[] { 15, 0, 0, 0 });
        // 
        // label_poseDuration
        // 
        label_poseDuration.AutoSize = true;
        label_poseDuration.Font = new Font("Victor Mono", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
        label_poseDuration.Location = new Point(10, 77);
        label_poseDuration.Name = "label_poseDuration";
        label_poseDuration.Size = new Size(63, 16);
        label_poseDuration.TabIndex = 24;
        label_poseDuration.Text = "Duration";
        // 
        // num_poseIndex
        // 
        num_poseIndex.Font = new Font("Victor Mono", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
        num_poseIndex.Location = new Point(79, 46);
        num_poseIndex.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
        num_poseIndex.Name = "num_poseIndex";
        num_poseIndex.Size = new Size(56, 26);
        num_poseIndex.TabIndex = 24;
        num_poseIndex.Value = new decimal(new int[] { 3, 0, 0, 0 });
        // 
        // label_poseIndex
        // 
        label_poseIndex.AutoSize = true;
        label_poseIndex.Font = new Font("Victor Mono", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
        label_poseIndex.Location = new Point(31, 48);
        label_poseIndex.Name = "label_poseIndex";
        label_poseIndex.Size = new Size(42, 16);
        label_poseIndex.TabIndex = 33;
        label_poseIndex.Text = "Index";
        // 
        // label_poseSuffix
        // 
        label_poseSuffix.AutoSize = true;
        label_poseSuffix.Font = new Font("Victor Mono", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
        label_poseSuffix.Location = new Point(24, 22);
        label_poseSuffix.Name = "label_poseSuffix";
        label_poseSuffix.Size = new Size(49, 16);
        label_poseSuffix.TabIndex = 32;
        label_poseSuffix.Text = "Suffix";
        // 
        // textBox_poseSuffix
        // 
        textBox_poseSuffix.Font = new Font("Victor Mono", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
        textBox_poseSuffix.Location = new Point(79, 17);
        textBox_poseSuffix.Name = "textBox_poseSuffix";
        textBox_poseSuffix.Size = new Size(97, 26);
        textBox_poseSuffix.TabIndex = 32;
        // 
        // textBox_skillExtend
        // 
        textBox_skillExtend.Font = new Font("Victor Mono", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
        textBox_skillExtend.Location = new Point(43, 16);
        textBox_skillExtend.Name = "textBox_skillExtend";
        textBox_skillExtend.Size = new Size(328, 23);
        textBox_skillExtend.TabIndex = 32;
        // 
        // toolTip_skillsForm
        // 
        toolTip_skillsForm.Tag = "";
        toolTip_skillsForm.ToolTipIcon = ToolTipIcon.Info;
        toolTip_skillsForm.ToolTipTitle = "Details";
        // 
        // tabControl_skills
        // 
        tabControl_skills.Controls.Add(tabPage_jabs);
        tabControl_skills.Controls.Add(tabPage_skillExtend);
        tabControl_skills.Font = new Font("Victor Mono", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
        tabControl_skills.Location = new Point(210, 38);
        tabControl_skills.Name = "tabControl_skills";
        tabControl_skills.SelectedIndex = 0;
        tabControl_skills.Size = new Size(607, 446);
        tabControl_skills.TabIndex = 34;
        // 
        // tabPage_jabs
        // 
        tabPage_jabs.Controls.Add(groupBox_poseData);
        tabPage_jabs.Controls.Add(groupBox_targetingData);
        tabPage_jabs.Controls.Add(groupBox_usageData);
        tabPage_jabs.Controls.Add(groupBox_mapData);
        tabPage_jabs.Controls.Add(groupBox_piercingData);
        tabPage_jabs.Controls.Add(groupBox_combo);
        tabPage_jabs.Location = new Point(4, 25);
        tabPage_jabs.Name = "tabPage_jabs";
        tabPage_jabs.Padding = new Padding(3);
        tabPage_jabs.Size = new Size(599, 417);
        tabPage_jabs.TabIndex = 0;
        tabPage_jabs.Text = "JABS";
        tabPage_jabs.UseVisualStyleBackColor = true;
        // 
        // tabPage_skillExtend
        // 
        tabPage_skillExtend.Controls.Add(groupBox_skillExtends);
        tabPage_skillExtend.Location = new Point(4, 25);
        tabPage_skillExtend.Name = "tabPage_skillExtend";
        tabPage_skillExtend.Padding = new Padding(3);
        tabPage_skillExtend.Size = new Size(599, 417);
        tabPage_skillExtend.TabIndex = 1;
        tabPage_skillExtend.Text = "Extend";
        tabPage_skillExtend.UseVisualStyleBackColor = true;
        // 
        // groupBox_skillExtends
        // 
        groupBox_skillExtends.Controls.Add(label_skillExtend);
        groupBox_skillExtends.Controls.Add(textBox_skillExtend);
        groupBox_skillExtends.Location = new Point(6, 6);
        groupBox_skillExtends.Name = "groupBox_skillExtends";
        groupBox_skillExtends.Size = new Size(384, 49);
        groupBox_skillExtends.TabIndex = 0;
        groupBox_skillExtends.TabStop = false;
        groupBox_skillExtends.Text = "Skills Extended";
        // 
        // label_skillExtend
        // 
        label_skillExtend.AutoSize = true;
        label_skillExtend.Font = new Font("Victor Mono", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
        label_skillExtend.Location = new Point(6, 19);
        label_skillExtend.Name = "label_skillExtend";
        label_skillExtend.Size = new Size(35, 16);
        label_skillExtend.TabIndex = 33;
        label_skillExtend.Text = "Ids:";
        // 
        // SkillsBoard
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(930, 511);
        Controls.Add(tabControl_skills);
        Controls.Add(label_skillIdValue);
        Controls.Add(label_skillId);
        Controls.Add(label_skillName);
        Controls.Add(textBox_skillName);
        Controls.Add(listboxSkills);
        Name = "SkillsBoard";
        Text = "Skill Data";
        ((ISupportInitialize)num_radius).EndInit();
        ((ISupportInitialize)num_proximity).EndInit();
        ((ISupportInitialize)num_cooldown).EndInit();
        ((ISupportInitialize)num_actionId).EndInit();
        ((ISupportInitialize)num_castAnimation).EndInit();
        ((ISupportInitialize)num_duration).EndInit();
        groupBox_combo.ResumeLayout(false);
        groupBox_combo.PerformLayout();
        ((ISupportInitialize)num_comboDelay).EndInit();
        ((ISupportInitialize)num_comboSkill).EndInit();
        groupBox_mapData.ResumeLayout(false);
        groupBox_mapData.PerformLayout();
        groupBox_targetingData.ResumeLayout(false);
        groupBox_targetingData.PerformLayout();
        groupBox_piercingData.ResumeLayout(false);
        groupBox_piercingData.PerformLayout();
        ((ISupportInitialize)num_piercingDelay).EndInit();
        ((ISupportInitialize)num_piercingCount).EndInit();
        groupBox_usageData.ResumeLayout(false);
        groupBox_usageData.PerformLayout();
        ((ISupportInitialize)num_castTime).EndInit();
        groupBox_poseData.ResumeLayout(false);
        groupBox_poseData.PerformLayout();
        ((ISupportInitialize)num_poseDuration).EndInit();
        ((ISupportInitialize)num_poseIndex).EndInit();
        tabControl_skills.ResumeLayout(false);
        tabPage_jabs.ResumeLayout(false);
        tabPage_skillExtend.ResumeLayout(false);
        groupBox_skillExtends.ResumeLayout(false);
        groupBox_skillExtends.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
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
    private CheckBox checkBox_comboStarter;
    private ToolTip toolTip_skillsForm;
    private CheckBox checkBox_aiSkillExclude;
    private TabControl tabControl_skills;
    private TabPage tabPage_jabs;
    private TabPage tabPage_skillExtend;
    private GroupBox groupBox_skillExtends;
    private Label label_skillExtend;
    private CheckBox checkBox_canGapClose;
    private NumericUpDown num_castTime;
    private Label label_castTime;
    private CheckBox checkBox_direct;
}
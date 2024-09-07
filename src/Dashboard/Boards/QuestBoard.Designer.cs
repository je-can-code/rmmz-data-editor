using System.ComponentModel;

namespace JMZ.Dashboard.Boards;

partial class QuestBoard
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

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
        tabControl1 = new TabControl();
        tabQuest = new TabPage();
        groupBoxFulfillmentData = new GroupBox();
        labelObjectiveType = new Label();
        labelObjectiveQuestKeys = new Label();
        comboBoxObjectiveType = new ComboBox();
        textBoxObjectiveQuestData = new TextBox();
        groupBoxFetchData = new GroupBox();
        labelFetchAmount = new Label();
        numFetchAmount = new NumericUpDown();
        labelFetchId = new Label();
        numFetchId = new NumericUpDown();
        comboBoxFetchType = new ComboBox();
        labelFetchType = new Label();
        groupBoxDestinationData = new GroupBox();
        labelDestinationY2 = new Label();
        numDestinationY2 = new NumericUpDown();
        labelDestinationX2 = new Label();
        numDestinationX2 = new NumericUpDown();
        labelDestinationY1 = new Label();
        numDestinationY1 = new NumericUpDown();
        labelDestinationX1 = new Label();
        numDestinationX1 = new NumericUpDown();
        labelDestinationMapId = new Label();
        numDestinationMapId = new NumericUpDown();
        groupBoxSlayData = new GroupBox();
        labelSlayEnemyId = new Label();
        labelSlayAmount = new Label();
        numSlayEnemyId = new NumericUpDown();
        numSlayAmount = new NumericUpDown();
        buttonDeleteQuest = new Button();
        buttonAddQuest = new Button();
        listBoxQuests = new ListBox();
        groupBoxObjectiveData = new GroupBox();
        groupBoxObjectiveLogs = new GroupBox();
        labelLogMissed = new Label();
        textBoxLogMissed = new TextBox();
        labelLogFailed = new Label();
        textBoxLogFailed = new TextBox();
        labelLogCompleted = new Label();
        textBoxLogCompleted = new TextBox();
        labelLogActive = new Label();
        textBoxLogActive = new TextBox();
        labelLogInactive = new Label();
        textBoxLogInactive = new TextBox();
        buttonDeleteObjective = new Button();
        buttonAddObjective = new Button();
        groupBoxIndiscriminateData = new GroupBox();
        textBoxIndiscriminateData = new TextBox();
        labelObjectiveId = new Label();
        numObjectiveId = new NumericUpDown();
        labelObjectiveDescription = new Label();
        textBoxObjectiveDescription = new TextBox();
        listBoxObjectives = new ListBox();
        checkBoxHiddenByDefault = new CheckBox();
        checkBoxIsOptional = new CheckBox();
        groupBoxCoreData = new GroupBox();
        labelRecommendedLevel = new Label();
        numRecommendedLevel = new NumericUpDown();
        textBoxOverview = new TextBox();
        labelCategory = new Label();
        listBoxTags = new ListBox();
        comboBoxCategory = new ComboBox();
        labelTags = new Label();
        labelIconIndex = new Label();
        numIconIndex = new NumericUpDown();
        labelUnknownHint = new Label();
        labelOverview = new Label();
        textBoxUnknownHint = new TextBox();
        labelName = new Label();
        textBoxKey = new TextBox();
        textBoxName = new TextBox();
        labelKey = new Label();
        tabCategories = new TabPage();
        tabTags = new TabPage();
        tabControl1.SuspendLayout();
        tabQuest.SuspendLayout();
        groupBoxFulfillmentData.SuspendLayout();
        groupBoxFetchData.SuspendLayout();
        ((ISupportInitialize)numFetchAmount).BeginInit();
        ((ISupportInitialize)numFetchId).BeginInit();
        groupBoxDestinationData.SuspendLayout();
        ((ISupportInitialize)numDestinationY2).BeginInit();
        ((ISupportInitialize)numDestinationX2).BeginInit();
        ((ISupportInitialize)numDestinationY1).BeginInit();
        ((ISupportInitialize)numDestinationX1).BeginInit();
        ((ISupportInitialize)numDestinationMapId).BeginInit();
        groupBoxSlayData.SuspendLayout();
        ((ISupportInitialize)numSlayEnemyId).BeginInit();
        ((ISupportInitialize)numSlayAmount).BeginInit();
        groupBoxObjectiveData.SuspendLayout();
        groupBoxObjectiveLogs.SuspendLayout();
        groupBoxIndiscriminateData.SuspendLayout();
        ((ISupportInitialize)numObjectiveId).BeginInit();
        groupBoxCoreData.SuspendLayout();
        ((ISupportInitialize)numRecommendedLevel).BeginInit();
        ((ISupportInitialize)numIconIndex).BeginInit();
        SuspendLayout();
        // 
        // tabControl1
        // 
        tabControl1.Controls.Add(tabQuest);
        tabControl1.Controls.Add(tabCategories);
        tabControl1.Controls.Add(tabTags);
        tabControl1.Font = new Font("Victor Mono", 7.874999F, FontStyle.Regular, GraphicsUnit.Point, 0);
        tabControl1.Location = new Point(0, 0);
        tabControl1.Name = "tabControl1";
        tabControl1.SelectedIndex = 0;
        tabControl1.Size = new Size(2358, 1314);
        tabControl1.TabIndex = 0;
        // 
        // tabQuest
        // 
        tabQuest.Controls.Add(groupBoxFulfillmentData);
        tabQuest.Controls.Add(buttonDeleteQuest);
        tabQuest.Controls.Add(buttonAddQuest);
        tabQuest.Controls.Add(listBoxQuests);
        tabQuest.Controls.Add(groupBoxObjectiveData);
        tabQuest.Controls.Add(groupBoxCoreData);
        tabQuest.Location = new Point(8, 40);
        tabQuest.Name = "tabQuest";
        tabQuest.Padding = new Padding(3);
        tabQuest.Size = new Size(2342, 1266);
        tabQuest.TabIndex = 1;
        tabQuest.Text = "Quests";
        tabQuest.UseVisualStyleBackColor = true;
        // 
        // groupBoxFulfillmentData
        // 
        groupBoxFulfillmentData.Controls.Add(labelObjectiveType);
        groupBoxFulfillmentData.Controls.Add(labelObjectiveQuestKeys);
        groupBoxFulfillmentData.Controls.Add(comboBoxObjectiveType);
        groupBoxFulfillmentData.Controls.Add(textBoxObjectiveQuestData);
        groupBoxFulfillmentData.Controls.Add(groupBoxFetchData);
        groupBoxFulfillmentData.Controls.Add(groupBoxDestinationData);
        groupBoxFulfillmentData.Controls.Add(groupBoxSlayData);
        groupBoxFulfillmentData.Location = new Point(1629, 660);
        groupBoxFulfillmentData.Name = "groupBoxFulfillmentData";
        groupBoxFulfillmentData.Size = new Size(697, 582);
        groupBoxFulfillmentData.TabIndex = 69;
        groupBoxFulfillmentData.TabStop = false;
        groupBoxFulfillmentData.Text = "Fulfillment Data";
        // 
        // labelObjectiveType
        // 
        labelObjectiveType.AutoSize = true;
        labelObjectiveType.Font = new Font("Victor Mono", 7.874999F);
        labelObjectiveType.Location = new Point(6, 33);
        labelObjectiveType.Name = "labelObjectiveType";
        labelObjectiveType.Size = new Size(56, 26);
        labelObjectiveType.TabIndex = 22;
        labelObjectiveType.Text = "Type";
        // 
        // labelObjectiveQuestKeys
        // 
        labelObjectiveQuestKeys.AutoSize = true;
        labelObjectiveQuestKeys.Font = new Font("Victor Mono", 7.874999F);
        labelObjectiveQuestKeys.Location = new Point(19, 291);
        labelObjectiveQuestKeys.Name = "labelObjectiveQuestKeys";
        labelObjectiveQuestKeys.Size = new Size(122, 26);
        labelObjectiveQuestKeys.TabIndex = 69;
        labelObjectiveQuestKeys.Text = "Quest Keys";
        // 
        // comboBoxObjectiveType
        // 
        comboBoxObjectiveType.Font = new Font("Victor Mono", 7.874999F);
        comboBoxObjectiveType.FormattingEnabled = true;
        comboBoxObjectiveType.Location = new Point(6, 62);
        comboBoxObjectiveType.Name = "comboBoxObjectiveType";
        comboBoxObjectiveType.Size = new Size(147, 34);
        comboBoxObjectiveType.TabIndex = 21;
        // 
        // textBoxObjectiveQuestData
        // 
        textBoxObjectiveQuestData.Font = new Font("Victor Mono", 7.874999F);
        textBoxObjectiveQuestData.Location = new Point(6, 319);
        textBoxObjectiveQuestData.Multiline = true;
        textBoxObjectiveQuestData.Name = "textBoxObjectiveQuestData";
        textBoxObjectiveQuestData.Size = new Size(408, 244);
        textBoxObjectiveQuestData.TabIndex = 68;
        // 
        // groupBoxFetchData
        // 
        groupBoxFetchData.Controls.Add(labelFetchAmount);
        groupBoxFetchData.Controls.Add(numFetchAmount);
        groupBoxFetchData.Controls.Add(labelFetchId);
        groupBoxFetchData.Controls.Add(numFetchId);
        groupBoxFetchData.Controls.Add(comboBoxFetchType);
        groupBoxFetchData.Controls.Add(labelFetchType);
        groupBoxFetchData.Location = new Point(174, 36);
        groupBoxFetchData.Name = "groupBoxFetchData";
        groupBoxFetchData.Size = new Size(240, 242);
        groupBoxFetchData.TabIndex = 33;
        groupBoxFetchData.TabStop = false;
        groupBoxFetchData.Text = "Fetch Data";
        // 
        // labelFetchAmount
        // 
        labelFetchAmount.AutoSize = true;
        labelFetchAmount.Font = new Font("Victor Mono", 7.874999F);
        labelFetchAmount.Location = new Point(12, 188);
        labelFetchAmount.Name = "labelFetchAmount";
        labelFetchAmount.Size = new Size(78, 26);
        labelFetchAmount.TabIndex = 36;
        labelFetchAmount.Text = "Amount";
        // 
        // numFetchAmount
        // 
        numFetchAmount.Font = new Font("Victor Mono", 7.874999F);
        numFetchAmount.Location = new Point(96, 186);
        numFetchAmount.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
        numFetchAmount.Name = "numFetchAmount";
        numFetchAmount.Size = new Size(124, 37);
        numFetchAmount.TabIndex = 35;
        numFetchAmount.TextAlign = HorizontalAlignment.Center;
        // 
        // labelFetchId
        // 
        labelFetchId.AutoSize = true;
        labelFetchId.Font = new Font("Victor Mono", 7.874999F);
        labelFetchId.Location = new Point(56, 124);
        labelFetchId.Name = "labelFetchId";
        labelFetchId.Size = new Size(34, 26);
        labelFetchId.TabIndex = 34;
        labelFetchId.Text = "Id";
        // 
        // numFetchId
        // 
        numFetchId.Font = new Font("Victor Mono", 7.874999F);
        numFetchId.Location = new Point(96, 122);
        numFetchId.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
        numFetchId.Name = "numFetchId";
        numFetchId.Size = new Size(124, 37);
        numFetchId.TabIndex = 33;
        numFetchId.TextAlign = HorizontalAlignment.Center;
        // 
        // comboBoxFetchType
        // 
        comboBoxFetchType.FormattingEnabled = true;
        comboBoxFetchType.Location = new Point(6, 59);
        comboBoxFetchType.Name = "comboBoxFetchType";
        comboBoxFetchType.Size = new Size(224, 34);
        comboBoxFetchType.TabIndex = 1;
        // 
        // labelFetchType
        // 
        labelFetchType.AutoSize = true;
        labelFetchType.Location = new Point(6, 30);
        labelFetchType.Name = "labelFetchType";
        labelFetchType.Size = new Size(122, 26);
        labelFetchType.TabIndex = 0;
        labelFetchType.Text = "Fetch Type";
        // 
        // groupBoxDestinationData
        // 
        groupBoxDestinationData.Controls.Add(labelDestinationY2);
        groupBoxDestinationData.Controls.Add(numDestinationY2);
        groupBoxDestinationData.Controls.Add(labelDestinationX2);
        groupBoxDestinationData.Controls.Add(numDestinationX2);
        groupBoxDestinationData.Controls.Add(labelDestinationY1);
        groupBoxDestinationData.Controls.Add(numDestinationY1);
        groupBoxDestinationData.Controls.Add(labelDestinationX1);
        groupBoxDestinationData.Controls.Add(numDestinationX1);
        groupBoxDestinationData.Controls.Add(labelDestinationMapId);
        groupBoxDestinationData.Controls.Add(numDestinationMapId);
        groupBoxDestinationData.Location = new Point(420, 199);
        groupBoxDestinationData.Name = "groupBoxDestinationData";
        groupBoxDestinationData.Size = new Size(260, 317);
        groupBoxDestinationData.TabIndex = 1;
        groupBoxDestinationData.TabStop = false;
        groupBoxDestinationData.Text = "Destination Data";
        // 
        // labelDestinationY2
        // 
        labelDestinationY2.AutoSize = true;
        labelDestinationY2.Font = new Font("Victor Mono", 7.874999F);
        labelDestinationY2.Location = new Point(65, 266);
        labelDestinationY2.Name = "labelDestinationY2";
        labelDestinationY2.Size = new Size(34, 26);
        labelDestinationY2.TabIndex = 36;
        labelDestinationY2.Text = "Y2";
        // 
        // numDestinationY2
        // 
        numDestinationY2.Font = new Font("Victor Mono", 7.874999F);
        numDestinationY2.Location = new Point(105, 264);
        numDestinationY2.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
        numDestinationY2.Minimum = new decimal(new int[] { 1, 0, 0, int.MinValue });
        numDestinationY2.Name = "numDestinationY2";
        numDestinationY2.Size = new Size(124, 37);
        numDestinationY2.TabIndex = 35;
        numDestinationY2.TextAlign = HorizontalAlignment.Center;
        // 
        // labelDestinationX2
        // 
        labelDestinationX2.AutoSize = true;
        labelDestinationX2.Font = new Font("Victor Mono", 7.874999F);
        labelDestinationX2.Location = new Point(65, 223);
        labelDestinationX2.Name = "labelDestinationX2";
        labelDestinationX2.Size = new Size(34, 26);
        labelDestinationX2.TabIndex = 34;
        labelDestinationX2.Text = "X2";
        // 
        // numDestinationX2
        // 
        numDestinationX2.Font = new Font("Victor Mono", 7.874999F);
        numDestinationX2.Location = new Point(105, 221);
        numDestinationX2.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
        numDestinationX2.Minimum = new decimal(new int[] { 1, 0, 0, int.MinValue });
        numDestinationX2.Name = "numDestinationX2";
        numDestinationX2.Size = new Size(124, 37);
        numDestinationX2.TabIndex = 33;
        numDestinationX2.TextAlign = HorizontalAlignment.Center;
        // 
        // labelDestinationY1
        // 
        labelDestinationY1.AutoSize = true;
        labelDestinationY1.Font = new Font("Victor Mono", 7.874999F);
        labelDestinationY1.Location = new Point(65, 155);
        labelDestinationY1.Name = "labelDestinationY1";
        labelDestinationY1.Size = new Size(34, 26);
        labelDestinationY1.TabIndex = 32;
        labelDestinationY1.Text = "Y1";
        // 
        // numDestinationY1
        // 
        numDestinationY1.Font = new Font("Victor Mono", 7.874999F);
        numDestinationY1.Location = new Point(105, 153);
        numDestinationY1.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
        numDestinationY1.Minimum = new decimal(new int[] { 1, 0, 0, int.MinValue });
        numDestinationY1.Name = "numDestinationY1";
        numDestinationY1.Size = new Size(124, 37);
        numDestinationY1.TabIndex = 31;
        numDestinationY1.TextAlign = HorizontalAlignment.Center;
        // 
        // labelDestinationX1
        // 
        labelDestinationX1.AutoSize = true;
        labelDestinationX1.Font = new Font("Victor Mono", 7.874999F);
        labelDestinationX1.Location = new Point(65, 112);
        labelDestinationX1.Name = "labelDestinationX1";
        labelDestinationX1.Size = new Size(34, 26);
        labelDestinationX1.TabIndex = 30;
        labelDestinationX1.Text = "X1";
        // 
        // numDestinationX1
        // 
        numDestinationX1.Font = new Font("Victor Mono", 7.874999F);
        numDestinationX1.Location = new Point(105, 110);
        numDestinationX1.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
        numDestinationX1.Minimum = new decimal(new int[] { 1, 0, 0, int.MinValue });
        numDestinationX1.Name = "numDestinationX1";
        numDestinationX1.Size = new Size(124, 37);
        numDestinationX1.TabIndex = 29;
        numDestinationX1.TextAlign = HorizontalAlignment.Center;
        // 
        // labelDestinationMapId
        // 
        labelDestinationMapId.AutoSize = true;
        labelDestinationMapId.Font = new Font("Victor Mono", 7.874999F);
        labelDestinationMapId.Location = new Point(21, 37);
        labelDestinationMapId.Name = "labelDestinationMapId";
        labelDestinationMapId.Size = new Size(78, 26);
        labelDestinationMapId.TabIndex = 28;
        labelDestinationMapId.Text = "Map Id";
        // 
        // numDestinationMapId
        // 
        numDestinationMapId.Font = new Font("Victor Mono", 7.874999F);
        numDestinationMapId.Location = new Point(105, 35);
        numDestinationMapId.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
        numDestinationMapId.Minimum = new decimal(new int[] { 1, 0, 0, int.MinValue });
        numDestinationMapId.Name = "numDestinationMapId";
        numDestinationMapId.Size = new Size(124, 37);
        numDestinationMapId.TabIndex = 27;
        numDestinationMapId.TextAlign = HorizontalAlignment.Center;
        // 
        // groupBoxSlayData
        // 
        groupBoxSlayData.Controls.Add(labelSlayEnemyId);
        groupBoxSlayData.Controls.Add(labelSlayAmount);
        groupBoxSlayData.Controls.Add(numSlayEnemyId);
        groupBoxSlayData.Controls.Add(numSlayAmount);
        groupBoxSlayData.Location = new Point(420, 36);
        groupBoxSlayData.Name = "groupBoxSlayData";
        groupBoxSlayData.Size = new Size(260, 157);
        groupBoxSlayData.TabIndex = 38;
        groupBoxSlayData.TabStop = false;
        groupBoxSlayData.Text = "Slay Data";
        // 
        // labelSlayEnemyId
        // 
        labelSlayEnemyId.AutoSize = true;
        labelSlayEnemyId.Font = new Font("Victor Mono", 7.874999F);
        labelSlayEnemyId.Location = new Point(19, 52);
        labelSlayEnemyId.Name = "labelSlayEnemyId";
        labelSlayEnemyId.Size = new Size(100, 26);
        labelSlayEnemyId.TabIndex = 32;
        labelSlayEnemyId.Text = "Enemy Id";
        // 
        // labelSlayAmount
        // 
        labelSlayAmount.AutoSize = true;
        labelSlayAmount.Font = new Font("Victor Mono", 7.874999F);
        labelSlayAmount.Location = new Point(41, 112);
        labelSlayAmount.Name = "labelSlayAmount";
        labelSlayAmount.Size = new Size(78, 26);
        labelSlayAmount.TabIndex = 32;
        labelSlayAmount.Text = "Amount";
        // 
        // numSlayEnemyId
        // 
        numSlayEnemyId.Font = new Font("Victor Mono", 7.874999F);
        numSlayEnemyId.Location = new Point(125, 50);
        numSlayEnemyId.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
        numSlayEnemyId.Minimum = new decimal(new int[] { 1, 0, 0, int.MinValue });
        numSlayEnemyId.Name = "numSlayEnemyId";
        numSlayEnemyId.Size = new Size(124, 37);
        numSlayEnemyId.TabIndex = 31;
        numSlayEnemyId.TextAlign = HorizontalAlignment.Center;
        // 
        // numSlayAmount
        // 
        numSlayAmount.Font = new Font("Victor Mono", 7.874999F);
        numSlayAmount.Location = new Point(125, 106);
        numSlayAmount.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
        numSlayAmount.Minimum = new decimal(new int[] { 1, 0, 0, int.MinValue });
        numSlayAmount.Name = "numSlayAmount";
        numSlayAmount.Size = new Size(124, 37);
        numSlayAmount.TabIndex = 31;
        numSlayAmount.TextAlign = HorizontalAlignment.Center;
        // 
        // buttonDeleteQuest
        // 
        buttonDeleteQuest.Font = new Font("Cascadia Code", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
        buttonDeleteQuest.ForeColor = Color.Red;
        buttonDeleteQuest.Location = new Point(9, 1165);
        buttonDeleteQuest.Margin = new Padding(6);
        buttonDeleteQuest.Name = "buttonDeleteQuest";
        buttonDeleteQuest.Size = new Size(172, 92);
        buttonDeleteQuest.TabIndex = 68;
        buttonDeleteQuest.Text = "❌";
        buttonDeleteQuest.UseVisualStyleBackColor = true;
        // 
        // buttonAddQuest
        // 
        buttonAddQuest.Font = new Font("Cascadia Code", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
        buttonAddQuest.ForeColor = Color.Green;
        buttonAddQuest.Location = new Point(316, 1163);
        buttonAddQuest.Margin = new Padding(6);
        buttonAddQuest.Name = "buttonAddQuest";
        buttonAddQuest.Size = new Size(166, 97);
        buttonAddQuest.TabIndex = 67;
        buttonAddQuest.Text = "✨";
        buttonAddQuest.UseVisualStyleBackColor = true;
        // 
        // listBoxQuests
        // 
        listBoxQuests.Font = new Font("Victor Mono", 7.874999F);
        listBoxQuests.FormattingEnabled = true;
        listBoxQuests.ItemHeight = 26;
        listBoxQuests.Location = new Point(6, 6);
        listBoxQuests.Name = "listBoxQuests";
        listBoxQuests.Size = new Size(476, 1148);
        listBoxQuests.TabIndex = 13;
        // 
        // groupBoxObjectiveData
        // 
        groupBoxObjectiveData.Controls.Add(groupBoxObjectiveLogs);
        groupBoxObjectiveData.Controls.Add(buttonDeleteObjective);
        groupBoxObjectiveData.Controls.Add(buttonAddObjective);
        groupBoxObjectiveData.Controls.Add(groupBoxIndiscriminateData);
        groupBoxObjectiveData.Controls.Add(labelObjectiveId);
        groupBoxObjectiveData.Controls.Add(numObjectiveId);
        groupBoxObjectiveData.Controls.Add(labelObjectiveDescription);
        groupBoxObjectiveData.Controls.Add(textBoxObjectiveDescription);
        groupBoxObjectiveData.Controls.Add(listBoxObjectives);
        groupBoxObjectiveData.Controls.Add(checkBoxHiddenByDefault);
        groupBoxObjectiveData.Controls.Add(checkBoxIsOptional);
        groupBoxObjectiveData.Font = new Font("Victor Mono", 7.874999F);
        groupBoxObjectiveData.Location = new Point(488, 15);
        groupBoxObjectiveData.Name = "groupBoxObjectiveData";
        groupBoxObjectiveData.Size = new Size(1838, 624);
        groupBoxObjectiveData.TabIndex = 19;
        groupBoxObjectiveData.TabStop = false;
        groupBoxObjectiveData.Text = "Objective Data";
        // 
        // groupBoxObjectiveLogs
        // 
        groupBoxObjectiveLogs.Controls.Add(labelLogMissed);
        groupBoxObjectiveLogs.Controls.Add(textBoxLogMissed);
        groupBoxObjectiveLogs.Controls.Add(labelLogFailed);
        groupBoxObjectiveLogs.Controls.Add(textBoxLogFailed);
        groupBoxObjectiveLogs.Controls.Add(labelLogCompleted);
        groupBoxObjectiveLogs.Controls.Add(textBoxLogCompleted);
        groupBoxObjectiveLogs.Controls.Add(labelLogActive);
        groupBoxObjectiveLogs.Controls.Add(textBoxLogActive);
        groupBoxObjectiveLogs.Controls.Add(labelLogInactive);
        groupBoxObjectiveLogs.Controls.Add(textBoxLogInactive);
        groupBoxObjectiveLogs.Location = new Point(84, 206);
        groupBoxObjectiveLogs.Name = "groupBoxObjectiveLogs";
        groupBoxObjectiveLogs.Size = new Size(1748, 318);
        groupBoxObjectiveLogs.TabIndex = 70;
        groupBoxObjectiveLogs.TabStop = false;
        groupBoxObjectiveLogs.Text = "Logs";
        // 
        // labelLogMissed
        // 
        labelLogMissed.AutoSize = true;
        labelLogMissed.Location = new Point(49, 260);
        labelLogMissed.Name = "labelLogMissed";
        labelLogMissed.Size = new Size(78, 26);
        labelLogMissed.TabIndex = 17;
        labelLogMissed.Text = "Missed";
        // 
        // textBoxLogMissed
        // 
        textBoxLogMissed.Font = new Font("Victor Mono", 7.874999F);
        textBoxLogMissed.Location = new Point(133, 257);
        textBoxLogMissed.Name = "textBoxLogMissed";
        textBoxLogMissed.Size = new Size(1604, 37);
        textBoxLogMissed.TabIndex = 16;
        // 
        // labelLogFailed
        // 
        labelLogFailed.AutoSize = true;
        labelLogFailed.Location = new Point(49, 197);
        labelLogFailed.Name = "labelLogFailed";
        labelLogFailed.Size = new Size(78, 26);
        labelLogFailed.TabIndex = 15;
        labelLogFailed.Text = "Failed";
        // 
        // textBoxLogFailed
        // 
        textBoxLogFailed.Font = new Font("Victor Mono", 7.874999F);
        textBoxLogFailed.Location = new Point(133, 194);
        textBoxLogFailed.Name = "textBoxLogFailed";
        textBoxLogFailed.Size = new Size(1604, 37);
        textBoxLogFailed.TabIndex = 14;
        // 
        // labelLogCompleted
        // 
        labelLogCompleted.AutoSize = true;
        labelLogCompleted.Location = new Point(16, 139);
        labelLogCompleted.Name = "labelLogCompleted";
        labelLogCompleted.Size = new Size(111, 26);
        labelLogCompleted.TabIndex = 13;
        labelLogCompleted.Text = "Completed";
        // 
        // textBoxLogCompleted
        // 
        textBoxLogCompleted.Font = new Font("Victor Mono", 7.874999F);
        textBoxLogCompleted.Location = new Point(133, 136);
        textBoxLogCompleted.Name = "textBoxLogCompleted";
        textBoxLogCompleted.Size = new Size(1604, 37);
        textBoxLogCompleted.TabIndex = 12;
        // 
        // labelLogActive
        // 
        labelLogActive.AutoSize = true;
        labelLogActive.Location = new Point(49, 85);
        labelLogActive.Name = "labelLogActive";
        labelLogActive.Size = new Size(78, 26);
        labelLogActive.TabIndex = 11;
        labelLogActive.Text = "Active";
        // 
        // textBoxLogActive
        // 
        textBoxLogActive.Font = new Font("Victor Mono", 7.874999F);
        textBoxLogActive.Location = new Point(133, 82);
        textBoxLogActive.Name = "textBoxLogActive";
        textBoxLogActive.Size = new Size(1604, 37);
        textBoxLogActive.TabIndex = 10;
        // 
        // labelLogInactive
        // 
        labelLogInactive.AutoSize = true;
        labelLogInactive.Location = new Point(27, 37);
        labelLogInactive.Name = "labelLogInactive";
        labelLogInactive.Size = new Size(100, 26);
        labelLogInactive.TabIndex = 9;
        labelLogInactive.Text = "Inactive";
        // 
        // textBoxLogInactive
        // 
        textBoxLogInactive.Font = new Font("Victor Mono", 7.874999F);
        textBoxLogInactive.Location = new Point(133, 26);
        textBoxLogInactive.Name = "textBoxLogInactive";
        textBoxLogInactive.Size = new Size(1604, 37);
        textBoxLogInactive.TabIndex = 8;
        // 
        // buttonDeleteObjective
        // 
        buttonDeleteObjective.Font = new Font("Cascadia Code", 8.25F);
        buttonDeleteObjective.ForeColor = Color.Red;
        buttonDeleteObjective.Location = new Point(9, 463);
        buttonDeleteObjective.Margin = new Padding(6);
        buttonDeleteObjective.Name = "buttonDeleteObjective";
        buttonDeleteObjective.Size = new Size(70, 62);
        buttonDeleteObjective.TabIndex = 67;
        buttonDeleteObjective.Text = "❌";
        buttonDeleteObjective.UseVisualStyleBackColor = true;
        // 
        // buttonAddObjective
        // 
        buttonAddObjective.Font = new Font("Cascadia Code", 8.25F);
        buttonAddObjective.ForeColor = Color.Green;
        buttonAddObjective.Location = new Point(9, 389);
        buttonAddObjective.Margin = new Padding(6);
        buttonAddObjective.Name = "buttonAddObjective";
        buttonAddObjective.Size = new Size(70, 62);
        buttonAddObjective.TabIndex = 66;
        buttonAddObjective.Text = "✨";
        buttonAddObjective.UseVisualStyleBackColor = true;
        // 
        // groupBoxIndiscriminateData
        // 
        groupBoxIndiscriminateData.Controls.Add(textBoxIndiscriminateData);
        groupBoxIndiscriminateData.Location = new Point(9, 530);
        groupBoxIndiscriminateData.Name = "groupBoxIndiscriminateData";
        groupBoxIndiscriminateData.Size = new Size(1823, 92);
        groupBoxIndiscriminateData.TabIndex = 37;
        groupBoxIndiscriminateData.TabStop = false;
        groupBoxIndiscriminateData.Text = "Indiscriminate Data";
        // 
        // textBoxIndiscriminateData
        // 
        textBoxIndiscriminateData.Font = new Font("Victor Mono", 7.874999F);
        textBoxIndiscriminateData.Location = new Point(18, 36);
        textBoxIndiscriminateData.Name = "textBoxIndiscriminateData";
        textBoxIndiscriminateData.Size = new Size(1794, 37);
        textBoxIndiscriminateData.TabIndex = 25;
        // 
        // labelObjectiveId
        // 
        labelObjectiveId.AutoSize = true;
        labelObjectiveId.Font = new Font("Victor Mono", 7.874999F);
        labelObjectiveId.Location = new Point(85, 36);
        labelObjectiveId.Name = "labelObjectiveId";
        labelObjectiveId.Size = new Size(34, 26);
        labelObjectiveId.TabIndex = 26;
        labelObjectiveId.Text = "Id";
        // 
        // numObjectiveId
        // 
        numObjectiveId.Font = new Font("Victor Mono", 7.874999F);
        numObjectiveId.Location = new Point(85, 71);
        numObjectiveId.Name = "numObjectiveId";
        numObjectiveId.Size = new Size(124, 37);
        numObjectiveId.TabIndex = 25;
        numObjectiveId.TextAlign = HorizontalAlignment.Center;
        // 
        // labelObjectiveDescription
        // 
        labelObjectiveDescription.AutoSize = true;
        labelObjectiveDescription.Font = new Font("Victor Mono", 7.874999F);
        labelObjectiveDescription.Location = new Point(85, 120);
        labelObjectiveDescription.Name = "labelObjectiveDescription";
        labelObjectiveDescription.Size = new Size(133, 26);
        labelObjectiveDescription.TabIndex = 24;
        labelObjectiveDescription.Text = "Description";
        // 
        // textBoxObjectiveDescription
        // 
        textBoxObjectiveDescription.Font = new Font("Victor Mono", 7.874999F);
        textBoxObjectiveDescription.Location = new Point(85, 154);
        textBoxObjectiveDescription.Name = "textBoxObjectiveDescription";
        textBoxObjectiveDescription.Size = new Size(1736, 37);
        textBoxObjectiveDescription.TabIndex = 23;
        // 
        // listBoxObjectives
        // 
        listBoxObjectives.Font = new Font("Victor Mono", 7.874999F);
        listBoxObjectives.FormattingEnabled = true;
        listBoxObjectives.ItemHeight = 26;
        listBoxObjectives.Location = new Point(6, 38);
        listBoxObjectives.Name = "listBoxObjectives";
        listBoxObjectives.Size = new Size(73, 342);
        listBoxObjectives.TabIndex = 20;
        // 
        // checkBoxHiddenByDefault
        // 
        checkBoxHiddenByDefault.AutoSize = true;
        checkBoxHiddenByDefault.Checked = true;
        checkBoxHiddenByDefault.CheckState = CheckState.Checked;
        checkBoxHiddenByDefault.Font = new Font("Victor Mono", 7.874999F);
        checkBoxHiddenByDefault.Location = new Point(291, 54);
        checkBoxHiddenByDefault.Name = "checkBoxHiddenByDefault";
        checkBoxHiddenByDefault.Size = new Size(231, 30);
        checkBoxHiddenByDefault.TabIndex = 11;
        checkBoxHiddenByDefault.Text = "Hidden By Default";
        checkBoxHiddenByDefault.UseVisualStyleBackColor = true;
        // 
        // checkBoxIsOptional
        // 
        checkBoxIsOptional.AutoSize = true;
        checkBoxIsOptional.Font = new Font("Victor Mono", 7.874999F);
        checkBoxIsOptional.Location = new Point(291, 90);
        checkBoxIsOptional.Name = "checkBoxIsOptional";
        checkBoxIsOptional.Size = new Size(165, 30);
        checkBoxIsOptional.TabIndex = 12;
        checkBoxIsOptional.Text = "Is Optional";
        checkBoxIsOptional.UseVisualStyleBackColor = true;
        // 
        // groupBoxCoreData
        // 
        groupBoxCoreData.Controls.Add(labelRecommendedLevel);
        groupBoxCoreData.Controls.Add(numRecommendedLevel);
        groupBoxCoreData.Controls.Add(textBoxOverview);
        groupBoxCoreData.Controls.Add(labelCategory);
        groupBoxCoreData.Controls.Add(listBoxTags);
        groupBoxCoreData.Controls.Add(comboBoxCategory);
        groupBoxCoreData.Controls.Add(labelTags);
        groupBoxCoreData.Controls.Add(labelIconIndex);
        groupBoxCoreData.Controls.Add(numIconIndex);
        groupBoxCoreData.Controls.Add(labelUnknownHint);
        groupBoxCoreData.Controls.Add(labelOverview);
        groupBoxCoreData.Controls.Add(textBoxUnknownHint);
        groupBoxCoreData.Controls.Add(labelName);
        groupBoxCoreData.Controls.Add(textBoxKey);
        groupBoxCoreData.Controls.Add(textBoxName);
        groupBoxCoreData.Controls.Add(labelKey);
        groupBoxCoreData.Font = new Font("Victor Mono", 7.874999F);
        groupBoxCoreData.Location = new Point(494, 645);
        groupBoxCoreData.Name = "groupBoxCoreData";
        groupBoxCoreData.Size = new Size(1109, 605);
        groupBoxCoreData.TabIndex = 18;
        groupBoxCoreData.TabStop = false;
        groupBoxCoreData.Text = "Core Data";
        // 
        // labelRecommendedLevel
        // 
        labelRecommendedLevel.AutoSize = true;
        labelRecommendedLevel.Font = new Font("Victor Mono", 7.874999F);
        labelRecommendedLevel.Location = new Point(6, 163);
        labelRecommendedLevel.Name = "labelRecommendedLevel";
        labelRecommendedLevel.Size = new Size(199, 26);
        labelRecommendedLevel.TabIndex = 19;
        labelRecommendedLevel.Text = "Recommended Level";
        // 
        // numRecommendedLevel
        // 
        numRecommendedLevel.Font = new Font("Victor Mono", 7.874999F);
        numRecommendedLevel.Location = new Point(211, 164);
        numRecommendedLevel.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
        numRecommendedLevel.Minimum = new decimal(new int[] { 1, 0, 0, int.MinValue });
        numRecommendedLevel.Name = "numRecommendedLevel";
        numRecommendedLevel.Size = new Size(122, 37);
        numRecommendedLevel.TabIndex = 18;
        numRecommendedLevel.TextAlign = HorizontalAlignment.Center;
        // 
        // textBoxOverview
        // 
        textBoxOverview.Font = new Font("Victor Mono", 7.874999F);
        textBoxOverview.Location = new Point(6, 354);
        textBoxOverview.Multiline = true;
        textBoxOverview.Name = "textBoxOverview";
        textBoxOverview.Size = new Size(1082, 243);
        textBoxOverview.TabIndex = 5;
        // 
        // labelCategory
        // 
        labelCategory.AutoSize = true;
        labelCategory.Font = new Font("Victor Mono", 7.874999F);
        labelCategory.Location = new Point(277, 81);
        labelCategory.Name = "labelCategory";
        labelCategory.Size = new Size(100, 26);
        labelCategory.TabIndex = 14;
        labelCategory.Text = "Category";
        // 
        // listBoxTags
        // 
        listBoxTags.Font = new Font("Victor Mono", 7.874999F);
        listBoxTags.FormattingEnabled = true;
        listBoxTags.ItemHeight = 26;
        listBoxTags.Location = new Point(848, 62);
        listBoxTags.Name = "listBoxTags";
        listBoxTags.SelectionMode = SelectionMode.MultiExtended;
        listBoxTags.Size = new Size(240, 186);
        listBoxTags.TabIndex = 17;
        // 
        // comboBoxCategory
        // 
        comboBoxCategory.Font = new Font("Victor Mono", 7.874999F);
        comboBoxCategory.FormattingEnabled = true;
        comboBoxCategory.Location = new Point(383, 77);
        comboBoxCategory.Name = "comboBoxCategory";
        comboBoxCategory.Size = new Size(329, 34);
        comboBoxCategory.TabIndex = 13;
        // 
        // labelTags
        // 
        labelTags.AutoSize = true;
        labelTags.Font = new Font("Victor Mono", 7.874999F);
        labelTags.Location = new Point(848, 30);
        labelTags.Name = "labelTags";
        labelTags.Size = new Size(56, 26);
        labelTags.TabIndex = 16;
        labelTags.Text = "Tags";
        // 
        // labelIconIndex
        // 
        labelIconIndex.AutoSize = true;
        labelIconIndex.Font = new Font("Victor Mono", 7.874999F);
        labelIconIndex.Location = new Point(6, 81);
        labelIconIndex.Name = "labelIconIndex";
        labelIconIndex.Size = new Size(122, 26);
        labelIconIndex.TabIndex = 10;
        labelIconIndex.Text = "Icon Index";
        // 
        // numIconIndex
        // 
        numIconIndex.Font = new Font("Victor Mono", 7.874999F);
        numIconIndex.Location = new Point(134, 79);
        numIconIndex.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
        numIconIndex.Minimum = new decimal(new int[] { 1, 0, 0, int.MinValue });
        numIconIndex.Name = "numIconIndex";
        numIconIndex.Size = new Size(122, 37);
        numIconIndex.TabIndex = 9;
        numIconIndex.TextAlign = HorizontalAlignment.Center;
        // 
        // labelUnknownHint
        // 
        labelUnknownHint.AutoSize = true;
        labelUnknownHint.Font = new Font("Victor Mono", 7.874999F);
        labelUnknownHint.Location = new Point(6, 233);
        labelUnknownHint.Name = "labelUnknownHint";
        labelUnknownHint.Size = new Size(144, 26);
        labelUnknownHint.TabIndex = 8;
        labelUnknownHint.Text = "Unknown Hint";
        // 
        // labelOverview
        // 
        labelOverview.AutoSize = true;
        labelOverview.Font = new Font("Victor Mono", 7.874999F);
        labelOverview.Location = new Point(6, 319);
        labelOverview.Name = "labelOverview";
        labelOverview.Size = new Size(100, 26);
        labelOverview.TabIndex = 6;
        labelOverview.Text = "Overview";
        // 
        // textBoxUnknownHint
        // 
        textBoxUnknownHint.Font = new Font("Victor Mono", 7.874999F);
        textBoxUnknownHint.Location = new Point(6, 268);
        textBoxUnknownHint.Name = "textBoxUnknownHint";
        textBoxUnknownHint.Size = new Size(1082, 37);
        textBoxUnknownHint.TabIndex = 7;
        // 
        // labelName
        // 
        labelName.AutoSize = true;
        labelName.Font = new Font("Victor Mono", 7.874999F);
        labelName.Location = new Point(277, 30);
        labelName.Name = "labelName";
        labelName.Size = new Size(56, 26);
        labelName.TabIndex = 4;
        labelName.Text = "Name";
        // 
        // textBoxKey
        // 
        textBoxKey.Font = new Font("Victor Mono", 7.874999F);
        textBoxKey.Location = new Point(57, 30);
        textBoxKey.Name = "textBoxKey";
        textBoxKey.Size = new Size(200, 37);
        textBoxKey.TabIndex = 1;
        // 
        // textBoxName
        // 
        textBoxName.Font = new Font("Victor Mono", 7.874999F);
        textBoxName.Location = new Point(339, 27);
        textBoxName.Name = "textBoxName";
        textBoxName.Size = new Size(494, 37);
        textBoxName.TabIndex = 3;
        // 
        // labelKey
        // 
        labelKey.AutoSize = true;
        labelKey.Font = new Font("Victor Mono", 7.874999F);
        labelKey.Location = new Point(6, 30);
        labelKey.Name = "labelKey";
        labelKey.Size = new Size(45, 26);
        labelKey.TabIndex = 2;
        labelKey.Text = "Key";
        // 
        // tabCategories
        // 
        tabCategories.Location = new Point(8, 40);
        tabCategories.Name = "tabCategories";
        tabCategories.Size = new Size(2342, 1266);
        tabCategories.TabIndex = 2;
        tabCategories.Text = "Categories";
        tabCategories.UseVisualStyleBackColor = true;
        // 
        // tabTags
        // 
        tabTags.Location = new Point(8, 40);
        tabTags.Name = "tabTags";
        tabTags.Size = new Size(2342, 1266);
        tabTags.TabIndex = 3;
        tabTags.Text = "Tags";
        tabTags.UseVisualStyleBackColor = true;
        // 
        // QuestBoard
        // 
        AutoScaleDimensions = new SizeF(13F, 32F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(2367, 1320);
        Controls.Add(tabControl1);
        Name = "QuestBoard";
        Text = "QuestBoard";
        tabControl1.ResumeLayout(false);
        tabQuest.ResumeLayout(false);
        groupBoxFulfillmentData.ResumeLayout(false);
        groupBoxFulfillmentData.PerformLayout();
        groupBoxFetchData.ResumeLayout(false);
        groupBoxFetchData.PerformLayout();
        ((ISupportInitialize)numFetchAmount).EndInit();
        ((ISupportInitialize)numFetchId).EndInit();
        groupBoxDestinationData.ResumeLayout(false);
        groupBoxDestinationData.PerformLayout();
        ((ISupportInitialize)numDestinationY2).EndInit();
        ((ISupportInitialize)numDestinationX2).EndInit();
        ((ISupportInitialize)numDestinationY1).EndInit();
        ((ISupportInitialize)numDestinationX1).EndInit();
        ((ISupportInitialize)numDestinationMapId).EndInit();
        groupBoxSlayData.ResumeLayout(false);
        groupBoxSlayData.PerformLayout();
        ((ISupportInitialize)numSlayEnemyId).EndInit();
        ((ISupportInitialize)numSlayAmount).EndInit();
        groupBoxObjectiveData.ResumeLayout(false);
        groupBoxObjectiveData.PerformLayout();
        groupBoxObjectiveLogs.ResumeLayout(false);
        groupBoxObjectiveLogs.PerformLayout();
        groupBoxIndiscriminateData.ResumeLayout(false);
        groupBoxIndiscriminateData.PerformLayout();
        ((ISupportInitialize)numObjectiveId).EndInit();
        groupBoxCoreData.ResumeLayout(false);
        groupBoxCoreData.PerformLayout();
        ((ISupportInitialize)numRecommendedLevel).EndInit();
        ((ISupportInitialize)numIconIndex).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private TabControl tabControl1;
    private TabPage tabQuest;
    private TabPage tabCategories;
    private TabPage tabTags;
    private Label labelKey;
    private TextBox textBoxKey;
    private Label labelOverview;
    private TextBox textBoxOverview;
    private Label labelName;
    private TextBox textBoxName;
    private CheckBox checkBoxIsOptional;
    private CheckBox checkBoxHiddenByDefault;
    private Label labelIconIndex;
    private NumericUpDown numIconIndex;
    private Label labelUnknownHint;
    private TextBox textBoxUnknownHint;
    private Label labelCategory;
    private ComboBox comboBoxCategory;
    private Label labelTags;
    private ListBox listBoxTags;
    private GroupBox groupBoxCoreData;
    private GroupBox groupBoxObjectiveData;
    private ListBox listBoxQuests;
    private ListBox listBoxObjectives;
    private Label labelObjectiveId;
    private NumericUpDown numObjectiveId;
    private Label labelObjectiveDescription;
    private TextBox textBoxObjectiveDescription;
    private Label labelObjectiveType;
    private ComboBox comboBoxObjectiveType;
    private GroupBox groupBoxDestinationData;
    private GroupBox groupBoxIndiscriminateData;
    private Label labelLogInactive;
    private TextBox textBoxIndiscriminateData;
    private Label labelDestinationY2;
    private NumericUpDown numDestinationY2;
    private Label labelDestinationX2;
    private NumericUpDown numDestinationX2;
    private Label labelDestinationY1;
    private NumericUpDown numDestinationY1;
    private Label labelDestinationX1;
    private NumericUpDown numDestinationX1;
    private Label labelDestinationMapId;
    private NumericUpDown numDestinationMapId;
    private GroupBox groupBoxSlayData;
    private Label labelSlayEnemyId;
    private Label labelSlayAmount;
    private NumericUpDown numSlayEnemyId;
    private NumericUpDown numSlayAmount;
    private GroupBox groupBoxFetchData;
    private ComboBox comboBoxFetchType;
    private Label labelFetchType;
    private Label labelFetchAmount;
    private NumericUpDown numFetchAmount;
    private Label labelFetchId;
    private NumericUpDown numFetchId;
    private Button buttonAddObjective;
    private Button buttonDeleteQuest;
    private Button buttonAddQuest;
    private Button buttonDeleteObjective;
    private Label labelObjectiveQuestKeys;
    private TextBox textBoxObjectiveQuestData;
    private GroupBox groupBoxObjectiveLogs;
    private TextBox textBoxLogInactive;
    private Label labelLogMissed;
    private TextBox textBoxLogMissed;
    private Label labelLogFailed;
    private TextBox textBoxLogFailed;
    private Label labelLogCompleted;
    private TextBox textBoxLogCompleted;
    private Label labelLogActive;
    private TextBox textBoxLogActive;
    private GroupBox groupBoxFulfillmentData;
    private Label labelRecommendedLevel;
    private NumericUpDown numRecommendedLevel;
}
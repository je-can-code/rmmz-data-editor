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
        tabControlQuestBoard = new TabControl();
        tabQuest = new TabPage();
        labelQuests = new Label();
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
        groupBoxFulfillmentData = new GroupBox();
        groupBoxQuestData = new GroupBox();
        textBoxObjectiveQuestData = new TextBox();
        labelObjectiveQuestKeys = new Label();
        labelObjectiveType = new Label();
        comboBoxObjectiveType = new ComboBox();
        groupBoxIndiscriminateData = new GroupBox();
        textBoxIndiscriminateData = new TextBox();
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
        labelObjectiveId = new Label();
        numObjectiveId = new NumericUpDown();
        labelObjectiveDescription = new Label();
        textBoxObjectiveDescription = new TextBox();
        listBoxObjectives = new ListBox();
        checkBoxHiddenByDefault = new CheckBox();
        checkBoxIsOptional = new CheckBox();
        groupBoxCoreData = new GroupBox();
        checkedListBoxQuestTags = new CheckedListBox();
        labelRecommendedLevel = new Label();
        numRecommendedLevel = new NumericUpDown();
        textBoxOverview = new TextBox();
        labelCategory = new Label();
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
        labelCategoryIconIndex = new Label();
        numCategoryIconIndex = new NumericUpDown();
        buttonDeleteCategory = new Button();
        buttonAddCategory = new Button();
        textBoxCategoryKey = new TextBox();
        labelCategoryKey = new Label();
        textBoxCategoryName = new TextBox();
        labelCategoryName = new Label();
        labelCategories = new Label();
        listBoxCategories = new ListBox();
        tabTags = new TabPage();
        labelTagIconIndex = new Label();
        numTagIconIndex = new NumericUpDown();
        buttonDeleteTag = new Button();
        buttonAddTag = new Button();
        textBoxTagKey = new TextBox();
        labelTagKey = new Label();
        textBoxTagName = new TextBox();
        labelTagName = new Label();
        labelTagList = new Label();
        listBoxTags = new ListBox();
        tabControlQuestBoard.SuspendLayout();
        tabQuest.SuspendLayout();
        groupBoxObjectiveData.SuspendLayout();
        groupBoxObjectiveLogs.SuspendLayout();
        groupBoxFulfillmentData.SuspendLayout();
        groupBoxQuestData.SuspendLayout();
        groupBoxIndiscriminateData.SuspendLayout();
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
        ((ISupportInitialize)numObjectiveId).BeginInit();
        groupBoxCoreData.SuspendLayout();
        ((ISupportInitialize)numRecommendedLevel).BeginInit();
        ((ISupportInitialize)numIconIndex).BeginInit();
        tabCategories.SuspendLayout();
        ((ISupportInitialize)numCategoryIconIndex).BeginInit();
        tabTags.SuspendLayout();
        ((ISupportInitialize)numTagIconIndex).BeginInit();
        SuspendLayout();
        // 
        // tabControlQuestBoard
        // 
        tabControlQuestBoard.Controls.Add(tabQuest);
        tabControlQuestBoard.Controls.Add(tabCategories);
        tabControlQuestBoard.Controls.Add(tabTags);
        tabControlQuestBoard.Font = new Font("Victor Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        tabControlQuestBoard.Location = new Point(0, 0);
        tabControlQuestBoard.Margin = new Padding(2, 1, 2, 1);
        tabControlQuestBoard.Name = "tabControlQuestBoard";
        tabControlQuestBoard.SelectedIndex = 0;
        tabControlQuestBoard.Size = new Size(1586, 863);
        tabControlQuestBoard.TabIndex = 0;
        // 
        // tabQuest
        // 
        tabQuest.Controls.Add(labelQuests);
        tabQuest.Controls.Add(listBoxQuests);
        tabQuest.Controls.Add(groupBoxObjectiveData);
        tabQuest.Controls.Add(groupBoxCoreData);
        tabQuest.Location = new Point(4, 29);
        tabQuest.Margin = new Padding(2, 1, 2, 1);
        tabQuest.Name = "tabQuest";
        tabQuest.Padding = new Padding(2, 1, 2, 1);
        tabQuest.Size = new Size(1578, 830);
        tabQuest.TabIndex = 1;
        tabQuest.Text = "Quests";
        tabQuest.UseVisualStyleBackColor = true;
        // 
        // labelQuests
        // 
        labelQuests.AutoSize = true;
        labelQuests.Font = new Font("Victor Mono", 15.7499981F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
        labelQuests.Location = new Point(5, 7);
        labelQuests.Name = "labelQuests";
        labelQuests.Size = new Size(78, 26);
        labelQuests.TabIndex = 70;
        labelQuests.Text = "Quests";
        // 
        // listBoxQuests
        // 
        listBoxQuests.Font = new Font("Victor Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        listBoxQuests.FormattingEnabled = true;
        listBoxQuests.ItemHeight = 20;
        listBoxQuests.Location = new Point(9, 40);
        listBoxQuests.Margin = new Padding(2, 1, 2, 1);
        listBoxQuests.Name = "listBoxQuests";
        listBoxQuests.Size = new Size(357, 784);
        listBoxQuests.TabIndex = 13;
        // 
        // groupBoxObjectiveData
        // 
        groupBoxObjectiveData.Controls.Add(groupBoxObjectiveLogs);
        groupBoxObjectiveData.Controls.Add(groupBoxFulfillmentData);
        groupBoxObjectiveData.Controls.Add(labelObjectiveId);
        groupBoxObjectiveData.Controls.Add(numObjectiveId);
        groupBoxObjectiveData.Controls.Add(labelObjectiveDescription);
        groupBoxObjectiveData.Controls.Add(textBoxObjectiveDescription);
        groupBoxObjectiveData.Controls.Add(listBoxObjectives);
        groupBoxObjectiveData.Controls.Add(checkBoxHiddenByDefault);
        groupBoxObjectiveData.Controls.Add(checkBoxIsOptional);
        groupBoxObjectiveData.Font = new Font("Victor Mono", 7.874999F);
        groupBoxObjectiveData.Location = new Point(370, 269);
        groupBoxObjectiveData.Margin = new Padding(2, 1, 2, 1);
        groupBoxObjectiveData.Name = "groupBoxObjectiveData";
        groupBoxObjectiveData.Padding = new Padding(2, 1, 2, 1);
        groupBoxObjectiveData.Size = new Size(1199, 559);
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
        groupBoxObjectiveLogs.Location = new Point(5, 368);
        groupBoxObjectiveLogs.Margin = new Padding(2, 1, 2, 1);
        groupBoxObjectiveLogs.Name = "groupBoxObjectiveLogs";
        groupBoxObjectiveLogs.Padding = new Padding(2, 1, 2, 1);
        groupBoxObjectiveLogs.Size = new Size(1199, 218);
        groupBoxObjectiveLogs.TabIndex = 70;
        groupBoxObjectiveLogs.TabStop = false;
        groupBoxObjectiveLogs.Text = "Logs";
        // 
        // labelLogMissed
        // 
        labelLogMissed.AutoSize = true;
        labelLogMissed.Location = new Point(26, 158);
        labelLogMissed.Margin = new Padding(2, 0, 2, 0);
        labelLogMissed.Name = "labelLogMissed";
        labelLogMissed.Size = new Size(43, 13);
        labelLogMissed.TabIndex = 17;
        labelLogMissed.Text = "Missed";
        // 
        // textBoxLogMissed
        // 
        textBoxLogMissed.Font = new Font("Victor Mono", 12F);
        textBoxLogMissed.Location = new Point(72, 156);
        textBoxLogMissed.Margin = new Padding(2, 1, 2, 1);
        textBoxLogMissed.Name = "textBoxLogMissed";
        textBoxLogMissed.Size = new Size(1118, 30);
        textBoxLogMissed.TabIndex = 16;
        // 
        // labelLogFailed
        // 
        labelLogFailed.AutoSize = true;
        labelLogFailed.Location = new Point(26, 120);
        labelLogFailed.Margin = new Padding(2, 0, 2, 0);
        labelLogFailed.Name = "labelLogFailed";
        labelLogFailed.Size = new Size(43, 13);
        labelLogFailed.TabIndex = 15;
        labelLogFailed.Text = "Failed";
        // 
        // textBoxLogFailed
        // 
        textBoxLogFailed.Font = new Font("Victor Mono", 12F);
        textBoxLogFailed.Location = new Point(72, 119);
        textBoxLogFailed.Margin = new Padding(2, 1, 2, 1);
        textBoxLogFailed.Name = "textBoxLogFailed";
        textBoxLogFailed.Size = new Size(1118, 30);
        textBoxLogFailed.TabIndex = 14;
        // 
        // labelLogCompleted
        // 
        labelLogCompleted.AutoSize = true;
        labelLogCompleted.Location = new Point(9, 84);
        labelLogCompleted.Margin = new Padding(2, 0, 2, 0);
        labelLogCompleted.Name = "labelLogCompleted";
        labelLogCompleted.Size = new Size(61, 13);
        labelLogCompleted.TabIndex = 13;
        labelLogCompleted.Text = "Completed";
        // 
        // textBoxLogCompleted
        // 
        textBoxLogCompleted.Font = new Font("Victor Mono", 12F);
        textBoxLogCompleted.Location = new Point(72, 83);
        textBoxLogCompleted.Margin = new Padding(2, 1, 2, 1);
        textBoxLogCompleted.Name = "textBoxLogCompleted";
        textBoxLogCompleted.Size = new Size(1118, 30);
        textBoxLogCompleted.TabIndex = 12;
        // 
        // labelLogActive
        // 
        labelLogActive.AutoSize = true;
        labelLogActive.Location = new Point(26, 51);
        labelLogActive.Margin = new Padding(2, 0, 2, 0);
        labelLogActive.Name = "labelLogActive";
        labelLogActive.Size = new Size(43, 13);
        labelLogActive.TabIndex = 11;
        labelLogActive.Text = "Active";
        // 
        // textBoxLogActive
        // 
        textBoxLogActive.Font = new Font("Victor Mono", 12F);
        textBoxLogActive.Location = new Point(72, 49);
        textBoxLogActive.Margin = new Padding(2, 1, 2, 1);
        textBoxLogActive.Name = "textBoxLogActive";
        textBoxLogActive.Size = new Size(1118, 30);
        textBoxLogActive.TabIndex = 10;
        // 
        // labelLogInactive
        // 
        labelLogInactive.AutoSize = true;
        labelLogInactive.Location = new Point(15, 17);
        labelLogInactive.Margin = new Padding(2, 0, 2, 0);
        labelLogInactive.Name = "labelLogInactive";
        labelLogInactive.Size = new Size(55, 13);
        labelLogInactive.TabIndex = 9;
        labelLogInactive.Text = "Inactive";
        // 
        // textBoxLogInactive
        // 
        textBoxLogInactive.Font = new Font("Victor Mono", 12F);
        textBoxLogInactive.Location = new Point(72, 12);
        textBoxLogInactive.Margin = new Padding(2, 1, 2, 1);
        textBoxLogInactive.Name = "textBoxLogInactive";
        textBoxLogInactive.Size = new Size(1118, 30);
        textBoxLogInactive.TabIndex = 8;
        // 
        // groupBoxFulfillmentData
        // 
        groupBoxFulfillmentData.Controls.Add(groupBoxQuestData);
        groupBoxFulfillmentData.Controls.Add(labelObjectiveType);
        groupBoxFulfillmentData.Controls.Add(comboBoxObjectiveType);
        groupBoxFulfillmentData.Controls.Add(groupBoxIndiscriminateData);
        groupBoxFulfillmentData.Controls.Add(groupBoxFetchData);
        groupBoxFulfillmentData.Controls.Add(groupBoxDestinationData);
        groupBoxFulfillmentData.Controls.Add(groupBoxSlayData);
        groupBoxFulfillmentData.Location = new Point(48, 105);
        groupBoxFulfillmentData.Margin = new Padding(2, 1, 2, 1);
        groupBoxFulfillmentData.Name = "groupBoxFulfillmentData";
        groupBoxFulfillmentData.Padding = new Padding(2, 1, 2, 1);
        groupBoxFulfillmentData.Size = new Size(1147, 273);
        groupBoxFulfillmentData.TabIndex = 69;
        groupBoxFulfillmentData.TabStop = false;
        groupBoxFulfillmentData.Text = "Fulfillment Data";
        // 
        // groupBoxQuestData
        // 
        groupBoxQuestData.Controls.Add(textBoxObjectiveQuestData);
        groupBoxQuestData.Controls.Add(labelObjectiveQuestKeys);
        groupBoxQuestData.Location = new Point(682, 15);
        groupBoxQuestData.Name = "groupBoxQuestData";
        groupBoxQuestData.Size = new Size(235, 151);
        groupBoxQuestData.TabIndex = 70;
        groupBoxQuestData.TabStop = false;
        groupBoxQuestData.Text = "Quest Data";
        // 
        // textBoxObjectiveQuestData
        // 
        textBoxObjectiveQuestData.Font = new Font("Victor Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        textBoxObjectiveQuestData.Location = new Point(5, 30);
        textBoxObjectiveQuestData.Margin = new Padding(2, 1, 2, 1);
        textBoxObjectiveQuestData.Multiline = true;
        textBoxObjectiveQuestData.Name = "textBoxObjectiveQuestData";
        textBoxObjectiveQuestData.Size = new Size(222, 116);
        textBoxObjectiveQuestData.TabIndex = 68;
        // 
        // labelObjectiveQuestKeys
        // 
        labelObjectiveQuestKeys.AutoSize = true;
        labelObjectiveQuestKeys.Font = new Font("Victor Mono", 7.874999F);
        labelObjectiveQuestKeys.Location = new Point(5, 16);
        labelObjectiveQuestKeys.Margin = new Padding(2, 0, 2, 0);
        labelObjectiveQuestKeys.Name = "labelObjectiveQuestKeys";
        labelObjectiveQuestKeys.Size = new Size(31, 13);
        labelObjectiveQuestKeys.TabIndex = 69;
        labelObjectiveQuestKeys.Text = "Keys";
        // 
        // labelObjectiveType
        // 
        labelObjectiveType.AutoSize = true;
        labelObjectiveType.Font = new Font("Victor Mono", 7.874999F);
        labelObjectiveType.Location = new Point(3, 15);
        labelObjectiveType.Margin = new Padding(2, 0, 2, 0);
        labelObjectiveType.Name = "labelObjectiveType";
        labelObjectiveType.Size = new Size(31, 13);
        labelObjectiveType.TabIndex = 22;
        labelObjectiveType.Text = "Type";
        // 
        // comboBoxObjectiveType
        // 
        comboBoxObjectiveType.Font = new Font("Victor Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        comboBoxObjectiveType.FormattingEnabled = true;
        comboBoxObjectiveType.Location = new Point(3, 29);
        comboBoxObjectiveType.Margin = new Padding(2, 1, 2, 1);
        comboBoxObjectiveType.Name = "comboBoxObjectiveType";
        comboBoxObjectiveType.Size = new Size(164, 28);
        comboBoxObjectiveType.TabIndex = 21;
        // 
        // groupBoxIndiscriminateData
        // 
        groupBoxIndiscriminateData.Controls.Add(textBoxIndiscriminateData);
        groupBoxIndiscriminateData.Location = new Point(4, 204);
        groupBoxIndiscriminateData.Margin = new Padding(2, 1, 2, 1);
        groupBoxIndiscriminateData.Name = "groupBoxIndiscriminateData";
        groupBoxIndiscriminateData.Padding = new Padding(2, 1, 2, 1);
        groupBoxIndiscriminateData.Size = new Size(1143, 57);
        groupBoxIndiscriminateData.TabIndex = 37;
        groupBoxIndiscriminateData.TabStop = false;
        groupBoxIndiscriminateData.Text = "Indiscriminate Data";
        // 
        // textBoxIndiscriminateData
        // 
        textBoxIndiscriminateData.Font = new Font("Victor Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        textBoxIndiscriminateData.Location = new Point(25, 17);
        textBoxIndiscriminateData.Margin = new Padding(2, 1, 2, 1);
        textBoxIndiscriminateData.Name = "textBoxIndiscriminateData";
        textBoxIndiscriminateData.Size = new Size(1114, 30);
        textBoxIndiscriminateData.TabIndex = 25;
        // 
        // groupBoxFetchData
        // 
        groupBoxFetchData.Controls.Add(labelFetchAmount);
        groupBoxFetchData.Controls.Add(numFetchAmount);
        groupBoxFetchData.Controls.Add(labelFetchId);
        groupBoxFetchData.Controls.Add(numFetchId);
        groupBoxFetchData.Controls.Add(comboBoxFetchType);
        groupBoxFetchData.Controls.Add(labelFetchType);
        groupBoxFetchData.Location = new Point(327, 15);
        groupBoxFetchData.Margin = new Padding(2, 1, 2, 1);
        groupBoxFetchData.Name = "groupBoxFetchData";
        groupBoxFetchData.Padding = new Padding(2, 1, 2, 1);
        groupBoxFetchData.Size = new Size(168, 187);
        groupBoxFetchData.TabIndex = 33;
        groupBoxFetchData.TabStop = false;
        groupBoxFetchData.Text = "Fetch Data";
        // 
        // labelFetchAmount
        // 
        labelFetchAmount.AutoSize = true;
        labelFetchAmount.Font = new Font("Victor Mono", 7.874999F);
        labelFetchAmount.Location = new Point(5, 110);
        labelFetchAmount.Margin = new Padding(2, 0, 2, 0);
        labelFetchAmount.Name = "labelFetchAmount";
        labelFetchAmount.Size = new Size(43, 13);
        labelFetchAmount.TabIndex = 36;
        labelFetchAmount.Text = "Amount";
        // 
        // numFetchAmount
        // 
        numFetchAmount.Font = new Font("Victor Mono", 12F);
        numFetchAmount.Location = new Point(52, 102);
        numFetchAmount.Margin = new Padding(2, 1, 2, 1);
        numFetchAmount.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
        numFetchAmount.Name = "numFetchAmount";
        numFetchAmount.Size = new Size(67, 30);
        numFetchAmount.TabIndex = 35;
        numFetchAmount.TextAlign = HorizontalAlignment.Center;
        // 
        // labelFetchId
        // 
        labelFetchId.AutoSize = true;
        labelFetchId.Font = new Font("Victor Mono", 7.874999F);
        labelFetchId.Location = new Point(29, 78);
        labelFetchId.Margin = new Padding(2, 0, 2, 0);
        labelFetchId.Name = "labelFetchId";
        labelFetchId.Size = new Size(19, 13);
        labelFetchId.TabIndex = 34;
        labelFetchId.Text = "Id";
        // 
        // numFetchId
        // 
        numFetchId.Font = new Font("Victor Mono", 12F);
        numFetchId.Location = new Point(52, 70);
        numFetchId.Margin = new Padding(2, 1, 2, 1);
        numFetchId.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
        numFetchId.Name = "numFetchId";
        numFetchId.Size = new Size(67, 30);
        numFetchId.TabIndex = 33;
        numFetchId.TextAlign = HorizontalAlignment.Center;
        // 
        // comboBoxFetchType
        // 
        comboBoxFetchType.Font = new Font("Victor Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        comboBoxFetchType.FormattingEnabled = true;
        comboBoxFetchType.Location = new Point(3, 28);
        comboBoxFetchType.Margin = new Padding(2, 1, 2, 1);
        comboBoxFetchType.Name = "comboBoxFetchType";
        comboBoxFetchType.Size = new Size(161, 28);
        comboBoxFetchType.TabIndex = 1;
        // 
        // labelFetchType
        // 
        labelFetchType.AutoSize = true;
        labelFetchType.Location = new Point(3, 14);
        labelFetchType.Margin = new Padding(2, 0, 2, 0);
        labelFetchType.Name = "labelFetchType";
        labelFetchType.Size = new Size(67, 13);
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
        groupBoxDestinationData.Location = new Point(183, 17);
        groupBoxDestinationData.Margin = new Padding(2, 1, 2, 1);
        groupBoxDestinationData.Name = "groupBoxDestinationData";
        groupBoxDestinationData.Padding = new Padding(2, 1, 2, 1);
        groupBoxDestinationData.Size = new Size(140, 185);
        groupBoxDestinationData.TabIndex = 1;
        groupBoxDestinationData.TabStop = false;
        groupBoxDestinationData.Text = "Destination Data";
        // 
        // labelDestinationY2
        // 
        labelDestinationY2.AutoSize = true;
        labelDestinationY2.Font = new Font("Victor Mono", 7.874999F);
        labelDestinationY2.Location = new Point(33, 161);
        labelDestinationY2.Margin = new Padding(2, 0, 2, 0);
        labelDestinationY2.Name = "labelDestinationY2";
        labelDestinationY2.Size = new Size(19, 13);
        labelDestinationY2.TabIndex = 36;
        labelDestinationY2.Text = "Y2";
        // 
        // numDestinationY2
        // 
        numDestinationY2.Font = new Font("Victor Mono", 12F);
        numDestinationY2.Location = new Point(57, 153);
        numDestinationY2.Margin = new Padding(2, 1, 2, 1);
        numDestinationY2.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
        numDestinationY2.Minimum = new decimal(new int[] { 1, 0, 0, int.MinValue });
        numDestinationY2.Name = "numDestinationY2";
        numDestinationY2.Size = new Size(67, 30);
        numDestinationY2.TabIndex = 35;
        numDestinationY2.TextAlign = HorizontalAlignment.Center;
        // 
        // labelDestinationX2
        // 
        labelDestinationX2.AutoSize = true;
        labelDestinationX2.Font = new Font("Victor Mono", 7.874999F);
        labelDestinationX2.Location = new Point(33, 129);
        labelDestinationX2.Margin = new Padding(2, 0, 2, 0);
        labelDestinationX2.Name = "labelDestinationX2";
        labelDestinationX2.Size = new Size(19, 13);
        labelDestinationX2.TabIndex = 34;
        labelDestinationX2.Text = "X2";
        // 
        // numDestinationX2
        // 
        numDestinationX2.Font = new Font("Victor Mono", 12F);
        numDestinationX2.Location = new Point(57, 121);
        numDestinationX2.Margin = new Padding(2, 1, 2, 1);
        numDestinationX2.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
        numDestinationX2.Minimum = new decimal(new int[] { 1, 0, 0, int.MinValue });
        numDestinationX2.Name = "numDestinationX2";
        numDestinationX2.Size = new Size(67, 30);
        numDestinationX2.TabIndex = 33;
        numDestinationX2.TextAlign = HorizontalAlignment.Center;
        // 
        // labelDestinationY1
        // 
        labelDestinationY1.AutoSize = true;
        labelDestinationY1.Font = new Font("Victor Mono", 7.874999F);
        labelDestinationY1.Location = new Point(35, 92);
        labelDestinationY1.Margin = new Padding(2, 0, 2, 0);
        labelDestinationY1.Name = "labelDestinationY1";
        labelDestinationY1.Size = new Size(19, 13);
        labelDestinationY1.TabIndex = 32;
        labelDestinationY1.Text = "Y1";
        // 
        // numDestinationY1
        // 
        numDestinationY1.Font = new Font("Victor Mono", 12F);
        numDestinationY1.Location = new Point(57, 84);
        numDestinationY1.Margin = new Padding(2, 1, 2, 1);
        numDestinationY1.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
        numDestinationY1.Minimum = new decimal(new int[] { 1, 0, 0, int.MinValue });
        numDestinationY1.Name = "numDestinationY1";
        numDestinationY1.Size = new Size(67, 30);
        numDestinationY1.TabIndex = 31;
        numDestinationY1.TextAlign = HorizontalAlignment.Center;
        // 
        // labelDestinationX1
        // 
        labelDestinationX1.AutoSize = true;
        labelDestinationX1.Font = new Font("Victor Mono", 7.874999F);
        labelDestinationX1.Location = new Point(33, 59);
        labelDestinationX1.Margin = new Padding(2, 0, 2, 0);
        labelDestinationX1.Name = "labelDestinationX1";
        labelDestinationX1.Size = new Size(19, 13);
        labelDestinationX1.TabIndex = 30;
        labelDestinationX1.Text = "X1";
        // 
        // numDestinationX1
        // 
        numDestinationX1.Font = new Font("Victor Mono", 12F);
        numDestinationX1.Location = new Point(57, 52);
        numDestinationX1.Margin = new Padding(2, 1, 2, 1);
        numDestinationX1.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
        numDestinationX1.Minimum = new decimal(new int[] { 1, 0, 0, int.MinValue });
        numDestinationX1.Name = "numDestinationX1";
        numDestinationX1.Size = new Size(67, 30);
        numDestinationX1.TabIndex = 29;
        numDestinationX1.TextAlign = HorizontalAlignment.Center;
        // 
        // labelDestinationMapId
        // 
        labelDestinationMapId.AutoSize = true;
        labelDestinationMapId.Font = new Font("Victor Mono", 7.874999F);
        labelDestinationMapId.Location = new Point(11, 24);
        labelDestinationMapId.Margin = new Padding(2, 0, 2, 0);
        labelDestinationMapId.Name = "labelDestinationMapId";
        labelDestinationMapId.Size = new Size(43, 13);
        labelDestinationMapId.TabIndex = 28;
        labelDestinationMapId.Text = "Map Id";
        // 
        // numDestinationMapId
        // 
        numDestinationMapId.Font = new Font("Victor Mono", 12F);
        numDestinationMapId.Location = new Point(57, 16);
        numDestinationMapId.Margin = new Padding(2, 1, 2, 1);
        numDestinationMapId.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
        numDestinationMapId.Minimum = new decimal(new int[] { 1, 0, 0, int.MinValue });
        numDestinationMapId.Name = "numDestinationMapId";
        numDestinationMapId.Size = new Size(67, 30);
        numDestinationMapId.TabIndex = 27;
        numDestinationMapId.TextAlign = HorizontalAlignment.Center;
        // 
        // groupBoxSlayData
        // 
        groupBoxSlayData.Controls.Add(labelSlayEnemyId);
        groupBoxSlayData.Controls.Add(labelSlayAmount);
        groupBoxSlayData.Controls.Add(numSlayEnemyId);
        groupBoxSlayData.Controls.Add(numSlayAmount);
        groupBoxSlayData.Location = new Point(499, 15);
        groupBoxSlayData.Margin = new Padding(2, 1, 2, 1);
        groupBoxSlayData.Name = "groupBoxSlayData";
        groupBoxSlayData.Padding = new Padding(2, 1, 2, 1);
        groupBoxSlayData.Size = new Size(140, 187);
        groupBoxSlayData.TabIndex = 38;
        groupBoxSlayData.TabStop = false;
        groupBoxSlayData.Text = "Slay Data";
        // 
        // labelSlayEnemyId
        // 
        labelSlayEnemyId.AutoSize = true;
        labelSlayEnemyId.Font = new Font("Victor Mono", 7.874999F);
        labelSlayEnemyId.Location = new Point(8, 78);
        labelSlayEnemyId.Margin = new Padding(2, 0, 2, 0);
        labelSlayEnemyId.Name = "labelSlayEnemyId";
        labelSlayEnemyId.Size = new Size(55, 13);
        labelSlayEnemyId.TabIndex = 32;
        labelSlayEnemyId.Text = "Enemy Id";
        // 
        // labelSlayAmount
        // 
        labelSlayAmount.AutoSize = true;
        labelSlayAmount.Font = new Font("Victor Mono", 7.874999F);
        labelSlayAmount.Location = new Point(20, 110);
        labelSlayAmount.Margin = new Padding(2, 0, 2, 0);
        labelSlayAmount.Name = "labelSlayAmount";
        labelSlayAmount.Size = new Size(43, 13);
        labelSlayAmount.TabIndex = 32;
        labelSlayAmount.Text = "Amount";
        // 
        // numSlayEnemyId
        // 
        numSlayEnemyId.Font = new Font("Victor Mono", 12F);
        numSlayEnemyId.Location = new Point(67, 70);
        numSlayEnemyId.Margin = new Padding(2, 1, 2, 1);
        numSlayEnemyId.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
        numSlayEnemyId.Minimum = new decimal(new int[] { 1, 0, 0, int.MinValue });
        numSlayEnemyId.Name = "numSlayEnemyId";
        numSlayEnemyId.Size = new Size(67, 30);
        numSlayEnemyId.TabIndex = 31;
        numSlayEnemyId.TextAlign = HorizontalAlignment.Center;
        // 
        // numSlayAmount
        // 
        numSlayAmount.Font = new Font("Victor Mono", 12F);
        numSlayAmount.Location = new Point(67, 102);
        numSlayAmount.Margin = new Padding(2, 1, 2, 1);
        numSlayAmount.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
        numSlayAmount.Minimum = new decimal(new int[] { 1, 0, 0, int.MinValue });
        numSlayAmount.Name = "numSlayAmount";
        numSlayAmount.Size = new Size(67, 30);
        numSlayAmount.TabIndex = 31;
        numSlayAmount.TextAlign = HorizontalAlignment.Center;
        // 
        // labelObjectiveId
        // 
        labelObjectiveId.AutoSize = true;
        labelObjectiveId.Font = new Font("Victor Mono", 7.874999F);
        labelObjectiveId.Location = new Point(46, 28);
        labelObjectiveId.Margin = new Padding(2, 0, 2, 0);
        labelObjectiveId.Name = "labelObjectiveId";
        labelObjectiveId.Size = new Size(19, 13);
        labelObjectiveId.TabIndex = 26;
        labelObjectiveId.Text = "Id";
        // 
        // numObjectiveId
        // 
        numObjectiveId.Font = new Font("Victor Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        numObjectiveId.Location = new Point(69, 20);
        numObjectiveId.Margin = new Padding(2, 1, 2, 1);
        numObjectiveId.Name = "numObjectiveId";
        numObjectiveId.Size = new Size(67, 30);
        numObjectiveId.TabIndex = 25;
        numObjectiveId.TextAlign = HorizontalAlignment.Center;
        // 
        // labelObjectiveDescription
        // 
        labelObjectiveDescription.AutoSize = true;
        labelObjectiveDescription.Font = new Font("Victor Mono", 7.874999F);
        labelObjectiveDescription.Location = new Point(46, 56);
        labelObjectiveDescription.Margin = new Padding(2, 0, 2, 0);
        labelObjectiveDescription.Name = "labelObjectiveDescription";
        labelObjectiveDescription.Size = new Size(73, 13);
        labelObjectiveDescription.TabIndex = 24;
        labelObjectiveDescription.Text = "Description";
        // 
        // textBoxObjectiveDescription
        // 
        textBoxObjectiveDescription.Font = new Font("Victor Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        textBoxObjectiveDescription.Location = new Point(46, 72);
        textBoxObjectiveDescription.Margin = new Padding(2, 1, 2, 1);
        textBoxObjectiveDescription.Name = "textBoxObjectiveDescription";
        textBoxObjectiveDescription.Size = new Size(1145, 30);
        textBoxObjectiveDescription.TabIndex = 23;
        // 
        // listBoxObjectives
        // 
        listBoxObjectives.Font = new Font("Victor Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        listBoxObjectives.FormattingEnabled = true;
        listBoxObjectives.ItemHeight = 20;
        listBoxObjectives.Location = new Point(3, 18);
        listBoxObjectives.Margin = new Padding(2, 1, 2, 1);
        listBoxObjectives.Name = "listBoxObjectives";
        listBoxObjectives.Size = new Size(41, 284);
        listBoxObjectives.TabIndex = 20;
        // 
        // checkBoxHiddenByDefault
        // 
        checkBoxHiddenByDefault.AutoSize = true;
        checkBoxHiddenByDefault.Checked = true;
        checkBoxHiddenByDefault.CheckState = CheckState.Checked;
        checkBoxHiddenByDefault.Font = new Font("Victor Mono", 12F);
        checkBoxHiddenByDefault.Location = new Point(208, 17);
        checkBoxHiddenByDefault.Margin = new Padding(2, 1, 2, 1);
        checkBoxHiddenByDefault.Name = "checkBoxHiddenByDefault";
        checkBoxHiddenByDefault.Size = new Size(181, 24);
        checkBoxHiddenByDefault.TabIndex = 11;
        checkBoxHiddenByDefault.Text = "Hidden By Default";
        checkBoxHiddenByDefault.UseVisualStyleBackColor = true;
        // 
        // checkBoxIsOptional
        // 
        checkBoxIsOptional.AutoSize = true;
        checkBoxIsOptional.Font = new Font("Victor Mono", 12F);
        checkBoxIsOptional.Location = new Point(208, 43);
        checkBoxIsOptional.Margin = new Padding(2, 1, 2, 1);
        checkBoxIsOptional.Name = "checkBoxIsOptional";
        checkBoxIsOptional.Size = new Size(127, 24);
        checkBoxIsOptional.TabIndex = 12;
        checkBoxIsOptional.Text = "Is Optional";
        checkBoxIsOptional.UseVisualStyleBackColor = true;
        // 
        // groupBoxCoreData
        // 
        groupBoxCoreData.Controls.Add(checkedListBoxQuestTags);
        groupBoxCoreData.Controls.Add(labelRecommendedLevel);
        groupBoxCoreData.Controls.Add(numRecommendedLevel);
        groupBoxCoreData.Controls.Add(textBoxOverview);
        groupBoxCoreData.Controls.Add(labelCategory);
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
        groupBoxCoreData.Location = new Point(370, 7);
        groupBoxCoreData.Margin = new Padding(2, 1, 2, 1);
        groupBoxCoreData.Name = "groupBoxCoreData";
        groupBoxCoreData.Padding = new Padding(2, 1, 2, 1);
        groupBoxCoreData.Size = new Size(1199, 260);
        groupBoxCoreData.TabIndex = 18;
        groupBoxCoreData.TabStop = false;
        groupBoxCoreData.Text = "Core Data";
        // 
        // checkedListBoxQuestTags
        // 
        checkedListBoxQuestTags.CheckOnClick = true;
        checkedListBoxQuestTags.Font = new Font("Victor Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        checkedListBoxQuestTags.FormattingEnabled = true;
        checkedListBoxQuestTags.Location = new Point(208, 83);
        checkedListBoxQuestTags.Name = "checkedListBoxQuestTags";
        checkedListBoxQuestTags.RightToLeft = RightToLeft.Yes;
        checkedListBoxQuestTags.Size = new Size(237, 154);
        checkedListBoxQuestTags.TabIndex = 20;
        checkedListBoxQuestTags.ThreeDCheckBoxes = true;
        // 
        // labelRecommendedLevel
        // 
        labelRecommendedLevel.AutoSize = true;
        labelRecommendedLevel.Font = new Font("Victor Mono", 9.749999F);
        labelRecommendedLevel.Location = new Point(3, 195);
        labelRecommendedLevel.Margin = new Padding(2, 0, 2, 0);
        labelRecommendedLevel.Name = "labelRecommendedLevel";
        labelRecommendedLevel.Size = new Size(126, 16);
        labelRecommendedLevel.TabIndex = 19;
        labelRecommendedLevel.Text = "Recommended Level";
        // 
        // numRecommendedLevel
        // 
        numRecommendedLevel.Font = new Font("Victor Mono", 12F);
        numRecommendedLevel.Location = new Point(3, 212);
        numRecommendedLevel.Margin = new Padding(2, 1, 2, 1);
        numRecommendedLevel.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
        numRecommendedLevel.Minimum = new decimal(new int[] { 1, 0, 0, int.MinValue });
        numRecommendedLevel.Name = "numRecommendedLevel";
        numRecommendedLevel.Size = new Size(66, 30);
        numRecommendedLevel.TabIndex = 18;
        numRecommendedLevel.TextAlign = HorizontalAlignment.Center;
        // 
        // textBoxOverview
        // 
        textBoxOverview.Font = new Font("Victor Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        textBoxOverview.Location = new Point(460, 83);
        textBoxOverview.Margin = new Padding(2, 1, 2, 1);
        textBoxOverview.Multiline = true;
        textBoxOverview.Name = "textBoxOverview";
        textBoxOverview.Size = new Size(735, 175);
        textBoxOverview.TabIndex = 5;
        // 
        // labelCategory
        // 
        labelCategory.AutoSize = true;
        labelCategory.Font = new Font("Victor Mono", 9.749999F);
        labelCategory.Location = new Point(141, 57);
        labelCategory.Margin = new Padding(2, 0, 2, 0);
        labelCategory.Name = "labelCategory";
        labelCategory.Size = new Size(63, 16);
        labelCategory.TabIndex = 14;
        labelCategory.Text = "Category";
        // 
        // comboBoxCategory
        // 
        comboBoxCategory.Font = new Font("Victor Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        comboBoxCategory.FormattingEnabled = true;
        comboBoxCategory.Location = new Point(208, 51);
        comboBoxCategory.Margin = new Padding(2, 1, 2, 1);
        comboBoxCategory.Name = "comboBoxCategory";
        comboBoxCategory.Size = new Size(243, 28);
        comboBoxCategory.TabIndex = 13;
        // 
        // labelTags
        // 
        labelTags.AutoSize = true;
        labelTags.Font = new Font("Victor Mono", 9.749999F, FontStyle.Regular, GraphicsUnit.Point, 0);
        labelTags.Location = new Point(169, 85);
        labelTags.Margin = new Padding(2, 0, 2, 0);
        labelTags.Name = "labelTags";
        labelTags.Size = new Size(35, 16);
        labelTags.TabIndex = 16;
        labelTags.Text = "Tags";
        // 
        // labelIconIndex
        // 
        labelIconIndex.AutoSize = true;
        labelIconIndex.Font = new Font("Victor Mono", 9.749999F);
        labelIconIndex.Location = new Point(3, 122);
        labelIconIndex.Margin = new Padding(2, 0, 2, 0);
        labelIconIndex.Name = "labelIconIndex";
        labelIconIndex.Size = new Size(77, 16);
        labelIconIndex.TabIndex = 10;
        labelIconIndex.Text = "Icon Index";
        // 
        // numIconIndex
        // 
        numIconIndex.Font = new Font("Victor Mono", 12F);
        numIconIndex.Location = new Point(3, 139);
        numIconIndex.Margin = new Padding(2, 1, 2, 1);
        numIconIndex.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
        numIconIndex.Minimum = new decimal(new int[] { 1, 0, 0, int.MinValue });
        numIconIndex.Name = "numIconIndex";
        numIconIndex.Size = new Size(66, 30);
        numIconIndex.TabIndex = 9;
        numIconIndex.TextAlign = HorizontalAlignment.Center;
        // 
        // labelUnknownHint
        // 
        labelUnknownHint.AutoSize = true;
        labelUnknownHint.Font = new Font("Victor Mono", 9.749999F);
        labelUnknownHint.Location = new Point(460, 0);
        labelUnknownHint.Margin = new Padding(2, 0, 2, 0);
        labelUnknownHint.Name = "labelUnknownHint";
        labelUnknownHint.Size = new Size(91, 16);
        labelUnknownHint.TabIndex = 8;
        labelUnknownHint.Text = "Unknown Hint";
        // 
        // labelOverview
        // 
        labelOverview.AutoSize = true;
        labelOverview.Font = new Font("Victor Mono", 9.749999F);
        labelOverview.Location = new Point(460, 54);
        labelOverview.Margin = new Padding(2, 0, 2, 0);
        labelOverview.Name = "labelOverview";
        labelOverview.Size = new Size(63, 16);
        labelOverview.TabIndex = 6;
        labelOverview.Text = "Overview";
        // 
        // textBoxUnknownHint
        // 
        textBoxUnknownHint.Font = new Font("Victor Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        textBoxUnknownHint.Location = new Point(460, 17);
        textBoxUnknownHint.Margin = new Padding(2, 1, 2, 1);
        textBoxUnknownHint.Name = "textBoxUnknownHint";
        textBoxUnknownHint.Size = new Size(735, 30);
        textBoxUnknownHint.TabIndex = 7;
        // 
        // labelName
        // 
        labelName.AutoSize = true;
        labelName.Font = new Font("Victor Mono", 9.749999F);
        labelName.Location = new Point(5, 19);
        labelName.Margin = new Padding(2, 0, 2, 0);
        labelName.Name = "labelName";
        labelName.Size = new Size(35, 16);
        labelName.TabIndex = 4;
        labelName.Text = "Name";
        // 
        // textBoxKey
        // 
        textBoxKey.Font = new Font("Victor Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        textBoxKey.Location = new Point(0, 83);
        textBoxKey.Margin = new Padding(2, 1, 2, 1);
        textBoxKey.Name = "textBoxKey";
        textBoxKey.Size = new Size(100, 30);
        textBoxKey.TabIndex = 1;
        // 
        // textBoxName
        // 
        textBoxName.Font = new Font("Victor Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        textBoxName.Location = new Point(44, 13);
        textBoxName.Margin = new Padding(2, 1, 2, 1);
        textBoxName.Name = "textBoxName";
        textBoxName.Size = new Size(407, 30);
        textBoxName.TabIndex = 3;
        // 
        // labelKey
        // 
        labelKey.AutoSize = true;
        labelKey.Font = new Font("Victor Mono", 9.749999F);
        labelKey.Location = new Point(5, 66);
        labelKey.Margin = new Padding(2, 0, 2, 0);
        labelKey.Name = "labelKey";
        labelKey.Size = new Size(28, 16);
        labelKey.TabIndex = 2;
        labelKey.Text = "Key";
        // 
        // tabCategories
        // 
        tabCategories.Controls.Add(labelCategoryIconIndex);
        tabCategories.Controls.Add(numCategoryIconIndex);
        tabCategories.Controls.Add(buttonDeleteCategory);
        tabCategories.Controls.Add(buttonAddCategory);
        tabCategories.Controls.Add(textBoxCategoryKey);
        tabCategories.Controls.Add(labelCategoryKey);
        tabCategories.Controls.Add(textBoxCategoryName);
        tabCategories.Controls.Add(labelCategoryName);
        tabCategories.Controls.Add(labelCategories);
        tabCategories.Controls.Add(listBoxCategories);
        tabCategories.Location = new Point(4, 29);
        tabCategories.Margin = new Padding(2, 1, 2, 1);
        tabCategories.Name = "tabCategories";
        tabCategories.Size = new Size(1578, 830);
        tabCategories.TabIndex = 2;
        tabCategories.Text = "Categories";
        tabCategories.UseVisualStyleBackColor = true;
        // 
        // labelCategoryIconIndex
        // 
        labelCategoryIconIndex.AutoSize = true;
        labelCategoryIconIndex.Font = new Font("Victor Mono", 7.874999F);
        labelCategoryIconIndex.Location = new Point(186, 165);
        labelCategoryIconIndex.Margin = new Padding(2, 0, 2, 0);
        labelCategoryIconIndex.Name = "labelCategoryIconIndex";
        labelCategoryIconIndex.Size = new Size(67, 13);
        labelCategoryIconIndex.TabIndex = 72;
        labelCategoryIconIndex.Text = "Icon Index";
        // 
        // numCategoryIconIndex
        // 
        numCategoryIconIndex.Font = new Font("Victor Mono", 7.874999F);
        numCategoryIconIndex.Location = new Point(188, 179);
        numCategoryIconIndex.Margin = new Padding(2, 1, 2, 1);
        numCategoryIconIndex.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
        numCategoryIconIndex.Minimum = new decimal(new int[] { 1, 0, 0, int.MinValue });
        numCategoryIconIndex.Name = "numCategoryIconIndex";
        numCategoryIconIndex.Size = new Size(66, 22);
        numCategoryIconIndex.TabIndex = 71;
        numCategoryIconIndex.TextAlign = HorizontalAlignment.Center;
        // 
        // buttonDeleteCategory
        // 
        buttonDeleteCategory.Font = new Font("Cascadia Code", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
        buttonDeleteCategory.ForeColor = Color.Red;
        buttonDeleteCategory.Location = new Point(8, 527);
        buttonDeleteCategory.Name = "buttonDeleteCategory";
        buttonDeleteCategory.Size = new Size(76, 43);
        buttonDeleteCategory.TabIndex = 70;
        buttonDeleteCategory.Text = "❌";
        buttonDeleteCategory.UseVisualStyleBackColor = true;
        // 
        // buttonAddCategory
        // 
        buttonAddCategory.Font = new Font("Cascadia Code", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
        buttonAddCategory.ForeColor = Color.Green;
        buttonAddCategory.Location = new Point(106, 527);
        buttonAddCategory.Name = "buttonAddCategory";
        buttonAddCategory.Size = new Size(75, 45);
        buttonAddCategory.TabIndex = 69;
        buttonAddCategory.Text = "✨";
        buttonAddCategory.UseVisualStyleBackColor = true;
        // 
        // textBoxCategoryKey
        // 
        textBoxCategoryKey.Location = new Point(187, 110);
        textBoxCategoryKey.Name = "textBoxCategoryKey";
        textBoxCategoryKey.Size = new Size(99, 30);
        textBoxCategoryKey.TabIndex = 30;
        // 
        // labelCategoryKey
        // 
        labelCategoryKey.AutoSize = true;
        labelCategoryKey.Font = new Font("Victor Mono", 7.874999F);
        labelCategoryKey.Location = new Point(186, 94);
        labelCategoryKey.Margin = new Padding(2, 0, 2, 0);
        labelCategoryKey.Name = "labelCategoryKey";
        labelCategoryKey.Size = new Size(25, 13);
        labelCategoryKey.TabIndex = 29;
        labelCategoryKey.Text = "Key";
        // 
        // textBoxCategoryName
        // 
        textBoxCategoryName.Location = new Point(187, 52);
        textBoxCategoryName.Name = "textBoxCategoryName";
        textBoxCategoryName.Size = new Size(214, 30);
        textBoxCategoryName.TabIndex = 28;
        // 
        // labelCategoryName
        // 
        labelCategoryName.AutoSize = true;
        labelCategoryName.Font = new Font("Victor Mono", 7.874999F);
        labelCategoryName.Location = new Point(186, 36);
        labelCategoryName.Margin = new Padding(2, 0, 2, 0);
        labelCategoryName.Name = "labelCategoryName";
        labelCategoryName.Size = new Size(31, 13);
        labelCategoryName.TabIndex = 27;
        labelCategoryName.Text = "Name";
        // 
        // labelCategories
        // 
        labelCategories.AutoSize = true;
        labelCategories.Font = new Font("Victor Mono", 15.7499981F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
        labelCategories.Location = new Point(8, 7);
        labelCategories.Name = "labelCategories";
        labelCategories.Size = new Size(122, 26);
        labelCategories.TabIndex = 1;
        labelCategories.Text = "Categories";
        // 
        // listBoxCategories
        // 
        listBoxCategories.FormattingEnabled = true;
        listBoxCategories.ItemHeight = 20;
        listBoxCategories.Location = new Point(8, 36);
        listBoxCategories.Name = "listBoxCategories";
        listBoxCategories.Size = new Size(173, 484);
        listBoxCategories.TabIndex = 0;
        // 
        // tabTags
        // 
        tabTags.Controls.Add(labelTagIconIndex);
        tabTags.Controls.Add(numTagIconIndex);
        tabTags.Controls.Add(buttonDeleteTag);
        tabTags.Controls.Add(buttonAddTag);
        tabTags.Controls.Add(textBoxTagKey);
        tabTags.Controls.Add(labelTagKey);
        tabTags.Controls.Add(textBoxTagName);
        tabTags.Controls.Add(labelTagName);
        tabTags.Controls.Add(labelTagList);
        tabTags.Controls.Add(listBoxTags);
        tabTags.Location = new Point(4, 29);
        tabTags.Margin = new Padding(2, 1, 2, 1);
        tabTags.Name = "tabTags";
        tabTags.Size = new Size(1578, 830);
        tabTags.TabIndex = 3;
        tabTags.Text = "Tags";
        tabTags.UseVisualStyleBackColor = true;
        // 
        // labelTagIconIndex
        // 
        labelTagIconIndex.AutoSize = true;
        labelTagIconIndex.Font = new Font("Victor Mono", 7.874999F);
        labelTagIconIndex.Location = new Point(187, 158);
        labelTagIconIndex.Margin = new Padding(2, 0, 2, 0);
        labelTagIconIndex.Name = "labelTagIconIndex";
        labelTagIconIndex.Size = new Size(67, 13);
        labelTagIconIndex.TabIndex = 74;
        labelTagIconIndex.Text = "Icon Index";
        // 
        // numTagIconIndex
        // 
        numTagIconIndex.Font = new Font("Victor Mono", 7.874999F);
        numTagIconIndex.Location = new Point(189, 172);
        numTagIconIndex.Margin = new Padding(2, 1, 2, 1);
        numTagIconIndex.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
        numTagIconIndex.Minimum = new decimal(new int[] { 1, 0, 0, int.MinValue });
        numTagIconIndex.Name = "numTagIconIndex";
        numTagIconIndex.Size = new Size(66, 22);
        numTagIconIndex.TabIndex = 73;
        numTagIconIndex.TextAlign = HorizontalAlignment.Center;
        // 
        // buttonDeleteTag
        // 
        buttonDeleteTag.Font = new Font("Cascadia Code", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
        buttonDeleteTag.ForeColor = Color.Red;
        buttonDeleteTag.Location = new Point(8, 527);
        buttonDeleteTag.Name = "buttonDeleteTag";
        buttonDeleteTag.Size = new Size(76, 43);
        buttonDeleteTag.TabIndex = 72;
        buttonDeleteTag.Text = "❌";
        buttonDeleteTag.UseVisualStyleBackColor = true;
        // 
        // buttonAddTag
        // 
        buttonAddTag.Font = new Font("Cascadia Code", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
        buttonAddTag.ForeColor = Color.Green;
        buttonAddTag.Location = new Point(106, 527);
        buttonAddTag.Name = "buttonAddTag";
        buttonAddTag.Size = new Size(75, 45);
        buttonAddTag.TabIndex = 71;
        buttonAddTag.Text = "✨";
        buttonAddTag.UseVisualStyleBackColor = true;
        // 
        // textBoxTagKey
        // 
        textBoxTagKey.Location = new Point(187, 111);
        textBoxTagKey.Name = "textBoxTagKey";
        textBoxTagKey.Size = new Size(99, 30);
        textBoxTagKey.TabIndex = 36;
        // 
        // labelTagKey
        // 
        labelTagKey.AutoSize = true;
        labelTagKey.Font = new Font("Victor Mono", 7.874999F);
        labelTagKey.Location = new Point(186, 95);
        labelTagKey.Margin = new Padding(2, 0, 2, 0);
        labelTagKey.Name = "labelTagKey";
        labelTagKey.Size = new Size(25, 13);
        labelTagKey.TabIndex = 35;
        labelTagKey.Text = "Key";
        // 
        // textBoxTagName
        // 
        textBoxTagName.Location = new Point(187, 53);
        textBoxTagName.Name = "textBoxTagName";
        textBoxTagName.Size = new Size(214, 30);
        textBoxTagName.TabIndex = 34;
        // 
        // labelTagName
        // 
        labelTagName.AutoSize = true;
        labelTagName.Font = new Font("Victor Mono", 7.874999F);
        labelTagName.Location = new Point(186, 37);
        labelTagName.Margin = new Padding(2, 0, 2, 0);
        labelTagName.Name = "labelTagName";
        labelTagName.Size = new Size(31, 13);
        labelTagName.TabIndex = 33;
        labelTagName.Text = "Name";
        // 
        // labelTagList
        // 
        labelTagList.AutoSize = true;
        labelTagList.Font = new Font("Victor Mono", 15.7499981F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
        labelTagList.Location = new Point(8, 8);
        labelTagList.Name = "labelTagList";
        labelTagList.Size = new Size(56, 26);
        labelTagList.TabIndex = 32;
        labelTagList.Text = "Tags";
        // 
        // listBoxTags
        // 
        listBoxTags.FormattingEnabled = true;
        listBoxTags.ItemHeight = 20;
        listBoxTags.Location = new Point(8, 37);
        listBoxTags.Name = "listBoxTags";
        listBoxTags.Size = new Size(173, 484);
        listBoxTags.TabIndex = 31;
        // 
        // QuestBoard
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1584, 861);
        Controls.Add(tabControlQuestBoard);
        Margin = new Padding(2, 1, 2, 1);
        Name = "QuestBoard";
        Text = "QuestBoard";
        tabControlQuestBoard.ResumeLayout(false);
        tabQuest.ResumeLayout(false);
        tabQuest.PerformLayout();
        groupBoxObjectiveData.ResumeLayout(false);
        groupBoxObjectiveData.PerformLayout();
        groupBoxObjectiveLogs.ResumeLayout(false);
        groupBoxObjectiveLogs.PerformLayout();
        groupBoxFulfillmentData.ResumeLayout(false);
        groupBoxFulfillmentData.PerformLayout();
        groupBoxQuestData.ResumeLayout(false);
        groupBoxQuestData.PerformLayout();
        groupBoxIndiscriminateData.ResumeLayout(false);
        groupBoxIndiscriminateData.PerformLayout();
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
        ((ISupportInitialize)numObjectiveId).EndInit();
        groupBoxCoreData.ResumeLayout(false);
        groupBoxCoreData.PerformLayout();
        ((ISupportInitialize)numRecommendedLevel).EndInit();
        ((ISupportInitialize)numIconIndex).EndInit();
        tabCategories.ResumeLayout(false);
        tabCategories.PerformLayout();
        ((ISupportInitialize)numCategoryIconIndex).EndInit();
        tabTags.ResumeLayout(false);
        tabTags.PerformLayout();
        ((ISupportInitialize)numTagIconIndex).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private TabControl tabControlQuestBoard;
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
    private Label labelCategories;
    private ListBox listBoxCategories;
    private Label labelQuests;
    private TextBox textBoxCategoryKey;
    private Label labelCategoryKey;
    private TextBox textBoxCategoryName;
    private Label labelCategoryName;
    private TextBox textBoxTagKey;
    private Label labelTagKey;
    private TextBox textBoxTagName;
    private Label labelTagName;
    private Label labelTagList;
    private ListBox listBoxTags;
    private Button buttonDeleteCategory;
    private Button buttonAddCategory;
    private Button buttonDeleteTag;
    private Button buttonAddTag;
    private GroupBox groupBoxQuestData;
    private Label labelCategoryIconIndex;
    private NumericUpDown numCategoryIconIndex;
    private Label labelTagIconIndex;
    private NumericUpDown numTagIconIndex;
    private CheckedListBox checkedListBoxQuestTags;
}
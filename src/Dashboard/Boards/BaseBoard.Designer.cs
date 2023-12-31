namespace JMZ.Dashboard.Boards
{
    partial class BaseBoard
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
            button_weapons = new Button();
            button_pickDataPath = new Button();
            folderDialog_dataPath = new FolderBrowserDialog();
            button_saveWeapons = new Button();
            button_saveSkills = new Button();
            button_skills = new Button();
            groupBox_skills = new GroupBox();
            groupBox_weapons = new GroupBox();
            statusStrip_base = new StatusStrip();
            menuStrip_base = new MenuStrip();
            tabControl_plugins = new TabControl();
            tabPage_jabs = new TabPage();
            groupBox_enemies = new GroupBox();
            button_enemies = new Button();
            button_saveEnemies = new Button();
            tabPage_sdp = new TabPage();
            checkBox_sdpSkipSavePopup = new CheckBox();
            button_saveSdps = new Button();
            button_sdps = new Button();
            tabPage_crafting = new TabPage();
            checkBoxSkipCraftingSavePopup = new CheckBox();
            button_saveCrafting = new Button();
            button_recipes = new Button();
            tabPage_difficulties = new TabPage();
            tabPage_proficiencies = new TabPage();
            label_dataPath = new Label();
            groupBox_skills.SuspendLayout();
            groupBox_weapons.SuspendLayout();
            tabControl_plugins.SuspendLayout();
            tabPage_jabs.SuspendLayout();
            groupBox_enemies.SuspendLayout();
            tabPage_sdp.SuspendLayout();
            tabPage_crafting.SuspendLayout();
            SuspendLayout();
            // 
            // button_weapons
            // 
            button_weapons.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            button_weapons.Location = new Point(6, 22);
            button_weapons.Name = "button_weapons";
            button_weapons.Size = new Size(304, 100);
            button_weapons.TabIndex = 0;
            button_weapons.Text = "Modify Weapons";
            button_weapons.UseVisualStyleBackColor = true;
            button_weapons.Click += button_weapons_Click;
            // 
            // button_pickDataPath
            // 
            button_pickDataPath.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            button_pickDataPath.Location = new Point(12, 61);
            button_pickDataPath.Name = "button_pickDataPath";
            button_pickDataPath.Size = new Size(419, 36);
            button_pickDataPath.TabIndex = 1;
            button_pickDataPath.Text = "Choose Data Path";
            button_pickDataPath.UseVisualStyleBackColor = true;
            button_pickDataPath.Click += button_pickDataPath_Click;
            // 
            // button_saveWeapons
            // 
            button_saveWeapons.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            button_saveWeapons.Location = new Point(316, 22);
            button_saveWeapons.Name = "button_saveWeapons";
            button_saveWeapons.Size = new Size(73, 100);
            button_saveWeapons.TabIndex = 2;
            button_saveWeapons.Text = "Save Weapons";
            button_saveWeapons.UseVisualStyleBackColor = true;
            button_saveWeapons.Click += button_saveWeapons_Click;
            // 
            // button_saveSkills
            // 
            button_saveSkills.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            button_saveSkills.Location = new Point(316, 22);
            button_saveSkills.Name = "button_saveSkills";
            button_saveSkills.Size = new Size(73, 100);
            button_saveSkills.TabIndex = 4;
            button_saveSkills.Text = "Save Skills";
            button_saveSkills.UseVisualStyleBackColor = true;
            button_saveSkills.Click += button_saveSkills_Click;
            // 
            // button_skills
            // 
            button_skills.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            button_skills.Location = new Point(6, 22);
            button_skills.Name = "button_skills";
            button_skills.Size = new Size(304, 100);
            button_skills.TabIndex = 3;
            button_skills.Text = "Modify Skills";
            button_skills.UseVisualStyleBackColor = true;
            button_skills.Click += button_skills_Click;
            // 
            // groupBox_skills
            // 
            groupBox_skills.Controls.Add(button_skills);
            groupBox_skills.Controls.Add(button_saveSkills);
            groupBox_skills.Location = new Point(6, 150);
            groupBox_skills.Name = "groupBox_skills";
            groupBox_skills.Size = new Size(395, 136);
            groupBox_skills.TabIndex = 5;
            groupBox_skills.TabStop = false;
            groupBox_skills.Text = "Skills";
            // 
            // groupBox_weapons
            // 
            groupBox_weapons.Controls.Add(button_weapons);
            groupBox_weapons.Controls.Add(button_saveWeapons);
            groupBox_weapons.Location = new Point(6, 6);
            groupBox_weapons.Name = "groupBox_weapons";
            groupBox_weapons.Size = new Size(395, 138);
            groupBox_weapons.TabIndex = 6;
            groupBox_weapons.TabStop = false;
            groupBox_weapons.Text = "Weapons";
            // 
            // statusStrip_base
            // 
            statusStrip_base.Location = new Point(0, 578);
            statusStrip_base.Name = "statusStrip_base";
            statusStrip_base.Size = new Size(447, 22);
            statusStrip_base.TabIndex = 7;
            statusStrip_base.Text = "qwertyboxheroes";
            // 
            // menuStrip_base
            // 
            menuStrip_base.Location = new Point(0, 0);
            menuStrip_base.Name = "menuStrip_base";
            menuStrip_base.Size = new Size(447, 24);
            menuStrip_base.TabIndex = 8;
            menuStrip_base.Text = "Unimplemented Menu";
            // 
            // tabControl_plugins
            // 
            tabControl_plugins.Controls.Add(tabPage_jabs);
            tabControl_plugins.Controls.Add(tabPage_sdp);
            tabControl_plugins.Controls.Add(tabPage_crafting);
            tabControl_plugins.Controls.Add(tabPage_difficulties);
            tabControl_plugins.Controls.Add(tabPage_proficiencies);
            tabControl_plugins.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            tabControl_plugins.Location = new Point(12, 103);
            tabControl_plugins.Name = "tabControl_plugins";
            tabControl_plugins.SelectedIndex = 0;
            tabControl_plugins.Size = new Size(423, 472);
            tabControl_plugins.TabIndex = 9;
            // 
            // tabPage_jabs
            // 
            tabPage_jabs.Controls.Add(groupBox_enemies);
            tabPage_jabs.Controls.Add(groupBox_weapons);
            tabPage_jabs.Controls.Add(groupBox_skills);
            tabPage_jabs.Location = new Point(4, 25);
            tabPage_jabs.Name = "tabPage_jabs";
            tabPage_jabs.Padding = new Padding(3);
            tabPage_jabs.Size = new Size(415, 443);
            tabPage_jabs.TabIndex = 0;
            tabPage_jabs.Text = "JABS";
            tabPage_jabs.UseVisualStyleBackColor = true;
            // 
            // groupBox_enemies
            // 
            groupBox_enemies.Controls.Add(button_enemies);
            groupBox_enemies.Controls.Add(button_saveEnemies);
            groupBox_enemies.Location = new Point(6, 292);
            groupBox_enemies.Name = "groupBox_enemies";
            groupBox_enemies.Size = new Size(395, 136);
            groupBox_enemies.TabIndex = 6;
            groupBox_enemies.TabStop = false;
            groupBox_enemies.Text = "Enemies";
            // 
            // button_enemies
            // 
            button_enemies.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            button_enemies.Location = new Point(6, 22);
            button_enemies.Name = "button_enemies";
            button_enemies.Size = new Size(304, 100);
            button_enemies.TabIndex = 3;
            button_enemies.Text = "Modify Enemies";
            button_enemies.UseVisualStyleBackColor = true;
            button_enemies.Click += button_enemies_Click;
            // 
            // button_saveEnemies
            // 
            button_saveEnemies.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            button_saveEnemies.Location = new Point(316, 22);
            button_saveEnemies.Name = "button_saveEnemies";
            button_saveEnemies.Size = new Size(73, 100);
            button_saveEnemies.TabIndex = 4;
            button_saveEnemies.Text = "Save Enemies";
            button_saveEnemies.UseVisualStyleBackColor = true;
            button_saveEnemies.Click += button_saveEnemies_Click;
            // 
            // tabPage_sdp
            // 
            tabPage_sdp.Controls.Add(checkBox_sdpSkipSavePopup);
            tabPage_sdp.Controls.Add(button_saveSdps);
            tabPage_sdp.Controls.Add(button_sdps);
            tabPage_sdp.Location = new Point(4, 25);
            tabPage_sdp.Name = "tabPage_sdp";
            tabPage_sdp.Padding = new Padding(3);
            tabPage_sdp.Size = new Size(415, 443);
            tabPage_sdp.TabIndex = 1;
            tabPage_sdp.Text = "SDP";
            tabPage_sdp.UseVisualStyleBackColor = true;
            // 
            // checkBox_sdpSkipSavePopup
            // 
            checkBox_sdpSkipSavePopup.Appearance = Appearance.Button;
            checkBox_sdpSkipSavePopup.AutoSize = true;
            checkBox_sdpSkipSavePopup.FlatStyle = FlatStyle.Popup;
            checkBox_sdpSkipSavePopup.Font = new Font("Cascadia Code", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            checkBox_sdpSkipSavePopup.Location = new Point(128, 255);
            checkBox_sdpSkipSavePopup.Name = "checkBox_sdpSkipSavePopup";
            checkBox_sdpSkipSavePopup.Size = new Size(146, 27);
            checkBox_sdpSkipSavePopup.TabIndex = 2;
            checkBox_sdpSkipSavePopup.Text = "Using Save Popup";
            checkBox_sdpSkipSavePopup.UseVisualStyleBackColor = true;
            checkBox_sdpSkipSavePopup.CheckedChanged += checkBox_sdpSkipSavePopup_CheckedChanged;
            // 
            // button_saveSdps
            // 
            button_saveSdps.Location = new Point(128, 145);
            button_saveSdps.Name = "button_saveSdps";
            button_saveSdps.Size = new Size(146, 104);
            button_saveSdps.TabIndex = 1;
            button_saveSdps.Text = "Save Panel Data";
            button_saveSdps.UseVisualStyleBackColor = true;
            button_saveSdps.Click += button_saveSdps_Click;
            // 
            // button_sdps
            // 
            button_sdps.Location = new Point(48, 35);
            button_sdps.Name = "button_sdps";
            button_sdps.Size = new Size(300, 104);
            button_sdps.TabIndex = 0;
            button_sdps.Text = "Configure Panel Data";
            button_sdps.UseVisualStyleBackColor = true;
            button_sdps.Click += button_sdps_Click;
            // 
            // tabPage_crafting
            // 
            tabPage_crafting.Controls.Add(checkBoxSkipCraftingSavePopup);
            tabPage_crafting.Controls.Add(button_saveCrafting);
            tabPage_crafting.Controls.Add(button_recipes);
            tabPage_crafting.Location = new Point(4, 25);
            tabPage_crafting.Name = "tabPage_crafting";
            tabPage_crafting.Size = new Size(415, 443);
            tabPage_crafting.TabIndex = 2;
            tabPage_crafting.Text = "Crafting";
            tabPage_crafting.UseVisualStyleBackColor = true;
            // 
            // checkBoxSkipCraftingSavePopup
            // 
            checkBoxSkipCraftingSavePopup.Appearance = Appearance.Button;
            checkBoxSkipCraftingSavePopup.AutoSize = true;
            checkBoxSkipCraftingSavePopup.FlatStyle = FlatStyle.Popup;
            checkBoxSkipCraftingSavePopup.Font = new Font("Cascadia Code", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            checkBoxSkipCraftingSavePopup.Location = new Point(126, 248);
            checkBoxSkipCraftingSavePopup.Name = "checkBoxSkipCraftingSavePopup";
            checkBoxSkipCraftingSavePopup.Size = new Size(146, 27);
            checkBoxSkipCraftingSavePopup.TabIndex = 4;
            checkBoxSkipCraftingSavePopup.Text = "Using Save Popup";
            checkBoxSkipCraftingSavePopup.UseVisualStyleBackColor = true;
            checkBoxSkipCraftingSavePopup.CheckedChanged += CheckBoxSkipCraftingSavePopupCheckedChanged;
            // 
            // button_saveCrafting
            // 
            button_saveCrafting.Location = new Point(68, 182);
            button_saveCrafting.Name = "button_saveCrafting";
            button_saveCrafting.Size = new Size(281, 60);
            button_saveCrafting.TabIndex = 3;
            button_saveCrafting.Text = "Save ALL Crafting Data";
            button_saveCrafting.UseVisualStyleBackColor = true;
            button_saveCrafting.Click += button_saveCrafting_Click;
            // 
            // button_recipes
            // 
            button_recipes.Location = new Point(30, 19);
            button_recipes.Name = "button_recipes";
            button_recipes.Size = new Size(356, 122);
            button_recipes.TabIndex = 1;
            button_recipes.Text = "Configure Recipe Data";
            button_recipes.UseVisualStyleBackColor = true;
            button_recipes.Click += button_recipes_Click;
            // 
            // tabPage_difficulties
            // 
            tabPage_difficulties.Location = new Point(4, 25);
            tabPage_difficulties.Name = "tabPage_difficulties";
            tabPage_difficulties.Size = new Size(415, 443);
            tabPage_difficulties.TabIndex = 3;
            tabPage_difficulties.Text = "Difficulties";
            tabPage_difficulties.UseVisualStyleBackColor = true;
            // 
            // tabPage_proficiencies
            // 
            tabPage_proficiencies.Location = new Point(4, 25);
            tabPage_proficiencies.Name = "tabPage_proficiencies";
            tabPage_proficiencies.Size = new Size(415, 443);
            tabPage_proficiencies.TabIndex = 4;
            tabPage_proficiencies.Text = "Proficiencies";
            tabPage_proficiencies.UseVisualStyleBackColor = true;
            // 
            // label_dataPath
            // 
            label_dataPath.AutoSize = true;
            label_dataPath.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label_dataPath.Location = new Point(12, 34);
            label_dataPath.Name = "label_dataPath";
            label_dataPath.Size = new Size(14, 16);
            label_dataPath.TabIndex = 10;
            label_dataPath.Text = "_";
            // 
            // BaseBoard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(447, 600);
            Controls.Add(label_dataPath);
            Controls.Add(tabControl_plugins);
            Controls.Add(statusStrip_base);
            Controls.Add(menuStrip_base);
            Controls.Add(button_pickDataPath);
            MainMenuStrip = menuStrip_base;
            Name = "BaseBoard";
            Text = "J-MZ Data Editor";
            groupBox_skills.ResumeLayout(false);
            groupBox_weapons.ResumeLayout(false);
            tabControl_plugins.ResumeLayout(false);
            tabPage_jabs.ResumeLayout(false);
            groupBox_enemies.ResumeLayout(false);
            tabPage_sdp.ResumeLayout(false);
            tabPage_sdp.PerformLayout();
            tabPage_crafting.ResumeLayout(false);
            tabPage_crafting.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button_pickDataPath;
        private FolderBrowserDialog folderDialog_dataPath;
        private Button button_weapons;
        private Button button_saveWeapons;
        private Button button_saveSkills;
        private Button button_skills;
        private GroupBox groupBox_skills;
        private GroupBox groupBox_weapons;
        private StatusStrip statusStrip_base;
        private MenuStrip menuStrip_base;
        private TabControl tabControl_plugins;
        private TabPage tabPage_jabs;
        private TabPage tabPage_sdp;
        private TabPage tabPage_crafting;
        private TabPage tabPage_difficulties;
        private TabPage tabPage_proficiencies;
        private Label label_dataPath;
        private Button button_saveSdps;
        private Button button_sdps;
        private CheckBox checkBox_sdpSkipSavePopup;
        private Button button_recipes;
        private Button button_saveCrafting;
        private CheckBox checkBoxSkipCraftingSavePopup;
        private GroupBox groupBox_enemies;
        private Button button_enemies;
        private Button button_saveEnemies;
    }
}
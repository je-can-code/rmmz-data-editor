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
            statusStrip1 = new StatusStrip();
            menuStrip_base = new MenuStrip();
            tabControl_plugins = new TabControl();
            tabPage_jabs = new TabPage();
            tabPage_sdp = new TabPage();
            button_saveSdps = new Button();
            button_sdps = new Button();
            tabPage_jafting = new TabPage();
            tabPage_diff = new TabPage();
            tabPage_prof = new TabPage();
            label_dataPath = new Label();
            groupBox_skills.SuspendLayout();
            groupBox_weapons.SuspendLayout();
            tabControl_plugins.SuspendLayout();
            tabPage_jabs.SuspendLayout();
            tabPage_sdp.SuspendLayout();
            SuspendLayout();
            // 
            // button_weapons
            // 
            button_weapons.Location = new Point(6, 22);
            button_weapons.Name = "button_weapons";
            button_weapons.Size = new Size(256, 100);
            button_weapons.TabIndex = 0;
            button_weapons.Text = "Weapons";
            button_weapons.UseVisualStyleBackColor = true;
            button_weapons.Click += button_weapons_Click;
            // 
            // button_pickDataPath
            // 
            button_pickDataPath.Location = new Point(12, 61);
            button_pickDataPath.Name = "button_pickDataPath";
            button_pickDataPath.Size = new Size(369, 23);
            button_pickDataPath.TabIndex = 1;
            button_pickDataPath.Text = "Choose Data Path";
            button_pickDataPath.UseVisualStyleBackColor = true;
            button_pickDataPath.Click += button_pickDataPath_Click;
            // 
            // button_saveWeapons
            // 
            button_saveWeapons.Location = new Point(268, 22);
            button_saveWeapons.Name = "button_saveWeapons";
            button_saveWeapons.Size = new Size(73, 100);
            button_saveWeapons.TabIndex = 2;
            button_saveWeapons.Text = "Save Weapons";
            button_saveWeapons.UseVisualStyleBackColor = true;
            button_saveWeapons.Click += button_saveWeapons_Click;
            // 
            // button_saveSkills
            // 
            button_saveSkills.Location = new Point(268, 22);
            button_saveSkills.Name = "button_saveSkills";
            button_saveSkills.Size = new Size(73, 100);
            button_saveSkills.TabIndex = 4;
            button_saveSkills.Text = "Save Skills";
            button_saveSkills.UseVisualStyleBackColor = true;
            button_saveSkills.Click += button_saveSkills_Click;
            // 
            // button_skills
            // 
            button_skills.Location = new Point(6, 22);
            button_skills.Name = "button_skills";
            button_skills.Size = new Size(256, 100);
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
            groupBox_skills.Size = new Size(349, 136);
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
            groupBox_weapons.Size = new Size(349, 138);
            groupBox_weapons.TabIndex = 6;
            groupBox_weapons.TabStop = false;
            groupBox_weapons.Text = "Weapons";
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new Point(0, 435);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(395, 22);
            statusStrip1.TabIndex = 7;
            statusStrip1.Text = "statusStrip1";
            // 
            // menuStrip_base
            // 
            menuStrip_base.Location = new Point(0, 0);
            menuStrip_base.Name = "menuStrip_base";
            menuStrip_base.Size = new Size(395, 24);
            menuStrip_base.TabIndex = 8;
            menuStrip_base.Text = "Unimplemented Menu";
            // 
            // tabControl_plugins
            // 
            tabControl_plugins.Controls.Add(tabPage_jabs);
            tabControl_plugins.Controls.Add(tabPage_sdp);
            tabControl_plugins.Controls.Add(tabPage_jafting);
            tabControl_plugins.Controls.Add(tabPage_diff);
            tabControl_plugins.Controls.Add(tabPage_prof);
            tabControl_plugins.Location = new Point(12, 103);
            tabControl_plugins.Name = "tabControl_plugins";
            tabControl_plugins.SelectedIndex = 0;
            tabControl_plugins.Size = new Size(373, 329);
            tabControl_plugins.TabIndex = 9;
            // 
            // tabPage_jabs
            // 
            tabPage_jabs.Controls.Add(groupBox_weapons);
            tabPage_jabs.Controls.Add(groupBox_skills);
            tabPage_jabs.Location = new Point(4, 24);
            tabPage_jabs.Name = "tabPage_jabs";
            tabPage_jabs.Padding = new Padding(3);
            tabPage_jabs.Size = new Size(365, 301);
            tabPage_jabs.TabIndex = 0;
            tabPage_jabs.Text = "JABS";
            tabPage_jabs.UseVisualStyleBackColor = true;
            // 
            // tabPage_sdp
            // 
            tabPage_sdp.Controls.Add(button_saveSdps);
            tabPage_sdp.Controls.Add(button_sdps);
            tabPage_sdp.Location = new Point(4, 24);
            tabPage_sdp.Name = "tabPage_sdp";
            tabPage_sdp.Padding = new Padding(3);
            tabPage_sdp.Size = new Size(365, 301);
            tabPage_sdp.TabIndex = 1;
            tabPage_sdp.Text = "SDP";
            tabPage_sdp.UseVisualStyleBackColor = true;
            // 
            // button_saveSdps
            // 
            button_saveSdps.Location = new Point(131, 170);
            button_saveSdps.Name = "button_saveSdps";
            button_saveSdps.Size = new Size(88, 104);
            button_saveSdps.TabIndex = 1;
            button_saveSdps.Text = "Save Panels";
            button_saveSdps.UseVisualStyleBackColor = true;
            button_saveSdps.Click += button_saveSdps_Click;
            // 
            // button_sdps
            // 
            button_sdps.Location = new Point(48, 35);
            button_sdps.Name = "button_sdps";
            button_sdps.Size = new Size(259, 104);
            button_sdps.TabIndex = 0;
            button_sdps.Text = "Configure Panels";
            button_sdps.UseVisualStyleBackColor = true;
            button_sdps.Click += button_sdps_Click;
            // 
            // tabPage_jafting
            // 
            tabPage_jafting.Location = new Point(4, 24);
            tabPage_jafting.Name = "tabPage_jafting";
            tabPage_jafting.Size = new Size(365, 301);
            tabPage_jafting.TabIndex = 2;
            tabPage_jafting.Text = "Jafting";
            tabPage_jafting.UseVisualStyleBackColor = true;
            // 
            // tabPage_diff
            // 
            tabPage_diff.Location = new Point(4, 24);
            tabPage_diff.Name = "tabPage_diff";
            tabPage_diff.Size = new Size(365, 301);
            tabPage_diff.TabIndex = 3;
            tabPage_diff.Text = "Difficulties";
            tabPage_diff.UseVisualStyleBackColor = true;
            // 
            // tabPage_prof
            // 
            tabPage_prof.Location = new Point(4, 24);
            tabPage_prof.Name = "tabPage_prof";
            tabPage_prof.Size = new Size(365, 301);
            tabPage_prof.TabIndex = 4;
            tabPage_prof.Text = "Proficiencies";
            tabPage_prof.UseVisualStyleBackColor = true;
            // 
            // label_dataPath
            // 
            label_dataPath.AutoSize = true;
            label_dataPath.Location = new Point(12, 34);
            label_dataPath.Name = "label_dataPath";
            label_dataPath.Size = new Size(38, 15);
            label_dataPath.TabIndex = 10;
            label_dataPath.Text = "label1";
            // 
            // BaseBoard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(395, 457);
            Controls.Add(label_dataPath);
            Controls.Add(tabControl_plugins);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip_base);
            Controls.Add(button_pickDataPath);
            MainMenuStrip = menuStrip_base;
            Name = "BaseBoard";
            Text = "BaseBoard";
            groupBox_skills.ResumeLayout(false);
            groupBox_weapons.ResumeLayout(false);
            tabControl_plugins.ResumeLayout(false);
            tabPage_jabs.ResumeLayout(false);
            tabPage_sdp.ResumeLayout(false);
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
        private StatusStrip statusStrip1;
        private MenuStrip menuStrip_base;
        private TabControl tabControl_plugins;
        private TabPage tabPage_jabs;
        private TabPage tabPage_sdp;
        private TabPage tabPage_jafting;
        private TabPage tabPage_diff;
        private TabPage tabPage_prof;
        private Label label_dataPath;
        private Button button_saveSdps;
        private Button button_sdps;
    }
}
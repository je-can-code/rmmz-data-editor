namespace Dashboard.Boards
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
            groupBox_skills.SuspendLayout();
            groupBox_weapons.SuspendLayout();
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
            button_pickDataPath.Location = new Point(4, 387);
            button_pickDataPath.Name = "button_pickDataPath";
            button_pickDataPath.Size = new Size(349, 23);
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
            groupBox_skills.Location = new Point(12, 171);
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
            groupBox_weapons.Location = new Point(12, 27);
            groupBox_weapons.Name = "groupBox_weapons";
            groupBox_weapons.Size = new Size(349, 138);
            groupBox_weapons.TabIndex = 6;
            groupBox_weapons.TabStop = false;
            groupBox_weapons.Text = "Weapons";
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new Point(0, 424);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(373, 22);
            statusStrip1.TabIndex = 7;
            statusStrip1.Text = "statusStrip1";
            // 
            // menuStrip_base
            // 
            menuStrip_base.Location = new Point(0, 0);
            menuStrip_base.Name = "menuStrip_base";
            menuStrip_base.Size = new Size(373, 24);
            menuStrip_base.TabIndex = 8;
            menuStrip_base.Text = "Unimplemented Menu";
            // 
            // BaseBoard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(373, 446);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip_base);
            Controls.Add(groupBox_weapons);
            Controls.Add(groupBox_skills);
            Controls.Add(button_pickDataPath);
            MainMenuStrip = menuStrip_base;
            Name = "BaseBoard";
            Text = "BaseBoard";
            groupBox_skills.ResumeLayout(false);
            groupBox_weapons.ResumeLayout(false);
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
    }
}
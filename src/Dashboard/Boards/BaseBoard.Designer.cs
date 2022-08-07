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
            this.button_weapons = new System.Windows.Forms.Button();
            this.button_pickDataPath = new System.Windows.Forms.Button();
            this.folderDialog_dataPath = new System.Windows.Forms.FolderBrowserDialog();
            this.button_saveWeapons = new System.Windows.Forms.Button();
            this.button_saveSkills = new System.Windows.Forms.Button();
            this.button_skills = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_weapon
            // 
            this.button_weapons.Location = new System.Drawing.Point(12, 41);
            this.button_weapons.Name = "button_weapons";
            this.button_weapons.Size = new System.Drawing.Size(68, 61);
            this.button_weapons.TabIndex = 0;
            this.button_weapons.Text = "Weapons";
            this.button_weapons.UseVisualStyleBackColor = true;
            this.button_weapons.Click += new System.EventHandler(this.button_weapons_Click);
            // 
            // btn_pickDataPath
            // 
            this.button_pickDataPath.Location = new System.Drawing.Point(12, 12);
            this.button_pickDataPath.Name = "button_pickDataPath";
            this.button_pickDataPath.Size = new System.Drawing.Size(520, 23);
            this.button_pickDataPath.TabIndex = 1;
            this.button_pickDataPath.Text = "Choose Data Path";
            this.button_pickDataPath.UseVisualStyleBackColor = true;
            this.button_pickDataPath.Click += new System.EventHandler(this.button_pickDataPath_Click);
            // 
            // button_saveWeapons
            // 
            this.button_saveWeapons.Location = new System.Drawing.Point(12, 108);
            this.button_saveWeapons.Name = "button_saveWeapons";
            this.button_saveWeapons.Size = new System.Drawing.Size(68, 38);
            this.button_saveWeapons.TabIndex = 2;
            this.button_saveWeapons.Text = "Save Weapons";
            this.button_saveWeapons.UseVisualStyleBackColor = true;
            this.button_saveWeapons.Click += new System.EventHandler(this.button_saveWeapons_Click);
            // 
            // button_saveSkills
            // 
            this.button_saveSkills.Location = new System.Drawing.Point(121, 108);
            this.button_saveSkills.Name = "button_saveSkills";
            this.button_saveSkills.Size = new System.Drawing.Size(68, 38);
            this.button_saveSkills.TabIndex = 4;
            this.button_saveSkills.Text = "Save Skills";
            this.button_saveSkills.UseVisualStyleBackColor = true;
            this.button_saveSkills.Click += new System.EventHandler(this.button_saveSkills_Click);
            // 
            // button_skills
            // 
            this.button_skills.Location = new System.Drawing.Point(121, 41);
            this.button_skills.Name = "button_skills";
            this.button_skills.Size = new System.Drawing.Size(68, 61);
            this.button_skills.TabIndex = 3;
            this.button_skills.Text = "Skills";
            this.button_skills.UseVisualStyleBackColor = true;
            this.button_skills.Click += new System.EventHandler(this.button_skills_Click);
            // 
            // BaseBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 400);
            this.Controls.Add(this.button_saveSkills);
            this.Controls.Add(this.button_skills);
            this.Controls.Add(this.button_saveWeapons);
            this.Controls.Add(this.button_pickDataPath);
            this.Controls.Add(this.button_weapons);
            this.Name = "BaseBoard";
            this.Text = "BaseBoard";
            this.ResumeLayout(false);

        }

        #endregion

        private Button button_pickDataPath;
        private FolderBrowserDialog folderDialog_dataPath;
        private Button button_weapons;
        private Button button_saveWeapons;
        private Button button_saveSkills;
        private Button button_skills;
    }
}
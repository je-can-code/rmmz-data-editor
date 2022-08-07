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
            this.btn_weapon = new System.Windows.Forms.Button();
            this.btn_pickDataPath = new System.Windows.Forms.Button();
            this.folderDialog_dataPath = new System.Windows.Forms.FolderBrowserDialog();
            this.button_save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_weapon
            // 
            this.btn_weapon.Location = new System.Drawing.Point(12, 41);
            this.btn_weapon.Name = "btn_weapon";
            this.btn_weapon.Size = new System.Drawing.Size(68, 61);
            this.btn_weapon.TabIndex = 0;
            this.btn_weapon.Text = "Weapons";
            this.btn_weapon.UseVisualStyleBackColor = true;
            this.btn_weapon.Click += new System.EventHandler(this.btn_weapon_Click);
            // 
            // btn_pickDataPath
            // 
            this.btn_pickDataPath.Location = new System.Drawing.Point(12, 12);
            this.btn_pickDataPath.Name = "btn_pickDataPath";
            this.btn_pickDataPath.Size = new System.Drawing.Size(520, 23);
            this.btn_pickDataPath.TabIndex = 1;
            this.btn_pickDataPath.Text = "Choose Data Path";
            this.btn_pickDataPath.UseVisualStyleBackColor = true;
            this.btn_pickDataPath.Click += new System.EventHandler(this.btn_pickDataPath_Click);
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(12, 108);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(68, 38);
            this.button_save.TabIndex = 2;
            this.button_save.Text = "Save Weapons";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // BaseBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 400);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.btn_pickDataPath);
            this.Controls.Add(this.btn_weapon);
            this.Name = "BaseBoard";
            this.Text = "BaseBoard";
            this.ResumeLayout(false);

        }

        #endregion

        private Button btn_weapon;
        private Button btn_pickDataPath;
        private FolderBrowserDialog folderDialog_dataPath;
        private Button button_save;
    }
}
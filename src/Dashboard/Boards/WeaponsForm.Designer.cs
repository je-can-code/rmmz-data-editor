namespace Dashboard
{
    partial class WeaponsForm
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
            this.components = new System.ComponentModel.Container();
            this.listWeapons = new System.Windows.Forms.ListBox();
            this.textBox_weaponName = new System.Windows.Forms.TextBox();
            this.weaponBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label_weaponName = new System.Windows.Forms.Label();
            this.label_weaponId = new System.Windows.Forms.Label();
            this.label_weaponIdValue = new System.Windows.Forms.Label();
            this.label_weaponSkillId = new System.Windows.Forms.Label();
            this.num_weaponSkillId = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.weaponBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_weaponSkillId)).BeginInit();
            this.SuspendLayout();
            // 
            // listWeapons
            // 
            this.listWeapons.FormattingEnabled = true;
            this.listWeapons.ItemHeight = 15;
            this.listWeapons.Location = new System.Drawing.Point(12, 12);
            this.listWeapons.Name = "listWeapons";
            this.listWeapons.Size = new System.Drawing.Size(192, 484);
            this.listWeapons.TabIndex = 0;
            // 
            // textBox_weaponName
            // 
            this.textBox_weaponName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.weaponBindingSource, "name", true));
            this.textBox_weaponName.Location = new System.Drawing.Point(210, 57);
            this.textBox_weaponName.Name = "textBox_weaponName";
            this.textBox_weaponName.Size = new System.Drawing.Size(195, 23);
            this.textBox_weaponName.TabIndex = 1;
            // 
            // weaponBindingSource
            // 
            this.weaponBindingSource.DataSource = typeof(Dashboard.Models.RPG_Weapon);
            // 
            // label_weaponName
            // 
            this.label_weaponName.AutoSize = true;
            this.label_weaponName.Location = new System.Drawing.Point(210, 39);
            this.label_weaponName.Name = "label_weaponName";
            this.label_weaponName.Size = new System.Drawing.Size(39, 15);
            this.label_weaponName.TabIndex = 2;
            this.label_weaponName.Text = "Name";
            // 
            // label_weaponId
            // 
            this.label_weaponId.AutoSize = true;
            this.label_weaponId.Location = new System.Drawing.Point(210, 12);
            this.label_weaponId.Name = "label_weaponId";
            this.label_weaponId.Size = new System.Drawing.Size(17, 15);
            this.label_weaponId.TabIndex = 4;
            this.label_weaponId.Text = "Id";
            // 
            // label_weaponIdValue
            // 
            this.label_weaponIdValue.AutoSize = true;
            this.label_weaponIdValue.Location = new System.Drawing.Point(233, 12);
            this.label_weaponIdValue.Name = "label_weaponIdValue";
            this.label_weaponIdValue.Size = new System.Drawing.Size(25, 15);
            this.label_weaponIdValue.TabIndex = 5;
            this.label_weaponIdValue.Text = "n/a";
            // 
            // label_weaponSkillId
            // 
            this.label_weaponSkillId.AutoSize = true;
            this.label_weaponSkillId.Location = new System.Drawing.Point(210, 100);
            this.label_weaponSkillId.Name = "label_weaponSkillId";
            this.label_weaponSkillId.Size = new System.Drawing.Size(78, 15);
            this.label_weaponSkillId.TabIndex = 6;
            this.label_weaponSkillId.Text = "Attack Skill Id";
            // 
            // num_weaponSkillId
            // 
            this.num_weaponSkillId.Location = new System.Drawing.Point(210, 118);
            this.num_weaponSkillId.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.num_weaponSkillId.Name = "num_weaponSkillId";
            this.num_weaponSkillId.Size = new System.Drawing.Size(78, 23);
            this.num_weaponSkillId.TabIndex = 7;
            this.num_weaponSkillId.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // WeaponsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 511);
            this.Controls.Add(this.num_weaponSkillId);
            this.Controls.Add(this.label_weaponSkillId);
            this.Controls.Add(this.label_weaponIdValue);
            this.Controls.Add(this.label_weaponId);
            this.Controls.Add(this.label_weaponName);
            this.Controls.Add(this.textBox_weaponName);
            this.Controls.Add(this.listWeapons);
            this.Name = "WeaponsForm";
            this.Text = "WeaponsForm";
            ((System.ComponentModel.ISupportInitialize)(this.weaponBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_weaponSkillId)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox listWeapons;
        private TextBox textBox_weaponName;
        private BindingSource weaponBindingSource;
        private Label label_weaponName;
        private Label label_weaponId;
        private Label label_weaponIdValue;
        private Label label_weaponSkillId;
        private NumericUpDown num_weaponSkillId;
    }
}
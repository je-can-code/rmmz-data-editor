using JMZ.Rmmz.Data.Models.db.implementations;

namespace JMZ.Dashboard.Boards
{
    partial class WeaponsBoard
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
            components = new System.ComponentModel.Container();
            listBoxWeapons = new ListBox();
            textBox_weaponName = new TextBox();
            weaponBindingSource = new BindingSource(components);
            label_weaponName = new Label();
            label_weaponId = new Label();
            label_weaponIdValue = new Label();
            label_weaponSkillId = new Label();
            num_weaponSkillId = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)weaponBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num_weaponSkillId).BeginInit();
            SuspendLayout();
            // 
            // listBoxWeapons
            // 
            listBoxWeapons.Font = new Font("Victor Mono SemiBold", 10.124999F, FontStyle.Bold, GraphicsUnit.Point);
            listBoxWeapons.FormattingEnabled = true;
            listBoxWeapons.ItemHeight = 33;
            listBoxWeapons.Location = new Point(22, 26);
            listBoxWeapons.Margin = new Padding(6, 6, 6, 6);
            listBoxWeapons.Name = "listBoxWeapons";
            listBoxWeapons.Size = new Size(353, 1027);
            listBoxWeapons.TabIndex = 0;
            // 
            // textBox_weaponName
            // 
            textBox_weaponName.DataBindings.Add(new Binding("Text", weaponBindingSource, "name", true));
            textBox_weaponName.Location = new Point(390, 122);
            textBox_weaponName.Margin = new Padding(6, 6, 6, 6);
            textBox_weaponName.Name = "textBox_weaponName";
            textBox_weaponName.Size = new Size(359, 39);
            textBox_weaponName.TabIndex = 1;
            // 
            // weaponBindingSource
            // 
            weaponBindingSource.DataSource = typeof(RPG_Weapon);
            // 
            // label_weaponName
            // 
            label_weaponName.AutoSize = true;
            label_weaponName.Location = new Point(390, 83);
            label_weaponName.Margin = new Padding(6, 0, 6, 0);
            label_weaponName.Name = "label_weaponName";
            label_weaponName.Size = new Size(78, 32);
            label_weaponName.TabIndex = 2;
            label_weaponName.Text = "Name";
            // 
            // label_weaponId
            // 
            label_weaponId.AutoSize = true;
            label_weaponId.Location = new Point(390, 26);
            label_weaponId.Margin = new Padding(6, 0, 6, 0);
            label_weaponId.Name = "label_weaponId";
            label_weaponId.Size = new Size(34, 32);
            label_weaponId.TabIndex = 4;
            label_weaponId.Text = "Id";
            // 
            // label_weaponIdValue
            // 
            label_weaponIdValue.AutoSize = true;
            label_weaponIdValue.Location = new Point(433, 26);
            label_weaponIdValue.Margin = new Padding(6, 0, 6, 0);
            label_weaponIdValue.Name = "label_weaponIdValue";
            label_weaponIdValue.Size = new Size(49, 32);
            label_weaponIdValue.TabIndex = 5;
            label_weaponIdValue.Text = "n/a";
            // 
            // label_weaponSkillId
            // 
            label_weaponSkillId.AutoSize = true;
            label_weaponSkillId.Location = new Point(390, 213);
            label_weaponSkillId.Margin = new Padding(6, 0, 6, 0);
            label_weaponSkillId.Name = "label_weaponSkillId";
            label_weaponSkillId.Size = new Size(157, 32);
            label_weaponSkillId.TabIndex = 6;
            label_weaponSkillId.Text = "Attack Skill Id";
            // 
            // num_weaponSkillId
            // 
            num_weaponSkillId.Location = new Point(390, 252);
            num_weaponSkillId.Margin = new Padding(6, 6, 6, 6);
            num_weaponSkillId.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
            num_weaponSkillId.Name = "num_weaponSkillId";
            num_weaponSkillId.Size = new Size(145, 39);
            num_weaponSkillId.TabIndex = 7;
            num_weaponSkillId.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // WeaponsBoard
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1976, 1090);
            Controls.Add(num_weaponSkillId);
            Controls.Add(label_weaponSkillId);
            Controls.Add(label_weaponIdValue);
            Controls.Add(label_weaponId);
            Controls.Add(label_weaponName);
            Controls.Add(textBox_weaponName);
            Controls.Add(listBoxWeapons);
            Margin = new Padding(6, 6, 6, 6);
            Name = "WeaponsBoard";
            Text = "Weapon Data";
            ((System.ComponentModel.ISupportInitialize)weaponBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)num_weaponSkillId).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBoxWeapons;
        private TextBox textBox_weaponName;
        private BindingSource weaponBindingSource;
        private Label label_weaponName;
        private Label label_weaponId;
        private Label label_weaponIdValue;
        private Label label_weaponSkillId;
        private NumericUpDown num_weaponSkillId;
    }
}
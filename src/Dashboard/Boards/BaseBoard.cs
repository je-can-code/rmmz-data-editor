using Dashboard.Services;

namespace Dashboard.Boards;

public partial class BaseBoard : Form
{
    private readonly WeaponsForm weaponsForm;
    private readonly SkillsForm skillsForm;

    private string projectPath = @"D:\dev\code\gaming\ca\chef-adventure\data";//String.Empty;

    public BaseBoard()
    {
        InitializeComponent();
        this.weaponsForm = new();
        this.skillsForm = new();
    }

    private void ShowBaseBoard(object? sender, FormClosingEventArgs e)
    {
        if (e.CloseReason == CloseReason.UserClosing)
        {
            e.Cancel = true;
            this.weaponsForm.Hide();
            this.skillsForm.Hide();
        }

        this.Show();
    }

    private void button_pickDataPath_Click(object sender, EventArgs e)
    {
        var dialogResult = folderDialog_dataPath.ShowDialog();
        if (dialogResult == DialogResult.OK)
        {
            if (this.projectPath != folderDialog_dataPath.SelectedPath)
            {
                this.weaponsForm.FlagForRefresh();
            }

            this.projectPath = folderDialog_dataPath.SelectedPath;
        }
    }

    private void button_weapons_Click(object sender, EventArgs e)
    {
        var baseWeaponsList = JsonLoaderService.LoadWeapons(this.projectPath);
        this.weaponsForm.FormClosing += this.ShowBaseBoard;
        this.weaponsForm.Show();
        this.weaponsForm.Setup(baseWeaponsList);
    }
    
    private async void button_saveWeapons_Click(object sender, EventArgs e)
    {
        var dialogResult = MessageBox.Show("Are you sure you want to save weapons?");
        if (dialogResult == DialogResult.OK)
        {
            var updatedWeapons = this.weaponsForm.Weapons();
            await JsonSavingService.SaveWeapons(projectPath, updatedWeapons);
            MessageBox.Show("Saving has completed successfully.");
        }
        else
        {
            MessageBox.Show("Edits were not lost. Hit the 'save weapons' button again to be prompted again.");
        }
    }
    
    private void button_skills_Click(object sender, EventArgs e)
    {
        var dataList = JsonLoaderService.LoadSkills(this.projectPath);
        this.skillsForm.FormClosing += this.ShowBaseBoard;
        this.skillsForm.Show();
        this.skillsForm.Setup(dataList);
    }

    private async void button_saveSkills_Click(object sender, EventArgs e)
    {
        var dialogResult = MessageBox.Show("Are you sure you want to save skills?");
        if (dialogResult == DialogResult.OK)
        {
            var updated = this.skillsForm.Skills();
            await JsonSavingService.SaveSkills(projectPath, updated);
            MessageBox.Show("Saving has completed successfully.");
        }
        else
        {
            MessageBox.Show("Edits were not lost. Hit the 'save skills' button again to be prompted again.");
        }
    }
}

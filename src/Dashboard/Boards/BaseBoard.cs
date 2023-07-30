using JMZ.Dashboard.Services;

namespace JMZ.Dashboard.Boards;

public partial class BaseBoard : Form
{
    private readonly WeaponsBoard weaponsBoard;
    private readonly SkillsBoard skillsBoard;

    private string projectPath = @"D:\dev\gaming\ca\chef-adventure\data";//String.Empty;

    public BaseBoard()
    {
        InitializeComponent();
        this.weaponsBoard = new();
        this.skillsBoard = new();
    }

    private void ShowBaseBoard(object? sender, FormClosingEventArgs e)
    {
        if (e.CloseReason == CloseReason.UserClosing)
        {
            e.Cancel = true;
            this.HideSubBoards();
        }

        this.Show();
    }

    private void HideSubBoards()
    {
        this.weaponsBoard.Hide();
        this.skillsBoard.Hide();
    }

    private void button_pickDataPath_Click(object sender, EventArgs e)
    {
        var dialogResult = folderDialog_dataPath.ShowDialog();
        if (dialogResult != DialogResult.OK) return;

        if (this.projectPath != folderDialog_dataPath.SelectedPath)
        {
            this.weaponsBoard.FlagForRefresh();
        }

        this.projectPath = folderDialog_dataPath.SelectedPath;
    }

    private void button_weapons_Click(object sender, EventArgs e)
    {
        var baseWeaponsList = JsonLoaderService.LoadWeapons(this.projectPath);
        this.weaponsBoard.FormClosing += this.ShowBaseBoard;
        this.weaponsBoard.Show();
        this.weaponsBoard.Setup(baseWeaponsList);
    }

    private async void button_saveWeapons_Click(object sender, EventArgs e)
    {
        var dialogResult = MessageBox.Show("Are you sure you want to save weapons?");
        if (dialogResult == DialogResult.OK)
        {
            var updatedWeapons = this.weaponsBoard.Weapons();
            await JsonSavingService.SaveWeapons(this.projectPath, updatedWeapons);
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
        this.skillsBoard.FormClosing += this.ShowBaseBoard;
        this.skillsBoard.Show();
        this.skillsBoard.Setup(dataList);
    }

    private async void button_saveSkills_Click(object sender, EventArgs e)
    {
        var dialogResult = MessageBox.Show("Are you sure you want to save skills?");
        if (dialogResult == DialogResult.OK)
        {
            var updated = this.skillsBoard.Skills();
            await JsonSavingService.SaveSkills(this.projectPath, updated);
            MessageBox.Show("Saving has completed successfully.");
        }
        else
        {
            MessageBox.Show("Edits were not lost. Hit the 'save skills' button again to be prompted again.");
        }
    }
}

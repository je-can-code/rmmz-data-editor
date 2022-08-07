using Dashboard.Services;

namespace Dashboard.Boards;

public partial class BaseBoard : Form
{
    private readonly WeaponsForm weaponsForm;

    private string projectPath = @"D:\dev\code\gaming\ca\chef-adventure\data";//String.Empty;

    public BaseBoard()
    {
        InitializeComponent();
        this.weaponsForm = new();
    }

    private void btn_weapon_Click(object sender, EventArgs e)
    {
        var baseWeaponsList = JsonLoaderService.LoadWeapons(this.projectPath);
        this.weaponsForm.FormClosing += this.ShowBaseBoard;
        this.weaponsForm.Show();
        this.weaponsForm.Setup(baseWeaponsList);
    }

    private void ShowBaseBoard(object? sender, FormClosingEventArgs e)
    {
        if (e.CloseReason == CloseReason.UserClosing)
        {
            e.Cancel = true;
            this.weaponsForm.Hide();
        }

        this.Show();
    }

    private void btn_pickDataPath_Click(object sender, EventArgs e)
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

    private async void button_save_Click(object sender, EventArgs e)
    {
        var dialogResult = MessageBox.Show("Are you sure you want to save weapons?");
        if (dialogResult == DialogResult.OK)
        {
            var updatedWeapons = this.weaponsForm.Weapons();
            await JsonLoaderService.SaveWeapons(projectPath, updatedWeapons);
        }
        else
        {
            MessageBox.Show("Edits were not lost. Hit the 'save weapons' button again to be prompted again.");
        }
    }
}

using JMZ.Dashboard.Services;

namespace JMZ.Dashboard.Boards;

public partial class BaseBoard : Form
{
    private readonly WeaponsBoard weaponsBoard;

    private readonly SkillsBoard skillsBoard;

    private readonly SdpBoard sdpBoard;

    private string projectPath = @"D:\dev\gaming\rmmz-plugins\project\data";

    private bool skipSdpSavePopup = false;

    public BaseBoard()
    {
        InitializeComponent();
        this.StartPosition = FormStartPosition.Manual;
        var x = Screen.PrimaryScreen!.Bounds.Width / 2 - this.Width;
        var y = Screen.PrimaryScreen!.Bounds.Height / 2 - this.Height;
        this.Location = new(x, y);

        this.weaponsBoard = new();
        this.skillsBoard = new();
        this.sdpBoard = new();

        this.SynchronizeProjectDataPath();
    }

    private void SynchronizeProjectDataPath()
    {
        this.label_dataPath.Text = this.projectPath;
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
        this.sdpBoard.Hide();
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
        this.SynchronizeProjectDataPath();
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

    private void button_sdps_Click(object sender, EventArgs e)
    {
        this.sdpBoard.FormClosing += this.ShowBaseBoard;

        var configPath = JsonLoaderService.sdpDataPath(this.projectPath);
        var isConfigPresent = JsonLoaderService.IsConfigPresent(configPath);
        if (!isConfigPresent)
        {
            var dialogResult = MessageBox.Show(
                "No SDP configuration was detected. Create a new config?",
                "SDP Configuration Data Missing",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation);
            if (dialogResult == DialogResult.Yes)
            {
                File.WriteAllText(configPath, "[]");
                MessageBox.Show("Empty SDP configuration has been written.");
            }
            else
            {
                MessageBox.Show(
                    "Without SDP configuration data, you cannot modify the SDP configuration data.");
                return;
            }
        }

        var dataList = JsonLoaderService.LoadSdps(this.projectPath);
        this.sdpBoard.Setup(dataList);

        var x = this.Right;
        var y = Screen.PrimaryScreen!.Bounds.Height / 2 - this.Height;
        this.sdpBoard.Show();
        this.sdpBoard.SetDesktopLocation(x, y);
    }

    private async void button_saveSdps_Click(object sender, EventArgs e)
    {
        if (this.sdpBoard.needsSetup)
        {
            var message = """
                          SDP configuration data cannot be saved before being initialized.
                          Please click the 'Configure Panel Data' button to load the current data first.
                          """;
            MessageBox.Show(
                message,
                "No SDP Configuration Data Loaded",
                MessageBoxButtons.OK);
            return;
        }
        
        if (this.skipSdpSavePopup)
        {
            await this.saveSdps();
            return;
        }

        var dialogResult = MessageBox.Show(
            "Are you sure you want to save SDPs?",
            "Save SDP Configuration Data",
            MessageBoxButtons.YesNo);
        if (dialogResult == DialogResult.Yes)
        {
            await this.saveSdps();
            MessageBox.Show("Saving has completed successfully.");
        }
        else
        {
            MessageBox.Show(
                "Edits were not lost. Hit the 'save skills' button again to be prompted again.");
        }
    }

    private async Task saveSdps()
    {
        // update the tracked stuff to saved stuff.
        this.sdpBoard.TrackedToSavedSdps();
        
        // grab the updated save data.
        var updated = this.sdpBoard.Sdps();
        
        // record the newly updated data to disk.
        await JsonSavingService.SaveSdps(this.projectPath, updated);
        
        // flag our status strip.
        this.statusStrip_base.Text = "Updated SDP configuration data.";
        this.statusStrip_base.Refresh();
    }


    private void checkBox_sdpSkipSavePopup_CheckedChanged(object sender, EventArgs e)
    {
        this.skipSdpSavePopup = this.checkBox_sdpSkipSavePopup.Checked;
        this.checkBox_sdpSkipSavePopup.Text = this.checkBox_sdpSkipSavePopup.Checked
            ? "Just doing it ✅"
            : "Using Save Popup";
    }
}

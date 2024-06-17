using JMZ.Dashboard.Utils;
using JMZ.Json.Data.Services;
using JMZ.Sdp.Data;

namespace JMZ.Dashboard.Boards;

public partial class BaseBoard
{
    /// <summary>
    /// The board that primarily handles SDP design.
    /// </summary>
    private readonly SdpBoard sdpBoard = new();

    /// <summary>
    /// When true, the prompt for skipping the prompt when saving SDP data.
    /// When false, the confirmation popup will show.
    /// </summary>
    private bool skipSdpSavePopup;
    
    private partial void SetupSdpBoard()
    {
        this.sdpBoard.FormClosing += FormUtils.HideBoard;
    }

    private async void button_sdps_Click(object sender, EventArgs e)
    {
        // check if we can load the board based on the required config.
        var canLoadBoard = await FormUtils.ValidateConfiguration(
            this.projectPath,
            JsonLoaderService.sdpDataPath(this.projectPath),
            SdpInitializer.InitializeConfiguration);

        // validate we are able to load the board.
        if (canLoadBoard is false) return;

        // initialize the data for the board.
        var data = JsonLoaderService.LoadSdps(this.projectPath);
        this.sdpBoard.Setup(data);

        // show the window.
        this.sdpBoard.Show();

        // relocate the window to where we want it to be.
        var x = this.Right;
        var y = Screen.PrimaryScreen!.Bounds.Height / 2 - this.Height / 2;
        this.sdpBoard.SetDesktopLocation(x, y);
    }

    private async void button_saveSdps_Click(object sender, EventArgs e)
    {
        // check if the board hasn't been setup yet, or is in need of a refresh first.
        if (this.sdpBoard.needsSetup)
        {
            MessageBox.Show(
                """
                SDP configuration data needs initialization.
                Please click the 'Configure Panel Data' button to load the current data first.
                """,
                "SDP Configuration Data Needs Initialization",
                MessageBoxButtons.OK);
            return;
        }

        // check if we're skipping the popup dialogue to confirm saving.
        if (this.skipSdpSavePopup)
        {
            // just save.
            await this.saveSdps();
            return;
        }

        // ask the user to confirm they want to save.
        var dialogResult = MessageBox.Show(
            "Are you sure you want to save SDPs?",
            "Save SDP Configuration Data",
            MessageBoxButtons.YesNo);

        // pivot on what the user chooses.
        switch (dialogResult)
        {
            // check if the user agreed.
            case DialogResult.Yes:
                // then save.
                await this.saveSdps();
                MessageBox.Show("Saving has completed successfully.");
                break;
            // the user didn't hit YES.
            default:
                MessageBox.Show("Edits were not lost. Hit the 'save skills' button again to be prompted again.");
                break;
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
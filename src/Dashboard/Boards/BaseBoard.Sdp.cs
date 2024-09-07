using JMZ.Dashboard.Utils;
using JMZ.Json.Data.Services;
using JMZ.Sdp.Data;

namespace JMZ.Dashboard.Boards;

public partial class BaseBoard
{
    /// <summary>
    ///     The board that primarily handles SDP design.
    /// </summary>
    private readonly SdpBoard sdpBoard = new();

    /// <summary>
    ///     When true, the prompt for skipping the prompt when saving SDP data.
    ///     When false, the confirmation popup will show.
    /// </summary>
    private bool skipSdpSavePopup;

    private partial void SetupSdpBoard()
    {
        sdpBoard.FormClosing += FormUtils.HideBoard;
    }

    private async void button_sdps_Click(object sender, EventArgs e)
    {
        // check if we can load the board based on the required config.
        var canLoadBoard = await FormUtils.ValidateConfiguration(
            _projectPath,
            JsonLoaderService.SdpDataPath(_projectPath),
            SdpInitializer.InitializeConfiguration);

        // validate we are able to load the board.
        if (canLoadBoard is false) return;

        // initialize the data for the board.
        var data = JsonLoaderService.LoadSdps(_projectPath);
        sdpBoard.Setup(data);

        // show the window.
        sdpBoard.Show();

        // relocate the window to where we want it to be.
        var x = Right;
        var y = Screen.PrimaryScreen!.Bounds.Height / 2 - Height / 2;
        sdpBoard.SetDesktopLocation(x, y);
    }

    private async void button_saveSdps_Click(object sender, EventArgs e)
    {
        // check if the board hasn't been setup yet, or is in need of a refresh first.
        if (sdpBoard.needsSetup)
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
        if (skipSdpSavePopup)
        {
            // just save.
            await saveSdps();
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
                await saveSdps();
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
        sdpBoard.TrackedToSavedSdps();

        // grab the updated save data.
        var updated = sdpBoard.Sdps();

        // record the newly updated data to disk.
        await JsonSavingService.SaveSdps(_projectPath, updated);

        // flag our status strip.
        statusStrip_base.Text = "Updated SDP configuration data.";
        statusStrip_base.Refresh();
    }

    private void checkBox_sdpSkipSavePopup_CheckedChanged(object sender, EventArgs e)
    {
        skipSdpSavePopup = checkBox_sdpSkipSavePopup.Checked;
        checkBox_sdpSkipSavePopup.Text = checkBox_sdpSkipSavePopup.Checked
            ? "Just doing it ✅"
            : "Using Save Popup";
    }
}
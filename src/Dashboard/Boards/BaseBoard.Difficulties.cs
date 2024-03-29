using JMZ.Dashboard.Utils;
using JMZ.Difficulty.Data;
using JMZ.Json.Data.Services;

namespace JMZ.Dashboard.Boards;

public partial class BaseBoard
{
    private readonly DifficultyBoard difficultyBoard = new();
    
    private void SetupDifficultyBoard()
    {
        this.difficultyBoard.FormClosing += FormUtils.HideBoard;
        this.buttonDifficulties.Click += OpenDifficultiesClick;
        this.buttonSaveDifficulties.Click += SaveDifficultiesClick;
        this.checkboxSkipDifficultySavePopup.CheckedChanged += SaveSkipForDifficultiesCheck;
    }
    
    private async void OpenDifficultiesClick(object? sender, EventArgs e)
    {
        // check if we can load the board based on the required config.
        var canLoadBoard = await this.ValidateConfiguration(
            JsonLoaderService.difficultyDataPath(this.projectPath),
            DifficultyInitializer.InitializeConfiguration);

        // validate we are able to load the board.
        if (canLoadBoard is false) return;

        // initialize the data for the board.
        var data = JsonLoaderService.LoadDifficulties(this.projectPath);
        this.difficultyBoard.Setup(data);

        // show the window.
        this.difficultyBoard.Show();
    }

    private async void SaveDifficultiesClick(object? sender, EventArgs e)
    {
        // check if we're skipping the popup dialogue to confirm saving.
        if (this.skipDifficultySavePopup)
        {
            // just save.
            await this.SaveCrafting();
            return;
        }
        
        // ask the user if they are sure they want to do it.
        var dialogResult = MessageBox.Show("Are you sure you want to save difficulties?");

        // we only accept "OK" to save the data.
        if (dialogResult == DialogResult.OK)
        {
            // process the event.
            await this.SaveDifficulties();

            // upon completion, show the success.
            MessageBox.Show("Saving has completed successfully.");
        }
        else
        {
            MessageBox.Show("Edits were not lost. Hit the 'save' button again to be prompted again.");
        }
    }

    private void SaveSkipForDifficultiesCheck(object? sender, EventArgs e)
    {
        this.skipDifficultySavePopup = this.checkboxSkipDifficultySavePopup.Checked;
        this.checkboxSkipDifficultySavePopup.Text = this.checkboxSkipDifficultySavePopup.Checked
            ? "Just doing it ✅"
            : "Using Save Popup";
    }

    private async Task SaveDifficulties()
    {
        // update the tracked stuff to saved stuff.
        this.difficultyBoard.TrackToSavedDifficulties();
        var updated = this.difficultyBoard.Difficulties();

        // execute the save.
        await JsonSavingService.SaveDifficulties(this.projectPath, updated);

        // upon completion, show the success.
        MessageBox.Show("Saving has completed successfully.");

        // process the event.
        this.OnDatabaseSave();
    }
}
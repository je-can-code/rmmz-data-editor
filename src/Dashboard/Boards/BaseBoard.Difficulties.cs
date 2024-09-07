using JMZ.Dashboard.Utils;
using JMZ.Difficulty.Data;
using JMZ.Json.Data.Services;

namespace JMZ.Dashboard.Boards;

public partial class BaseBoard
{
    private readonly DifficultyBoard difficultyBoard = new();

    /// <summary>
    ///     When true, the prompt raised by trying to save is skipped when saving difficulties.
    /// </summary>
    private bool skipDifficultySavePopup;

    private partial void SetupDifficultyBoard()
    {
        difficultyBoard.FormClosing += FormUtils.HideBoard;
        buttonDifficulties.Click += OpenDifficultiesClick;
        buttonSaveDifficulties.Click += SaveDifficultiesClick;
        checkboxSkipDifficultySavePopup.CheckedChanged += SaveSkipForDifficultiesCheck;
    }

    private async void OpenDifficultiesClick(object? sender, EventArgs e)
    {
        // check if we can load the board based on the required config.
        var canLoadBoard = await FormUtils.ValidateConfiguration(
            _projectPath,
            JsonLoaderService.DifficultyDataPath(_projectPath),
            DifficultyInitializer.InitializeConfiguration);

        // validate we are able to load the board.
        if (canLoadBoard is false) return;

        // initialize the data for the board.
        var data = JsonLoaderService.LoadDifficulties(_projectPath);
        difficultyBoard.Setup(data);

        // show the window.
        difficultyBoard.Show();
    }

    private async void SaveDifficultiesClick(object? sender, EventArgs e)
    {
        // check if we're skipping the popup dialogue to confirm saving.
        if (skipDifficultySavePopup)
        {
            // just save.
            await SaveCrafting();
            return;
        }

        // ask the user if they are sure they want to do it.
        var dialogResult = MessageBox.Show("Are you sure you want to save difficulties?");

        // we only accept "OK" to save the data.
        if (dialogResult == DialogResult.OK)
        {
            // process the event.
            await SaveDifficulties();

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
        skipDifficultySavePopup = checkboxSkipDifficultySavePopup.Checked;
        checkboxSkipDifficultySavePopup.Text = checkboxSkipDifficultySavePopup.Checked
            ? "Just doing it ✅"
            : "Using Save Popup";
    }

    private async Task SaveDifficulties()
    {
        // update the tracked stuff to saved stuff.
        difficultyBoard.TrackToSavedDifficulties();
        var updated = difficultyBoard.Difficulties();

        // execute the save.
        await JsonSavingService.SaveDifficulties(_projectPath, updated);

        // upon completion, show the success.
        MessageBox.Show("Saving has completed successfully.");

        // process the event.
        await OnDatabaseSave();
    }
}
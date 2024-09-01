using JMZ.Dashboard.Utils;
using JMZ.Json.Data.Services;
using JMZ.Quest.Data;

namespace JMZ.Dashboard.Boards;

public partial class BaseBoard
{
    private readonly QuestBoard _questBoard = new();

    private bool skipQuestSavePopup = false;

    private partial void SetupQuestBoard()
    {
        _questBoard.FormClosing += FormUtils.HideBoard;
        buttonQuests.Click += ButtonLoadQuestBoard;
        buttonSaveQuests.Click += ButtonSaveQuests;
    }

    private async void ButtonLoadQuestBoard(object? target, EventArgs? eventArgs)
    {
        // check if we can load the board based on the required config.
        var canLoadBoard = await FormUtils.ValidateConfiguration(
            _projectPath,
            JsonLoaderService.SdpDataPath(_projectPath),
            QuestInitializer.InitializeConfiguration);
        
        // validate we are able to load the board.
        if (canLoadBoard is false) return;

        var data = await JsonLoaderService.LoadQuests(_projectPath);
        _questBoard.Setup(data);
        _questBoard.Show();
    }
    
    private async void ButtonSaveQuests(object? target, EventArgs? eventArgs)
    {
        // check if the board hasn't been setup yet, or is in need of a refresh first.
        if (craftBoard.needsSetup)
        {
            MessageBox.Show(
                """
                Quest configuration data needs initialization.
                Please click the 'Configure Quest Data' button
                to load the current data first.
                """,
                "Quest Configuration Data Needs Initialization",
                MessageBoxButtons.OK);
            return;
        }
        
        // check if we're skipping the popup dialogue to confirm saving.
        if (skipQuestSavePopup)
        {
            // just save.
            await SaveQuests();
            return;
        }
        
        // ask the user to confirm they want to save.
        var dialogResult = MessageBox.Show(
            "Are you sure you want to save all quest data?",
            "Save All Quest Configuration Data",
            MessageBoxButtons.YesNo);

        // pivot on what the user chooses.
        switch (dialogResult)
        {
            // check if the user agreed.
            case DialogResult.Yes:
                // then save.
                await SaveQuests();
                MessageBox.Show("Saving has completed successfully.");
                break;
            // the user didn't hit YES.
            default:
                MessageBox.Show(
                    """
                    Edits were not lost.
                    Hit the 'Save Quest Config' button again to be prompted again.
                    """);
                break;
        }
    }

    private async Task SaveQuests()
    {
        _questBoard.TrackedToSaved();

        var updatedConfiguration = new QuestConfiguration
        {
            Quests = _questBoard.OmniQuests,
            Categories = _questBoard.OmniCategories,
            Tags = _questBoard.OmniTags
        };
        
        await JsonSavingService.SaveQuests(_projectPath, updatedConfiguration);
    }
}
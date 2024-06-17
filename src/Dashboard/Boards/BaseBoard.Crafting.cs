using JMZ.Crafting.Data;
using JMZ.Dashboard.Boards.Craft;
using JMZ.Dashboard.Utils;
using JMZ.Json.Data.Services;

namespace JMZ.Dashboard.Boards;

public partial class BaseBoard
{
    /// <summary>
    /// The board that primarily handles Crafting design.
    /// </summary>
    private readonly CraftBoard craftBoard = new();

    /// <summary>
    /// When true, the prompt for skipping the prompt when saving crafting data.
    /// When false, the confirmation popup will show.
    /// </summary>
    private bool skipCraftingSavePopup;
    
    private partial void SetupCraftingBoard()
    {
        this.craftBoard.FormClosing += FormUtils.HideBoard;
    }

    private async void button_saveCrafting_Click(object sender, EventArgs e)
    {
        // check if the board hasn't been setup yet, or is in need of a refresh first.
        if (this.craftBoard.needsSetup)
        {
            MessageBox.Show(
                """
                Crafting configuration data needs initialization.
                Please click either the 'Configure Recipe Data' button or the
                'Configure Category Data' button to load the current data first.
                """,
                "Crafting Configuration Data Needs Initialization",
                MessageBoxButtons.OK);
            return;
        }

        // check if we're skipping the popup dialogue to confirm saving.
        if (this.skipCraftingSavePopup)
        {
            // just save.
            await this.SaveCrafting();
            return;
        }

        // ask the user to confirm they want to save.
        var dialogResult = MessageBox.Show(
            "Are you sure you want to save all crafting data?",
            "Save All Crafting Configuration Data",
            MessageBoxButtons.YesNo);

        // pivot on what the user chooses.
        switch (dialogResult)
        {
            // check if the user agreed.
            case DialogResult.Yes:
                // then save.
                await this.SaveCrafting();
                MessageBox.Show("Saving has completed successfully.");
                break;
            // the user didn't hit YES.
            default:
                MessageBox.Show(
                    """
                    Edits were not lost.
                    Hit the 'Save Crafting Config' button again to be prompted again.
                    """);
                break;
        }
    }

    private async Task SaveCrafting()
    {
        // update the tracked stuff to saved stuff.
        this.craftBoard.TrackedToSavedRecipes();
        this.craftBoard.TrackedToSavedCategories();

        // create the updated configuration data.
        var updatedConfiguration = new CraftingConfiguration
        {
            Recipes = this.craftBoard.Recipes(),
            Categories = this.craftBoard.Categories()
        };


        // record the newly updated data to disk.
        await JsonSavingService.SaveCrafting(this.projectPath, updatedConfiguration);

        // flag our status strip.
        this.statusStrip_base.Text = "Updated Crafting configuration data.";
        this.statusStrip_base.Refresh();
    }

    private void CheckBoxSkipCraftingSavePopupCheckedChanged(object sender, EventArgs e)
    {
        this.skipCraftingSavePopup = this.checkBoxSkipCraftingSavePopup.Checked;
        this.checkBoxSkipCraftingSavePopup.Text = this.checkBoxSkipCraftingSavePopup.Checked
            ? "Just doing it ✅"
            : "Using Save Popup";
    }

    private async void button_recipes_Click(object sender, EventArgs e)
    {
        // check if we can load the board based on the required config.
        var canLoadBoard = await FormUtils.ValidateConfiguration(
            this.projectPath,
            JsonLoaderService.craftingDataPath(this.projectPath),
            CraftingInitializer.InitializeConfiguration);

        // validate we are able to load the board.
        if (canLoadBoard is false) return;

        // initialize the data for the board.
        var data = JsonLoaderService.LoadCrafting(this.projectPath);
        this.craftBoard.Setup(data);

        // show the window.
        this.craftBoard.Show();
    }
}
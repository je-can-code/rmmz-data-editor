using JMZ.Crafting.Data;
using JMZ.Dashboard.Boards.Craft;
using JMZ.Json.Data.Caches;
using JMZ.Json.Data.Services;
using JMZ.Sdp.Data;

namespace JMZ.Dashboard.Boards;

public partial class BaseBoard : Form
{
    /// <summary>
    /// The board that primarily handles weapon modifications.
    /// </summary>
    private readonly WeaponsBoard weaponsBoard;

    /// <summary>
    /// The board that primarily handles skill modifications.
    /// </summary>
    private readonly SkillsBoard skillsBoard;

    /// <summary>
    /// The board that primarily handles SDP design.
    /// </summary>
    private readonly SdpBoard sdpBoard;

    /// <summary>
    /// The board that primarily handles Crafting design.
    /// </summary>
    private readonly CraftBoard craftBoard;

    /// <summary>
    /// The board that primarily handles the enemies and modifications to them.
    /// </summary>
    private readonly EnemiesBoard enemiesBoard;

    /// <summary>
    /// The full path to the /data directory of the project.
    /// </summary>
    private string projectPath;

    /// <summary>
    /// When true, the prompt for skipping the prompt when saving SDP data.
    /// When false, the confirmation popup will show.
    /// </summary>
    private bool skipSdpSavePopup;

    /// <summary>
    /// When true, the prompt for skipping the prompt when saving crafting data.
    /// When false, the confirmation popup will show.
    /// </summary>
    private bool skipCraftingSavePopup;

    /// <summary>
    /// When true, the prompt raised by trying to save is skipped when saving difficulties. 
    /// </summary>
    private bool skipDifficultySavePopup;

    public BaseBoard()
    {
        InitializeComponent();
        this.StartPosition = FormStartPosition.Manual;
        var x = Screen.PrimaryScreen!.Bounds.Width / 2 - this.Width;
        var y = Screen.PrimaryScreen!.Bounds.Height / 2 - this.Height + 300;
        this.Location = new(x, y);

        // hard-code this for default, but we should probably make this configurable.
        //this.projectPath = @"//192.168.86.35/dev/gaming/rmmz-plugins/project/data";
        this.projectPath = @"Z:/dev/gaming/rmmz-plugins/project/data";

        this.RefreshDatabaseCaches();

        this.weaponsBoard = new();
        this.skillsBoard = new();
        this.enemiesBoard = new();

        this.sdpBoard = new();
        this.craftBoard = new();

        // initialize the boards.
        this.SetupBoards();

        this.RefreshProjectDataPath();
    }

    private void SetupBoards()
    {
        // TODO: does this sort of one-time setup work?
        // this.weaponsBoard.Load += SetupWeaponsBoard; // ??

        this.weaponsBoard.FormClosing += HideBoard;
        this.skillsBoard.FormClosing += HideBoard;
        this.enemiesBoard.FormClosing += HideBoard;

        this.sdpBoard.FormClosing += HideBoard;
        this.craftBoard.FormClosing += HideBoard;
        this.SetupDifficultyBoard();
    }



    /// <summary>
    /// An event handler for hiding the boards instead of closing them.
    /// </summary>
    private static void HideBoard(object? sender, FormClosingEventArgs e)
    {
        // make sure its the user trying to close the window, first.
        if (e.CloseReason != CloseReason.UserClosing) return;

        // actually don't close and dispose of the window.
        e.Cancel = true;

        // hide the window instead.
        ((Form)sender!).Hide();
    }

    #region project data path
    private void button_pickDataPath_Click(object sender, EventArgs e)
    {
        var dialogResult = folderDialog_dataPath.ShowDialog();
        if (dialogResult != DialogResult.OK) return;

        if (this.projectPath != folderDialog_dataPath.SelectedPath)
        {
            this.OnProjectDataPathChange();
        }

    }

    /// <summary>
    /// Refreshes the project path and its label by the most-recently-selected project.
    /// </summary>
    private void RefreshProjectDataPath()
    {
        // check if there is a selected folder path to update our project path with.
        if (folderDialog_dataPath.SelectedPath.Length > 0)
        {
            // update the underlying tracker for the path to the /data folder of the project.
            this.projectPath = folderDialog_dataPath.SelectedPath;
        }

        // if there is a project path, update the label.
        if (this.projectPath.Length > 0)
        {
            // update the label for the user to see this text.
            this.label_dataPath.Text = this.projectPath;
        }
    }

    private void OnProjectDataPathChange()
    {
        // sync the path and label with the actual project path.
        this.RefreshProjectDataPath();

        // flag the weapons for update.
        this.weaponsBoard.FlagForRefresh();

        // refresh the database caches.
        this.RefreshDatabaseCaches();
    }

    private void RefreshDatabaseCaches()
    {
        // refresh the various database caches.
        Items.Refresh(this.projectPath);
        Weapons.Refresh(this.projectPath);
        Armors.Refresh(this.projectPath);
    }
    #endregion

    private void OnDatabaseSave()
    {
        this.RefreshDatabaseCaches();
        this.weaponsBoard.FlagForRefresh();
        this.enemiesBoard.FlagForRefresh();
        this.skillsBoard.FlagForRefresh();
        this.enemiesBoard.FlagForRefresh();
        // this.difficultyBoard.FlagForRefresh();
    }

    #region jabs
    private void button_weapons_Click(object sender, EventArgs e)
    {
        // get the core dataset for this board.
        var data = JsonLoaderService.LoadWeapons(this.projectPath);

        // setup the board.
        this.weaponsBoard.Show();
        this.weaponsBoard.Setup(data);
    }

    private async void button_saveWeapons_Click(object sender, EventArgs e)
    {
        // ask the user if they are sure they want to do it.
        var dialogResult = MessageBox.Show("Are you sure you want to save weapons?");

        // we only accept "OK" to save the data.
        if (dialogResult == DialogResult.OK)
        {
            // these are updated by reference.
            var updated = this.weaponsBoard.Weapons();

            // execute the save.
            await JsonSavingService.SaveWeapons(this.projectPath, updated);

            // upon completion, show the success.
            MessageBox.Show("Saving has completed successfully.");

            // process the event.
            this.OnDatabaseSave();
        }
        else
        {
            MessageBox.Show("Edits were not lost. Hit the 'save' button again to be prompted again.");
        }
    }

    private void button_skills_Click(object sender, EventArgs e)
    {
        // get the core dataset for this board.
        var data = JsonLoaderService.LoadSkills(this.projectPath);

        // setup the board.
        this.skillsBoard.Show();
        this.skillsBoard.Setup(data);
    }

    private async void button_saveSkills_Click(object sender, EventArgs e)
    {
        // ask the user if they are sure they want to do it.
        var dialogResult = MessageBox.Show("Are you sure you want to save skills?");

        // we only accept "OK" to save the data.
        if (dialogResult == DialogResult.OK)
        {
            // these are updated by reference.
            var updated = this.skillsBoard.Skills();

            // execute the save.
            await JsonSavingService.SaveSkills(this.projectPath, updated);

            // upon completion, show the success.
            MessageBox.Show("Saving has completed successfully.");

            // process the event.
            this.OnDatabaseSave();
        }
        // they decided not to save.
        else
        {
            // let them know we didn't trash their updates.
            MessageBox.Show("Edits were not lost. Hit the 'save' button again to be prompted again.");
        }
    }
    #endregion

    #region sdp
    private async void button_sdps_Click(object sender, EventArgs e)
    {
        // check if we can load the board based on the required config.
        var canLoadBoard = await this.ValidateConfiguration(
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
    #endregion

    #region crafting
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
        var canLoadBoard = await this.ValidateConfiguration(
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
    #endregion
    


    private async Task<bool> ValidateConfiguration(string configPath, Func<string, Task> initConfigFunc)
    {
        // check if the config exists.
        var isConfigPresent = JsonLoaderService.IsConfigPresent(configPath);

        // it exists, great!
        if (isConfigPresent) return true;

        // ask the user what they want to do about the missing and required configuration data file.
        var dialogResult = MessageBox.Show(
            "No configuration was detected. Create a new config?",
            "Configuration Data Missing",
            MessageBoxButtons.YesNoCancel,
            MessageBoxIcon.Exclamation);

        // there can only be yes/no/cancel.
        switch (dialogResult)
        {
            case DialogResult.Yes:
                await initConfigFunc(this.projectPath);
                MessageBox.Show("Empty configuration has been written.");
                return true;
            case DialogResult.No:
                MessageBox.Show(
                    "Without necessary configuration data, the GUI to manipulate said missing data may not work.");
                return false;
            default:
                MessageBox.Show("Ignoring configuration data check result.");
                return true;
        }
    }

    private async void button_enemies_Click(object sender, EventArgs e)
    {
        // get the core dataset for this board.
        var data = await Task.Run(() => JsonLoaderService.LoadEnemies(this.projectPath));

        // setup the board.
        this.enemiesBoard.Show();
        this.enemiesBoard.Setup(data);
    }

    private async void button_saveEnemies_Click(object sender, EventArgs e)
    {
        // ask the user if they are sure they want to do it.
        var dialogResult = MessageBox.Show("Are you sure you want to save enemies?");

        // we only accept "OK" to save the data.
        if (dialogResult == DialogResult.OK)
        {
            // these are updated by reference.
            var updated = this.enemiesBoard.Enemies();

            // execute the save.
            await JsonSavingService.SaveEnemies(this.projectPath, updated);

            // upon completion, show the success.
            MessageBox.Show("Saving has completed successfully.");

            // process the event.
            this.OnDatabaseSave();
        }
        else
        {
            MessageBox.Show("Edits were not lost. Hit the 'save' button again to be prompted again.");
        }
    }
}

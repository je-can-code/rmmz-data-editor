using JMZ.Dashboard.Configuration;
using JMZ.Dashboard.Utils;
using JMZ.Json.Data.Caches;
using Microsoft.Extensions.Options;

namespace JMZ.Dashboard.Boards;

public partial class BaseBoard : Form
{
    /// <summary>
    /// The full path to the /data directory of the project.
    /// </summary>
    private string _projectPath;

    public BaseBoard(IOptions<JmzOptions> options)
    {
        // TODO: remove this if we end up pivoting to 100% code-driven design.
        // perform required designer-based logic.
        InitializeComponent();

        var screen = Screen.PrimaryScreen
            ?? throw new NullReferenceException("why tf is Screen.PrimaryScreen is null");

        // move the window to the center.
        StartPosition = FormStartPosition.Manual;
        var x = screen.Bounds.Width / 2 - Width;
        var y = screen.Bounds.Height / 2 - Height + 300;
        Location = new(x, y);

        // define the initial state of the project path based on the options.
        _projectPath = options.Value.DefaultProjectPath;

        // start by initializing the database cache.
        Task.Run(async () => await RefreshDatabaseCaches());

        // initialize the boards.
        SetupBoards();

        // refresh the project path.
        RefreshProjectDataPath();
    }

    #region setup
    /// <summary>
    /// Initializes all winforms boards used in this application.
    /// </summary>
    private void SetupBoards()
    {
        SetupDatabaseBoards();
        SetupCustomBoards();
    }

    /// <summary>
    /// Sets up the boards that are for database pages, like weapons or skills.
    /// </summary>
    private void SetupDatabaseBoards()
    {
        SetupWeaponsBoard();
        SetupSkillsBoard();
        SetupEnemiesBoard();
    }

    /// <summary>
    /// Sets up the boards that are for custom plugins, like SDP or Difficulties.
    /// </summary>
    private void SetupCustomBoards()
    {
        SetupDifficultyBoard();
        SetupCraftingBoard();
        SetupSdpBoard();
        SetupQuestBoard();
    }

    #region database boards
    // implemented in BaseBoard.Weapons.
    private partial void SetupWeaponsBoard();

    // implemented in BaseBoard.Skills.
    private partial void SetupSkillsBoard();

    // implemented in BaseBoard.Enemies.
    private partial void SetupEnemiesBoard();
    #endregion

    #region custom boards
    // implemented in BaseBoard.Difficulties.
    private partial void SetupDifficultyBoard();

    // implemented in BaseBoard.Crafting.
    private partial void SetupCraftingBoard();

    // implemented in BaseBoard.Sdp.
    private partial void SetupSdpBoard();

    private partial void SetupQuestBoard();
    #endregion
    #endregion setup

    #region project data path
    private async void button_pickDataPath_Click(object sender, EventArgs e)
    {
        var dialogResult = folderDialogDataPath.ShowDialog();
        if (dialogResult != DialogResult.OK) return;

        if (_projectPath != folderDialogDataPath.SelectedPath)
        {
            await OnProjectDataPathChange();
        }

    }

    /// <summary>
    /// Refreshes the project path and its label by the most-recently-selected project.
    /// </summary>
    private void RefreshProjectDataPath()
    {
        // check if there is a selected folder path to update our project path with.
        if (folderDialogDataPath.SelectedPath.Length > 0)
        {
            // update the underlying tracker for the path to the /data folder of the project.
            _projectPath = folderDialogDataPath.SelectedPath;
        }

        // if there is a project path, update the label.
        if (_projectPath.Length > 0)
        {
            // update the label for the user to see this text.
            label_dataPath.Text = _projectPath;
        }
    }

    private async Task OnProjectDataPathChange()
    {
        // sync the path and label with the actual project path.
        RefreshProjectDataPath();

        // flag the boards for update.
        weaponsBoard.FlagForRefresh();
        enemiesBoard.FlagForRefresh();
        skillsBoard.FlagForRefresh();

        // TODO: this should be implemented as an abstract class for ALL boards?
        // this.difficultyBoard.FlagForRefresh();

        // refresh the database caches.
        await RefreshDatabaseCaches();
    }

    private async Task RefreshDatabaseCaches()
    {
        // refresh the various database caches.
        Items.Refresh(_projectPath);
        await Weapons.Refresh(_projectPath);
        Armors.Refresh(_projectPath);
    }
    #endregion

    private async Task OnDatabaseSave()
    {
        await RefreshDatabaseCaches();
        weaponsBoard.FlagForRefresh();
        enemiesBoard.FlagForRefresh();
        skillsBoard.FlagForRefresh();

        // this.difficultyBoard.FlagForRefresh();
    }
}
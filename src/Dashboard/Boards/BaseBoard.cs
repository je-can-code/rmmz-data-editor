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
    private string projectPath;

    public BaseBoard(IOptions<JmzOptions> options)
    {
        // TODO: remove this if we end up pivoting to 100% code-driven design.
        // perform required designer-based logic.
        this.InitializeComponent();
        
        // move the window to the center.
        this.StartPosition = FormStartPosition.Manual;
        var x = Screen.PrimaryScreen!.Bounds.Width / 2 - this.Width;
        var y = Screen.PrimaryScreen!.Bounds.Height / 2 - this.Height + 300;
        this.Location = new(x, y);

        // define the initial state of the project path based on the options.
        this.projectPath = options.Value.DefaultProjectPath;

        // start by initializing the database cache.
        this.RefreshDatabaseCaches();

        // initialize the boards.
        this.SetupBoards();

        // refresh the project path.
        this.RefreshProjectDataPath();
    }

    #region setup
    /// <summary>
    /// Initializes all winforms boards used in this application.
    /// </summary>
    private void SetupBoards()
    {
        this.SetupDatabaseBoards();
        this.SetupCustomBoards();
    }

    /// <summary>
    /// Sets up the boards that are for database pages, like weapons or skills.
    /// </summary>
    private void SetupDatabaseBoards()
    {
        this.SetupWeaponsBoard();
        this.SetupSkillsBoard();
        this.SetupEnemiesBoard();
    }

    /// <summary>
    /// Sets up the boards that are for custom plugins, like SDP or Difficulties.
    /// </summary>
    private void SetupCustomBoards()
    {
        this.SetupDifficultyBoard();
        this.SetupSdpBoard();
        this.SetupCraftingBoard();
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
    #endregion
    #endregion setup

    #region project data path
    private void button_pickDataPath_Click(object sender, EventArgs e)
    {
        var dialogResult = this.folderDialogDataPath.ShowDialog();
        if (dialogResult != DialogResult.OK) return;

        if (this.projectPath != this.folderDialogDataPath.SelectedPath)
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
        if (this.folderDialogDataPath.SelectedPath.Length > 0)
        {
            // update the underlying tracker for the path to the /data folder of the project.
            this.projectPath = this.folderDialogDataPath.SelectedPath;
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
}
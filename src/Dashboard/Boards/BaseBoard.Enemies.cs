using JMZ.Dashboard.Utils;
using JMZ.Json.Data.Services;

namespace JMZ.Dashboard.Boards;

/// <summary>
/// This portion of the BaseBoard is to encapsulate logic explicitly associated with the enemies board.
/// </summary>
public partial class BaseBoard
{
    /// <summary>
    /// The board that primarily handles the enemies and modifications to them.
    /// </summary>
    private readonly EnemiesBoard enemiesBoard = new();

    private partial void SetupEnemiesBoard()
    {
        this.enemiesBoard.FormClosing += FormUtils.HideBoard;
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
        // they decided not to save.
        else
        {
            MessageBox.Show("Edits were not lost. Hit the 'save' button again to be prompted again.");
        }
    }
}
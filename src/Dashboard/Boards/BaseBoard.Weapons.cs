using JMZ.Dashboard.Utils;
using JMZ.Json.Data.Services;

namespace JMZ.Dashboard.Boards;

public partial class BaseBoard
{
    /// <summary>
    /// The board that primarily handles weapon modifications.
    /// </summary>
    private readonly WeaponsBoard weaponsBoard = new();

    private partial void SetupWeaponsBoard()
    {
        // TODO: does this sort of one-time setup work?
        // this.weaponsBoard.Load += SetupWeaponsBoard; // ??
        
        this.weaponsBoard.FormClosing += FormUtils.HideBoard;
    }

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
        // they decided not to save.
        else
        {
            MessageBox.Show("Edits were not lost. Hit the 'save' button again to be prompted again.");
        }
    }
}
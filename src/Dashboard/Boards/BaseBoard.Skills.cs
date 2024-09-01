using JMZ.Dashboard.Utils;
using JMZ.Json.Data.Services;

namespace JMZ.Dashboard.Boards;

public partial class BaseBoard
{
    /// <summary>
    /// The board that primarily handles skill modifications.
    /// </summary>
    private readonly SkillsBoard skillsBoard = new();

    private partial void SetupSkillsBoard()
    {
        skillsBoard.FormClosing += FormUtils.HideBoard;
    }

    private void button_skills_Click(object sender, EventArgs e)
    {
        // get the core dataset for this board.
        var data = JsonLoaderService.LoadSkills(_projectPath);

        // setup the board.
        skillsBoard.Show();
        skillsBoard.Setup(data);
    }

    private async void button_saveSkills_Click(object sender, EventArgs e)
    {
        // ask the user if they are sure they want to do it.
        var dialogResult = MessageBox.Show("Are you sure you want to save skills?");

        // we only accept "OK" to save the data.
        if (dialogResult == DialogResult.OK)
        {
            // these are updated by reference.
            var updated = skillsBoard.Skills();

            // execute the save.
            await JsonSavingService.SaveSkills(_projectPath, updated);

            // upon completion, show the success.
            MessageBox.Show("Saving has completed successfully.");

            // process the event.
            await OnDatabaseSave();
        }
        // they decided not to save.
        else
        {
            // let them know we didn't trash their updates.
            MessageBox.Show("Edits were not lost. Hit the 'save' button again to be prompted again.");
        }
    }
}
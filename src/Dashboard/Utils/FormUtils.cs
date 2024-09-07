using JMZ.Json.Data.Services;

namespace JMZ.Dashboard.Utils;

public static class FormUtils
{
    /// <summary>
    ///     An event handler for simply hiding a form instead of closing it when the user tries to close the form.<br />
    ///     This is explicitly unique to this
    /// </summary>
    public static void HideBoard(object? sender, FormClosingEventArgs e)
    {
        // make sure its the user trying to close the window, first.
        if (e.CloseReason != CloseReason.UserClosing) return;

        // actually don't close and dispose of the window.
        e.Cancel = true;

        // hide the window instead.
        ((Form)sender!).Hide();
    }

    /// <summary>
    ///     Determines whether or not the configuration is valid.<br />
    ///     If it is not, it will be created using the provided init func.
    /// </summary>
    public static async Task<bool> ValidateConfiguration(
        string projectPath,
        string configPath,
        Func<string, Task> initConfigFunc)
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
                await initConfigFunc(projectPath);
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
}
namespace JMZ.Dashboard.Utils;

public static class FormUtils
{
    /// <summary>
    /// An event handler for simply hiding a form instead of closing it when the user tries to close the form.<br/>
    /// This is explicitly unique to this 
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
}
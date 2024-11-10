namespace JMZ.Dashboard.Extensions;

public static class ListBoxExtensions
{
    /// <summary>
    /// <para>
    /// Gets the index above the currently selected index. If the selection is the beginning of the list or there is no
    /// selection at all, it will default to the beginning of the listbox collection.
    /// </para>
    /// <para>
    /// This is intended to be used for inserting into the collection, and so "above" in the context of insertion is
    /// "equal to the selected index", which slides the currently selected index down one.
    /// </para>
    /// </summary>
    /// <param name="listBox">The listbox to inspect.</param>
    /// <returns>The above index.</returns>
    public static int GetIndexAbove(this ListBox listBox)
    {
        return listBox.SelectedIndex <= 0
            ? 0
            : listBox.SelectedIndex;
    }

    /// <summary>
    /// <para>
    /// Gets the index below the currently selected index. If the selection is the beginning of the list or there is no
    /// selection at all, it will default to the beginning of the listbox collection.
    /// </para>
    /// <para>
    /// This is intended to be used for inserting into the collection, and so "below" in the context of insertion is
    /// "index plus one", which will place the item after the currently-selected index, and slide all the rest of the
    /// list down one.
    /// </para>
    /// </summary>
    /// <param name="listBox">The listbox to inspect.</param>
    /// <returns>The below index.</returns>
    public static int GetIndexBelow(this ListBox listBox)
    {
        if (listBox.SelectedIndex == -1) return 0;
        
        return listBox.SelectedIndex + 1 >= listBox.Items.Count - 1
            ? listBox.Items.Count
            : listBox.SelectedIndex + 1;
    }
}
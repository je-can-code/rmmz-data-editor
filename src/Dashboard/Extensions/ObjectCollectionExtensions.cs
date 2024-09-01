namespace JMZ.Dashboard.Extensions;

/// <summary>
/// Extension methods for the various ObjectCollection classes.
/// </summary>
public static class ObjectCollectionExtensions
{
    /// <summary>
    /// Finds the first index of an item in the <see cref="ComboBox.ObjectCollection"/> that meets the criteria of the provided
    /// predicate.
    /// </summary>
    /// <param name="objectCollection">The collection being searched.</param>
    /// <param name="predicate">The predicate- or lambda function- to use to find the item's index.</param>
    /// <typeparam name="T">The type of the items in the collection- used for typing in the predicate.</typeparam>
    /// <returns>The 0-based index of the first entry that passes the predicate, or -1 if nothing was found.</returns>
    public static int FindIndex<T>(this ComboBox.ObjectCollection objectCollection, Predicate<T> predicate)
    {
        // initialize the index to 0.
        var index = 0;

        // iterate over each item in the object collection.
        foreach (T objectItem in objectCollection)
        {
            // check if the predicate matches.
            if (predicate(objectItem))
            {
                // it matches, so this is the index.
                return index;
            }

            // increment the index if we didn't find anything.
            index++;
        }

        // if nothing was found that matches the predicate, then default to -1.
        return -1;
    }

    /// <summary>
    /// Finds the first index of an item in the <see cref="ListBox.ObjectCollection"/> that meets the criteria of the provided
    /// predicate.
    /// </summary>
    /// <param name="objectCollection">The collection being searched.</param>
    /// <param name="predicate">The predicate- or lambda function- to use to find the item's index.</param>
    /// <typeparam name="T">The type of the items in the collection- used for typing in the predicate.</typeparam>
    /// <returns>The 0-based index of the first entry that passes the predicate, or -1 if nothing was found.</returns>
    public static int FindIndex<T>(this ListBox.ObjectCollection objectCollection, Predicate<T> predicate)
    {
        // initialize the index to 0.
        var index = 0;

        // iterate over each item in the object collection.
        foreach (T objectItem in objectCollection)
        {
            // check if the predicate matches.
            if (predicate(objectItem))
            {
                // it matches, so this is the index.
                return index;
            }

            // increment the index if we didn't find anything.
            index++;
        }

        // if nothing was found that matches the predicate, then default to -1.
        return -1;
    }

    /// <summary>
    /// Finds the first index of an item in the <see cref="CheckedListBox.ObjectCollection"/> that meets the criteria of the provided
    /// predicate.
    /// </summary>
    /// <param name="objectCollection">The collection being searched.</param>
    /// <param name="predicate">The predicate- or lambda function- to use to find the item's index.</param>
    /// <typeparam name="T">The type of the items in the collection- used for typing in the predicate.</typeparam>
    /// <returns>The 0-based index of the first entry that passes the predicate, or -1 if nothing was found.</returns>
    public static int FindIndex<T>(this CheckedListBox.ObjectCollection objectCollection, Predicate<T> predicate)
    {
        // initialize the index to 0.
        var index = 0;

        // iterate over each item in the object collection.
        foreach (T objectItem in objectCollection)
        {
            // check if the predicate matches.
            if (predicate(objectItem))
            {
                // it matches, so this is the index.
                return index;
            }

            // increment the index if we didn't find anything.
            index++;
        }

        // if nothing was found that matches the predicate, then default to -1.
        return -1;
    }
}
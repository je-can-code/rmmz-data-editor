using JMZ.Crafting.Data.Models;

namespace JMZ.Dashboard.Boards.Craft;

public partial class CraftCategoryHelper : Form
{
    private List<Category> categories = [];
    private bool needsSetup = true;

    public CraftCategoryHelper()
    {
        InitializeComponent();

        InitializeDataControls();
        InitializeTooltips();
        ApplyUpdateEvents();
    }

    /// <summary>
    ///     Gets the component from the helper in its current state.
    /// </summary>
    /// <returns></returns>
    public Category CurrentCategory()
    {
        return (Category)listBoxCategories.SelectedItem!;
    }

    public List<Category> Categories()
    {
        return categories;
    }

    public void TrackedToSavedCategories()
    {
        // clear the existing list.
        categories.Clear();

        // iterate over the tracked list.
        foreach (var category in listBoxCategories.Items)
        {
            // add each item from the tracked list into the list to be saved.
            categories.Add((Category)category);
        }
    }

    private void buttonAddCategory_Click(object sender, EventArgs e)
    {
        // define the new SDP.
        var newItem = Category.NEW;

        // grab the current selection.
        var selectedIndex = listBoxCategories.SelectedIndex;

        // check if there was no current selection.
        if (selectedIndex == -1 || selectedIndex == listBoxCategories.Items.Count - 1)
        {
            // add the item to the list without regard for index.
            listBoxCategories.Items.Add(newItem);
        }
        // we are in the middle somewhere.
        else
        {
            // add it at the given index.
            listBoxCategories.Items.Insert(selectedIndex, newItem);
        }
    }

    private void buttonDeleteCategory_Click(object sender, EventArgs e)
    {
        // grab the selection the user is considering removing.
        var removalIndex = listBoxCategories.SelectedIndex;

        // check if there is no index selected right now.
        if (removalIndex == -1)
        {
            // do nothing.
            return;
        }

        // grab the current panel we're working with.
        var selectedItem = (Category)listBoxCategories.SelectedItem!;

        // define the prompt.
        var removalPrompt = $"Are you sure you want to remove the category with key [{selectedItem.Key}]?";

        // show the box with the prompt.
        var dialogResult = MessageBox.Show(removalPrompt, "Removing a Category", MessageBoxButtons.OKCancel);

        // pivot on the user decisions.
        switch (dialogResult)
        {
            case DialogResult.OK:
                listBoxCategories.Items.RemoveAt(removalIndex);
                if (listBoxCategories.Items.Count != 0)
                {
                    listBoxCategories.SelectedIndex = 0;
                }

                break;
            case DialogResult.Cancel:
                break;
        }
    }

    #region setup
    public void Setup(List<Category> data)
    {
        if (!needsSetup) return;

        categories = data;

        RefreshCategoryData();

        needsSetup = false;
    }
    #endregion

    #region init
    /// <summary>
    ///     Initializes the data-binding of components to arbitrary values.
    /// </summary>
    private void InitializeDataControls()
    {
        // setup the list of categories.
        listBoxCategories.DisplayMember = "Name";
        listBoxCategories.ValueMember = "Key";
    }

    /// <summary>
    ///     Initializes all tooltips associated with this board.
    /// </summary>
    private void InitializeTooltips()
    {
        // _toolTip = new();
        // _toolTip.AutoPopDelay = 5000;
        // _toolTip.InitialDelay = 1000;
        // _toolTip.ReshowDelay = 500;
        // _toolTip.ToolTipIcon = ToolTipIcon.Info;
        // _toolTip.ToolTipTitle = "Details and Usage";

        // _toolTip.SetToolTip(this.num_radius, JABS.Data.Models.Tags.Radius.Description);
    }

    private void ApplyUpdateEvents()
    {
        // if the category changes, refresh all of the form.
        listBoxCategories.SelectedIndexChanged += RefreshForm;

        // if the key changes, update it.
        textBoxKey.TextChanged += UpdateKey;

        // if the name changes, update it.
        textBoxName.TextChanged += UpdateName;

        // if the quantity changes, update it.
        textBoxDescription.TextChanged += UpdateDescription;

        // if the icon index changes, update it.
        numIconIndex.ValueChanged += UpdateIconIndex;

        // if the unlocked by default changes, update it.
        checkBoxUnlockedByDefault.CheckedChanged += UpdateUnlockedByDefault;
    }
    #endregion

    #region update
    private void UpdateKey(object? sender, EventArgs e)
    {
        var selectedItem = (Category)listBoxCategories.SelectedItem!;

        if (selectedItem is null) return;

        selectedItem.Key = textBoxKey.Text;

        listBoxCategories.Items[listBoxCategories.SelectedIndex] = selectedItem;
    }

    private void UpdateName(object? sender, EventArgs e)
    {
        var selectedItem = (Category)listBoxCategories.SelectedItem!;

        if (selectedItem is null) return;

        selectedItem.Name = textBoxName.Text;

        listBoxCategories.Items[listBoxCategories.SelectedIndex] = selectedItem;
    }

    private void UpdateDescription(object? sender, EventArgs e)
    {
        var selectedItem = (Category)listBoxCategories.SelectedItem!;

        if (selectedItem is null) return;

        selectedItem.Description = textBoxDescription.Text;
    }

    private void UpdateIconIndex(object? sender, EventArgs e)
    {
        var selectedItem = (Category)listBoxCategories.SelectedItem!;

        if (selectedItem is null) return;

        selectedItem.IconIndex = (int)numIconIndex.Value;
    }

    private void UpdateUnlockedByDefault(object? sender, EventArgs e)
    {
        var selectedItem = (Category)listBoxCategories.SelectedItem!;

        if (selectedItem is null) return;

        selectedItem.UnlockedByDefault = checkBoxUnlockedByDefault.Checked;
    }
    #endregion

    #region refresh
    private void RefreshForm(object? sender, EventArgs e)
    {
        _RefreshForm();
    }

    private void _RefreshForm()
    {
        // refresh recipe data.
        RenderCategoryData();
    }

    private void RenderCategoryData()
    {
        var selectedItem = (Category)listBoxCategories.SelectedItem!;

        if (selectedItem is null) return;

        textBoxKey.Text = selectedItem.Key;
        textBoxName.Text = selectedItem.Name;
        textBoxDescription.Text = selectedItem.Description;
        numIconIndex.Value = selectedItem.IconIndex;
    }

    private void RefreshCategoryData()
    {
        listBoxCategories.Items.Clear();

        categories.ForEach(
            category =>
            {
                if (category is null) return;

                listBoxCategories.Items.Add(category);
            });
    }
    #endregion
}
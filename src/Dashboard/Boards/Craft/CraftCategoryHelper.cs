using JMZ.Crafting.Data.Models;

namespace JMZ.Dashboard.Boards.Craft;

public partial class CraftCategoryHelper : Form
{
    private bool needsSetup = true;

    private List<Category> categories = new();

    public CraftCategoryHelper()
    {
        InitializeComponent();

        this.InitializeDataControls();
        this.InitializeTooltips();
        this.ApplyUpdateEvents();
    }

    /// <summary>
    /// Gets the component from the helper in its current state.
    /// </summary>
    /// <returns></returns>
    public Category CurrentCategory()
    {
        return (Category)this.listBoxCategories.SelectedItem!;
    }

    public List<Category> Categories()
    {
        return this.categories;
    }

    public void TrackedToSavedCategories()
    {
        // clear the existing list.
        this.categories.Clear();

        // iterate over the tracked list.
        foreach (var category in this.listBoxCategories.Items)
        {
            // add each item from the tracked list into the list to be saved.
            this.categories.Add((Category)category);
        }
    }

    #region init
    /// <summary>
    /// Initializes the data-binding of components to arbitrary values.
    /// </summary>
    private void InitializeDataControls()
    {
        // setup the list of categories.
        this.listBoxCategories.DisplayMember = "Name";
        this.listBoxCategories.ValueMember = "Key";
    }

    /// <summary>
    /// Initializes all tooltips associated with this board.
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
        this.listBoxCategories.SelectedIndexChanged += this.RefreshForm;

        // if the key changes, update it.
        this.textBoxKey.TextChanged += this.UpdateKey;

        // if the name changes, update it.
        this.textBoxName.TextChanged += this.UpdateName;

        // if the quantity changes, update it.
        this.textBoxDescription.TextChanged += this.UpdateDescription;

        // if the icon index changes, update it.
        this.numIconIndex.ValueChanged += this.UpdateIconIndex;

        // if the unlocked by default changes, update it.
        this.checkBoxUnlockedByDefault.CheckedChanged += this.UpdateUnlockedByDefault;
    }
    #endregion

    #region update
    private void UpdateKey(object? sender, EventArgs e)
    {
        var selectedItem = (Category)this.listBoxCategories.SelectedItem!;

        if (selectedItem is null) return;

        selectedItem.Key = this.textBoxKey.Text;

        this.listBoxCategories.Items[this.listBoxCategories.SelectedIndex] = selectedItem;
    }

    private void UpdateName(object? sender, EventArgs e)
    {
        var selectedItem = (Category)this.listBoxCategories.SelectedItem!;

        if (selectedItem is null) return;

        selectedItem.Name = this.textBoxName.Text;
        
        this.listBoxCategories.Items[this.listBoxCategories.SelectedIndex] = selectedItem;
    }

    private void UpdateDescription(object? sender, EventArgs e)
    {
        var selectedItem = (Category)this.listBoxCategories.SelectedItem!;

        if (selectedItem is null) return;

        selectedItem.Description = this.textBoxDescription.Text;
    }

    private void UpdateIconIndex(object? sender, EventArgs e)
    {
        var selectedItem = (Category)this.listBoxCategories.SelectedItem!;

        if (selectedItem is null) return;

        selectedItem.IconIndex = (int)this.numIconIndex.Value;
    }

    private void UpdateUnlockedByDefault(object? sender, EventArgs e)
    {
        var selectedItem = (Category)this.listBoxCategories.SelectedItem!;

        if (selectedItem is null) return;

        selectedItem.UnlockedByDefault = this.checkBoxUnlockedByDefault.Checked;
    }
    #endregion

    private void buttonAddCategory_Click(object sender, EventArgs e)
    {
        // define the new SDP.
        var newItem = Category.NEW;

        // grab the current selection.
        var selectedIndex = this.listBoxCategories.SelectedIndex;

        // check if there was no current selection.
        if (selectedIndex == -1 || (selectedIndex == this.listBoxCategories.Items.Count - 1))
        {
            // add the item to the list without regard for index.
            this.listBoxCategories.Items.Add(newItem);
        }
        // we are in the middle somewhere.
        else
        {
            // add it at the given index.
            this.listBoxCategories.Items.Insert(selectedIndex, newItem);
        }
    }

    private void buttonDeleteCategory_Click(object sender, EventArgs e)
    {
        // grab the selection the user is considering removing.
        var removalIndex = this.listBoxCategories.SelectedIndex;

        // check if there is no index selected right now.
        if (removalIndex == -1)
        {
            // do nothing.
            return;
        }

        // grab the current panel we're working with.
        var selectedItem = (Category)this.listBoxCategories.SelectedItem!;

        // define the prompt.
        var removalPrompt = $"Are you sure you want to remove the category with key [{selectedItem.Key}]?";

        // show the box with the prompt.
        var dialogResult = MessageBox.Show(
            removalPrompt,
            "Removing a Category",
            MessageBoxButtons.OKCancel);

        // pivot on the user decisions.
        switch (dialogResult)
        {
            case DialogResult.OK:
                this.listBoxCategories.Items.RemoveAt(removalIndex);
                if (this.listBoxCategories.Items.Count != 0)
                {
                    this.listBoxCategories.SelectedIndex = 0;
                }

                break;
            case DialogResult.Cancel:
                break;
        }
    }

    #region refresh
    private void RefreshForm(object? sender, EventArgs e)
    {
        this._RefreshForm();
    }

    private void _RefreshForm()
    {
        // refresh recipe data.
        this.RenderCategoryData();
    }

    private void RenderCategoryData()
    {
        var selectedItem = (Category)this.listBoxCategories.SelectedItem!;

        if (selectedItem is null) return;

        this.textBoxKey.Text = selectedItem.Key;
        this.textBoxName.Text = selectedItem.Name;
        this.textBoxDescription.Text = selectedItem.Description;
        this.numIconIndex.Value = selectedItem.IconIndex;
    }

    private void RefreshCategoryData()
    {
        this.listBoxCategories.Items.Clear();

        this.categories.ForEach(category =>
        {
            if (category is null) return;

            this.listBoxCategories.Items.Add(category);
        });
    }

    #endregion

    #region setup

    public void Setup(List<Category> data)
    {
        if (!this.needsSetup) return;

        this.categories = data;

        this.RefreshCategoryData();

        this.needsSetup = false;
    }
    #endregion
}
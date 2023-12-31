using JMZ.Crafting.Data.Extensions;
using JMZ.Crafting.Data.Models;
using JMZ.Dashboard.Caches;
using JMZ.Rmmz.Data.Models.db.@base;
using JMZ.Rmmz.Data.Models.db.implementations;

namespace JMZ.Dashboard.Boards.Craft;

/// <summary>
/// A helper form for conveniently managing components for recipes.
/// </summary>
public partial class CraftComponentHelper : Form
{
    private bool needsSetup = true;

    private readonly Component currentComponent;

    /// <summary>
    /// Gets the component from the helper in its current state.
    /// </summary>
    /// <returns></returns>
    public Component CurrentComponent()
    {
        return this.currentComponent.Clone();
    }

    public CraftComponentHelper()
    {
        InitializeComponent();

        currentComponent = new();

        this.InitializeDataControls();
        this.InitializeTooltips();
        this.ApplyUpdateEvents();
    }

    #region init
    /// <summary>
    /// Initializes the data-binding of components to arbitrary values.
    /// </summary>
    private void InitializeDataControls()
    {
        // setup the list of component types.
        this.comboBoxTypes.DisplayMember = "Key";
        this.comboBoxTypes.ValueMember = "Name";

        // setup the list of components from the component type.
        this.listBoxComponents.DisplayMember = "Name";
        this.listBoxComponents.ValueMember = "Id";
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
        // if the component type changes, refresh all of the form.
        this.comboBoxTypes.SelectedIndexChanged += this.RefreshForm;

        // if the component chosen changes, update the component.
        this.listBoxComponents.SelectedIndexChanged += this.UpdateComponent;

        // if the user is trying to search, then filter the component results.
        this.textBoxDataFilter.TextChanged += this.OnFilterText;

        // if the quantity changes, update the component.
        this.numQuantity.ValueChanged += this.OnQuantityChange;
    }
    #endregion

    #region update
    private void UpdateComponent(object? sender, EventArgs e)
    {
        // if there are no components to select, then do not update.
        if (this.listBoxComponents.Items.Count == 0) return;

        // determine the selected item.
        var item = (RPG_BaseItem)this.listBoxComponents.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // update the id of the component.
        this.currentComponent.Id = item.id;
        this.textBoxCurrentId.Text = this.currentComponent.Id.ToString();

        // update the type of the component.
        this.currentComponent.Type = ((ComponentType)comboBoxTypes.SelectedItem).ToAbbreviation();
        this.textBoxCurrentType.Text = this.currentComponent.Type;

        // update the quantity.
        this.currentComponent.Count = (int)numQuantity.Value;
        this.textBoxCurrentCount.Text = this.currentComponent.Count.ToString();

        // also update the name for display purposes only.
        this.currentComponent.Name = item.name;
    }

    private void OnFilterText(object? sender, EventArgs e)
    {
        var currentFilterText = textBoxDataFilter.Text;
        if (string.IsNullOrWhiteSpace(currentFilterText))
        {
            this.RefreshComponentData();
        }
        else
        {
            var selectedItem = (ComponentType)this.comboBoxTypes.SelectedItem!;

            var items = new List<RPG_BaseItem>();

            switch (selectedItem)
            {
                case ComponentType.Item:
                    items.AddRange(Items.Cache.Values);
                    break;
                case ComponentType.Weapon:
                    items.AddRange(Weapons.Cache.Values);
                    break;
                case ComponentType.Armor:
                    items.AddRange(Armors.Cache.Values);
                    break;
            }

            this.listBoxComponents.Items.Clear();

            items
                .Where(item => item.name.ToLower().Contains(currentFilterText))
                .ToList()
                .ForEach(item => this.listBoxComponents.Items.Add(item));
        }
    }

    private void OnQuantityChange(object? sender, EventArgs e)
    {
        // determine the new quantity.
        var quantity = (int)numQuantity.Value;

        // update the component with this quantity.
        this.currentComponent.Count = quantity;

        // update the visual indicator.
        this.textBoxCurrentCount.Text = quantity.ToString();
    }

    #endregion

    #region refresh
    private void RefreshForm(object? sender, EventArgs e)
    {
        this._RefreshForm();
    }

    private void _RefreshForm()
    {
        // refresh recipe data.
        this.RefreshComponentData();
    }

    private void RefreshComponentData()
    {
        var selectedItem = (ComponentType)this.comboBoxTypes.SelectedItem!;

        this.listBoxComponents.Items.Clear();

        this.listBoxComponents.Enabled = true;
        this.textBoxDataFilter.Enabled = true;

        switch (selectedItem)
        {
            case ComponentType.Item:
                this.PopulateComponentsWithCache(Items.Cache.Values);
                break;
            case ComponentType.Weapon:
                this.PopulateComponentsWithCache(Weapons.Cache.Values);
                break;
            case ComponentType.Armor:
                this.PopulateComponentsWithCache(Armors.Cache.Values);
                break;
            case ComponentType.Gold:
                this.listBoxComponents.Enabled = false;
                this.textBoxDataFilter.Enabled = false;
                this.currentComponent.Type = "g";
                this.currentComponent.Name = "GOLD";
                this.currentComponent.Id = 0;
                break;
            case ComponentType.SDP:
                this.listBoxComponents.Enabled = false;
                this.textBoxDataFilter.Enabled = false;
                this.currentComponent.Type = "s";
                this.currentComponent.Name = "SDP";
                this.currentComponent.Id = 0;
                break;
            default:
                // do nothing if not implemented.
                break;
        }

        this.RefreshCurrentComponentVisual();
    }

    private void RefreshCurrentComponentVisual()
    {
        this.textBoxCurrentCount.Text = this.currentComponent.Count.ToString();
        this.textBoxCurrentId.Text = this.currentComponent.Id.ToString();
        this.textBoxCurrentType.Text = this.currentComponent.Type;
    }

    /// <summary>
    /// Populates the list of components based on the provided cache.
    /// </summary>
    private void PopulateComponentsWithCache<T>(IEnumerable<T> cache)
    {
        // iterate over the cache dictionary.
        cache.ToList().ForEach(value =>
        {
            // just in case there is null, don't process it.
            if (value is null) return;

            // add the cached item to the collection.
            this.listBoxComponents.Items.Add(value);
        });

        // check if we have any items after adding the cache.
        if (this.listBoxComponents.Items.Count > 0)
        {
            // select the first item in the list.
            this.listBoxComponents.SelectedIndex = 0;
        }
    }

    #endregion

    #region setup
    public void Setup()
    {
        if (!this.needsSetup) return;

        this.comboBoxTypes.DataSource = Enum.GetValues(typeof(ComponentType));

        this.RefreshComponentData();

        this.needsSetup = false;
    }
    #endregion
}
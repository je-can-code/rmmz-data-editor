using JMZ.Crafting.Data.Extensions;
using JMZ.Crafting.Data.Models;
using JMZ.Json.Data.Caches;
using JMZ.Rmmz.Data.Models.db.@base;

namespace JMZ.Dashboard.Boards.Craft;

/// <summary>
///     A helper form for conveniently managing components for recipes.
/// </summary>
public partial class CraftComponentHelper : Form
{
    private readonly Component currentComponent;
    private bool needsSetup = true;

    public CraftComponentHelper()
    {
        InitializeComponent();

        currentComponent = new();

        InitializeDataControls();
        InitializeTooltips();
        ApplyUpdateEvents();
    }

    /// <summary>
    ///     Gets the component from the helper in its current state.
    /// </summary>
    /// <returns></returns>
    public Component CurrentComponent()
    {
        return currentComponent.Clone();
    }

    #region setup
    public void Setup()
    {
        if (!needsSetup) return;

        comboBoxTypes.DataSource = Enum.GetValues(typeof(ComponentType));

        RefreshComponentData();

        needsSetup = false;
    }
    #endregion

    #region init
    /// <summary>
    ///     Initializes the data-binding of components to arbitrary values.
    /// </summary>
    private void InitializeDataControls()
    {
        // setup the list of component types.
        comboBoxTypes.DisplayMember = "Key";
        comboBoxTypes.ValueMember = "Name";

        // setup the list of components from the component type.
        listBoxComponents.DisplayMember = "Name";
        listBoxComponents.ValueMember = "Id";
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
        // if the component type changes, refresh all of the form.
        comboBoxTypes.SelectedIndexChanged += RefreshForm;

        // if the component chosen changes, update the component.
        listBoxComponents.SelectedIndexChanged += UpdateComponent;

        // if the user is trying to search, then filter the component results.
        textBoxDataFilter.TextChanged += OnFilterText;

        // if the quantity changes, update the component.
        numQuantity.ValueChanged += OnQuantityChange;
    }
    #endregion

    #region update
    private void UpdateComponent(object? sender, EventArgs e)
    {
        // if there are no components to select, then do not update.
        if (listBoxComponents.Items.Count == 0) return;

        // determine the selected item.
        var item = (RPG_BaseItem)listBoxComponents.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // update the id of the component.
        currentComponent.Id = item.id;
        textBoxCurrentId.Text = currentComponent.Id.ToString();

        // update the type of the component.
        currentComponent.Type = ((ComponentType)comboBoxTypes.SelectedItem!).ToAbbreviation();
        textBoxCurrentType.Text = currentComponent.Type;

        // update the quantity.
        currentComponent.Count = (int)numQuantity.Value;
        textBoxCurrentCount.Text = currentComponent.Count.ToString();

        // also update the name for display purposes only.
        currentComponent.Name = item.name;
    }

    private void OnFilterText(object? sender, EventArgs e)
    {
        var currentFilterText = textBoxDataFilter.Text;
        if (string.IsNullOrWhiteSpace(currentFilterText))
        {
            RefreshComponentData();
        }
        else
        {
            var selectedItem = (ComponentType)comboBoxTypes.SelectedItem!;

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

            listBoxComponents.Items.Clear();

            items.Where(
                    item => item.name
                        .ToLower()
                        .Contains(currentFilterText))
                .ToList()
                .ForEach(item => listBoxComponents.Items.Add(item));
        }
    }

    private void OnQuantityChange(object? sender, EventArgs e)
    {
        // determine the new quantity.
        var quantity = (int)numQuantity.Value;

        // update the component with this quantity.
        currentComponent.Count = quantity;

        // update the visual indicator.
        textBoxCurrentCount.Text = quantity.ToString();
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
        RefreshComponentData();
    }

    private void RefreshComponentData()
    {
        var selectedItem = (ComponentType)comboBoxTypes.SelectedItem!;

        listBoxComponents.Items.Clear();

        listBoxComponents.Enabled = true;
        textBoxDataFilter.Enabled = true;

        switch (selectedItem)
        {
            case ComponentType.Item:
                PopulateComponentsWithCache(Items.Cache.Values);
                break;
            case ComponentType.Weapon:
                PopulateComponentsWithCache(Weapons.Cache.Values);
                break;
            case ComponentType.Armor:
                PopulateComponentsWithCache(Armors.Cache.Values);
                break;
            case ComponentType.Gold:
                listBoxComponents.Enabled = false;
                textBoxDataFilter.Enabled = false;
                currentComponent.Type = "g";
                currentComponent.Name = "GOLD";
                currentComponent.Id = 0;
                break;
            case ComponentType.SDP:
                listBoxComponents.Enabled = false;
                textBoxDataFilter.Enabled = false;
                currentComponent.Type = "s";
                currentComponent.Name = "SDP";
                currentComponent.Id = 0;
                break;
        }

        RefreshCurrentComponentVisual();
    }

    private void RefreshCurrentComponentVisual()
    {
        textBoxCurrentCount.Text = currentComponent.Count.ToString();
        textBoxCurrentId.Text = currentComponent.Id.ToString();
        textBoxCurrentType.Text = currentComponent.Type;
    }

    /// <summary>
    ///     Populates the list of components based on the provided cache.
    /// </summary>
    private void PopulateComponentsWithCache<T>(IEnumerable<T> cache)
    {
        // iterate over the cache dictionary.
        cache.ToList()
            .ForEach(
                value =>
                {
                    // just in case there is null, don't process it.
                    if (value is null) return;

                    // add the cached item to the collection.
                    listBoxComponents.Items.Add(value);
                });

        // check if we have any items after adding the cache.
        if (listBoxComponents.Items.Count > 0)
        {
            // select the first item in the list.
            listBoxComponents.SelectedIndex = 0;
        }
    }
    #endregion
}
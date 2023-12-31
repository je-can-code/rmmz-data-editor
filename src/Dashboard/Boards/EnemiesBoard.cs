using JMZ.Crafting.Data.Models;
using JMZ.Dashboard.Boards.Craft;
using JMZ.Dashboard.Mappers;
using JMZ.Rmmz.Data.Models.db.implementations;
using JMZ.Drops.Data.Extensions.implementations._Enemy;
using JMZ.Sdp.Data.Extensions.implementations._Enemy;

namespace JMZ.Dashboard.Boards;

public partial class EnemiesBoard : Form
{
    /// <summary>
    /// The running list of parsed data including any edits made by the user.
    /// </summary>
    private List<RPG_Enemy> enemiesList = new();

    private readonly CraftComponentHelper dropHelper;


    /// <summary>
    /// Whether or not this form needs setup.
    /// </summary>
    private bool needsSetup = true;

    /// <summary>
    /// Constructor.
    /// </summary>
    public EnemiesBoard()
    {
        InitializeComponent();

        this.dropHelper = new();
        this.SetupBoards();

        this.InitializeDataControls();
        this.InitializeTooltips();
        this.ApplyUpdateEvents();
    }

    private void SetupBoards()
    {
        this.dropHelper.FormClosing += HideBoard;
        this.dropHelper.Setup();
    }

    /// <summary>
    /// An event handler for hiding the boards instead of closing them.
    /// </summary>
    private static void HideBoard(object? sender, FormClosingEventArgs e)
    {
        // make sure its the user trying to close the window, first.
        if (e.CloseReason != CloseReason.UserClosing) return;

        // actually don't close and dispose of the window.
        e.Cancel = true;

        // hide the window instead.
        ((Form)sender!).Hide();
    }

    #region init
    /// <summary>
    /// Initializes the data-binding of components to arbitrary values.
    /// </summary>
    private void InitializeDataControls()
    {
        // setup the main list box of SDPs.
        this.listBoxEnemies.DisplayMember = "name";
        this.listBoxEnemies.ValueMember = "id";
        this.listBoxEnemies.SelectedIndexChanged += this.RefreshForm;

        this.listBoxDrops.DisplayMember = "DropChanceName";
        this.listBoxDrops.ValueMember = "Id";
    }

    /// <summary>
    /// Initializes all tooltips associated with this board.
    /// </summary>
    private void InitializeTooltips()
    {
        /*
        _toolTip = new();
        _toolTip.AutoPopDelay = 5000;
        _toolTip.InitialDelay = 1000;
        _toolTip.ReshowDelay = 500;
        _toolTip.ToolTipIcon = ToolTipIcon.Info;
        _toolTip.ToolTipTitle = "Details and Usage";

        var keyTip = """
            The unique identifying key of the recipe.
            Use this to refer to this recipe when using various plugin commands or scripts.

            This is required, and will cause issues if left blank.
            """;
        _toolTip.SetToolTip(this.textBox_key, keyTip);
        */
    }

    private void ApplyUpdateEvents()
    {
        this.ApplyUpdateEventsForCoreData();
    }

    private void ApplyUpdateEventsForCoreData()
    {
        this.textBoxName.TextChanged += this.UpdateName;
    }
    #endregion

    public List<RPG_Enemy> Enemies()
    {
        return this.enemiesList;
    }

    #region drop helper
    private void buttonDropHelper_Click(object sender, EventArgs e)
    {
        this.dropHelper.Show();
    }

    private void buttonCloneToDrops_Click(object sender, EventArgs e)
    {
        // determine the selected item.
        var selectedEnemy = (RPG_Enemy?)this.listBoxEnemies.SelectedItem!;

        // don't update if it was null.
        if (selectedEnemy is null) return;

        // grab the current state of the component from the helper.
        var chosenDrop = this.dropHelper.CurrentComponent();

        // insert that item into the ingredients list.
        this.listBoxDrops.Items.Add(chosenDrop);

        var dropList = this.listBoxDrops.Items
            .OfType<Component>()
            .Select(component => component.ToDropItem())
            .ToList();

        // add the drop to the enemy, too.
        selectedEnemy.UpdateDropsData(dropList);
    }

    private void buttonDeleteDrop_Click(object sender, EventArgs e)
    {
        // determine the selected item.
        var selectedEnemy = (RPG_Enemy?)this.listBoxEnemies.SelectedItem!;

        // don't update if it was null.
        if (selectedEnemy is null) return;

        // shorthand the listbox.
        var listbox = this.listBoxDrops;

        // identify what we're removing.
        var removalIndex = listbox.SelectedIndex;
        if (removalIndex == -1) return;

        // remove the item from the display.
        listbox.Items.RemoveAt(removalIndex);
        if (listbox.Items.Count != 0)
        {
            listbox.SelectedIndex = 0;
        }

        // update the enemy's tracking based on the new drop data.
        var dropList = this.listBoxDrops.Items
            .OfType<Component>()
            .Select(component => component.ToDropItem())
            .ToList();
        selectedEnemy.UpdateDropsData(dropList);
    }
    #endregion

    private (RPG_Enemy enemy, int index) GetEnemySelection()
    {
        // determine the selection.
        var selectedItem = (RPG_Enemy?)this.listBoxEnemies.SelectedItem;

        if (selectedItem == null) throw new IndexOutOfRangeException("could not find the current selection for some reason");

        // find the index of the selection in our local list.
        var index = this.enemiesList.FindIndex(data => data != null && data.id == selectedItem!.id);

        // return both data points.
        return new(selectedItem, index);
    }

    private void UpdateEnemyData(RPG_Enemy enemy, int index)
    {
        this.listBoxEnemies.Items[index - 1] = enemy;
    }

    private void UpdateName(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (enemy, index) = this.GetEnemySelection();

        var name = this.textBoxName.Text;

        enemy.name = name;

        this.UpdateEnemyData(enemy, index);
    }

    private void checkBoxHasPanelDrop_CheckedChanged(object sender, EventArgs e)
    {
        var isAlreadyChecked = this.checkBoxHasPanelDrop.Checked;

        if (isAlreadyChecked)
        {
            numSdpChance.Enabled = false;
            textSdpKey.Enabled = false;
        }
        else
        {
            numSdpChance.Enabled = true;
            textSdpKey.Enabled = true;
        }
    }

    private void buttonCloneToSdpDrop_Click(object sender, EventArgs e)
    {

    }

    private void buttonDeleteSdpDrop_Click(object sender, EventArgs e)
    {

    }
    
    #region refresh
    private void RefreshForm(object? sender, EventArgs e)
    {
        this._RefreshForm();
    }

    private void _RefreshForm()
    {
        this.RefreshEnemies();

        this.RefreshDrops();

        this.RefreshSdp();

        // update other data in form here.
    }

    private void RefreshEnemies()
    {
        var selectedEnemy = (RPG_Enemy?)this.listBoxEnemies.SelectedItem;
        if (selectedEnemy is null) return;

        this.textBoxName.Text = selectedEnemy.name;
        this.labelTextId.Text = selectedEnemy.id.ToString();
    }

    private void RefreshDrops()
    {
        this.listBoxDrops.Items.Clear();

        var selectedEnemy = (RPG_Enemy?)this.listBoxEnemies.SelectedItem;
        if (selectedEnemy is null) return;

        var extraDrops = selectedEnemy.GetDropsData();
        if (!extraDrops.Any()) return;

        extraDrops.ForEach(extraDrop =>
        {
            var extraComponent = extraDrop.ToComponent();
            extraComponent.Name = extraComponent.GetDisplayName();

            this.listBoxDrops.Items.Add(extraComponent);
        });
    }

    private void RefreshSdp()
    {
        var selectedEnemy = (RPG_Enemy?)this.listBoxEnemies.SelectedItem;
        if (selectedEnemy is null) return;

        var sdpData = selectedEnemy.GetSdpData();
        this.textSdpKey.Text = sdpData.Key;
        this.numSdpChance.Value = sdpData.DropChance;
        // this.numSdpItemId.Value = sdpData.ItemId;
        
        this.numSdpPoints.Value = selectedEnemy.GetSdpPoints();
    }

    #endregion

    #region setup
    public void FlagForRefresh()
    {
        this.needsSetup = true;
    }

    public void SetupComplete()
    {
        this.needsSetup = false;
    }

    public void Setup(List<RPG_Enemy> enemies)
    {
        if (!this.needsSetup) return;

        // populate the list of weapons.
        this.PopulateEnemiesList(enemies);

        // check if we need to autopick an index.
        if (this.listBoxEnemies.SelectedIndex == -1)
        {
            // set the index to the first item.
            this.listBoxEnemies.SelectedIndex = 0;
        }
    }

    private void PopulateEnemiesList(List<RPG_Enemy> enemies)
    {
        // assign the list of weapons locally to the form.
        this.enemiesList = enemies;

        // iterate over each of the weapons in the list 
        this.enemiesList.ForEach(enemy =>
        {
            // the first weapon in the list is always null, so accommodate.
            if (enemy != null)
            {
                // add the weapon to the running list.
                this.listBoxEnemies.Items.Add(enemy);
            }
        });

        // let this form know we've finished setup.
        this.SetupComplete();
    }
    #endregion setup
}

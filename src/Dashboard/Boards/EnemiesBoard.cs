using JMZ.Crafting.Data.Models;
using JMZ.Dashboard.Boards.Craft;
using JMZ.Dashboard.Mappers;
using JMZ.Dashboard.Utils;
using JMZ.Rmmz.Data.Models.db.implementations;
using JMZ.Drops.Data.Extensions.implementations._Enemy;
using JMZ.JABS.Data.Extensions.implementations._Enemy;
using JMZ.LevelMaster.Data.Extensions.implementations._Enemy;
using JMZ.Rmmz.Data.Extensions.db.@base._Base;
using JMZ.Rmmz.Data.Extensions.db.implementations._Enemy;
using JMZ.Sdp.Data.Extensions.implementations._Enemy;

namespace JMZ.Dashboard.Boards;

public partial class EnemiesBoard : Form
{
    /// <summary>
    /// The running list of parsed data including any edits made by the user.
    /// </summary>
    private List<RPG_Enemy> enemiesList = [];

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
        this.InitializeComponent();

        this.dropHelper = new();
        this.SetupBoards();

        this.InitializeDataControls();
        this.InitializeTooltips();
        this.ApplyUpdateEvents();
    }

    private void SetupBoards()
    {
        this.dropHelper.FormClosing += FormUtils.HideBoard;
        this.dropHelper.Setup();
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
        this.ApplyUpdateEventsForJabsData();
    }

    private void ApplyUpdateEventsForCoreData()
    {
        this.textBoxName.TextChanged += this.UpdateName;

        this.numLevel.ValueChanged += this.UpdateLevel;
        this.numExperience.ValueChanged += this.UpdateRewardExperience;
        this.numGold.ValueChanged += this.UpdateRewardGold;

        this.numMaxHp.ValueChanged += this.UpdateParamMaxHp;
        this.numMaxMp.ValueChanged += this.UpdateParamMaxMp;
        
        // TODO: implement TP updating and retrieval.
        this.numMaxTp.ValueChanged += this.UpdateParamMaxTp;
        
        this.numParamPower.ValueChanged += this.UpdateParamPower;
        this.numParamEndurance.ValueChanged += this.UpdateParamEndurance;
        this.numParamForce.ValueChanged += this.UpdateParamForce;
        this.numParamResistance.ValueChanged += this.UpdateParamResistance;
        this.numParamSpeed.ValueChanged += this.UpdateParamSpeed;
        this.numParamLuck.ValueChanged += this.UpdateParamLuck;

        this.numSdpPoints.ValueChanged += this.UpdateSdpPoints;
        // SDP data updates are handled with GUI buttons.
    }

    private void ApplyUpdateEventsForJabsData()
    {
        this.numJabsSight.ValueChanged += this.UpdateJabsSight;
        this.numJabsSightAlerted.ValueChanged += this.UpdateJabsSightAlerted;
        this.numJabsPursuit.ValueChanged += this.UpdateJabsPursuit;
        this.numJabsPursuitAlerted.ValueChanged += this.UpdateJabsPursuitAlerted;
    }
    #endregion

    public List<RPG_Enemy> Enemies()
    {
        return this.enemiesList;
    }
    
    // TODO: figure out how the clipboard works so we can setup keyboard shortcuts.
    // protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    // {
    //     if (this.ActiveControl == this.listBoxEnemies)
    //     {
    //         switch (keyData)
    //         {
    //             // copy
    //             case Keys.Control | Keys.C:
    //                 // this.CloneEnemyToClipboard();
    //                 return true;
    //             // pasta
    //             case Keys.Control | Keys.V:
    //                 // this.PasteEnemyToListbox();
    //                 return true;
    //         }
    //     }
    //
    //     return base.ProcessCmdKey(ref msg, keyData);
    // }

    private void CloneEnemyToClipboard()
    {
        // grab the item from the listbox.
        var selectedItem = (RPG_Enemy)this.listBoxEnemies.SelectedItem!;

        // if there is no selected item, then don't clone it to the clipboard.
        if (selectedItem is null) return;

        var data = new DataObject("rpg_enemy", selectedItem);
        
        // set the enemy to the clipboard.
        Clipboard.SetDataObject(data);
    }

    private void PasteEnemyToListbox()
    {
        var clipboardItem = Clipboard.GetDataObject();

        if (clipboardItem?.GetData("rpg_enemy") is not RPG_Enemy copiedEnemy) return;
        
        // for user-friendliness, we clone right next to where the cursor is.
        var selectedIndex = this.listBoxEnemies.SelectedIndex;
        
        // check if there was no current selection.
        if (selectedIndex == -1 || selectedIndex == this.listBoxEnemies.Items.Count - 1)
        {
            // add the item to the list without regard for index.
            this.listBoxEnemies.Items.Add(copiedEnemy);
        }
        // we are in the middle somewhere.
        else
        {
            // add it at the given index.
            this.listBoxEnemies.Items.Insert(selectedIndex, copiedEnemy);
        }
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
        var index = this.enemiesList.FindIndex(data => data != null && data.id == selectedItem.id);

        // return both data points.
        return new(selectedItem, index);
    }

    private void UpdateEnemyData(RPG_Enemy enemy, int index)
    {
        this.listBoxEnemies.Items[index - 1] = enemy;
    }

    #region parameters
    private void UpdateName(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (enemy, index) = this.GetEnemySelection();

        // grab the value out of the field.
        var name = this.textBoxName.Text;

        // update the value on the source.
        enemy.UpdateName(name);

        // refresh the item in the list.
        this.UpdateEnemyData(enemy, index);
    }

    private void UpdateLevel(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (enemy, index) = this.GetEnemySelection();

        // grab the value out of the field.
        var level = this.numLevel.Value;

        // update the value on the source.
        enemy.UpdateLevel(level);

        // refresh the item in the list.
        this.UpdateEnemyData(enemy, index);
    }

    private void UpdateParamMaxHp(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (enemy, index) = this.GetEnemySelection();

        // grab the value out of the field.
        var value = this.numMaxHp.Value;

        // update the value on the source.
        enemy.UpdateBaseParamMaxHp(value);

        // refresh the item in the list.
        this.UpdateEnemyData(enemy, index);
    }

    private void UpdateParamMaxMp(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (enemy, index) = this.GetEnemySelection();

        // grab the value out of the field.
        var value = this.numMaxMp.Value;

        // update the value on the source.
        enemy.UpdateBaseParamMaxMp(value);

        // refresh the item in the list.
        this.UpdateEnemyData(enemy, index);
    }

    private void UpdateParamMaxTp(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (enemy, index) = this.GetEnemySelection();

        // grab the value out of the field.
        var value = this.numMaxTp.Value;

        // update the value on the source.
        // TODO: implement TP update.
        //enemy.UpdateBaseParamMaxTp(value);

        // refresh the item in the list.
        this.UpdateEnemyData(enemy, index);
    }

    private void UpdateParamPower(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (enemy, index) = this.GetEnemySelection();

        // grab the value out of the field.
        var value = this.numParamPower.Value;

        // update the value on the source.
        enemy.UpdateBaseParamPower(value);

        // refresh the item in the list.
        this.UpdateEnemyData(enemy, index);
    }

    private void UpdateParamEndurance(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (enemy, index) = this.GetEnemySelection();

        // grab the value out of the field.
        var value = this.numParamEndurance.Value;

        // update the value on the source.
        enemy.UpdateBaseParamEndurance(value);

        // refresh the item in the list.
        this.UpdateEnemyData(enemy, index);
    }

    private void UpdateParamForce(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (enemy, index) = this.GetEnemySelection();

        // grab the value out of the field.
        var value = this.numParamForce.Value;

        // update the value on the source.
        enemy.UpdateBaseParamForce(value);

        // refresh the item in the list.
        this.UpdateEnemyData(enemy, index);
    }

    private void UpdateParamResistance(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (enemy, index) = this.GetEnemySelection();

        // grab the value out of the field.
        var value = this.numParamResistance.Value;

        // update the value on the source.
        enemy.UpdateBaseParamResistance(value);

        // refresh the item in the list.
        this.UpdateEnemyData(enemy, index);
    }

    private void UpdateParamSpeed(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (enemy, index) = this.GetEnemySelection();

        // grab the value out of the field.
        var value = this.numParamSpeed.Value;

        // update the value on the source.
        enemy.UpdateBaseParamSpeed(value);

        // refresh the item in the list.
        this.UpdateEnemyData(enemy, index);
    }

    private void UpdateParamLuck(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (enemy, index) = this.GetEnemySelection();

        // grab the value out of the field.
        var value = this.numParamLuck.Value;

        // update the value on the source.
        enemy.UpdateBaseParamLuck(value);

        // refresh the item in the list.
        this.UpdateEnemyData(enemy, index);
    }

    private void UpdateRewardExperience(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (enemy, index) = this.GetEnemySelection();

        // grab the value out of the field.
        var value = this.numExperience.Value;

        // update the value on the source.
        enemy.UpdateExperience(value);

        // refresh the item in the list.
        this.UpdateEnemyData(enemy, index);
    }

    private void UpdateRewardGold(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (enemy, index) = this.GetEnemySelection();

        // grab the value out of the field.
        var value = this.numGold.Value;

        // update the value on the source.
        enemy.UpdateGold(value);

        // refresh the item in the list.
        this.UpdateEnemyData(enemy, index);
    }
    #endregion parameters

    #region sdp
    private void UpdateSdpPoints(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (enemy, index) = this.GetEnemySelection();

        // grab the value out of the field.
        var points = this.numSdpPoints.Value;

        // update the value on the source.
        enemy.UpdateSdpPoints(points);

        // refresh the item in the list.
        this.UpdateEnemyData(enemy, index);
    }

    private void UpdateSdpData()
    {
        // get the data of the selected item.
        var (enemy, index) = this.GetEnemySelection();

        // make sure the checkbox is enabled indicating we have SDP.
        if (this.checkBoxHasPanelDrop.Checked)
        {
            // grab the SDP values out.
            var key = this.textSdpKey.Text;
            var chance = this.numSdpChance.Value;
            var itemId = this.labelSdpItemIdValue.Text;
        
            // update the SDP data.
            enemy.UpdateSdpData(key, chance, decimal.Parse(itemId));
        }
        // the checkbox was disabled, so remove the data instead.
        else
        {
            // remove the SDP data.
            enemy.UpdateSdpData(string.Empty, 0, 0);
        }
        
        // and update the data in the list.
        this.UpdateEnemyData(enemy, index);
    }

    private void checkBoxHasPanelDrop_CheckedChanged(object sender, EventArgs e)
    {
        var isAlreadyChecked = this.checkBoxHasPanelDrop.Checked;

        if (isAlreadyChecked)
        {
            this.numSdpChance.Enabled = true;
            this.textSdpKey.Enabled = true;
        }
        else
        {
            this.numSdpChance.Enabled = false;
            this.textSdpKey.Enabled = false;
        }
    }

    private void buttonCloneToSdpDrop_Click(object sender, EventArgs e)
    {
        // determine the selected item.
        var enemy = (RPG_Enemy)this.listBoxEnemies.SelectedItem!;

        // don't update if it was null.
        if (enemy is null) return;

        // grab the current state of the component from the helper.
        var helperComponent = this.dropHelper.CurrentComponent();

        // update the label with the selection from the helper.
        this.labelSdpItemIdValue.Text = helperComponent.Id.ToString();
    }
    
    private void buttonUpdateSdpData_Click(object sender, EventArgs e)
    {
        this.UpdateSdpData();
    }

    private void buttonRemoveSdpData_Click(object sender, EventArgs e)
    {
        this.textSdpKey.Text = string.Empty;
        this.numSdpChance.Value = 1;
        this.labelSdpItemIdValue.Text = decimal.MinusOne.ToString();
        this.ToggleSdpSection();
    }

    private void ToggleSdpSection(bool isEnabled = false)
    {
        this.checkBoxHasPanelDrop.Checked = isEnabled;
        this.textSdpKey.Enabled = isEnabled;
        this.numSdpChance.Enabled = isEnabled;
    }
    #endregion sdp
    
    #region jabs
    private void UpdateJabsSight(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (enemy, index) = this.GetEnemySelection();

        // grab the value out of the field.
        var value = this.numJabsSight.Value;

        // update the value on the source.
        enemy.UpdateJabsSight(value);

        // refresh the item in the list.
        this.UpdateEnemyData(enemy, index);
    }
    
    private void UpdateJabsSightAlerted(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (enemy, index) = this.GetEnemySelection();

        // grab the value out of the field.
        var value = this.numJabsSightAlerted.Value;

        // update the value on the source.
        enemy.UpdateJabsAlertedSightBoost(value);

        // refresh the item in the list.
        this.UpdateEnemyData(enemy, index);
    }
    
    private void UpdateJabsPursuit(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (enemy, index) = this.GetEnemySelection();

        // grab the value out of the field.
        var value = this.numJabsPursuit.Value;

        // update the value on the source.
        enemy.UpdateJabsPursuit(value);

        // refresh the item in the list.
        this.UpdateEnemyData(enemy, index);
    }
    
    private void UpdateJabsPursuitAlerted(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (enemy, index) = this.GetEnemySelection();

        // grab the value out of the field.
        var value = this.numJabsPursuitAlerted.Value;

        // update the value on the source.
        enemy.UpdateJabsAlertedPursuitBoost(value);

        // refresh the item in the list.
        this.UpdateEnemyData(enemy, index);
    }
    #endregion jabs

    #region refresh
    private void RefreshForm(object? sender, EventArgs e)
    {
        this._RefreshForm();
    }

    private void _RefreshForm()
    {
        this.RefreshEnemies();

        this.RefreshParameters();

        this.RefreshDrops();

        this.RefreshSdp();

        this.RefreshJabs();

        // update other data in form here.
    }

    private void RefreshParameters()
    {
        var selectedEnemy = (RPG_Enemy?)this.listBoxEnemies.SelectedItem;
        if (selectedEnemy is null) return;

        this.numLevel.Value = selectedEnemy.GetLevel();

        this.numMaxHp.Value = selectedEnemy.GetBaseParamMaxHp();
        this.numMaxMp.Value = selectedEnemy.GetBaseParamMaxMp();

        // TODO: implement tp retrieval.
        // this.numMaxTp.Value = selectedEnemy.GetBaseParamMaxTp();

        this.numParamPower.Value = selectedEnemy.GetBaseParamPower();
        this.numParamEndurance.Value = selectedEnemy.GetBaseParamEndurance();
        this.numParamForce.Value = selectedEnemy.GetBaseParamForce();
        this.numParamResistance.Value = selectedEnemy.GetBaseParamResistance();
        this.numParamSpeed.Value = selectedEnemy.GetBaseParamSpeed();
        this.numParamLuck.Value = selectedEnemy.GetBaseParamLuck();

        this.numExperience.Value = selectedEnemy.GetExperience();
        this.numGold.Value = selectedEnemy.GetGold();
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

        var sdpKey = selectedEnemy.GetSdpKey();
        this.textSdpKey.Text = sdpKey;
        this.numSdpChance.Value = selectedEnemy.GetSdpDropChance();
        this.labelSdpItemIdValue.Text = selectedEnemy.GetSdpItemId().ToString();

        // no key means no SDP drop on this enemy.
        var hasSdp = !string.IsNullOrWhiteSpace(sdpKey);
        this.ToggleSdpSection(hasSdp);

        this.numSdpPoints.Value = selectedEnemy.GetSdpPoints();
    }

    private void RefreshJabs()
    {
        var selectedEnemy = (RPG_Enemy?)this.listBoxEnemies.SelectedItem;
        if (selectedEnemy is null) return;

        this.numJabsSight.Value = selectedEnemy.GetJabsSight();
        this.numJabsSightAlerted.Value = selectedEnemy.GetJabsAlertedSightBoost();
        this.numJabsPursuit.Value = selectedEnemy.GetJabsPursuit();
        this.numJabsPursuitAlerted.Value = selectedEnemy.GetJabsAlertedPursuitBoost();
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

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
        InitializeComponent();

        dropHelper = new();
        SetupBoards();

        InitializeDataControls();
        InitializeTooltips();
        ApplyUpdateEvents();
    }

    private void SetupBoards()
    {
        dropHelper.FormClosing += FormUtils.HideBoard;
        dropHelper.Setup();
    }

    #region init
    /// <summary>
    /// Initializes the data-binding of components to arbitrary values.
    /// </summary>
    private void InitializeDataControls()
    {
        // setup the main list box of SDPs.
        listBoxEnemies.DisplayMember = "name";
        listBoxEnemies.ValueMember = "id";
        listBoxEnemies.SelectedIndexChanged += RefreshForm;

        listBoxDrops.DisplayMember = "DropChanceName";
        listBoxDrops.ValueMember = "Id";
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
        ApplyUpdateEventsForCoreData();
        ApplyUpdateEventsForJabsData();
    }

    private void ApplyUpdateEventsForCoreData()
    {
        textBoxName.TextChanged += UpdateName;

        numLevel.ValueChanged += UpdateLevel;
        numExperience.ValueChanged += UpdateRewardExperience;
        numGold.ValueChanged += UpdateRewardGold;

        numMaxHp.ValueChanged += UpdateParamMaxHp;
        numMaxMp.ValueChanged += UpdateParamMaxMp;
        
        // TODO: implement TP updating and retrieval.
        numMaxTp.ValueChanged += UpdateParamMaxTp;
        
        numParamPower.ValueChanged += UpdateParamPower;
        numParamEndurance.ValueChanged += UpdateParamEndurance;
        numParamForce.ValueChanged += UpdateParamForce;
        numParamResistance.ValueChanged += UpdateParamResistance;
        numParamSpeed.ValueChanged += UpdateParamSpeed;
        numParamLuck.ValueChanged += UpdateParamLuck;

        numSdpPoints.ValueChanged += UpdateSdpPoints;
        // SDP data updates are handled with GUI buttons.
    }

    private void ApplyUpdateEventsForJabsData()
    {
        numJabsSight.ValueChanged += UpdateJabsSight;
        numJabsSightAlerted.ValueChanged += UpdateJabsSightAlerted;
        numJabsPursuit.ValueChanged += UpdateJabsPursuit;
        numJabsPursuitAlerted.ValueChanged += UpdateJabsPursuitAlerted;

        checkBoxAiTraitCareful.CheckedChanged += UpdateJabsAiTraitCareful;
        checkBoxAiTraitExecutor.CheckedChanged += UpdateJabsAiTraitExecutor;
        checkBoxAiTraitReckless.CheckedChanged += UpdateJabsAiTraitReckless;
        checkBoxAiTraitHealer.CheckedChanged += UpdateJabsAiTraitHealer;
        checkBoxAiTraitLeader.CheckedChanged += UpdateJabsAiTraitLeader;
        checkBoxAiTraitFollower.CheckedChanged += UpdateJabsAiTraitFollower;
    }
    #endregion

    public List<RPG_Enemy> Enemies()
    {
        return enemiesList;
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
        var selectedItem = (RPG_Enemy)listBoxEnemies.SelectedItem!;

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
        var selectedIndex = listBoxEnemies.SelectedIndex;
        
        // check if there was no current selection.
        if (selectedIndex == -1 || selectedIndex == listBoxEnemies.Items.Count - 1)
        {
            // add the item to the list without regard for index.
            listBoxEnemies.Items.Add(copiedEnemy);
        }
        // we are in the middle somewhere.
        else
        {
            // add it at the given index.
            listBoxEnemies.Items.Insert(selectedIndex, copiedEnemy);
        }
    }

    #region drop helper
    private void buttonDropHelper_Click(object sender, EventArgs e)
    {
        dropHelper.Show();
    }

    private void buttonCloneToDrops_Click(object sender, EventArgs e)
    {
        // determine the selected item.
        var selectedEnemy = (RPG_Enemy?)listBoxEnemies.SelectedItem!;

        // don't update if it was null.
        if (selectedEnemy is null) return;

        // grab the current state of the component from the helper.
        var chosenDrop = dropHelper.CurrentComponent();

        // insert that item into the ingredients list.
        listBoxDrops.Items.Add(chosenDrop);

        var dropList = listBoxDrops.Items
            .OfType<Component>()
            .Select(component => component.ToDropItem())
            .ToList();

        // add the drop to the enemy, too.
        selectedEnemy.UpdateDropsData(dropList);
    }

    private void buttonDeleteDrop_Click(object sender, EventArgs e)
    {
        // determine the selected item.
        var selectedEnemy = (RPG_Enemy?)listBoxEnemies.SelectedItem!;

        // don't update if it was null.
        if (selectedEnemy is null) return;

        // shorthand the listbox.
        var listbox = listBoxDrops;

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
        var dropList = listBoxDrops.Items
            .OfType<Component>()
            .Select(component => component.ToDropItem())
            .ToList();
        selectedEnemy.UpdateDropsData(dropList);
    }
    #endregion

    private (RPG_Enemy enemy, int index) GetEnemySelection()
    {
        // determine the selection.
        var selectedItem = (RPG_Enemy?)listBoxEnemies.SelectedItem;

        if (selectedItem == null) throw new IndexOutOfRangeException("could not find the current selection for some reason");

        // find the index of the selection in our local list.
        var index = enemiesList.FindIndex(data => data != null && data.id == selectedItem.id);

        // return both data points.
        return new(selectedItem, index);
    }

    private void UpdateEnemyData(RPG_Enemy enemy, int index)
    {
        listBoxEnemies.Items[index - 1] = enemy;
    }

    #region parameters
    private void UpdateName(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (enemy, index) = GetEnemySelection();

        // grab the value out of the field.
        var name = textBoxName.Text;

        // update the value on the source.
        enemy.UpdateName(name);

        // refresh the item in the list.
        UpdateEnemyData(enemy, index);
    }

    private void UpdateLevel(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (enemy, index) = GetEnemySelection();

        // grab the value out of the field.
        var level = numLevel.Value;

        // update the value on the source.
        enemy.UpdateLevel(level);

        // refresh the item in the list.
        UpdateEnemyData(enemy, index);
    }

    private void UpdateParamMaxHp(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (enemy, index) = GetEnemySelection();

        // grab the value out of the field.
        var value = numMaxHp.Value;

        // update the value on the source.
        enemy.UpdateBaseParamMaxHp(value);

        // refresh the item in the list.
        UpdateEnemyData(enemy, index);
    }

    private void UpdateParamMaxMp(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (enemy, index) = GetEnemySelection();

        // grab the value out of the field.
        var value = numMaxMp.Value;

        // update the value on the source.
        enemy.UpdateBaseParamMaxMp(value);

        // refresh the item in the list.
        UpdateEnemyData(enemy, index);
    }

    private void UpdateParamMaxTp(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (enemy, index) = GetEnemySelection();

        // grab the value out of the field.
        var value = numMaxTp.Value;

        // update the value on the source.
        // TODO: implement TP update.
        //enemy.UpdateBaseParamMaxTp(value);

        // refresh the item in the list.
        UpdateEnemyData(enemy, index);
    }

    private void UpdateParamPower(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (enemy, index) = GetEnemySelection();

        // grab the value out of the field.
        var value = numParamPower.Value;

        // update the value on the source.
        enemy.UpdateBaseParamPower(value);

        // refresh the item in the list.
        UpdateEnemyData(enemy, index);
    }

    private void UpdateParamEndurance(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (enemy, index) = GetEnemySelection();

        // grab the value out of the field.
        var value = numParamEndurance.Value;

        // update the value on the source.
        enemy.UpdateBaseParamEndurance(value);

        // refresh the item in the list.
        UpdateEnemyData(enemy, index);
    }

    private void UpdateParamForce(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (enemy, index) = GetEnemySelection();

        // grab the value out of the field.
        var value = numParamForce.Value;

        // update the value on the source.
        enemy.UpdateBaseParamForce(value);

        // refresh the item in the list.
        UpdateEnemyData(enemy, index);
    }

    private void UpdateParamResistance(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (enemy, index) = GetEnemySelection();

        // grab the value out of the field.
        var value = numParamResistance.Value;

        // update the value on the source.
        enemy.UpdateBaseParamResistance(value);

        // refresh the item in the list.
        UpdateEnemyData(enemy, index);
    }

    private void UpdateParamSpeed(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (enemy, index) = GetEnemySelection();

        // grab the value out of the field.
        var value = numParamSpeed.Value;

        // update the value on the source.
        enemy.UpdateBaseParamSpeed(value);

        // refresh the item in the list.
        UpdateEnemyData(enemy, index);
    }

    private void UpdateParamLuck(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (enemy, index) = GetEnemySelection();

        // grab the value out of the field.
        var value = numParamLuck.Value;

        // update the value on the source.
        enemy.UpdateBaseParamLuck(value);

        // refresh the item in the list.
        UpdateEnemyData(enemy, index);
    }

    private void UpdateRewardExperience(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (enemy, index) = GetEnemySelection();

        // grab the value out of the field.
        var value = numExperience.Value;

        // update the value on the source.
        enemy.UpdateExperience(value);

        // refresh the item in the list.
        UpdateEnemyData(enemy, index);
    }

    private void UpdateRewardGold(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (enemy, index) = GetEnemySelection();

        // grab the value out of the field.
        var value = numGold.Value;

        // update the value on the source.
        enemy.UpdateGold(value);

        // refresh the item in the list.
        UpdateEnemyData(enemy, index);
    }
    #endregion parameters

    #region sdp
    private void UpdateSdpPoints(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (enemy, index) = GetEnemySelection();

        // grab the value out of the field.
        var points = numSdpPoints.Value;

        // update the value on the source.
        enemy.UpdateSdpPoints(points);

        // refresh the item in the list.
        UpdateEnemyData(enemy, index);
    }

    private void UpdateSdpData()
    {
        // get the data of the selected item.
        var (enemy, index) = GetEnemySelection();

        // make sure the checkbox is enabled indicating we have SDP.
        if (checkBoxHasPanelDrop.Checked)
        {
            // grab the SDP values out.
            var key = textSdpKey.Text;
            var chance = numSdpChance.Value;
            var itemId = labelSdpItemIdValue.Text;
        
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
        UpdateEnemyData(enemy, index);
    }

    private void checkBoxHasPanelDrop_CheckedChanged(object sender, EventArgs e)
    {
        var isAlreadyChecked = checkBoxHasPanelDrop.Checked;

        if (isAlreadyChecked)
        {
            numSdpChance.Enabled = true;
            textSdpKey.Enabled = true;
        }
        else
        {
            numSdpChance.Enabled = false;
            textSdpKey.Enabled = false;
        }
    }

    private void buttonCloneToSdpDrop_Click(object sender, EventArgs e)
    {
        // determine the selected item.
        var enemy = (RPG_Enemy)listBoxEnemies.SelectedItem!;

        // don't update if it was null.
        if (enemy is null) return;

        // grab the current state of the component from the helper.
        var helperComponent = dropHelper.CurrentComponent();

        // update the label with the selection from the helper.
        labelSdpItemIdValue.Text = helperComponent.Id.ToString();
    }
    
    private void buttonUpdateSdpData_Click(object sender, EventArgs e)
    {
        UpdateSdpData();
    }

    private void buttonRemoveSdpData_Click(object sender, EventArgs e)
    {
        textSdpKey.Text = string.Empty;
        numSdpChance.Value = 1;
        labelSdpItemIdValue.Text = decimal.MinusOne.ToString();
        ToggleSdpSection();
    }

    private void ToggleSdpSection(bool isEnabled = false)
    {
        checkBoxHasPanelDrop.Checked = isEnabled;
        textSdpKey.Enabled = isEnabled;
        numSdpChance.Enabled = isEnabled;
    }
    #endregion sdp
    
    #region jabs
    private void UpdateJabsSight(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (enemy, index) = GetEnemySelection();

        // grab the value out of the field.
        var value = numJabsSight.Value;

        // update the value on the source.
        enemy.UpdateJabsSight(value);

        // refresh the item in the list.
        UpdateEnemyData(enemy, index);
    }
    
    private void UpdateJabsSightAlerted(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (enemy, index) = GetEnemySelection();

        // grab the value out of the field.
        var value = numJabsSightAlerted.Value;

        // update the value on the source.
        enemy.UpdateJabsAlertedSightBoost(value);

        // refresh the item in the list.
        UpdateEnemyData(enemy, index);
    }
    
    private void UpdateJabsPursuit(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (enemy, index) = GetEnemySelection();

        // grab the value out of the field.
        var value = numJabsPursuit.Value;

        // update the value on the source.
        enemy.UpdateJabsPursuit(value);

        // refresh the item in the list.
        UpdateEnemyData(enemy, index);
    }
    
    private void UpdateJabsPursuitAlerted(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (enemy, index) = GetEnemySelection();

        // grab the value out of the field.
        var value = numJabsPursuitAlerted.Value;

        // update the value on the source.
        enemy.UpdateJabsAlertedPursuitBoost(value);

        // refresh the item in the list.
        UpdateEnemyData(enemy, index);
    }
    
    private void UpdateJabsAiTraitCareful(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (enemy, index) = GetEnemySelection();

        // update the underlying data.
        enemy.UpdateJabsAiTraitCareful(checkBoxAiTraitCareful.Checked);

        // update the running list.
        UpdateEnemyData(enemy, index);
    }
    
    private void UpdateJabsAiTraitExecutor(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (enemy, index) = GetEnemySelection();

        // update the underlying data.
        enemy.UpdateJabsAiTraitExecutor(checkBoxAiTraitExecutor.Checked);

        // update the running list.
        UpdateEnemyData(enemy, index);
    }
    
    private void UpdateJabsAiTraitReckless(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (enemy, index) = GetEnemySelection();

        // update the underlying data.
        enemy.UpdateJabsAiTraitReckless(checkBoxAiTraitReckless.Checked);

        // update the running list.
        UpdateEnemyData(enemy, index);
    }
    
    private void UpdateJabsAiTraitHealer(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (enemy, index) = GetEnemySelection();

        // update the underlying data.
        enemy.UpdateJabsAiTraitHealer(checkBoxAiTraitHealer.Checked);

        // update the running list.
        UpdateEnemyData(enemy, index);
    }
    
    private void UpdateJabsAiTraitLeader(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (enemy, index) = GetEnemySelection();

        // update the underlying data.
        enemy.UpdateJabsAiTraitLeader(checkBoxAiTraitLeader.Checked);

        // update the running list.
        UpdateEnemyData(enemy, index);
    }
    
    private void UpdateJabsAiTraitFollower(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (enemy, index) = GetEnemySelection();

        // update the underlying data.
        enemy.UpdateJabsAiTraitFollower(checkBoxAiTraitFollower.Checked);

        // update the running list.
        UpdateEnemyData(enemy, index);
    }
    #endregion jabs

    #region refresh
    private void RefreshForm(object? sender, EventArgs e)
    {
        _RefreshForm();
    }

    private void _RefreshForm()
    {
        RefreshEnemies();

        RefreshParameters();

        RefreshDrops();

        RefreshSdp();

        RefreshJabs();

        // update other data in form here.
    }

    private void RefreshParameters()
    {
        var selectedEnemy = (RPG_Enemy?)listBoxEnemies.SelectedItem;
        if (selectedEnemy is null) return;

        numLevel.Value = selectedEnemy.GetLevel();

        numMaxHp.Value = selectedEnemy.GetBaseParamMaxHp();
        numMaxMp.Value = selectedEnemy.GetBaseParamMaxMp();

        // TODO: implement tp retrieval.
        // this.numMaxTp.Value = selectedEnemy.GetBaseParamMaxTp();

        numParamPower.Value = selectedEnemy.GetBaseParamPower();
        numParamEndurance.Value = selectedEnemy.GetBaseParamEndurance();
        numParamForce.Value = selectedEnemy.GetBaseParamForce();
        numParamResistance.Value = selectedEnemy.GetBaseParamResistance();
        numParamSpeed.Value = selectedEnemy.GetBaseParamSpeed();
        numParamLuck.Value = selectedEnemy.GetBaseParamLuck();

        numExperience.Value = selectedEnemy.GetExperience();
        numGold.Value = selectedEnemy.GetGold();
    }
    
    private void RefreshEnemies()
    {
        var selectedEnemy = (RPG_Enemy?)listBoxEnemies.SelectedItem;
        if (selectedEnemy is null) return;

        textBoxName.Text = selectedEnemy.name;
        labelTextId.Text = selectedEnemy.id.ToString();
    }

    private void RefreshDrops()
    {
        listBoxDrops.Items.Clear();

        var selectedEnemy = (RPG_Enemy?)listBoxEnemies.SelectedItem;
        if (selectedEnemy is null) return;

        var extraDrops = selectedEnemy.GetDropsData();
        if (!extraDrops.Any()) return;

        extraDrops.ForEach(extraDrop =>
        {
            var extraComponent = extraDrop.ToComponent();
            extraComponent.Name = extraComponent.GetDisplayName();

            listBoxDrops.Items.Add(extraComponent);
        });
    }

    private void RefreshSdp()
    {
        var selectedEnemy = (RPG_Enemy?)listBoxEnemies.SelectedItem;
        if (selectedEnemy is null) return;

        var sdpKey = selectedEnemy.GetSdpKey();
        textSdpKey.Text = sdpKey;
        numSdpChance.Value = selectedEnemy.GetSdpDropChance();
        labelSdpItemIdValue.Text = selectedEnemy.GetSdpItemId().ToString();

        // no key means no SDP drop on this enemy.
        var hasSdp = !string.IsNullOrWhiteSpace(sdpKey);
        ToggleSdpSection(hasSdp);

        numSdpPoints.Value = selectedEnemy.GetSdpPoints();
    }

    private void RefreshJabs()
    {
        var selectedEnemy = (RPG_Enemy?)listBoxEnemies.SelectedItem;
        if (selectedEnemy is null) return;

        numJabsSight.Value = selectedEnemy.GetJabsSight();
        numJabsSightAlerted.Value = selectedEnemy.GetJabsAlertedSightBoost();
        numJabsPursuit.Value = selectedEnemy.GetJabsPursuit();
        numJabsPursuitAlerted.Value = selectedEnemy.GetJabsAlertedPursuitBoost();

        checkBoxAiTraitCareful.Checked = selectedEnemy.HasJabsAiTraitCareful();
        checkBoxAiTraitExecutor.Checked = selectedEnemy.HasJabsAiTraitExecutor();
        checkBoxAiTraitReckless.Checked = selectedEnemy.HasJabsAiTraitReckless();
        checkBoxAiTraitHealer.Checked = selectedEnemy.HasJabsAiTraitHealer();
        checkBoxAiTraitLeader.Checked = selectedEnemy.HasJabsAiTraitLeader();
        checkBoxAiTraitFollower.Checked = selectedEnemy.HasJabsAiTraitFollower();
    }
    #endregion

    #region setup
    public void FlagForRefresh()
    {
        needsSetup = true;
    }

    public void SetupComplete()
    {
        needsSetup = false;
    }

    public void Setup(List<RPG_Enemy> enemies)
    {
        if (!needsSetup) return;

        // populate the list of weapons.
        PopulateEnemiesList(enemies);

        // check if we need to autopick an index.
        if (listBoxEnemies.SelectedIndex == -1)
        {
            // set the index to the first item.
            listBoxEnemies.SelectedIndex = 0;
        }
    }

    private void PopulateEnemiesList(List<RPG_Enemy> enemies)
    {
        // assign the list of weapons locally to the form.
        enemiesList = enemies;

        // iterate over each of the weapons in the list 
        enemiesList.ForEach(enemy =>
        {
            // the first weapon in the list is always null, so accommodate.
            if (enemy != null)
            {
                // add the weapon to the running list.
                listBoxEnemies.Items.Add(enemy);
            }
        });

        // let this form know we've finished setup.
        SetupComplete();
    }
    #endregion setup
}

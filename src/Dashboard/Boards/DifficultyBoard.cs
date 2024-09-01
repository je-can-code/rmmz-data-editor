using JMZ.Difficulty.Data.Models;

namespace JMZ.Dashboard.Boards;

public partial class DifficultyBoard : Form
{
    private bool needsSetup = true;
    
    private readonly ToolTip _toolTip = new();

    private List<DifficultyMetadata> difficultyList = [];

    public List<DifficultyMetadata> Difficulties()
    {
        return difficultyList;
    }

    public void TrackToSavedDifficulties()
    {
        // clear the existing list.
        difficultyList.Clear();

        // iterate over the tracked list.
        foreach (var difficulty in listboxDifficultyLayers.Items)
        {
            // add each item from the tracked list into the list to be saved.
            difficultyList.Add((DifficultyMetadata)difficulty);
        }
    }

    public DifficultyBoard()
    {
        InitializeComponent();

        InitializeDataControls();
        InitializeTooltips();
        ApplyButtonInteractions();
        ApplyUpdateEvents();
    }
    
    #region init
    /// <summary>
    /// Initializes the data-binding of components to arbitrary values.
    /// </summary>
    private void InitializeDataControls()
    {
        // setup the main list box of difficulties.
        listboxDifficultyLayers.DisplayMember = "Key";
        listboxDifficultyLayers.ValueMember = "Name";
    }
    
    /// <summary>
    /// Initializes all tooltips associated with this board.
    /// </summary>
    private void InitializeTooltips()
    {
        _toolTip.AutoPopDelay = 5000;
        _toolTip.InitialDelay = 1000;
        _toolTip.ReshowDelay = 500;
        _toolTip.ToolTipIcon = ToolTipIcon.Info;
        _toolTip.ToolTipTitle = "Details and Usage";

        var keyTip = """
            The unique identifying key of the difficulty.
            Use this to refer to this layer when using various plugin commands or scripts.
            
            This is required, and will cause issues if left blank.
            """;
        _toolTip.SetToolTip(textBoxKey, keyTip);
    }

    private void ApplyButtonInteractions()
    {
        buttonAddDifficulty.Click += AddDifficulty;
        buttonCloneDifficulty.Click += CloneDifficulty;
        buttonDeleteDifficulty.Click += DeleteDifficulty;
    }

    #endregion
    
    #region refresh
    private void RefreshForm(object? sender, EventArgs e)
    {
        _RefreshForm();
    }

    private void _RefreshForm()
    {
        // refresh difficulty data.
        RefreshDifficulties();

        // refresh sub-data of the chosen difficulty.
        RefreshBattlerEffectsData();
        RefreshRewardData();
    }
    
    private void RefreshDifficulties()
    {
        var selectedItem = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;
        if (selectedItem is null) return;

        // core data
        textBoxKey.Text = selectedItem.Key;
        textBoxName.Text = selectedItem.Name;
        textBoxDescription.Text = selectedItem.Description;
        numIconIndex.Value = selectedItem.IconIndex;
        checkBoxUnlockedByDefault.Checked = selectedItem.UnlockedByDefault;
        checkBoxEnabledByDefault.Checked = selectedItem.EnabledByDefault;
        checkBoxHiddenByDefault.Checked = selectedItem.HiddenByDefault;
        numCost.Value = selectedItem.Cost;
    }

    private void RefreshBattlerEffectsData()
    {
        var selectedItem = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;
        if (selectedItem is null) return;

        var actorBattlerEffects = selectedItem.ActorEffects;
        
        num00MaxLifeActor.Value = actorBattlerEffects.bparams[0];
        num01MaxMagiActor.Value = actorBattlerEffects.bparams[1];
        num02PowerActor.Value = actorBattlerEffects.bparams[2];
        num03EndureActor.Value = actorBattlerEffects.bparams[3];
        num04ForceActor.Value = actorBattlerEffects.bparams[4];
        num05ResistActor.Value = actorBattlerEffects.bparams[5];
        num06SpeedActor.Value = actorBattlerEffects.bparams[6];
        num07LuckActor.Value = actorBattlerEffects.bparams[7];
        
        num00AccuracyActor.Value = actorBattlerEffects.xparams[0];
        num01PhysEvadeActor.Value = actorBattlerEffects.xparams[1];
        num02CritChanceActor.Value = actorBattlerEffects.xparams[2];
        num03CritEvadeActor.Value = actorBattlerEffects.xparams[3];
        num04MagiEvadeActor.Value = actorBattlerEffects.xparams[4];
        num05MagiReflectActor.Value = actorBattlerEffects.xparams[5];
        num06CounterActor.Value = actorBattlerEffects.xparams[6];
        num07LifeRegenActor.Value = actorBattlerEffects.xparams[7];
        num08MagiRegenActor.Value = actorBattlerEffects.xparams[8];
        num09TechRegenActor.Value = actorBattlerEffects.xparams[9];
        
        num00AggroActor.Value = actorBattlerEffects.sparams[0];
        num01ParryActor.Value = actorBattlerEffects.sparams[1];
        num02HealingActor.Value = actorBattlerEffects.sparams[2];
        num03ItemEffectsActor.Value = actorBattlerEffects.sparams[3];
        num04MagiCostActor.Value = actorBattlerEffects.sparams[4];
        num05TechCostActor.Value = actorBattlerEffects.sparams[5];
        num06PhysDamageActor.Value = actorBattlerEffects.sparams[6];
        num07MagiDamageActor.Value = actorBattlerEffects.sparams[7];
        num08EnvironDamageActor.Value = actorBattlerEffects.sparams[8];
        num09ExperienceRateActor.Value = actorBattlerEffects.sparams[9];
        
        var enemyBattlerEffects = selectedItem.EnemyEffects;

        num00MaxLifeEnemy.Value = enemyBattlerEffects.bparams[0];
        num01MaxMagiEnemy.Value = enemyBattlerEffects.bparams[1];
        num02PowerEnemy.Value = enemyBattlerEffects.bparams[2];
        num03EndureEnemy.Value = enemyBattlerEffects.bparams[3];
        num04ForceEnemy.Value = enemyBattlerEffects.bparams[4];
        num05ResistEnemy.Value = enemyBattlerEffects.bparams[5];
        num06SpeedEnemy.Value = enemyBattlerEffects.bparams[6];
        num07LuckEnemy.Value = enemyBattlerEffects.bparams[7];
        
        num00AccuracyEnemy.Value = enemyBattlerEffects.xparams[0];
        num01PhysEvadeEnemy.Value = enemyBattlerEffects.xparams[1];
        num02CritChanceEnemy.Value = enemyBattlerEffects.xparams[2];
        num03CritEvadeEnemy.Value = enemyBattlerEffects.xparams[3];
        num04MagiEvadeEnemy.Value = enemyBattlerEffects.xparams[4];
        num05MagiReflectEnemy.Value = enemyBattlerEffects.xparams[5];
        num06CounterEnemy.Value = enemyBattlerEffects.xparams[6];
        num07LifeRegenEnemy.Value = enemyBattlerEffects.xparams[7];
        num08MagiRegenEnemy.Value = enemyBattlerEffects.xparams[8];
        num09TechRegenEnemy.Value = enemyBattlerEffects.xparams[9];
        
        num00AggroEnemy.Value = enemyBattlerEffects.sparams[0];
        num01ParryEnemy.Value = enemyBattlerEffects.sparams[1];
        num02HealingEnemy.Value = enemyBattlerEffects.sparams[2];
        num03ItemEffectsEnemy.Value = enemyBattlerEffects.sparams[3];
        num04MagiCostEnemy.Value = enemyBattlerEffects.sparams[4];
        num05TechCostEnemy.Value = enemyBattlerEffects.sparams[5];
        num06PhysDamageEnemy.Value = enemyBattlerEffects.sparams[6];
        num07MagiDamageEnemy.Value = enemyBattlerEffects.sparams[7];
        num08EnvironDamageEnemy.Value = enemyBattlerEffects.sparams[8];
        num09ExperienceRateEnemy.Value = enemyBattlerEffects.sparams[9];
    }
    
    private void RefreshRewardData()
    {
        var selectedItem = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;
        if (selectedItem is null) return;
        
        var rewards = selectedItem.Rewards;

        numRewardExperience.Value = rewards.Experience;
        numRewardGold.Value = rewards.Gold;
        numRewardDrops.Value = rewards.Drops;
        numRewardEncounters.Value = rewards.Encounters;
        numRewardSdp.Value = rewards.SdpPoints;
    }

    #endregion
    
    #region setup
    public void Setup(List<DifficultyMetadata> difficultyMetadatas)
    {
        // check to make sure we need to run the setup before running it.
        if (!needsSetup) return;

        // populate the list.
        PopulateDifficultyList(difficultyMetadatas);

        // check if we need to autopick an index.
        if (listboxDifficultyLayers.SelectedIndex == -1 && listboxDifficultyLayers.Items.Count > 0)
        {
            // set the index to the first item.
            listboxDifficultyLayers.SelectedIndex = 0;
        }

        // let this form know we've finished setup.
        SetupComplete();
    }
    
    private void PopulateDifficultyList(List<DifficultyMetadata> difficultyMetadatas)
    {
        // empty the list first.
        listboxDifficultyLayers.Items.Clear();

        // assign the list of items locally to the form.
        difficultyList = difficultyMetadatas;

        // iterate over each of the entries in the list.
        difficultyList.ForEach(difficultyMetadata =>
        {
            // if any entry is null somehow, skip it.
            if (difficultyMetadata is null) return;

            // add the entry to the running list.
            listboxDifficultyLayers.Items.Add(difficultyMetadata);
        });
    }
    
    private void SetupComplete()
    {
        needsSetup = false;
    }
    #endregion

    private void AddDifficulty(object? sender, EventArgs e)
    {
        var newItem = new DifficultyMetadata();

        var selectedIndex = listboxDifficultyLayers.SelectedIndex;
        
        // check if there was no current selection.
        if (selectedIndex == -1 || selectedIndex == listboxDifficultyLayers.Items.Count - 1)
        {
            // add the item to the list without regard for index.
            listboxDifficultyLayers.Items.Add(newItem);
        }
        // we are in the middle somewhere.
        else
        {
            // add it at the given index.
            listboxDifficultyLayers.Items.Insert(selectedIndex, newItem);
        }
    }
    
    private void DeleteDifficulty(object? sender, EventArgs e)
    {
        // grab the selection the user is considering removing.
        var removalIndex = listboxDifficultyLayers.SelectedIndex;

        // check if there is no index selected right now.
        if (removalIndex == -1)
        {
            // do nothing.
            return;
        }

        // grab the current panel we're working with.
        var selectedItem = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;

        // define the prompt.
        var removalPrompt = $"Are you sure you want to remove the difficulty with key [{selectedItem.Key}]?";

        // show the box with the prompt.
        var dialogResult = MessageBox.Show(
            removalPrompt,
            "Removing a Difficulty",
            MessageBoxButtons.OKCancel);

        // pivot on the user decisions.
        switch (dialogResult)
        {
            case DialogResult.OK:
                listboxDifficultyLayers.Items.RemoveAt(removalIndex);
                if (listboxDifficultyLayers.Items.Count != 0)
                {
                    listboxDifficultyLayers.SelectedIndex = 0;
                }

                break;
            case DialogResult.Cancel:
                break;
        }
    }

    private void CloneDifficulty(object? sender, EventArgs e)
    {
        // grab the currently selected recipe.
        var selectedItem = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;

        // no cloning if there is no selected item.
        if (selectedItem is null) return;

        // copying by reference is hard.
        var copiedRewards = new RewardEffects
        {
            Experience = selectedItem.Rewards.Experience,
            Gold = selectedItem.Rewards.Gold,
            Drops = selectedItem.Rewards.Drops,
            Encounters = selectedItem.Rewards.Encounters,
            SdpPoints = selectedItem.Rewards.SdpPoints
        };

        // copying by reference is hard.
        var copiedActorEffects = new BattlerEffects
        {
            bparams = [..selectedItem.ActorEffects.bparams],
            xparams = [..selectedItem.ActorEffects.xparams],
            sparams = [..selectedItem.ActorEffects.sparams],
            cparams = [..selectedItem.ActorEffects.cparams]
        };
        
        // copying by reference is hard.
        var copiedEnemyEffects = new BattlerEffects
        {
            bparams = [..selectedItem.EnemyEffects.bparams],
            xparams = [..selectedItem.EnemyEffects.xparams],
            sparams = [..selectedItem.EnemyEffects.sparams],
            cparams = [..selectedItem.EnemyEffects.cparams]
        };

        // define the new recipe.
        var clonedItem = new DifficultyMetadata
        {
            Name = selectedItem.Name,
            Key = selectedItem.Key,
            Description = selectedItem.Description,
            IconIndex = selectedItem.IconIndex,
            Cost = selectedItem.Cost,
            UnlockedByDefault = selectedItem.UnlockedByDefault,
            EnabledByDefault = selectedItem.EnabledByDefault,
            HiddenByDefault = selectedItem.HiddenByDefault,
            
            // cloning by reference takes more work.
            Rewards = copiedRewards,
            ActorEffects = copiedActorEffects,
            EnemyEffects = copiedEnemyEffects
        };

        // grab the current selection.
        var selectedIndex = listboxDifficultyLayers.SelectedIndex;

        // check if there was no current selection.
        if (selectedIndex == -1 || selectedIndex == listboxDifficultyLayers.Items.Count - 1)
        {
            // add the item to the list without regard for index.
            listboxDifficultyLayers.Items.Add(clonedItem);
        }
        // we are in the middle somewhere.
        else
        {
            // add it at the given index.
            listboxDifficultyLayers.Items.Insert(selectedIndex, clonedItem);
        }
    }
}
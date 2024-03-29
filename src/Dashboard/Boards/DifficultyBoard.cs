using JMZ.Difficulty.Data.Models;

namespace JMZ.Dashboard.Boards;

public partial class DifficultyBoard : Form
{
    private bool needsSetup = true;
    private readonly ToolTip _toolTip = new();

    private List<DifficultyMetadata> difficultyList = [];

    public List<DifficultyMetadata> Difficulties()
    {
        return this.difficultyList;
    }

    public void TrackToSavedDifficulties()
    {
        // clear the existing list.
        this.difficultyList.Clear();

        // iterate over the tracked list.
        foreach (var difficulty in this.listboxDifficultyLayers.Items)
        {
            // add each item from the tracked list into the list to be saved.
            this.difficultyList.Add((DifficultyMetadata)difficulty);
        }
    }

    public DifficultyBoard()
    {
        InitializeComponent();

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
        // setup the main list box of difficulties.
        this.listboxDifficultyLayers.DisplayMember = "Key";
        this.listboxDifficultyLayers.ValueMember = "Name";
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
        _toolTip.SetToolTip(this.textboxKey, keyTip);
    }
    #endregion
    
    #region refresh
    private void RefreshForm(object? sender, EventArgs e)
    {
        this._RefreshForm();
    }

    private void _RefreshForm()
    {
        // refresh difficulty data.
        this.RefreshDifficulties();

        // refresh sub-data of the chosen difficulty.
        this.RefreshBattlerEffectsData();
        this.RefreshRewardData();
    }
    
    private void RefreshDifficulties()
    {
        var selectedItem = (DifficultyMetadata)this.listboxDifficultyLayers.SelectedItem!;
        if (selectedItem is null) return;

        // core data
        this.textboxKey.Text = selectedItem.Key;
        this.textboxName.Text = selectedItem.Name;
        this.textBoxDescription.Text = selectedItem.Description;
        this.numIconIndex.Value = selectedItem.IconIndex;
        this.checkboxUnlockedByDefault.Checked = selectedItem.UnlockedByDefault;
        this.checkboxEnabledByDefault.Checked = selectedItem.EnabledByDefault;
        this.checkboxHiddenByDefault.Checked = selectedItem.HiddenByDefault;
    }

    private void RefreshBattlerEffectsData()
    {
        var selectedItem = (DifficultyMetadata)this.listboxDifficultyLayers.SelectedItem!;
        if (selectedItem is null) return;

        var actorBattlerEffects = selectedItem.actorEffects;
        
        this.num00MaxLifeActor.Value = actorBattlerEffects.bparams[0];
        this.num01MaxMagiActor.Value = actorBattlerEffects.bparams[1];
        this.num02PowerActor.Value = actorBattlerEffects.bparams[2];
        this.num03EndureActor.Value = actorBattlerEffects.bparams[3];
        this.num04ForceActor.Value = actorBattlerEffects.bparams[4];
        this.num05ResistActor.Value = actorBattlerEffects.bparams[5];
        this.num06SpeedActor.Value = actorBattlerEffects.bparams[6];
        this.num07LuckActor.Value = actorBattlerEffects.bparams[7];
        
        this.num00AccuracyActor.Value = actorBattlerEffects.xparams[0];
        this.num01PhysEvadeActor.Value = actorBattlerEffects.xparams[1];
        this.num02CritChanceActor.Value = actorBattlerEffects.xparams[2];
        this.num03CritEvadeActor.Value = actorBattlerEffects.xparams[3];
        this.num04MagiEvadeActor.Value = actorBattlerEffects.xparams[4];
        this.num05MagiReflectActor.Value = actorBattlerEffects.xparams[5];
        this.num06CounterActor.Value = actorBattlerEffects.xparams[6];
        this.num07LifeRegenActor.Value = actorBattlerEffects.xparams[7];
        this.num08MagiRegenActor.Value = actorBattlerEffects.xparams[8];
        this.num09TechRegenActor.Value = actorBattlerEffects.xparams[9];
        
        this.num00AggroActor.Value = actorBattlerEffects.sparams[0];
        this.num01ParryActor.Value = actorBattlerEffects.sparams[1];
        this.num02HealingActor.Value = actorBattlerEffects.sparams[2];
        this.num03ItemEffectsActor.Value = actorBattlerEffects.sparams[3];
        this.num04MagiCostActor.Value = actorBattlerEffects.sparams[4];
        this.num05TechCostActor.Value = actorBattlerEffects.sparams[5];
        this.num06PhysDamageActor.Value = actorBattlerEffects.sparams[6];
        this.num07MagiDamageActor.Value = actorBattlerEffects.sparams[7];
        this.num08EnvironDamageActor.Value = actorBattlerEffects.sparams[8];
        this.num09ExperienceRateActor.Value = actorBattlerEffects.sparams[9];
        
        var enemyBattlerEffects = selectedItem.enemyEffects;

        this.num00MaxLifeEnemy.Value = enemyBattlerEffects.bparams[0];
        this.num01MaxMagiEnemy.Value = enemyBattlerEffects.bparams[1];
        this.num02PowerEnemy.Value = enemyBattlerEffects.bparams[2];
        this.num03EndureEnemy.Value = enemyBattlerEffects.bparams[3];
        this.num04ForceEnemy.Value = enemyBattlerEffects.bparams[4];
        this.num05ResistEnemy.Value = enemyBattlerEffects.bparams[5];
        this.num06SpeedEnemy.Value = enemyBattlerEffects.bparams[6];
        this.num07LuckEnemy.Value = enemyBattlerEffects.bparams[7];
        
        this.num00AccuracyEnemy.Value = enemyBattlerEffects.xparams[0];
        this.num01PhysEvadeEnemy.Value = enemyBattlerEffects.xparams[1];
        this.num02CritChanceEnemy.Value = enemyBattlerEffects.xparams[2];
        this.num03CritEvadeEnemy.Value = enemyBattlerEffects.xparams[3];
        this.num04MagiEvadeEnemy.Value = enemyBattlerEffects.xparams[4];
        this.num05MagiReflectEnemy.Value = enemyBattlerEffects.xparams[5];
        this.num06CounterEnemy.Value = enemyBattlerEffects.xparams[6];
        this.num07LifeRegenEnemy.Value = enemyBattlerEffects.xparams[7];
        this.num08MagiRegenEnemy.Value = enemyBattlerEffects.xparams[8];
        this.num09TechRegenEnemy.Value = enemyBattlerEffects.xparams[9];
        
        this.num00AggroEnemy.Value = enemyBattlerEffects.sparams[0];
        this.num01ParryEnemy.Value = enemyBattlerEffects.sparams[1];
        this.num02HealingEnemy.Value = enemyBattlerEffects.sparams[2];
        this.num03ItemEffectsEnemy.Value = enemyBattlerEffects.sparams[3];
        this.num04MagiCostEnemy.Value = enemyBattlerEffects.sparams[4];
        this.num05TechCostEnemy.Value = enemyBattlerEffects.sparams[5];
        this.num06PhysDamageEnemy.Value = enemyBattlerEffects.sparams[6];
        this.num07MagiDamageEnemy.Value = enemyBattlerEffects.sparams[7];
        this.num08EnvironDamageEnemy.Value = enemyBattlerEffects.sparams[8];
        this.num09ExperienceRateEnemy.Value = enemyBattlerEffects.sparams[9];
    }
    
    private void RefreshRewardData()
    {
        var selectedItem = (DifficultyMetadata)this.listboxDifficultyLayers.SelectedItem!;
        if (selectedItem is null) return;
        
        var rewards = selectedItem.rewards;

        this.numRewardExperience.Value = rewards.Experience;
        this.numRewardGold.Value = rewards.Gold;
        this.numRewardDrops.Value = rewards.Drops;
        this.numRewardEncounters.Value = rewards.Encounters;
        this.numRewardSdp.Value = rewards.SdpPoints;
    }

    #endregion
    
    #region setup
    public void Setup(List<DifficultyMetadata> difficultyMetadatas)
    {
        // check to make sure we need to run the setup before running it.
        if (!this.needsSetup) return;

        // populate the list.
        this.PopulateDifficultyList(difficultyMetadatas);

        // check if we need to autopick an index.
        if (this.listboxDifficultyLayers.SelectedIndex == -1 && this.listboxDifficultyLayers.Items.Count > 0)
        {
            // set the index to the first item.
            this.listboxDifficultyLayers.SelectedIndex = 0;
        }

        // let this form know we've finished setup.
        this.SetupComplete();
    }
    
    private void PopulateDifficultyList(List<DifficultyMetadata> difficultyMetadatas)
    {
        // empty the list first.
        this.listboxDifficultyLayers.Items.Clear();

        // assign the list of items locally to the form.
        this.difficultyList = difficultyMetadatas;

        // iterate over each of the entries in the list.
        this.difficultyList.ForEach(difficultyMetadata =>
        {
            // if any entry is null somehow, skip it.
            if (difficultyMetadata is null) return;

            // add the entry to the running list.
            this.listboxDifficultyLayers.Items.Add(difficultyMetadata);
        });
    }
    
    private void SetupComplete()
    {
        this.needsSetup = false;
    }
    #endregion
}
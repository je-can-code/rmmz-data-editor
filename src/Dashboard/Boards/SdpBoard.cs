using JMZ.Sdp.Data.Models;

namespace JMZ.Dashboard.Boards;

public partial class SdpBoard : Form
{
    private ToolTip _toolTip = new();

    private List<StatDistributionPanel> sdpList = [];

    public bool needsSetup = true;

    public SdpBoard()
    {
        InitializeComponent();

        this.InitializeDataControls();
        this.InitializeTooltips();
        this.ApplyUpdateEvents();
    }

    /// <summary>
    /// Initializes the data-binding of components to arbitrary values.
    /// </summary>
    private void InitializeDataControls()
    {
        // setup the main list box of SDPs.
        this.listBox_Sdps.DisplayMember = "Name";
        this.listBox_Sdps.ValueMember = "Key";

        // setup the listing of parameters per panel.
        this.listBox_parameters.DisplayMember = "ParameterName";
        this.listBox_parameters.ValueMember = "ParameterId";

        // setup the listing of rewards per panel.
        this.listBox_rewards.DisplayMember = "RewardName";
        this.listBox_rewards.ValueMember = "Effect";

        // associate the dropdowns with their appropriate data types.
        this.comboBox_parameter.DataSource = Enum.GetValues(typeof(LongParameter));
        this.comboBox_rarity.DataSource = Enum.GetValues(typeof(Rarity));
    }

    /// <summary>
    /// Initializes all tooltips associated with this board.
    /// </summary>
    private void InitializeTooltips()
    {
        _toolTip = new();
        _toolTip.AutoPopDelay = 5000;
        _toolTip.InitialDelay = 1000;
        _toolTip.ReshowDelay = 500;
        _toolTip.ToolTipIcon = ToolTipIcon.Info;
        _toolTip.ToolTipTitle = "Details and Usage";

        // _toolTip.SetToolTip(this.num_radius, JABS.Data.Models.Tags.Radius.Description);
    }

    private void ApplyUpdateEvents()
    {
        this.ApplyUpdateEventsForCoreData();
        this.ApplyUpdateEventsForCostData();
        this.ApplyUpdateEventsForDescriptionData();
        this.ApplyUpdateEventsForParameterData();
        this.ApplyUpdateEventsForRewardData();

        this.listBox_Sdps.SelectedIndexChanged += this.RefreshForm;
        this.listBox_parameters.SelectedIndexChanged += this.RefreshParameters;
        this.listBox_rewards.SelectedIndexChanged += this.RefreshRewards;
    }

    private void ApplyUpdateEventsForCoreData()
    {
        this.textBox_key.TextChanged += this.UpdateSdpKey;
        this.textBox_name.TextChanged += this.UpdateSdpName;
        this.num_iconIndex.ValueChanged += this.UpdateIconIndex;
        this.checkBox_unlockedByDefault.CheckedChanged += this.UpdateUnlockedByDefault;
        this.comboBox_rarity.SelectedIndexChanged += this.UpdateRarity;
    }

    private void ApplyUpdateEventsForCostData()
    {
        this.num_maxRank.ValueChanged += this.UpdateMaxRank;
        this.num_baseCost.ValueChanged += this.UpdateBaseCost;
        this.num_flatGrowth.ValueChanged += this.UpdateFlatGrowth;
        this.num_multGrowth.ValueChanged += this.UpdateMultGrowth;
    }

    private void ApplyUpdateEventsForDescriptionData()
    {
        this.textBox_flavorText.TextChanged += this.UpdateFlavorText;
        this.textBox_description.TextChanged += this.UpdateDescription;
    }

    private void ApplyUpdateEventsForParameterData()
    {
        this.num_paramGrowthPerRank.ValueChanged += this.UpdateGrowthPerRank;
        this.checkBox_isFlat.CheckedChanged += this.UpdateIsFlat;
        this.checkBox_isCore.CheckedChanged += this.UpdateIsCore;
        this.comboBox_parameter.SelectedIndexChanged += this.UpdateParameterType;
    }

    private void ApplyUpdateEventsForRewardData()
    {
        this.textBox_rewardName.TextChanged += this.UpdateRewardName;

        // NOTE: updating the name is a bit hacky on sub-lists lke rewards.
        this.textBox_rewardName.LostFocus += this.SyncRewardListNames;

        this.textBox_rewardEffect.TextChanged += this.UpdateRewardEffect;
        this.num_rewardRankRequired.ValueChanged += this.UpdateRewardRankRequired;
    }

    public List<StatDistributionPanel> Sdps()
    {
        return this.sdpList;
    }

    public void TrackedToSavedSdps()
    {
        // clear the existing list.
        this.sdpList.Clear();

        // iterate over the tracked list.
        foreach (var sdp in this.listBox_Sdps.Items)
        {
            // add each item from the tracked list into the list to be saved.
            this.sdpList.Add((StatDistributionPanel)sdp);
        }
    }

    #region updates
    #region update panel-level data
    #region update core data
    private void UpdateSdpKey(object? sender, EventArgs e)
    {
        // determine the selected item.
        var sdp = (StatDistributionPanel)this.listBox_Sdps.SelectedItem!;

        // don't update if it was null.
        if (sdp is null) return;

        // update with the new value.
        sdp.Key = this.textBox_key.Text;
    }

    private void UpdateSdpName(object? sender, EventArgs e)
    {
        // determine the selected item.
        var sdp = (StatDistributionPanel)this.listBox_Sdps.SelectedItem!;

        // don't update if it was null.
        if (sdp is null) return;

        // update the name with the new value.
        sdp.Name = this.textBox_name.Text;

        // the name is special in that it needs to be synced with the list to ensure name updates apply.
        this.listBox_Sdps.Items[this.listBox_Sdps.SelectedIndex] = sdp;
    }

    private void UpdateIconIndex(object? sender, EventArgs e)
    {
        // determine the selected item.
        var sdp = (StatDistributionPanel)this.listBox_Sdps.SelectedItem!;

        // don't update if it was null.
        if (sdp is null) return;

        // update with the new value.
        sdp.IconIndex = (int)this.num_iconIndex.Value;
    }

    private void UpdateUnlockedByDefault(object? sender, EventArgs e)
    {
        // determine the selected item.
        var sdp = (StatDistributionPanel)this.listBox_Sdps.SelectedItem!;

        // don't update if it was null.
        if (sdp is null) return;

        // update with the new value.
        sdp.UnlockedByDefault = this.checkBox_unlockedByDefault.Checked;
    }

    private void UpdateRarity(object? sender, EventArgs e)
    {
        // determine the selected item.
        var sdp = (StatDistributionPanel)this.listBox_Sdps.SelectedItem!;

        // don't update if it was null.
        if (sdp is null) return;

        // update with the new value.
        var rarity = (Rarity)this.comboBox_rarity.SelectedItem!;

        // cast the rarity as its underlying color index form.
        sdp.Rarity = (int)rarity;
    }
    #endregion

    #region update cost data
    private void UpdateMaxRank(object? sender, EventArgs e)
    {
        // determine the selected item.
        var sdp = (StatDistributionPanel)this.listBox_Sdps.SelectedItem!;

        // don't update if it was null.
        if (sdp is null) return;

        // update with the new value.
        sdp.MaxRank = (int)this.num_maxRank.Value;
    }

    private void UpdateBaseCost(object? sender, EventArgs e)
    {
        // determine the selected item.
        var sdp = (StatDistributionPanel)this.listBox_Sdps.SelectedItem!;

        // don't update if it was null.
        if (sdp is null) return;

        // update with the new value.
        sdp.BaseCost = this.num_baseCost.Value;
    }

    private void UpdateFlatGrowth(object? sender, EventArgs e)
    {
        // determine the selected item.
        var sdp = (StatDistributionPanel)this.listBox_Sdps.SelectedItem!;

        // don't update if it was null.
        if (sdp is null) return;

        // update with the new value.
        sdp.FlatGrowthCost = this.num_flatGrowth.Value;
    }

    private void UpdateMultGrowth(object? sender, EventArgs e)
    {
        // determine the selected item.
        var sdp = (StatDistributionPanel)this.listBox_Sdps.SelectedItem!;

        // don't update if it was null.
        if (sdp is null) return;

        // update with the new value.
        sdp.MultGrowthCost = this.num_multGrowth.Value;
    }

    #endregion

    #region update description data
    private void UpdateFlavorText(object? sender, EventArgs e)
    {
        // determine the selected item.
        var sdp = (StatDistributionPanel)this.listBox_Sdps.SelectedItem!;

        // don't update if it was null.
        if (sdp is null) return;

        // update the name with the new value.
        sdp.TopFlavorText = this.textBox_flavorText.Text;
    }

    private void UpdateDescription(object? sender, EventArgs e)
    {
        // determine the selected item.
        var sdp = (StatDistributionPanel)this.listBox_Sdps.SelectedItem!;

        // don't update if it was null.
        if (sdp is null) return;

        // update the name with the new value.
        sdp.Description = this.textBox_description.Text;
    }
    #endregion
    #endregion

    #region update panel-parameter-level data
    private void UpdateGrowthPerRank(object? sender, EventArgs e)
    {
        // determine the selected item.
        var selectedParameter = (SdpParameter)this.listBox_parameters.SelectedItem!;

        // don't update if the parameter was null.
        if (selectedParameter is null) return;

        // update with the new value.
        selectedParameter.PerRank = this.num_paramGrowthPerRank.Value;
    }

    private void UpdateIsFlat(object? sender, EventArgs e)
    {
        // determine the selected item.
        var selectedParameter = (SdpParameter)this.listBox_parameters.SelectedItem!;

        // don't update if the parameter was null.
        if (selectedParameter is null) return;

        // update with the new value.
        selectedParameter.IsFlat = this.checkBox_isFlat.Checked;

        // also update the checkbox text.
        this.checkBox_isFlat.Text = this.checkBox_isFlat.Checked
            ? "Is Flat Growth"
            : "Is Percent Growth";

        // the name is special in that it needs to be synced with the list to ensure name updates apply.
        this.SyncParameterListNames();
    }

    private void UpdateIsCore(object? sender, EventArgs e)
    {
        // determine the selected item.
        var selectedParameter = (SdpParameter)this.listBox_parameters.SelectedItem!;

        // don't update if the parameter was null.
        if (selectedParameter is null) return;

        // update with the new value.
        selectedParameter.IsCore = this.checkBox_isCore.Checked;

        // also update the checkbox text.
        this.checkBox_isCore.Text = this.checkBox_isCore.Checked
            ? "Is Core Parameter"
            : "Is Secondary Parameter";

        // the name is special in that it needs to be synced with the list to ensure name updates apply.
        this.SyncParameterListNames();
    }

    private void UpdateParameterType(object? sender, EventArgs e)
    {
        // determine the selected item.
        var selectedParameter = (SdpParameter)this.listBox_parameters.SelectedItem!;

        // don't update if the parameter was null.
        if (selectedParameter is null) return;

        // update with the new value.
        var longParameter = (LongParameter)this.comboBox_parameter.SelectedItem!;

        // cast the parameterId as its underlying index form.
        selectedParameter.ParameterId = (int)longParameter;

        // the name is special in that it needs to be synced with the list to ensure name updates apply.
        this.SyncParameterListNames();
    }

    private void SyncParameterListNames()
    {
        // determine the selected item.
        var selectedItem = (SdpParameter)this.listBox_parameters.SelectedItem!;

        // don't update if it was null.
        if (selectedItem is null) return;

        // the name is special in that it needs to be synced with the list to ensure name updates apply.
        this.listBox_parameters.Items[this.listBox_parameters.SelectedIndex] = selectedItem;
    }
    #endregion

    #region update panel-reward-level data
    private void UpdateRewardName(object? sender, EventArgs e)
    {
        // determine the selected item.
        var selectedReward = (SdpReward)this.listBox_rewards.SelectedItem!;

        // don't update if it was null.
        if (selectedReward is null) return;

        // update with the new value.
        selectedReward.RewardName = this.textBox_rewardName.Text;
    }

    private void SyncRewardListNames(object? sender, EventArgs e)
    {
        // determine the selected item.
        var selectedReward = (SdpReward)this.listBox_rewards.SelectedItem!;

        // don't update if it was null.
        if (selectedReward is null) return;

        // the name is special in that it needs to be synced with the list to ensure name updates apply.
        this.listBox_rewards.Items[this.listBox_rewards.SelectedIndex] = selectedReward;
    }

    private void UpdateRewardEffect(object? sender, EventArgs e)
    {
        // determine the selected item.
        var selectedReward = (SdpReward)this.listBox_rewards.SelectedItem!;

        // don't update if it was null.
        if (selectedReward is null) return;

        // update with the new value.
        selectedReward.Effect = this.textBox_rewardEffect.Text;
    }

    private void UpdateRewardRankRequired(object? sender, EventArgs e)
    {
        // determine the selected item.
        var selectedReward = (SdpReward)this.listBox_rewards.SelectedItem!;

        // don't update if it was null.
        if (selectedReward is null) return;

        // update with the new value.
        selectedReward.RankRequired = (int)this.num_rewardRankRequired.Value;
    }
    #endregion
    #endregion updates

    private void RefreshForm(object? sender, EventArgs e)
    {
        this._RefreshForm();
    }

    private void _RefreshForm()
    {
        var selectedItem = (StatDistributionPanel)this.listBox_Sdps.SelectedItem!;
        if (selectedItem != null)
        {
            // core data
            this.textBox_key.Text = selectedItem.Key;
            this.textBox_name.Text = selectedItem.Name;
            this.num_iconIndex.Value = selectedItem.IconIndex;
            this.checkBox_unlockedByDefault.Checked = selectedItem.UnlockedByDefault;
            var rarityName = ((Rarity)selectedItem.Rarity).ToString();
            var rarityIndex = this.comboBox_rarity.FindString(rarityName);
            if (rarityIndex != -1)
            {
                this.comboBox_rarity.SelectedIndex = rarityIndex;
            }

            // cost data
            this.num_maxRank.Value = selectedItem.MaxRank;
            this.num_baseCost.Value = selectedItem.BaseCost;
            this.num_flatGrowth.Value = selectedItem.FlatGrowthCost;
            this.num_multGrowth.Value = selectedItem.MultGrowthCost;

            // description data
            this.textBox_description.Text = selectedItem.Description;
            this.textBox_flavorText.Text = selectedItem.TopFlavorText;
        }

        this.RenderParameters();
        this.RenderRewards();
    }

    #region parameters
    private void RenderParameters()
    {
        // wipe the current list.
        this.listBox_parameters.Items.Clear();

        // clear the parameter data.
        this.ClearParameterData();

        // grab the panel we're working with.
        var selectedItem = (StatDistributionPanel)this.listBox_Sdps.SelectedItem!;

        // check to make sure we have a panel to work with.
        if (selectedItem == null)
        {
            // stop processing.
            return;
        }

        // at this point, we know we have a new panel to refresh for.

        // but we don't have any parameters for this panel.
        if (selectedItem.PanelParameters.Count == 0) return;

        // at this point, we know the new panel has parameters to render.

        // repopulate the list with the rewards from the current panel.
        selectedItem.PanelParameters.ForEach(panelParameter =>
        {
            this.listBox_parameters.Items.Add(panelParameter);
        });

        // fix the index to 0 and force a re-draw.
        this.listBox_parameters.SelectedIndex = 0;
    }

    private void RefreshParameters(object? sender, EventArgs e)
    {
        this.RedrawParameterData();
    }

    private void RedrawParameterData()
    {
        var selectedParameter = (SdpParameter)this.listBox_parameters.SelectedItem!;

        // check to make sure we have a panel to work with.
        if (selectedParameter == null)
        {
            // clear the parameter data.
            this.ClearParameterData();

            // stop processing.
            return;
        }

        // update the parameter data.
        this.num_paramGrowthPerRank.Value = selectedParameter.PerRank;
        this.checkBox_isFlat.Checked = selectedParameter.IsFlat;
        this.checkBox_isCore.Checked = selectedParameter.IsCore;

        var parameterName = ((LongParameter)selectedParameter.ParameterId).ToString();
        var parameterIndex = this.comboBox_parameter.FindString(parameterName);
        if (parameterIndex != -1)
        {
            this.comboBox_parameter.SelectedIndex = parameterIndex;
        }

        this.checkBox_isFlat.Text = this.checkBox_isFlat.Checked
            ? "Is Flat Growth"
            : "Is Percent Growth";

        this.checkBox_isCore.Text = this.checkBox_isCore.Checked
            ? "Is Core Parameter"
            : "Is Secondary Parameter";
    }

    private void ClearParameterData()
    {
        // clear the parameter data.
        this.num_paramGrowthPerRank.Value = 0;
        this.checkBox_isFlat.Checked = false;
        this.checkBox_isCore.Checked = false;
    }
    #endregion parameters

    #region rewards
    private void RenderRewards()
    {
        // wipe the current list if there is no panel.
        this.listBox_rewards.Items.Clear();

        // clear the reward data.
        this.ClearRewardData();

        // grab the panel we're working with.
        var selectedItem = (StatDistributionPanel)this.listBox_Sdps.SelectedItem!;

        // check to make sure we have a panel to work with.
        if (selectedItem == null)
        {
            // stop processing.
            return;
        }

        // at this point, we know we have a new panel to refresh for.

        // but we don't have any rewards for this panel.
        if (selectedItem.PanelRewards.Count == 0) return;

        // at this point, we know the new panel has rewards to render.

        // repopulate the list with the rewards from the current panel.
        selectedItem.PanelRewards.ForEach(panelReward =>
        {
            this.listBox_rewards.Items.Add(panelReward);
        });

        // fix the index to 0 and force a re-draw.
        this.listBox_rewards.SelectedIndex = 0;
    }

    private void RefreshRewards(object? sender, EventArgs e)
    {
        this.RedrawRewardData();
    }

    private void RedrawRewardData()
    {
        // grab the currently selected reward.
        var selectedReward = (SdpReward)this.listBox_rewards.SelectedItem!;

        // check to make sure we have a panel to work with.
        if (selectedReward == null)
        {
            // clear the reward data.
            this.ClearRewardData();

            // stop processing.
            return;
        }

        // update the reward data.
        this.textBox_rewardName.Text = selectedReward.RewardName;
        this.textBox_rewardEffect.Text = selectedReward.Effect;
        this.num_rewardRankRequired.Value = selectedReward.RankRequired;
    }

    private void ClearRewardData()
    {
        // clear the reward data.
        this.textBox_rewardName.Text = string.Empty;
        this.textBox_rewardEffect.Text = string.Empty;
        this.num_rewardRankRequired.Value = 0;
    }
    #endregion rewards

    #region setup
    public void FlagForRefresh()
    {
        this.needsSetup = true;
    }

    public void SetupComplete()
    {
        this.needsSetup = false;
    }

    public void Setup(List<StatDistributionPanel> panels)
    {
        if (!this.needsSetup) return;

        // populate the list of weapons.
        this.PopulateSdpsList(panels);

        // check if we need to autopick an index.
        if (this.listBox_Sdps.SelectedIndex == -1 && this.listBox_Sdps.Items.Count > 0)
        {
            // set the index to the first item.
            this.listBox_Sdps.SelectedIndex = 0;
        }
    }

    private void PopulateSdpsList(List<StatDistributionPanel> panels)
    {
        // empty the list first.
        this.listBox_Sdps.Items.Clear();

        // assign the list of items locally to the form.
        this.sdpList = panels;

        // iterate over each of the entries in the list 
        this.sdpList.ForEach(panel =>
        {
            // the first weapon in the list is always null, so accommodate.
            if (panel != null)
            {
                // add the weapon to the running list.
                this.listBox_Sdps.Items.Add(panel);
            }
        });

        // let this form know we've finished setup.
        this.SetupComplete();
    }
    #endregion setup

    private void button_addReward_Click(object sender, EventArgs e)
    {
        // determine the selected panel.
        var sdp = (StatDistributionPanel)this.listBox_Sdps.SelectedItem!;

        // do not proceed if there is no panel selected for some reason.
        if (sdp is null) return;

        // define the new parameter.
        var newReward = new SdpReward();

        // add the reward to the panel.
        sdp.PanelRewards.Add(newReward);

        // grab the current selection.
        var selectedIndex = this.listBox_rewards.SelectedIndex;

        // check if there was no current selection.
        if (selectedIndex == -1 || (selectedIndex == this.listBox_rewards.Items.Count - 1))
        {
            // add the item to the list without regard for index.
            this.listBox_rewards.Items.Add(newReward);
        }
        // the index selected is valid.
        else
        {
            // add it at the given index.
            this.listBox_rewards.Items.Insert(selectedIndex, newReward);
        }
    }

    private void button_removeReward_Click(object sender, EventArgs e)
    {
        // determine the selected panel.
        var sdp = (StatDistributionPanel)this.listBox_Sdps.SelectedItem!;

        // do not proceed if there is no panel selected for some reason.
        if (sdp is null) return;

        // grab the selection the user is considering removing.
        var removalIndex = this.listBox_rewards.SelectedIndex;

        // check if there is no index selected right now.
        if (removalIndex == -1)
        {
            // do nothing.
            return;
        }

        // grab the current panel we're working with.
        var selectedItem = (SdpReward)this.listBox_rewards.SelectedItem!;

        // define the prompt.
        var removalPrompt = $"Are you sure you want to remove the selected reward, [{selectedItem.RewardName}]?";

        // show the box with the prompt.
        var dialogResult = MessageBox.Show(
            removalPrompt,
            "Removing a reward",
            MessageBoxButtons.OKCancel);

        // pivot on the user decisions.
        switch (dialogResult)
        {
            case DialogResult.OK:
                sdp.PanelRewards.Remove(selectedItem);
                this.listBox_rewards.Items.RemoveAt(removalIndex);
                if (this.listBox_rewards.Items.Count != 0)
                {
                    this.listBox_rewards.SelectedIndex = 0;
                }

                break;
            case DialogResult.Cancel:
                break;
        }
    }

    private void button_addParameter_Click(object sender, EventArgs e)
    {
        // determine the selected panel.
        var sdp = (StatDistributionPanel)this.listBox_Sdps.SelectedItem!;

        // do not proceed if there is no panel selected for some reason.
        if (sdp is null) return;

        // define the new parameter.
        var newParameter = new SdpParameter();

        // add the new parameter to the panel.
        sdp.PanelParameters.Add(newParameter);

        // grab the current selection.
        var selectedIndex = this.listBox_parameters.SelectedIndex;

        // check if there was no current selection.
        if (selectedIndex == -1 || (selectedIndex == this.listBox_parameters.Items.Count - 1))
        {
            // add the item to the list without regard for index.
            this.listBox_parameters.Items.Add(newParameter);
        }
        // the index selected is valid.
        else
        {
            // add it at the given index.
            this.listBox_parameters.Items.Insert(selectedIndex, newParameter);
        }
    }

    private void button_removeParameter_Click(object sender, EventArgs e)
    {
        // determine the selected panel.
        var sdp = (StatDistributionPanel)this.listBox_Sdps.SelectedItem!;

        // do not proceed if there is no panel selected for some reason.
        if (sdp is null) return;

        // grab the selection the user is considering removing.
        var removalIndex = this.listBox_parameters.SelectedIndex;

        // check if there is no index selected right now.
        if (removalIndex == -1)
        {
            // do nothing.
            return;
        }

        // grab the current panel we're working with.
        var selectedItem = (SdpParameter)this.listBox_parameters.SelectedItem!;

        // define the prompt.
        var removalPrompt = $"Are you sure you want to remove the selected parameter, [{selectedItem.ParameterName}]?";

        // show the box with the prompt.
        var dialogResult = MessageBox.Show(
            removalPrompt,
            "Removing a parameter",
            MessageBoxButtons.OKCancel);

        // pivot on the user decisions.
        switch (dialogResult)
        {
            case DialogResult.OK:
                sdp.PanelParameters.Remove(selectedItem);
                this.listBox_parameters.Items.RemoveAt(removalIndex);
                if (this.listBox_parameters.Items.Count != 0)
                {
                    this.listBox_parameters.SelectedIndex = 0;
                }

                break;
            case DialogResult.Cancel:
                break;
        }
    }

    private void button_addSdp_Click(object sender, EventArgs e)
    {
        // define the new SDP.
        var newSdp = new StatDistributionPanel
        {
            Name = "===NEW SDP===",
            Key = "NEW_0"
        };

        // grab the current selection.
        var selectedIndex = this.listBox_Sdps.SelectedIndex;

        // check if there was no current selection.
        if (selectedIndex == -1 || (selectedIndex == this.listBox_Sdps.Items.Count - 1))
        {
            // add the item to the list without regard for index.
            this.listBox_Sdps.Items.Add(newSdp);
        }
        // we are in the middle somewhere.
        else
        {
            // add it at the given index.
            this.listBox_Sdps.Items.Insert(selectedIndex, newSdp);
        }
    }

    private void button_removeSdp_Click(object sender, EventArgs e)
    {
        // grab the selection the user is considering removing.
        var removalIndex = this.listBox_Sdps.SelectedIndex;

        // check if there is no index selected right now.
        if (removalIndex == -1)
        {
            // do nothing.
            return;
        }

        // grab the current panel we're working with.
        var selectedItem = (StatDistributionPanel)this.listBox_Sdps.SelectedItem!;

        // define the prompt.
        var removalPrompt = $"Are you sure you want to remove the panel with key [{selectedItem.Key}]?";

        // show the box with the prompt.
        var dialogResult = MessageBox.Show(
            removalPrompt,
            "Removing a SDP",
            MessageBoxButtons.OKCancel);

        // pivot on the user decisions.
        switch (dialogResult)
        {
            case DialogResult.OK:
                this.listBox_Sdps.Items.RemoveAt(removalIndex);
                if (this.listBox_Sdps.Items.Count != 0)
                {
                    this.listBox_Sdps.SelectedIndex = 0;
                }

                break;
            case DialogResult.Cancel:
                break;
        }
    }
}

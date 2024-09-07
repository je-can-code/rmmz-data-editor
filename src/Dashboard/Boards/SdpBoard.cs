using JMZ.Dashboard.Mappers;
using JMZ.Sdp.Data.Models;

namespace JMZ.Dashboard.Boards;

public partial class SdpBoard : Form
{
    private ToolTip _toolTip = new();

    public bool needsSetup = true;

    private List<StatDistributionPanel> sdpList = [];

    public SdpBoard()
    {
        InitializeComponent();

        InitializeDataControls();
        InitializeTooltips();
        ApplyUpdateEvents();
    }

    /// <summary>
    ///     Initializes the data-binding of components to arbitrary values.
    /// </summary>
    private void InitializeDataControls()
    {
        // setup the main list box of SDPs.
        listBox_Sdps.DisplayMember = "Name";
        listBox_Sdps.ValueMember = "Key";

        // setup the listing of parameters per panel.
        listBox_parameters.DisplayMember = "ParameterName";
        listBox_parameters.ValueMember = "ParameterId";

        // setup the listing of rewards per panel.
        listBox_rewards.DisplayMember = "RewardName";
        listBox_rewards.ValueMember = "Effect";

        // associate the dropdowns with their appropriate data types.
        comboBox_parameter.DataSource = OrderMapper.ToLongParameters();
        comboBox_rarity.DataSource = OrderMapper.ToRarities();
    }

    /// <summary>
    ///     Initializes all tooltips associated with this board.
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
        ApplyUpdateEventsForCoreData();
        ApplyUpdateEventsForCostData();
        ApplyUpdateEventsForDescriptionData();
        ApplyUpdateEventsForParameterData();
        ApplyUpdateEventsForRewardData();

        listBox_Sdps.SelectedIndexChanged += RefreshForm;
        listBox_parameters.SelectedIndexChanged += RefreshParameters;
        listBox_rewards.SelectedIndexChanged += RefreshRewards;
    }

    private void ApplyUpdateEventsForCoreData()
    {
        textBox_key.TextChanged += UpdateSdpKey;
        textBox_name.TextChanged += UpdateSdpName;
        num_iconIndex.ValueChanged += UpdateIconIndex;
        checkBox_unlockedByDefault.CheckedChanged += UpdateUnlockedByDefault;
        comboBox_rarity.SelectedIndexChanged += UpdateRarity;
    }

    private void ApplyUpdateEventsForCostData()
    {
        num_maxRank.ValueChanged += UpdateMaxRank;
        num_baseCost.ValueChanged += UpdateBaseCost;
        num_flatGrowth.ValueChanged += UpdateFlatGrowth;
        num_multGrowth.ValueChanged += UpdateMultGrowth;
    }

    private void ApplyUpdateEventsForDescriptionData()
    {
        textBox_flavorText.TextChanged += UpdateFlavorText;
        textBox_description.TextChanged += UpdateDescription;
    }

    private void ApplyUpdateEventsForParameterData()
    {
        num_paramGrowthPerRank.ValueChanged += UpdateGrowthPerRank;
        checkBox_isFlat.CheckedChanged += UpdateIsFlat;
        checkBox_isCore.CheckedChanged += UpdateIsCore;
        comboBox_parameter.SelectedIndexChanged += UpdateParameterType;
    }

    private void ApplyUpdateEventsForRewardData()
    {
        textBox_rewardName.TextChanged += UpdateRewardName;

        // NOTE: updating the name is a bit hacky on sub-lists lke rewards.
        textBox_rewardName.LostFocus += SyncRewardListNames;

        textBox_rewardEffect.TextChanged += UpdateRewardEffect;
        num_rewardRankRequired.ValueChanged += UpdateRewardRankRequired;
    }

    public List<StatDistributionPanel> Sdps()
    {
        return sdpList;
    }

    public void TrackedToSavedSdps()
    {
        // clear the existing list.
        sdpList.Clear();

        // iterate over the tracked list.
        foreach (var sdp in listBox_Sdps.Items)
        {
            // add each item from the tracked list into the list to be saved.
            sdpList.Add((StatDistributionPanel)sdp);
        }
    }

    private void RefreshForm(object? sender, EventArgs e)
    {
        _RefreshForm();
    }

    private void _RefreshForm()
    {
        var selectedItem = (StatDistributionPanel)listBox_Sdps.SelectedItem!;
        if (selectedItem != null)
        {
            // core data
            textBox_key.Text = selectedItem.Key;
            textBox_name.Text = selectedItem.Name;
            num_iconIndex.Value = selectedItem.IconIndex;
            checkBox_unlockedByDefault.Checked = selectedItem.UnlockedByDefault;
            var rarityName = ((Rarity)selectedItem.Rarity).ToString();
            var rarityIndex = comboBox_rarity.FindString(rarityName);
            if (rarityIndex != -1)
            {
                comboBox_rarity.SelectedIndex = rarityIndex;
            }

            // cost data
            num_maxRank.Value = selectedItem.MaxRank;
            num_baseCost.Value = selectedItem.BaseCost;
            num_flatGrowth.Value = selectedItem.FlatGrowthCost;
            num_multGrowth.Value = selectedItem.MultGrowthCost;

            // description data
            textBox_description.Text = selectedItem.Description;
            textBox_flavorText.Text = selectedItem.TopFlavorText;
        }

        RenderParameters();
        RenderRewards();
    }

    private void button_addReward_Click(object sender, EventArgs e)
    {
        // determine the selected panel.
        var sdp = (StatDistributionPanel)listBox_Sdps.SelectedItem!;

        // do not proceed if there is no panel selected for some reason.
        if (sdp is null) return;

        // define the new parameter.
        var newReward = new SdpReward();

        // add the reward to the panel.
        sdp.PanelRewards.Add(newReward);

        // grab the current selection.
        var selectedIndex = listBox_rewards.SelectedIndex;

        // check if there was no current selection.
        if (selectedIndex == -1 || selectedIndex == listBox_rewards.Items.Count - 1)
        {
            // add the item to the list without regard for index.
            listBox_rewards.Items.Add(newReward);
        }
        // the index selected is valid.
        else
        {
            // add it at the given index.
            listBox_rewards.Items.Insert(selectedIndex, newReward);
        }
    }

    private void button_removeReward_Click(object sender, EventArgs e)
    {
        // determine the selected panel.
        var sdp = (StatDistributionPanel)listBox_Sdps.SelectedItem!;

        // do not proceed if there is no panel selected for some reason.
        if (sdp is null) return;

        // grab the selection the user is considering removing.
        var removalIndex = listBox_rewards.SelectedIndex;

        // check if there is no index selected right now.
        if (removalIndex == -1)
        {
            // do nothing.
            return;
        }

        // grab the current panel we're working with.
        var selectedItem = (SdpReward)listBox_rewards.SelectedItem!;

        // define the prompt.
        var removalPrompt = $"Are you sure you want to remove the selected reward, [{selectedItem.RewardName}]?";

        // show the box with the prompt.
        var dialogResult = MessageBox.Show(removalPrompt, "Removing a reward", MessageBoxButtons.OKCancel);

        // pivot on the user decisions.
        switch (dialogResult)
        {
            case DialogResult.OK:
                sdp.PanelRewards.Remove(selectedItem);
                listBox_rewards.Items.RemoveAt(removalIndex);
                if (listBox_rewards.Items.Count != 0)
                {
                    listBox_rewards.SelectedIndex = 0;
                }

                break;
            case DialogResult.Cancel:
                break;
        }
    }

    private void button_addParameter_Click(object sender, EventArgs e)
    {
        // determine the selected panel.
        var sdp = (StatDistributionPanel)listBox_Sdps.SelectedItem!;

        // do not proceed if there is no panel selected for some reason.
        if (sdp is null) return;

        // define the new parameter.
        var newParameter = new SdpParameter();

        // add the new parameter to the panel.
        sdp.PanelParameters.Add(newParameter);

        // grab the current selection.
        var selectedIndex = listBox_parameters.SelectedIndex;

        // check if there was no current selection.
        if (selectedIndex == -1 || selectedIndex == listBox_parameters.Items.Count - 1)
        {
            // add the item to the list without regard for index.
            listBox_parameters.Items.Add(newParameter);
        }
        // the index selected is valid.
        else
        {
            // add it at the given index.
            listBox_parameters.Items.Insert(selectedIndex, newParameter);
        }
    }

    private void button_removeParameter_Click(object sender, EventArgs e)
    {
        // determine the selected panel.
        var sdp = (StatDistributionPanel)listBox_Sdps.SelectedItem!;

        // do not proceed if there is no panel selected for some reason.
        if (sdp is null) return;

        // grab the selection the user is considering removing.
        var removalIndex = listBox_parameters.SelectedIndex;

        // check if there is no index selected right now.
        if (removalIndex == -1)
        {
            // do nothing.
            return;
        }

        // grab the current panel we're working with.
        var selectedItem = (SdpParameter)listBox_parameters.SelectedItem!;

        // define the prompt.
        var removalPrompt = $"Are you sure you want to remove the selected parameter, [{selectedItem.ParameterName}]?";

        // show the box with the prompt.
        var dialogResult = MessageBox.Show(removalPrompt, "Removing a parameter", MessageBoxButtons.OKCancel);

        // pivot on the user decisions.
        switch (dialogResult)
        {
            case DialogResult.OK:
                sdp.PanelParameters.Remove(selectedItem);
                listBox_parameters.Items.RemoveAt(removalIndex);
                if (listBox_parameters.Items.Count != 0)
                {
                    listBox_parameters.SelectedIndex = 0;
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
            Name = "==NEW SDP==",
            Key = "NEW_0"
        };

        // grab the current selection.
        var selectedIndex = listBox_Sdps.SelectedIndex;

        // check if there was no current selection.
        if (selectedIndex == -1 || selectedIndex == listBox_Sdps.Items.Count - 1)
        {
            // add the item to the list without regard for index.
            listBox_Sdps.Items.Add(newSdp);
        }
        // we are in the middle somewhere.
        else
        {
            // add it at the given index.
            listBox_Sdps.Items.Insert(selectedIndex, newSdp);
        }

        // select the newly created panel.
        listBox_Sdps.SelectedIndex -= 1;
    }

    private void button_removeSdp_Click(object sender, EventArgs e)
    {
        // grab the selection the user is considering removing.
        var removalIndex = listBox_Sdps.SelectedIndex;

        // check if there is no index selected right now.
        if (removalIndex == -1)
        {
            // do nothing.
            return;
        }

        // grab the current panel we're working with.
        var selectedItem = (StatDistributionPanel)listBox_Sdps.SelectedItem!;

        // define the prompt.
        var removalPrompt = $"Are you sure you want to remove the panel with key [{selectedItem.Key}]?";

        // show the box with the prompt.
        var dialogResult = MessageBox.Show(removalPrompt, "Removing a SDP", MessageBoxButtons.OKCancel);

        // pivot on the user decisions.
        switch (dialogResult)
        {
            case DialogResult.OK:
                // remove the designated panel from the list in memory.
                listBox_Sdps.Items.RemoveAt(removalIndex);

                // 
                if (listBox_Sdps.Items.Count != 0)
                {
                    listBox_Sdps.SelectedIndex = Math.Max(-1, removalIndex - 1);
                }

                break;
            case DialogResult.Cancel:
                break;
        }
    }

    #region updates
    #region update panel-level data
    #region update core data
    private void UpdateSdpKey(object? sender, EventArgs e)
    {
        // determine the selected item.
        var sdp = (StatDistributionPanel)listBox_Sdps.SelectedItem!;

        // don't update if it was null.
        if (sdp is null) return;

        // update with the new value.
        sdp.Key = textBox_key.Text;
    }

    private void UpdateSdpName(object? sender, EventArgs e)
    {
        // determine the selected item.
        var sdp = (StatDistributionPanel)listBox_Sdps.SelectedItem!;

        // don't update if it was null.
        if (sdp is null) return;

        // update the name with the new value.
        sdp.Name = textBox_name.Text;

        // the name is special in that it needs to be synced with the list to ensure name updates apply.
        listBox_Sdps.Items[listBox_Sdps.SelectedIndex] = sdp;
    }

    private void UpdateIconIndex(object? sender, EventArgs e)
    {
        // determine the selected item.
        var sdp = (StatDistributionPanel)listBox_Sdps.SelectedItem!;

        // don't update if it was null.
        if (sdp is null) return;

        // update with the new value.
        sdp.IconIndex = (int)num_iconIndex.Value;
    }

    private void UpdateUnlockedByDefault(object? sender, EventArgs e)
    {
        // determine the selected item.
        var sdp = (StatDistributionPanel)listBox_Sdps.SelectedItem!;

        // don't update if it was null.
        if (sdp is null) return;

        // update with the new value.
        sdp.UnlockedByDefault = checkBox_unlockedByDefault.Checked;
    }

    private void UpdateRarity(object? sender, EventArgs e)
    {
        // determine the selected item.
        var sdp = (StatDistributionPanel)listBox_Sdps.SelectedItem!;

        // don't update if it was null.
        if (sdp is null) return;

        // update with the new value.
        var rarity = (Rarity)comboBox_rarity.SelectedItem!;

        // cast the rarity as its underlying color index form.
        sdp.Rarity = (int)rarity;
    }
    #endregion

    #region update cost data
    private void UpdateMaxRank(object? sender, EventArgs e)
    {
        // determine the selected item.
        var sdp = (StatDistributionPanel)listBox_Sdps.SelectedItem!;

        // don't update if it was null.
        if (sdp is null) return;

        // update with the new value.
        sdp.MaxRank = (int)num_maxRank.Value;
    }

    private void UpdateBaseCost(object? sender, EventArgs e)
    {
        // determine the selected item.
        var sdp = (StatDistributionPanel)listBox_Sdps.SelectedItem!;

        // don't update if it was null.
        if (sdp is null) return;

        // update with the new value.
        sdp.BaseCost = num_baseCost.Value;
    }

    private void UpdateFlatGrowth(object? sender, EventArgs e)
    {
        // determine the selected item.
        var sdp = (StatDistributionPanel)listBox_Sdps.SelectedItem!;

        // don't update if it was null.
        if (sdp is null) return;

        // update with the new value.
        sdp.FlatGrowthCost = num_flatGrowth.Value;
    }

    private void UpdateMultGrowth(object? sender, EventArgs e)
    {
        // determine the selected item.
        var sdp = (StatDistributionPanel)listBox_Sdps.SelectedItem!;

        // don't update if it was null.
        if (sdp is null) return;

        // update with the new value.
        sdp.MultGrowthCost = num_multGrowth.Value;
    }
    #endregion

    #region update description data
    private void UpdateFlavorText(object? sender, EventArgs e)
    {
        // determine the selected item.
        var sdp = (StatDistributionPanel)listBox_Sdps.SelectedItem!;

        // don't update if it was null.
        if (sdp is null) return;

        // update the name with the new value.
        sdp.TopFlavorText = textBox_flavorText.Text;
    }

    private void UpdateDescription(object? sender, EventArgs e)
    {
        // determine the selected item.
        var sdp = (StatDistributionPanel)listBox_Sdps.SelectedItem!;

        // don't update if it was null.
        if (sdp is null) return;

        // update the name with the new value.
        sdp.Description = textBox_description.Text;
    }
    #endregion
    #endregion

    #region update panel-parameter-level data
    private void UpdateGrowthPerRank(object? sender, EventArgs e)
    {
        // determine the selected item.
        var selectedParameter = (SdpParameter)listBox_parameters.SelectedItem!;

        // don't update if the parameter was null.
        if (selectedParameter is null) return;

        // update with the new value.
        selectedParameter.PerRank = num_paramGrowthPerRank.Value;
    }

    private void UpdateIsFlat(object? sender, EventArgs e)
    {
        // determine the selected item.
        var selectedParameter = (SdpParameter)listBox_parameters.SelectedItem!;

        // don't update if the parameter was null.
        if (selectedParameter is null) return;

        // update with the new value.
        selectedParameter.IsFlat = checkBox_isFlat.Checked;

        // also update the checkbox text.
        checkBox_isFlat.Text = checkBox_isFlat.Checked
            ? "Is Flat Growth"
            : "Is Percent Growth";

        // the name is special in that it needs to be synced with the list to ensure name updates apply.
        SyncParameterListNames();
    }

    private void UpdateIsCore(object? sender, EventArgs e)
    {
        // determine the selected item.
        var selectedParameter = (SdpParameter)listBox_parameters.SelectedItem!;

        // don't update if the parameter was null.
        if (selectedParameter is null) return;

        // update with the new value.
        selectedParameter.IsCore = checkBox_isCore.Checked;

        // also update the checkbox text.
        checkBox_isCore.Text = checkBox_isCore.Checked
            ? "Is Core Parameter"
            : "Is Secondary Parameter";

        // the name is special in that it needs to be synced with the list to ensure name updates apply.
        SyncParameterListNames();
    }

    private void UpdateParameterType(object? sender, EventArgs e)
    {
        // determine the selected item.
        var selectedParameter = (SdpParameter)listBox_parameters.SelectedItem!;

        // don't update if the parameter was null.
        if (selectedParameter is null) return;

        // TODO: properly convert the selected item into the given ID matching the parameter.
        // update with the new value.
        var longParameter = (LongParameter)comboBox_parameter.SelectedItem!;

        // cast the parameterId as its underlying index form.
        selectedParameter.ParameterId = (int)longParameter;

        // the name is special in that it needs to be synced with the list to ensure name updates apply.
        SyncParameterListNames();
    }

    private void SyncParameterListNames()
    {
        // determine the selected item.
        var selectedItem = (SdpParameter)listBox_parameters.SelectedItem!;

        // don't update if it was null.
        if (selectedItem is null) return;

        // the name is special in that it needs to be synced with the list to ensure name updates apply.
        listBox_parameters.Items[listBox_parameters.SelectedIndex] = selectedItem;
    }
    #endregion

    #region update panel-reward-level data
    private void UpdateRewardName(object? sender, EventArgs e)
    {
        // determine the selected item.
        var selectedReward = (SdpReward)listBox_rewards.SelectedItem!;

        // don't update if it was null.
        if (selectedReward is null) return;

        // update with the new value.
        selectedReward.RewardName = textBox_rewardName.Text;
    }

    private void SyncRewardListNames(object? sender, EventArgs e)
    {
        // determine the selected item.
        var selectedReward = (SdpReward)listBox_rewards.SelectedItem!;

        // don't update if it was null.
        if (selectedReward is null) return;

        // the name is special in that it needs to be synced with the list to ensure name updates apply.
        listBox_rewards.Items[listBox_rewards.SelectedIndex] = selectedReward;
    }

    private void UpdateRewardEffect(object? sender, EventArgs e)
    {
        // determine the selected item.
        var selectedReward = (SdpReward)listBox_rewards.SelectedItem!;

        // don't update if it was null.
        if (selectedReward is null) return;

        // update with the new value.
        selectedReward.Effect = textBox_rewardEffect.Text;
    }

    private void UpdateRewardRankRequired(object? sender, EventArgs e)
    {
        // determine the selected item.
        var selectedReward = (SdpReward)listBox_rewards.SelectedItem!;

        // don't update if it was null.
        if (selectedReward is null) return;

        // update with the new value.
        selectedReward.RankRequired = (int)num_rewardRankRequired.Value;
    }
    #endregion
    #endregion updates

    #region parameters
    private void RenderParameters()
    {
        // wipe the current list.
        listBox_parameters.Items.Clear();

        // clear the parameter data.
        ClearParameterData();

        // grab the panel we're working with.
        var selectedItem = (StatDistributionPanel)listBox_Sdps.SelectedItem!;

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
        selectedItem.PanelParameters.ForEach(
            panelParameter =>
            {
                listBox_parameters.Items.Add(panelParameter);
            });

        // fix the index to 0 and force a re-draw.
        listBox_parameters.SelectedIndex = 0;
    }

    private void RefreshParameters(object? sender, EventArgs e)
    {
        RedrawParameterData();
    }

    private void RedrawParameterData()
    {
        var selectedParameter = (SdpParameter)listBox_parameters.SelectedItem!;

        // check to make sure we have a panel to work with.
        if (selectedParameter == null)
        {
            // clear the parameter data.
            ClearParameterData();

            // stop processing.
            return;
        }

        // update the parameter data.
        num_paramGrowthPerRank.Value = selectedParameter.PerRank;
        checkBox_isFlat.Checked = selectedParameter.IsFlat;
        checkBox_isCore.Checked = selectedParameter.IsCore;

        var parameterName = ((LongParameter)selectedParameter.ParameterId).ToString();
        var parameterIndex = comboBox_parameter.FindString(parameterName);
        if (parameterIndex != -1)
        {
            comboBox_parameter.SelectedIndex = parameterIndex;
        }

        checkBox_isFlat.Text = checkBox_isFlat.Checked
            ? "Is Flat Growth"
            : "Is Percent Growth";

        checkBox_isCore.Text = checkBox_isCore.Checked
            ? "Is Core Parameter"
            : "Is Secondary Parameter";
    }

    private void ClearParameterData()
    {
        // clear the parameter data.
        num_paramGrowthPerRank.Value = 0;
        checkBox_isFlat.Checked = false;
        checkBox_isCore.Checked = false;
    }
    #endregion parameters

    #region rewards
    private void RenderRewards()
    {
        // wipe the current list if there is no panel.
        listBox_rewards.Items.Clear();

        // clear the reward data.
        ClearRewardData();

        // grab the panel we're working with.
        var selectedItem = (StatDistributionPanel)listBox_Sdps.SelectedItem!;

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
        selectedItem.PanelRewards.ForEach(
            panelReward =>
            {
                listBox_rewards.Items.Add(panelReward);
            });

        // fix the index to 0 and force a re-draw.
        listBox_rewards.SelectedIndex = 0;
    }

    private void RefreshRewards(object? sender, EventArgs e)
    {
        RedrawRewardData();
    }

    private void RedrawRewardData()
    {
        // grab the currently selected reward.
        var selectedReward = (SdpReward)listBox_rewards.SelectedItem!;

        // check to make sure we have a panel to work with.
        if (selectedReward == null)
        {
            // clear the reward data.
            ClearRewardData();

            // stop processing.
            return;
        }

        // update the reward data.
        textBox_rewardName.Text = selectedReward.RewardName;
        textBox_rewardEffect.Text = selectedReward.Effect;
        num_rewardRankRequired.Value = selectedReward.RankRequired;
    }

    private void ClearRewardData()
    {
        // clear the reward data.
        textBox_rewardName.Text = string.Empty;
        textBox_rewardEffect.Text = string.Empty;
        num_rewardRankRequired.Value = 0;
    }
    #endregion rewards

    #region setup
    public void FlagForRefresh()
    {
        needsSetup = true;
    }

    public void SetupComplete()
    {
        needsSetup = false;
    }

    public void Setup(List<StatDistributionPanel> panels)
    {
        if (!needsSetup) return;

        // populate the list of weapons.
        PopulateSdpsList(panels);

        // check if we need to autopick an index.
        if (listBox_Sdps.SelectedIndex == -1 && listBox_Sdps.Items.Count > 0)
        {
            // set the index to the first item.
            listBox_Sdps.SelectedIndex = 0;
        }
    }

    private void PopulateSdpsList(List<StatDistributionPanel> panels)
    {
        // empty the list first.
        listBox_Sdps.Items.Clear();

        // assign the list of items locally to the form.
        sdpList = panels;

        // iterate over each of the entries in the list 
        sdpList.ForEach(
            panel =>
            {
                // the first weapon in the list is always null, so accommodate.
                if (panel != null)
                {
                    // add the weapon to the running list.
                    listBox_Sdps.Items.Add(panel);
                }
            });

        // let this form know we've finished setup.
        SetupComplete();
    }
    #endregion setup
}
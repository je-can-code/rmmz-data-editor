using JMZ.Dashboard.Extensions;
using JMZ.Quest.Data;
using JMZ.Quest.Data.Enums;
using JMZ.Quest.Data.Models;

namespace JMZ.Dashboard.Boards;

public partial class QuestBoard : Form
{
    public List<OmniQuest> OmniQuests { get; } = [];

    public List<OmniCategory> OmniCategories { get; } = [];

    public List<OmniTag> OmniTags { get; } = [];

    private bool _needsSetup = true;

    public void TrackedToSaved()
    {
        OmniQuests.Clear();
        // OmniCategories.Clear();
        // OmniTags.Clear();

        foreach (var quest in listBoxQuests.Items)
        {
            OmniQuests.Add((OmniQuest)quest);
        }

        // TODO: update categories.
        // TODO: update tags.
    }

    public QuestBoard()
    {
        InitializeComponent();

        InitializeDataControls();
        ApplyUpdateEvents();
    }

    #region init
    /// <summary>
    /// Initializes the data-binding of components to arbitrary values.
    /// </summary>
    private void InitializeDataControls()
    {
        listBoxQuests.DisplayMember = nameof(OmniQuest.Name);
        listBoxQuests.ValueMember = nameof(OmniQuest.Key);

        comboBoxCategory.DisplayMember = nameof(OmniCategory.Name);
        comboBoxCategory.ValueMember = nameof(OmniCategory.Key);

        listBoxTags.DisplayMember = nameof(OmniTag.Name);
        listBoxTags.ValueMember = nameof(OmniTag.Key);

        listBoxObjectives.DisplayMember = nameof(OmniObjective.Id);
        listBoxObjectives.ValueMember = nameof(OmniObjective.Id);

        // this is unchanging data.
        comboBoxObjectiveType.DisplayMember = nameof(OmniObjective.ObjectiveName);
        comboBoxObjectiveType.ValueMember = nameof(OmniObjective.Type);
        foreach (var enumValue in Enum.GetValues<OmniObjectiveType>())
        {
            comboBoxObjectiveType.Items.Add(enumValue);
        }
        
        comboBoxFetchType.DisplayMember = nameof(OmniObjective.FetchTypeName);
        comboBoxFetchType.ValueMember = nameof(OmniObjective.FetchTypeId);
        foreach (var enumValue in Enum.GetValues<OmniObjectiveFetchType>())
        {
            comboBoxFetchType.Items.Add(enumValue);
        }
    }

    private void ApplyUpdateEvents()
    {
        listBoxQuests.SelectedIndexChanged += RefreshQuestFormEvent;
        listBoxObjectives.SelectedIndexChanged += RefreshObjectiveDataEvent;
        ApplyUpdateEventsForCoreData();
        ApplyUpdateEventsForObjectiveData();
    }

    private void ApplyUpdateEventsForCoreData()
    {
        textBoxKey.TextChanged += UpdateKey;
        textBoxName.TextChanged += UpdateName;
        numIconIndex.ValueChanged += UpdateIconIndex;
        comboBoxCategory.SelectedIndexChanged += UpdateCategory;
        numRecommendedLevel.ValueChanged += UpdateRecommendedLevel;
        textBoxUnknownHint.TextChanged += UpdateUnknownHint;
        textBoxOverview.TextChanged += UpdateOverview;
        listBoxTags.SelectedIndexChanged += UpdateTagKeys;
        
    }

    private void ApplyUpdateEventsForObjectiveData()
    {
        numObjectiveId.ValueChanged += UpdateObjectiveId;
        checkBoxHiddenByDefault.CheckedChanged += UpdateObjectiveHiddenByDefault;
        checkBoxIsOptional.CheckedChanged += UpdateObjectiveIsOptional;
        textBoxObjectiveDescription.TextChanged += UpdateObjectiveDescription;
        
        textBoxLogInactive.TextChanged += UpdateObjectiveLogsInactive;
        textBoxLogActive.TextChanged += UpdateObjectiveLogsActive;
        textBoxLogCompleted.TextChanged += UpdateObjectiveLogsCompleted;
        textBoxLogFailed.TextChanged += UpdateObjectiveLogsFailed;
        textBoxLogMissed.TextChanged += UpdateObjectiveLogsMissed;

        comboBoxObjectiveType.SelectedIndexChanged += UpdateObjectiveType;
        
        textBoxIndiscriminateData.TextChanged += UpdateObjectiveIndiscriminateData;
        
        numDestinationMapId.ValueChanged += UpdateObjectiveDestinationData;
        numDestinationX1.ValueChanged += UpdateObjectiveDestinationData;
        numDestinationY1.ValueChanged += UpdateObjectiveDestinationData;
        numDestinationX2.ValueChanged += UpdateObjectiveDestinationData;
        numDestinationY2.ValueChanged += UpdateObjectiveDestinationData;
        
        comboBoxFetchType.SelectedIndexChanged += UpdateObjectiveFetchData;
        numFetchId.ValueChanged += UpdateObjectiveFetchData;
        numFetchAmount.ValueChanged += UpdateObjectiveFetchData;

        numSlayEnemyId.ValueChanged += UpdateObjectiveSlayData;
        numSlayAmount.ValueChanged += UpdateObjectiveSlayData;

        textBoxObjectiveQuestData.TextChanged += UpdateObjectiveQuestKeys;
    }
    #endregion init

    #region update
    #region core
    private void UpdateKey(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (OmniQuest)listBoxQuests.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // update with the new value.
        item.Key = textBoxKey.Text;
    }
    
    private void UpdateName(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (OmniQuest)listBoxQuests.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // update with the new value.
        item.Name = textBoxName.Text;
    }
    
    private void UpdateIconIndex(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (OmniQuest)listBoxQuests.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // update with the new value.
        item.IconIndex = (int)numIconIndex.Value;
    }
    
    private void UpdateCategory(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (OmniQuest)listBoxQuests.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // update with the new value.
        item.CategoryKey = ((OmniCategory)comboBoxCategory.SelectedItem!).Key;
    }
    
    private void UpdateRecommendedLevel(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (OmniQuest)listBoxQuests.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // update with the new value.
        item.RecommendedLevel = (int)numRecommendedLevel.Value;
    }
    
    private void UpdateTagKeys(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (OmniQuest)listBoxQuests.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // update with the new value.
        var tagKeys = new List<string>();
        foreach (var tag in listBoxTags.SelectedItems)
        {
            var omniTag = (OmniTag)tag;
            tagKeys.Add(omniTag.Key);
        }
        item.TagKeys = tagKeys.ToArray();
    }
    
    private void UpdateUnknownHint(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (OmniQuest)listBoxQuests.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // update with the new value.
        item.UnknownHint = textBoxUnknownHint.Text;
    }
    
    private void UpdateOverview(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (OmniQuest)listBoxQuests.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // update with the new value.
        item.Overview = textBoxOverview.Text;
    }
    #endregion core
    
    #region objective
    private void UpdateObjectiveId(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (OmniObjective)listBoxObjectives.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // update with the new value.
        item.Id = (int)numObjectiveId.Value;
    }
    
    private void UpdateObjectiveHiddenByDefault(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (OmniObjective)listBoxObjectives.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // update with the new value.
        item.HiddenByDefault = checkBoxHiddenByDefault.Checked;
    }
    
    private void UpdateObjectiveIsOptional(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (OmniObjective)listBoxObjectives.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // update with the new value.
        item.IsOptional = checkBoxIsOptional.Checked;
    }
    
    private void UpdateObjectiveDescription(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (OmniObjective)listBoxObjectives.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // update with the new value.
        item.Description = textBoxObjectiveDescription.Text;
    }
    
    private void UpdateObjectiveLogsInactive(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (OmniObjective)listBoxObjectives.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // update with the new value.
        item.Logs.Inactive = textBoxLogInactive.Text;
    }
    
    private void UpdateObjectiveLogsActive(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (OmniObjective)listBoxObjectives.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // update with the new value.
        item.Logs.Active = textBoxLogActive.Text;
    }
    
    private void UpdateObjectiveLogsCompleted(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (OmniObjective)listBoxObjectives.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // update with the new value.
        item.Logs.Completed = textBoxLogCompleted.Text;
    }
    
    private void UpdateObjectiveLogsFailed(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (OmniObjective)listBoxObjectives.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // update with the new value.
        item.Logs.Failed = textBoxLogFailed.Text;
    }
    
    private void UpdateObjectiveLogsMissed(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (OmniObjective)listBoxObjectives.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // update with the new value.
        item.Logs.Missed = textBoxLogMissed.Text;
    }

    private void UpdateObjectiveType(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (OmniObjective)listBoxObjectives.SelectedItem!;

        var objectiveType = (OmniObjectiveType)comboBoxObjectiveType.SelectedItem!;
        item.Type = (int)objectiveType;
        
        RefreshFulfillmentData(item);
    }

    private void UpdateObjectiveIndiscriminateData(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (OmniObjective)listBoxObjectives.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // update with the new value.
        item.FulfillmentData = [];
        item.SetIndiscriminateData(textBoxIndiscriminateData.Text);
    }
    
    private void UpdateObjectiveDestinationData(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (OmniObjective)listBoxObjectives.SelectedItem!;

        // don't update if it was null.
        var newDestinationData = new List<int>
        {
            (int)numDestinationMapId.Value,
            (int)numDestinationX1.Value,
            (int)numDestinationY1.Value,
            (int)numDestinationX2.Value,
            (int)numDestinationY2.Value
        };

        // update with the new value.
        item.SetDestinationData(newDestinationData);
    }

    private void UpdateObjectiveFetchData(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (OmniObjective)listBoxObjectives.SelectedItem!;

        // don't update if it was null.
        var newFetchData = new List<int>
        {
            (int)(OmniObjectiveFetchType)comboBoxFetchType.SelectedItem!,
            (int)numFetchId.Value,
            (int)numFetchAmount.Value,
        };

        // update with the new value.
        item.SetFetchData(newFetchData);
    }
    
    private void UpdateObjectiveSlayData(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (OmniObjective)listBoxObjectives.SelectedItem!;

        // don't update if it was null.
        var newSlayData = new List<int>
        {
            (int)numSlayEnemyId.Value,
            (int)numSlayAmount.Value,
        };

        // update with the new value.
        item.SetSlayData(newSlayData);
    }
    
    private void UpdateObjectiveQuestKeys(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (OmniObjective)listBoxObjectives.SelectedItem!;
        
        // update with the new value.
        item?.SetQuestKeys(textBoxObjectiveQuestData.Text);
    }
    #endregion objective
    
    #endregion update

    #region refresh
    private void RefreshQuestFormEvent(object? sender, EventArgs e)
    {
        RefreshQuestForm();
    }

    private void RefreshQuestForm()
    {
        var selectedItem = (OmniQuest)listBoxQuests.SelectedItem!;
        if (selectedItem is null) return;

        RefreshCoreData(selectedItem);
        RefreshObjectivesData(selectedItem);
    }

    private void RefreshCoreData(OmniQuest selectedItem)
    {
        // core data
        textBoxKey.Text = selectedItem.Key;
        textBoxName.Text = selectedItem.Name;
        textBoxOverview.Text = selectedItem.Overview;
        textBoxUnknownHint.Text = selectedItem.UnknownHint;
        numIconIndex.Value = selectedItem.IconIndex;

        var categoryIndex = comboBoxCategory.Items.FindIndex<OmniCategory>(category => category.Key == selectedItem.CategoryKey);
        comboBoxCategory.SelectedIndex = categoryIndex;

        listBoxTags.SelectedIndices.Clear();
        foreach (var tagKey in selectedItem.TagKeys)
        {
            listBoxTags.SelectedIndices.Add(listBoxTags.Items.FindIndex<OmniTag>(tag => tag.Key == tagKey));
        }
    }

    private void RefreshObjectivesData(OmniQuest selectedItem)
    {
        listBoxObjectives.Items.Clear();

        var objectives = selectedItem.Objectives;

        if (objectives.Length == 0)
        {
            listBoxObjectives.SelectedIndex = -1;
            return;
        }

        foreach (var objective in objectives)
        {
            listBoxObjectives.Items.Add(objective);
        }

        listBoxObjectives.SelectedIndex = 0;
        var selectedObjective = (OmniObjective)listBoxObjectives.SelectedItem!;
        RefreshObjectiveData(selectedObjective);
    }

    private void RefreshObjectiveDataEvent(object? sender, EventArgs e)
    {
        _RefreshObjective();
    }

    private void _RefreshObjective()
    {
        // it could be null, validate its not.
        if (listBoxObjectives.SelectedItem is not OmniObjective selectedObjective) return;

        RefreshObjectiveData(selectedObjective);
    }

    private void RefreshObjectiveData(OmniObjective selectedObjective)
    {
        textBoxObjectiveDescription.Text = selectedObjective.Description;
        numObjectiveId.Value = selectedObjective.Id;
        checkBoxIsOptional.Checked = selectedObjective.IsOptional;
        checkBoxHiddenByDefault.Checked = selectedObjective.HiddenByDefault;

        var objectiveType = (OmniObjectiveType)selectedObjective.Type;
        comboBoxObjectiveType.SelectedIndex =
            comboBoxObjectiveType.Items.FindIndex<OmniObjectiveType>(type => type.Equals(objectiveType));

        textBoxLogInactive.Text = selectedObjective.Logs.Inactive;
        textBoxLogActive.Text = selectedObjective.Logs.Active;
        textBoxLogCompleted.Text = selectedObjective.Logs.Completed;
        textBoxLogFailed.Text = selectedObjective.Logs.Failed;
        textBoxLogMissed.Text = selectedObjective.Logs.Missed;

        RefreshFulfillmentData(selectedObjective);
    }

    private void RefreshFulfillmentData(OmniObjective selectedObjective)
    {
        var objectiveType = (OmniObjectiveType)selectedObjective.Type;
        switch (objectiveType)
        {
            case OmniObjectiveType.Indiscriminate:
                ToggleIndiscriminateDataControls(true);
                
                RefreshIndiscriminateDataControls(selectedObjective);
                
                ToggleDestinationDataControls(false);
                ToggleFetchDataControls(false);
                ToggleSlayDataControls(false);
                ToggleQuestDataControls(false);
                break;
            case OmniObjectiveType.Destination:
                ToggleDestinationDataControls(true);
                
                RefreshDestinationDataControls(selectedObjective);
                
                ToggleIndiscriminateDataControls(false);
                ToggleFetchDataControls(false);
                ToggleSlayDataControls(false);
                ToggleQuestDataControls(false);
                break;
            case OmniObjectiveType.Fetch:
                ToggleFetchDataControls(true);

                RefreshFetchDataControls(selectedObjective);
                
                ToggleIndiscriminateDataControls(false);
                ToggleDestinationDataControls(false);
                ToggleSlayDataControls(false);
                ToggleQuestDataControls(false);
                break;
            case OmniObjectiveType.Slay:
                ToggleSlayDataControls(true);
                
                RefreshSlayDataControls(selectedObjective);
                
                ToggleIndiscriminateDataControls(false);
                ToggleDestinationDataControls(false);
                ToggleFetchDataControls(false);
                ToggleQuestDataControls(false);
                break;
            case OmniObjectiveType.Quest:
                ToggleQuestDataControls(true);
                
                RefreshQuestDataControls(selectedObjective);
                
                ToggleIndiscriminateDataControls(false);
                ToggleDestinationDataControls(false);
                ToggleFetchDataControls(false);
                ToggleSlayDataControls(false);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(OmniObjective.Type));
        }
    }

    private void ToggleIndiscriminateDataControls(bool enabled)
    {
        textBoxIndiscriminateData.Enabled = enabled;
        if (enabled) return;
        
        textBoxIndiscriminateData.Text = string.Empty;
    }

    private void RefreshIndiscriminateDataControls(OmniObjective selectedObjective)
    {
        textBoxIndiscriminateData.Text = selectedObjective.IndiscriminateData;
    }

    private void ToggleDestinationDataControls(bool enabled)
    {
        numDestinationMapId.Enabled = enabled;
        numDestinationX1.Enabled = enabled;
        numDestinationX2.Enabled = enabled;
        numDestinationY1.Enabled = enabled;
        numDestinationY2.Enabled = enabled;
        if (enabled) return;

        // when disabling the controls, also reset them.
        numDestinationMapId.Value = -1;
        numDestinationX1.Value = -1;
        numDestinationY1.Value = -1;
        numDestinationX2.Value = -1;
        numDestinationY2.Value = -1;
    }

    private void RefreshDestinationDataControls(OmniObjective selectedObjective)
    {
        numDestinationMapId.Value = selectedObjective.DestinationMapId;
        numDestinationX1.Value = selectedObjective.DestinationX1;
        numDestinationY1.Value = selectedObjective.DestinationY1;
        numDestinationX2.Value = selectedObjective.DestinationX2;
        numDestinationY2.Value = selectedObjective.DestinationY2;
    }

    private void ToggleFetchDataControls(bool enabled)
    {
        comboBoxFetchType.Enabled = enabled;
        numFetchId.Enabled = enabled;
        numFetchAmount.Enabled = enabled;
        if (enabled) return;

        // when disabling the controls, also reset them.
        comboBoxFetchType.SelectedIndex = -1;
        numFetchId.Value = 0;
        numFetchAmount.Value = 0;
    }

    private void RefreshFetchDataControls(OmniObjective selectedObjective)
    {
        var targetFetchType = selectedObjective.FetchType;
        comboBoxFetchType.SelectedIndex =
            comboBoxFetchType.Items.FindIndex<OmniObjectiveFetchType>(fetchType => fetchType.Equals(targetFetchType));
        numFetchId.Value = selectedObjective.FetchTypeId;
        numFetchAmount.Value = selectedObjective.FetchAmount;
    }

    private void ToggleSlayDataControls(bool enabled)
    {
        numSlayEnemyId.Enabled = enabled;
        numSlayAmount.Enabled = enabled;
        if (enabled) return;
        
        // when disabling the controls, also reset them.
        numSlayEnemyId.Value = 0;
        numSlayAmount.Value = 0;
    }

    private void RefreshSlayDataControls(OmniObjective selectedObjective)
    {
        numSlayEnemyId.Value = selectedObjective.SlayEnemyId;
        numSlayAmount.Value = selectedObjective.SlayAmount;
    }

    private void ToggleQuestDataControls(bool enabled = true)
    {
        textBoxObjectiveQuestData.Enabled = enabled;
        if (enabled) return;

        // when disabling the controls, also reset them.
        textBoxObjectiveQuestData.Text = string.Empty;
    }

    private void RefreshQuestDataControls(OmniObjective selectedObjective)
    {
        textBoxObjectiveQuestData.Text = string.Join(",", selectedObjective.FulfillmentQuestKeys);
    }
    #endregion refresh

    public void Setup(QuestConfiguration questConfiguration)
    {
        // check if we need setup before executing setup.
        if (!_needsSetup) return;

        // populate the list of weapons.
        PopulateQuests(questConfiguration.Quests);
        PopulateCategories(questConfiguration.Categories);
        PopulateTags(questConfiguration.Tags);

        // check if we need to autopick an index.
        if (listBoxQuests.SelectedIndex == -1 && listBoxQuests.Items.Count > 0)
        {
            // set the index to the first item.
            listBoxQuests.SelectedIndex = 0;
        }

        // let this form know we've finished setup.
        _needsSetup = false;
    }

    private void PopulateQuests(List<OmniQuest> quests)
    {
        // empty the list first.
        OmniQuests.Clear();
        listBoxQuests.Items.Clear();

        // assign the list of items locally to the form.
        OmniQuests.AddRange(quests);

        // iterate over each of the entries to add to the list.
        quests.ForEach(quest => listBoxQuests.Items.Add(quest));
    }

    private void PopulateCategories(List<OmniCategory> categories)
    {
        // empty the list first.
        OmniCategories.Clear();
        comboBoxCategory.Items.Clear();

        // assign the list of items locally to the form.
        OmniCategories.AddRange(categories);

        // iterate over each of the entries to add to the list.
        categories.ForEach(category => comboBoxCategory.Items.Add(category));
    }

    private void PopulateTags(List<OmniTag> tags)
    {
        // empty the list first.
        OmniTags.Clear();
        listBoxTags.Items.Clear();

        // assign the list of items locally to the form.
        OmniTags.AddRange(tags);

        // iterate over each of the entries to add to the list.
        tags.ForEach(tag => listBoxTags.Items.Add(tag));
    }
}
﻿using JMZ.Dashboard.Extensions;
using JMZ.Quest.Data;
using JMZ.Quest.Data.Enums;
using JMZ.Quest.Data.Models;

namespace JMZ.Dashboard.Boards;

public partial class QuestBoard : Form
{
    public bool NeedsSetup { get; private set; } = true;

    public List<OmniQuest> OmniQuests { get; } = [];

    public List<OmniCategory> OmniCategories { get; } = [];

    public List<OmniTag> OmniTags { get; } = [];

    private bool ReloadingTags { get; set; } = false;

    public QuestBoard()
    {
        InitializeComponent();

        InitializeDataControls();
        ApplyButtonEvents();
        ApplyUpdateEvents();
    }

    public void TrackedToSaved()
    {
        OmniQuests.Clear();
        OmniCategories.Clear();
        OmniTags.Clear();

        foreach (var quest in listBoxQuests.Items)
        {
            OmniQuests.Add((OmniQuest)quest);
        }

        foreach (var category in listBoxCategories.Items)
        {
            OmniCategories.Add((OmniCategory)category);
        }

        foreach (var tag in listBoxTags.Items)
        {
            OmniTags.Add((OmniTag)tag);
        }
    }

    public void Setup(QuestConfiguration questConfiguration)
    {
        // check if we need setup before executing setup.
        if (!NeedsSetup) return;

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
        NeedsSetup = false;
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
        listBoxCategories.Items.Clear();

        // assign the list of items locally to the form.
        OmniCategories.AddRange(categories);

        // iterate over each of the entries to add to the list.
        categories.ForEach(
            category =>
            {
                comboBoxCategory.Items.Add(category);
                listBoxCategories.Items.Add(category);
            });
    }

    private void PopulateTags(List<OmniTag> tags)
    {
        // empty the list first.
        OmniTags.Clear();
        listBoxTags.Items.Clear();
        checkedListBoxQuestTags.Items.Clear();

        // assign the list of items locally to the form.
        OmniTags.AddRange(tags);

        // iterate over each of the entries to add to the list.
        tags.ForEach(
            tag =>
            {
                listBoxTags.Items.Add(tag);
                checkedListBoxQuestTags.Items.Add(tag);
            });
    }

    private void QuestTabRepopulateCategoriesAndTags(object? sender, EventArgs e)
    {
        RepopulateQuestTabCategories();
        RepopulateQuestTabTags();
    }

    private void RepopulateQuestTabTags()
    {
        checkedListBoxQuestTags.Items.Clear();

        foreach (var tag in listBoxTags.Items)
        {
            checkedListBoxQuestTags.Items.Add(tag);
        }
    }

    private void RepopulateQuestTabCategories()
    {
        comboBoxCategory.Items.Clear();

        foreach (var category in listBoxCategories.Items)
        {
            comboBoxCategory.Items.Add(category);
        }
    }

    #region init
    /// <summary>
    ///     Initializes the data-binding of components to arbitrary values.
    /// </summary>
    private void InitializeDataControls()
    {
        InitializeQuestTabDynamicDataControls();
        InitializeQuestTabStaticDataControls();
        InitializeCategoryTabDynamicDataControls();
        InitializeTagTabDynamicDataControls();

        SetupContextMenus();
    }

    private void InitializeQuestTabDynamicDataControls()
    {
        // dynamic data on quest tab
        listBoxQuests.DisplayMember = nameof(OmniQuest.Name);
        listBoxQuests.ValueMember = nameof(OmniQuest.Key);

        comboBoxCategory.DisplayMember = nameof(OmniCategory.Name);
        comboBoxCategory.ValueMember = nameof(OmniCategory.Key);

        checkedListBoxQuestTags.DisplayMember = nameof(OmniTag.Name);
        checkedListBoxQuestTags.ValueMember = nameof(OmniTag.Key);

        listBoxObjectives.DisplayMember = nameof(OmniObjective.Id);
        listBoxObjectives.ValueMember = nameof(OmniObjective.Id);
    }

    private void InitializeQuestTabStaticDataControls()
    {
        // static data on quest tab
        comboBoxObjectiveType.DisplayMember = nameof(OmniObjective.ObjectiveName);
        comboBoxObjectiveType.ValueMember = nameof(OmniObjective.Type);
        foreach (var enumValue in Enum.GetValues<OmniObjectiveType>())
        {
            comboBoxObjectiveType.Items.Add(enumValue);
        }

        comboBoxFetchType.DisplayMember = nameof(OmniObjective.Fulfillment.Fetch.TypeName);
        comboBoxFetchType.ValueMember = nameof(OmniObjective.Fulfillment.Fetch.Id);
        foreach (var enumValue in Enum.GetValues<OmniObjectiveFetchType>())
        {
            comboBoxFetchType.Items.Add(enumValue);
        }
    }

    private void InitializeCategoryTabDynamicDataControls()
    {
        listBoxCategories.DisplayMember = nameof(OmniCategory.Name);
        listBoxCategories.ValueMember = nameof(OmniCategory.Key);
    }

    private void InitializeTagTabDynamicDataControls()
    {
        listBoxTags.DisplayMember = nameof(OmniTag.Name);
        listBoxTags.ValueMember = nameof(OmniTag.Key);
    }

    private void SetupContextMenus()
    {
        SetupQuestListContextMenu();
        SetupObjectiveListContextMenu();
    }

    private void SetupQuestListContextMenu()
    {
        var contextMenuStrip = new ContextMenuStrip();
        contextMenuStrip.Items.Add("➕⬆️ Add new quest above", null, AddQuestAboveEvent);
        contextMenuStrip.Items.Add("➕⬇️ Add new quest below", null, AddQuestBelowEvent);
        contextMenuStrip.Items.Add(new ToolStripSeparator());
        contextMenuStrip.Items.Add("📄⬆️ Clone quest above", null, CloneQuestAboveEvent);
        contextMenuStrip.Items.Add("📄⬇️ Clone quest below", null, CloneQuestBelowEvent);
        contextMenuStrip.Items.Add(new ToolStripSeparator());
        contextMenuStrip.Items.Add("🗑️ Delete quest", null, DeleteQuestEvent);
        
        listBoxQuests.ContextMenuStrip  = contextMenuStrip;
    }

    private void SetupObjectiveListContextMenu()
    {
        var contextMenuStrip = new ContextMenuStrip();
        contextMenuStrip.Items.Add("➕⬆️ Add new objective above", null, AddObjectiveAboveEvent);
        contextMenuStrip.Items.Add("➕⬇️ Add new objective below", null, AddObjectiveBelowEvent);
        contextMenuStrip.Items.Add(new ToolStripSeparator());
        contextMenuStrip.Items.Add("📄⬆️ Clone objective above", null, CloneObjectiveAboveEvent);
        contextMenuStrip.Items.Add("📄⬇️ Clone objective below", null, CloneObjectiveBelowEvent);
        contextMenuStrip.Items.Add(new ToolStripSeparator());
        contextMenuStrip.Items.Add("🗑️ Delete objective", null, DeleteObjectiveEvent);
        
        listBoxObjectives.ContextMenuStrip  = contextMenuStrip;
    }

    private void ApplyButtonEvents()
    {
        buttonAddCategory.Click += ButtonAddCategoryEvent;
        buttonDeleteCategory.Click += ButtonDeleteCategoryEvent;

        buttonAddTag.Click += ButtonAddTagEvent;
        buttonDeleteTag.Click += ButtonDeleteTagEvent;

        tabQuest.Enter += QuestTabRepopulateCategoriesAndTags;
    }

    private void AddQuestAboveEvent(object? sender, EventArgs e)
    {
        // define the new quest.
        var newQuest = OmniQuest.DefaultTemplate();

        // determine the index for the new quest.
        var selectedIndex = listBoxQuests.GetIndexAbove();

        // add it at the given index.
        listBoxQuests.Items.Insert(selectedIndex, newQuest);
    }
    
    private void AddQuestBelowEvent(object? sender, EventArgs e)
    {
        // define the new quest.
        var newQuest = OmniQuest.DefaultTemplate();

        // determine the index for the new quest.
        var selectedIndex = listBoxQuests.GetIndexBelow();

        // add it at the given index.
        listBoxQuests.Items.Insert(selectedIndex, newQuest);
    }
    
    private void CloneQuestAboveEvent(object? sender, EventArgs e)
    {
        // determine the quest to clone.
        if (listBoxQuests.SelectedItem is not OmniQuest targetQuest) return;
        
        // clone the quest.
        var clonedQuest = OmniQuest.From(targetQuest);

        // determine the index for the new objective.
        var targetIndex = listBoxQuests.GetIndexAbove();

        // add it at the given index.
        listBoxQuests.Items.Insert(targetIndex, clonedQuest);
    }

    private void CloneQuestBelowEvent(object? sender, EventArgs e)
    {
        // determine the quest to clone.
        if (listBoxQuests.SelectedItem is not OmniQuest targetQuest) return;
        
        // clone the quest.
        var clonedQuest = OmniQuest.From(targetQuest);

        // grab the current selection's index.
        var targetIndex = listBoxQuests.GetIndexBelow();

        // add it at the given index.
        listBoxQuests.Items.Insert(targetIndex, clonedQuest);
    }

    private void DeleteQuestEvent(object? sender, EventArgs e)
    {
        // determine the quest to clone.
        if (listBoxQuests.SelectedItem is not OmniQuest targetQuest) return;

        // determine the index for the new objective.
        var removalIndex = listBoxQuests.SelectedIndex;

        // check if there is no index selected right now.
        if (removalIndex == -1) return;

        // define the prompt.
        var removalPrompt = $"Are you sure you want to remove the selected quest, [{targetQuest.Name}]?";

        // show the box with the prompt.
        var dialogResult = MessageBox.Show(removalPrompt, "Removing a quest", MessageBoxButtons.OKCancel);

        // pivot on the user decisions.
        switch (dialogResult)
        {
            case DialogResult.OK:
                listBoxQuests.Items.RemoveAt(removalIndex);
                if (listBoxQuests.Items.Count != 0)
                {
                    listBoxQuests.SelectedIndex = Math.Max(-1, removalIndex - 1);
                }

                break;
            case DialogResult.Cancel:
                break;
        }
    }
    
    private void AddObjectiveAboveEvent(object? sender, EventArgs e)
    {
        // determine the quest to clone.
        if (listBoxQuests.SelectedItem is not OmniQuest omniQuest) return;

        // determine the index for the new objective.
        var targetIndex = listBoxObjectives.GetIndexAbove();

        // define the new objective.
        var newObjective = OmniObjective.DefaultTemplate();
        newObjective.Id = targetIndex;

        // add it at the given index.
        omniQuest.Objectives.Insert(targetIndex, newObjective);
        listBoxObjectives.Items.Insert(targetIndex, newObjective);
    }
    
    private void AddObjectiveBelowEvent(object? sender, EventArgs e)
    {
        // determine the quest to clone.
        if (listBoxQuests.SelectedItem is not OmniQuest omniQuest) return;

        // determine the index for the new objective.
        var targetIndex = listBoxObjectives.GetIndexBelow();

        // define the new objective.
        var newObjective = OmniObjective.DefaultTemplate();
        newObjective.Id = targetIndex;

        // add it at the given index.
        omniQuest.Objectives.Insert(targetIndex, newObjective);
        listBoxObjectives.Items.Insert(targetIndex, newObjective);
    }
    
    private void CloneObjectiveAboveEvent(object? sender, EventArgs e)
    {
        // determine the quest being worked with.
        if (listBoxQuests.SelectedItem is not OmniQuest omniQuest) return;

        // determine the index for the new objective.
        var targetIndex = listBoxObjectives.GetIndexAbove();
        
        // determine the objective to clone.
        if (listBoxObjectives.SelectedItem is not OmniObjective targetObjective) return;
        
        // define the new objective.
        var clonedObjective = OmniObjective.From(targetObjective);
        clonedObjective.Id = targetIndex;

        // add it at the given index.
        omniQuest.Objectives.Insert(targetIndex, clonedObjective);
        listBoxObjectives.Items.Insert(targetIndex, clonedObjective);
    }
    
    private void CloneObjectiveBelowEvent(object? sender, EventArgs e)
    {
        // determine the quest being worked with.
        if (listBoxQuests.SelectedItem is not OmniQuest omniQuest) return;

        // determine the index for the new objective.
        var targetIndex = listBoxObjectives.GetIndexBelow();
        
        // determine the objective to clone.
        if (listBoxObjectives.SelectedItem is not OmniObjective targetObjective) return;
        
        // define the new objective.
        var clonedObjective = OmniObjective.From(targetObjective);
        clonedObjective.Id = targetIndex;

        // add it at the given index.
        omniQuest.Objectives.Insert(targetIndex, clonedObjective);
        listBoxObjectives.Items.Insert(targetIndex, clonedObjective);
    }

    private void DeleteObjectiveEvent(object? sender, EventArgs e)
    {
        // determine the quest being worked with.
        if (listBoxQuests.SelectedItem is not OmniQuest omniQuest) return;

        // determine the index for the new objective.
        var removalIndex = listBoxObjectives.SelectedIndex;

        // check if there is no index selected right now.
        if (removalIndex == -1) return;

        // determine the objective to delete.
        if (listBoxObjectives.SelectedItem is not OmniObjective targetObjective) return;

        // define the prompt.
        var removalPrompt = $"Are you sure you want to remove the selected objective, [{targetObjective.ObjectiveName}]?";

        // show the box with the prompt.
        var dialogResult = MessageBox.Show(removalPrompt, "Removing an objective", MessageBoxButtons.OKCancel);

        // pivot on the user decisions.
        switch (dialogResult)
        {
            case DialogResult.OK:
                omniQuest.Objectives.Remove(targetObjective);
                listBoxObjectives.Items.RemoveAt(removalIndex);
                if (listBoxObjectives.Items.Count != 0)
                {
                    listBoxObjectives.SelectedIndex = 0;
                }

                break;
            case DialogResult.Cancel:
                break;
        }
    }

    private void ButtonAddCategoryEvent(object? sender, EventArgs e)
    {
        // define the new entry.
        var newCategory = OmniCategory.DefaultTemplate();

        // determine the index for the new entry.
        var selectedIndex = listBoxCategories.SelectedIndex;

        // check if there was no current selection.
        if (selectedIndex == -1 || selectedIndex == listBoxCategories.Items.Count - 1)
        {
            // add the item to the list without regard for index.
            listBoxCategories.Items.Add(newCategory);
        }
        // the index selected is valid.
        else
        {
            // add it at the given index.
            listBoxCategories.Items.Insert(selectedIndex, newCategory);
        }
    }

    private void ButtonDeleteCategoryEvent(object? sender, EventArgs e)
    {
        // determine the selected entry.
        var selectedItem = (OmniCategory?)listBoxCategories.SelectedItem;

        // do not proceed if there is no entry selected.
        if (selectedItem is null) return;

        // determine the index for the new entry.
        var removalIndex = listBoxCategories.SelectedIndex;

        // check if there is no index selected right now.
        if (removalIndex == -1) return;

        // define the prompt.
        var removalPrompt = $"Are you sure you want to remove the selected category, [{selectedItem.Name}]?";

        // show the box with the prompt.
        var dialogResult = MessageBox.Show(removalPrompt, "Removing a category", MessageBoxButtons.OKCancel);

        // pivot on the user decisions.
        switch (dialogResult)
        {
            case DialogResult.OK:
                listBoxCategories.Items.RemoveAt(removalIndex);
                if (listBoxCategories.Items.Count != 0)
                {
                    listBoxCategories.SelectedIndex = Math.Max(-1, removalIndex - 1);
                }

                break;
            case DialogResult.Cancel:
                break;
        }
    }

    private void ButtonAddTagEvent(object? sender, EventArgs e)
    {
        // define the new entry.
        var newTag = OmniTag.DefaultTemplate();

        // determine the index for the new entry.
        var selectedIndex = listBoxTags.SelectedIndex;

        // check if there was no current selection.
        if (selectedIndex == -1 || selectedIndex == listBoxTags.Items.Count - 1)
        {
            // add the item to the list without regard for index.
            listBoxTags.Items.Add(newTag);
        }
        // the index selected is valid.
        else
        {
            // add it at the given index.
            listBoxTags.Items.Insert(selectedIndex, newTag);
        }
    }

    private void ButtonDeleteTagEvent(object? sender, EventArgs e)
    {
        // determine the selected entry.
        var selectedItem = (OmniTag?)listBoxTags.SelectedItem;

        // do not proceed if there is no entry selected.
        if (selectedItem is null) return;

        // determine the index for the new entry.
        var removalIndex = listBoxTags.SelectedIndex;

        // check if there is no index selected right now.
        if (removalIndex == -1) return;

        // define the prompt.
        var removalPrompt = $"Are you sure you want to remove the selected tag, [{selectedItem.Name}]?";

        // show the box with the prompt.
        var dialogResult = MessageBox.Show(removalPrompt, "Removing a tag", MessageBoxButtons.OKCancel);

        // pivot on the user decisions.
        switch (dialogResult)
        {
            case DialogResult.OK:
                listBoxTags.Items.RemoveAt(removalIndex);
                if (listBoxTags.Items.Count != 0)
                {
                    listBoxTags.SelectedIndex = Math.Max(-1, removalIndex - 1);
                }

                break;
            case DialogResult.Cancel:
                break;
        }
    }

    private void ApplyUpdateEvents()
    {
        ApplyQuestTabEvents();
        ApplyCategoryTabEvents();
        ApplyTagTabEvents();
    }

    private void ApplyQuestTabEvents()
    {
        listBoxQuests.SelectedIndexChanged += RefreshQuestTabEvent;
        listBoxObjectives.SelectedIndexChanged += ReloadObjectiveEvent;
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

        // a hacky approach to updating AFTER an item is checked rather than BEFORE.
        checkedListBoxQuestTags.ItemCheck += (sender, eventArgs) =>
        {
            // required when the form is initially loaded because winforms is stupid.
            if (IsHandleCreated)
            {
                // async execution with a delay that is JUST ENOUGH to happen after the check.
                BeginInvoke((MethodInvoker)(() => UpdateQuestTagKeys(sender, eventArgs)));
            }

        };
    }

    private void ApplyUpdateEventsForObjectiveData()
    {
        // common data.
        numObjectiveId.ValueChanged += UpdateObjectiveId;
        checkBoxHiddenByDefault.CheckedChanged += UpdateObjectiveHiddenByDefault;
        checkBoxIsOptional.CheckedChanged += UpdateObjectiveIsOptional;
        textBoxObjectiveDescription.TextChanged += UpdateObjectiveDescription;

        // logs.
        textBoxLogInactive.TextChanged += UpdateObjectiveLogsInactive;
        textBoxLogActive.TextChanged += UpdateObjectiveLogsActive;
        textBoxLogCompleted.TextChanged += UpdateObjectiveLogsCompleted;
        textBoxLogFailed.TextChanged += UpdateObjectiveLogsFailed;
        textBoxLogMissed.TextChanged += UpdateObjectiveLogsMissed;

        comboBoxObjectiveType.SelectedIndexChanged += UpdateObjectiveType;

        // indiscriminate data.
        textBoxIndiscriminateData.TextChanged += UpdateObjectiveIndiscriminateData;

        // destination data.
        numDestinationMapId.ValueChanged += UpdateObjectiveDestinationMapId;
        numDestinationX1.ValueChanged += UpdateObjectiveDestinationX1;
        numDestinationY1.ValueChanged += UpdateObjectiveDestinationY1;
        numDestinationX2.ValueChanged += UpdateObjectiveDestinationX2;
        numDestinationY2.ValueChanged += UpdateObjectiveDestinationY2;

        // fetch data.
        comboBoxFetchType.SelectedIndexChanged += UpdateObjectiveFetchType;
        numFetchId.ValueChanged += UpdateObjectiveFetchId;
        numFetchAmount.ValueChanged += UpdateObjectiveFetchAmount;

        // slay data.
        numSlayEnemyId.ValueChanged += UpdateObjectiveSlayId;
        numSlayAmount.ValueChanged += UpdateObjectiveSlayAmount;

        // quest data.
        textBoxObjectiveQuestData.TextChanged += UpdateObjectiveQuestKeys;
    }

    private void ApplyCategoryTabEvents()
    {
        listBoxCategories.SelectedIndexChanged += RefreshCategoryTabEvent;
        textBoxCategoryKey.TextChanged += UpdateCategoryKey;
        textBoxCategoryName.TextChanged += UpdateCategoryName;
        numCategoryIconIndex.ValueChanged += UpdateCategoryIconIndex;
    }

    private void ApplyTagTabEvents()
    {
        listBoxTags.SelectedIndexChanged += RefreshTagTabEvent;
        textBoxTagKey.TextChanged += UpdateTagKey;
        textBoxTagName.TextChanged += UpdateTagName;
        numTagIconIndex.ValueChanged += UpdateTagIconIndex;
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

        // update the list to reflect the new display data.
        listBoxQuests.Items[listBoxQuests.SelectedIndex] = item;
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
        var item = (OmniQuest?)listBoxQuests.SelectedItem;

        // don't update if it was null.
        if (item is null) return;

        // determine the new value.
        var updatedCategoryKey = (OmniCategory?)comboBoxCategory.SelectedItem;

        // don't update if it was null.
        if (updatedCategoryKey is null) return;

        // update with the new value.
        item.CategoryKey = updatedCategoryKey.Key;
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

    private void UpdateQuestTagKeys(object? sender, EventArgs e)
    {
        // no updating the data model while reloading tags.
        if (ReloadingTags) return;

        // determine the selected item.
        var item = (OmniQuest)listBoxQuests.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new tag keys.
        var questTagKeys = checkedListBoxQuestTags.CheckedItems
            .Cast<OmniTag>()
            .Select(tag => tag.Key)
            .ToList();

        // update with the new value.
        item.TagKeys = questTagKeys;
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

        // update the list to reflect the new display data.
        listBoxObjectives.Items[listBoxObjectives.SelectedIndex] = item;
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
        item.Type = objectiveType;

        RefreshFulfillmentData(item);
    }

    private void UpdateObjectiveIndiscriminateData(object? sender, EventArgs e)
    {
        if (((Control)sender!).Enabled is false) return;

        // determine the selected item.
        var item = (OmniObjective)listBoxObjectives.SelectedItem!;

        // update with the new value.
        item.Fulfillment.Indiscriminate.Hint = textBoxIndiscriminateData.Text;
    }

    private void UpdateObjectiveDestinationMapId(object? sender, EventArgs e)
    {
        if (((Control)sender!).Enabled is false) return;

        // determine the selected item.
        var item = (OmniObjective)listBoxObjectives.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // update with the new value.
        item.Fulfillment.Destination.MapId = (int)numDestinationMapId.Value;
    }

    private void UpdateObjectiveDestinationX1(object? sender, EventArgs e)
    {
        if (((Control)sender!).Enabled is false) return;

        // determine the selected item.
        var item = (OmniObjective)listBoxObjectives.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // update with the new value.
        item.Fulfillment.Destination.X1 = (int)numDestinationX1.Value;
    }

    private void UpdateObjectiveDestinationY1(object? sender, EventArgs e)
    {
        if (((Control)sender!).Enabled is false) return;

        // determine the selected item.
        var item = (OmniObjective)listBoxObjectives.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // update with the new value.
        item.Fulfillment.Destination.Y1 = (int)numDestinationY1.Value;
    }

    private void UpdateObjectiveDestinationX2(object? sender, EventArgs e)
    {
        if (((Control)sender!).Enabled is false) return;

        // determine the selected item.
        var item = (OmniObjective)listBoxObjectives.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // update with the new value.
        item.Fulfillment.Destination.X2 = (int)numDestinationX2.Value;
    }

    private void UpdateObjectiveDestinationY2(object? sender, EventArgs e)
    {
        if (((Control)sender!).Enabled is false) return;

        // determine the selected item.
        var item = (OmniObjective)listBoxObjectives.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // update with the new value.
        item.Fulfillment.Destination.Y2 = (int)numDestinationY2.Value;
    }

    private void UpdateObjectiveFetchType(object? sender, EventArgs e)
    {
        if (groupBoxFetchData.Visible is false) return;

        // determine the selected item.
        var item = (OmniObjective)listBoxObjectives.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // update with the new value.
        item.Fulfillment.Fetch.Type = (OmniObjectiveFetchType)comboBoxFetchType.SelectedItem!;
    }

    private void UpdateObjectiveFetchId(object? sender, EventArgs e)
    {
        if (groupBoxFetchData.Visible is false) return;

        // determine the selected item.
        var item = (OmniObjective)listBoxObjectives.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // update with the new value.
        item.Fulfillment.Fetch.Id = (int)numFetchId.Value;
    }

    private void UpdateObjectiveFetchAmount(object? sender, EventArgs e)
    {
        if (groupBoxFetchData.Visible is false) return;

        // determine the selected item.
        var item = (OmniObjective)listBoxObjectives.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // update with the new value.
        item.Fulfillment.Fetch.Amount = (int)numFetchAmount.Value;
    }

    private void UpdateObjectiveSlayId(object? sender, EventArgs e)
    {
        if (groupBoxSlayData.Enabled is false) return;

        // determine the selected item.
        var item = (OmniObjective)listBoxObjectives.SelectedItem!;

        if (item is null) return;

        // update with the new value.
        item.Fulfillment.Slay.Id = (int)numSlayEnemyId.Value;
    }

    private void UpdateObjectiveSlayAmount(object? sender, EventArgs e)
    {
        if (groupBoxSlayData.Enabled is false) return;

        // determine the selected item.
        var item = (OmniObjective)listBoxObjectives.SelectedItem!;

        if (item is null) return;

        // update with the new value.
        item.Fulfillment.Slay.Amount = (int)numSlayAmount.Value;
    }

    private void UpdateObjectiveQuestKeys(object? sender, EventArgs e)
    {
        if (((Control)sender!).Enabled is false) return;

        // determine the selected item.
        var item = (OmniObjective)listBoxObjectives.SelectedItem!;

        // update with the new value.
        item.Fulfillment.Quest.Keys = textBoxObjectiveQuestData.Text
            .Split(',')
            .ToList();
    }
    #endregion objective

    #region categories
    private void UpdateCategoryKey(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (OmniCategory)listBoxCategories.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // update with the new value.
        item.Key = textBoxCategoryKey.Text;
    }

    private void UpdateCategoryName(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (OmniCategory)listBoxCategories.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // update with the new value.
        item.Name = textBoxCategoryName.Text;

        // update the list to reflect the new display data.
        listBoxCategories.Items[listBoxCategories.SelectedIndex] = item;
    }

    private void UpdateCategoryIconIndex(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (OmniCategory)listBoxCategories.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // update with the new value.
        item.IconIndex = (int)numCategoryIconIndex.Value;
    }
    #endregion categories

    #region tags
    private void UpdateTagKey(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (OmniTag)listBoxTags.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // update with the new value.
        item.Key = textBoxTagKey.Text;
    }

    private void UpdateTagName(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (OmniTag)listBoxTags.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // update with the new value.
        item.Name = textBoxTagName.Text;

        // update the list to reflect the new display data.
        listBoxTags.Items[listBoxTags.SelectedIndex] = item;
    }

    private void UpdateTagIconIndex(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (OmniTag)listBoxTags.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // update with the new value.
        item.IconIndex = (int)numTagIconIndex.Value;
    }
    #endregion tags
    #endregion update

    #region refresh
    #region quest tab
    private void RefreshQuestTabEvent(object? sender, EventArgs e)
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
        numRecommendedLevel.Value = selectedItem.RecommendedLevel;

        var categoryIndex =
            comboBoxCategory.Items.FindIndex<OmniCategory>(category => category.Key == selectedItem.CategoryKey);
        comboBoxCategory.SelectedIndex = categoryIndex;

        RefreshQuestTags(selectedItem);
    }

    private void RefreshQuestTags(OmniQuest selectedItem)
    {
        // flag to notify that we're reloading the tags and shouldn't update the data model.
        ReloadingTags = true;

        // uncheck all the quest tags.
        foreach (int checkedIndex in checkedListBoxQuestTags.CheckedIndices)
        {
            checkedListBoxQuestTags.SetItemChecked(checkedIndex, false);
        }

        // check all the data model's quest tags.
        foreach (var tagKey in selectedItem.TagKeys)
        {
            var index = checkedListBoxQuestTags.Items.FindIndex<OmniTag>(tag => tag.Key == tagKey);
            checkedListBoxQuestTags.SetItemChecked(index, true);
        }

        // flag to notify that we're done reloading tags.
        ReloadingTags = false;
    }

    private void RefreshObjectivesData(OmniQuest selectedItem)
    {
        listBoxObjectives.Items.Clear();

        var objectives = selectedItem.Objectives;

        if (!objectives.Any())
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
        ReloadObjectiveData(selectedObjective);
    }

    private void ReloadObjectiveEvent(object? sender, EventArgs e)
    {
        ReloadObjective();
    }

    private void ReloadObjective()
    {
        // it could be null, validate its not.
        if (listBoxObjectives.SelectedItem is not OmniObjective selectedObjective) return;

        ReloadObjectiveData(selectedObjective);
    }

    private void ReloadObjectiveData(OmniObjective selectedObjective)
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
                ToggleQuestDataControls();

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
        groupBoxIndiscriminateData.Visible = enabled;
    }

    private void RefreshIndiscriminateDataControls(OmniObjective selectedObjective)
    {
        textBoxIndiscriminateData.Text = selectedObjective.Fulfillment.Indiscriminate.Hint;
    }

    private void ToggleDestinationDataControls(bool enabled)
    {
        groupBoxDestinationData.Visible = enabled;
    }

    private void RefreshDestinationDataControls(OmniObjective selectedObjective)
    {
        if (selectedObjective is null) return;

        numDestinationMapId.Value = selectedObjective.Fulfillment.Destination.MapId;
        numDestinationX1.Value = selectedObjective.Fulfillment.Destination.X1;
        numDestinationY1.Value = selectedObjective.Fulfillment.Destination.Y1;
        numDestinationX2.Value = selectedObjective.Fulfillment.Destination.X2;
        numDestinationY2.Value = selectedObjective.Fulfillment.Destination.Y2;
    }

    private void ToggleFetchDataControls(bool enabled)
    {
        groupBoxFetchData.Visible = enabled;
    }

    private void RefreshFetchDataControls(OmniObjective selectedObjective)
    {
        if (selectedObjective is null) return;

        numFetchId.Value = selectedObjective.Fulfillment.Fetch.Id;
        numFetchAmount.Value = selectedObjective.Fulfillment.Fetch.Amount;

        var targetFetchType = selectedObjective.Fulfillment.Fetch.Type;
        comboBoxFetchType.SelectedIndex =
            comboBoxFetchType.Items.FindIndex<OmniObjectiveFetchType>(fetchType => fetchType.Equals(targetFetchType));
    }

    private void ToggleSlayDataControls(bool enabled)
    {
        groupBoxSlayData.Visible = enabled;
        // numSlayEnemyId.Visible = enabled;
        // numSlayAmount.Visible = enabled;
    }

    private void RefreshSlayDataControls(OmniObjective selectedObjective)
    {
        if (selectedObjective is null) return;

        numSlayEnemyId.Value = selectedObjective.Fulfillment.Slay.Id;
        numSlayAmount.Value = selectedObjective.Fulfillment.Slay.Amount;
    }

    private void ToggleQuestDataControls(bool enabled = true)
    {
        textBoxObjectiveQuestData.Visible = enabled;
    }

    private void RefreshQuestDataControls(OmniObjective selectedObjective)
    {
        if (selectedObjective is null) return;

        textBoxObjectiveQuestData.Text = string.Join(",", selectedObjective.Fulfillment.Quest.Keys);
    }
    #endregion quest tab

    #region category tab
    private void RefreshCategoryTabEvent(object? sender, EventArgs e)
    {
        RefreshCategoryTab();
    }

    private void RefreshCategoryTab()
    {
        var selectedItem = (OmniCategory?)listBoxCategories.SelectedItem;
        if (selectedItem is null) return;

        textBoxCategoryKey.Text = selectedItem.Key;
        textBoxCategoryName.Text = selectedItem.Name;
        numCategoryIconIndex.Value = selectedItem.IconIndex;
    }
    #endregion category tab

    #region tag tab
    private void RefreshTagTabEvent(object? sender, EventArgs e)
    {
        RefreshTagTab();
    }

    private void RefreshTagTab()
    {
        var selectedItem = (OmniTag?)listBoxTags.SelectedItem;
        if (selectedItem is null) return;

        textBoxTagKey.Text = selectedItem.Key;
        textBoxTagName.Text = selectedItem.Name;
        numTagIconIndex.Value = selectedItem.IconIndex;
    }
    #endregion tag tab
    #endregion refresh
}
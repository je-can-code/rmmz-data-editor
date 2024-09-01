using JMZ.Extend.Data.Extensions.implementations._Skill;
using JMZ.JABS.Data.Extensions.implementations._Skill.ComboData;
using JMZ.JABS.Data.Extensions.implementations._Skill.CoreData;
using JMZ.JABS.Data.Extensions.implementations._Skill.MapData;
using JMZ.JABS.Data.Extensions.implementations._Skill.PiercingData;
using JMZ.JABS.Data.Extensions.implementations._Skill.PoseData;
using JMZ.JABS.Data.Extensions.implementations._Skill.TargetingData;
using JMZ.JABS.Data.Extensions.implementations._Skill.UsageData;
using JMZ.JABS.Data.Models;
using JMZ.Rmmz.Data.Models.db.implementations;

namespace JMZ.Dashboard.Boards;

public partial class SkillsBoard : Form
{
    private ToolTip _toolTip = new();

    /// <summary>
    /// The running list of parsed data including any edits made by the user.
    /// </summary>
    private List<RPG_Skill> skillsList = [];

    /// <summary>
    /// Whether or not this form needs setup.
    /// </summary>
    private bool needsSetup = true;

    /// <summary>
    /// Constructor.
    /// </summary>
    public SkillsBoard()
    {
        // default initialization.
        InitializeComponent();

        InitializeDataControls();
        InitializeTooltips();
        ApplyUpdateEvents();
    }

    /// <summary>
    /// Initializes the data-binding of components to arbitrary values.
    /// </summary>
    private void InitializeDataControls()
    {
        // setup the main list box of skills.
        listboxSkills.DisplayMember = "name";
        listboxSkills.ValueMember = "id";
        comboBox_hitbox.DataSource = Enum.GetValues(typeof(Hitbox));
    }

    private void InitializeTooltips()
    {
        _toolTip = new();
        _toolTip.AutoPopDelay = 5000;
        _toolTip.InitialDelay = 1000;
        _toolTip.ReshowDelay = 500;
        _toolTip.ToolTipIcon = ToolTipIcon.Info;
        _toolTip.ToolTipTitle = "Details and Usage";

        _toolTip.SetToolTip(num_radius, Tags.Radius.Description);
        _toolTip.SetToolTip(num_proximity, Tags.Proximity.Description);
        _toolTip.SetToolTip(comboBox_hitbox, Tags.Hitbox.Description);

        _toolTip.SetToolTip(num_comboSkill, Tags.Combo.Descriptions[0]);
        _toolTip.SetToolTip(num_comboDelay, Tags.Combo.Descriptions[1]);
        _toolTip.SetToolTip(checkBox_comboStarter, Tags.AiComboStarter.Description);
        _toolTip.SetToolTip(checkBox_freeCombo, Tags.FreeCombo.Description);

        _toolTip.SetToolTip(num_piercingCount, Tags.Pierce.Description);
        _toolTip.SetToolTip(num_piercingDelay, Tags.Pierce.Description);

        _toolTip.SetToolTip(num_actionId, Tags.ActionId.Description);
        _toolTip.SetToolTip(num_duration, Tags.Duration.Description);

        _toolTip.SetToolTip(num_cooldown, Tags.Cooldown.Description);
        _toolTip.SetToolTip(num_castAnimation, Tags.CastAnimation.Description);

        _toolTip.SetToolTip(textBox_poseSuffix, Tags.Pose.Description);
        _toolTip.SetToolTip(num_poseIndex, Tags.Pose.Description);
        _toolTip.SetToolTip(num_poseDuration, Tags.Pose.Description);
    }

    /// <summary>
    /// Binds the update of the various controls across this form.
    /// </summary>
    private void ApplyUpdateEvents()
    {
        ApplyUpdateEventsForBasicData();
        ApplyUpdateEventsForTargetingData();
        ApplyUpdateEventsForMapData();
        ApplyUpdateEventsForUsageData();
        ApplyUpdateEventsForComboData();
        ApplyUpdateEventsForPiercingData();
        ApplyUpdateEventsForPoseData();

        listboxSkills.SelectedValueChanged += RefreshForm;
    }

    private void ApplyUpdateEventsForBasicData()
    {
        // update basic data.
        textBox_skillName.TextChanged += UpdateSkillName;
        textBox_skillExtend.TextChanged += UpdateSkillExtend;
        checkBox_hideFromJabsMenu.CheckedChanged += UpdateQuickMenuVisibility;
    }

    private void ApplyUpdateEventsForTargetingData()
    {
        // update targeting data.
        checkBox_direct.CheckedChanged += UpdateDirectTargeting;
        num_proximity.ValueChanged += UpdateProximity;
        num_radius.ValueChanged += UpdateRadius;
        comboBox_hitbox.SelectedIndexChanged += UpdateHitbox;
    }

    private void ApplyUpdateEventsForMapData()
    {
        // update map data.
        num_actionId.ValueChanged += UpdateActionId;
        num_duration.ValueChanged += UpdateDuration;
    }

    private void ApplyUpdateEventsForUsageData()
    {
        // update usage data.
        num_cooldown.ValueChanged += UpdateCooldown;
        num_castAnimation.ValueChanged += UpdateCastAnimation;
        num_castTime.ValueChanged += UpdateCastTime;
        checkBox_canGapClose.CheckedChanged += UpdateCanGapClose;
    }

    private void ApplyUpdateEventsForComboData()
    {
        // update combo data.
        num_comboDelay.ValueChanged += UpdateComboData;
        num_comboSkill.ValueChanged += UpdateComboData;
        checkBox_freeCombo.CheckedChanged += UpdateFreeCombo;
        checkBox_comboStarter.CheckedChanged += UpdateAiComboStarter;
        checkBox_aiSkillExclude.CheckedChanged += UpdateAiSkillExclusion;
    }

    private void ApplyUpdateEventsForPiercingData()
    {
        // update piercing data.
        num_piercingCount.ValueChanged += UpdatePiercingData;
        num_piercingDelay.ValueChanged += UpdatePiercingData;
    }

    private void ApplyUpdateEventsForPoseData()
    {
        // update pose data.
        textBox_poseSuffix.TextChanged += UpdatePoseData;
        num_poseIndex.ValueChanged += UpdatePoseData;
        num_poseDuration.ValueChanged += UpdatePoseData;
    }

    /// <summary>
    /// Gets the current state of skills.
    /// </summary>
    /// <returns>The skill data including any edits.</returns>
    public List<RPG_Skill> Skills()
    {
        return skillsList;
    }

    #region updates

    /// <summary>
    /// Gets the currently selected item and also the index of that item.
    /// </summary>
    /// <returns>A pair of skill and its index in the list of skills.</returns>
    private (RPG_Skill skill, int index) GetSkillSelection()
    {
        // determine the selected skill.
        var selectedItem = (RPG_Skill)listboxSkills.SelectedItem!;

        // find the index of the selected skill in our local list.
        var index = skillsList.FindIndex(data => data != null && data.id == selectedItem.id);

        // return both data points.
        return new(selectedItem, index);
    }

    /// <summary>
    /// Updates the 
    /// </summary>
    /// <param name="skill"></param>
    /// <param name="index"></param>
    private void UpdateSkillData(RPG_Skill skill, int index)
    {
        // update the backed skill data with this new data.
        listboxSkills.Items[index - 1] = skill;
    }

    private void UpdateQuickMenuVisibility(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (skill, index) = GetSkillSelection();

        // update the underlying data.
        skill.UpdateJabsHideFromQuickMenu(checkBox_hideFromJabsMenu.Checked);

        // update the running list.
        UpdateSkillData(skill, index);
    }

    private void UpdateSkillExtend(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (skill, index) = GetSkillSelection();

        // grab the current data.
        var extensions = textBox_skillExtend.Text;

        // update the underlying data.
        skill.UpdateSkillExtendIds(extensions);

        // update the running list.
        UpdateSkillData(skill, index);
    }

    private void UpdatePoseData(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (skill, index) = GetSkillSelection();

        // grab the current pose suffix.
        var poseSuffix = textBox_poseSuffix.Text;

        // grab the current pose index.
        var poseIndex = num_poseIndex.Value;

        // grab the current pose duration.
        var poseDuration = num_poseDuration.Value;

        // update the underlying data.
        skill.UpdateJabsPoseData(poseSuffix, poseIndex, poseDuration);

        // update the running list.
        UpdateSkillData(skill, index);
    }

    private void UpdatePiercingData(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (skill, index) = GetSkillSelection();

        // grab the current piercing count.
        var piercingCount = num_piercingCount.Value;

        // grab the current piercing delay.
        var piercingDelay = num_piercingDelay.Value;

        // update the underlying note.
        skill.UpdateJabsPiercingData(piercingCount, piercingDelay);

        // update the running list.
        UpdateSkillData(skill, index);
    }

    private void UpdateFreeCombo(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (skill, index) = GetSkillSelection();

        // update the underlying data.
        skill.UpdateJabsFreeCombo(checkBox_freeCombo.Checked);

        // update the running list.
        UpdateSkillData(skill, index);
    }

    private void UpdateAiComboStarter(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (skill, index) = GetSkillSelection();

        // update the underlying data.
        skill.UpdateJabsAiComboStarter(checkBox_comboStarter.Checked);

        // update the running list.
        UpdateSkillData(skill, index);
    }

    private void UpdateAiSkillExclusion(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (skill, index) = GetSkillSelection();

        // update the underlying data.
        skill.UpdateJabsAiSkillExclusion(checkBox_aiSkillExclude.Checked);

        // update the running list.
        UpdateSkillData(skill, index);
    }

    private void UpdateCanGapClose(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (skill, index) = GetSkillSelection();

        // update the underlying data.
        skill.UpdateJabsGapCloser(checkBox_canGapClose.Checked);

        // update the running list.
        UpdateSkillData(skill, index);
    }

    private void UpdateComboData(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (skill, index) = GetSkillSelection();

        // grab the current combo skill in the box.
        var comboSkill = num_comboSkill.Value;

        // grab the current combo delay in the box.
        var comboDelay = num_comboDelay.Value;

        // update the underlying data.
        skill.UpdateJabsComboData(comboSkill, comboDelay);

        // update the running list.
        UpdateSkillData(skill, index);
    }

    private void UpdateCastAnimation(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (skill, index) = GetSkillSelection();

        // grab the current value in the input.
        var castAnimationId = num_castAnimation.Value;

        // update the underlying data.
        skill.UpdateJabsCastAnimation(castAnimationId);

        // update the running list.
        UpdateSkillData(skill, index);
    }

    private void UpdateCastTime(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (skill, index) = GetSkillSelection();

        // grab the current value in the input.
        var castTime = num_castTime.Value;

        // update the underlying data.
        skill.UpdateJabsCastTime(castTime);

        // update the running list.
        UpdateSkillData(skill, index);
    }

    private void UpdateCooldown(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (skill, index) = GetSkillSelection();

        // grab the current value in the input.
        var cooldown = num_cooldown.Value;

        // update the underlying data.
        skill.UpdateJabsCooldown(cooldown);

        // update the running list.
        UpdateSkillData(skill, index);
    }

    private void UpdateDuration(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (skill, index) = GetSkillSelection();

        // grab the current value in the input.
        var duration = num_duration.Value;

        // update the underlying data.
        skill.UpdateJabsDuration(duration);

        // update the running list.
        UpdateSkillData(skill, index);
    }

    private void UpdateActionId(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (skill, index) = GetSkillSelection();

        // grab the current value in the input.
        var actionId = num_actionId.Value;

        // update the underlying data.
        skill.UpdateJabsActionId(actionId);

        // update the running list.
        UpdateSkillData(skill, index);
    }

    private void UpdateHitbox(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (skill, index) = GetSkillSelection();

        // grab the current value in the input.
        var hitbox = (Hitbox)comboBox_hitbox.SelectedItem!;

        // update the underlying data.
        skill.UpdateJabsHitbox(hitbox);

        // update the running list.
        UpdateSkillData(skill, index);
    }

    private void UpdateDirectTargeting(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (skill, index) = GetSkillSelection();

        // update the underlying data.
        skill.UpdateJabsDirectTargeting(checkBox_direct.Checked);

        // update the running list.
        UpdateSkillData(skill, index);
    }

    private void UpdateRadius(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (skill, index) = GetSkillSelection();

        // grab the current value in the input.
        var radius = num_radius.Value;

        // update the underlying data.
        skill.UpdateJabsRadius(radius);

        // update the running list.
        UpdateSkillData(skill, index);
    }

    private void UpdateProximity(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (skill, index) = GetSkillSelection();

        // grab the current value in the input.
        var proximity = num_proximity.Value;

        // update the underlying data.
        skill.UpdateJabsProximity(proximity);

        // update the running list.
        UpdateSkillData(skill, index);
    }

    private void UpdateSkillName(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (skill, index) = GetSkillSelection();

        // update the name with the new value.
        skillsList[index].name = textBox_skillName.Text;

        // update the listbox with the updated data.
        listboxSkills.Items[index - 1] = skillsList[index];

        // refresh.
        listboxSkills.Refresh();
    }
    #endregion updates

    /// <summary>
    /// Refreshes the form on-demand, repopulating all data points with the latest.
    /// </summary>
    private void RefreshForm(object? sender, EventArgs e)
    {
        _RefreshForm();
    }

    /// <summary>
    /// Refreshes the form on-demand, repopulating all data points with the latest.
    /// </summary>
    private void _RefreshForm()
    {
        var selectedItem = (RPG_Skill)listboxSkills.SelectedItem!;

        if (selectedItem == null) return;

        // core data
        label_skillIdValue.Text = selectedItem.id.ToString();
        textBox_skillName.Text = selectedItem.name;
        checkBox_hideFromJabsMenu.Checked = selectedItem.HasJabsHideFromQuickMenu();

        // targeting data
        checkBox_direct.Checked = selectedItem.HasJabsDirectTargeting();
        num_radius.Value = selectedItem.GetJabsRadius();
        num_proximity.Value = selectedItem.GetJabsProximity();
        var hitboxIndex = comboBox_hitbox.FindString(selectedItem.GetJabsHitbox().ToString());
        if (hitboxIndex != -1)
        {
            comboBox_hitbox.SelectedIndex = hitboxIndex;
        }

        textBox_skillExtend.Text = selectedItem.GetSkillExtendIds();

        // combo data
        num_comboSkill.Value = selectedItem.GetJabsComboSkillId();
        num_comboDelay.Value = selectedItem.GetJabsComboDelay();
        checkBox_freeCombo.Checked = selectedItem.HasJabsFreeCombo();
        checkBox_comboStarter.Checked = selectedItem.HasJabsAiComboStarter();

        // map data
        num_actionId.Value = selectedItem.GetJabsActionId();
        num_duration.Value = selectedItem.GetJabsDuration();

        // piercing data
        num_piercingCount.Value = selectedItem.GetJabsPiercingCount();
        num_piercingDelay.Value = selectedItem.GetJabsPiercingDelay();

        // usage data
        num_cooldown.Value = selectedItem.GetJabsCooldown();
        num_castAnimation.Value = selectedItem.GetJabsCastAnimation();
        num_castTime.Value = selectedItem.GetJabsCastTime();
        checkBox_aiSkillExclude.Checked = selectedItem.HasJabsAiSkillExclusion();
        checkBox_canGapClose.Checked = selectedItem.HasJabsGapCloser();

        // pose data
        textBox_poseSuffix.Text = selectedItem.GetJabsPoseSuffix();
        num_poseIndex.Value = selectedItem.GetJabsPoseIndex();
        num_poseDuration.Value = selectedItem.GetJabsPoseDuration();
    }

    #region setup
    public void FlagForRefresh()
    {
        needsSetup = true;
    }

    private void SetupComplete()
    {
        needsSetup = false;
    }

    public void Setup(List<RPG_Skill> data)
    {
        if (!needsSetup) return;

        // populate the list of weapons.
        PopulateSkillsList(data);

        // check if we need to autopick an index.
        if (listboxSkills.SelectedIndex == -1)
        {
            // set the index to the first item.
            listboxSkills.SelectedIndex = 0;
        }
    }

    private void PopulateSkillsList(List<RPG_Skill> data)
    {
        // assign the list of data locally to the form.
        skillsList = data;

        // iterate over each of the items in the list 
        skillsList.ForEach(skill =>
        {
            // the first entry in the list is always null, so accommodate.
            if (skill != null)
            {
                // add the data to the running list.
                listboxSkills.Items.Add(skill);
            }
        });

        // let this form know we've finished setup.
        SetupComplete();
    }
    #endregion setup
}
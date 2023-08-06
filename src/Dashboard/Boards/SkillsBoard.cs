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
    private List<RPG_Skill> skillsList = new();

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
        this.InitializeComponent();

        this.InitializeDataControls();
        this.InitializeTooltips();
        this.ApplyUpdateEvents();
    }

    /// <summary>
    /// Initializes the data-binding of components to arbitrary values.
    /// </summary>
    private void InitializeDataControls()
    {
        // setup the main list box of skills.
        this.listboxSkills.DisplayMember = "name";
        this.listboxSkills.ValueMember = "id";
        this.comboBox_hitbox.DataSource = Enum.GetValues(typeof(Hitbox));
    }

    private void InitializeTooltips()
    {
        _toolTip = new();
        _toolTip.AutoPopDelay = 5000;
        _toolTip.InitialDelay = 1000;
        _toolTip.ReshowDelay = 500;
        _toolTip.ToolTipIcon = ToolTipIcon.Info;
        _toolTip.ToolTipTitle = "Details and Usage";

        _toolTip.SetToolTip(this.num_radius, JABS.Data.Models.Tags.Radius.Description);
        _toolTip.SetToolTip(this.num_proximity, JABS.Data.Models.Tags.Proximity.Description);
        _toolTip.SetToolTip(this.comboBox_hitbox, JABS.Data.Models.Tags.Hitbox.Description);

        _toolTip.SetToolTip(this.num_comboSkill, JABS.Data.Models.Tags.Combo.Descriptions[0]);
        _toolTip.SetToolTip(this.num_comboDelay, JABS.Data.Models.Tags.Combo.Descriptions[1]);
        _toolTip.SetToolTip(this.checkBox_comboStarter, JABS.Data.Models.Tags.AiComboStarter.Description);
        _toolTip.SetToolTip(this.checkBox_freeCombo, JABS.Data.Models.Tags.FreeCombo.Description);

        _toolTip.SetToolTip(this.num_piercingCount, JABS.Data.Models.Tags.Pierce.Description);
        _toolTip.SetToolTip(this.num_piercingDelay, JABS.Data.Models.Tags.Pierce.Description);

        _toolTip.SetToolTip(this.num_actionId, JABS.Data.Models.Tags.ActionId.Description);
        _toolTip.SetToolTip(this.num_duration, JABS.Data.Models.Tags.Duration.Description);

        _toolTip.SetToolTip(this.num_cooldown, JABS.Data.Models.Tags.Cooldown.Description);
        _toolTip.SetToolTip(this.num_castAnimation, JABS.Data.Models.Tags.CastAnimation.Description);

        _toolTip.SetToolTip(this.textBox_poseSuffix, JABS.Data.Models.Tags.Pose.Description);
        _toolTip.SetToolTip(this.num_poseIndex, JABS.Data.Models.Tags.Pose.Description);
        _toolTip.SetToolTip(this.num_poseDuration, JABS.Data.Models.Tags.Pose.Description);
    }

    /// <summary>
    /// Binds the update of the various controls across this form.
    /// </summary>
    private void ApplyUpdateEvents()
    {
        this.ApplyUpdateEventsForBasicData();
        this.ApplyUpdateEventsForTargetingData();
        this.ApplyUpdateEventsForMapData();
        this.ApplyUpdateEventsForUsageData();
        this.ApplyUpdateEventsForComboData();
        this.ApplyUpdateEventsForPiercingData();
        this.ApplyUpdateEventsForPoseData();

        this.listboxSkills.SelectedValueChanged += this.RefreshForm;
    }

    private void ApplyUpdateEventsForBasicData()
    {
        // update basic data.
        this.textBox_skillName.TextChanged += this.UpdateSkillName;
        this.textBox_skillExtend.TextChanged += this.UpdateSkillExtend;
        this.checkBox_hideFromJabsMenu.CheckedChanged += this.UpdateQuickMenuVisibility;
    }

    private void ApplyUpdateEventsForTargetingData()
    {
        // update targeting data.
        this.checkBox_direct.CheckedChanged += this.UpdateDirectTargeting;
        this.num_proximity.ValueChanged += this.UpdateProximity;
        this.num_radius.ValueChanged += this.UpdateRadius;
        this.comboBox_hitbox.SelectedIndexChanged += this.UpdateHitbox;
    }

    private void ApplyUpdateEventsForMapData()
    {
        // update map data.
        this.num_actionId.ValueChanged += this.UpdateActionId;
        this.num_duration.ValueChanged += this.UpdateDuration;
    }

    private void ApplyUpdateEventsForUsageData()
    {
        // update usage data.
        this.num_cooldown.ValueChanged += this.UpdateCooldown;
        this.num_castAnimation.ValueChanged += this.UpdateCastAnimation;
        this.num_castTime.ValueChanged += this.UpdateCastTime;
        this.checkBox_canGapClose.CheckedChanged += this.UpdateCanGapClose;
    }

    private void ApplyUpdateEventsForComboData()
    {
        // update combo data.
        this.num_comboDelay.ValueChanged += this.UpdateComboData;
        this.num_comboSkill.ValueChanged += this.UpdateComboData;
        this.checkBox_freeCombo.CheckedChanged += this.UpdateFreeCombo;
        this.checkBox_comboStarter.CheckedChanged += this.UpdateAiComboStarter;
        this.checkBox_aiSkillExclude.CheckedChanged += this.UpdateAiSkillExclusion;
    }

    private void ApplyUpdateEventsForPiercingData()
    {
        // update piercing data.
        this.num_piercingCount.ValueChanged += this.UpdatePiercingData;
        this.num_piercingDelay.ValueChanged += this.UpdatePiercingData;
    }

    private void ApplyUpdateEventsForPoseData()
    {
        // update pose data.
        this.textBox_poseSuffix.TextChanged += this.UpdatePoseData;
        this.num_poseIndex.ValueChanged += this.UpdatePoseData;
        this.num_poseDuration.ValueChanged += this.UpdatePoseData;
    }

    /// <summary>
    /// Gets the current state of skills.
    /// </summary>
    /// <returns>The skill data including any edits.</returns>
    public List<RPG_Skill> Skills()
    {
        return this.skillsList;
    }

    #region updates

    /// <summary>
    /// Gets the currently selected item and also the index of that item.
    /// </summary>
    /// <returns>A pair of skill and its index in the list of skills.</returns>
    private (RPG_Skill skill, int index) GetSkillSelection()
    {
        // determine the selected skill.
        var selectedItem = (RPG_Skill)this.listboxSkills.SelectedItem!;

        // find the index of the selected skill in our local list.
        var index = this.skillsList.FindIndex(data => data != null && data.id == selectedItem.id);

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
        this.listboxSkills.Items[index - 1] = skill;
    }

    private void UpdateQuickMenuVisibility(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (skill, index) = this.GetSkillSelection();

        // update the underlying data.
        skill.UpdateJabsHideFromQuickMenu(this.checkBox_hideFromJabsMenu.Checked);

        // update the running list.
        this.UpdateSkillData(skill, index);
    }

    private void UpdateSkillExtend(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (skill, index) = this.GetSkillSelection();

        // grab the current data.
        var extensions = this.textBox_skillExtend.Text;

        // update the underlying data.
        skill.UpdateSkillExtendIds(extensions);

        // update the running list.
        this.UpdateSkillData(skill, index);
    }

    private void UpdatePoseData(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (skill, index) = this.GetSkillSelection();

        // grab the current pose suffix.
        var poseSuffix = this.textBox_poseSuffix.Text;

        // grab the current pose index.
        var poseIndex = this.num_poseIndex.Value;

        // grab the current pose duration.
        var poseDuration = this.num_poseDuration.Value;

        // update the underlying data.
        skill.UpdateJabsPoseData(poseSuffix, poseIndex, poseDuration);

        // update the running list.
        this.UpdateSkillData(skill, index);
    }

    private void UpdatePiercingData(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (skill, index) = this.GetSkillSelection();

        // grab the current piercing count.
        var piercingCount = this.num_piercingCount.Value;

        // grab the current piercing delay.
        var piercingDelay = this.num_piercingDelay.Value;

        // update the underlying note.
        skill.UpdateJabsPiercingData(piercingCount, piercingDelay);

        // update the running list.
        this.UpdateSkillData(skill, index);
    }

    private void UpdateFreeCombo(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (skill, index) = this.GetSkillSelection();

        // update the underlying data.
        skill.UpdateJabsFreeCombo(this.checkBox_freeCombo.Checked);

        // update the running list.
        this.UpdateSkillData(skill, index);
    }

    private void UpdateAiComboStarter(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (skill, index) = this.GetSkillSelection();

        // update the underlying data.
        skill.UpdateJabsAiComboStarter(this.checkBox_comboStarter.Checked);

        // update the running list.
        this.UpdateSkillData(skill, index);
    }

    private void UpdateAiSkillExclusion(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (skill, index) = this.GetSkillSelection();

        // update the underlying data.
        skill.UpdateJabsAiSkillExclusion(this.checkBox_aiSkillExclude.Checked);

        // update the running list.
        this.UpdateSkillData(skill, index);
    }

    private void UpdateCanGapClose(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (skill, index) = this.GetSkillSelection();

        // update the underlying data.
        skill.UpdateJabsGapCloser(this.checkBox_canGapClose.Checked);

        // update the running list.
        this.UpdateSkillData(skill, index);
    }

    private void UpdateComboData(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (skill, index) = this.GetSkillSelection();

        // grab the current combo skill in the box.
        var comboSkill = this.num_comboSkill.Value;

        // grab the current combo delay in the box.
        var comboDelay = this.num_comboDelay.Value;

        // update the underlying data.
        skill.UpdateJabsComboData(comboSkill, comboDelay);

        // update the running list.
        this.UpdateSkillData(skill, index);
    }

    private void UpdateCastAnimation(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (skill, index) = this.GetSkillSelection();

        // grab the current value in the input.
        var castAnimationId = this.num_castAnimation.Value;

        // update the underlying data.
        skill.UpdateJabsCastAnimation(castAnimationId);

        // update the running list.
        this.UpdateSkillData(skill, index);
    }

    private void UpdateCastTime(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (skill, index) = this.GetSkillSelection();

        // grab the current value in the input.
        var castTime = this.num_castTime.Value;

        // update the underlying data.
        skill.UpdateJabsCastTime(castTime);

        // update the running list.
        this.UpdateSkillData(skill, index);
    }

    private void UpdateCooldown(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (skill, index) = this.GetSkillSelection();

        // grab the current value in the input.
        var cooldown = this.num_cooldown.Value;

        // update the underlying data.
        skill.UpdateJabsCooldown(cooldown);

        // update the running list.
        this.UpdateSkillData(skill, index);
    }

    private void UpdateDuration(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (skill, index) = this.GetSkillSelection();

        // grab the current value in the input.
        var duration = this.num_duration.Value;

        // update the underlying data.
        skill.UpdateJabsDuration(duration);

        // update the running list.
        this.UpdateSkillData(skill, index);
    }

    private void UpdateActionId(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (skill, index) = this.GetSkillSelection();

        // grab the current value in the input.
        var actionId = this.num_actionId.Value;

        // update the underlying data.
        skill.UpdateJabsActionId(actionId);

        // update the running list.
        this.UpdateSkillData(skill, index);
    }

    private void UpdateHitbox(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (skill, index) = this.GetSkillSelection();

        // grab the current value in the input.
        var hitbox = (Hitbox)this.comboBox_hitbox.SelectedItem;

        // update the underlying data.
        skill.UpdateJabsHitbox(hitbox);

        // update the running list.
        this.UpdateSkillData(skill, index);
    }

    private void UpdateDirectTargeting(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (skill, index) = this.GetSkillSelection();

        // update the underlying data.
        skill.UpdateJabsDirectTargeting(this.checkBox_direct.Checked);

        // update the running list.
        this.UpdateSkillData(skill, index);
    }

    private void UpdateRadius(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (skill, index) = this.GetSkillSelection();

        // grab the current value in the input.
        var radius = this.num_radius.Value;

        // update the underlying data.
        skill.UpdateJabsRadius(radius);

        // update the running list.
        this.UpdateSkillData(skill, index);
    }

    private void UpdateProximity(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (skill, index) = this.GetSkillSelection();

        // grab the current value in the input.
        var proximity = this.num_proximity.Value;

        // update the underlying data.
        skill.UpdateJabsProximity(proximity);

        // update the running list.
        this.UpdateSkillData(skill, index);
    }

    private void UpdateSkillName(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (skill, index) = this.GetSkillSelection();

        // update the name with the new value.
        this.skillsList[index].name = this.textBox_skillName.Text;

        // update the listbox with the updated data.
        this.listboxSkills.Items[index - 1] = this.skillsList[index];

        // refresh.
        this.listboxSkills.Refresh();
    }
    #endregion updates

    /// <summary>
    /// Refreshes the form on-demand, repopulating all data points with the latest.
    /// </summary>
    private void RefreshForm(object? sender, EventArgs e)
    {
        this._RefreshForm();
    }

    /// <summary>
    /// Refreshes the form on-demand, repopulating all data points with the latest.
    /// </summary>
    private void _RefreshForm()
    {
        var selectedItem = (RPG_Skill)this.listboxSkills.SelectedItem!;

        if (selectedItem == null) return;

        // core data
        this.label_skillIdValue.Text = selectedItem.id.ToString();
        this.textBox_skillName.Text = selectedItem.name;
        this.checkBox_hideFromJabsMenu.Checked = selectedItem.HasJabsHideFromQuickMenu();

        // targeting data
        this.checkBox_direct.Checked = selectedItem.HasJabsDirectTargeting();
        this.num_radius.Value = selectedItem.GetJabsRadius();
        this.num_proximity.Value = selectedItem.GetJabsProximity();
        var hitboxIndex = this.comboBox_hitbox.FindString(selectedItem.GetJabsHitbox().ToString());
        if (hitboxIndex != -1)
        {
            this.comboBox_hitbox.SelectedIndex = hitboxIndex;
        }

        this.textBox_skillExtend.Text = selectedItem.GetSkillExtendIds();

        // combo data
        this.num_comboSkill.Value = selectedItem.GetJabsComboSkillId();
        this.num_comboDelay.Value = selectedItem.GetJabsComboDelay();
        this.checkBox_freeCombo.Checked = selectedItem.HasJabsFreeCombo();
        this.checkBox_comboStarter.Checked = selectedItem.HasJabsAiComboStarter();

        // map data
        this.num_actionId.Value = selectedItem.GetJabsActionId();
        this.num_duration.Value = selectedItem.GetJabsDuration();

        // piercing data
        this.num_piercingCount.Value = selectedItem.GetJabsPiercingCount();
        this.num_piercingDelay.Value = selectedItem.GetJabsPiercingDelay();

        // usage data
        this.num_cooldown.Value = selectedItem.GetJabsCooldown();
        this.num_castAnimation.Value = selectedItem.GetJabsCastAnimation();
        this.num_castTime.Value = selectedItem.GetJabsCastTime();
        this.checkBox_aiSkillExclude.Checked = selectedItem.HasJabsAiSkillExclusion();
        this.checkBox_canGapClose.Checked = selectedItem.HasJabsGapCloser();

        // pose data
        this.textBox_poseSuffix.Text = selectedItem.GetJabsPoseSuffix();
        this.num_poseIndex.Value = selectedItem.GetJabsPoseIndex();
        this.num_poseDuration.Value = selectedItem.GetJabsPoseDuration();
    }

    #region setup
    public void FlagForRefresh()
    {
        this.needsSetup = true;
    }

    private void SetupComplete()
    {
        this.needsSetup = false;
    }

    public void Setup(List<RPG_Skill> data)
    {
        if (!this.needsSetup) return;

        // populate the list of weapons.
        this.PopulateSkillsList(data);

        // check if we need to autopick an index.
        if (this.listboxSkills.SelectedIndex == -1)
        {
            // set the index to the first item.
            this.listboxSkills.SelectedIndex = 0;
        }
    }

    private void PopulateSkillsList(List<RPG_Skill> data)
    {
        // assign the list of data locally to the form.
        this.skillsList = data;

        // iterate over each of the items in the list 
        this.skillsList.ForEach(skill =>
        {
            // the first entry in the list is always null, so accommodate.
            if (skill != null)
            {
                // add the data to the running list.
                this.listboxSkills.Items.Add(skill);
            }
        });

        // let this form know we've finished setup.
        this.SetupComplete();
    }
    #endregion setup
}
using JMZ.Rmmz.Data.Models.JABS;
using JMZ.Rmmz.Data.Models.JABS.implementations;

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
        this.comboBox_hitbox.DataSource = Enum.GetValues(typeof(Rmmz.Data.Models.JABS.Hitbox));
    }

    /// <summary>
    /// Binds the update of the various controls across this form.
    /// </summary>
    private void ApplyUpdateEvents()
    {
        // update basic data.
        this.textBox_skillName.TextChanged += this.UpdateSkillName;
        this.textBox_skillExtend.TextChanged += this.UpdateSkillExtend;
        this.checkBox_hideFromJabsMenu.CheckedChanged += this.UpdateQuickMenuVisibility;

        // update targeting data.
        this.checkBox_direct.CheckedChanged += this.UpdateDirectTargeting;
        this.num_proximity.ValueChanged += this.UpdateProximity;
        this.num_radius.ValueChanged += this.UpdateRadius;
        this.comboBox_hitbox.SelectedIndexChanged += this.UpdateHitbox;

        // update map data.
        this.num_actionId.ValueChanged += this.UpdateActionId;
        this.num_duration.ValueChanged += this.UpdateDuration;

        // update usage data.
        this.num_cooldown.ValueChanged += this.UpdateCooldown;
        this.num_castAnimation.ValueChanged += this.UpdateCastAnimation;
        this.num_castTime.ValueChanged += this.UpdateCastTime;
        this.checkBox_canGapClose.CheckedChanged += this.UpdateCanGapClose;

        // update combo data.
        this.num_comboDelay.ValueChanged += this.UpdateComboData;
        this.num_comboSkill.ValueChanged += this.UpdateComboData;
        this.checkBox_freeCombo.CheckedChanged += this.UpdateFreeCombo;
        this.checkBox_comboStarter.CheckedChanged += this.UpdateAiComboStarter;
        this.checkBox_aiSkillExclude.CheckedChanged += this.UpdateAiSkillExclusion;

        // update pose data.
        this.textBox_poseSuffix.TextChanged += this.UpdatePoseData;
        this.num_poseIndex.ValueChanged += this.UpdatePoseData;
        this.num_poseDuration.ValueChanged += this.UpdatePoseData;

        this.listboxSkills.SelectedValueChanged += this.RefreshForm;
    }

    private void InitializeTooltips()
    {
        _toolTip = new();
        _toolTip.AutoPopDelay = 5000;
        _toolTip.InitialDelay = 1000;
        _toolTip.ReshowDelay = 500;
        _toolTip.ToolTipIcon = ToolTipIcon.Info;
        _toolTip.ToolTipTitle = "Details and Usage";

        _toolTip.SetToolTip(this.num_radius, Rmmz.Data.Models.JABS.Tags.Radius.Description);
        _toolTip.SetToolTip(this.num_proximity, Rmmz.Data.Models.JABS.Tags.Proximity.Description);
        _toolTip.SetToolTip(this.comboBox_hitbox, Rmmz.Data.Models.JABS.Tags.Hitbox.Description);

        _toolTip.SetToolTip(this.num_comboSkill, Rmmz.Data.Models.JABS.Tags.Combo.Descriptions[0]);
        _toolTip.SetToolTip(this.num_comboDelay, Rmmz.Data.Models.JABS.Tags.Combo.Descriptions[1]);
        _toolTip.SetToolTip(this.checkBox_comboStarter, Rmmz.Data.Models.JABS.Tags.AiComboStarter.Description);
        _toolTip.SetToolTip(this.checkBox_freeCombo, Rmmz.Data.Models.JABS.Tags.FreeCombo.Description);

        _toolTip.SetToolTip(this.num_piercingCount, Rmmz.Data.Models.JABS.Tags.Pierce.Description);
        _toolTip.SetToolTip(this.num_piercingDelay, Rmmz.Data.Models.JABS.Tags.Pierce.Description);

        _toolTip.SetToolTip(this.num_actionId, Rmmz.Data.Models.JABS.Tags.ActionId.Description);
        _toolTip.SetToolTip(this.num_duration, Rmmz.Data.Models.JABS.Tags.Duration.Description);

        _toolTip.SetToolTip(this.num_cooldown, Rmmz.Data.Models.JABS.Tags.Cooldown.Description);
        _toolTip.SetToolTip(this.num_castAnimation, Rmmz.Data.Models.JABS.Tags.CastAnimation.Description);

        _toolTip.SetToolTip(this.textBox_poseSuffix, Rmmz.Data.Models.JABS.Tags.Pose.Description);
        _toolTip.SetToolTip(this.num_poseIndex, Rmmz.Data.Models.JABS.Tags.Pose.Description);
        _toolTip.SetToolTip(this.num_poseDuration, Rmmz.Data.Models.JABS.Tags.Pose.Description);
    }

    /// <summary>
    /// Gets the current state of skills.
    /// </summary>
    /// <returns>The skill data including any edits.</returns>
    public List<RPG_Skill> Skills()
    {
        return this.skillsList;
    }

    /// <summary>
    /// Gets the currently selected item and also the index of that item.
    /// </summary>
    /// <returns>A pair of skill and its index in the list of skills.</returns>
    private (RPG_Skill skill, int index) getSkillSelection()
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
    private void updateSkillData(RPG_Skill skill, int index)
    {
        // update the backed skill data with this new data.
        this.listboxSkills.Items[index - 1] = skill;
    }

    private void UpdateQuickMenuVisibility(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (skill, index) = this.getSkillSelection();

        // update the underlying data.
        skill.updateHideFromQuickMenu(this.checkBox_hideFromJabsMenu.Checked);

        // update the running list.
        this.updateSkillData(skill, index);
    }

    private void UpdateSkillExtend(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (skill, index) = this.getSkillSelection();

        // grab the current data.
        var extensions = this.textBox_skillExtend.Text;

        // update the underlying data.
        skill.updateSkillExtends(extensions);

        // update the running list.
        this.updateSkillData(skill, index);
    }

    private void UpdatePoseData(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (skill, index) = this.getSkillSelection();

        // grab the current pose suffix.
        var poseSuffix = this.textBox_poseSuffix.Text;

        // grab the current pose index.
        var poseIndex = this.num_poseIndex.Value;

        // grab the current pose duration.
        var poseDuration = this.num_poseDuration.Value;

        // update the underlying data.
        skill.updateJabsPose(poseSuffix, poseIndex, poseDuration);

        // update the running list.
        this.updateSkillData(skill, index);
    }

    private void UpdateFreeCombo(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (skill, index) = this.getSkillSelection();

        // update the underlying data.
        skill.updateFreeComboEnabled(this.checkBox_freeCombo.Checked);

        // update the running list.
        this.updateSkillData(skill, index);
    }

    private void UpdateAiComboStarter(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (skill, index) = this.getSkillSelection();

        // update the underlying data.
        skill.updateAiComboStarter(this.checkBox_comboStarter.Checked);

        // update the running list.
        this.updateSkillData(skill, index);
    }

    private void UpdateAiSkillExclusion(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (skill, index) = this.getSkillSelection();

        // update the underlying data.
        skill.updateAiSkillExclusion(this.checkBox_aiSkillExclude.Checked);

        // update the running list.
        this.updateSkillData(skill, index);
    }

    private void UpdateCanGapClose(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (skill, index) = this.getSkillSelection();

        // update the underlying data.
        skill.updateCanGapClose(this.checkBox_canGapClose.Checked);

        // update the running list.
        this.updateSkillData(skill, index);
    }

    private void UpdateComboData(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (skill, index) = this.getSkillSelection();

        // grab the current combo skill in the box.
        var comboSkill = this.num_comboSkill.Value;

        // grab the current combo delay in the box.
        var comboDelay = this.num_comboDelay.Value;

        // update the underlying data.
        skill.updateJabsCombo(comboSkill, comboDelay);

        // update the running list.
        this.updateSkillData(skill, index);
    }

    private void UpdateCastAnimation(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (skill, index) = this.getSkillSelection();

        // grab the current value in the input.
        var castAnimationId = this.num_castAnimation.Value;

        // update the underlying data.
        skill.updateJabsCastAnimation(castAnimationId);

        // update the running list.
        this.updateSkillData(skill, index);
    }

    private void UpdateCastTime(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (skill, index) = this.getSkillSelection();

        // grab the current value in the input.
        var castTime = this.num_castTime.Value;

        // update the underlying data.
        skill.updateJabsCastTime(castTime);

        // update the running list.
        this.updateSkillData(skill, index);
    }

    private void UpdateCooldown(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (skill, index) = this.getSkillSelection();

        // grab the current value in the input.
        var cooldown = this.num_cooldown.Value;

        // update the underlying data.
        skill.updateJabsCooldown(cooldown);

        // update the running list.
        this.updateSkillData(skill, index);
    }

    private void UpdateDuration(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (skill, index) = this.getSkillSelection();

        // grab the current value in the input.
        var duration = this.num_duration.Value;

        // update the underlying data.
        skill.updateJabsDuration(duration);

        // update the running list.
        this.updateSkillData(skill, index);
    }

    private void UpdateActionId(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (skill, index) = this.getSkillSelection();

        // grab the current value in the input.
        var actionId = this.num_actionId.Value;

        // update the underlying data.
        skill.updateJabsActionId(actionId);

        // update the running list.
        this.updateSkillData(skill, index);
    }

    private void UpdateHitbox(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (skill, index) = this.getSkillSelection();

        // grab the current value in the input.
        var hitbox = (Hitbox)this.comboBox_hitbox.SelectedItem;

        // update the underlying data.
        skill.updateJabsHitbox(hitbox);

        // update the running list.
        this.updateSkillData(skill, index);
    }

    private void UpdateDirectTargeting(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (skill, index) = this.getSkillSelection();

        // update the underlying data.
        skill.updateJabsDirectTargeting(this.checkBox_direct.Checked);

        // update the running list.
        this.updateSkillData(skill, index);
    }

    private void UpdateRadius(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (skill, index) = this.getSkillSelection();

        // grab the current value in the input.
        var radius = this.num_radius.Value;

        // update the underlying data.
        skill.updateJabsRadius(radius);

        // update the running list.
        this.updateSkillData(skill, index);
    }

    private void UpdateProximity(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (skill, index) = this.getSkillSelection();

        // grab the current value in the input.
        var proximity = this.num_proximity.Value;

        // update the underlying data.
        skill.updateJabsProximity(proximity);

        // update the running list.
        this.updateSkillData(skill, index);
    }

    private void UpdateSkillName(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (skill, index) = this.getSkillSelection();

        // update the name with the new value.
        this.skillsList[index].name = this.textBox_skillName.Text;

        // update the listbox with the updated data.
        this.listboxSkills.Items[index - 1] = this.skillsList[index];

        // refresh.
        this.listboxSkills.Refresh();
    }

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
        this.checkBox_hideFromJabsMenu.Checked = selectedItem.jabsHideFromQuickMenu;

        // targeting data
        this.checkBox_direct.Checked = selectedItem.jabsDirectTargeting;
        this.num_radius.Value = selectedItem.jabsRadius;
        this.num_proximity.Value = selectedItem.jabsProximity;
        var hitboxIndex = this.comboBox_hitbox.FindString(selectedItem.jabsHitbox.ToString());
        if (hitboxIndex != -1)
        {
            this.comboBox_hitbox.SelectedIndex = hitboxIndex;
        }

        this.textBox_skillExtend.Text = selectedItem.jabsSkillExtends;

        // combo data
        this.num_comboSkill.Value = selectedItem.jabsComboSkillId;
        this.num_comboDelay.Value = selectedItem.jabsComboDelay;
        this.checkBox_freeCombo.Checked = selectedItem.jabsFreeCombo;
        this.checkBox_comboStarter.Checked = selectedItem.jabsAiComboStarter;

        // map data
        this.num_actionId.Value = selectedItem.jabsActionId;
        this.num_duration.Value = selectedItem.jabsDuration;

        // piercing data
        this.num_piercingCount.Value = selectedItem.jabsPierceCount;
        this.num_piercingDelay.Value = selectedItem.jabsPierceDelay;

        // usage data
        this.num_cooldown.Value = selectedItem.jabsCooldown;
        this.num_castAnimation.Value = selectedItem.jabsCastAnimation;
        this.num_castTime.Value = selectedItem.jabsCastTime;
        this.checkBox_aiSkillExclude.Checked = selectedItem.jabsAiSkillExclusion;
        this.checkBox_canGapClose.Checked = selectedItem.jabsGapCloser;

        // pose data
        this.textBox_poseSuffix.Text = selectedItem.jabsPoseSuffix;
        this.num_poseIndex.Value = selectedItem.jabsPoseIndex;
        this.num_poseDuration.Value = selectedItem.jabsPoseDuration;
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
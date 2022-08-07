using Dashboard.Models.implementations;
using Dashboard.Models.JABS;

namespace Dashboard.Boards;

public partial class SkillsForm : Form
{
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
    public SkillsForm()
    {
        InitializeComponent();
        this.listboxSkills.DisplayMember = "name";
        this.listboxSkills.ValueMember = "id";
        this.listboxSkills.SelectedIndexChanged += this.RefreshForm;
        this.comboBox_hitbox.DataSource = Enum.GetValues(typeof(Hitbox));

        // update basic data.
        this.textBox_skillName.TextChanged += this.UpdateSkillName;

        // update targeting data.
        this.num_proximity.ValueChanged += this.UpdateProximity;
        this.num_radius.ValueChanged += this.UpdateRadius;
        this.comboBox_hitbox.SelectedIndexChanged += this.UpdateHitbox;

        // update map data.
        this.num_actionId.ValueChanged += this.UpdateActionId;
        this.num_duration.ValueChanged += this.UpdateDuration;
        
        // update usage data.
        this.num_cooldown.ValueChanged += this.UpdateCooldown;
        this.num_castAnimation.ValueChanged += this.UpdateCastAnimation;
        
        // update combo data.
        this.num_comboDelay.ValueChanged += this.UpdateComboData;
        this.num_comboSkill.ValueChanged += this.UpdateComboData;
        this.checkBox_freeCombo.CheckedChanged += this.UpdateFreeCombo;
        
        // update pose data.
        this.textBox_poseSuffix.TextChanged += this.UpdatePoseData;
        this.num_poseIndex.ValueChanged += this.UpdatePoseData;
        this.num_poseDuration.ValueChanged += this.UpdatePoseData;
    }

    private (RPG_Skill skill, int index) getSkillSelection()
    {
        // determine the selected skill.
        var selectedItem = (RPG_Skill)this.listboxSkills.SelectedItem;
        
        // find the index of the selected skill in our local list.
        var index = this.skillsList.FindIndex(data => data != null && data.id == selectedItem.id);

        // return both data points.
        return new(selectedItem, index);
    }

    private void UpdatePoseData(object? sender, EventArgs e)
    {
    }

    private void UpdateFreeCombo(object? sender, EventArgs e)
    {
    }

    private void UpdateComboData(object? sender, EventArgs e)
    {
    }

    private void UpdateCastAnimation(object? sender, EventArgs e)
    {
    }

    private void UpdateCooldown(object? sender, EventArgs e)
    {
    }

    private void UpdateDuration(object? sender, EventArgs e)
    {
    }

    private void UpdateActionId(object? sender, EventArgs e)
    {
    }

    private void UpdateHitbox(object? sender, EventArgs e)
    {
    }

    private void UpdateRadius(object? sender, EventArgs e)
    {
    }

    private void UpdateProximity(object? sender, EventArgs e)
    {
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
    /// Gets the current state of skills.
    /// </summary>
    /// <returns>The skill data including any edits.</returns>
    public List<RPG_Skill> Skills()
    {
        return this.skillsList;
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
        var selectedItem = (RPG_Skill)this.listboxSkills.SelectedItem;

        if (selectedItem == null) return;

        this.textBox_skillName.Text = selectedItem.name;
        this.label_skillIdValue.Text = selectedItem.id.ToString();

        // update other data in form here.
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
using JMZ.JABS.Data.Extensions.implementations._Weapon.CoreData;
using JMZ.Rmmz.Data.Models.db.implementations;

namespace JMZ.Dashboard.Boards;

public partial class WeaponsBoard : Form
{
    /// <summary>
    /// The running list of parsed data including any edits made by the user.
    /// </summary>
    private List<RPG_Weapon> weaponsList = new();

    /// <summary>
    /// Whether or not this form needs setup.
    /// </summary>
    private bool needsSetup = true;

    /// <summary>
    /// Constructor.
    /// </summary>
    public WeaponsBoard()
    {
        InitializeComponent();
        this.listBoxWeapons.DisplayMember = "name";
        this.listBoxWeapons.ValueMember = "id";
        this.listBoxWeapons.SelectedIndexChanged += this.RefreshForm;
        this.textBox_weaponName.TextChanged += this.UpdateName;
        this.num_weaponSkillId.ValueChanged += this.UpdateSkillId;
    }

    public List<RPG_Weapon> Weapons()
    {
        return this.weaponsList;
    }

    private (RPG_Weapon weapon, int index) getWeaponSelection()
    {
        // determine the selected weapon.
        var selectedItem = (RPG_Weapon)this.listBoxWeapons.SelectedItem!;

        // find the index of the selected weapon in our local list.
        var index = this.weaponsList.FindIndex(data => data != null && data.id == selectedItem.id);

        // return both data points.
        return new(selectedItem, index);
    }

    private void updateWeaponData(RPG_Weapon weapon, int index)
    {
        this.listBoxWeapons.Items[index - 1] = weapon;
    }

    private void UpdateName(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (weapon, index) = this.getWeaponSelection();

        var name = this.textBox_weaponName.Text;

        weapon.name = name;

        this.updateWeaponData(weapon, index);
    }

    private void UpdateSkillId(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (weapon, index) = this.getWeaponSelection();

        // grab the current value in the input.
        var skillId = this.num_weaponSkillId.Value;

        // update the underlying data.
        weapon.UpdateJabsSkillId(skillId);

        // update the running list.
        this.updateWeaponData(weapon, index);
    }

    private void RefreshForm(object? sender, EventArgs e)
    {
        this._RefreshForm();
    }

    private void _RefreshForm()
    {
        var selectedItem = (RPG_Weapon)this.listBoxWeapons.SelectedItem!;

        if (selectedItem == null) return;

        this.textBox_weaponName.Text = selectedItem.name;
        this.label_weaponIdValue.Text = selectedItem.id.ToString();

        this.num_weaponSkillId.Value = selectedItem.GetJabsSkillId();

        // update other data in form here.
    }

    #region setup
    public void FlagForRefresh()
    {
        this.needsSetup = true;
    }

    public void SetupComplete()
    {
        this.needsSetup = false;
    }

    public void Setup(List<RPG_Weapon> weapons)
    {
        if (!this.needsSetup) return;

        // populate the list of weapons.
        this.PopulateWeaponsList(weapons);

        // check if we need to autopick an index.
        if (this.listBoxWeapons.SelectedIndex == -1)
        {
            // set the index to the first item.
            this.listBoxWeapons.SelectedIndex = 0;
        }
    }

    private void PopulateWeaponsList(List<RPG_Weapon> weapons)
    {
        // assign the list of weapons locally to the form.
        this.weaponsList = weapons;

        // iterate over each of the weapons in the list 
        this.weaponsList.ForEach(weapon =>
        {
            // the first weapon in the list is always null, so accommodate.
            if (weapon != null)
            {
                // add the weapon to the running list.
                this.listBoxWeapons.Items.Add(weapon);
            }
        });

        // let this form know we've finished setup.
        this.SetupComplete();
    }
    #endregion setup
}

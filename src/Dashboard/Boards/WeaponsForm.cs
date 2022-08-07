using Dashboard.Models;
using System.Text.RegularExpressions;

namespace Dashboard;

public partial class WeaponsForm : Form
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
    public WeaponsForm()
    {
        InitializeComponent();
        this.listWeapons.DisplayMember = "name";
        this.listWeapons.ValueMember = "id";
        this.listWeapons.SelectedIndexChanged += this.RefreshForm;
        this.textBox_weaponName.TextChanged += this.UpdateWeaponName;
        this.num_weaponSkillId.ValueChanged += this.UpdateWeaponSkillId;
    }

    public List<RPG_Weapon> Weapons()
    {
        return this.weaponsList;
    }

    private void UpdateWeaponName(object? sender, EventArgs e)
    {
        var selectedItem = (RPG_Weapon)this.listWeapons.SelectedItem;
        var weaponIndex = this.weaponsList.FindIndex(weapon => weapon != null && weapon.id == selectedItem.id);
        weaponsList[weaponIndex].name = this.textBox_weaponName.Text;
        this.listWeapons.Items[weaponIndex-1] = weaponsList[weaponIndex];
        this.listWeapons.Refresh();
    }

    private void UpdateWeaponSkillId(object? sender, EventArgs e)
    {
        var selectedItem = (RPG_Weapon)this.listWeapons.SelectedItem;
        var weaponIndex = this.weaponsList.FindIndex(weapon => weapon != null && weapon.id == selectedItem.id);

        selectedItem.updateSkillId(decimal.ToInt32(this.num_weaponSkillId.Value));

        this.listWeapons.Items[weaponIndex - 1] = selectedItem;
        
        this.listWeapons.Refresh();
    }

    private void RefreshForm(object? sender, EventArgs e)
    {
        this._RefreshForm();
    }

    private void _RefreshForm()
    {
        var selectedItem = (RPG_Weapon)this.listWeapons.SelectedItem;

        if (selectedItem == null) return;

        this.textBox_weaponName.Text = selectedItem.name;
        this.label_weaponIdValue.Text = selectedItem.id.ToString();

        this.num_weaponSkillId.Value = selectedItem.jabsSkillId;

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
        if (this.listWeapons.SelectedIndex == -1)
        {
            // set the index to the first item.
            this.listWeapons.SelectedIndex = 0;
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
                this.listWeapons.Items.Add(weapon);
            }
        });

        // let this form know we've finished setup.
        this.SetupComplete();
    }
    #endregion setup
}

using JMZ.Dashboard.Utils;
using JMZ.JABS.Data.Extensions.implementations._Weapon.CoreData;
using JMZ.Rmmz.Data.Models.db.implementations;

namespace JMZ.Dashboard.Boards;

public partial class WeaponsBoard : Form
{
    /// <summary>
    ///     Whether or not this form needs setup.
    /// </summary>
    private bool needsSetup = true;

    /// <summary>
    ///     Constructor.
    /// </summary>
    public WeaponsBoard()
    {
        InitializeComponent();
        listBoxWeapons.DisplayMember = "name";
        listBoxWeapons.ValueMember = "id";
        listBoxWeapons.SelectedIndexChanged += RefreshForm;
        textBox_weaponName.TextChanged += UpdateName;
        num_weaponSkillId.ValueChanged += UpdateSkillId;
    }

    private (RPG_Weapon weapon, int index) GetWeaponSelection()
    {
        // determine the selected weapon.
        var selectedItem = (RPG_Weapon)listBoxWeapons.SelectedItem!;

        // find the index of the selected weapon in our local list.
        var index = DataState.WeaponsList.FindIndex(data => data != null && data.id == selectedItem.id);

        // return both data points.
        return new(selectedItem, index);
    }

    private void UpdateWeaponData(RPG_Weapon weapon, int index)
    {
        listBoxWeapons.Items[index - 1] = weapon;
    }

    private void UpdateName(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (weapon, index) = GetWeaponSelection();

        var name = textBox_weaponName.Text;

        weapon.name = name;

        UpdateWeaponData(weapon, index);
    }

    private void UpdateSkillId(object? sender, EventArgs e)
    {
        // get the data of the selected item.
        var (weapon, index) = GetWeaponSelection();

        // grab the current value in the input.
        var skillId = num_weaponSkillId.Value;

        // update the underlying data.
        weapon.UpdateJabsSkillId(skillId);

        // update the running list.
        UpdateWeaponData(weapon, index);
    }

    private void RefreshForm(object? sender, EventArgs e)
    {
        _RefreshForm();
    }

    private void _RefreshForm()
    {
        var selectedItem = (RPG_Weapon)listBoxWeapons.SelectedItem!;

        if (selectedItem == null) return;

        textBox_weaponName.Text = selectedItem.name;
        label_weaponIdValue.Text = selectedItem.id.ToString();

        num_weaponSkillId.Value = selectedItem.GetJabsSkillId();

        // update other data in form here.
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

    public void Setup()
    {
        // don't actually setup the board if it isn't in need of setup.
        if (!needsSetup) return;

        // populate the list of weapons by reference.
        PopulateWeaponsList(DataState.WeaponsList);

        // set the index to the first item.
        listBoxWeapons.SelectedIndex = 0;
    }

    private void PopulateWeaponsList(List<RPG_Weapon> weapons)
    {
        // empty the list of weapons first.
        listBoxWeapons.Items.Clear();

        // iterate over each of the weapons in the list 
        weapons.ForEach(
            weapon =>
            {
                // the first weapon in the list is always null, so accommodate.
                if (weapon != null)
                {
                    // add the weapon to the running list.
                    listBoxWeapons.Items.Add(weapon);
                }
            });

        // let this form know we've finished setup.
        SetupComplete();
    }
    #endregion setup
}
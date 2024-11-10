using JMZ.Difficulty.Data.Models;
using JMZ.Rmmz.Data.Models;

namespace JMZ.Dashboard.Boards;

/// <summary>
///     The part of this class that contains all the update logic.
/// </summary>
public partial class DifficultyBoard
{
    private void ApplyUpdateEvents()
    {
        ApplyUpdateEventsForCoreData();
        ApplyUpdateEventsForBattlerEffectsData();
        ApplyUpdateEventsForRewards();

        listboxDifficultyLayers.SelectedIndexChanged += RefreshForm;
    }

    private void ApplyUpdateEventsForCoreData()
    {
        textBoxKey.TextChanged += UpdateKey;
        textBoxName.TextChanged += UpdateName;
        textBoxDescription.TextChanged += UpdateDescription;
        numIconIndex.ValueChanged += UpdateIconIndex;
        checkBoxUnlockedByDefault.CheckedChanged += UpdateUnlockedByDefault;
        checkBoxEnabledByDefault.CheckedChanged += UpdateEnabledByDefault;
        checkBoxHiddenByDefault.CheckedChanged += UpdateHiddenByDefault;
        numCost.ValueChanged += UpdateCost;
    }

    private void ApplyUpdateEventsForBattlerEffectsData()
    {
        ApplyUpdateEventsForBParamBattlerEffects();
        ApplyUpdateEventsForXParamBattlerEffects();
        ApplyUpdateEventsForSParamBattlerEffects();

        ApplyUpdateEventsForCustomParamBattlerEffects();
    }

    private void ApplyUpdateEventsForBParamBattlerEffects()
    {
        num00MaxLifeActor.ValueChanged += UpdateBattlerEffectMaxLifeActor;
        num01MaxMagiActor.ValueChanged += UpdateBattlerEffectMaxMagiActor;
        num02PowerActor.ValueChanged += UpdateBattlerEffectPowerActor;
        num03EndureActor.ValueChanged += UpdateBattlerEffectEndureActor;
        num04ForceActor.ValueChanged += UpdateBattlerEffectForceActor;
        num05ResistActor.ValueChanged += UpdateBattlerEffectResistActor;
        num06SpeedActor.ValueChanged += UpdateBattlerEffectSpeedActor;
        num07LuckActor.ValueChanged += UpdateBattlerEffectLuckActor;

        num00MaxLifeEnemy.ValueChanged += UpdateBattlerEffectMaxLifeEnemy;
        num01MaxMagiEnemy.ValueChanged += UpdateBattlerEffectMaxMagiEnemy;
        num02PowerEnemy.ValueChanged += UpdateBattlerEffectPowerEnemy;
        num03EndureEnemy.ValueChanged += UpdateBattlerEffectEndureEnemy;
        num04ForceEnemy.ValueChanged += UpdateBattlerEffectForceEnemy;
        num05ResistEnemy.ValueChanged += UpdateBattlerEffectResistEnemy;
        num06SpeedEnemy.ValueChanged += UpdateBattlerEffectSpeedEnemy;
        num07LuckEnemy.ValueChanged += UpdateBattlerEffectLuckEnemy;
    }

    private void ApplyUpdateEventsForXParamBattlerEffects()
    {
        num00AccuracyActor.ValueChanged += UpdateBattlerEffectAccuracyActor;
        num01PhysEvadeActor.ValueChanged += UpdateBattlerEffectPhysEvadeActor;
        num02CritChanceActor.ValueChanged += UpdateBattlerEffectCritChanceActor;
        num03CritEvadeActor.ValueChanged += UpdateBattlerEffectCritEvadeActor;
        num04MagiEvadeActor.ValueChanged += UpdateBattlerEffectMagiEvadeActor;
        num05MagiReflectActor.ValueChanged += UpdateBattlerEffectMagiReflectActor;
        num06CounterActor.ValueChanged += UpdateBattlerEffectCounterActor;
        num07LifeRegenActor.ValueChanged += UpdateBattlerEffectLifeRegenActor;
        num08MagiRegenActor.ValueChanged += UpdateBattlerEffectMagiRegenActor;
        num09TechRegenActor.ValueChanged += UpdateBattlerEffectTechRegenActor;

        num00AccuracyEnemy.ValueChanged += UpdateBattlerEffectAccuracyEnemy;
        num01PhysEvadeEnemy.ValueChanged += UpdateBattlerEffectPhysEvadeEnemy;
        num02CritChanceEnemy.ValueChanged += UpdateBattlerEffectCritChanceEnemy;
        num03CritEvadeEnemy.ValueChanged += UpdateBattlerEffectCritEvadeEnemy;
        num04MagiEvadeEnemy.ValueChanged += UpdateBattlerEffectMagiEvadeEnemy;
        num05MagiReflectEnemy.ValueChanged += UpdateBattlerEffectMagiReflectEnemy;
        num06CounterEnemy.ValueChanged += UpdateBattlerEffectCounterEnemy;
        num07LifeRegenEnemy.ValueChanged += UpdateBattlerEffectLifeRegenEnemy;
        num08MagiRegenEnemy.ValueChanged += UpdateBattlerEffectMagiRegenEnemy;
        num09TechRegenEnemy.ValueChanged += UpdateBattlerEffectTechRegenEnemy;
    }

    private void ApplyUpdateEventsForSParamBattlerEffects()
    {
        num00AggroActor.ValueChanged += UpdateBattlerEffectAggroActor;
        num01ParryActor.ValueChanged += UpdateBattlerEffectParryActor;
        num02HealingActor.ValueChanged += UpdateBattlerEffectHealingActor;
        num03ItemEffectsActor.ValueChanged += UpdateBattlerEffectItemEffectsActor;
        num04MagiCostActor.ValueChanged += UpdateBattlerEffectMagiCostActor;
        num05TechCostActor.ValueChanged += UpdateBattlerEffectTechCostActor;
        num06PhysDamageActor.ValueChanged += UpdateBattlerEffectPhysDamageActor;
        num07MagiDamageActor.ValueChanged += UpdateBattlerEffectMagiDamageActor;
        num08EnvironDamageActor.ValueChanged += UpdateBattlerEffectEnvironDamageActor;
        num09ExperienceRateActor.ValueChanged += UpdateBattlerEffectExperienceActor;

        num00AggroEnemy.ValueChanged += UpdateBattlerEffectAggroEnemy;
        num01ParryEnemy.ValueChanged += UpdateBattlerEffectParryEnemy;
        num02HealingEnemy.ValueChanged += UpdateBattlerEffectHealingEnemy;
        num03ItemEffectsEnemy.ValueChanged += UpdateBattlerEffectItemEffectsEnemy;
        num04MagiCostEnemy.ValueChanged += UpdateBattlerEffectMagiCostEnemy;
        num05TechCostEnemy.ValueChanged += UpdateBattlerEffectTechCostEnemy;
        num06PhysDamageEnemy.ValueChanged += UpdateBattlerEffectPhysDamageEnemy;
        num07MagiDamageEnemy.ValueChanged += UpdateBattlerEffectMagiDamageEnemy;
        num08EnvironDamageEnemy.ValueChanged += UpdateBattlerEffectEnvironDamageEnemy;
        num09ExperienceRateEnemy.ValueChanged += UpdateBattlerEffectExperienceEnemy;
    }

    private void ApplyUpdateEventsForCustomParamBattlerEffects()
    {
        num28MaxTechActor.ValueChanged += UpdateBattlerEffectMaxTechActor;

        num28MaxTechEnemy.ValueChanged += UpdateBattlerEffectMaxTechEnemy;
    }

    private void ApplyUpdateEventsForRewards()
    {
        numRewardExperience.ValueChanged += UpdateRewardExperience;
        numRewardGold.ValueChanged += UpdateRewardGold;
        numRewardDrops.ValueChanged += UpdateRewardDrops;
        numRewardEncounters.ValueChanged += UpdateRewardEncounters;
        numRewardSdp.ValueChanged += UpdateRewardSdp;
    }

    #region update
    #region core updates
    private void UpdateKey(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // update with the new value.
        item.Key = textBoxKey.Text;
        
        // the name is special in that it needs to be synced with the list to ensure name updates apply.
        listboxDifficultyLayers.Items[listboxDifficultyLayers.SelectedIndex] = item;
    }

    private void UpdateName(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // update the name with the new value.
        item.Name = textBoxName.Text;

        // the name is special in that it needs to be synced with the list to ensure name updates apply.
        listboxDifficultyLayers.Items[listboxDifficultyLayers.SelectedIndex] = item;
    }

    private void UpdateDescription(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // update the name with the new value.
        item.Description = textBoxDescription.Text;
    }

    private void UpdateIconIndex(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // update with the new value.
        item.IconIndex = (int)numIconIndex.Value;
    }

    private void UpdateUnlockedByDefault(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // update with the new value.
        item.UnlockedByDefault = checkBoxUnlockedByDefault.Checked;
    }

    private void UpdateEnabledByDefault(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // update with the new value.
        item.EnabledByDefault = checkBoxEnabledByDefault.Checked;
    }

    private void UpdateHiddenByDefault(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // update with the new value.
        item.HiddenByDefault = checkBoxHiddenByDefault.Checked;
    }

    private void UpdateCost(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // update with the new value.
        item.Cost = decimal.ToInt32(numCost.Value);
    }
    #endregion

    #region effects updates
    #region bparam updates
    private void UpdateBattlerEffectMaxLifeActor(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = num00MaxLifeActor.Value;

        // update the battler effect.
        UpdateBattlerEffect(item, BattlerEffectType.BASE, ParameterId.MAX_HP, updatedValue, true);
    }

    private void UpdateBattlerEffectMaxLifeEnemy(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = num00MaxLifeEnemy.Value;

        // update the battler effect.
        UpdateBattlerEffect(item, BattlerEffectType.BASE, ParameterId.MAX_HP, updatedValue, false);
    }

    private void UpdateBattlerEffectMaxMagiActor(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = num01MaxMagiActor.Value;

        // update the battler effect.
        UpdateBattlerEffect(item, BattlerEffectType.BASE, ParameterId.MAX_MP, updatedValue, true);
    }

    private void UpdateBattlerEffectMaxMagiEnemy(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = num01MaxMagiEnemy.Value;

        // update the battler effect.
        UpdateBattlerEffect(item, BattlerEffectType.BASE, ParameterId.MAX_MP, updatedValue, false);
    }

    private void UpdateBattlerEffectPowerActor(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = num02PowerActor.Value;

        // update the battler effect.
        UpdateBattlerEffect(item, BattlerEffectType.BASE, ParameterId.POWER, updatedValue, true);
    }

    private void UpdateBattlerEffectPowerEnemy(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = num02PowerEnemy.Value;

        // update the battler effect.
        UpdateBattlerEffect(item, BattlerEffectType.BASE, ParameterId.POWER, updatedValue, false);
    }

    private void UpdateBattlerEffectEndureActor(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = num03EndureActor.Value;

        // update the battler effect.
        UpdateBattlerEffect(item, BattlerEffectType.BASE, ParameterId.ENDURANCE, updatedValue, true);
    }

    private void UpdateBattlerEffectEndureEnemy(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = num03EndureEnemy.Value;

        // update the battler effect.
        UpdateBattlerEffect(item, BattlerEffectType.BASE, ParameterId.ENDURANCE, updatedValue, false);
    }

    private void UpdateBattlerEffectForceActor(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = num04ForceActor.Value;

        // update the battler effect.
        UpdateBattlerEffect(item, BattlerEffectType.BASE, ParameterId.FORCE, updatedValue, true);
    }

    private void UpdateBattlerEffectForceEnemy(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = num04ForceEnemy.Value;

        // update the battler effect.
        UpdateBattlerEffect(item, BattlerEffectType.BASE, ParameterId.FORCE, updatedValue, false);
    }

    private void UpdateBattlerEffectResistActor(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = num05ResistActor.Value;

        // update the battler effect.
        UpdateBattlerEffect(item, BattlerEffectType.BASE, ParameterId.RESISTANCE, updatedValue, true);
    }

    private void UpdateBattlerEffectResistEnemy(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = num05ResistEnemy.Value;

        // update the battler effect.
        UpdateBattlerEffect(item, BattlerEffectType.BASE, ParameterId.RESISTANCE, updatedValue, false);
    }

    private void UpdateBattlerEffectSpeedActor(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = num06SpeedActor.Value;

        // update the battler effect.
        UpdateBattlerEffect(item, BattlerEffectType.BASE, ParameterId.SPEED, updatedValue, true);
    }

    private void UpdateBattlerEffectSpeedEnemy(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = num06SpeedEnemy.Value;

        // update the battler effect.
        UpdateBattlerEffect(item, BattlerEffectType.BASE, ParameterId.SPEED, updatedValue, false);
    }

    private void UpdateBattlerEffectLuckActor(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = num07LuckActor.Value;

        // update the battler effect.
        UpdateBattlerEffect(item, BattlerEffectType.BASE, ParameterId.LUCK, updatedValue, true);
    }

    private void UpdateBattlerEffectLuckEnemy(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = num07LuckEnemy.Value;

        // update the battler effect.
        UpdateBattlerEffect(item, BattlerEffectType.BASE, ParameterId.LUCK, updatedValue, false);
    }
    #endregion

    #region xparam updates
    private void UpdateBattlerEffectAccuracyActor(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = num00AccuracyActor.Value;

        // update the battler effect.
        UpdateBattlerEffect(item, BattlerEffectType.EX, ExParameterId.ACCURACY, updatedValue, true);
    }

    private void UpdateBattlerEffectAccuracyEnemy(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = num00AccuracyEnemy.Value;

        // update the battler effect.
        UpdateBattlerEffect(item, BattlerEffectType.EX, ExParameterId.ACCURACY, updatedValue, false);
    }

    private void UpdateBattlerEffectPhysEvadeActor(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = num01PhysEvadeActor.Value;

        // update the battler effect.
        UpdateBattlerEffect(item, BattlerEffectType.EX, ExParameterId.PHYSICAL_EVASION, updatedValue, true);
    }

    private void UpdateBattlerEffectPhysEvadeEnemy(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = num01PhysEvadeEnemy.Value;

        // update the battler effect.
        UpdateBattlerEffect(item, BattlerEffectType.EX, ExParameterId.PHYSICAL_EVASION, updatedValue, false);
    }

    private void UpdateBattlerEffectCritChanceActor(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = num02CritChanceActor.Value;

        // update the battler effect.
        UpdateBattlerEffect(item, BattlerEffectType.EX, ExParameterId.CRITICAL_CHANCE, updatedValue, true);
    }

    private void UpdateBattlerEffectCritChanceEnemy(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = num02CritChanceEnemy.Value;

        // update the battler effect.
        UpdateBattlerEffect(item, BattlerEffectType.EX, ExParameterId.CRITICAL_CHANCE, updatedValue, false);
    }

    private void UpdateBattlerEffectCritEvadeActor(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = num03CritEvadeActor.Value;

        // update the battler effect.
        UpdateBattlerEffect(item, BattlerEffectType.EX, ExParameterId.CRITICAL_EVASION, updatedValue, true);
    }

    private void UpdateBattlerEffectCritEvadeEnemy(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = num03CritEvadeEnemy.Value;

        // update the battler effect.
        UpdateBattlerEffect(item, BattlerEffectType.EX, ExParameterId.CRITICAL_EVASION, updatedValue, false);
    }

    private void UpdateBattlerEffectMagiEvadeActor(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = num04MagiEvadeActor.Value;

        // update the battler effect.
        UpdateBattlerEffect(item, BattlerEffectType.EX, ExParameterId.MAGICAL_EVASION, updatedValue, true);
    }

    private void UpdateBattlerEffectMagiEvadeEnemy(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = num04MagiEvadeEnemy.Value;

        // update the battler effect.
        UpdateBattlerEffect(item, BattlerEffectType.EX, ExParameterId.MAGICAL_EVASION, updatedValue, false);
    }

    private void UpdateBattlerEffectMagiReflectActor(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = num05MagiReflectActor.Value;

        // update the battler effect.
        UpdateBattlerEffect(item, BattlerEffectType.EX, ExParameterId.MAGICAL_REFLECT, updatedValue, true);
    }

    private void UpdateBattlerEffectMagiReflectEnemy(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = num05MagiReflectEnemy.Value;

        // update the battler effect.
        UpdateBattlerEffect(item, BattlerEffectType.EX, ExParameterId.MAGICAL_REFLECT, updatedValue, false);
    }

    private void UpdateBattlerEffectCounterActor(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = num06CounterActor.Value;

        // update the battler effect.
        UpdateBattlerEffect(item, BattlerEffectType.EX, ExParameterId.COUNTER_CHANCE, updatedValue, true);
    }

    private void UpdateBattlerEffectCounterEnemy(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = num06CounterEnemy.Value;

        // update the battler effect.
        UpdateBattlerEffect(item, BattlerEffectType.EX, ExParameterId.COUNTER_CHANCE, updatedValue, false);
    }

    private void UpdateBattlerEffectLifeRegenActor(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = num07LifeRegenActor.Value;

        // update the battler effect.
        UpdateBattlerEffect(item, BattlerEffectType.EX, ExParameterId.LIFE_REGEN, updatedValue, true);
    }

    private void UpdateBattlerEffectLifeRegenEnemy(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = num07LifeRegenEnemy.Value;

        // update the battler effect.
        UpdateBattlerEffect(item, BattlerEffectType.EX, ExParameterId.LIFE_REGEN, updatedValue, false);
    }

    private void UpdateBattlerEffectMagiRegenActor(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = num08MagiRegenActor.Value;

        // update the battler effect.
        UpdateBattlerEffect(item, BattlerEffectType.EX, ExParameterId.MAGI_REGEN, updatedValue, true);
    }

    private void UpdateBattlerEffectMagiRegenEnemy(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = num08MagiRegenEnemy.Value;

        // update the battler effect.
        UpdateBattlerEffect(item, BattlerEffectType.EX, ExParameterId.MAGI_REGEN, updatedValue, false);
    }

    private void UpdateBattlerEffectTechRegenActor(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = num09TechRegenActor.Value;

        // update the battler effect.
        UpdateBattlerEffect(item, BattlerEffectType.EX, ExParameterId.TECH_REGEN, updatedValue, true);
    }

    private void UpdateBattlerEffectTechRegenEnemy(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = num09TechRegenEnemy.Value;

        // update the battler effect.
        UpdateBattlerEffect(item, BattlerEffectType.EX, ExParameterId.TECH_REGEN, updatedValue, false);
    }
    #endregion

    #region sparam updates
    private void UpdateBattlerEffectAggroActor(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = num00AggroActor.Value;

        // update the battler effect.
        UpdateBattlerEffect(item, BattlerEffectType.SP, SpParameterId.AGGRO, updatedValue, true);
    }

    private void UpdateBattlerEffectAggroEnemy(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = num00AggroEnemy.Value;

        // update the battler effect.
        UpdateBattlerEffect(item, BattlerEffectType.SP, SpParameterId.AGGRO, updatedValue, false);
    }

    private void UpdateBattlerEffectParryActor(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = num01ParryActor.Value;

        // update the battler effect.
        UpdateBattlerEffect(item, BattlerEffectType.SP, SpParameterId.PARRY, updatedValue, true);
    }

    private void UpdateBattlerEffectParryEnemy(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = num01ParryEnemy.Value;

        // update the battler effect.
        UpdateBattlerEffect(item, BattlerEffectType.SP, SpParameterId.PARRY, updatedValue, false);
    }

    private void UpdateBattlerEffectHealingActor(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = num02HealingActor.Value;

        // update the battler effect.
        UpdateBattlerEffect(item, BattlerEffectType.SP, SpParameterId.HEALING, updatedValue, true);
    }

    private void UpdateBattlerEffectHealingEnemy(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = num02HealingEnemy.Value;

        // update the battler effect.
        UpdateBattlerEffect(item, BattlerEffectType.SP, SpParameterId.HEALING, updatedValue, false);
    }

    private void UpdateBattlerEffectItemEffectsActor(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = num03ItemEffectsActor.Value;

        // update the battler effect.
        UpdateBattlerEffect(item, BattlerEffectType.SP, SpParameterId.ITEM_EFFECTS, updatedValue, true);
    }

    private void UpdateBattlerEffectItemEffectsEnemy(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = num03ItemEffectsEnemy.Value;

        // update the battler effect.
        UpdateBattlerEffect(item, BattlerEffectType.SP, SpParameterId.ITEM_EFFECTS, updatedValue, false);
    }

    private void UpdateBattlerEffectMagiCostActor(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = num04MagiCostActor.Value;

        // update the battler effect.
        UpdateBattlerEffect(item, BattlerEffectType.SP, SpParameterId.MAGI_COST, updatedValue, true);
    }

    private void UpdateBattlerEffectMagiCostEnemy(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = num04MagiCostEnemy.Value;

        // update the battler effect.
        UpdateBattlerEffect(item, BattlerEffectType.SP, SpParameterId.MAGI_COST, updatedValue, false);
    }

    private void UpdateBattlerEffectTechCostActor(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = num05TechCostActor.Value;

        // update the battler effect.
        UpdateBattlerEffect(item, BattlerEffectType.SP, SpParameterId.TECH_COST, updatedValue, true);
    }

    private void UpdateBattlerEffectTechCostEnemy(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = num05TechCostEnemy.Value;

        // update the battler effect.
        UpdateBattlerEffect(item, BattlerEffectType.SP, SpParameterId.TECH_COST, updatedValue, false);
    }

    private void UpdateBattlerEffectPhysDamageActor(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = num06PhysDamageActor.Value;

        // update the battler effect.
        UpdateBattlerEffect(item, BattlerEffectType.SP, SpParameterId.PHYSICAL_DMG_RATE, updatedValue, true);
    }

    private void UpdateBattlerEffectPhysDamageEnemy(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = num06PhysDamageEnemy.Value;

        // update the battler effect.
        UpdateBattlerEffect(item, BattlerEffectType.SP, SpParameterId.PHYSICAL_DMG_RATE, updatedValue, false);
    }

    private void UpdateBattlerEffectMagiDamageActor(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = num07MagiDamageActor.Value;

        // update the battler effect.
        UpdateBattlerEffect(item, BattlerEffectType.SP, SpParameterId.MAGICAL_DMG_RATE, updatedValue, true);
    }

    private void UpdateBattlerEffectMagiDamageEnemy(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = num07MagiDamageEnemy.Value;

        // update the battler effect.
        UpdateBattlerEffect(item, BattlerEffectType.SP, SpParameterId.MAGICAL_DMG_RATE, updatedValue, false);
    }

    private void UpdateBattlerEffectEnvironDamageActor(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = num08EnvironDamageActor.Value;

        // update the battler effect.
        UpdateBattlerEffect(item, BattlerEffectType.SP, SpParameterId.ENVIRON_DMG_RATE, updatedValue, true);
    }

    private void UpdateBattlerEffectEnvironDamageEnemy(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = num08EnvironDamageEnemy.Value;

        // update the battler effect.
        UpdateBattlerEffect(item, BattlerEffectType.SP, SpParameterId.ENVIRON_DMG_RATE, updatedValue, false);
    }

    private void UpdateBattlerEffectExperienceActor(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = num09ExperienceRateActor.Value;

        // update the battler effect.
        UpdateBattlerEffect(item, BattlerEffectType.SP, SpParameterId.EXPERIENCE, updatedValue, true);
    }

    private void UpdateBattlerEffectExperienceEnemy(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = num09ExperienceRateEnemy.Value;

        // update the battler effect.
        UpdateBattlerEffect(item, BattlerEffectType.SP, SpParameterId.EXPERIENCE, updatedValue, false);
    }
    #endregion

    #region custom param updates
    private void UpdateBattlerEffectMaxTechActor(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = num28MaxTechActor.Value;

        // update the battler effect.
        UpdateBattlerEffect(item, BattlerEffectType.CUSTOM, CustomParameterId.MAX_TECH, updatedValue, true);
    }

    private void UpdateBattlerEffectMaxTechEnemy(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = num28MaxTechEnemy.Value;

        // update the battler effect.
        UpdateBattlerEffect(item, BattlerEffectType.CUSTOM, CustomParameterId.MAX_TECH, updatedValue, false);
    }
    #endregion
    #endregion

    #region reward updates
    private void UpdateRewardExperience(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // update with the new value.
        item.Rewards.Experience = decimal.ToInt32(numRewardExperience.Value);
    }

    private void UpdateRewardGold(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // update with the new value.
        item.Rewards.Gold = decimal.ToInt32(numRewardGold.Value);
    }

    private void UpdateRewardDrops(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // update with the new value.
        item.Rewards.Drops = decimal.ToInt32(numRewardDrops.Value);
    }

    private void UpdateRewardEncounters(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // update with the new value.
        item.Rewards.Encounters = decimal.ToInt32(numRewardEncounters.Value);
    }

    private void UpdateRewardSdp(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // update with the new value.
        item.Rewards.SdpPoints = decimal.ToInt32(numRewardSdp.Value);
    }
    #endregion

    private void UpdateBattlerEffect(
        DifficultyMetadata difficultyMetadata,
        BattlerEffectType type,
        int index,
        decimal rawValue,
        bool isActor)
    {
        // determine which battler effects are relevant.
        var battlerEffects = isActor
            ? difficultyMetadata.ActorEffects
            : difficultyMetadata.EnemyEffects;

        // parse the value into a regular int.
        var value = decimal.ToInt32(rawValue);

        // pivot on the type of parameter being updated.
        switch (type)
        {
            case BattlerEffectType.BASE:
                battlerEffects.bparams[index] = value;
                break;
            case BattlerEffectType.EX:
                battlerEffects.xparams[index] = value;
                break;
            case BattlerEffectType.SP:
                battlerEffects.sparams[index] = value;
                break;
            case BattlerEffectType.CUSTOM:
                battlerEffects.cparams[index] = value;
                // TODO: handle management for custom parameters in the battler effects.
                break;
        }
    }
    #endregion
}
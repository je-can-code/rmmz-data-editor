using JMZ.Difficulty.Data.Models;
using JMZ.Rmmz.Data.Models;

namespace JMZ.Dashboard.Boards;

/// <summary>
/// The part of this class that contains all the update logic.
/// </summary>
public partial class DifficultyBoard
{
    private void ApplyUpdateEvents()
    {
        this.ApplyUpdateEventsForCoreData();
        this.ApplyUpdateEventsForBattlerEffectsData();

        this.listboxDifficultyLayers.SelectedIndexChanged += this.RefreshForm;
    }
    
    private void ApplyUpdateEventsForCoreData()
    {
        this.textboxKey.TextChanged += this.UpdateKey;
        this.textboxName.TextChanged += this.UpdateName;
        this.textBoxDescription.TextChanged += this.UpdateDescription;
        this.numIconIndex.ValueChanged += this.UpdateIconIndex;
        this.checkboxUnlockedByDefault.CheckedChanged += this.UpdateUnlockedByDefault;
        this.checkboxEnabledByDefault.CheckedChanged += this.UpdateEnabledByDefault;
        this.checkboxHiddenByDefault.CheckedChanged += this.UpdateHiddenByDefault;
    }

    private void ApplyUpdateEventsForBattlerEffectsData()
    {
        this.ApplyUpdateEventsForBParamBattlerEffects();
        this.ApplyUpdateEventsForXParamBattlerEffects();
        this.ApplyUpdateEventsForSParamBattlerEffects();
        
        this.ApplyUpdateEventsForCustomParamBattlerEffects();
    }

    private void ApplyUpdateEventsForBParamBattlerEffects()
    {
        this.num00MaxLifeActor.ValueChanged += this.UpdateBattlerEffectMaxLifeActor;
        this.num01MaxMagiActor.ValueChanged += this.UpdateBattlerEffectMaxMagiActor;
        this.num02PowerActor.ValueChanged += this.UpdateBattlerEffectPowerActor;
        this.num03EndureActor.ValueChanged += this.UpdateBattlerEffectEndureActor;
        this.num04ForceActor.ValueChanged += this.UpdateBattlerEffectForceActor;
        this.num05ResistActor.ValueChanged += this.UpdateBattlerEffectResistActor;
        this.num06SpeedActor.ValueChanged += this.UpdateBattlerEffectSpeedActor;
        this.num07LuckActor.ValueChanged += this.UpdateBattlerEffectLuckActor;

        this.num00MaxLifeEnemy.ValueChanged += this.UpdateBattlerEffectMaxLifeEnemy;
        this.num01MaxMagiEnemy.ValueChanged += this.UpdateBattlerEffectMaxMagiEnemy;
        this.num02PowerEnemy.ValueChanged += this.UpdateBattlerEffectPowerEnemy;
        this.num03EndureEnemy.ValueChanged += this.UpdateBattlerEffectEndureEnemy;
        this.num04ForceEnemy.ValueChanged += this.UpdateBattlerEffectForceEnemy;
        this.num05ResistEnemy.ValueChanged += this.UpdateBattlerEffectResistEnemy;
        this.num06SpeedEnemy.ValueChanged += this.UpdateBattlerEffectSpeedEnemy;
        this.num07LuckEnemy.ValueChanged += this.UpdateBattlerEffectLuckEnemy;
    }

    private void ApplyUpdateEventsForXParamBattlerEffects()
    {
        this.num00AccuracyActor.ValueChanged += this.UpdateBattlerEffectAccuracyActor;
        this.num01PhysEvadeActor.ValueChanged += this.UpdateBattlerEffectPhysEvadeActor;
        this.num02CritChanceActor.ValueChanged += this.UpdateBattlerEffectCritChanceActor;
        this.num03CritEvadeActor.ValueChanged += this.UpdateBattlerEffectCritEvadeActor;
        this.num04MagiEvadeActor.ValueChanged += this.UpdateBattlerEffectMagiEvadeActor;
        this.num05MagiReflectActor.ValueChanged += this.UpdateBattlerEffectMagiReflectActor;
        this.num06CounterActor.ValueChanged += this.UpdateBattlerEffectCounterActor;
        this.num07LifeRegenActor.ValueChanged += this.UpdateBattlerEffectLifeRegenActor;
        this.num08MagiRegenActor.ValueChanged += this.UpdateBattlerEffectMagiRegenActor;
        this.num09TechRegenActor.ValueChanged += this.UpdateBattlerEffectTechRegenActor;
        
        this.num00AccuracyEnemy.ValueChanged += this.UpdateBattlerEffectAccuracyEnemy;
        this.num01PhysEvadeEnemy.ValueChanged += this.UpdateBattlerEffectPhysEvadeEnemy;
        this.num02CritChanceEnemy.ValueChanged += this.UpdateBattlerEffectCritChanceEnemy;
        this.num03CritEvadeEnemy.ValueChanged += this.UpdateBattlerEffectCritEvadeEnemy;
        this.num04MagiEvadeEnemy.ValueChanged += this.UpdateBattlerEffectMagiEvadeEnemy;
        this.num05MagiReflectEnemy.ValueChanged += this.UpdateBattlerEffectMagiReflectEnemy;
        this.num06CounterEnemy.ValueChanged += this.UpdateBattlerEffectCounterEnemy;
        this.num07LifeRegenEnemy.ValueChanged += this.UpdateBattlerEffectLifeRegenEnemy;
        this.num08MagiRegenEnemy.ValueChanged += this.UpdateBattlerEffectMagiRegenEnemy;
        this.num09TechRegenEnemy.ValueChanged += this.UpdateBattlerEffectTechRegenEnemy;
    }
    
    private void ApplyUpdateEventsForSParamBattlerEffects()
    {
        this.num00AggroActor.ValueChanged += this.UpdateBattlerEffectAggroActor;
        this.num01ParryActor.ValueChanged += this.UpdateBattlerEffectParryActor;
        this.num02HealingActor.ValueChanged += this.UpdateBattlerEffectHealingActor;
        this.num03ItemEffectsActor.ValueChanged += this.UpdateBattlerEffectItemEffectsActor;
        this.num04MagiCostActor.ValueChanged += this.UpdateBattlerEffectMagiCostActor;
        this.num05TechCostActor.ValueChanged += this.UpdateBattlerEffectTechCostActor;
        this.num06PhysDamageActor.ValueChanged += this.UpdateBattlerEffectPhysDamageActor;
        this.num07MagiDamageActor.ValueChanged += this.UpdateBattlerEffectMagiDamageActor;
        this.num08EnvironDamageActor.ValueChanged += this.UpdateBattlerEffectEnvironDamageActor;
        this.num09ExperienceRateActor.ValueChanged += this.UpdateBattlerEffectExperienceActor;
        
        this.num00AggroEnemy.ValueChanged += this.UpdateBattlerEffectAggroEnemy;
        this.num01ParryEnemy.ValueChanged += this.UpdateBattlerEffectParryEnemy;
        this.num02HealingEnemy.ValueChanged += this.UpdateBattlerEffectHealingEnemy;
        this.num03ItemEffectsEnemy.ValueChanged += this.UpdateBattlerEffectItemEffectsEnemy;
        this.num04MagiCostEnemy.ValueChanged += this.UpdateBattlerEffectMagiCostEnemy;
        this.num05TechCostEnemy.ValueChanged += this.UpdateBattlerEffectTechCostEnemy;
        this.num06PhysDamageEnemy.ValueChanged += this.UpdateBattlerEffectPhysDamageEnemy;
        this.num07MagiDamageEnemy.ValueChanged += this.UpdateBattlerEffectMagiDamageEnemy;
        this.num08EnvironDamageEnemy.ValueChanged += this.UpdateBattlerEffectEnvironDamageEnemy;
        this.num09ExperienceRateEnemy.ValueChanged += this.UpdateBattlerEffectExperienceEnemy;
    }

    private void ApplyUpdateEventsForCustomParamBattlerEffects()
    {
        this.num28MaxTechActor.ValueChanged += this.UpdateBattlerEffectMaxTechActor;
        
        this.num28MaxTechEnemy.ValueChanged += this.UpdateBattlerEffectMaxTechEnemy;
    }
    
    #region update
    #region core updates
    private void UpdateKey(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)this.listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // update with the new value.
        item.Key = this.textboxKey.Text;
    }
    
    private void UpdateName(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)this.listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // update the name with the new value.
        item.Name = this.textboxName.Text;

        // the name is special in that it needs to be synced with the list to ensure name updates apply.
        this.listboxDifficultyLayers.Items[this.listboxDifficultyLayers.SelectedIndex] = item;
    }
    
    private void UpdateDescription(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)this.listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // update the name with the new value.
        item.Description = this.textBoxDescription.Text;
    }
    
    private void UpdateIconIndex(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)this.listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // update with the new value.
        item.IconIndex = (int)this.numIconIndex.Value;
    }
    
    private void UpdateUnlockedByDefault(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)this.listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // update with the new value.
        item.UnlockedByDefault = this.checkboxUnlockedByDefault.Checked;
    }
    
    private void UpdateEnabledByDefault(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)this.listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // update with the new value.
        item.EnabledByDefault = this.checkboxEnabledByDefault.Checked;
    }
    
    private void UpdateHiddenByDefault(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)this.listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // update with the new value.
        item.HiddenByDefault = this.checkboxHiddenByDefault.Checked;
    }
    #endregion
    
    #region effects updates
    #region bparam updates
    private void UpdateBattlerEffectMaxLifeActor(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)this.listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = this.num00MaxLifeActor.Value;

        // update the battler effect.
        this.UpdateBattlerEffect(
            item,
            BattlerEffectType.BASE,
            ParameterId.MAX_HP,
            updatedValue,
            true);
    }
    
    private void UpdateBattlerEffectMaxLifeEnemy(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)this.listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = this.num00MaxLifeEnemy.Value;

        // update the battler effect.
        this.UpdateBattlerEffect(
            item,
            BattlerEffectType.BASE,
            ParameterId.MAX_HP,
            updatedValue,
            false);
    }
    
    private void UpdateBattlerEffectMaxMagiActor(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)this.listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = this.num01MaxMagiActor.Value;

        // update the battler effect.
        this.UpdateBattlerEffect(
            item,
            BattlerEffectType.BASE,
            ParameterId.MAX_MP,
            updatedValue,
            true);
    }
    
    private void UpdateBattlerEffectMaxMagiEnemy(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)this.listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = this.num01MaxMagiEnemy.Value;

        // update the battler effect.
        this.UpdateBattlerEffect(
            item,
            BattlerEffectType.BASE,
            ParameterId.MAX_MP,
            updatedValue,
            false);
    }
    
    private void UpdateBattlerEffectPowerActor(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)this.listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = this.num02PowerActor.Value;

        // update the battler effect.
        this.UpdateBattlerEffect(
            item,
            BattlerEffectType.BASE,
            ParameterId.POWER,
            updatedValue,
            true);
    }
    
    private void UpdateBattlerEffectPowerEnemy(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)this.listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = this.num02PowerEnemy.Value;

        // update the battler effect.
        this.UpdateBattlerEffect(
            item,
            BattlerEffectType.BASE,
            ParameterId.POWER,
            updatedValue,
            false);
    }
    
    private void UpdateBattlerEffectEndureActor(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)this.listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = this.num03EndureActor.Value;

        // update the battler effect.
        this.UpdateBattlerEffect(
            item,
            BattlerEffectType.BASE,
            ParameterId.ENDURANCE,
            updatedValue,
            true);
    }
    
    private void UpdateBattlerEffectEndureEnemy(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)this.listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = this.num03EndureEnemy.Value;

        // update the battler effect.
        this.UpdateBattlerEffect(
            item,
            BattlerEffectType.BASE,
            ParameterId.ENDURANCE,
            updatedValue,
            false);
    }
    
    private void UpdateBattlerEffectForceActor(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)this.listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = this.num04ForceActor.Value;

        // update the battler effect.
        this.UpdateBattlerEffect(
            item,
            BattlerEffectType.BASE,
            ParameterId.FORCE,
            updatedValue,
            true);
    }
    
    private void UpdateBattlerEffectForceEnemy(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)this.listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = this.num04ForceEnemy.Value;

        // update the battler effect.
        this.UpdateBattlerEffect(
            item,
            BattlerEffectType.BASE,
            ParameterId.FORCE,
            updatedValue,
            false);
    }
    
    private void UpdateBattlerEffectResistActor(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)this.listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = this.num05ResistActor.Value;

        // update the battler effect.
        this.UpdateBattlerEffect(
            item,
            BattlerEffectType.BASE,
            ParameterId.RESISTANCE,
            updatedValue,
            true);
    }
    
    private void UpdateBattlerEffectResistEnemy(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)this.listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = this.num05ResistEnemy.Value;

        // update the battler effect.
        this.UpdateBattlerEffect(
            item,
            BattlerEffectType.BASE,
            ParameterId.RESISTANCE,
            updatedValue,
            false);
    }
    
    private void UpdateBattlerEffectSpeedActor(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)this.listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = this.num06SpeedActor.Value;

        // update the battler effect.
        this.UpdateBattlerEffect(
            item,
            BattlerEffectType.BASE,
            ParameterId.SPEED,
            updatedValue,
            true);
    }
    
    private void UpdateBattlerEffectSpeedEnemy(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)this.listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = this.num06SpeedEnemy.Value;

        // update the battler effect.
        this.UpdateBattlerEffect(
            item,
            BattlerEffectType.BASE,
            ParameterId.SPEED,
            updatedValue,
            false);
    }
    
    private void UpdateBattlerEffectLuckActor(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)this.listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = this.num07LuckActor.Value;

        // update the battler effect.
        this.UpdateBattlerEffect(
            item,
            BattlerEffectType.BASE,
            ParameterId.LUCK,
            updatedValue,
            true);
    }
    
    private void UpdateBattlerEffectLuckEnemy(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)this.listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = this.num07LuckEnemy.Value;

        // update the battler effect.
        this.UpdateBattlerEffect(
            item,
            BattlerEffectType.BASE,
            ParameterId.LUCK,
            updatedValue,
            false);
    }
    #endregion
    
    #region xparam updates
    private void UpdateBattlerEffectAccuracyActor(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)this.listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = this.num00AccuracyActor.Value;

        // update the battler effect.
        this.UpdateBattlerEffect(
            item,
            BattlerEffectType.EX,
            ExParameterId.ACCURACY,
            updatedValue,
            true);
    }
    
    private void UpdateBattlerEffectAccuracyEnemy(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)this.listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = this.num00AccuracyEnemy.Value;

        // update the battler effect.
        this.UpdateBattlerEffect(
            item,
            BattlerEffectType.EX,
            ExParameterId.ACCURACY,
            updatedValue,
            false);
    }
    
    private void UpdateBattlerEffectPhysEvadeActor(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)this.listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = this.num01PhysEvadeActor.Value;

        // update the battler effect.
        this.UpdateBattlerEffect(
            item,
            BattlerEffectType.EX,
            ExParameterId.PHYSICAL_EVASION,
            updatedValue,
            true);
    }
    
    private void UpdateBattlerEffectPhysEvadeEnemy(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)this.listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = this.num01PhysEvadeEnemy.Value;

        // update the battler effect.
        this.UpdateBattlerEffect(
            item,
            BattlerEffectType.EX,
            ExParameterId.PHYSICAL_EVASION,
            updatedValue,
            false);
    }
    
    private void UpdateBattlerEffectCritChanceActor(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)this.listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = this.num02CritChanceActor.Value;

        // update the battler effect.
        this.UpdateBattlerEffect(
            item,
            BattlerEffectType.EX,
            ExParameterId.CRITICAL_CHANCE,
            updatedValue,
            true);
    }
    
    private void UpdateBattlerEffectCritChanceEnemy(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)this.listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = this.num02CritChanceEnemy.Value;

        // update the battler effect.
        this.UpdateBattlerEffect(
            item,
            BattlerEffectType.EX,
            ExParameterId.CRITICAL_CHANCE,
            updatedValue,
            false);
    }
    
    private void UpdateBattlerEffectCritEvadeActor(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)this.listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = this.num03CritEvadeActor.Value;

        // update the battler effect.
        this.UpdateBattlerEffect(
            item,
            BattlerEffectType.EX,
            ExParameterId.CRITICAL_EVASION,
            updatedValue,
            true);
    }
    
    private void UpdateBattlerEffectCritEvadeEnemy(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)this.listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = this.num03CritEvadeEnemy.Value;

        // update the battler effect.
        this.UpdateBattlerEffect(
            item,
            BattlerEffectType.EX,
            ExParameterId.CRITICAL_EVASION,
            updatedValue,
            false);
    }
    
    private void UpdateBattlerEffectMagiEvadeActor(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)this.listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = this.num04MagiEvadeActor.Value;

        // update the battler effect.
        this.UpdateBattlerEffect(
            item,
            BattlerEffectType.EX,
            ExParameterId.MAGICAL_EVASION,
            updatedValue,
            true);
    }
    
    private void UpdateBattlerEffectMagiEvadeEnemy(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)this.listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = this.num04MagiEvadeEnemy.Value;

        // update the battler effect.
        this.UpdateBattlerEffect(
            item,
            BattlerEffectType.EX,
            ExParameterId.MAGICAL_EVASION,
            updatedValue,
            false);
    }
    
    private void UpdateBattlerEffectMagiReflectActor(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)this.listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = this.num05MagiReflectActor.Value;

        // update the battler effect.
        this.UpdateBattlerEffect(
            item,
            BattlerEffectType.EX,
            ExParameterId.MAGICAL_REFLECT,
            updatedValue,
            true);
    }
    
    private void UpdateBattlerEffectMagiReflectEnemy(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)this.listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = this.num05MagiReflectEnemy.Value;

        // update the battler effect.
        this.UpdateBattlerEffect(
            item,
            BattlerEffectType.EX,
            ExParameterId.MAGICAL_REFLECT,
            updatedValue,
            false);
    }
    
    private void UpdateBattlerEffectCounterActor(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)this.listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = this.num06CounterActor.Value;

        // update the battler effect.
        this.UpdateBattlerEffect(
            item,
            BattlerEffectType.EX,
            ExParameterId.COUNTER_CHANCE,
            updatedValue,
            true);
    }
    
    private void UpdateBattlerEffectCounterEnemy(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)this.listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = this.num06CounterEnemy.Value;

        // update the battler effect.
        this.UpdateBattlerEffect(
            item,
            BattlerEffectType.EX,
            ExParameterId.COUNTER_CHANCE,
            updatedValue,
            false);
    }
    
    private void UpdateBattlerEffectLifeRegenActor(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)this.listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = this.num07LifeRegenActor.Value;

        // update the battler effect.
        this.UpdateBattlerEffect(
            item,
            BattlerEffectType.EX,
            ExParameterId.LIFE_REGEN,
            updatedValue,
            true);
    }
    
    private void UpdateBattlerEffectLifeRegenEnemy(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)this.listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = this.num07LifeRegenEnemy.Value;

        // update the battler effect.
        this.UpdateBattlerEffect(
            item,
            BattlerEffectType.EX,
            ExParameterId.LIFE_REGEN,
            updatedValue,
            false);
    }
    
    private void UpdateBattlerEffectMagiRegenActor(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)this.listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = this.num08MagiRegenActor.Value;

        // update the battler effect.
        this.UpdateBattlerEffect(
            item,
            BattlerEffectType.EX,
            ExParameterId.MAGI_REGEN,
            updatedValue,
            true);
    }
    
    private void UpdateBattlerEffectMagiRegenEnemy(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)this.listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = this.num08MagiRegenEnemy.Value;

        // update the battler effect.
        this.UpdateBattlerEffect(
            item,
            BattlerEffectType.EX,
            ExParameterId.MAGI_REGEN,
            updatedValue,
            false);
    }
    
    private void UpdateBattlerEffectTechRegenActor(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)this.listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = this.num09TechRegenActor.Value;

        // update the battler effect.
        this.UpdateBattlerEffect(
            item,
            BattlerEffectType.EX,
            ExParameterId.TECH_REGEN,
            updatedValue,
            true);
    }
    
    private void UpdateBattlerEffectTechRegenEnemy(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)this.listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = this.num09TechRegenEnemy.Value;

        // update the battler effect.
        this.UpdateBattlerEffect(
            item,
            BattlerEffectType.EX,
            ExParameterId.TECH_REGEN,
            updatedValue,
            false);
    }
    #endregion
    
    #region sparam updates
    private void UpdateBattlerEffectAggroActor(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)this.listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = this.num00AggroActor.Value;

        // update the battler effect.
        this.UpdateBattlerEffect(
            item,
            BattlerEffectType.SP,
            SpParameterId.AGGRO,
            updatedValue,
            true);
    }
    
    private void UpdateBattlerEffectAggroEnemy(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)this.listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = this.num00AggroEnemy.Value;

        // update the battler effect.
        this.UpdateBattlerEffect(
            item,
            BattlerEffectType.SP,
            SpParameterId.AGGRO,
            updatedValue,
            false);
    }
    
    private void UpdateBattlerEffectParryActor(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)this.listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = this.num01ParryActor.Value;

        // update the battler effect.
        this.UpdateBattlerEffect(
            item,
            BattlerEffectType.SP,
            SpParameterId.PARRY,
            updatedValue,
            true);
    }
    
    private void UpdateBattlerEffectParryEnemy(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)this.listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = this.num01ParryEnemy.Value;

        // update the battler effect.
        this.UpdateBattlerEffect(
            item,
            BattlerEffectType.SP,
            SpParameterId.PARRY,
            updatedValue,
            false);
    }
    
    private void UpdateBattlerEffectHealingActor(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)this.listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = this.num02HealingActor.Value;

        // update the battler effect.
        this.UpdateBattlerEffect(
            item,
            BattlerEffectType.SP,
            SpParameterId.HEALING,
            updatedValue,
            true);
    }
    
    private void UpdateBattlerEffectHealingEnemy(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)this.listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = this.num02HealingEnemy.Value;

        // update the battler effect.
        this.UpdateBattlerEffect(
            item,
            BattlerEffectType.SP,
            SpParameterId.HEALING,
            updatedValue,
            false);
    }
    
    private void UpdateBattlerEffectItemEffectsActor(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)this.listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = this.num03ItemEffectsActor.Value;

        // update the battler effect.
        this.UpdateBattlerEffect(
            item,
            BattlerEffectType.SP,
            SpParameterId.ITEM_EFFECTS,
            updatedValue,
            true);
    }
    
    private void UpdateBattlerEffectItemEffectsEnemy(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)this.listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = this.num03ItemEffectsEnemy.Value;

        // update the battler effect.
        this.UpdateBattlerEffect(
            item,
            BattlerEffectType.SP,
            SpParameterId.ITEM_EFFECTS,
            updatedValue,
            false);
    }
    
    private void UpdateBattlerEffectMagiCostActor(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)this.listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = this.num04MagiCostActor.Value;

        // update the battler effect.
        this.UpdateBattlerEffect(
            item,
            BattlerEffectType.SP,
            SpParameterId.MAGI_COST,
            updatedValue,
            true);
    }
    
    private void UpdateBattlerEffectMagiCostEnemy(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)this.listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = this.num04MagiCostEnemy.Value;

        // update the battler effect.
        this.UpdateBattlerEffect(
            item,
            BattlerEffectType.SP,
            SpParameterId.MAGI_COST,
            updatedValue,
            false);
    }
    
    private void UpdateBattlerEffectTechCostActor(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)this.listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = this.num05TechCostActor.Value;

        // update the battler effect.
        this.UpdateBattlerEffect(
            item,
            BattlerEffectType.SP,
            SpParameterId.TECH_COST,
            updatedValue,
            true);
    }
    
    private void UpdateBattlerEffectTechCostEnemy(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)this.listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = this.num05TechCostEnemy.Value;

        // update the battler effect.
        this.UpdateBattlerEffect(
            item,
            BattlerEffectType.SP,
            SpParameterId.TECH_COST,
            updatedValue,
            false);
    }
    
    private void UpdateBattlerEffectPhysDamageActor(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)this.listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = this.num06PhysDamageActor.Value;

        // update the battler effect.
        this.UpdateBattlerEffect(
            item,
            BattlerEffectType.SP,
            SpParameterId.PHYSICAL_DMG_RATE,
            updatedValue,
            true);
    }
    
    private void UpdateBattlerEffectPhysDamageEnemy(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)this.listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = this.num06PhysDamageEnemy.Value;

        // update the battler effect.
        this.UpdateBattlerEffect(
            item,
            BattlerEffectType.SP,
            SpParameterId.PHYSICAL_DMG_RATE,
            updatedValue,
            false);
    }
    
    private void UpdateBattlerEffectMagiDamageActor(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)this.listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = this.num07MagiDamageActor.Value;

        // update the battler effect.
        this.UpdateBattlerEffect(
            item,
            BattlerEffectType.SP,
            SpParameterId.MAGICAL_DMG_RATE,
            updatedValue,
            true);
    }
    
    private void UpdateBattlerEffectMagiDamageEnemy(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)this.listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = this.num07MagiDamageEnemy.Value;

        // update the battler effect.
        this.UpdateBattlerEffect(
            item,
            BattlerEffectType.SP,
            SpParameterId.MAGICAL_DMG_RATE,
            updatedValue,
            false);
    }
    
    private void UpdateBattlerEffectEnvironDamageActor(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)this.listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = this.num08EnvironDamageActor.Value;

        // update the battler effect.
        this.UpdateBattlerEffect(
            item,
            BattlerEffectType.SP,
            SpParameterId.ENVIRON_DMG_RATE,
            updatedValue,
            true);
    }
    
    private void UpdateBattlerEffectEnvironDamageEnemy(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)this.listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = this.num08EnvironDamageEnemy.Value;

        // update the battler effect.
        this.UpdateBattlerEffect(
            item,
            BattlerEffectType.SP,
            SpParameterId.ENVIRON_DMG_RATE,
            updatedValue,
            false);
    }
    
    private void UpdateBattlerEffectExperienceActor(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)this.listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = this.num09ExperienceRateActor.Value;

        // update the battler effect.
        this.UpdateBattlerEffect(
            item,
            BattlerEffectType.SP,
            SpParameterId.EXPERIENCE,
            updatedValue,
            true);
    }
    
    private void UpdateBattlerEffectExperienceEnemy(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)this.listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = this.num09ExperienceRateEnemy.Value;

        // update the battler effect.
        this.UpdateBattlerEffect(
            item,
            BattlerEffectType.SP,
            SpParameterId.EXPERIENCE,
            updatedValue,
            false);
    }
    #endregion
    
    #region custom param updates
    private void UpdateBattlerEffectMaxTechActor(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)this.listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = this.num28MaxTechActor.Value;

        // update the battler effect.
        this.UpdateBattlerEffect(
            item,
            BattlerEffectType.CUSTOM,
            CustomParameterId.MAX_TECH,
            updatedValue,
            true);
    }
    
    private void UpdateBattlerEffectMaxTechEnemy(object? sender, EventArgs e)
    {
        // determine the selected item.
        var item = (DifficultyMetadata)this.listboxDifficultyLayers.SelectedItem!;

        // don't update if it was null.
        if (item is null) return;

        // identify the new value.
        var updatedValue = this.num28MaxTechEnemy.Value;

        // update the battler effect.
        this.UpdateBattlerEffect(
            item,
            BattlerEffectType.CUSTOM,
            CustomParameterId.MAX_TECH,
            updatedValue,
            false);
    }
    #endregion
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
            ? difficultyMetadata.actorEffects
            : difficultyMetadata.enemyEffects;

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
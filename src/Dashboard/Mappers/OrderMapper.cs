using JMZ.Sdp.Data.Models;

namespace JMZ.Dashboard.Mappers;

public static class OrderMapper
{
    public static Rarity[] ToRarities()
    {
        return
        [
            Rarity.Common,
            Rarity.Magical,
            Rarity.Rare,
            Rarity.Epic,
            Rarity.Legendary,
            Rarity.Godlike
        ];
    }

    public static LongParameter[] ToLongParameters()
    {
        return
        [
            LongParameter.MaxLife,
            LongParameter.HpRegen,
            LongParameter.HealingRate,

            LongParameter.MaxMagi,
            LongParameter.MpRegen,
            LongParameter.MagiCost,
            
            LongParameter.MaxTech,
            LongParameter.TpRegen,
            LongParameter.TechCost,

            LongParameter.Power,
            LongParameter.Endurance,
            LongParameter.PhysDmgRate,
            
            LongParameter.Force,
            LongParameter.Resistance,
            LongParameter.MagiDmgRate,

            LongParameter.Speed,
            LongParameter.MoveBoost,
            LongParameter.LightFooted,
            
            LongParameter.Accuracy,
            LongParameter.Parry,
            LongParameter.ParryExtend, // TODO: revert to EVA and make custom/calculated.

            LongParameter.CritRate,
            LongParameter.CritDodge,
            LongParameter.CritAmp,
            LongParameter.CritBlock,
            
            LongParameter.MagicEvade,
            LongParameter.MagicReflect,
            LongParameter.Autocounter,
            
            LongParameter.Aggro,
            LongParameter.ItemEffects,
            LongParameter.Luck,
            
            LongParameter.ExperienceUp,
            LongParameter.ProficiencyBoost,
        ];
        // sequential order
        // 
        // [
        //     LongParameter.MaxLife,
        //     LongParameter.MaxMagi,
        //     
        //     LongParameter.Power,
        //     LongParameter.Endurance,
        //     LongParameter.Force,
        //     LongParameter.Resistance,
        //     LongParameter.Speed,
        //     LongParameter.Luck,
        //     
        //     LongParameter.Accuracy,
        //     LongParameter.ParryExtend,
        //     LongParameter.CritRate,
        //     LongParameter.CritDodge,
        //     LongParameter.MagicEvade,
        //     LongParameter.MagicReflect,
        //     LongParameter.Autocounter,
        //     LongParameter.HpRegen,
        //     LongParameter.MpRegen,
        //     LongParameter.TpRegen,
        //     
        //     LongParameter.Aggro,
        //     LongParameter.Parry,
        //     LongParameter.HealingRate,
        //     LongParameter.ItemEffects,
        //     LongParameter.MagiCost,
        //     LongParameter.TechCost,
        //     LongParameter.PhysDmgRate,
        //     LongParameter.MagiDmgRate,
        //     LongParameter.LightFooted,
        //     LongParameter.ExperienceUp,
        //
        //     LongParameter.CritAmp,
        //     LongParameter.CritBlock,
        //     LongParameter.MaxTech,
        //     LongParameter.MoveBoost,
        //     LongParameter.ProficiencyBoost,
        // ];
    }
}
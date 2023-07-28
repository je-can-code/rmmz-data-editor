namespace Rmmz.Data.Models.db._data;

public class RPG_SkillDamage
{
    public bool critical { get; set; } = false;

    public int elementId { get; set; } = -1;

    public string formula { get; set; } = string.Empty;

    public int type { get; set; } = 0;

    public int variance { get; set; } = 0;
}
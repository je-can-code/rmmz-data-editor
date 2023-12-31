/// <summary>
/// A class representing a single action a battler can execute.
/// </summary>
public class RPG_EnemyAction
{
    public int conditionParam1 { get; set; } = 0;

    public int conditionParam2 { get; set; } = 0;

    public int conditionType { get; set; } = 0;

    public int rating { get; set; } = 5;

    public int skillId { get; set; } = 1;
}
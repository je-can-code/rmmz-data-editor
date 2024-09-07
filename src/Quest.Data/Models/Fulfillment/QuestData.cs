namespace JMZ.Quest.Data.Models.Fulfillment;

public record QuestData
{
    public List<string> Keys { get; set; } = [];

    public QuestData(List<string> keys)
    {
        Keys = keys;
    }
}
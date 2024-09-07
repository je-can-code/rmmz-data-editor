namespace JMZ.Quest.Data.Models.Fulfillment;

public record SlayData
{
    public int Id { get; set; }

    public int Amount { get; set; }

    public SlayData(int id, int amount)
    {
        Id = id;
        Amount = amount;
    }
}
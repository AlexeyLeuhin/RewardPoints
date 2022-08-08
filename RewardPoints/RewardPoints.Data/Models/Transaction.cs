namespace RewardPoints.Data.Models;

public class Transaction
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public DateTime Date { get; set; }

    public int Value { get; set; }
}


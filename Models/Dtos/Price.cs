namespace Models.Dtos;

public class EnergyPrice
{
    public required string Source { get; set; }
    public DateTime IntervalStart { get; set; }
    public DateTime IntervalEnd { get; set; }
    public decimal MinPrice { get; set; }
    public decimal MidPrice { get; set; }
    public decimal MaxPrice { get; set; }
}

using Models.Dtos;

namespace Repositories;

public interface IPriceStorage
{
    List<EnergyPrice> GetPrices();
    void AddPrice(EnergyPrice price);
}

public class PriceStorage : IPriceStorage
{
    public List<EnergyPrice> Prices { get; set; }

    public PriceStorage()
    {
        Prices =
        [
            new EnergyPrice
            {
                IntervalStart = DateTime.Parse("2025-02-23T15:12:00Z").ToUniversalTime(),
                IntervalEnd = DateTime.Parse("2025-02-23T15:13:00Z").ToUniversalTime(),
                MinPrice = 29.16m,
                MidPrice = 86.04m,
                MaxPrice = 228.65m,
                Source = "TenneT"
            },
            new EnergyPrice
            {
                IntervalStart = DateTime.Parse("2025-02-23T15:13:00Z").ToUniversalTime(),
                IntervalEnd = DateTime.Parse("2025-02-23T15:14:00Z").ToUniversalTime(),
                MinPrice = 143.24m,
                MidPrice = 249.15m,
                MaxPrice = 1679.28m,
                Source = "TenneT"
            },
            new EnergyPrice
            {
                IntervalStart = DateTime.Parse("2025-02-23T15:14:00Z").ToUniversalTime(),
                IntervalEnd = DateTime.Parse("2025-02-23T15:15:00Z").ToUniversalTime(),
                MinPrice = 26.77m,
                MidPrice = 231.23m,
                MaxPrice = 1564.68m,
                Source = "TenneT"
            }
        ];
    }

    public List<EnergyPrice> GetPrices() => Prices;

    public void AddPrice(EnergyPrice price) => Prices.Add(price);
}


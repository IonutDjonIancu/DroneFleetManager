using Models.Dtos;
using Repositories;

namespace PricingService;

public interface IPricingManager
{
    void FetchAndStorePrice();
}

public class PricingManager : IPricingManager
{
    private readonly IPriceStorage _priceStorage;
    private readonly Random _random = new();

    public PricingManager(IPriceStorage priceStorage)
    {
        _priceStorage = priceStorage;
    }

    // we are going to fake the api call from TenneT
    public void FetchAndStorePrice()
    {
        var now = DateTime.UtcNow;
        var price = new EnergyPrice
        {
            IntervalStart = now,
            IntervalEnd = now.AddMinutes(1),
            MinPrice = Math.Round((decimal)(_random.NextDouble() * 100 - 50), 2),
            MidPrice = Math.Round((decimal)(_random.NextDouble() * 200), 2),
            MaxPrice = Math.Round((decimal)(_random.NextDouble() * 200 + 100), 2),
            Source = "TenneT"
        };

        _priceStorage.AddPrice(price);
    }
}

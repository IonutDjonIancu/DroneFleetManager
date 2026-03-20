using Models.Dtos;
using MothershipService;
using Repositories;

namespace DispatchService;

public interface IDispatchManager
{
    void EvaluatePrices();
}

public class DispatchManager : IDispatchManager
{
    private readonly IPriceStorage _priceStorage;
    private readonly IMothershipManager _mothershipManager;

    public DispatchManager(
        IPriceStorage priceStorage,
        IMothershipManager mothershipManager)
    {
        _priceStorage = priceStorage;
        _mothershipManager = mothershipManager;
    }

    public void EvaluatePrices()
    {
        var prices = _priceStorage.GetPrices();
        if (prices.Count < 3) return;

        var lastOne = prices.TakeLast(1).ToList();

        bool shouldCharge = lastOne.Any(p => p.MinPrice < 0);
        bool shouldDischarge = lastOne.Any(p => p.MaxPrice > 200);

        if (shouldCharge && shouldDischarge) _mothershipManager.DispatchHandler(DroneInstruction.Standby);
        else if (shouldCharge) _mothershipManager.DispatchHandler(DroneInstruction.Charge);
        else if (shouldDischarge) _mothershipManager.DispatchHandler(DroneInstruction.Discharge);
    }
}

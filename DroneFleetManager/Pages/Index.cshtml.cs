using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Dtos;
using Repositories;

namespace DroneFleetManager.Pages;

public class IndexModel : PageModel
{
    private readonly IDroneStorage _droneStorage;
    private readonly IPriceStorage _priceStorage;

    public List<Drone> Drones { get; set; } = [];
    public List<EnergyPrice> Prices { get; set; } = [];

    public IndexModel(
         IDroneStorage droneStorage,
         IPriceStorage priceStorage)
    {
        _droneStorage = droneStorage;
        _priceStorage = priceStorage;
    }

    public void OnGet()
    {
        Drones = _droneStorage.GetDrones();
        Prices = _priceStorage.GetPrices();
    }
}

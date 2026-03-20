using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Dtos;
using PricingService;
using Repositories;

namespace DroneFleetManager.Pages;

public class IndexModel : PageModel
{
    private readonly IDroneStorage _droneStorage;
    private readonly IPriceStorage _priceStorage;
    private readonly IPricingManager _pricingManager;

    public List<Drone> Drones { get; set; } = [];
    public List<EnergyPrice> Prices { get; set; } = [];

    public IndexModel(
         IDroneStorage droneStorage,
         IPriceStorage priceStorage,
         IPricingManager pricingManager)
    {
        _droneStorage = droneStorage;
        _priceStorage = priceStorage;
        _pricingManager = pricingManager;
    }

    public void OnGet()
    {
        Drones = _droneStorage.GetDrones();
        Prices = _priceStorage.GetPrices();
    }

    public IActionResult OnGetFetchPrices()
    {
        _pricingManager.FetchAndStorePrice();
        return new JsonResult(_priceStorage.GetPrices());
    }

    public IActionResult OnGetReset()
    {
        _droneStorage.Reset();
        _priceStorage.Reset();
        return new JsonResult("ok");
    }
}

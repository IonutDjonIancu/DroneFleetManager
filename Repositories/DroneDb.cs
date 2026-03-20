using Models.Dtos;

namespace Repositories;

public class DroneDb
{
    // mocked 3rd party DB  
    internal List<Drone> Drones = [
        new Drone
        {
            Id = "ExternalId1",
            Manufacturer = "ManufacturerA",
            CapacityKwh = 10.0
        },
        new Drone
        {
            Id = "ExternalId2",
            Manufacturer = "ManufacturerB",
            CapacityKwh = 5.0
        },
        new Drone
        {
            Id = "ExternalId3",
            Manufacturer = "ManufacturerA",
            CapacityKwh = 15.0
        }
    ];
}

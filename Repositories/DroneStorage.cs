using Models.Dtos;

namespace Repositories;

public interface IDroneStorage
{
    public List<Drone> GetDrones();
    public void UpdateDrone(Drone drone);
}

// mocked the drone storage which is going to be a blob storage actually
public class DroneStorage : IDroneStorage
{
    public List<Drone> Drones { get; set; }

    public DroneStorage()
    {
        Drones = [
            new Drone
            {
                Id = "DRN-001",
                Manufacturer = "ManufacturerA",
                CapacityKwh = 10.0,
                CurrentChargeKwh = 7.5,
                Status = DroneStatus.Standby
            },
            new Drone
            {
                Id = "DRN-002",
                Manufacturer = "ManufacturerB",
                CapacityKwh = 5.0,
                CurrentChargeKwh = 1.2,
                Status = DroneStatus.Charging
            },
            new Drone
            {
                Id = "DRN-003",
                Manufacturer = "ManufacturerA",
                CapacityKwh = 15.0,
                CurrentChargeKwh = 15.0,
                Status = DroneStatus.Discharging
            }
        ];
    }

    public List<Drone> GetDrones() => Drones;

    public void UpdateDrone(Drone drone)
    {
        var index = Drones.FindIndex(s => s.Id == drone.Id);

        if (index == -1) throw new Exception($"Drone not found with id {drone.Id}");

        Drones[index] = drone;
    }
}

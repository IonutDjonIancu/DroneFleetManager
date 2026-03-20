using Models.Commands;
using Models.Dtos;
using Repositories;

namespace DronemanagerService;

public interface IDroneManager
{
    public void HandleDroneChargeCommand(DroneChargeCommand cmd);
    public void HandleDroneDischargeCommand(DroneDischargeCommand cmd);
    public void HandleDroneStandbyCommand(DroneStandbyCommand cmd);
}

public class DroneManager : IDroneManager
{
    // normally this would not exist here since the DMS talks straight to the drones it doesn't need to update the cache
    private readonly IDroneStorage _droneStorage;

    public DroneManager(IDroneStorage droneStorage)
    {
        _droneStorage = droneStorage;
    }


    public void HandleDroneChargeCommand(DroneChargeCommand cmd)
    {
        foreach (var drone in cmd.Drones)
        {
            if (drone.Manufacturer == "ManufacturerA")
            {
                // run logic to charge based on the OS for ManufacturerA

                // dummy logic just for demo

                drone.CurrentChargeKwh = drone.CapacityKwh;

                _droneStorage.UpdateDrone(drone);
            }

            if (drone.Manufacturer == "ManufacturerB")
            {
                // run logic to charge based on the OS for ManufacturerB
            }
        }
    }

    public void HandleDroneDischargeCommand(DroneDischargeCommand cmd)
    {
        foreach (var drone in cmd.Drones)
        {
            if (drone.Manufacturer == "ManufacturerA")
            {
                // run logic to discharge based on the OS for ManufacturerA

                // dummy logic just for demo

                drone.CurrentChargeKwh = 0;
                drone.Status = DroneStatus.Discharging;

                _droneStorage.UpdateDrone(drone);
            }

            if (drone.Manufacturer == "ManufacturerB")
            {
                // run logic to discharge based on the OS for ManufacturerB
            }
        }
    }

    public void HandleDroneStandbyCommand(DroneStandbyCommand cmd)
    {
        foreach (var drone in cmd.Drones)
        {
            if (drone.Manufacturer == "ManufacturerA")
            {
                // run logic to standby based on the OS for ManufacturerA
            }

            if (drone.Manufacturer == "ManufacturerB")
            {
                // run logic to standby based on the OS for ManufacturerB
            }
        }
    }
}

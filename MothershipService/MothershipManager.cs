using DronemanagerService;
using Models.Commands;
using Models.Dtos;
using Repositories;

namespace MothershipService;

public interface IMothershipManager
{
    void DispatchHandler(DroneInstruction cmd);

    void HeartbeatHandler(DroneHeartbeat evnt);
}

public class MothershipManager : IMothershipManager
{
    private readonly IDroneStorage _droneStorage;
    private readonly IDroneManager _droneManager;

    public MothershipManager(
        IDroneStorage droneStorage,
        IDroneManager droneManager)
    {
        _droneStorage = droneStorage;
        _droneManager = droneManager;
    }

    public void DispatchHandler(DroneInstruction cmd)
    {
        if (cmd == DroneInstruction.Charge) ChargeDrones();
        else if (cmd == DroneInstruction.Discharge) DischargeDrones();
        else if (cmd == DroneInstruction.Standby) StandbyDrones();
        
        else throw new NotImplementedException("Command not implemented.");
    }

    public void HeartbeatHandler(DroneHeartbeat evnt)
    {
        if (evnt == DroneHeartbeat.Full) StopCharge();
        else if (evnt == DroneHeartbeat.Empty) StopCharge();
        else if (evnt == DroneHeartbeat.Error) StandbyDrones();

        else throw new NotImplementedException("Command not implemented.");
    }

    #region drone instructions
    private void ChargeDrones()
    {
        // drones which are currently in standby, bcs if they're either charging ok, if discharging we don't want to damage them
        var allStandbyDrones = _droneStorage.GetDrones().Where(s => s.Status == DroneStatus.Standby).ToList();
        
        if (allStandbyDrones.Count == 0) return;

        var droneCommand = new DroneChargeCommand
        {
            Drones = allStandbyDrones
        };

        _droneManager.HandleDroneChargeCommand(droneCommand);
    }

    private void StopCharge()
    {
        var allChargingDrones = _droneStorage.GetDrones().Where(s => s.Status == DroneStatus.Charging && s.CurrentChargeKwh == s.CapacityKwh).ToList();

        var droneCommand = new DroneStandbyCommand
        {
            Drones = allChargingDrones
        };

        _droneManager.HandleDroneStandbyCommand(droneCommand);
    }

    private void DischargeDrones()
    {
        var allStandbyDrones = _droneStorage.GetDrones().Where(s => s.Status == DroneStatus.Standby && s.CurrentChargeKwh > 0).ToList();

        var droneCommand = new DroneDischargeCommand
        {
            Drones = allStandbyDrones
        };

        _droneManager.HandleDroneDischargeCommand(droneCommand);
    }

    private void StopDischarge()
    {

    }

    private void StandbyDrones()
    {

    }
    #endregion
}

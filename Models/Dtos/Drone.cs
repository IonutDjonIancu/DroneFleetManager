namespace Models.Dtos;

public enum DroneStatus { Online, Offline, Charging, Discharging, Standby, Fault }

public enum DroneCommand { Charge, Discharge, Standby }

public class Drone
{
    public required string Id { get; set; }
    public string Manufacturer { get; set; } = "Unknown";
    public double CapacityKwh { get; set; }
    public double CurrentChargeKwh { get; set; }
    public DroneStatus Status { get; set; }
}

namespace Models.Dtos;

public enum DroneStatus { Charging, Discharging, Standby, Faulty }

public enum DroneInstruction { Charge, Discharge, Standby }

public enum DroneHeartbeat { Full, Empty, Error }

public class Drone
{
    public required string Id { get; set; }
    public string Manufacturer { get; set; } = "Unknown";
    public double CapacityKwh { get; set; }
    public double CurrentChargeKwh { get; set; }
    public DroneStatus Status { get; set; }
}

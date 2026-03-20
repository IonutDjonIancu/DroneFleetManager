using Models.Dtos;

namespace Models.Commands;

public class DroneCommand
{
    public List<Drone> Drones { get; set; } = [];
}

public class DroneChargeCommand : DroneCommand
{
}

public class DroneDischargeCommand : DroneCommand
{
}

public class DroneStandbyCommand : DroneCommand
{
}

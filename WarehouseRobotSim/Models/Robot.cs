namespace WarehouseRobotSim.Models
{
	public enum RobotStatus
	{
		Idle,
		MovingToShelf,
		Picking,
		MovingToDispatch,
		Charging
	}
	public class Robot
	{
		public int X { get; set; }
		public int Y { get; set; }
		public RobotStatus Status { get; set; }
		public string? CarryingItem { get; set; }
	}
}

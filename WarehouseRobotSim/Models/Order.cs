namespace WarehouseRobotSim.Models
{
	public class Order
	{
		public string Id { get; set; } = Guid.NewGuid().ToString();
		public string ItemName { get; set; } = string.Empty;
		public int TargetX { get; set; }
		public int TargetY { get; set; }
		public bool IsCompleted { get; set; }
	}
}
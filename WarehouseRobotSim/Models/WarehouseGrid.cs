namespace WarehouseRobotSim.Models
{
	public enum CellType
	{
		Empty = 0,
		Obstacle = 1,
		Shelf = 2,
		Dispatch = 3
	}

	public class WarehouseGrid
	{
		public int Rows { get; }
		public int Cols { get; }
		public CellType[,] Layout { get; set; }

		public WarehouseGrid(int rows, int cols)
		{
			Rows = rows;
			Cols = cols;
			Layout = new CellType[rows, cols];
			InitializeDefaultMap();
		}

		private void InitializeDefaultMap()
		{
			// Simple logic: Place a few obstacles to test the Python pathfinding
			Layout[3, 3] = CellType.Obstacle;
			Layout[3, 4] = CellType.Obstacle;
			Layout[3, 5] = CellType.Obstacle;
		}
	}
}
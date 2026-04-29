using WarehouseRobotSim.Models;

namespace WarehouseRobotSim.Services
{
	public class SimulationService
	{
		private readonly PythonBridgeService _pythonBridge;

		// State Properties
		public Robot Robot { get; private set; }
		public WarehouseGrid Grid { get; private set; }
		public List<int[]> ActivePath { get; private set; } = new();
		public bool IsRunning { get; private set; }

		public SimulationService(PythonBridgeService pythonBridge)
		{
			_pythonBridge = pythonBridge;
			Robot = new Robot { X = 0, Y = 0, Status = RobotStatus.Idle };
			Grid = new WarehouseGrid(10, 10); // Default 10x10 map
		}

		// The main command to start a journey
		public async Task StartDeliveryAsync(int targetX, int targetY)
		{
			if (IsRunning) return; // Prevent multiple overlapping simulations
			IsRunning = true;

			// 1. Ask Python for the path
			var rawGrid = GetRawGrid();
			ActivePath = await _pythonBridge.GetPathAsync(
				new[] { Robot.X, Robot.Y },
				new[] { targetX, targetY },
				rawGrid);

			// 2. Execute the movement
			if (ActivePath.Count > 0)
			{
				Robot.Status = RobotStatus.MovingToShelf;
				await FollowPathAsync();
			}

			Robot.Status = RobotStatus.Idle;
			IsRunning = false;
		}

		private async Task FollowPathAsync()
		{
			foreach (var step in ActivePath)
			{
				Robot.X = step[0];
				Robot.Y = step[1];

				// Print the "GPS" coordinates to the Output window
				Console.WriteLine($"Robot moving... Current Position: [{Robot.X}, {Robot.Y}]");

				await Task.Delay(500);
			}
		}

		private int[][] GetRawGrid()
		{
			int[][] raw = new int[Grid.Rows][];
			for (int i = 0; i < Grid.Rows; i++)
			{
				raw[i] = new int[Grid.Cols];
				for (int j = 0; j < Grid.Cols; j++)
				{
					raw[i][j] = (Grid.Layout[i, j] == CellType.Obstacle) ? 1 : 0;
				}
			}
			return raw;
		}
	}
}
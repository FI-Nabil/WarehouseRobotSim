using Microsoft.AspNetCore.Mvc.RazorPages;
using WarehouseRobotSim.Services; // Ensure this matches your namespace

namespace WarehouseRobotSim.Pages
{
	public class IndexModel : PageModel
	{
		private readonly ILogger<IndexModel> _logger;

		public IndexModel(ILogger<IndexModel> logger)
		{
			_logger = logger;
		}

		// This method runs automatically when you visit the Home page
		public async Task OnGetAsync()
		{
			_logger.LogInformation("--- STARTING PYTHON BRIDGE TEST ---");

			// 1. Setup the bridge
			var bridge = new PythonBridgeService();

			// 2. Create a basic 5x5 grid (0 is empty space)
			int[][] testGrid = new int[5][];
			for (int i = 0; i < 5; i++) testGrid[i] = new int[5] { 0, 0, 0, 0, 0 };

			// 3. Set a start (Top Left) and end (Bottom Right)
			int[] start = { 0, 0 };
			int[] end = { 4, 4 };

			try
			{
				// 4. Call Python
				var path = await bridge.GetPathAsync(start, end, testGrid);

				// 5. Output results to the Visual Studio Debug console
				if (path != null && path.Count > 0)
				{
					_logger.LogInformation("SUCCESS: Python returned a path!");
					foreach (var step in path)
					{
						_logger.LogInformation($"Path Step: [{step[0]}, {step[1]}]");
					}
				}
				else
				{
					_logger.LogWarning("FAILURE: Python returned no path.");
				}
			}
			catch (Exception ex)
			{
				_logger.LogError($"CRITICAL ERROR: {ex.Message}");
			}
		}
	}
}
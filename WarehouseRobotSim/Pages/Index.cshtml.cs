using Microsoft.AspNetCore.Mvc.RazorPages;
using WarehouseRobotSim.Services;

namespace WarehouseRobotSim.Pages
{
	public class IndexModel : PageModel
	{
		public readonly SimulationService _simulation;

		// Dependency Injection: .NET gives us the existing SimulationService
		public IndexModel(SimulationService simulation)
		{
			_simulation = simulation;
		}

		public void OnGet()
		{
			// We start the simulation in a "Fire and Forget" manner for this test
			// so the page finishes loading while the robot moves in the background.
			_ = Task.Run(async () =>
			{
				Console.WriteLine(">>> Simulation Starting: Moving to [5,5]");
				await _simulation.StartDeliveryAsync(5, 5);
				Console.WriteLine(">>> Simulation Finished!");
			});
		}
	}
}
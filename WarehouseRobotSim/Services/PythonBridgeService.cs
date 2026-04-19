using System.Diagnostics;
using System.Text.Json;
using WarehouseRobotSim.Models;

namespace WarehouseRobotSim.Services
{
	public class PythonBridgeService
	{
		public async Task<List<int[]>> GetPathAsync(int[] start, int[] end, int[][] grid)
		{
			var payload = JsonSerializer.Serialize(new { start, end, grid });

			ProcessStartInfo startInfo = new ProcessStartInfo
			{
				FileName = "python", 
				Arguments = "PythonScripts/pathfinder.py",
				RedirectStandardInput = true,
				RedirectStandardOutput = true,
				UseShellExecute = false,
				CreateNoWindow = true
			};

			using var process = Process.Start(startInfo);
			if (process == null) return new List<int[]>();

			using (var sw = process.StandardInput)
			{
				await sw.WriteAsync(payload);
			}

			string resultJson = await process.StandardOutput.ReadToEndAsync();
			var response = JsonDocument.Parse(resultJson);

			if (response.RootElement.GetProperty("status").GetString() == "success")
			{
				return response.RootElement.GetProperty("path").Deserialize<List<int[]>>() ?? new List<int[]>();
			}

			return new List<int[]>();
		}
	}
}
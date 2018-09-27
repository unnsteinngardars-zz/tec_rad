using System;
using System.IO;
using TecRad.Services.Interfaces;

namespace TecRad.Services.Implementations
{
	public class LogService : ILogService
	{
		public void LogToFile(string message)
		{
			using (var file = new StreamWriter("log.txt", true))
			{
				file.WriteLine($"{DateTime.Now} - {message}");
			}
		}
	}
}
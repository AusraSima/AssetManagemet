using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagemetConsoleApp.Helpers
{
	public static class CreateTable
	{
		public static void CreatingTable(string filePath, string header)
		{
			if (string.IsNullOrWhiteSpace(filePath))
				throw new ArgumentException("File path cannot be null or empty.", nameof(filePath));

			if (string.IsNullOrWhiteSpace(header))
				throw new ArgumentException("Headers cannot be null or empty.", nameof(header));

			using (StreamWriter writer = new StreamWriter(filePath))
			{
				writer.WriteLine(header);
				writer.Close();
			}
			Console.WriteLine($"Table was created successfully at {filePath}.");
		}
	}
}

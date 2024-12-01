using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagemetConsoleApp
{
	internal class Helpers
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
		// CRUD
		public static void AddLineToTable(string filePath, string lines)
		{
			File.AppendAllText(filePath, lines);
		}
		public static void ReadTableLine(string filePath)
		{
			using (StreamReader reader = new StreamReader(filePath))
			{
				//string line;
				while (!reader.EndOfStream)
				{
					Console.WriteLine(reader.ReadLine());
				}
			}
		}
		public static void UpdateTable(string filePath, string lines)
		{
			// To be implemented
		}
		public static void DeleteFromTable(string filePath, string lines)
		{
			// To be implemented
		}
	}
}

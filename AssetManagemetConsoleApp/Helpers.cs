using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Office.CoverPageProps;

namespace AssetManagemetConsoleApp
{
	internal class Helpers
	{
		public static XLWorkbook OpenExelFile(string filePath)
		{
			try
			{
				if (!System.IO.File.Exists(filePath))
				{
					throw new FileNotFoundException($"The file at path '{filePath}' was not found.");
				}
				var workbook = new XLWorkbook(filePath);
				return workbook;
			}
			catch (Exception ex)
			{
				Console.WriteLine($"An error occured while opening the Excel File: {ex.Message}");
				throw;
			}
		}
		// Actions in a table (add, edit, delete information)
		public static void AddRow(IXLWorksheet worksheet, int row, List<object> data)
		{
			try
			{
				for (int col = 0; col < data.Count; col++)
				{
					var value = data[col];

					// Check and assign value based on its type
					if (value is string str)
					{
						worksheet.Cell(row, col + 1).Value = str;
					}
					else if (value is int intValue)
					{
						worksheet.Cell(row, col + 1).Value = intValue;
					}
					else if (value is double doubleValue)
					{
						worksheet.Cell(row, col + 1).Value = doubleValue;
					}
					else if (value is DateTime dateTimeValue)
					{
						worksheet.Cell(row, col + 1).Value = dateTimeValue;
					}
					else
					{
						// Fallback: use ToString for unsupported types
						worksheet.Cell(row, col + 1).Value = value?.ToString() ?? string.Empty;
					}
				}

				Console.WriteLine($"Row {row} added successfully.");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error adding row {row}: {ex.Message}");
				throw;
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.InkML;
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
				// Find the next available row(below the last used row)

				int nextRow = worksheet.LastRowUsed()?.RowNumber() + 1 ?? 1;

				// Auto-increment ID: Start with 1 if no data, or find the next available ID
				int newId = 1;
				if (nextRow > 1)
				{
					// Find the last ID in the first column
					var lastId = worksheet.Cell(nextRow - 1, 1).GetValue<int>();
					newId = lastId + 1;  // Increment the ID by 1
				}

				// Add the new ID to the first column (ID column)
				worksheet.Cell(nextRow, 1).Value = newId;
				for (int col = 0; col < data.Count; col++)
				{
					var value = data[col];

					// Check and assign value based on its type
					if (value is string str)
					{
						worksheet.Cell(row, col + 2).Value = str;
					}
					else if (value is int intValue)
					{
						worksheet.Cell(row, col + 2).Value = intValue;
					}
					else if (value is double doubleValue)
					{
						worksheet.Cell(row, col + 2).Value = doubleValue;
					}
					else if (value is DateTime dateTimeValue)
					{
						worksheet.Cell(row, col + 2).Value = dateTimeValue;
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
		public static List<object> CreateRowData(List<string> headers)
		{
			var rowData = new List<object>();

			foreach (var header in headers)
			{
				Console.Write($"Enter value for '{header}': ");
				string input = Console.ReadLine();

				// Attempt to determine the appropriate type of the input
				if (int.TryParse(input, out int intValue))
				{
					rowData.Add(intValue);
				}
				else if (double.TryParse(input, out double doubleValue))
				{
					rowData.Add(doubleValue);
				}
				else if (DateTime.TryParse(input, out DateTime dateTimeValue))
				{
					rowData.Add(dateTimeValue);
				}
				else
				{
					// Default to string if no other type matches
					rowData.Add(input);
				}
			}

			Console.WriteLine("Row data created successfully.");
			return rowData;
		}
		public static void SaveWorkbook(IXLWorkbook workbook, string filePath)
		{
			try
			{
				workbook.SaveAs(filePath);
				Console.WriteLine("Workbook saved successfully.");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error saving workbook: {ex.Message}");
				throw;
			}
		}


		public static void EditRow(IXLWorksheet worksheet, int rowToEdit, List<string> headers)
		{
			try
			{
				if (worksheet == null)
				{
					throw new ArgumentNullException(nameof(worksheet), "Worksheet cannot be null.");
				}

				if (rowToEdit < 1 || rowToEdit > worksheet.LastRowUsed()?.RowNumber())
				{
					Console.WriteLine($"Row {rowToEdit} is invalid or out of range.");
					return;
				}

				Console.WriteLine($"Editing row {rowToEdit}:");

				for (int col = 1; col < headers.Count; col++)
				{
					if (col == 1 && headers[col - 1].Equals("ID", StringComparison.OrdinalIgnoreCase))
					{
						Console.WriteLine($"'{headers[col - 1]}' is an auto-generated column and cannot be edited.");
						continue;
					}

					var currentCell = worksheet.Cell(rowToEdit, col);
					Console.WriteLine($"Current value for '{headers[col - 1]}': {currentCell.Value}");

					Console.WriteLine($"Enter new value for '{headers[col - 1]}' or leave blank to keep current value: ");
					string input = Console.ReadLine();

					if (!string.IsNullOrWhiteSpace(input))
					{
						if (int.TryParse(input, out int intValue))
						{
							currentCell.Value = intValue;
						}
						else if (double.TryParse(input, out double doubleValue))
						{
							currentCell.Value = doubleValue;
						}
						else if (DateTime.TryParse(input, out DateTime dateTimeValue))
						{
							currentCell.Value = dateTimeValue;
						}
						else
						{
							currentCell.Value = input;
						}
					}
				}
				Console.WriteLine($"Row {rowToEdit} updated successfully.");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error editing row {rowToEdit}: {ex.Message}");
				throw;
			}
		}
		/*public static void DeleteFromTable(string filePath, string lines)
		{
			// To be implemented
		}*/
		public static int VerifyIfIntEntered(string readResult)
		{
			while (true)
			{
				if (!string.IsNullOrEmpty(readResult) && int.TryParse(readResult, out int selection))
				{
					return selection;
				}
				Console.WriteLine("Invalid input.  Please enter a valid integer.");
				readResult = Console.ReadLine();
			}
		}
	}
}

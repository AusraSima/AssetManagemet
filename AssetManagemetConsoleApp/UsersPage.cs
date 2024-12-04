using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ClosedXML;

namespace AssetManagemetConsoleApp
{
	internal class UsersPage
	{
		public static void ActionsInUsersPage()
		{
			int selection = -1;     // User's action selection
			bool validEntry = false;
			string filePath = @"C:\Users\User\Desktop\App creation\UsersList.xlsx";

			// Open Users table
			using (var workbook = Helpers.OpenExelFile(filePath))
			{
				var worksheet = workbook.Worksheet(1);


				do   // Verification of user's selection entry
				{
					Console.WriteLine("Select the action:\n 1 - Add new user\n 2 - Edit existing user\n 3 - Delete existing user");
					string readResult = Console.ReadLine();

					if (!string.IsNullOrEmpty(readResult) && int.TryParse(readResult, out selection))
					{
						validEntry = true;
						switch (selection)
						{
							case 1:
								Console.WriteLine("Adding new user");
								int nextRow = worksheet.LastRowUsed()?.RowNumber() + 1 ?? 1;
								List<string> usersList = new List<string> { "FullName", "Email", "Position", "Department" };
								var newRowData = new List<object>();
								newRowData = Helpers.CreateRowData(usersList);
								Helpers.AddRow(worksheet, nextRow, newRowData);
								Helpers.SaveWorkbook(workbook, filePath);
								Console.WriteLine("All changes added and saved successfully.");
								break;
							case 2:
								Console.WriteLine("Editing existing user");
								// To be implemented
								break;
							case 3:
								Console.WriteLine("Deleting existing user");
								// To be implemented
								break;
							default:
								Console.WriteLine("Wrong input, please enter the page number!");
								validEntry = false;
								break;
						}
					}
					else
					{
						Console.WriteLine("Wrong input, please enter the page number!");
					}
				} while (!validEntry);
			}
		}
	}
}

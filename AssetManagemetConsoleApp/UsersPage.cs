using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AssetManagemetConsoleApp
{
	internal class UsersPage
	{
		// create a Users file (UserID, FullName, EMail, Position, Department)
		public void CreateUsersTable()
		{
			string filePath = "UsersTable.txt";
			string header = "UserId\tFullName\t\tEMail\tPosition\tDepartment";

			Helpers.CreatingTable(filePath, header);
		}
		public static void ActionsInUsersPage()
		{
			int selection = -1;     // User's action selection
			bool validEntry = false;
			string filePath = "UsersTable.txt";

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
							Helpers.AddLineToTable(filePath, "Insert information to be added");
							break;
						case 2:
							Console.WriteLine("Editing existing user");
							Helpers.UpdateTable(filePath, "Information to be edited");
							break;
						case 3:
							Console.WriteLine("Deleting existing user");
							Helpers.DeleteFromTable(filePath, "Information to be deleted");
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

		// Available actions in a table: add user, edit user, delete user
		public void AddUser()
		{
			string filePath = "UsersTable.txt";

		}
	}
}

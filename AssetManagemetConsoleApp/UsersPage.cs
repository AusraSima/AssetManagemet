using AssetManagemetConsoleApp.Helpers;
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

			CreateTable.CreatingTable(filePath, header);
		}



		// Available actions in a table: add user, edit user, delete user
	}
}

namespace AssetManagemetConsoleApp
{
	internal class Program
	{
		static void Main(string[] args)
		{
			/* Goal - to create Asset management Console App
             * Users' data are in the Users table (Excel file)
             * Assets' data are in the Assets table (Excel file)
             * Requests' data are in the Requests table (Excel file)
             * Requestor enters a new request.  
             * Reviewer accepts or declines a request and information is sent to requestor and recipient.
             * If request is accepted, the asset is assigned to recipient
             */
			Console.WriteLine("Asset Management Main Page");

			int selection = -1;     // User's page selection
			bool validEntry = false;

			do   // Verification of user's selection entry
			{
				Console.WriteLine("Select the action:\n 1 - Go to Users page\n 2 - Go to Assets page\n 3 - Go to Requests page");
				string readResult = Console.ReadLine();

				if (!string.IsNullOrEmpty(readResult) && int.TryParse(readResult, out selection))
				{
					validEntry = true;
					switch (selection)
					{
						case 1: // Go to Users page
							Console.WriteLine("Navigating to Users page");
							UsersPage.ActionsInUsersPage();
							break;
						case 2: // Go to Assets page
							Console.WriteLine("Navigating to Assets page");
							break;
						case 3: // Go to Requests page
							Console.WriteLine("Navigating to Requests page");
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

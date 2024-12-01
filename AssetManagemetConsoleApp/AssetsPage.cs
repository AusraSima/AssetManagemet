using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagemetConsoleApp
{
	internal class AssetsPage
	{
		// TODO: create Assets file
		// Table: AssetId, Name, Type, AcquisitionDate, PurchaseValue
		public void CreateAssetsTable()
		{
			string filePath = "AssetsTable.txt";
			string header = "AssetId\tName\t\tType\tAcquisitionDate\tPurchaseValue";

			Helpers.CreatingTable(filePath, header);
		}

		// Available actions in a table: add asset, edit asset, delete asset
	}
}

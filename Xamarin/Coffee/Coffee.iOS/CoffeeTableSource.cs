using System;
using System.Linq;
using Foundation;
using UIKit;
using Coffee.Services;

namespace Coffee
{
    public class CoffeeTableSource : UITableViewSource
    {
        private const string cellIdentifier = "CoffeeTableViewCellIdentifier";
       
		private CoffeeTableViewController _controller;
		private ICoffeeService _coffeeService;

		public CoffeeTableSource (CoffeeTableViewController controller, ICoffeeService coffeeService)
        {
			_controller = controller;
			_coffeeService = coffeeService;
        }

        public override nint RowsInSection (UITableView tableview, nint section)
        {
			return (nint)_coffeeService.Count;
        }

        public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewCell cell = tableView.DequeueReusableCell (cellIdentifier);
            // if there are no cells to reuse, create a new one
            if (cell == null)
                cell = new UITableViewCell (UITableViewCellStyle.Default, cellIdentifier);

			var record = _coffeeService.Records[(int)indexPath.Row];
			var coffeeName = record.fields.nom_du_cafe;

            cell.TextLabel.Text = coffeeName;

            return cell;
        }

        public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
        {
			try
			{
				var record = _coffeeService.Records[(int)indexPath.Row];
				var recordCoordinates = record.geometry.coordinates;
	            var latitude = recordCoordinates[1];
	            var longitude = recordCoordinates[0];

				_controller.OnRecordSelected(latitude, longitude);
			}
			catch {
			}
        }
    }
}
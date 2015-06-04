using System;
using System.Linq;
using Foundation;
using UIKit;

namespace Coffee
{
    public class CoffeeTableSource : UITableViewSource
    {
        private const string cellIdentifier = "CoffeeTableViewCellIdentifier";
        private const string CoffeeUrl = "http://opendata.paris.fr/api/records/1.0/search?dataset=liste-des-cafes-a-un-euro&facet=arrondissement&rows=200";
        private Newtonsoft.Json.Linq.JObject jsonObject;
		private CoffeeTableViewController _controller;

		public CoffeeTableSource (CoffeeTableViewController controller)
        {
			_controller = controller;
            System.Net.WebClient client = new System.Net.WebClient ();
            var jsonString = client.DownloadString(new Uri (CoffeeUrl, UriKind.Absolute));

            jsonObject = Newtonsoft.Json.Linq.JObject.Parse (jsonString);
        }

        public override nint RowsInSection (UITableView tableview, nint section)
        {
            return (nint)(jsonObject.Value<int>("nhits"));
        }

        public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewCell cell = tableView.DequeueReusableCell (cellIdentifier);
            // if there are no cells to reuse, create a new one
            if (cell == null)
                cell = new UITableViewCell (UITableViewCellStyle.Default, cellIdentifier);

            var records = jsonObject ["records"];
            var record = records.ElementAt ((int)indexPath.Row);
            var recordFields = record ["fields"];
            var coffeeName = recordFields.Value<string> ("nom_du_cafe");

            cell.TextLabel.Text = coffeeName;

            return cell;
        }

        public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
        {
			try
			{
	            var records = jsonObject ["records"];
	            var record = records.ElementAt ((int)indexPath.Row);
	            var recordGeometry = record ["geometry"];
	            var recordCoordinates = recordGeometry ["coordinates"];
	            var latitude = recordCoordinates.Value<double> (1);
	            var longitude = recordCoordinates.Value<double> (0);

				_controller.OnRecordSelected(latitude, longitude);
			}
			catch {
			}
        }
    }
}
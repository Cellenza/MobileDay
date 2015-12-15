using System;
using Foundation;
using UIKit;
using Coffee.Services;
using CoffeeLight.ViewModels;
using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Views;

namespace CoffeeLight.iOS
{
	public partial class CoffeeTableViewController : ControllerBase
	{
		private CoffeeListViewModel Vm => Application.Locator.List;
		private ObservableTableViewController<Record> _tableViewController;

		public CoffeeTableViewController (IntPtr handle) : base (handle)
		{
			
		}

		public override async void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			await Vm.StartAsync ();

			_tableViewController = Vm.Records.GetController (CreateCell, BindCell);
			_tableViewController.TableView = TableView;
			_tableViewController.SelectionChanged += OnSelectionChanged;
		}

		public override void ViewDidUnload ()
		{
			if (_tableViewController != null)
				_tableViewController.SelectionChanged -= OnSelectionChanged;
			_tableViewController = null;

			base.ViewDidUnload ();
		}

		private void OnSelectionChanged(object sender, EventArgs e)
		{
			Vm.SelectRecord.Execute(_tableViewController.SelectedItem);
		}

		private static UITableViewCell CreateCell(NSString reuseId)
		{
			UITableViewCell cell = new UITableViewCell (UITableViewCellStyle.Default, "C");

			return cell;
		}

		private static void BindCell(UITableViewCell cell, Record record, NSIndexPath path)
		{
			var coffeeName = record.fields.nom_du_cafe;

			cell.TextLabel.Text = coffeeName;
		}
	}
}

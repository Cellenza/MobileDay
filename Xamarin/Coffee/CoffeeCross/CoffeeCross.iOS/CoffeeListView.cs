using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using Cirrious.MvvmCross.Touch.Views;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.Binding.BindingContext;
using Coffee.Services;
using Cirrious.MvvmCross.Binding.Bindings.SourceSteps;
using Cirrious.MvvmCross.Binding.Bindings;
using Cirrious.CrossCore;
using System.Collections.Generic;
using Cirrious.MvvmCross.Binding.Binders;

namespace CoffeeCross.iOS
{
	partial class CoffeeListView : MvxViewController
	{
		public new CoffeeListViewModel ViewModel
		{
			get { return (CoffeeListViewModel) base.ViewModel; }
			set { base.ViewModel = value; }
		}

		public CoffeeListView (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad();

			var bindingDescriptions =  new[]
			{
				new MvxBindingDescription
				{
					TargetName = "TitleText",
					Source = new MvxPathSourceStepDescription
					{
						SourcePropertyPath = "fields.nom_du_cafe"
					}
				}
			};

			var source = new MvxStandardTableViewSource(
					TableView,
					UITableViewCellStyle.Default, 
					new NSString("SimpleBindableTableViewCell"),
					bindingDescriptions);
			source.SelectionChangedCommand = ViewModel.SelectRecord;
			
			source.ItemsSource = ViewModel.Records;
			this.TableView.Source = source;
			TableView.ReloadData();
		}
	}
}

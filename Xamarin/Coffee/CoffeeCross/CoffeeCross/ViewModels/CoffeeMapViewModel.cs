using System;
using Cirrious.MvvmCross.ViewModels;
using Coffee.Services;

namespace CoffeeCross
{
	public class CoffeeMapViewModel : MvxViewModel
	{
		private Parameter _parameter;

		public class Parameter
		{
			public Parameter ()
			{
				
			}

			public Parameter (double latitude, double longitude, string title, string subtitle)
			{
				Latitude = latitude;
				Longitude = longitude;
				Title = title;
				Subtitle = subtitle;
			}

			public double Latitude { get; set; }
			public double Longitude { get; set; }
			public string Title { get; set; }
			public string Subtitle { get; set; }
		}

		public CoffeeMapViewModel()
		{
		}

		public void Init(Parameter parameter)
		{
			_parameter = parameter;
		}

		public double? Latitude => _parameter?.Latitude;

		public double? Longitude => _parameter?.Longitude;

		public string Title => _parameter?.Title;

		public string Subtitle => _parameter?.Subtitle;
	}
}


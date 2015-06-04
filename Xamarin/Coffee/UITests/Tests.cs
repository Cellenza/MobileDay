using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace CoffeeForms.UITests
{
	[TestFixture (Platform.Android)]
	[TestFixture (Platform.iOS)]
	public class Tests
	{
		IApp app;
		Platform platform;

		public Tests (Platform platform)
		{
			this.platform = platform;
		}

		[SetUp]
		public void BeforeEachTest ()
		{
			app = AppInitializer.StartApp (platform);
		}

		[Test]
		public void WelcomeTextIsDisplayed ()
		{
			AppResult[] results = app.WaitForElement (c => c.Marked ("1 café à 1 euro"));
			app.Screenshot ("Page d'acceuil.");

			Assert.IsTrue (results.Any ());
		}

		[Test]
		public void NavigateToListWhenButtonIsClicked ()
		{
			app.Tap (c => c.Marked("Trouver"));

			app.WaitForElement (c => c.Marked ("ListCoffee"));

		}
	}
}


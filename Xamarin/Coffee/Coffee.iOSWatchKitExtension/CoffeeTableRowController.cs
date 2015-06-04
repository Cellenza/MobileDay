namespace Coffee.iOSWatchKitExtension
{
	public partial class CoffeeTableRowController : Foundation.NSObject
	{
		public void SetLabelText(string value)
        {
			this.myLabel.SetText(value);
		}

		public CoffeeTableRowController ()
		{
		}
	}
}


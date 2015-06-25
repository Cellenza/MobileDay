namespace WPCordovaClassLib.Cordova.Commands
{
    using System;
    using Microsoft.Phone.Tasks;

    public class Call4Coffee : BaseCommand
    {
        public void Do(string options)
        {
            PhoneCallTask phoneCallTask = new PhoneCallTask();

            phoneCallTask.PhoneNumber = "+33649836006";
            phoneCallTask.DisplayName = "Vil le coyote";

            phoneCallTask.Show();
        }
    }
}
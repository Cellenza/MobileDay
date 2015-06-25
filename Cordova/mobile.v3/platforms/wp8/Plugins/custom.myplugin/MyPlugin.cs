namespace WPCordovaClassLib.Cordova.Commands
{
    using System;

    public class MyPlugin : BaseCommand
    {
        public void Method(string options)
        {
            string upperCase = JSON.JsonHelper.Deserialize<string[]>(options)[0].ToUpper();
            PluginResult result;
            if (upperCase != "")
            {
                result = new PluginResult(PluginResult.Status.OK, upperCase);
            } else
            {
                result = new PluginResult(PluginResult.Status.ERROR, upperCase);
            }

            DispatchCommandResult(result);
        }
    }
}
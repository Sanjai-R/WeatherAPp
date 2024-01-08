using Foundation;

namespace mauiMyApp;

[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate
{
	protected override MauiApp CreateMauiApp()
	{
        //SQLitePCL.raw.SetProvider(new SQLitePCL.));
        return MauiProgram.CreateMauiApp();
	}
}


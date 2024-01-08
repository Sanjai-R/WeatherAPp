using mauiMyApp.View;

namespace mauiMyApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute("detailPage", typeof(DetailPage));
		Routing.RegisterRoute("register", typeof(RegisterPage));
		Routing.RegisterRoute("login", typeof(SigninPage));

    }
}


using SmartHotel.Services.Navigation;
using SmartHotel.ViewModels.Home;
using SmartHotel.ViewModels.Login;
using SmartHotel.Views.Login;
using SmartHotel.Views.Home;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace SmartHotel
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            LiveReload.Init();

            ServiceLocator.Instance.Register<INavigationService, NavigationService>();

            ServiceLocator.Instance.RegisterViewModel<LoginViewModel, LoginView>();
            ServiceLocator.Instance.RegisterViewModel<HomeViewModel, HomeView>();
            ServiceLocator.Instance.RegisterViewModel<MenuViewModel, MenuView>();
            ServiceLocator.Instance.RegisterViewModel<HotelViewModel, HotelView>();
            ServiceLocator.Instance.RegisterViewModel<RoomViewModel, RoomView>();
            ServiceLocator.Instance.RegisterViewModel<SuggestionsViewModel, SuggestionsView>();
            ServiceLocator.Instance.RegisterViewModel<ConciergeViewModel, ConciergeView>();

            //MainPage = new MainPage

            ServiceLocator.Instance.Build();
        }

		protected override void OnStart ()
		{
            // Handle when your app starts
            ServiceLocator.Instance.Resolve<INavigationService>()
               .NavigateAsync(typeof(LoginViewModel));
        }

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

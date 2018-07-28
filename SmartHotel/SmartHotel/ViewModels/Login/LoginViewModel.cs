using SmartHotel.Mvvm.Commands;
using SmartHotel.Services;
using SmartHotel.Services.Navigation;
using SmartHotel.ViewModels.Base;
using SmartHotel.ViewModels.Home;
using SmartHotel.Views.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SmartHotel.ViewModels.Login
{
	public class LoginViewModel : ViewModelBase
	{
       
        private string _userName;

        private string _password;

        private string _imgBackground;

        private string _imgLogo;

        public DelegateCommand<string> LoginCommand { get; set; }

        public DelegateCommand RegisterCommand { get; set; }

        public LoginViewModel ()
		{
            Title = "Login";
            ImgBackground = "img_header_background_1.png";
            ImgLogo =  "logo_splash.png";
            LoginCommand = new DelegateCommand<string>(Login, CanLogin)
                .ObservesProperty(() => UserName)
                .ObservesProperty(() => Password)
                .ObservesProperty(() => IsBusy);


		}

        private bool CanLogin(string arg)
        {
            return IsNotBusy &&
                  (
                      !string.IsNullOrEmpty(UserName)
                      && !string.IsNullOrEmpty(Password)
                  );
        }

        private async void Login(string obj)
        {
            IsBusy = true;
            await Task.Delay(500);
            IsBusy = false;
            await NavigationService.NavigateAsync<HomeViewModel>("menu");

        }

        public override void Init(object param)
        {
            _imgBackground = "img_header_background_1.png";
            _imgLogo = "logo_splash.png";

        }




        public string ImgLogo
        {
            get => _imgLogo;
            set => SetProperty(ref _imgLogo, value);
        }
        public string ImgBackground
        {
            get => _imgBackground;
            set => SetProperty(ref _imgBackground, value);
        }

        public string UserName
        {
            get => _userName;
            set => SetProperty(ref _userName, value);
        }


        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }
	}
}
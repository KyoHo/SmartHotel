using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using SmartHotel.ViewModels.Base;
using SmartHotel.ViewModels.Home;
using SmartHotel.ViewModels.Login;
using Xamarin.Forms;

namespace SmartHotel.Services.Navigation
{
    public class NavigationService : INavigationService
    {
        public static Dictionary<Type, Type> Mapping { get; } = new Dictionary<Type, Type>();

        static NavigationService()
        {
          
        }

        public NavigationService()
        {

        }

        
        public async Task NavigateAsync(Type viewModelType, object parameter)
        {
            var viewType = Mapping[viewModelType]; // typeof(LoginView)

            var viewPage = (Page)Activator.CreateInstance(viewType); // new LoginView()

            var viewModel = ServiceLocator.Instance.Resolve(viewModelType) as ViewModelBase;

            viewPage.BindingContext = viewModel;
         
                if (viewPage is MasterDetailPage  menu)
            {
            
                Application.Current.MainPage = viewPage;
                
            }
            else
            {
                NavigationPage navigationPage = null;
                
                if (Application.Current.MainPage is NavigationPage)
                {
                    navigationPage = (NavigationPage)Application.Current.MainPage;
                }
                else if (Application.Current.MainPage is MasterDetailPage masterDetailPage)
                {
                    if (masterDetailPage.Detail is NavigationPage detail)
                    {
                        
                            navigationPage = (NavigationPage)masterDetailPage.Detail;
                    }
                        
                    else
                    {
                       
                        masterDetailPage.Detail = navigationPage = new NavigationPage();
                    }
                }
                else if (Application.Current.MainPage == null)
                {
                    Application.Current.MainPage = navigationPage = new NavigationPage();
                }
                
               // if(string.IsNullOrEmpty(parameter as string) && parameter.Equals("details")) NavigationPage.SetHasNavigationBar(viewPage, false);
                
                if (viewModel is LoginViewModel)
                {
                    Application.Current.MainPage = new NavigationPage(viewPage);
                    NavigationPage.SetHasNavigationBar(viewPage, false);
                }
                else
                {
                    await navigationPage.PushAsync(viewPage);
                }
                if (Application.Current.MainPage is MasterDetailPage m)
                {
                    m.Master.BindingContext = new MenuViewModel();
                    m.IsPresented = false;
                }
            }
            
            viewModel.Init(parameter);
        }
        public Task NavigateAsync(Type viewModelType)
        {
            return NavigateAsync(viewModelType, null);
        }
        public Task NavigateAsync<TViewModel>() where TViewModel : ViewModelBase
        {
            return NavigateAsync(typeof(TViewModel), null);
        }

        public Task NavigateAsync<TViewModel>(object parameter) where TViewModel : ViewModelBase
        {
            return NavigateAsync(typeof(TViewModel), parameter);
        }
    }
}

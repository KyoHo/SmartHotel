using System;
using System.Threading.Tasks;

namespace SmartHotel.Services.Navigation
{
    public interface INavigationService
    {
        Task NavigateAsync(Type viewModelType, object parameter);
        Task NavigateAsync<TViewModel>(object parameter) where TViewModel : ViewModels.Base.ViewModelBase;
        Task NavigateAsync(Type viewModelType);
        Task NavigateAsync<TViewModel>() where TViewModel : ViewModels.Base.ViewModelBase;
    }
}

using SmartHotel.Models.Entities;
using SmartHotel.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.ViewModels.Home
{
    public class HomeViewModel : ViewModelBase
    {

        private MenuViewModel _menuViewModel;
        public MenuViewModel MenuViewModel
        {
            get => _menuViewModel;
            set
            {
                _menuViewModel = value;
                OnPropertyChanged();
            }
        }
        
      

        public HomeViewModel()
        {
           
            
        }

        public override void Init(object parameter = null)
        {

            _menuViewModel = new MenuViewModel(); 
            NavigationService.NavigateAsync<RoomViewModel>();
        }
    }
}

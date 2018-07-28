using SmartHotel.Mvvm.Commands;
using SmartHotel.ViewModels.Base;
using SmartHotel.ViewModels.Login;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace SmartHotel.ViewModels.Home
{
    public class MenuViewModel : ViewModelBase
    {
        private ObservableCollection<MenuSource> _menus;

        public ObservableCollection<MenuSource> Menus { get => _menus; set { _menus = value; OnPropertyChanged(); } }
        public DelegateCommand<MenuSource> MenuItemSelectedCommand => new DelegateCommand<MenuSource>(OnSelectMenuItem);

        private async void OnSelectMenuItem(MenuSource item)
        {
            if (item.Name == "Book a room")
            {
               await NavigationService.NavigateAsync<HotelViewModel>();
            }
            else
                if (item.Name == "My room")
            {
                await NavigationService.NavigateAsync<RoomViewModel>();
            }
            else
                if (item.Name == "Suggestions")
            {
                await NavigationService.NavigateAsync<SuggestionsViewModel>();
            }
            else
                if (item.Name == "Concierge")
            {
                await NavigationService.NavigateAsync<ConciergeViewModel>();
            }
            else
                if (item.Name == "Logout")
            {
               
                await NavigationService.NavigateAsync<LoginViewModel>();
            }
        }

        public MenuViewModel()
        {
            Title = "Menu";
            Menus = new ObservableCollection<MenuSource>();
            Menus.Add(new MenuSource { Name = "Book a room", Image = "ic_bed" });
            Menus.Add(new MenuSource { Name = "My room", Image = "ic_key" });
            Menus.Add(new MenuSource { Name = "Suggestions", Image = "ic_bot" });
            Menus.Add(new MenuSource { Name = "Concierge", Image = "ic_beach" });
            Menus.Add(new MenuSource { Name = "Logout", Image = "ic_logout" });
         
        }

      

        internal IEnumerable<Task> Init()
        {
            throw new NotImplementedException();
        }

       
    }
    public class MenuSource : Mvvm.BindableBase
    {


        private string _name;
        private string _image;

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }


        public string Image { get => _image; set => SetProperty(ref _image, value); }
    }

  

}


using SmartHotel.Models.Entities;
using SmartHotel.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SmartHotel.ViewModels.Home
{
    class HotelViewModel : ViewModelBase
    {
        private ObservableCollection<Item> _items;

        public ObservableCollection<Item> Items { get => _items; set { _items = value; OnPropertyChanged(); } }
        public HotelViewModel()
        {
            int i = 0;
            while (i > 5)
            {
                Items.Add(new Item { Title = "The room", Image = "i_hotel_2" });
                i++;
            }
        }

        public override void Init(object parameter = null)
        {
            //new HotelViewModel();
        }
    }
}

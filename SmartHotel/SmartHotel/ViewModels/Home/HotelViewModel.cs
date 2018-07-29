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
            Items = new ObservableCollection<Item>();
               Title = "aaaa";
            int i = 1;
            while (true)
            {
                Items.Add(new Item { Title = "The room", Image = "i_hotel_2" });
                i++;
                if (i == 5) break;
            }
        }

      
        public override void Init(object parameter = null)
        {
           // new HotelViewModel();
        }
    }
}

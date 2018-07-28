using SmartHotel.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHotel.Models.Entities
{
    public class Item : ModelBase
    {
        public Item()
        {

        }
        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        
        private string _image;
        public string Image
        {
            get => _image;
            set => SetProperty(ref _image, value);
        }
    }
}

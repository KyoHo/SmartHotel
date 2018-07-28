using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SmartHotel.Views.Base
{
    public  class ViewBase : ContentPage
    {
        public ViewBase()
        {
            SetBinding(IsBusyProperty, new Binding("IsBusy"));
            SetBinding(TitleProperty, new Binding("Title"));
        }
    }
}

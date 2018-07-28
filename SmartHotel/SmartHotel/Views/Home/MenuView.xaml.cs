using SmartHotel.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartHotel.Views.Home
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuView 
	{
		public MenuView ()
		{
			InitializeComponent ();
            
           // BindingContext =new MenuViewModel();
		}
	}
}
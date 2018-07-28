using SmartHotel.Services.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHotel.ViewModels.Base
{
    public class ViewModelBase : Mvvm.BindableBase
    {

        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);

        }

        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value, () => RaisePropertyChanged(nameof(IsNotBusy)));
        }

        public bool IsNotBusy => !IsBusy;
        protected INavigationService NavigationService { get; }

        public ViewModelBase()
        {
            NavigationService = ServiceLocator.Instance.Resolve<INavigationService>();
        }

        public virtual void Init(object param)
        {
            //dosomething
        }
    }
}

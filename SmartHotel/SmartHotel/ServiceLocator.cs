using Autofac;
using System;

namespace SmartHotel
{
    public class ServiceLocator
    {
        private IContainer Container { get; set; }

        private ContainerBuilder _containerBuilder;

        public static ServiceLocator Instance { get; } = new ServiceLocator();

        public ServiceLocator()
        {
            _containerBuilder = new ContainerBuilder();
        }
        public void Build()
        {
            Container = _containerBuilder.Build();
        }

        public T Resolve<T>()
        {
            return Container.Resolve<T>();
        }

        public object Resolve(Type type)
        {
            return Container.Resolve(type);
        }

        public void Register<TInterface, TImplementation>() where TImplementation : TInterface
        {
            _containerBuilder.RegisterType<TImplementation>().As<TInterface>();
        }

        public void Register<T>() where T : class
        {
            _containerBuilder.RegisterType<T>();
        }

        public void RegisterViewModel<T>() where T : ViewModels.Base.ViewModelBase
        {
            _containerBuilder.RegisterType<T>();
        }


        public void RegisterViewModel<TViewModel, TView>() where TViewModel : ViewModels.Base.ViewModelBase
            where TView: Xamarin.Forms.Page
        {
            RegisterViewModel<TViewModel>();

            Services.Navigation.NavigationService.Mapping.Add(typeof(TViewModel), typeof(TView));
        }
    }
}

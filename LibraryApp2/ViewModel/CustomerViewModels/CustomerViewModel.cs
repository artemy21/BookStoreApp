using System;
using GalaSoft.MvvmLight;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Command;
using LibraryApp2.Views.CustomerViews;

namespace LibraryApp2.ViewModel.CustomerViewModels
{
    public class CustomerViewModel : ViewModelBase
    {
        private UserControl userControlView;
        public UserControl UserControlView
        {
            get => userControlView;
            set => Set(ref userControlView, value);
        }

        public RelayCommand GetCatalogViewCommand => new RelayCommand(() => SwitchView(typeof(CatalogView)));
        public RelayCommand GetCartViewCommand => new RelayCommand(() => SwitchView(typeof(CartView)));

        private void SwitchView(Type type) => UserControlView = (UserControl)Activator.CreateInstance(type);

        public CustomerViewModel() => UserControlView = new CatalogView();
    }
}

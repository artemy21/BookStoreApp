using System;
using GalaSoft.MvvmLight;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Command;
using LibraryApp2.Views.ManagerViews;

namespace LibraryApp2.ViewModel.ManagerViewModels
{
    public class ManagerViewModel : ViewModelBase
    {
        private UserControl userControlView;
        public UserControl UserControlView { get => userControlView; set => Set(ref userControlView, value); }

        public RelayCommand GetStorageViewCommand => new RelayCommand(() => SwitchView(typeof(StorageView)));
        public RelayCommand GetOrderViewCommand => new RelayCommand(() => SwitchView(typeof(OrderView)));
        public RelayCommand GetDiscountViewCommand => new RelayCommand(() => SwitchView(typeof(DiscountView)));
        public RelayCommand GetMailViewCommand => new RelayCommand(() => SwitchView(typeof(MailView)));

        private void SwitchView(Type type) => UserControlView = (UserControl)Activator.CreateInstance(type);

        public ManagerViewModel() => UserControlView = new OrderView();
    }
}

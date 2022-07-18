using Service.API;
using Service.Services;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using LibraryApp2.ViewModel.ManagerViewModels;
using LibraryApp2.ViewModel.CustomerViewModels;

namespace LibraryApp2.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            #region Service
            SimpleIoc.Default.Register<AddService>();
            SimpleIoc.Default.Register<IAddable>(() => SimpleIoc.Default.GetInstance<AddService>());
            SimpleIoc.Default.Register<IAddEvent>(() => SimpleIoc.Default.GetInstance<AddService>());
            SimpleIoc.Default.Register<CartAddService>();
            SimpleIoc.Default.Register<ICartaddable>(() => SimpleIoc.Default.GetInstance<CartAddService>());
            SimpleIoc.Default.Register<ICartaddEvent>(() => SimpleIoc.Default.GetInstance<CartAddService>());
            #endregion

            #region Manager
            SimpleIoc.Default.Register<ManagerViewModel>();
            SimpleIoc.Default.Register<OrderViewModel>(true);
            SimpleIoc.Default.Register<StorageViewModel>(true);
            SimpleIoc.Default.Register<EditItemViewModel>();
            SimpleIoc.Default.Register<DiscountViewModel>(true);
            SimpleIoc.Default.Register<NotificationViewModel>(true);
            SimpleIoc.Default.Register<InvoiceViewModel>(true);
            #endregion

            #region Customer
            SimpleIoc.Default.Register<CustomerViewModel>();
            SimpleIoc.Default.Register<CatalogViewModel>();
            SimpleIoc.Default.Register<CartViewModel>(true);
            SimpleIoc.Default.Register<OrderAmountViewModel>();
            #endregion
        }

        #region Manager
        public ManagerViewModel Manager => ServiceLocator.Current.GetInstance<ManagerViewModel>();
        public StorageViewModel Storage => ServiceLocator.Current.GetInstance<StorageViewModel>();
        public OrderViewModel Order => ServiceLocator.Current.GetInstance<OrderViewModel>();
        public EditItemViewModel EditItem => ServiceLocator.Current.GetInstance<EditItemViewModel>();
        public DiscountViewModel Discount => ServiceLocator.Current.GetInstance<DiscountViewModel>();
        public NotificationViewModel Notification => ServiceLocator.Current.GetInstance<NotificationViewModel>();
        public InvoiceViewModel Invoice => ServiceLocator.Current.GetInstance<InvoiceViewModel>();
        #endregion

        #region Customer
        public CustomerViewModel Customer => ServiceLocator.Current.GetInstance<CustomerViewModel>();
        public CatalogViewModel Catalog => ServiceLocator.Current.GetInstance<CatalogViewModel>();
        public CartViewModel Cart => ServiceLocator.Current.GetInstance<CartViewModel>();
        public OrderAmountViewModel OrderAmount => ServiceLocator.Current.GetInstance<OrderAmountViewModel>();
        #endregion
    }
}
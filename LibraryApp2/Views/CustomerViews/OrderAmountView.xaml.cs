using System.Windows;
using Model.ItemModels;
using LibraryApp2.ViewModel.CustomerViewModels;

namespace LibraryApp2.Views.CustomerViews
{
    public partial class OrderAmountView : Window
    {
        private readonly OrderAmountViewModel vm;
        public OrderAmountView(AbstractItem item)
        {
            InitializeComponent();
            vm = DataContext as OrderAmountViewModel;
            vm.Item = item;
            vm.CloseWindowEvent += CloseWindow;
        }

        private void ButtonClick(object sender, RoutedEventArgs e) => CloseWindow();
        private void CloseWindow()
        {
            Close();
            vm.ResetView();
        }
    }
}

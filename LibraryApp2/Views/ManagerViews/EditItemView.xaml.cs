using System;
using System.Windows;
using Model.ItemModels;
using LibraryApp2.ViewModel.ManagerViewModels;

namespace LibraryApp2.Views.ManagerViews
{
    public partial class EditItemView : Window
    {
        private readonly Action action;

        public EditItemView(AbstractItem item, Action act)
        {
            InitializeComponent();
            action = act;
            var vm = DataContext as EditItemViewModel;
            vm.Item = item;
            vm.CloseWindowEvent += CloseWindow;
            vm.CloseWindowEvent += act;
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            CloseWindow();
            action();
        }
        private void CloseWindow() => Close();
    }
}

using Service.Services;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;

namespace LibraryApp2.ViewModel.ManagerViewModels
{
    public class NotificationViewModel
    {
        public ObservableCollection<string> Messages { get; }

        public string SelectedMsg { get; set; }

        public RelayCommand DeleteItemCommand { get; }
        public RelayCommand DeleteAllCommand { get; }

        public NotificationViewModel()
        {
            Messages = new ObservableCollection<string>();
            DeleteItemCommand = new RelayCommand(DeleteItem);
            DeleteAllCommand = new RelayCommand(DeleteAll);
            AmountNotifier.ItemAmountEvent += AddMessage;
        }

        private void AddMessage(string message)
        {
            if (!Messages.Contains(message)) Messages.Add(message);
        }
        private void DeleteItem()
        {
            if (SelectedMsg == null) return;
            Messages.Remove(SelectedMsg);
            SelectedMsg = null;
        }
        private void DeleteAll() => Messages.Clear();
    }
}

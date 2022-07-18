using Model.General;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using Service.Services;

namespace LibraryApp2.ViewModel.ManagerViewModels
{
    public class InvoiceViewModel : ViewModelBase 
    {
        private readonly ObservableCollection<SaleDetails> fullInvoices;

        private ObservableCollection<SaleDetails> invoices;
        public ObservableCollection<SaleDetails> Invoices
        {
            get => invoices;
            set => Set(ref invoices, value);
        }

        #region ID
        private string id;
        public string ID
        {
            get => id;
            set => Set(ref id, value);
        }
        #endregion

        public RelayCommand SearchCommand { get; }
        public RelayCommand ClearCommand { get; }

        public InvoiceViewModel()
        {
            fullInvoices = new ObservableCollection<SaleDetails>();
            Invoices = new ObservableCollection<SaleDetails>();
            SaleDetailsService.SaleDetailsEvent += AddInvoice;
            SearchCommand = new RelayCommand(Search);
            ClearCommand = new RelayCommand(Clear);
        }

        private void AddInvoice(SaleDetails saleDetails)
        {
            fullInvoices.Add(saleDetails);
            Invoices.Add(saleDetails);
        }
        private void Search()
        {
            if (!int.TryParse(ID, out int id) || ID.Length != 9) return;
            Invoices.Clear();
            foreach (SaleDetails saleDetails in fullInvoices)
            {
                if (saleDetails.ID == id) Invoices.Add(saleDetails);
            }
        }
        private void Clear()
        {
            ID = string.Empty;
            Invoices.Clear();
            foreach (SaleDetails saleDetails in fullInvoices) Invoices.Add(saleDetails);
        }
    }
}

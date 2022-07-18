using System;
using Model.General;

namespace Service.Services
{
    public abstract class SaleDetailsService
    {
        public static event Action<SaleDetails> SaleDetailsEvent;
        public static void SendSaleDetails(SaleDetails saleDetails)
        {
            if (saleDetails == null) throw new ArgumentNullException(nameof(saleDetails));
            SaleDetailsEvent?.Invoke(saleDetails);
        }
    }
}

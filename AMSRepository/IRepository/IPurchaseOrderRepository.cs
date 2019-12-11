using AMSRepository.Models;
using System.Collections.Generic;

namespace AMSRepository.Repository
{
    public interface IPurchaseOrderRepository
    {
        PurchaseOrder CreatePurchaseOrder(PurchaseOrder purchaseOrder);

        PurchaseOrder GetPurchaseOrderByID(int purchaseOrderID);

        List<PurchaseOrder> GetPurchaseOrders();

        PurchaseOrder UpdatePurchaseOrder(PurchaseOrder purchaseOrder);
    }
}
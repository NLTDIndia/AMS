using AMSRepository.Models;
using System.Collections.Generic;

namespace AMSRepository.Repository
{
    public class PurchaseOrderRepository : BaseRepository<PurchaseOrder>, IPurchaseOrderRepository
    {
        public PurchaseOrder CreatePurchaseOrder(PurchaseOrder purchaseOrder)
        {
            return Insert(purchaseOrder);
        }

        public PurchaseOrder UpdatePurchaseOrder(PurchaseOrder purchaseOrder)
        {
            return Update(purchaseOrder);
        }

        public List<PurchaseOrder> GetPurchaseOrders()
        {
            return GetAll();
        }

        public PurchaseOrder GetPurchaseOrderByID(int purchaseOrderID)
        {
            return GetByID(purchaseOrderID);
        }
    }
}
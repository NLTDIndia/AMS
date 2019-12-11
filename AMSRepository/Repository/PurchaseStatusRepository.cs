using AMSRepository.Models;
using System.Collections.Generic;

namespace AMSRepository.Repository
{
    public class PurchaseStatusRepository : BaseRepository<PurchaseStatus>, IPurchaseStatusRepository
    {
        public PurchaseStatus CreatePurchaseStatus(PurchaseStatus purchaseStatus)
        {
            return Insert(purchaseStatus);
        }

        public PurchaseStatus UpdatePurchaseStatus(PurchaseStatus purchaseStatus)
        {
            return Update(purchaseStatus);
        }

        public List<PurchaseStatus> GetPurchaseStatus()
        {
            return GetAll();
        }

        public PurchaseStatus GetPurchaseStatusByID(int purchaseStatusID)
        {
            return GetByID(purchaseStatusID);
        }
    }
}
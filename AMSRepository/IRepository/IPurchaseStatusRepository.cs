using AMSRepository.Models;
using System.Collections.Generic;

namespace AMSRepository.Repository
{
    public interface IPurchaseStatusRepository
    {
        PurchaseStatus CreatePurchaseStatus(PurchaseStatus purchaseStatus);

        List<PurchaseStatus> GetPurchaseStatus();

        PurchaseStatus GetPurchaseStatusByID(int purchaseStatusID);

        PurchaseStatus UpdatePurchaseStatus(PurchaseStatus purchaseStatus);
    }
}
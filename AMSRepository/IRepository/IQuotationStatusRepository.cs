using AMSRepository.Models;
using System.Collections.Generic;

namespace AMSRepository.Repository
{
    public interface IQuotationStatusRepository
    {
        QuotationStatus CreateQuotationStatus(QuotationStatus quotationStatus);

        List<QuotationStatus> GetQuotationStatus();

        QuotationStatus GetQuotationStatusByID(int quotationStatusID);

        QuotationStatus UpdateQuotationStatus(QuotationStatus quotationStatus);
    }
}
using AMSRepository.Models;
using System.Collections.Generic;

namespace AMSRepository.Repository
{
    public class QuotationStatusRepository : BaseRepository<QuotationStatus>, IQuotationStatusRepository
    {
        public QuotationStatus CreateQuotationStatus(QuotationStatus quotationStatus)
        {
            return Insert(quotationStatus);
        }

        public QuotationStatus UpdateQuotationStatus(QuotationStatus quotationStatus)
        {
            return Update(quotationStatus);
        }

        public List<QuotationStatus> GetQuotationStatus()
        {
            return GetAll();
        }

        public QuotationStatus GetQuotationStatusByID(int quotationStatusID)
        {
            return GetByID(quotationStatusID);
        }
    }
}
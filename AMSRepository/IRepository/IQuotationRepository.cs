using AMSRepository.Models;
using System.Collections.Generic;

namespace AMSRepository.Repository
{
    public interface IQuotationRepository
    {
        Quotation CreateQuotation(Quotation quotation);

        Quotation GetQuotationByID(int quotationID);

        List<Quotation> GetQuotations();

        Quotation UpdateQuotation(Quotation quotation);
    }
}
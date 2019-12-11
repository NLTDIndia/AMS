using AMSRepository.Models;
using System.Collections.Generic;

namespace AMSRepository.Repository
{
    public interface IVendorRepository
    {
        Vendor CreateVendor(Vendor vendor);

        Vendor GetVendorByID(int Id);

        List<Vendor> GetVendors();

        Vendor UpdateVendor(Vendor vendor);
    }
}
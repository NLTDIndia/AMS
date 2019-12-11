using AMSRepository.Models;
using System.Collections.Generic;

namespace AMSRepository.Repository
{
    public class VendorRepository : BaseRepository<Vendor>, IVendorRepository
    {
        public List<Vendor> GetVendors()
        {
            return GetAll();
        }

        public Vendor CreateVendor(Vendor vendor)
        {
            return Insert(vendor);
        }

        public Vendor GetVendorByID(int Id)
        {
            return GetByID(Id);
        }

        public Vendor UpdateVendor(Vendor vendor)
        {
            return Update(vendor);
        }
    }
}
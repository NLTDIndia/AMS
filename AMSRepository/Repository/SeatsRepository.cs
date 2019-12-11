using AMSRepository.Models;
using System.Collections.Generic;

namespace AMSRepository.Repository
{
    public class SeatsRepository : BaseRepository<Seats>, ISeatsRepository
    {
        public Seats CreateSeat(Seats seats)
        {
            return Insert(seats);
        }

        public Seats UpdateSeat(Seats seats)
        {
            return Update(seats);
        }

        public List<Seats> GetSeats()
        {
            return GetAll();
        }

        public Seats GetSeatsByID(int seatsID)
        {
            return GetByID(seatsID);
        }
    }
}
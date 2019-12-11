using AMSRepository.Models;
using System.Collections.Generic;

namespace AMSRepository.Repository
{
    public interface ISeatsRepository
    {
        Seats CreateSeat(Seats seats);

        List<Seats> GetSeats();

        Seats GetSeatsByID(int seatsID);

        Seats UpdateSeat(Seats seats);
    }
}
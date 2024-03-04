using TicketsPurchaseService.Data.Entites;

namespace TicketsPurchaseService.Interfaces.Repository
{
    public interface IPlaneRepository
    {
        bool AddPlane(string brand, string model);
        bool AddSeats(Guid planeId, IEnumerable<Seat> seats);
        bool RemovePlaneById(Guid planeId);
        bool UpdateById(Guid planeId);
        bool Save();
        IEnumerable<Plane> GetAll();
        Plane GetById(Guid id);

    }
}

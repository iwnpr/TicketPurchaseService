using Azure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketsPurchaseService.Data;
using TicketsPurchaseService.Data.Entites;
using TicketsPurchaseService.Interfaces.Repository;

namespace TicketsPurchaseService.Repositories
{
    public class PlaneRepository : IPlaneRepository
    {
        private readonly TicketsPurchaseServiceDbContext _context;
        public PlaneRepository()
        {
            _context = new TicketsPurchaseServiceDbContext();
        }

        public bool AddPlane(string brand, string model)
        {
            try
            {
                var plane = new Plane
                {
                    Id = Guid.NewGuid(),
                    Brand = brand,
                    Model = model
                };

                _context.Planes.Add(plane);
                Save();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool AddSeats(Guid planeId, IEnumerable<Seat> seats)
        {
            var plane = _context.Planes.Any(x => x.Id == planeId);

            if (plane == true)
            {
                _context.Planes.Single(x => x.Id == planeId).Seats.AddRange(seats);
                Save();
                return true;
            }

            return false;
        }

        public IEnumerable<Plane> GetAll()
        {
            return _context.Planes.ToList();
        }

        public Plane GetById(Guid id)
        {
            var plane = _context.Planes.Single(x => x.Id == id);
            
            return plane;
        }

        public bool RemovePlaneById(Guid planeId)
        {
            var plane = _context.Planes.Single(x => x.Id == planeId);

            if (plane != null)
            {
                _context.Planes.Remove(plane);
                Save();

                return true;
            }

            return false;
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();

            return saved > 0;
        }

        public bool UpdateById(Guid planeId)
        {
            var plane = _context.Planes.Single(x => x.Id == planeId);

            if (plane != null)
            {
                _context.Update(plane);
                return Save();
            }

            return false;
        }
    }
}

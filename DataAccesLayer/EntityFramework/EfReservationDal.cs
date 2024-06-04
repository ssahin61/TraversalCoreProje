using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete;
using DataAccesLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.EntityFramework
{
	public class EfReservationDal : GenericRepository<Reservation>, IReservationDal
	{
		public List<Reservation> GetListWithReservationByWaitAccepted(int id)
		{
			using (var context = new Context())
			{
				return context.Reservations.Include(x => x.Destination).Where
					(x => x.Status == "Onaylandı" && x.AppUserID == id).ToList();
			}
		}

		public List<Reservation> GetListWithReservationByWaitPrevious(int id)
		{
			using (var context = new Context())
			{
				return context.Reservations.Include(x => x.Destination).Where
					(x => x.Status == "Geçmiş Rezervasyon" && x.AppUserID == id).ToList();
			}
		}

		public List<Reservation> GetListWithReservationByWaitApproval(int id)
		{
			using (var context = new Context())
			{
				return context.Reservations.Include(x => x.Destination).Where
					(x => x.Status == "Onay Bekliyor" && x.AppUserID == id).ToList();
			}
		}

		public List<Reservation> GetListWithReservationByUser(int id)
		{
			using (var c = new Context())
			{
				return c.Reservations
						 .Include(x => x.AppUser)
						 .Include(x => x.Destination)
						 .Where(x => x.Status == "Onaylandı" && x.AppUserID == id)
						 .ToList();
			}
		}

	}
}






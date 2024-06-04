using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Abstract
{
	public interface IReservationDal : IGenericDal<Reservation>
	{
		List<Reservation> GetListWithReservationByWaitApproval(int id);
		List<Reservation> GetListWithReservationByWaitAccepted(int id);
		List<Reservation> GetListWithReservationByWaitPrevious(int id);

		public List<Reservation> GetListWithReservationByUser(int id);
	}
}
	
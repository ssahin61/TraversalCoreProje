﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Abstract
{
	public interface IReservationService : IGenericService<Reservation>
	{
		List<Reservation> GetListWithReservationByWaitApproval(int id);
		List<Reservation> GetListWithReservationByWaitAccepted(int id);
		List<Reservation> GetListWithReservationByWaitPrevious(int id);

		List<Reservation> TGetListWithReservationByUser(int id);

	}
}

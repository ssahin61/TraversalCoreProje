﻿using BussinesLayer.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Concrete
{
	public class ReservationManager : IReservationService
	{
		private readonly IReservationDal _reservationDal;

		public ReservationManager(IReservationDal reservationDal)
		{
			_reservationDal = reservationDal;
		}

		public List<Reservation> GetListWithReservationByWaitAccepted(int id)
		{
			return _reservationDal.GetListWithReservationByWaitAccepted(id);
		}

		public List<Reservation> GetListWithReservationByWaitPrevious(int id)
		{
			return _reservationDal.GetListWithReservationByWaitPrevious(id);
		}

		public List<Reservation> GetListWithReservationByWaitApproval(int id)
		{
			return _reservationDal.GetListWithReservationByWaitApproval(id);
		}

		public void TAdd(Reservation t)
		{
			_reservationDal.Insert(t);
		}

		public void TDelete(Reservation t)
		{
			throw new NotImplementedException();
		}

		public Reservation TGetByID(int id)
		{
			throw new NotImplementedException();
		}

		public List<Reservation> TGetList()
		{
			throw new NotImplementedException();
		}

		public void TUpdate(Reservation t)
		{
			throw new NotImplementedException();
		}

		public List<Reservation> TGetListWithReservationByUser(int id)
		{
			return _reservationDal.GetListWithReservationByUser(id);
		}
	}
}

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
	public class AppUserManager : IAppUserService
	{
		private readonly IAppUserDal _appUserDal;

		public AppUserManager(IAppUserDal appUserDal)
		{
			_appUserDal = appUserDal;
		}

		public void TAdd(AppUser t)
		{
			throw new NotImplementedException();
		}

		public void TDelete(AppUser t)
		{
			throw new NotImplementedException();
		}

		public AppUser TGetByID(int id)
		{
			throw new NotImplementedException();
		}

		public List<AppUser> TGetList()
		{
			return _appUserDal.GetList();
		}

		public void TUpdate(AppUser t)
		{
			throw new NotImplementedException();
		}
	}
}

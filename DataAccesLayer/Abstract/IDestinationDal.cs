﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Abstract
{
	public interface IDestinationDal : IGenericDal<Destination>
	{
		public Destination GetDestinationWithGuide(int id);
	}
}
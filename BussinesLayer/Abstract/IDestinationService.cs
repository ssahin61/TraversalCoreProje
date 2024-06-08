﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Abstract
{
    public interface IDestinationService : IGenericService<Destination>
    {
		public Destination TGetDestinationWithGuide(int id);
		public List<Destination> TGetLast4Destination();

	}
}

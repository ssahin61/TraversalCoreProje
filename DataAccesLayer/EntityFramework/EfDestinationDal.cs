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
	public class EfDestinationtDal : GenericRepository<Destination>, IDestinationDal
	{
		public Destination GetDestinationWithGuide(int id)
		{
			using (var c = new Context())
			{
				return c.Destinations.Where(x => x.DestinationID == id).Include(x => x.Guide).FirstOrDefault();
			}
		}
	}
}

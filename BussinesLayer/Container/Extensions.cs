using BussinesLayer.Abstract;
using BussinesLayer.Concrete;
using BussinesLayer.ValidationRules;
using BussinesLayer.ValidationRules.AnnouncementValidationRules;
using BussinesLayer.ValidationRules.ContactUsValidation;
using DataAccesLayer.Abstract;
using DataAccesLayer.EntityFramework;
using DTOLayer.DTOs.AnnouncementDTOs;
using DTOLayer.DTOs.ContactUsDTOs;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Container
{
	public static class Extensions
	{
		public static void ContainerDependencies(this IServiceCollection services)
		{
			services.AddScoped<ICommentService, CommentManager>();
			services.AddScoped<ICommentDal, EfCommentDal>();

			services.AddScoped<IDestinationService, DestinationManager>();
			services.AddScoped<IDestinationDal, EfDestinationtDal>();

			services.AddScoped<IAppUserService, AppUserManager>();
			services.AddScoped<IAppUserDal, EfAppUserDal>();

			services.AddScoped<IReservationService, ReservationManager>();
			services.AddScoped<IReservationDal, EfReservationDal>();

			services.AddScoped<IGuideService, GuideManager>();
			services.AddScoped<IGuideDal, EfGuideDal>();

			services.AddScoped<IContactUsService, ContactUsManager>();
			services.AddScoped<IContactUsDal, EfContactUsDal>();

			services.AddScoped<IAnnouncementService, AnnouncementManager>();
			services.AddScoped<IAnnouncementDal, EfAnnouncementDal>();

			services.AddScoped<IExcelService, ExcelManager>();

		}

		public static void CustomerValidator(this IServiceCollection services)
		{
			services.AddTransient<IValidator<AnnouncementAddDTO>, AnnouncementValidator>();
			services.AddTransient<IValidator<SendMessageDTO>, SendContactUsValidator>();
		}
	}
}

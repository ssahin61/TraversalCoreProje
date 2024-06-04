using AutoMapper;
using DTOLayer.DTOs.AnnouncementDTOs;
using DTOLayer.DTOs.AppUserDTOs;
using DTOLayer.DTOs.ContactUsDTOs;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
namespace TraversalCoreProje.Mapping.AutoMapperProfile
{
	public class MapProfile : Profile
	{
		public MapProfile()
		{
			CreateMap<AnnouncementListDTO, Announcement>().ReverseMap();
			CreateMap<AnnouncementAddDTO, Announcement>().ReverseMap();
			CreateMap<AnnouncementUpdateDTO, Announcement>().ReverseMap();

			CreateMap<AppUserRegisterDTO, AppUser>().ReverseMap();
			CreateMap<AppUserLoginDTO, AppUser>().ReverseMap();

			CreateMap<SendMessageDTO, ContactUs>().ReverseMap();


		}

	}
}

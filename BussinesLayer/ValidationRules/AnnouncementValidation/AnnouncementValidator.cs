using DTOLayer.DTOs.AnnouncementDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.ValidationRules.AnnouncementValidationRules
{
	public class AnnouncementValidator : AbstractValidator<AnnouncementAddDTO>
	{
		public AnnouncementValidator()
		{
			RuleFor(x => x.Title)
				.NotEmpty().WithMessage("Lütfen başlığı boş geçmeyin")
				.MinimumLength(5).WithMessage("Lütfen en az 5 karakter veri girişi yapınız")
				.MaximumLength(50).WithMessage("Lütfen en fazla 50 karakter veri girişi yapınız");

			RuleFor(x => x.Content)
				.NotEmpty().WithMessage("Lütfen duyuru içeriğini boş geçmeyin")
				.MinimumLength(5).WithMessage("Lütfen en az 20 karakter veri girişi yapınız")
				.MaximumLength(500).WithMessage("Lütfen en fazla 500 karakter veri girişi yapınız");

		}
	}
}

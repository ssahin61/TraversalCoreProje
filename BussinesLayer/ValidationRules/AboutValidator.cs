using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using System.Data;

namespace BussinesLayer.ValidationRules
{
	public class AboutValidator : AbstractValidator<About>
	{
		public AboutValidator()
		{
			RuleFor(x => x.Description)
				.NotEmpty().WithMessage("Açıklama kısmı boş geçilemez..!")
				.MinimumLength(50).WithMessage("Lütfen en az 50 karakterlik açıklama bilgisi giriniz..")
				.MaximumLength(1500).WithMessage("Lütfen açıklamayı kısaltın..");

			RuleFor(x => x.Image1)
				.NotEmpty().WithMessage("Lütfen görsel seçiniz..");
		}
	}
}

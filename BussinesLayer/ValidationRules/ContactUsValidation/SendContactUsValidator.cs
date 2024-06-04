using DTOLayer.DTOs.ContactUsDTOs;
using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.ValidationRules.ContactUsValidation
{
	public class SendContactUsValidator : AbstractValidator<SendMessageDTO>
	{
		public SendContactUsValidator()
		{
			RuleFor(x => x.Name)
				.NotEmpty().WithMessage("İsim alanı boş geçilemez");

			RuleFor(x => x.Mail)
				.NotEmpty().WithMessage("Mail alanı boş geçilemez");

			RuleFor(x => x.Subject)
				.NotEmpty().WithMessage("Konu kısmı boş geçilemez")
				.MinimumLength(3).WithMessage("Konu kısmına en az 3 karakterlik veri girişi yapın")
				.MaximumLength(50).WithMessage("Konu kısmına en fazla 50 karakterlik veri girişi yapın");

			RuleFor(x => x.MessageBody)
				.NotEmpty().WithMessage("Mesaj alanı kısmı boş geçilemez")
				.MinimumLength(10).WithMessage("Mesaj alanı kısmına en az 10 karakterlik veri girişi yapın")
				.MaximumLength(200).WithMessage("Mesaj alanı kısmına en fazla 200 karakterlik veri girişi yapın");
		}
	}
}

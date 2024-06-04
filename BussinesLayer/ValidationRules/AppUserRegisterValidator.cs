﻿using DTOLayer.DTOs.AppUserDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.ValidationRules
{
	public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDTO>
	{
		public AppUserRegisterValidator()
		{
			RuleFor(x => x.Name)
				.NotEmpty().WithMessage("ad alanı boş geçilemez");

			RuleFor(x => x.Surname)
				.NotEmpty().WithMessage("soyad alanı boş geçilemez");

			RuleFor(x => x.Mail)
				.NotEmpty().WithMessage("mail alanı boş geçilemez");

			RuleFor(x => x.Username)
				.NotEmpty().WithMessage("kullanıcı adı alanı boş geçilemez")
				.MinimumLength(5).WithMessage("lütfen en az 5 karakter veri girişi yapınız")
				.MaximumLength(20).WithMessage("lütfen en fazla 20 karakter veri girişi yapınız");

			RuleFor(x => x.Password)
				.NotEmpty().WithMessage("şifre alanı boş geçilemez")
				.Equal(y => y.ConfirmPassword).WithMessage("şifreler birbiriyle uyuşmuyor");

			RuleFor(x => x.ConfirmPassword)
				.NotEmpty().WithMessage("şifre tekrar alanı boş geçilemez");



		}
	}
}

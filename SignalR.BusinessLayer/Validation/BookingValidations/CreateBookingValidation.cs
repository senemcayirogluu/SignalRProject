using FluentValidation;
using SignalR.DtoLayer.BookingDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Validation.BookingValidations
{
	public class CreateBookingValidation:AbstractValidator<CreateBookingDto>
	{
		public CreateBookingValidation()
		{
			RuleFor(x => x.Name).NotEmpty().WithMessage("Ad boş geçilemez!");
			RuleFor(x => x.Phone).NotEmpty().WithMessage("Telefon no boş geçilemez!");
			RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail alanı boş geçilemez!");
			RuleFor(x => x.PersonCount).NotEmpty().WithMessage("Kişi sayısı boş geçilemez!");
			RuleFor(x => x.Date).NotEmpty().WithMessage("Tarih boş geçilemez! Lütfen tarih seçin!");

			RuleFor(x => x.Name).MinimumLength(3).WithMessage("Ad en az 3 karakter olmalıdır!").MaximumLength(50).WithMessage("Ad en fazla 50 karakter olmalıdır!"); 
			RuleFor(x => x.Phone).MinimumLength(10).WithMessage("Telefon no en az 10 karakter olmalıdır!").MaximumLength(15).WithMessage("Telefon no en fazla 15 karakter olmalıdır!");
			RuleFor(x => x.Description).MaximumLength(500).WithMessage("Açıklama en fazla 500 karakter olmalıdır!"); 
			RuleFor(x => x.Mail).EmailAddress().WithMessage("Lütfen geçerli bir mail adresi girin!");
			RuleFor(x => x.Date).GreaterThan(DateTime.Now).WithMessage("Lütfen geçerli bir tarih seçin!");
		}
	}
}

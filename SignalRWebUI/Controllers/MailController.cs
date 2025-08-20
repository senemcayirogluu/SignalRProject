using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using SignalRWebUI.Dtos.MailDtos;

namespace SignalRWebUI.Controllers
{
	public class MailController : Controller
	{
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Index(CreateMailDto createMailDto)
		{
			MimeMessage mimeMessage = new MimeMessage();

			MailboxAddress mailboxAddressFrom = new MailboxAddress("SignalR Rezervasyon", "signalr.project.mail@gmail.com");
			mimeMessage.From.Add(mailboxAddressFrom);

			MailboxAddress mailboxAddressTo = new MailboxAddress("Kullanıcı", createMailDto.ReceiverMail);
			mimeMessage.To.Add(mailboxAddressTo);

			var bodybuilder = new BodyBuilder();
			bodybuilder.HtmlBody = createMailDto.Body;
			mimeMessage.Body = bodybuilder.ToMessageBody();

			mimeMessage.Subject = createMailDto.Subject;

			SmtpClient client = new SmtpClient();
			client.Connect("smtp.gmail.com", 587, false);
			client.Authenticate("signalr.project.mail@gmail.com", "fkhr ikdq lhbn rlyy");
			client.Send(mimeMessage);
			client.Disconnect(true);

			return RedirectToAction("Index", "Mail");
		}
	}
}

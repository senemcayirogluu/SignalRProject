using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;
using ZXing;

namespace SignalRWebUI.Controllers
{
	public class QRCodeController : Controller
	{
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Index(string value)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				QRCodeGenerator createQRCode = new QRCodeGenerator();
				QRCodeGenerator.QRCode squareCode = createQRCode.CreateQrCode(value, QRCodeGenerator.ECCLevel.Q);
				using (Bitmap image = squareCode.GetGraphic(10))
				{
					image.Save(memoryStream, ImageFormat.Png);
					ViewBag.QRCodeImage = "data:image/png;base64," + Convert.ToBase64String(memoryStream.ToArray());
				}
			}
			return View();
		}

		[HttpPost]
		public IActionResult DecodeQRCode(IFormFile file)
		{
			if (file == null || file.Length == 0)
				return BadRequest("Bir dosya yükleyin!");

			using (var stream = file.OpenReadStream())
			using (var bitmap = new Bitmap(stream))
			{
				var reader = new BarcodeReaderGeneric();
				var result = reader.Decode(bitmap);

				if (result != null)
				{
					ViewBag.DecodedText = result.Text; 
					return View("Index");
				}
				else
				{
					ModelState.AddModelError("", "QR kod çözülemedi!");
					return View("Index");
				}
			}
		}
	}
}

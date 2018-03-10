using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ReportFormsSample.Models;

namespace ReportFormsSample.Pages.Report
{
	public class BarkMoundsModel : PageModel
	{
		public string Message { get; set; }

		[BindProperty]
		public BarkMoundsFormModel FormData { get; set; }
		

		public void OnGet()
		{
			Message = "Bark Mound Report - Site Code: BM";
			FormData = new BarkMoundsFormModel();
		}

		public void OnPost()
		{
			if (!ModelState.IsValid)
			{
				Message = "Please correct your input and try again.";
				return;
			}

			Message = "Thank you for reporting the bark mound";
			FormData = new BarkMoundsFormModel();
		}
	}
}

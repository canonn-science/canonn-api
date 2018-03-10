using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ReportFormsSample.Models;

namespace ReportFormsSample.Pages.Report
{
	public class FungalGourdsModel : PageModel
	{
		public string Message { get; set; }

		[BindProperty]
		public FungalGourdsFormModel FormData { get; set; }
		

		public void OnGet()
		{
			Message = "Fungal Gourds Report - Site Code: FG";
			FormData = new FungalGourdsFormModel();
		}

		public void OnPost()
		{
			if (!ModelState.IsValid)
			{
				Message = "Please correct your input and try again.";
				return;
			}

			Message = "Thank you for reporting the Fungal Gourds";
			FormData = new FungalGourdsFormModel();
		}
	}
}

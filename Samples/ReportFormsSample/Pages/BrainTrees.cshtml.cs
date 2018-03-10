using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ReportFormsSample.Models;

namespace ReportFormsSample.Pages
{
	public class BrainTreesModel : PageModel
	{
		public string Message { get; set; }

		[BindProperty]
		public BrainTreesFormModel FormModel { get; set; }

		public void OnGet()
		{
			Message = "Please report your brain trees.";
			FormModel = new BrainTreesFormModel();
		}

		public void OnPost()
		{
			if (!ModelState.IsValid)
			{
				Message = "Please correct your input and try again.";
				return;
			}

			Message = "Thank you for reporting the brain trees.";
			FormModel = new BrainTreesFormModel();
		}
	}
}


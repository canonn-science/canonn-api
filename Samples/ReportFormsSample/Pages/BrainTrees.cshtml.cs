using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using ReportFormsSample.Models;

namespace ReportFormsSample.Pages
{
	public class BrainTreesModel : PageModel
	{
		public string Message { get; set; }
		public string Debug { get; set; }

		[BindProperty]
		public BrainTreesFormModel FormModel { get; set; }

		public void OnGet()
		{
			Message = "Please report your brain trees.";
			Debug = String.Empty;
			FormModel = new BrainTreesFormModel();
		}

		public IActionResult OnPost()
		{
			if (!ModelState.IsValid)
				return Page();

			Message = "Thank you for reporting the brain trees.";
			Debug = JsonConvert.SerializeObject(FormModel, Formatting.Indented);

			FormModel = new BrainTreesFormModel();

			return Page();
		}
	}
}


using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ReportingHub.Pages
{
	public class ContactModel : PageModel
	{
		public string Message { get; set; }

		public void OnGet()
		{
			Message = "Your contact page.";
		}
	}
}

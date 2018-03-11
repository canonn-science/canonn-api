using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ReportingHub.RazorPages
{
	public abstract class BaseFormModel<TFormModel> : PageModel
		where TFormModel : new()
	{
		protected string StartMessage { get; set; }
		protected string ThankYouMessage { get; set; }
		protected string ErrorMessage { get; set; } = "Please correct your input and try again.";

		public string Type { get; set; }
		public string Code { get; set; }
		public string Message { get; set; }
		
		[BindProperty]
		public TFormModel FormData { get; set; }

		protected BaseFormModel() { }

		protected BaseFormModel(string type, string code)
		{
			Type = type;
			Code = code;
			StartMessage = $"{Type} Report - Site Code: {Code}";
			ThankYouMessage = $"Thank you for reporting the {Type}.";
		}

		public virtual void OnGet()
		{
			Message = StartMessage;
			FormData = new TFormModel();
		}

		public virtual void OnPost()
		{
			if (!ModelState.IsValid)
			{
				Message = ErrorMessage;
				return;
			}

			Message = ThankYouMessage;
			FormData = new TFormModel();
		}
	}
}

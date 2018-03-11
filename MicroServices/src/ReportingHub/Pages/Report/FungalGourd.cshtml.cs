using ReportingHub.Models;
using ReportingHub.RazorPages;

namespace ReportingHub.Pages.Report
{
	public class FungalGourdModel : BaseFormModel<FungalGourdFormModel>
	{
		public FungalGourdModel()
			: base("Fungal Gourd", "FG")
		{
		}
	}
}

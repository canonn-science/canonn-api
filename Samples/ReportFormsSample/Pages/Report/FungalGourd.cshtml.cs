using ReportFormsSample.Models;
using ReportFormsSample.RazorPages;

namespace ReportFormsSample.Pages.Report
{
	public class FungalGourdModel : BaseFormModel<FungalGourdFormModel>
	{
		public FungalGourdModel()
			: base("Fungal Gourd", "FG")
		{
		}
	}
}

using ReportFormsSample.Models;
using ReportFormsSample.RazorPages;

namespace ReportFormsSample.Pages.Report
{
	public class BarkMoundsModel : BaseFormModel<BarkMoundFormModel>
	{
		public BarkMoundsModel()
			: base("Bark Mound", "BM")
		{
		}
	}
}

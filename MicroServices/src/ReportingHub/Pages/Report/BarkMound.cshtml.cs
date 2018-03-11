using ReportingHub.Models;
using ReportingHub.RazorPages;

namespace ReportingHub.Pages.Report
{
	public class BarkMoundsModel : BaseFormModel<BarkMoundFormModel>
	{
		public BarkMoundsModel()
			: base("Bark Mound", "BM")
		{
		}
	}
}

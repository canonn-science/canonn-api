using ReportFormsSample.Models;
using ReportFormsSample.RazorPages;

namespace ReportFormsSample.Pages.Report
{
	public class GeyserModel : BaseFormModel<GeyserFormModel>
	{
		public GeyserModel()
			: base("Geyser", "GY")
		{
		}
	}
}

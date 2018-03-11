using ReportingHub.Models;
using ReportingHub.RazorPages;

namespace ReportingHub.Pages.Report
{
	public class GeyserModel : BaseFormModel<GeyserFormModel>
	{
		public GeyserModel()
			: base("Geyser", "GY")
		{
		}
	}
}

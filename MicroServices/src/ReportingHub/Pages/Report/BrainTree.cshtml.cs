using ReportingHub.Models;
using ReportingHub.RazorPages;

namespace ReportingHub.Pages.Report
{
	public class BrainTreeModel : BaseFormModel<BrainTreeFormModel>
	{
		public BrainTreeModel()
			: base("Brain Tree", "BT")
		{
		}
	}
}


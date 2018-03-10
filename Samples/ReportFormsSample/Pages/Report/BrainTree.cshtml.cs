using ReportFormsSample.Models;
using ReportFormsSample.RazorPages;

namespace ReportFormsSample.Pages.Report
{
	public class BrainTreeModel : BaseFormModel<BrainTreeFormModel>
	{
		public BrainTreeModel()
			: base("Brain Tree", "BT")
		{
		}
	}
}


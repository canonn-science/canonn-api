using ReportFormsSample.Models;
using ReportFormsSample.RazorPages;

namespace ReportFormsSample.Pages.Report
{
	public class FumaroleModel : BaseFormModel<FumaroleFormModel>
	{
		public FumaroleModel()
			: base("Fumarole", "FM")
		{
		}
	}
}

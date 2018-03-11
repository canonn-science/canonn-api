using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ReportingHub.Pages.Components.MainMenu
{
	public class MainMenuViewComponent : ViewComponent
	{
		public Task<IViewComponentResult> InvokeAsync()
		{
			return Task.FromResult((IViewComponentResult)View());
		}
	}
}

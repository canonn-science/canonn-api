using FormFactory.Attributes;

namespace ReportFormsSample.Models
{
	public class BrainTreeFormModel
	{
		[Required()]
		[Display(Name="Commander Name", Prompt="Your Commander name")]
		[Description("Give yourself or someone else, credit as the locator. Multiple names allowed.")]
		public string CommanderName { get; set; }

		[NoLabel]
		public PlanetaryLocation Location { get; set; } = new PlanetaryLocation();

		[Required()]
		[Display(Name = "Link to screenshot", Prompt = "http://imgur.com/your_image")]
		[Description("It is required that you include a screenshot to allow for validation.")]
		public string ScreenshotUrl { get; set; }

		[Display(Name = "Amount")]
		[Description("You can include the amount of Brain Trees at this site if you whish.")]
		public int Amount { get; set; }

		[Display(Name = "Link to forum post", Prompt = "https://forums.frontier.co.uk/forum.php")]
		[Description("Please post your finding at the FD forum, so that we can get back later and find your name, evidence and if we have any questions.")]
		public string ForumPostUrl { get; set; }

		[Description("If you have any specifics you would like to mention please do so here.")]
		[MultilineText]
		public string QuestionsCommentsAndConcerns { get; set; }
	}
}

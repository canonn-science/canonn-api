using System;
using FormFactory.Attributes;
using DataType = System.ComponentModel.DataAnnotations.DataType;

namespace ReportFormsSample.Models
{
	public class BrainTreesFormModel
	{
		[Required()]
		[Display(Name="Commander Name", Prompt="Your Commander name")]
		[Description("Give yourself or someone else, credit as the locator. Multiple names allowed.")]
		public string CommanderName { get; set; }

		[Required()]
		[Display(Name="System", Prompt="The system where the brain trees were found")]
		[Description("Please ensure you spell the system name correctly.")]
		public string System { get; set; }

		[Required()]
		[Display(Name = "Planet", Prompt = "The name of the planet")]
		[Description("Please put proper spacing between groups (A 8, B 7, AB 3, etc.).")]		
		public string Body { get; set; }

		[Required()]
		[Range(-90, 90)]
		[RegularExpression(@"\d+(\.\d{4})")]
		[Display(Name="Latitude", Prompt = "0.0000")]
		[Description("4 decimal points, NOT rounded, value between -90 and +90 (Please use periods).")]
		public decimal Latitude { get; set; }

		[Required()]
		[Range(-180, 180)]
		[RegularExpression(@"\d+(\.\d{4})")]
		[Display(Name="Longitude", Prompt = "0.0000")]
		[Description("4 decimal points, NOT rounded, value between -180 and +180 (Please use periods).")]
		public decimal Longitude { get; set; }

		[Required()]
		[System.ComponentModel.DataAnnotations.DataType(DataType.Url)]
		[Display(Name = "Link to screenshot", Prompt = "http://imgur.com/your_image")]
		[Description("It is required that you include a screenshot to allow for validation.")]
		public string ScreenshotUrl { get; set; }

		[Description("You can include the count of brain trees if you whish.")]
		public int AmountOfBrainTrees { get; set; }

		[Display(Name = "Link to forum post", Prompt = "https://forums.frontier.co.uk/forum.php")]
		[System.ComponentModel.DataAnnotations.DataType(DataType.Url)]
		[RegularExpression(@"/^([a-z0-9+.-]+):(?://(?:((?:[a-z0-9-._~!$&'()*+,;=:]|%[0-9A-F]{2})*)@)?((?:[a-z0-9-._~!$&'()*+,;=]|%[0-9A-F]{2})*)(?::(\d*))?(/(?:[a-z0-9-._~!$&'()*+,;=:@/]|%[0-9A-F]{2})*)?|(/?(?:[a-z0-9-._~!$&'()*+,;=:@]|%[0-9A-F]{2})+(?:[a-z0-9-._~!$&'()*+,;=:@/]|%[0-9A-F]{2})*)?)(?:\?((?:[a-z0-9-._~!$&'()*+,;=:/?@]|%[0-9A-F]{2})*))?(?:#((?:[a-z0-9-._~!$&'()*+,;=:/?@]|%[0-9A-F]{2})*))?$/i", FriendlyFormat = "an url.")]
		[Description("Please post your finding at the FD forum, so that we can get back later and find your name, evidence and if we have any questions.")]
		public string ForumPostUrl { get; set; }

		[Description("If you have any specifics you would like to mention please do so here.")]
		[MultilineText]
		public string QuestionsCommentsAndConcerns { get; set; }
	}
}

using FormFactory.Attributes;

namespace ReportFormsSample.Models
{
	public enum GeyserType
	{
		[Display(Name ="Ammonia Magma")]
		AmmoniaMagma,
		[Display(Name ="Iron Magma")]
		IronMagma,
		[Display(Name ="Major Metallic Magma")]
		MajorMetalligMagma,
		[Display(Name ="Major Rocky Magma")]
		MajorRockyMagma,
		[Display(Name ="Metallic Magma")]
		MetallicMagma,
		[Display(Name ="Rocky Magma")]
		RockyMagma,
		[Display(Name ="Silicate Magma")]
		SilicateMagma,
		[Display(Name ="Silicate Vapour")]
		SilicateVapour,
		[Display(Name ="Other. Please specify below.")]
		Other,
	}

	public class GeyserFormModel
	{
		[Required()]
		[Display(Name="Commander Name", Prompt="Your Commander name")]
		[Description("Give yourself or someone else, credit as the locator. Multiple names allowed.")]
		public string CommanderName { get; set; }

		[NoLabel]
		public PlanetaryLocation Location { get; set; } = new PlanetaryLocation();

		[Display(Name = "Geyser type")]
		[Description("If your type isn't listed, please use the other.")]
		[Radio]
		public GeyserType GeyserType { get; set; }

		[Display(Name = "Geyser type")]
		[Description("If your type isn't listed, please use the other.")]
		public string CustomFumeroleType { get; set; }

		[Required()]
		[Display(Name = "Link to screenshot", Prompt = "http://imgur.com/your_image")]
		[Description("It is required that you include a screenshot to allow for validation.")]
		public string ScreenshotUrl { get; set; }

		[Display(Name = "Amount")]
		[Description("You can include the amount of Geysers at this site if you whish.")]
		public int Amount { get; set; }

		[Display(Name = "Link to forum post", Prompt = "https://forums.frontier.co.uk/forum.php")]
		[Description("Please post your finding at the FD forum, so that we can get back later and find your name, evidence and if we have any questions.")]
		public string ForumPostUrl { get; set; }

		[Description("If you have any specifics you would like to mention please do so here.")]
		[MultilineText]
		public string QuestionsCommentsAndConcerns { get; set; }
	}
}

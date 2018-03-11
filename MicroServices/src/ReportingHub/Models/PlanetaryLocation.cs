using FormFactory.Attributes;

namespace ReportingHub.Models
{
	public class PlanetaryLocation
	{
		[Required()]
		[Display(Name="System", Prompt="The name of the star system")]
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
	}
}

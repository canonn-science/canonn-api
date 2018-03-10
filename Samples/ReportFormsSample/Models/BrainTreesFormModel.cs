﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ReportFormsSample.Models
{
	public class BrainTreesFormModel
	{
		[Required()]
		[Display(Name="Your Commander Name")]
		[Description("Give yourself or someone else, credit as the locator. Multiple names allowed.")]
		public string CommanderName { get; set; }

		[Required()]
		[Description("Please ensure you spell the System name correctly.")]
		public string System { get; set; }

		[Required()]
		[Description("Please put proper spacing between groups (A 8, B 7, AB 3, etc.).")]
		public string Planet { get; set; }

		[Required()]
		[Description("4 decimal points, NOT rounded, value between -90 and +90 (Please use periods).")]
		[Range(-90, 90)]
		[DefaultValue(0.0000d)]
		[RegularExpression(@"\d+(\.\d{4})", ErrorMessage = "4 decimal points are required.")]
		public decimal Latitude { get; set; }

		[Required()]
		[Description("4 decimal points, NOT rounded, value between -180 and +180 (Please use periods).")]
		[Range(-180, 180)]
		[DefaultValue(0.0000d)]
		[RegularExpression(@"\d+(\.\d{4})", ErrorMessage = "4 decimal points are required.")]
		public decimal Longitude { get; set; }

		[Required()]
		[Description("It is required that you include a screenshot to allow for validation.")]
		public string ScreenshotUrl { get; set; }

		[Description("You can include the count of brain trees if you whish.")]
		public int AmountOfBrainTrees { get; set; }

		[Description("Please post your finding at the FD forum, so that we can get back later and find your name, evidence and if we have any questions.")]
		public string ForumPostUrl { get; set; }

		[Description("If you have any specifics you would like to mention please do so here.")]
		[DataType(DataType.MultilineText)] 
		public string QuestionsCommentsAndConcerns { get; set; }
	}
}

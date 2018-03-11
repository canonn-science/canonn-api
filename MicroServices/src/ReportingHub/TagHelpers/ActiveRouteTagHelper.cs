using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ReportingHub.TagHelpers
{
	[HtmlTargetElement(Attributes = "is-active-route")]

	public class ActiveRouteTagHelper : TagHelper
	{
		private IDictionary<string, string> _routeValues;

		/// <summary>The name of the page method.</summary>
		/// <remarks>Must be <c>null</c> if <see cref="P:Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper.Route" /> is non-<c>null</c>.</remarks>
		[HtmlAttributeName("asp-page")]
		public string Page { get; set; }


		/// <summary>Additional parameters for the route.</summary>
		[HtmlAttributeName("asp-all-route-data", DictionaryAttributePrefix = "asp-route-")]
		public IDictionary<string, string> RouteValues
		{
			get => _routeValues ?? (_routeValues = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase));
			set => _routeValues = value;
		}

		/// <summary>
		/// Gets or sets the <see cref="T:Microsoft.AspNetCore.Mvc.Rendering.ViewContext" /> for the current request.
		/// </summary>
		[HtmlAttributeNotBound]
		[ViewContext]
		public ViewContext ViewContext { get; set; }


		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			base.Process(context, output);

			if (ViewContext.ActionDescriptor.DisplayName == Page)
			{
				MakeActive(output);
			}

			output.Attributes.RemoveAll("is-active-route");
		}

		private void MakeActive(TagHelperOutput output)
		{
			var classAttr = output.Attributes.FirstOrDefault(a => a.Name == "class");

			if (classAttr == null)
			{
				classAttr = new TagHelperAttribute("class", "active");
				output.Attributes.Add(classAttr);
			}
			else if (classAttr.Value == null || classAttr.Value.ToString().IndexOf("active", StringComparison.Ordinal) < 0)
			{
				output.Attributes.SetAttribute("class",
					classAttr.Value == null
						? "active"
						: classAttr.Value + " active"
				);
			}
		}
	}
}

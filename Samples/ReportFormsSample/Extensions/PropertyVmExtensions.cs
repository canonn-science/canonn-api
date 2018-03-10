using System.Linq;

// ReSharper disable once CheckNamespace
namespace FormFactory
{
	public static class PropertyVmExtensions
	{
		public static string GetDescription(this PropertyVm property)
		{
			// First FormFactory, then fallback to System.ComponentModel
			return property
					   .GetCustomAttributes()
					   .OfType<FormFactory.Attributes.DescriptionAttribute>()
					   .Select(att => att.Description)
					   .FirstOrDefault()
				   ?? property
					   .GetCustomAttributes()
					   .OfType<System.ComponentModel.DescriptionAttribute>()
					   .Select(att => att.Description)
					   .FirstOrDefault();
		}

		public static bool IsRequired(this PropertyVm property)
		{
			return property.HasAttribute<FormFactory.Attributes.RequiredAttribute>()
				   || property.HasAttribute<System.ComponentModel.DataAnnotations.RequiredAttribute>();
		}

		public static string GetDefaultValueOrPrompt(this PropertyVm property)
		{
			return property.GetCustomAttributes()
					.OfType<System.ComponentModel.DefaultValueAttribute>()
					.Select(att => att.Value.ToString())
					.FirstOrDefault()
				?? property
					.GetCustomAttributes()
					.OfType<FormFactory.Attributes.DisplayAttribute>()
					.Select(att => att.Prompt)
					.FirstOrDefault();
		}
	}
}

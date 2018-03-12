namespace DomainServices
{
	using DDD.Abstractions;
	using Microsoft.Extensions.DependencyInjection;

	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddDomainServices(IServiceCollection services)
		{
			return services
				.AddTransient<IAggregateFactory, AggregateFactory>()
				.AddTransient(typeof(IEventDispatcher<>), typeof(TypeBasedEventDispatcher<>));
		}
	}
}

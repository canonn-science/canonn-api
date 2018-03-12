using System;
using DDD.Abstractions;
using Domain.Aggregates;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Xunit;

namespace DomainServices.IntegrationTests.EntityFactoryTests
{
	public class CreateEntity
	{
		[Fact]
		public void Should_Create_Entity()
		{
			var serviceProvider = new ServiceCollection()
				.AddLogging(lb => lb.SetMinimumLevel(LogLevel.None))
				.AddTransient<IAggregateFactory, AggregateFactory>()
				.AddTransient(typeof(IEventDispatcher<>), typeof(TypeBasedEventDispatcher<>))
				.BuildServiceProvider();

			var sut = serviceProvider.GetRequiredService<IAggregateFactory>();

			var entity = sut.CreateEntity<StarSystem>();

			entity.Should().NotBeNull();
			entity.GetType().Should().Be<StarSystem>();
			entity.Id.Should().NotBe(Guid.Empty);
		}

		[Fact]
		public void Should_Create_Entity_With_Id()
		{
			var serviceProvider = new ServiceCollection()
				.AddLogging(lb => lb.SetMinimumLevel(LogLevel.None))
				.AddTransient<IAggregateFactory, AggregateFactory>()
				.AddTransient(typeof(IEventDispatcher<>), typeof(TypeBasedEventDispatcher<>))
				.BuildServiceProvider();

			var id = new Guid("affeaffe-dead-beef-dead-affeaffeaffe");

			var sut = serviceProvider.GetRequiredService<IAggregateFactory>();

			var entity = sut.CreateEntity<StarSystem>(id);

			entity.Should().NotBeNull();
			entity.GetType().Should().Be<StarSystem>();
			entity.Id.Should().Be(id);
		}

		[Fact]
		public void Aggregate_Should_Update()
		{
			var serviceProvider = new ServiceCollection()
				.AddLogging(lb => lb.SetMinimumLevel(LogLevel.None))
				.AddTransient<IAggregateFactory, AggregateFactory>()
				.AddTransient(typeof(IEventDispatcher<>), typeof(TypeBasedEventDispatcher<>))
				.BuildServiceProvider();

			var factory = serviceProvider.GetRequiredService<IAggregateFactory>();

			var aggregate = factory.CreateEntity<StarSystem>();

			aggregate.Should().NotBeNull();
			aggregate.GetType().Should().Be<StarSystem>();

			var id = Guid.NewGuid();
			aggregate.ApplyEvent(new StarSystemCreatedEvent()
			{
				Id = Guid.NewGuid(),
				Name = "Shinrarta Dezhra",
				SystemId = id,
			});

			aggregate.Id.Should().Be(id);
			aggregate.Name.Should().Be("Shinrarta Dezhra");
			aggregate.Version.Should().Be(1);

			aggregate.ApplyEvent(new StarSystemImporteddEvent()
			{
				Id = Guid.NewGuid(),
				EdsmId = 1,
				FdevId = 1,
				TimeStamp = DateTime.UtcNow,
			});

			aggregate.Version.Should().Be(2);
			aggregate.LastImported.Should().NotBeNull();
		}

	}
}

using System;
using Domain.Entities;
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
				.BuildServiceProvider();

			var sut = new EntityFactory(
				serviceProvider.GetService<ILogger<EntityFactory>>(),
				serviceProvider);

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
				.BuildServiceProvider();
			var id = new Guid("affeaffe-dead-beef-dead-affeaffeaffe");

			var sut = new EntityFactory(
				serviceProvider.GetService<ILogger<EntityFactory>>(),
				serviceProvider);

			var entity = sut.CreateEntity<StarSystem>(id);

			entity.Should().NotBeNull();
			entity.GetType().Should().Be<StarSystem>();
			entity.Id.Should().Be(id);
		}
	}
}

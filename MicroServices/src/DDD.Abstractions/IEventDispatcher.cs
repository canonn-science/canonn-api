namespace DDD.Abstractions
{
	public interface IEventDispatcher
	{
		void DispatchEvent(IAggregate aggregate, IEvent evt);
	}

	public interface IEventDispatcher<TAggregate> : IEventDispatcher
		where TAggregate: class, IAggregate
	{
	}
}

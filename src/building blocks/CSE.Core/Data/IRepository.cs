using CSE.Core.DomainObjects;

namespace CSE.Core.Data;

public interface IRepository<T> : IDisposable where T : IAggregateRoot
{

}

namespace CSE.Core.Data;

public interface IUnitOfWork
{
    Task<bool> Commit();
}

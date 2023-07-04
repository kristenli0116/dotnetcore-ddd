namespace Turakas.Domain.SharedKernel.Generics;

public interface IRepository<TEntity> : IRepository
{
    
}

public interface IRepository<TEntity, TKey> : IRepository<TEntity> where TKey : IComparable<TKey>
{
    
}
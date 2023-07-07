namespace Turakas.Domain.SharedKernel.Generics;

public interface IRepository<TEntity>: IRepository where TEntity :EntityBase
{
    
}

public interface IRepository<TEntity, TKey> : IRepository<TEntity> 
    where TEntity : EntityBase
    where TKey : IComparable<TKey>
{
    
}
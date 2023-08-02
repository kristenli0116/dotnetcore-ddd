namespace Turakas.Domain.SharedKernel.Generics
{
    public abstract class EntityBase<TKey> :EntityBase where TKey : class
    {
        public new TKey Id { get; protected set; } = null!;
    }
}
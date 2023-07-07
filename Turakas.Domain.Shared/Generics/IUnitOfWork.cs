using System.Net.Mime;

namespace Turakas.Domain.SharedKernel.Generics;

public interface IUnitOfWork<TKey> : IUnitOfWork where TKey : IComparable<TKey>
{
}
namespace Turakas.Domain.SharedKernel;

/// <summary>
/// 仓库
/// </summary>
public interface IRepository
{
    IUnitOfWork UnitOfWork { get; }
}
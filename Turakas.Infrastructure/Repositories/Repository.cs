using Microsoft.EntityFrameworkCore;
using Turakas.Domain.Models.Auth;
using Turakas.Domain.SharedKernel;
using Turakas.Domain.SharedKernel.Generics;

namespace Turakas.Infrastructure.Repositories;

public class Repository : IRepository
{
    private readonly DbContext _dbContext;

    public Repository(DbContext dbContext, IUnitOfWork unitOfWork)
    {
        _dbContext = dbContext;
        UnitOfWork = unitOfWork;
    }

    public IUnitOfWork UnitOfWork { get; }
}
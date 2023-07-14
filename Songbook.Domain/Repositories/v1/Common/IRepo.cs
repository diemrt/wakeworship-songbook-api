using System;
namespace Songbook.Domain.Repositories.v1.Common
{
    public interface IRepo
    {
        IUnitOfWork UnitOfWork { get; }
    }
}


using System;
using Songbook.Domain.Entities.v1;
using Songbook.Domain.Repositories.v1.Common;

namespace Songbook.Domain.Repositories.v1
{
    public interface IChordTypeRepository : IGenericRepo<ChordType>
    {
        Task<IEnumerable<ChordType>> GetAllAsync();
    }
}


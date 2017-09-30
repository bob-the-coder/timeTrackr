using System;

namespace DataLayer.Interfaces
{
    public interface ISinglePkDataAccessObject : IDataAccessObject
    {
        Guid Id { get; set; }
    }
}
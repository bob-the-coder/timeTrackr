using System;

namespace BusinessLogic.Interfaces
{
    public interface ISinglePkModel : IModel
    {
        Guid Id { get; set; }
    }
}

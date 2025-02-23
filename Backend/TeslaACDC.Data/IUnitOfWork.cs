using System;
using TeslaACDC.Data.Models;

namespace TeslaACDC.Data;

public interface IUnitOfWork
{
    IRepository<int, Autor> AutorRepository { get; }

    Task SaveAsync();
}

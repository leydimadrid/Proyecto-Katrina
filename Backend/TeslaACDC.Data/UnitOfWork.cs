using System;
using Microsoft.EntityFrameworkCore;
using TeslaACDC.Data.Models;

namespace TeslaACDC.Data;

public class UnitOfWork : IUnitOfWork
{
    internal TeslaContext _context;
    private IRepository<int, Autor> _autorRepository;
    private bool _disposed = false;

    public UnitOfWork(TeslaContext context)
    {
        _context = context;

    }


    public IRepository<int, Autor> AutorRepository
    {
        get
        {
            _autorRepository ??= new Repository<int, Autor>(_context);
            return _autorRepository;
        }
    }

    public async Task SaveAsync()
    {
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException ex)
        {
            ex.Entries.Single().Reload();

        }
    }

    #region IDisposable
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _context.DisposeAsync();
            }
        }
        _disposed = true;
    }
    public void Dispose()
    {
        Dispose(true);
    }

    #endregion
}

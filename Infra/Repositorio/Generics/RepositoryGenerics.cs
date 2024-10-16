using Domain.Interfaces.Generics;
using Infra.Configuracao;
using Microsoft.EntityFrameworkCore;

public class RepositoryGenerics<T> : IGenerics<T>, IDisposable where T : class
{
    private readonly DbContextOptions<ContextBase> _optionsBuilder;
    private bool _disposed = false; // Sinalizador para detectar chamadas redundantes

    public RepositoryGenerics()
    {
        _optionsBuilder = new DbContextOptions<ContextBase>();
    }

    public async Task Add(T objeto)
    {
        using (var data = new ContextBase(_optionsBuilder))
        {
            await data.Set<T>().AddAsync(objeto);
            await data.SaveChangesAsync();
        }
    }

    public async Task Delete(T objeto)
    {
        using (var data = new ContextBase(_optionsBuilder))
        {
            data.Set<T>().Remove(objeto);
            await data.SaveChangesAsync();
        }
    }

    public async Task<T> GetEntityById(int id)
    {
        using (var data = new ContextBase(_optionsBuilder))
        {
            return await data.Set<T>().FindAsync(id);
        }
    }

    public async Task<List<T>> List()
    {
        using (var data = new ContextBase(_optionsBuilder))
        {
            return await data.Set<T>().AsNoTracking().ToListAsync();
        }
    }

    public async Task Update(T objeto)
    {
        using (var data = new ContextBase(_optionsBuilder))
        {
            data.Set<T>().Update(objeto);
            await data.SaveChangesAsync();
        }
    }

    // Dispose method
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this); // Impedir que o finalizador seja executado
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                // Descarte recursos gerenciados se houver
                // Neste caso, não há nada para descartar, pois o ContextBase é descartado em instruções using
            }
                // Descarte recursos não gerenciados, se houver

            _disposed = true;
        }
    }
}

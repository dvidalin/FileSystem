
namespace FileSystem.Core.Interfaces
{
    public  interface IReadRepositoryBase<T> where T : class
    {
        Task<T?> GetByIdAsync<Tid>(Tid id) where Tid : notnull;
        Task<List<T>> ListAsync();
        Task<int> CountAsync();
        Task<bool> AnyAsync();

    }
}

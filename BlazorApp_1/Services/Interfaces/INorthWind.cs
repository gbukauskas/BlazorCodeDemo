using BlazorApp_1.DataContext.Models;

namespace BlazorApp_1.Services.Interfaces
{
    public interface INorthWind<T, K> where T : class
                                      where K : IComparable
    {
        Task<T> CreateEntity(NorthwindContext ctx, T newEntity);
        Task<IEnumerable<T>> CreateEntities(NorthwindContext ctx, IEnumerable<T> collection);
        Task<T> UpdateEntity(NorthwindContext ctx, T entity);

        IQueryable<T> GetAllEntities(NorthwindContext ctx);
        Task<T> GetEntityByIdAsync(NorthwindContext ctx, K id);
        Task<K> DeleteEntityByIdAsync(NorthwindContext ctx, K id);
    }
}

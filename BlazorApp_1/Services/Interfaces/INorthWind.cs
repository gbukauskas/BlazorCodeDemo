using BlazorApp_1.DataContext.Models;

namespace BlazorApp_1.Services.Interfaces
{
    public interface INorthWind<T> where T : class
    {
        IQueryable<T> GetAllEntities(NorthwindContext ctx);
        Task<T> GetEntityById(NorthwindContext ctx, int id);
        Task<T> CreateEntity(NorthwindContext ctx, T newEntity);
        Task UpdateEntity(T entity);
    }
}

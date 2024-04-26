using BlazorApp_1.DataContext.RequestResponse;

namespace BlazorApp_1.Services.Interfaces
{
    public interface IPagedCollection<T> where T : class
    {
        public Task<PageResponse<T>> GetPageAsync(IQueryable<T> collection, int pageSize, int pageNumber);
    }
}

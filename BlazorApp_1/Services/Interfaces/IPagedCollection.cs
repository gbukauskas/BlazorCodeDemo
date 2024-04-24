using BlazorApp_1.DataContext.Models;
using BlazorApp_1.DataContext.RequestResponse;

namespace BlazorApp_1.Services.Interfaces
{
    public interface IPagedCollection<T> where T : class
    {
        public Task<PageResponse<T>> GetPage(NorthwindContext ctx, int pageSize, int pageNumber);
    }
}

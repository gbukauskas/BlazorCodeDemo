namespace BlazorApp_1.DataContext.RequestResponse
{
    public class PageResponse<T> where T : class
    {
        public int TotalRecords { get; set; }
        public int TotalPages { get; set; } = 0;
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public IEnumerable<T>? Items { get; set; }
    }
}

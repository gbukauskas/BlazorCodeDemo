namespace BlazorApp_1.DataContext.RequestResponse
{
    public class PageResponse<T> where T : class
    {
        /// <summary>
        /// Number of records in the dataset
        /// </summary>
        public int TotalRecords { get; set; }

        /// <summary>
        /// Total number of pages
        /// </summary>
        public int TotalPages { get; set; } = 0;

        /// <summary>
        /// Number of records in the page
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Number of current page. Page numbering starts from 1.
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// Content of the current page.
        /// </summary>
        public IEnumerable<T>? Items { get; set; }
    }
}

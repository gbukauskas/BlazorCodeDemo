namespace BlazorApp_1.Client.Models
{
    public struct PagerData
    {
        internal int Id { get; set; }
        internal string PageIndex { get; set; }
        internal bool IsSelected { get; set; }
        internal bool IsDisabled { get; set; }

        internal PagerData(int pgIndex, bool isSelected = false, bool isDisabled = false)
        {
            Id = pgIndex;
            PageIndex = pgIndex.ToString();
            IsSelected = isSelected;
            IsDisabled = isDisabled;
        }
    }
}

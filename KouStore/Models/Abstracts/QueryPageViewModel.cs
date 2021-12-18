using KouStore.Config;

namespace KouStore.Models.Absracts
{
    public abstract class QueryPageViewModel<T> where T : class, new()
    {
        public abstract List<T> QueryModels { get; set; }
        public int MaxModelSizePerPage { get; set; } = Settings.MaxModelSizePerPage;
        public int CurrentPage { get; set; } = 1;
        public int TotalPageCount
        {
            get
            {
                if (TotalModelCount == 0) return 1;
                int count = TotalModelCount / MaxModelSizePerPage;
                if (TotalModelCount % MaxModelSizePerPage != 0) count++;
                return count;
            }
        }
        public int TotalModelCount { get; set; }
    }
}

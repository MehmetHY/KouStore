namespace KouStore.Models.Interfaces
{
    public interface IQueryPageViewModel<T> where T : class, new()
    {
        public List<T> QueryModels { get; set; }
        public int MaxModelSizePerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPageCount { get; }
        public int TotalModelCount { get; set; }
    }
}

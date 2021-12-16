namespace KouStore.Models.Interfaces
{
    public interface IViewModel
    {
        public bool Result { get; }
        public void ValidateViewModel();
    }
}

namespace KouStore.Config
{
    public static class Settings
    {
        public const int MaxImageSizeInMB = 5;
        public const int MaxImageSizeInBytes = MaxImageSizeInMB * 1000000;
        public static string[] AllowedImageExtensions => new string[]{ ".jpg", ".JPG", ".jpeg", ".JPEG" };
        public const int MaxModelSizePerPage = 8;
    }
}

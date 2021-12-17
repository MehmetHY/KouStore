namespace KouStore.Config
{
    public static class Settings
    {
        public static int MaxImageSizeInMB => 5;
        public static int MaxImageSizeInBytes => MaxImageSizeInMB * 1000000;
        public static string[] AllowedImageExtensions => new string[]{ ".jpg", ".JPG", ".jpeg", ".JPEG" };
    }
}

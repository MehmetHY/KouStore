namespace KouStore.Config
{
    public static class Settings
    {
        public enum Language { English, Turkish }
        public static Language CurrentLanguage { get; set; } = Language.Turkish;
    }
}

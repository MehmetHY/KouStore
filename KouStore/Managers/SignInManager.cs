namespace KouStore.Managers
{
    public static class SignInManager
    {
        public const string ADMIN_ID_KEY = "AdminId";
        public static bool IsAdminSignedIn(ISession session)
        {
            return session.GetString(ADMIN_ID_KEY) != null;
        }
    }
}

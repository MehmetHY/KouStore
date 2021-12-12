using static KouStore.Managers.SessionManager;

namespace KouStore.Managers
{
    public static class AdminLoginChecker
    {
        public static bool IsAuthorized(ISession session, int id)
        {
            if (!IsExist(session, AdminId)) return false;
            if (!CompareValue(session, AdminId, id)) return false;
            return true;
        }
    }
}

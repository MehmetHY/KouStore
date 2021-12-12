using static KouStore.Managers.SessionManager;

namespace KouStore.Managers
{
    public static class AdminLoginManager
    {
        public static bool IsAuthorized(ISession session, int id)
        {
            if (!IsExist(session, AdminId)) return false;
            if (!CompareValue(session, AdminId, id)) return false;
            return true;
        }
        public static void Logout(ISession session)
        {
            SessionManager.RemoveSession(session, AdminId);
        }
        public static void Login(ISession session, int id)
        {
            SessionManager.AddSession(session, AdminId, id.ToString());
        }
    }
}

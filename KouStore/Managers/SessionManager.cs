using KouStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace KouStore.Managers
{
    public static class SessionManager
    {
        public const string AdminId = "adminId";
        public static void AddSession(ISession session, string key, string value)
        {
            session.SetString(key, value);
        }
        public static void RemoveSession(ISession session, string key)
        {
            session.Remove(key);
        }
        public static string? GetSession(ISession session, string key)
        {
            return session.GetString(key);
        }
        public static bool CompareSession(ISession session, string key1, string key2)
        {
            return session.GetString(key1) == session.GetString(key2);
        }
        public static bool CompareValue(ISession session, string key, object obj)
        {
            return session.GetString(key) == obj.ToString();
        }
        public static bool IsExist(ISession session, string key)
        {
            return session.GetString(key) != null;
        }
    }
}

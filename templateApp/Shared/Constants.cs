using System.Collections.Generic;

namespace templateApp.Shared
{
    public enum ErrorCode
    {
        NO_ERROR = 0,
        NO_LOGIN = -1,
        NO_USER = -2,
        NO_MAIL = -3,
        WPNO_EXISTS = -4,
        BAD_PASSCODE = -5,
        INVALID_USER_ID = -6,
    }

    internal class Constants
    {
        // 以下にWebAPIのリンクを記載する
        //public const string API_DOMAIN = "https://localhost:7106";
        public const string API_DOMAIN = "https://localhost:7218";
        public static readonly Dictionary<string, string> API = new Dictionary<string, string>
        {
            { "getAllTManagementItemsSync", API_DOMAIN + "/getAllTManagementItemsSync" },
            { "getAllTManagementItemsAsync", API_DOMAIN + "/getAllTManagementItemsAsync" },
            { "projectData", API_DOMAIN + "/api/project" },
            { "search", API_DOMAIN + "/api/project/search" },
            { "init", API_DOMAIN + "/api/init" },
            { "login", API_DOMAIN + "/api/login" },
        };
    }
}

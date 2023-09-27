using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace templateApp.Shared
{
    public class ClientVersionException : Exception
    {
        public ClientVersionException(String version): base(version) { }
    }
    public class SearchParam
    {
        public String Cond { get; set; } = "";
        public int Limit { get; set; } = 30;
    }
    internal class State
    {

        public static async Task initApp()
        {
            Newtonsoft.Json.Linq.JToken token = await Comm.Get1(Constants.API[key: "init"]);

            /* 初期化時の処理を追記予定
            masters = token.ToObject<Models.Masters>();
            if (AppInited != null)
            {
                AppInited(null, masters);
            }
            */
        }
        
        private static List<Models.ProjectDatum> projectData = null;
        private const string Key = "projectData";
        public static event EventHandler<List<Models.ProjectDatum>> ProjectDataChanged;

        public static async Task readProjectData(SearchParam sp)
        {
            string url = Constants.API["search"];
            Newtonsoft.Json.Linq.JArray list = (Newtonsoft.Json.Linq.JArray)(await Comm.Post(url, sp));

            State.projectData = list.ToObject<List<Models.ProjectDatum>>();
            if (ProjectDataChanged != null)
            {
                ProjectDataChanged(null, State.projectData);
            }
        }
        public static List<Models.ProjectDatum> ProjectData() { return projectData; }


        // 同期型API呼び出し
        public static List<Models.ProjectDatum> GetTManagementItemsDataSync()
        {
            string url = Constants.API["getAllTManagementItemsSync"];
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = response.Content.ReadAsStringAsync().Result;
                    Newtonsoft.Json.Linq.JArray list = Newtonsoft.Json.Linq.JArray.Parse(jsonResponse);
                    return list.ToObject<List<Models.ProjectDatum>>();
                }
                else
                {
                    throw new Exception($"Error {response.StatusCode}: {response.ReasonPhrase}");
                }
            }
        }

        // 非同期型API呼び出し
        public static async Task<List<Models.ProjectDatum>> GetTManagementItemsDataAsync()
        {
            string url = Constants.API["getAllTManagementItemsAsync"];
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    Newtonsoft.Json.Linq.JArray list = Newtonsoft.Json.Linq.JArray.Parse(jsonResponse);
                    return list.ToObject<List<Models.ProjectDatum>>();
                }
                else
                {
                    throw new Exception($"Error {response.StatusCode}: {response.ReasonPhrase}");
                }
            }
        }

        public static void syncData(Models.ProjectDatum datum)
        {
            if (datum != null)
            {
                int idx = projectData.FindIndex(d => d.no == datum.no);
                if (idx != -1)
                {
                    projectData[idx] = datum;
                    if (ProjectDataChanged != null)
                    {
                        ProjectDataChanged(null, State.projectData);
                    }
                }
            }
        }

        public static void clearData()
        {
            State.projectData = new List<Models.ProjectDatum>();
            if (ProjectDataChanged != null)
            {
                ProjectDataChanged(null, State.projectData);
            }
        }

        /// <summary>
        /// LOGIN USER
        /// </summary>
        /* ログイン時の処理を追加予定
        public static Models.MWpTantou LoginUser { get; set; } = null;
        public static event EventHandler<Models.MWpTantou> LoginUserChanged;

        public static void setLoginUser(Models.MWpTantou loginUser)
        {
            LoginUser = loginUser;
            if (LoginUserChanged != null)
            {
                LoginUserChanged(null, loginUser);
            }
        }
        */

            /// <summary>
            /// データ排他処理
            /// </summary>
        public const string OPEN = "open";
        public const string CLOSE = "close";
        public const string UNLOCK = "unlock";
        public const string OVERRIDE = "override";
        public static async Task<Models.ProjectDatum> dataOperation(string cmd, String wpNo)
        {
            string url = String.Format(Constants.API[cmd], wpNo);
            return (await Comm.Get1(url)).ToObject<Models.ProjectDatum>();
        }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication6
{
    public partial class Default3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["code"] != null)
            {
                TokenInfo token = GetTokenInfo(Request["code"]);

                if (token != null)
                {
                    UserInfo userinfo = GetUserInfo(token);
                    //寫入DB 
                }
            }
        }

        public TokenInfo GetTokenInfo(string code)
        {
            string client_id = "619431961751584";
            string redirect_uri = "http://localhost:56506/Default3.aspx";
            string client_secret = "516aa237b4e8484bb0888a6a7e247a65";

            string url = string.Format("https://graph.facebook.com/v3.0/oauth/access_token?client_id={0}&redirect_uri={1}&client_secret={2}&code={3}", client_id, redirect_uri, client_secret, code);
            string result = string.Empty;

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Method = "GET";

            using (var response = request.GetResponse())
            {
                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {
                    result = sr.ReadToEnd();
                }
            }
            TokenInfo tokenInfo = JsonConvert.DeserializeObject<TokenInfo>(result);

            return tokenInfo;
        }

        public UserInfo GetUserInfo(TokenInfo token)
        {
            string url = string.Format("https://graph.facebook.com/v3.0/me?fields=id,name,gender,birthday,email&access_token={0}", token.access_token);
            string result = string.Empty;

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Method = "GET";

            using (var response = request.GetResponse())
            {
                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {
                    result = sr.ReadToEnd();
                }
            }
            UserInfo userInfo = JsonConvert.DeserializeObject<UserInfo>(result);

            return userInfo;
        }

        public class TokenInfo
        {
            public string access_token { get; set; }
            public string token_type { get; set; }
            public string expires_in { get; set; } //expires_in: 為access_token存活的時間。
        }

        public class UserInfo
        {
            public string id { get; set; }
            public string name { get; set; }
            public string gender { get; set; }
            public string birthday { get; set; }
            public string email { get; set; }
        }
    }
}
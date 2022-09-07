using System;
using System.Threading.Tasks;
using System.Net.Http;

namespace androidcontrols
{
    public class NetworkUtils
    {
        internal static string baseUrl = "https://toprate.toprateresources.com/Account/Authenticate/";

        public NetworkUtils()
        {
           
        }


        internal static async Task<string> PostUserData(string actionName, string rawData)
        {
            string result = string.Empty;
            try
            {
               using (var mClient = new HttpClient() {BaseAddress = new Uri("https://api-test.loosechange.app") })
                {
                    mClient.Timeout = TimeSpan.FromMinutes(1);

                    var response = await mClient.PostAsync($"{actionName}/", new StringContent(rawData, System.Text.Encoding.UTF8, "application/json")).ConfigureAwait(false);

                    var reuu = await mClient.GetAsync($"{actionName}/").ConfigureAwait(false);

                    if (reuu.IsSuccessStatusCode) {

                    }


                    if (response.IsSuccessStatusCode)
                    {
                        var mResult = await response.Content.ReadAsStringAsync();
                        return mResult;
                    }else
                    {
                        result = response.ReasonPhrase;
                    }
                }
            }catch(Exception e)
            {
                result = e.Message;
            }
            return result;
        }

        internal static async Task<string> GetUserData(string actionName)
        {
            string result = string.Empty;
            try
            {
                using (var mClient = new HttpClient() { BaseAddress = new Uri(baseUrl) })
                {
                    mClient.Timeout = TimeSpan.FromMinutes(1);

                    var response = await mClient.GetAsync($"{actionName}/").ConfigureAwait(false);
                    if (response.IsSuccessStatusCode)
                    {
                        var mResult = await response.Content.ReadAsStringAsync();
                        return mResult;
                    }
                    else
                    {
                        result = response.ReasonPhrase;
                    }
                }
            }
            catch (Exception e)
            {
                result = e.Message;
            }
            return result;
        }

    }
}

using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        string nearRpcUrl = "https://rpc.testnet.near.org"; // Replace with the desired NEAR RPC URL
        string accountId = "rk37946.testnet"; // Replace with the account ID you want to check

        using (HttpClient client = new HttpClient())
        {
            // Example: Get account balance
            string viewMethodJson = @"
            {
                ""jsonrpc"": ""2.0"",
                ""id"": ""dontcare"",
                ""method"": ""query"",
                ""params"": {
                    ""request_type"": ""view_account"",
                    ""finality"": ""final"",
                    ""account_id"": """ + accountId + @"""
                }
            }";

            StringContent content = new StringContent(viewMethodJson, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync($"{nearRpcUrl}", content);

            if (response.IsSuccessStatusCode)
            {
                string responseJson = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseJson);
            }
        }
    }
}

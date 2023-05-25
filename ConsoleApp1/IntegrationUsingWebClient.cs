// using webclient - deprecated

using System;
using System.Net;

class Program
{
    static void Main(string[] args)
    {
        // NEAR JSON-RPC endpoint
        string rpcEndpoint = "https://rpc.testnet.near.org";

        // NEAR account ID
        string accountId = "rk37946.testnet";

        // Create a new WebClient
        using (WebClient client = new WebClient())
        {
            try
            {
                // Set the JSON-RPC content type
                client.Headers.Add("Content-Type", "application/json");

                // Construct the JSON-RPC request
                string request = $"{{\"jsonrpc\":\"2.0\",\"id\":\"1\",\"method\":\"query\",\"params\":{{\"request_type\":\"view_account\",\"finality\":\"final\",\"account_id\":\"{accountId}\"}}}}";

                // Send the request and get the response
                string response = client.UploadString(rpcEndpoint, request);

                // Print the response
                Console.WriteLine(response);
            }
            catch (WebException ex)
            {
                // Handle any exceptions
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

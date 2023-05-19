using System.Text;
using System.Text.Json;
using System.Security.Cryptography;

namespace IpaymuLibrary
{
    public class HistoryPayment
    {
        public Task Initialize { get; }

        public HistoryPayment()
        {
            Initialize = HistoryPaymentAsync();
        }

        public static Boolean sandbox;

        public static string va;

        public static string apiKey;

        public static string id;

        public static string status;

        public static string date;

        public static string startDate;

        public static string endDate;

        public static string page;

        public static string type;

        public static string orderBy;

        public static string order;

        public static string limit;

        public static string lang;

        public static string bulkId;

        public static string account;

        public static string lockStatus;

        public static string responses;

        static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        static string calcHmac(string data, string apiKey)
        {
            byte[] key = Encoding.ASCII.GetBytes(apiKey);
            HMACSHA256 myhmacsha256 = new HMACSHA256(key);
            byte[] byteArray = Encoding.ASCII.GetBytes(data);
            MemoryStream stream = new MemoryStream(byteArray);
            string result = myhmacsha256.ComputeHash(stream).Aggregate("", (s, e) => s + String.Format("{0:x2}", e), s => s);
            return result;
        }



        public async Task HistoryPaymentAsync()
        {
            try
            {

                string url = "";

                if (sandbox == true)
                {
                    url = "https://sandbox.ipaymu.com/api/v2/payment";
                }
                else
                {
                    url = "https://my.ipaymu.com/api/v2/payment";
                }


                var model = new
                {
                    id = id,
                    status = status,
                    date = date,
                    startDate = startDate,
                    endDate = endDate,
                    page = page,
                    type =type,
                    orderBy = orderBy,
                    order = order,
                    limit = limit,
                    lang = lang,
                    bulkId = bulkId,
                    account = account,
                    lockStatus = lockStatus,
                    
                };
                var json = JsonSerializer.Serialize(model);
                var RequestBody = ComputeSha256Hash(json);
                var stringToSign = "POST:" + va + ":" + RequestBody + ":" + apiKey;

                String signature = calcHmac(stringToSign, apiKey);

                var data = new StringContent(json, Encoding.UTF8, "application/json");
                using var client = new HttpClient();

                client.DefaultRequestHeaders.Add("VA", va);
                client.DefaultRequestHeaders.Add("signature", signature);

                var res = await client.PostAsync(url, data);
                res.EnsureSuccessStatusCode();
                string result = res.Content.ReadAsStringAsync().Result;

                responses = result;

            }
            catch (HttpRequestException e)
            {
                // Console.WriteLine("\nException Caught!");
                // Console.WriteLine("Message :{0} ", e.Message);

                responses = e.Message;
            }



        }

    }
}

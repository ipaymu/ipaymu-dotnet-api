using System.Text;
using System.Text.Json;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace IpaymuLibrary
{
    public class DirectPaymentCod
    {
        public Task Initialize { get; }

        public DirectPaymentCod()
        {
            Initialize = DirectPaymentAsync();
        }

        public static Boolean sandbox;

        public static string va;

        public static string apiKey;

        public static string name;

        public static string phone;

        public static string email;

        public static string amount;

        public static string notifyUrl;

        public static string expired;

        public static string expiredType;

        public static string comment;

        public static string referenceId;

        public static string paymentMethod;

        public static string paymentChannel;

        public static string[] product;

        public static string[] qty;

        public static string[] price;

        public static string[] weight;

        public static string[] width;

        public static string[] height;

        public static string[] length;

        public static string deliveryArea;

        public static string deliveryAddress;

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

        public async Task DirectPaymentAsync()
        {
            try
            {

                string url = "";

                if (sandbox == true)
                {
                    url = "https://sandbox.ipaymu.com/api/v2/payment/direct";
                }
                else
                {
                    url = "https://my.ipaymu.com/api/v2/payment/direct";
                }

                var model = new
                {
                    name = name,
                    phone = phone,
                    email = email,
                    amount = amount,
                    notifyUrl = notifyUrl == "" ? null : notifyUrl,
                    expired = expired,
                    expiredType = expiredType,
                    comment = comment,
                    referenceId = referenceId,
                    paymentMethod = paymentMethod,
                    paymentChannel = paymentChannel,
                    product = product,
                    qty = qty,
                    price = price,
                    weight = weight,
                    width = width,
                    height = height,
                    length = length,
                    deliveryArea = deliveryArea,
                    deliveryAddress = deliveryAddress,
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

namespace IpaymuLibrary
{
    using System.Text;
    using System.Text.Json;
    using System.Security.Cryptography;
    using System.Threading.Tasks;

    public class RedirectPayment
    {

        public Task Initialize { get; }

        public RedirectPayment()
        {
            Initialize = RedirectPaymentAsync();
        }

        public static Boolean sandbox;

        public static string va;

        public static string apiKey;

        public static string[] product;

        public static string[] qty;

        public static string[] price;

        public static string notifyUrl;

        public static string returnUrl;

        public static string cancelUrl;

        public static string referenceId;

        public static string buyerName;

        public static string buyerEmail;

        public static string buyerPhone;

        public static string paymentMethod;

        public static string paymentChannel;

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



        public async Task RedirectPaymentAsync()
        {
            try
            {
               
                string url = ""; 
                                                                   
               if(sandbox == true)
                {
                    url = "https://sandbox.ipaymu.com/api/v2/payment";
                }
                else
                {
                    url = "https://my.ipaymu.com/api/v2/payment";
                }

                string[] productVal = product;
                string[] qtyVal = qty;
                string[] priceVal = price;

                var model = new
                {
                    product = productVal,
                    qty = qtyVal,
                    price = priceVal,
                    notifyUrl = notifyUrl,
                    returnUrl = returnUrl,
                    cancelUrl = cancelUrl,
                    referenceId = referenceId,
                    buyerName = buyerName, //optional
                    buyerEmail = buyerEmail, //optional
                    buyerPhone = buyerPhone, //optional
                    paymentMethod = paymentMethod,
                    paymentChannel = paymentChannel,
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

        public async Task Bayu()
        {
            // Call asynchronous network methods in a try/catch block to handle exceptions.
            try
            {
                HttpClient client = new HttpClient();

                using HttpResponseMessage response = await client.GetAsync("https://dummyjson.com/products/1");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);

                Console.WriteLine(responseBody);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }

    }
}
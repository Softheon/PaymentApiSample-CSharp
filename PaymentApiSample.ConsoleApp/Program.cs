using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace PaymentApiSample.ConsoleApp
{
    class Program
    {
        /// <summary>
        /// The client ID
        /// </summary>
        private static string ClientId = "";

        /// <summary>
        /// The client secret
        /// </summary>
        private static string ClientSecret = "";

        /// <summary>
        /// The scope
        /// </summary>
        private static string Scope = "paymentapi";

        /// <summary>
        /// The token endpoint URI
        /// </summary>
        private static string TokenEndpointUri = "https://hack.softheon.io/api/identity/core/connect/token";

        /// <summary>
        /// The credit card endpoint
        /// </summary>
        private static string CreditCardEndpoint = "https://hack.softheon.io/api/payments/v1/creditcards";

        /// <summary>
        /// The payment endpoint
        /// </summary>
        private static string PaymentEndpoint = "https://hack.softheon.io/api/payments/v1/payments";

        static void Main(string[] args)
        {
            // Create an example address
            Address billingAddress = new Address
            {
                Address1 = "123 Test St",
                City = "Test",
                State = "NY",
                ZipCode = "11111"
            };

            // Create an test credit card
            CreditCard exampleCreditCard = new CreditCard()
            {
                CardNumber = "4134185779995000", // Will always return success
                SecurityCode = "123",
                ExpirationMonth = 3,
                ExpirationYear = 2017,
                CardHolderName = "Test",
                BillingAddress = billingAddress,
                Email = "example@example.com",
            };

            // Request an access token using Softheon's Identity Service
            string tokenResponse = OAuthToken.Get(TokenEndpointUri, ClientId, ClientSecret, Scope);

            // Get the access token returned in the response
            dynamic jsonToken = JsonConvert.DeserializeObject(tokenResponse);
            var accessToken = jsonToken.access_token.Value as string;

            // Use the Payment API to create a credit card token for the example credit card
            string creditCardToken = CreateCreditCardToken(exampleCreditCard, accessToken);

            // Create an example payment that uses the credit card token
            Payment examplePayment = new Payment()
            {
                PaymentAmount = 10.00m,
                Description = "Test payment",
                PaymentMethod = new PaymentMethod() { PaymentToken = creditCardToken, Type = "Credit Card" }
            };

            // Use the Payment API to make a payment
            PaymentResponse paymentResponse = MakePayment(examplePayment, accessToken);

            Console.WriteLine("Access Token: " + accessToken + "\n");
            Console.WriteLine("Credit Card Token: " + creditCardToken + "\n");
            Console.WriteLine("Payment Result Status: " + paymentResponse.Result.Status);
            Console.WriteLine("Payment Result Message: " + paymentResponse.Result.Message);

            Console.Read();
        }

        /// <summary>
        /// Creates the credit card token.
        /// </summary>
        /// <param name="creditCard">The credit card</param>
        /// <param name="accessToken">The access token</param>
        /// <returns></returns>
        /// <exception cref="HttpRequestException">Error when creating credit card token.</exception>
        public static string CreateCreditCardToken(CreditCard creditCard, string accessToken)
        {
            HttpResponseMessage response;

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                response = client.PostAsync
                (
                    CreditCardEndpoint,
                    new StringContent(JsonConvert.SerializeObject(creditCard), Encoding.UTF8, "application/json")
                ).Result;
            }

            string content = response.Content.ReadAsStringAsync().Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException("Error creating credit card token.");
            }

            CreditCardResponse creditCardResponse = JsonConvert.DeserializeObject<CreditCardResponse>(content);

            return creditCardResponse.Token;
        }

        /// <summary>
        /// Makes the payment.
        /// </summary>
        /// <param name="payment">The payment</param>
        /// <param name="accessToken">The access token</param>
        /// <returns></returns>
        /// <exception cref="HttpRequestException">Error when making a payment.</exception>
        public static PaymentResponse MakePayment(Payment payment, string accessToken)
        {
            HttpResponseMessage response;

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                response = client.PostAsync
                (
                    PaymentEndpoint,
                    new StringContent(JsonConvert.SerializeObject(payment), Encoding.UTF8, "application/json")
                ).Result;
            }

            string content = response.Content.ReadAsStringAsync().Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException("Error making a payment.");
            }

            return JsonConvert.DeserializeObject<PaymentResponse>(content);
        }
    }
}

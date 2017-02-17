namespace PaymentApiSample.ConsoleApp
{
    /// <summary>
    /// Credit Card Response class used for deserializing the Payment API's POST /creditcard response into.
    /// </summary>
    public class CreditCardResponse
    {
        /// <summary>
        /// The payment token
        /// </summary>
        public string Token;

        /// <summary>
        /// The card state
        /// </summary>
        public string CardState;

        /// <summary>
        /// The code
        /// </summary>
        public string Code;

        /// <summary>
        /// The message
        /// </summary>
        public string Message;

        /// <summary>
        /// The redirect URL
        /// </summary>
        public string RedirectUrl;
    }
}

namespace demoApi.VModels
{
    public class MomoRespone
    {
        public string partnerCode { get; set; }
        public string requestId { get; set; }
        public string orderId { get; set; } 
        //public string amount { get; set; }
        public string errorCode { get; set; }
        public string message { get; set; }
        public string localMessage { get; set; }
        public string payUrl { get; set; }
        public string signature { get; set; }

        public MomoRespone(string partnerCode, string requestId, string orderId,  string errorCode, string message, string localMessage, string payUrl, string signature)
        {
            this.partnerCode = partnerCode;
            this.requestId = requestId;
            this.orderId = orderId;
            //this.amount = amount;
            this.errorCode = errorCode;
            this.message = message;
            this.localMessage = localMessage;
            this.payUrl = payUrl;
            this.signature = signature;
        }


    }
}

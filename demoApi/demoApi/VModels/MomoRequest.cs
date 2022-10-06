namespace demoApi.VModels
{
    public class MomoRequest
    {
        public string partnerCode { get; set; }
        public string requestId { get; set; }
        public long amount { get; set; }
        public string orderId { get; set; }
        public string orderinfo { get; set; }
        public string redirectUrl { get; set; }
        public string ipnUrl { get; set; }
        public string requestType { get; set; }
        public string extraData { get; set; }
        //public Item iteminfor { get, set,}
        //public User userInfor { get, set,}
        public string signature { get; set; }

        public MomoRequest(string partnerCode, string requestId, long amount, string orderId, string orderinfo, string redirectUrl, string ipnUrl, string requestType, string extraData, string signature)
        {
            this.partnerCode = partnerCode;
            this.requestId = requestId;
            this.amount = amount;
            this.orderId = orderId;
            this.orderinfo = orderinfo;
            this.redirectUrl = redirectUrl;
            this.ipnUrl = ipnUrl;
            this.requestType = requestType;
            this.extraData = extraData;
            this.signature = signature;
        }
    }

}

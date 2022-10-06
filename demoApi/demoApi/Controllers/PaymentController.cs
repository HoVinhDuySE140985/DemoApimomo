using demoApi.Model;
using demoApi.Orther;
using demoApi.VModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Net;

namespace demoApi.Controllers
{
    [ApiController]
    public class PaymentController : ControllerBase
    {
        [HttpPost("/create")]
        public IActionResult Payment()
        {
            string endpoint = "https://test-payment.momo.vn/gw_payment/transactionProcessor";
            string partnerCode = "MOMOOJOI20210710";
            string accessKey = "iPXneGmrJH0G8FOP";
            string serectkey = "sFcbSGRSJjwGxwhhcEktCHWYUuTuPNDB";
            string orderInfo = "test";
            string returnUrl = "https://www.youtube.com/";
            string ipnUrl = "http://52.172.254.105/api/Payment"; //lưu ý: notifyurl không được sử dụng localhost, có thể sử dụng ngrok để public localhost trong quá trình test
            string notifyurl = "https://4c8d-2001-ee0-5045-50-58c1-b2ec-3123-740d.ap.ngrok.io/Home/SavePayment"; //lưu ý: notifyurl không được sử dụng localhost, có thể sử dụng ngrok để public localhost trong quá trình test

            string amount = "1000";
            string orderid = DateTime.Now.Ticks.ToString(); //mã đơn hàng
            string requestId = DateTime.Now.Ticks.ToString();
            string extraData = "";

            string rawHash = "partnerCode=" +
                partnerCode + "&accessKey=" +
                accessKey + "&requestId=" +
                requestId + "&amount=" +
                amount + "&orderId=" +
                orderid + "&orderInfo=" +
                orderInfo + "&returnUrl=" +
                returnUrl + "&ipnUrl" +
                ipnUrl    + "&notifyUrl=" +
                notifyurl + "&extraData=" +
                extraData;

            MoMoSecurity crypto = new MoMoSecurity();
            //sign signature SHA256
            string signature = crypto.signSHA256(rawHash, serectkey);

            //build body json request
            JObject message = new JObject
            {
                { "partnerCode", partnerCode },
                { "accessKey", accessKey },
                { "requestId", requestId },
                { "amount", amount },
                { "orderId", orderid },
                { "orderInfo", orderInfo },
                { "returnUrl", returnUrl },
                { "ipnUrl", ipnUrl },
                { "notifyUrl", notifyurl },
                { "extraData", extraData },
                { "requestType", "captureMoMoWallet" },
                { "signature", signature }
            };
            //MessageRespone jMessage = new MessageRespone(partnerCode, accessKey, requestId, amount, orderid, orderInfo, returnUrl, notifyurl, extraData, "captureMoMoWallet", signature);
            //Object responseFromMomo = PaymentRequest.sendPaymentRequest(endpoint, message.ToString());

            string responseFromMomo = PaymentRequest.sendPaymentRequest(endpoint, message.ToString());
            ////JObject jmess = JObject.Parse(responseFromMomo);
            //string _partnerCode = jmess.GetValue("partnerCode").ToString();
            //string _requestId = jmess.GetValue("requestId").ToString();
            //string errorCode = jmess.GetValue("errorCode").ToString();
            //string orderId = jmess.GetValue("orderId").ToString();
            //string _message = jmess.GetValue("message").ToString();
            //string localMessage = jmess.GetValue("localMessage").ToString();
            //string payUrl = jmess.GetValue("payUrl").ToString();
            //string _signature = jmess.GetValue("signature").ToString();
            //MomoRespone momoRespone = new MomoRespone(_partnerCode,_requestId, errorCode, orderId, _message, localMessage, payUrl, _signature);
            return Ok(responseFromMomo);
        }

        [HttpPost("/callback")]
        public IActionResult InstantPaymentNotification()
        {
            string partnerCode;
            string orderId;
            string requestId;
            long amount;
            string orderInfo;
            string orderType;
            string transId;
            int resultCode;
            string message;
            string payType;
            string extraData;
            string signature;
            return null;
        }
    }
}

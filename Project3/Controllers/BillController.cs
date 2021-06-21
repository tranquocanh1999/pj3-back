using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Project3.Common.Models;
using Project3.Common.Momo;
using Project3.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project3.Api.Controllers
{

    [ApiController]
    public class BillController : BaseController<Bill>
    {
        private IProductService productService ; 
        public BillController(IBillService billService, IProductService _productService) : base(billService)
        {
            productService = _productService;
        }

   
        [HttpPost("pay-momo")]
        public IActionResult PayMoMo(Bill entity)
        {
            string endpoint = "https://test-payment.momo.vn/gw_payment/transactionProcessor";
            string partnerCode = "MOMO5RGX20191128";
            string accessKey = "M8brj9K6E22vXoDB";
            string serectkey = "nqQiVSgDMy809JoPF6OzP5OdBUB550Y4";
            string orderInfo = "Thanh toán hóa đơn";
            string returnUrl = "http://localhost:8080/success";
            string notifyurl = "https://momo.vn/notify";

            string amount = (entity.Amount - entity.Promotion).ToString();
            string requestId = Guid.NewGuid().ToString();
            string extraData = "";


            try
            {
                var res = _baseService.Insert(entity);
                var orderid = res.Data.ToString();

                //Before sign HMAC SHA256 signature
                string rawHash = "partnerCode=" +
                    partnerCode + "&accessKey=" +
                    accessKey + "&requestId=" +
                    requestId + "&amount=" +
                    amount + "&orderId=" +
                    orderid + "&orderInfo=" +
                    orderInfo + "&returnUrl=" +
                    returnUrl + "&notifyUrl=" +
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
                { "notifyUrl", notifyurl },
                { "extraData", extraData },
                { "requestType", "captureMoMoWallet" },
                { "signature", signature }

            };


                string responseFromMomo = PaymentRequest.sendPaymentRequest(endpoint, message.ToString());
                return StatusCode(200, responseFromMomo);

            }
            catch (Exception ex)
            {
                var serviceResult = new ServiceResult();
                var erroMsg = new ErroMsg();
                erroMsg.UserMsg.Add(Project3.Common.Properties.Resource.UserMsg_Exception);
                erroMsg.DevMsg = ex.ToString();
                serviceResult.Data = erroMsg;
                return StatusCode(500, serviceResult.Data);
            }
        }

        [HttpPost("update-quantity")]
        public IActionResult UpdateQuantity(Product[] products)
        {
            try
            {
                var res = productService.UpdateQuantity(products);
                if (res.Success == false)
                    return StatusCode(400, res.Data);

                else return StatusCode(200, res.Data);
            }
            catch (Exception ex)
            {
                var serviceResult = new ServiceResult();
                var erroMsg = new ErroMsg();
                erroMsg.UserMsg.Add(Project3.Common.Properties.Resource.UserMsg_Exception);
                erroMsg.DevMsg = ex.ToString();
                serviceResult.Data = erroMsg;
                return StatusCode(500, serviceResult.Data);
            }
        }
        }
}

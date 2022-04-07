using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArmanBroker.Library;
using Microsoft.AspNetCore.Mvc;

namespace ArmanBroker.Controllers
{
    [ApiController]
    [Route("api2")]
    public class Api2Controller : Controller
    {
        [HttpGet("BrokerList")]
        public async Task<IActionResult> GetBrokerList()
        {
            try
            {
                var result = await new PlusServices().GetBrokerList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(new Result() { StatusCode = 1, Exception = ex.Message, InnerException = ex.InnerException?.Message, StackTrace = ex.StackTrace });
            }
        }

        [HttpGet("BankList")]
        public async Task<IActionResult> GetBankList([FromQuery]string bankName, int pageIndex)
        {
            try
            {
                var result = await new PlusServices().GetBankList(bankName, pageIndex);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(new Result() { StatusCode = 1, Exception = ex.Message, InnerException = ex.InnerException?.Message, StackTrace = ex.StackTrace });
            }
        }

        [HttpGet("Cities")]
        public async Task<IActionResult> GetCities([FromQuery]string cityName, int pageIndex)
        {
            try
            {

                var result = await new PlusServices().GetCities(cityName, pageIndex);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(new Result() { StatusCode = 1, Exception = ex.Message, InnerException = ex.InnerException?.Message, StackTrace = ex.StackTrace });
            }
        }

        [HttpGet("States")]
        public async Task<IActionResult> GetStateList([FromQuery]string stateName, int pageIndex)
        {
            try
            {

                var result = await new PlusServices().GetStateList(stateName, pageIndex);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(new Result() { StatusCode = 1, Exception = ex.Message, InnerException = ex.InnerException?.Message, StackTrace = ex.StackTrace });
            }
        }


        [HttpGet("CustomerDocumentTypes")]
        public async Task<IActionResult> GetCustomerDocumentTypes()
        {
            try
            {
                var result = await new PlusServices().GetCustomerDocumentTypes();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(new Result() { StatusCode = 1, Exception = ex.Message, InnerException = ex.InnerException?.Message, StackTrace = ex.StackTrace });
            }
        }

        [HttpGet("SaveCashFlowRequestReceipt")]
        public async Task<IActionResult> SaveCashFlowRequestReceipt([FromBody]PlusService.CustomerCashFlowRequestReceiptDto receipt)
        {
            try
            {
                await new PlusServices().SaveCashFlowRequestReceipt(receipt);
                return Ok();
            }
            catch (Exception ex)
            {
                return Ok(new Result() { StatusCode = 1, Exception = ex.Message, InnerException = ex.InnerException?.Message, StackTrace = ex.StackTrace });
            }
        }

        [HttpGet("SaveCashFlowRequestPayment")]
        public IActionResult SaveCashFlowRequestPayment([FromBody]PlusService.CustomerCashFlowRequestPaymentDto payment)
        {
            try
            {
                new PlusServices().SaveCashFlowRequestPayment(payment);
                return Ok();
            }
            catch (Exception ex)
            {
                return Ok(new Result() { StatusCode = 1, Exception = ex.Message, InnerException = ex.InnerException?.Message, StackTrace = ex.StackTrace });
            }
        }

        [HttpGet("test")]
        public IActionResult test()
        {
            try
            {
                // await new PlusServices().AddCustomer(customer, customerBanks);
                return Ok(new Result() { StatusCode = 0 });
            }
            catch (Exception ex)
            {
                return Ok(new Result() { StatusCode = 1, Exception = ex.Message, InnerException = ex.InnerException.Message });
            }
        }


        [HttpPost("AddCustomer")]
        public async Task<IActionResult> AddCustomer([FromBody] AddCustomerRequest request)
        {
            try
            {
                //return Ok(request);
                await new PlusServices().AddCustomer(request.customer, request.customerBanks);
                return Ok(new Result() { StatusCode = 0 });
            }
            catch (Exception ex)
            {
                return Ok(new Result() { StatusCode = 1, Exception = ex.Message, InnerException = ex.InnerException?.Message, StackTrace = ex.StackTrace });
            }
        }



        [HttpPost("AddBuyOfflineOrder")]
        public IActionResult AddBuyOfflineOrder([FromBody]PlusService.BuyOfflineOrderDto order)
        {
            try
            {
                var id = new PlusServices().AddBuyOfflineOrder(order);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return Ok();
            }
        }
        [HttpPost("CancelOfflineOrder")]
        public IActionResult CancelOfflineOrder([FromBody]long orderId)
        {
            try
            {
                new PlusServices().CancelOfflineOrder(orderId);
                return Ok();
            }
            catch (Exception ex)
            {
                return Ok();
            }
        }

        [HttpGet("AddPartyDocument")]
        public async Task<IActionResult> AddPartyDocument([FromBody]AddPartyDocumentRequest request)
        {
           
            try
            {
                var documentFile = new PlusService.DocumentFileObject()
                {
                    DocumentTypeId = request.DocumentTypeIdField,
                    FileContent = Convert.FromBase64String(request.FileContentField),
                    FileName = request.FileNameField,
                    TradeCode = request.TradeCodeField
                };

                var result = await new PlusServices().AddPartyDocument(documentFile);
                return Ok(new Result() { StatusCode = 0, InnerResult = result.ToString() });
            }
            catch (Exception ex)
            {
                return Ok(new Result() { StatusCode = 1, Exception = ex.Message, InnerException = ex.InnerException?.Message, StackTrace = ex.StackTrace });
            }
        }


    }
    public class AddCustomerRequest
    {
        public PlusService.CustomerServiceObject customer { get; set; }
        public List<PlusService.CustomerBankAccountServiceObject> customerBanks { get; set; }
    }

    public class AddPartyDocumentRequest
    {
        public int DocumentTypeIdField { get; set; }

        public string FileContentField { get; set; }

        public string FileNameField { get; set; }

        public string TradeCodeField { get; set; }

    }



}
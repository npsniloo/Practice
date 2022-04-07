using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Security;
using System.Threading.Tasks;
using ArmanBroker.Library;
using Microsoft.AspNetCore.Mvc;
using ServiceReference1;

namespace ArmanBroker.Controllers
{
    [ApiController]
    [Route("api")]
    public class ApiController : Controller
    {
        


        [HttpGet("CustomerClub")]
        public async Task<IActionResult> GetCustomerByNationalCode([FromQuery]string nationalCode)


        {
            try
            {

                var result = await new clubservices().GetCustomerByNationalCode(nationalCode);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(new Result() { StatusCode = 1, Exception = ex.Message, InnerException = ex.InnerException?.Message, StackTrace = ex.StackTrace });
            }
        }

        [HttpGet("CustomerPortfolio")]
        public async Task<IActionResult> GetCustomerPortfolio([FromQuery]string nationalCode)
        {
            try
            {

                var result = await new clubservices().GetCustomerPortfolio(nationalCode);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(new Result() { StatusCode = 1, Exception = ex.Message, InnerException = ex.InnerException?.Message, StackTrace = ex.StackTrace });
            }
        }

        [HttpGet("CustomerTradeList")]
        public async Task<IActionResult> GetCustomerTradeList([FromQuery]string nationalCode)
        {
            try
            {

                var result = await new clubservices().GetTradeList(nationalCode);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(new Result() { StatusCode = 1, Exception = ex.Message, InnerException = ex.InnerException?.Message, StackTrace = ex.StackTrace });
            }
        }

        [HttpGet("TradeCodes")]
        public async Task<IActionResult> GetCustomerDailyTradeCodes()
        {
            try
            {
                var result = await new clubservices().GetDailyTradeCodes();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(new Result() { StatusCode = 1, Exception = ex.Message, InnerException = ex.InnerException?.Message, StackTrace = ex.StackTrace });
            }
        }

        [HttpGet("BranchList")]
        public async Task<IActionResult> GetBranchList()
        {
            try
            {
                var result = await new clubservices().GetBranchList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(new Result() { StatusCode = 1, Exception = ex.Message, InnerException = ex.InnerException?.Message, StackTrace = ex.StackTrace });
            }
        }

       

        [HttpGet("CustomerRemain")]
        public async Task<IActionResult> GetCustomerRemain([FromQuery]string nationalCode)
        {
            try
            {
                var result = await new clubservices().GetCustomerRemain(nationalCode);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(new Result() { StatusCode = 1, Exception = ex.Message, InnerException = ex.InnerException?.Message, StackTrace = ex.StackTrace });
            }
        }

        [HttpGet("MarketInstrumentMomentaryPrice")]
        public async Task<IActionResult> GetMarketInstrumentMomentaryPrice()
        {
            try
            {
                var result = await new clubservices().GetMarketInstrumentMomentaryPrice();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(new Result() { StatusCode = 1, Exception = ex.Message, InnerException = ex.InnerException?.Message, StackTrace = ex.StackTrace });
            }
        }

        [HttpGet("TSESymbolList/symbolDateTime/{symbolDateTime:DateTime}")]
        public async Task<IActionResult> GetTSESymbolList(DateTime symbolDateTime)
        {
            try
            {
                var result = await new clubservices().GetTSESymbolList(symbolDateTime);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(new Result() { StatusCode = 1, Exception = ex.Message, InnerException = ex.InnerException?.Message, StackTrace = ex.StackTrace });
            }
        }

        [HttpGet("CustomerList")]
        public async Task<IActionResult> GetCustomerList(DateTime modifiedDateTime, int pageIndex,int pageSize)
        {
            try
            {
                var result = await new clubservices().GetCustomerList(modifiedDateTime, pageIndex,pageSize);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(new Result() { StatusCode = 1, Exception = ex.Message, InnerException = ex.InnerException?.Message, StackTrace = ex.StackTrace });
            }
        }

        [HttpGet("FirmList")]
        public async Task<IActionResult> GetFirmList(DateTime modifiedDateTime, int pageIndex, int pageSize)
        {
            try
            {
                var result = await new clubservices().GetFirmList(modifiedDateTime, pageIndex, pageSize);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(new Result() { StatusCode = 1, Exception = ex.Message, InnerException = ex.InnerException?.Message, StackTrace = ex.StackTrace });
            }
        }

        [HttpGet("TradeTimeTrades")]
        public async Task<IActionResult> GetTradeTimeTrades(DateTime fromDateTime,DateTime toDateTime, int pageIndex)
        {
            try
            {
                var result = await new clubservices().GetTradeTimeTrades(fromDateTime,toDateTime, pageIndex);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(new Result() { StatusCode = 1, Exception = ex.Message, InnerException = ex.InnerException?.Message, StackTrace = ex.StackTrace });
            }
        }

        [HttpGet("DailyTradeList")]
        public async Task<IActionResult> GetDailyTradeList(DateTime tradeDate, int pageIndex, int pageSize)
        {
            try
            {
                var result = await new clubservices().GetDailyTradeList(tradeDate, pageIndex, pageSize);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(new Result() { StatusCode = 1, Exception = ex.Message, InnerException = ex.InnerException?.Message, StackTrace = ex.StackTrace });
            }
        }

        [HttpGet("CustomerMomentaryAssets")]
        public async Task<IActionResult> GetCustomerMomentaryAssets(string tradeCode)
        {
            try
            {
                var result = await new clubservices().GetCustomerMomentaryAssets(tradeCode);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(new Result() { StatusCode = 1, Exception = ex.Message, InnerException = ex.InnerException?.Message, StackTrace = ex.StackTrace });
            }
        }

        [HttpGet("CustomerTotalBrokerCommission")]
        public async Task<IActionResult> GetCustomerTotalBrokerCommission(DateTime fromDate, DateTime toDate, int pageIndex, int pageSize)
        {
            try
            {
                var result = await new clubservices().GetCustomerTotalBrokerCommission(fromDate, toDate, pageIndex, pageSize);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(new Result() { StatusCode = 1, Exception = ex.Message, InnerException = ex.InnerException?.Message, StackTrace = ex.StackTrace });
            }
        }

        [HttpGet("TenEndCustomerTurnover")]
        public async Task<IActionResult> GetTenEndCustomerTurnover(string tradeCode)
        {
            try
            {
                var result = await new clubservices().GetTenEndCustomerTurnover(tradeCode);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(new Result() { StatusCode = 1, Exception = ex.Message, InnerException = ex.InnerException?.Message, StackTrace = ex.StackTrace });
            }
        }

        [HttpGet("OfficeList")]
        public async Task<IActionResult> GetOfficeList()
        {
            try
            {
                var result = await new clubservices().GetOfficeList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(new Result() { StatusCode = 1, Exception = ex.Message, InnerException = ex.InnerException?.Message, StackTrace = ex.StackTrace });
            }
        }

        [HttpGet("CustomerRemainWithTradeCode")]
        public async Task<IActionResult> GetCustomerRemainWithTradeCode(string tradeCode, MarketEnumDto market)
        {
            try
            {
                var result = await new clubservices().GetCustomerRemainWithTradeCode(tradeCode,market);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok();
            }
        }

        [HttpGet("CustomerRemainInDate")]
        public async Task<IActionResult> GetCustomerRemainInDate(string tradeCode, DateTime dateOfRemain, MarketEnumDto market)
        {
            try
            {
                var result = await new clubservices().GetCustomerRemainInDate(tradeCode, dateOfRemain, market);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(new Result() { StatusCode = 1, Exception = ex.Message, InnerException = ex.InnerException?.Message, StackTrace = ex.StackTrace });
            }
        }




    }
}
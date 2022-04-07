using Newtonsoft.Json;
using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ServiceReference1.CustomerClubExternalServiceClient;

namespace ArmanBroker.Library
{
    public class clubservices
    {
        private CustomerClubExternalServiceClient client;
        public clubservices()
        {
            client = new CustomerClubExternalServiceClient(EndpointConfiguration.BasicHttpBinding_ICustomerClubExternalService1);
            client.Endpoint.EndpointBehaviors.Add(new FillHeader());
        }
        public async Task<CustomerClub> GetCustomerByNationalCode(string nationalCode)
        {
            if (!ValidateNationalCode(nationalCode))
            {
                throw new Exception("خطا : کد ملی اشتباه است");
            }
            else
            {
                var customer = await client.GetCustomerByNationalCodeAsync(nationalCode);
                return customer;
            }
        }

        public async Task<PortfolioDto[]> GetCustomerPortfolio(string nationalCode)
        {
            if (!ValidateNationalCode(nationalCode))
            {
                throw new Exception("خطا : کد ملی اشتباه است");
            }
            else
            {
                var portfolio = await client.GetCustomerPortfolioAsync(nationalCode);
                return portfolio;
            }
        }

        public async Task<TradeDto[]> GetTradeList(string nationalCode)
        {
            if (!ValidateNationalCode(nationalCode))
            {
                throw new Exception("خطا : کد ملی اشتباه است");
            }
            else
            {
                var tradeList = await client.GetTradeListAsync(GenerateTradeCode(nationalCode), DateTime.Today.AddDays(-6), DateTime.Today);
                return tradeList;
            }
        }

        public async Task<string[]> GetDailyTradeCodes()
        {

            var tradeCodes = await client.GetDailyTradeCodesAsync(DateTime.Today.AddDays(-1));
            return tradeCodes;

        }

        public async Task<decimal> GetMarketInstrumentMomentaryPrice()
        {

            var price = await client.GetMarketInstrumentMomentaryPriceAsync("IRO1IKCO0001");
            return price;
        }
        
        public async Task<decimal> GetCustomerRemain(string nationalCode)
        {

            if (!ValidateNationalCode(nationalCode)) throw new Exception("خطا : کد ملی اشتباه است");

            var Remain = await client.GetCustomerRemainAsync(nationalCode.Replace("-", "").Trim(), MarketEnumDto.TSE);
            if (Remain != null)
                return (Remain.AdjustedRemain);
            else
                throw new Exception("مانده مورد نظر یافت نشد");

        }

        public async Task<BranchDto[]> GetBranchList()
        {


            var BranchList = await client.GetBranchListAsync();
            if (BranchList != null)
                return (BranchList);
            else
                throw new Exception("شعب مورد نظر یافت نشد");
        }

        public async Task<List<TotalBrokerCommissionDto>> GetCustomerTotalBrokerCommission(int pagesize, int pageNum)
        {


            var CustomerTotalBrokerCommission = await client.GetCustomerTotalBrokerCommissionAsync(new DateTime(2019, 12, 24), new DateTime(2019, 12, 24), pageNum, pagesize);
            var templist =
                CustomerTotalBrokerCommission.Result.Where(q => q.AccountCode == "31212-20024112").ToList();
            if (templist.Count() > 0)
                return (templist);
            else
                throw new Exception(" یافت نشد");


        }

        public async Task<SymbolDto[]> GetTSESymbolList(DateTime symDate)
        {
            var symbolDtos = await client.GetTSESymbolListAsync(symDate);
            if (symbolDtos != null)
                return (symbolDtos);
            else
                throw new Exception("یافت نشد");
        }

        public async Task<PagedCollectionCustomerClub> GetCustomerList(DateTime modifiedDate, int pageIndex,int pageSize)
        {
            var pagedCollectionCustomerClub = await client.GetCustomerListAsync(modifiedDate,pageIndex,pageSize);
            if (pagedCollectionCustomerClub != null)
                return (pagedCollectionCustomerClub);
            else
                throw new Exception("یافت نشد");
        }

        public async Task<PagedCollectionFirmClub> GetFirmList(DateTime modifiedDate, int pageIndex, int pageSize)
        {
            var firmClub = await client.GetFirmListAsync(modifiedDate,pageIndex,pageSize);
            if (firmClub != null)
                return (firmClub);
            else
                throw new Exception("یافت نشد");
        }

        public async Task<PagedCollectionTradeDto> GetTradeTimeTrades(DateTime fromTime, DateTime toTime, int page)
        {
            var pagedCollectionTrade = await client.GetTradeTimeTradesAsync(fromTime,toTime,page);
            if (pagedCollectionTrade != null)
                return (pagedCollectionTrade);
            else
                throw new Exception("یافت نشد");
        }

        public async Task<PagedCollectionTradeDto> GetDailyTradeList(DateTime tradeDate, int page, int pageSize)
        {
            var pagedCollectionTradeDto = await client.GetDailyTradeListAsync(tradeDate,page,pageSize);
            if (pagedCollectionTradeDto != null)
                return (pagedCollectionTradeDto);
            else
                throw new Exception("یافت نشد");
        }

        public async Task<CustomerMomentaryAsset[]> GetCustomerMomentaryAssets(string tradeCode)
        {
            var customerMomentaryAssets = await client.GetCustomerMomentaryAssetsAsync(tradeCode);
            if (customerMomentaryAssets != null)
                return (customerMomentaryAssets);
            else
                throw new Exception("یافت نشد");
        }

        public async Task<PagedCollectionTotalBrokerCommissionDto> GetCustomerTotalBrokerCommission(DateTime fromDate, DateTime toDate, int page, int pageSize)
        {
            var pagedCollectionTotalBrokerCommissionDto = await client.GetCustomerTotalBrokerCommissionAsync(fromDate,toDate,page,pageSize);
            if (pagedCollectionTotalBrokerCommissionDto != null)
                return (pagedCollectionTotalBrokerCommissionDto);
            else
                throw new Exception("یافت نشد");
        }

        public async Task<TradeDto[]> GetTenEndCustomerTurnover(string tradeCode)
        {
            var tradeDtos = await client.GetTenEndCustomerTurnoverAsync(tradeCode);
            if (tradeDtos != null)
                return (tradeDtos);
            else
                throw new Exception("یافت نشد");

        }

        public async Task<Office[]> GetOfficeList()
        {
            var offices = await client.GetOfficeListAsync();
            if (offices != null)
                return (offices);
            else
                throw new Exception("یافت نشد");

        }

        public async Task<RemainDto> GetCustomerRemainWithTradeCode(string tradeCode, MarketEnumDto market)
        {
            var remainDto = await client.GetCustomerRemainWithTradeCodeAsync(tradeCode,market);
            if (remainDto != null)
                return (remainDto);
            else
                throw new Exception("یافت نشد");
        }

        public async Task<RemainDto> GetCustomerRemainInDate(string tradeCode, DateTime dateOfRemain,MarketEnumDto market)
        {
            var remainDto = await client.GetCustomerRemainInDateAsync(tradeCode, dateOfRemain, market);
            if (remainDto != null)
                return (remainDto);
            else
                throw new Exception("یافت نشد");

        }

        private string GenerateTradeCode(string nationalCode)
        {
            return "1299" + nationalCode.Replace("-", "").Trim(); ;
        }
        
        private bool ValidateNationalCode(string nationalCode)
        {
            try
            {
                if (nationalCode.Trim() != string.Empty &&
                    nationalCode.Replace("-", "").Trim().Length == 10)
                {

                    var chArray1 = nationalCode.Replace("-", "").ToCharArray();
                    var numArray1 = new int[chArray1.Length];
                    for (var num1 = 0; num1 < chArray1.Length; num1++)
                    {
                        numArray1[num1] = (int)char.GetNumericValue(chArray1[num1]);
                    }
                    var num2 = numArray1[9];
                    var num3 = ((((((((numArray1[0] * 10) + (numArray1[1] * 9)) + (numArray1[2] * 8)) + (numArray1[3] * 7)) +
                                   (numArray1[4] * 6)) + (numArray1[5] * 5)) + (numArray1[6] * 4)) + (numArray1[7] * 3)) +
                               (numArray1[8] * 2);
                    var num4 = num3 - ((num3 / 11) * 11);
                    if ((((num4 == 0) && (num2 == num4)) || ((num4 == 1) && (num2 == 1))) ||
                        ((num4 > 1) && (num2 == Math.Abs(num4 - 11))))
                        return true;
                    //MessageBox.Show("کد ملی وارد شده صحیح نمی باشد");
                    return false;
                }
                // MessageBox.Show("لطفا کد ملی را به صورت صحیح وارد نمایید");
                // txtEnterNationalCode.Focus();
                //txtEnterNationalCode.SelectAll();
                return false;
            }
            catch (Exception)
            {
                // MessageBox.Show("خطا در فرآیند اعتبار کد ملی");
                return false;
            }
        }
    }
}

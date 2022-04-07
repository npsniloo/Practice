
using ClubService;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ClubService.CustomerClubExternalServiceClient;

namespace ArmanBroker.Library
{
    public class Customer
    {
        private ClubService.CustomerClubExternalServiceClient client;
        public Customer()
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

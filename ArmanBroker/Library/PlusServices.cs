using PlusService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static PlusService.CustomerPlusExternalServiceClient;

namespace ArmanBroker.Library
{
    public class PlusServices
    {
        private CustomerPlusExternalServiceClient client;
        public PlusServices()
        {
            client = new PlusService.CustomerPlusExternalServiceClient(EndpointConfiguration.BasicHttpBinding_ICustomerPlusExternalService1);
            client.Endpoint.EndpointBehaviors.Add(new FillHeader());
        }

        public async Task<BrokerServiceObject[]> GetBrokerList()
        {
            var brokerList = await client.GetBrokerListAsync();
            if (brokerList != null)
                return brokerList;
            else
                throw new Exception("لیست کارگزاریهای مورد نظر یافت نشد");

        }

        public async Task<PagedCollectionCityServiceObject> GetCities(string title, int pageIndex)
        {

            var cityList = await client.GetCitiesAsync(title, pageIndex);
            if (cityList != null)
                return cityList;
            else
                throw new Exception("لیست شهرهای مورد نظر یافت نشد");
        }

        public async Task<PagedCollectionBankServiceObject> GetBankList(string title,int pageIndex)
        {

            var bankList = await client.GetBankListAsync(title, 0);
            if (bankList != null)
                return bankList;
            else
                throw new Exception("لیست بانکهای مورد نظر یافت نشد");
        }

        public async Task<BrokerBankAccountDto[]> GetTSEBrokerBankAccountWithAccount()
        {

            var brokerBankList = await client.GetTSEBrokerBankAccountWithAccountAsync();
            if (brokerBankList != null)
                return brokerBankList;
            else
                throw new Exception("نظر یافت نشد");
        }

        public async Task SaveCashFlowRequestReceipt(CustomerCashFlowRequestReceiptDto receipt)
        {

           
            try
            {
                await client.SaveCashFlowRequestReceiptAsync(receipt);
                // MessageBox.Show("واریز وجه با موفقیت ثبت گردید");
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task AddCustomer(CustomerServiceObject customer, List<CustomerBankAccountServiceObject> customerBanks)
        {
            try
            {
                customer.CustomerBank = customerBanks.ToArray();
                await client.AddCustomerAsync(customer);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void SaveCashFlowRequestPayment(CustomerCashFlowRequestPaymentDto payment)
        {
            try
            {
                client.SaveCashFlowRequestPaymentAsync(payment).GetAwaiter().GetResult();
                //MessageBox.Show("واریز وجه با موفقیت ثبت گردید");
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

       

        public long AddBuyOfflineOrder(BuyOfflineOrderDto order)
        {
            try
            {

                long id = client.AddBuyOfflineOrderAsync(order).GetAwaiter().GetResult();
                return id;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void CancelOfflineOrder(long id)
        {
            try
            {

                client.CancelOfflineOrderAsync(id).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public async Task<bool> AddPartyDocument(DocumentFileObject documentFile)
        {
            try
            {

                return await client.AddPartyDocumentAsync(documentFile);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<PagedCollectionStateServiceObject> GetStateList(string title, int pageIndex)
        {
            var states = await client.GetStateListAsync(title,pageIndex);
            if (states != null)
                return states;
            else
                throw new Exception("یافت نشد");
        }

        public async Task<DocumentTypeDtoWithId[]> GetCustomerDocumentTypes()
        {
            var documentTypeDtoWithIds = await client.GetCustomerDocumentTypesAsync();
            if (documentTypeDtoWithIds != null)
                return documentTypeDtoWithIds;
            else
                throw new Exception("یافت نشد");
        }

        public async Task AddCustomerTest()
        {

            var customer = new CustomerServiceObject
            {
                AverageSallary = 0,
                BirthCertificateCityId = 6,
                BirthCertificateNumber = "2368",
                BirthCertificateSerial = new BirthCertificateSerialServiceObject
                {
                    SerialLetter = "الف",
                    SerialNumber = "22",
                    SerialSeri = "234323"
                },
                BirthCityId = 6,
                BirthDate = new DateTime(1988, 7, 21),
                BourseCodeIsLastLetterSmall = true,
                BrokerBranchId = 42,
                DelegationCode = "",
                EducationField = "",
                EducationLevel = EducationLevelEnum.Bachelor,
                Email = "Test2020@yahoo.com",
                EmploymentDate = null,
                ExchangeKnowledgeType = ExchangeKnowledgeTypeEnum.VeryPoor,
                //ExprienceBrokerCodes = "", باید لیست باشد
                FamiliarityMethodType = FamiliarityMethodTypeEnum.Friends,
                //ExchangeSites = "",??? در سرویس وجود ندارد. این مورد تایپی از نحوه آشنایی می باشد
                FatherName = "تست تدبیر ",
                FirstName = "تست تدبیر ",
                Gender = GenderEnum.Female,
                HasTradeExprience = false,
                HomeAddress = new AddressServiceObject
                {
                    AddressDescription = "تست 2020",
                    AreaFaxNumber = "",
                    AreaTelNumber = "021",
                    CityId = 6,
                    FaxNumber = "",
                    PostalCode = "4444444444",
                    TelNumber = "44444444"
                },
                Id = 0,
                InternetOrderRequest = false,
                Job = new JobServiceObject
                {
                    AddressDescription = "تست 2020",
                    AreaFaxNumber = "",
                    AreaTelNumber = "021",
                    CityId = 6,
                    FaxNumber = "",
                    JobTitle = "مدیر",
                    JobPosition = "مدیر",
                    PostalCode = "",
                    TelNumber = "22222222"
                },
                LastName = "تست تدبیر ",
                //Lawyer = new LawyerServiceObject{}, در صورت وجود وکیل پر شود
                MaritalStatus = MaritalStatusEnum.Married,
                //MarketerId = 0, کد بورسی نیست. بازاریاب است
                BourseCode = "تست99999",
                MobileNumber = "09121234567",
                NationalCode = "0453315046",
                OnlineTradingRequest = false,
                TradeLevelInYear = TradeLevelInYearEnum.Under250,
                TradeValueInIme = null,
                TradeValueInTseAndIfb = null,
                TradeValueOutOfIran = null,
                Wealth = 0,
                WorkCompanyName = "اقتصاد"
            };
            var customerBank = new List<CustomerBankAccountServiceObject>();
            customerBank.Add(new CustomerBankAccountServiceObject
            {
                ShebaCode = "IR870550017380005195270001",
                BankAccountType = BankAccountTypeEnum.ShortTermInvestmentDeposit,
                AccountCode = "173-800-5195270-1",
                BankCityId = 6,
                BranchCode = "173",
                BranchName = "پونک",
                Bank = new BankServiceObject
                {
                    CityId = 6,
                    BankId = 21,
                    Name = "اقتصاد نوین"
                }
            });
            customer.CustomerBank = customerBank.ToArray();
            try
            {
                await client.AddCustomerAsync(customer);
                // MessageBox.Show("مشتری با موفقیت ثبت گردید");
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}

#pragma checksum "E:\Projects\ArmanBroker\ArmanBroker\Views\Default\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4994c0d91c37015ecbb1882e0556bb5da6a5541e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Default_Index), @"mvc.1.0.view", @"/Views/Default/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Default/Index.cshtml", typeof(AspNetCore.Views_Default_Index))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4994c0d91c37015ecbb1882e0556bb5da6a5541e", @"/Views/Default/Index.cshtml")]
    public class Views_Default_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "E:\Projects\ArmanBroker\ArmanBroker\Views\Default\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(43, 4476, true);
            WriteLiteral(@"
<h2>Api List</h2>

<a href=""http://46.209.4.155:99/armanbroker/api/CustomerClub?nationalCode=1292037210"">GetCustomerByNationalCode</a><br />
<a href=""http://46.209.4.155:99/armanbroker/api/CustomerPortfolio?nationalCode=1292037210"">GetCustomerPortfolio</a><br />
<a href=""http://46.209.4.155:99/armanbroker/api/CustomerTradeList?nationalCode=1292037210"">GetCustomerTradeList</a><br />
<a href=""http://46.209.4.155:99/armanbroker/api/TradeCodes"">GetCustomerDailyTradeCodes</a><br />
<a href=""http://46.209.4.155:99/armanbroker/api/BranchList"">GetBranchList</a><br />
<a href=""http://46.209.4.155:99/armanbroker/api/CustomerRemain?nationalCode=1292037210"">GetCustomerRemain</a><br />
<a href=""http://46.209.4.155:99/armanbroker/api/MarketInstrumentMomentaryPrice"">GetMarketInstrumentMomentaryPrice</a><br />
<a href=""http://46.209.4.155:99/armanbroker/api/TSESymbolList/symbolDateTime/2020-01-16T00:00:00"">GetTSESymbolList(input type:DateTime)</a><br />
<a href=""http://46.209.4.155:99/armanbroker/api/TSESymbolLis");
            WriteLiteral(@"t/symbolDateTime/2020-01-16T00:00:00"">GetTSESymbolList(input type:DateTime)</a><br />
<a href=""http://46.209.4.155:99/armanbroker/api/CustomerList?modifiedDateTime=2020-01-16T00:00:00&pageIndex=1&pageSize=10"">GetCustomerList(input :DateTime,int,int)</a><br />
<a href=""http://46.209.4.155:99/armanbroker/api/FirmList?modifiedDateTime=2020-01-16T00:00:00&pageIndex=1&pageSize=10"">GetFirmList(input :DateTime,int,int)</a><br />
<a href=""http://46.209.4.155:99/armanbroker/api/TradeTimeTrades?fromDateTime=2020-01-16T00:00:00&toDateTime=20200215T142354&pageIndex=1"">GetTradeTimeTrades(input :DateTime,DateTime,int)</a><br />
<a href=""http://46.209.4.155:99/armanbroker/api/DailyTradeList?tradeDate=2020-01-16T00:00:00&pageIndex=1&pageSize=10"">GetDailyTradeList(input :DateTime,int,int)</a><br />
<a href=""http://46.209.4.155:99/armanbroker/api/CustomerMomentaryAssets?tradeCode=21234"">GetCustomerMomentaryAssets(input :string)</a><br />
<a href=""http://46.209.4.155:99/armanbroker/api/CustomerTotalBrokerCommission?fromDa");
            WriteLiteral(@"teTime=2020-01-16T00:00:00&toDateTime=2020-02-16T00:00:00&pageIndex=1&pageSize=10"">GetCustomerTotalBrokerCommission(input :DateTime,DateTime,int,int)</a><br />
<a href=""http://46.209.4.155:99/armanbroker/api/TenEndCustomerTurnover?tradeCode=21234"">GetTenEndCustomerTurnover(input :string)</a><br />
<a href=""http://46.209.4.155:99/armanbroker/api/OfficeList"">GetOfficeList</a><br />
<a href=""http://46.209.4.155:99/armanbroker/api/CustomerRemainWithTradeCode?tradeCode=1234&market=1"">
    GetCustomerRemainWithTradeCode(input:string ,int)
    help second input is like this TSE = 1, IME = 2, IEE = 3, EFP = 4
</a><br />
<a href=""http://46.209.4.155:99/armanbroker/api/CustomerRemainInDate?tradeCode=1234&dateOfRemain=2020-01-16T00:00:00&market=1"">
    GetCustomerRemainInDate(input:string ,datetime,int)
    help third input is like this TSE = 1, IME = 2, IEE = 3, EFP = 4
</a><br />

<a href=""http://46.209.4.155:99/armanbroker/api2/AddCustomer"">
    AddCustomer:Post(input(body) :customer,customerbanks)

</");
            WriteLiteral(@"a><br />
<a href=""http://46.209.4.155:99/armanbroker/api2/AddBuyOfflineOrder"">
    AddBuyOfflineOrder:Post(input(body) :order)

</a><br />

    <a href=""http://46.209.4.155:99/armanbroker/api2/SaveCashFlowRequestReceipt"">
        SaveCashFlowRequestReceipt:Post(input(body) :receipt)
    </a>
<br />

<a href=""http://46.209.4.155:99/armanbroker/api2/CancelOfflineOrder"">
    CancelOfflineOrder:Post(input(body) :orderid)
</a>
<br />
<a href=""http://46.209.4.155:99/armanbroker/api2/AddPartyDocument"">
    AddPartyDocument:Post(input(body) :documentFile)
</a><br />
<a href=""http://46.209.4.155:99/armanbroker/api/SaveCashFlowRequestPayment"">
    SaveCashFlowRequestPayment:Post(input(body) :payment)</a>

<br />
<a href=""http://46.209.4.155:99/armanbroker/api2/BrokerList"">GetBrokerList</a><br />
<a href=""http://46.209.4.155:99/armanbroker/api2/States"">GetStateList(input query:stateName,pageIndex)</a><br />
<a href=""http://46.209.4.155:99/armanbroker/api2/BankList"">GetBankList(input query:bankNam");
            WriteLiteral(@"e,pageIndex)</a><br />
<a href=""http://46.209.4.155:99/armanbroker/api2/Cities"">GetCities(input query:cityName,pageIndex)</a><br />
<a href=""http://46.209.4.155:99/armanbroker/api2/TSEBrokerBankAccountWithAccount"">GetTSEBrokerBankAccountWithAccount</a><br />
<a href=""http://46.209.4.155:99/armanbroker/api2/CustomerDocumentTypes"">GetCustomerDocumentTypes</a><br />





");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591

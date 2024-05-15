using System.Configuration;
using System.Data;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using BiddingPlatform.Auction;
using BiddingPlatform.Bid;
using BiddingPlatform.GUI;
using BiddingPlatform.GUI.AdminSide;

namespace BiddingPlatform
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            HttpClient httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:7100")
            };

            string dbConnectionString = "Data Source = RICHARD_LAPTOP; Initial Catalog = BidingSystem; Integrated Security = true;";
            dbConnectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=BidingSystem;Integrated Security=True";

            var auctionRepository = new AuctionRepository(dbConnectionString);
            var auctionService = new AuctionService(auctionRepository);
            var bidRepository = new BidRepository(httpClient);
            var bidService = new BidService(bidRepository);
            Page liveAuctionPage = new LiveAuctionPage(auctionService, bidService);
            Page adminLiveAuctionPage = new AdminLiveAuctionPage(auctionService, bidService);
            Window mainWindow = new MainWindow(liveAuctionPage, adminLiveAuctionPage);
            mainWindow.Show();
        }
    }
}

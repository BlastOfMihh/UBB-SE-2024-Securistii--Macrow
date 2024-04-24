using BiddingPlatform.Auction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitMacrow.AuctionTests
{
    internal class AuctionServiceTest
    {
        private AuctionRepository _auctionRepository;
        [SetUp]
        public void Setup()
        {
            _auctionRepository = new AuctionRepository("Data Source=DESKTOP-LF9HLFA\\SQLEXPRESS;Initial Catalog=TESTINGISSsecuristii;Integrated Security=true");
        }

        [Test]
        public void TestAddAuctionToService()
        {
            AuctionService auctionService = new AuctionService(_auctionRepository);
            auctionService.AddAuction(20, DateTime.Now, "desc", "name", 350);
            Assert.That(_auctionRepository.listOfAuctions.Last().AuctionId, Is.EqualTo(20));
        }

        [Test]
        public void TestRemoveAuctionFromService()
        {
            AuctionService auctionService = new AuctionService(_auctionRepository);
            DateTime now = DateTime.Now;
            int countBefore = _auctionRepository.listOfAuctions.Count;
            auctionService.AddAuction(21, now, "desc", "name", 370);
            Assert.That(_auctionRepository.listOfAuctions.Count, Is.EqualTo(countBefore + 1));
            auctionService.RemoveAuction(21, now, "desc", "name", 370);
            Assert.That(_auctionRepository.listOfAuctions.Count, Is.EqualTo(countBefore));
        }

        [Test]
        public void TestUpdateAuctionInService()
        {
            AuctionService auctionService = new AuctionService(_auctionRepository);
            DateTime now = DateTime.Now;
            auctionService.AddAuction(22, now, "desc", "name", 370);
            auctionService.UpdateAuction(22, now, "desc", "name", 370, now, "new desc", "new name", 400);
            Assert.That(_auctionRepository.listOfAuctions.Last().Description, Is.EqualTo("new desc"));
            Assert.That(_auctionRepository.listOfAuctions.Last().Name, Is.EqualTo("new name"));
            Assert.That(_auctionRepository.listOfAuctions.Last().CurrentMaxSum, Is.EqualTo(400));
        }

        [Test]
        public void TestGetMaxBidSum()
        {
            AuctionService auctionService = new AuctionService(_auctionRepository);
            DateTime now = DateTime.Now;
            auctionService.AddAuction(23, now, "desc", "name", 370);
            auctionService.AddBid("name", "desc", now, 888);
            Assert.That(auctionService.GetMaxBidSum(23), Is.EqualTo(888));
        }
    }
}

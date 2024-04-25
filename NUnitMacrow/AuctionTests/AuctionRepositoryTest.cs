using BiddingPlatform.Auction;
using BiddingPlatform.Bid;
using BiddingPlatform.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitMacrow.AuctionTests
{
    public class MockAuction : IAuctionModel
    {
        public List<IBidModel> ListOfBids { get; set; }

        public int AuctionId { get; set; }
        public DateTime StartingDate { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public List<BasicUser> ListOfUsers { get; set; }
        public float CurrentMaxBid { get; set; }

        /// <inheritdoc/>
        public void AddUserToAuction(BasicUser user)
        {
            throw new NotImplementedException();
        }

        public void AddBidToAuction(IBidModel bid)
        {
            throw new NotImplementedException();
        }


    }
    internal class AuctionRepositoryTest {

        private string connectionString = "Data Source=DESKTOP-LF9HLFA\\SQLEXPRESS;Initial Catalog=TESTINGISSsecuristii;Integrated Security=true;";
        [Test]
        public void TestAddingToRepo_ValidDB_AddedSuccessfully()
        {
            IAuctionRepository auctionRepository = new AuctionRepository(connectionString);

            IAuctionModel auction = new MockAuction();
            auction.AuctionId = 99;
            auction.CurrentMaxBid = 100;
            auction.Description = "Test";
            auction.Name = "Test";
            auction.StartingDate = DateTime.MinValue;
            auctionRepository.AddAuctionToRepo(auction);
            Assert.That(auctionRepository.ListOfAuctions.Last().AuctionId, Is.EqualTo(99));
        }

        [Test]
        public void TestRemovingFromRepo_ValidDBValidAuction_RemovedSuccessfully()
        {
            IAuctionRepository auctionRepository = new AuctionRepository(connectionString);

            IAuctionModel auction = new MockAuction();
            auction.AuctionId = 99;
            auction.CurrentMaxBid= 100;
            auction.Description = "Test";
            auction.Name = "Test";
            auction.StartingDate = DateTime.MinValue;
            auctionRepository.AddAuctionToRepo(auction);
            int beforeRemoval = auctionRepository.ListOfAuctions.Count;
            auctionRepository.RemoveAuctionFromRepo(auction);
            int afterRemoval = auctionRepository.ListOfAuctions.Count;
            Assert.That(beforeRemoval, Is.EqualTo(afterRemoval + 1));
        }

        [Test]
        public void TestUpdatingIntoRepo_ValidDBValidAuctions_UpdatedSuccessfully()
        {
            IAuctionRepository auctionRepository = new AuctionRepository(connectionString);

            IAuctionModel auction = new MockAuction();
            auction.AuctionId = 99;
            auction.CurrentMaxBid = 100;
            auction.Description = "Test";
            auction.Name = "Test";
            auction.StartingDate = DateTime.MinValue;
            auctionRepository.AddAuctionToRepo(auction);

            IAuctionModel newAuction = new MockAuction();
            newAuction.AuctionId = 100;
            newAuction.CurrentMaxBid = 200;
            newAuction.Description = "Test";
            newAuction.Name = "Test";
            newAuction.StartingDate = DateTime.MinValue;

            auctionRepository.UpdateAuctionIntoRepo(auction, newAuction);
            Assert.That(auctionRepository.ListOfAuctions.Contains(auction), Is.False);
            Assert.That(auctionRepository.ListOfAuctions[1].AuctionId, Is.EqualTo(100));
        }

        [Test]
        public void TestRepoConstructor_ValidDBWithExistingRows_InitialisedCorrectly()
        {
            IAuctionRepository auctionRepository = new AuctionRepository(connectionString);
            Assert.That(auctionRepository.ListOfAuctions.Count, Is.EqualTo(6));
        }

        [Test]
        public void TestGetMaxBidSum_ValidDBExistingAuctions_ReturnedValueIsCorrect()
        {
            IAuctionRepository auctionRepository = new AuctionRepository(connectionString);
            Assert.That(auctionRepository.GetBidMaxSum(1), Is.EqualTo(300.3f));
        }

        [Test]
        public void TestAddToDB_ValidDBValidAuction_AddedToDBSuccessfully()
        {
            IAuctionRepository auctionRepository = new AuctionRepository(connectionString);
            auctionRepository.AddToDB("Test", "Test", DateTime.Now, 100);
            IAuctionRepository resultingRepository = new AuctionRepository(connectionString);
            Assert.That(resultingRepository.ListOfAuctions.Count, Is.EqualTo(1));
        }
    }
}

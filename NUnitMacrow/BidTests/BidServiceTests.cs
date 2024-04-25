﻿using BiddingPlatform.Bid;
using BiddingPlatform.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitMacrow.BidTests
{
    class MockBidRepository : IBidRepository
    {
        private List<IBidModel> _bids { get; set; }

        List<IBidModel> IBidRepository.Bids { get { return _bids; }
            set { this._bids = value; } }

        public MockBidRepository()
        {
            this._bids = new List<IBidModel>();
        }

        public void AddBidToRepo(IBidModel bid)
        {
            this._bids.Add(bid);
        }

        public void DeleteBidFromRepo(IBidModel bid)
        {
            this._bids.Remove(bid);
        }

        public List<IBidModel> GetBids()
        {
            return this._bids;
        }

        public void UpdateBidIntoRepo(IBidModel oldbid, IBidModel newbid)
        {
            int index = this._bids.FindIndex(bid => bid.BidId == oldbid.BidId);
            if (index != -1)
            {
                this._bids[index] = newbid;
            }
        }

    }

    internal class BidServiceTests
    {

        [Test]
        public void TestAddingBidSuccessfully() 
        {
            // Arrange
            IBidRepository mockRepository = new MockBidRepository();
            BidService bidService = new BidService(mockRepository);

            int bidId = 1;
            BasicUser user = new BasicUser(1, "UserName", "User");
            float bidSum = 100.0f;
            DateTime bidDate = DateTime.UtcNow;

            // Act
            bidService.AddBid(bidId, user, bidSum, bidDate);

            // Assert
            List<IBidModel> bids = mockRepository.GetBids();
            Assert.That(bids.Count, Is.EqualTo(1));
            Assert.That(bids[0].BidId, Is.EqualTo(bidId));
            Assert.That(bids[0].BasicUser, Is.EqualTo(user));
            Assert.That(bids[0].BidSum, Is.EqualTo(bidSum));
            Assert.That(bids[0].BidDateTime, Is.EqualTo(bidDate));
        }
        
        [Test]
        public void TestRemovingBidSuccessfully()
        {
            // Arrange
            IBidRepository mockRepository = new MockBidRepository();
            BidService bidService = new BidService(mockRepository);

            int bidId = 1;
            BasicUser user = new BasicUser(1, "UserName", "User");
            float bidSum = 100.0f;
            DateTime bidDate = DateTime.UtcNow;
            bidService.AddBid(bidId, user, bidSum, bidDate);

            // Act
            bidService.RemoveBid(bidId, user, bidSum, bidDate);

            // Assert
            List<IBidModel> bids = mockRepository.GetBids();
            Assert.That(bids.Count, Is.EqualTo(0));
        }

        [Test]
        public void TestUpdatingBidSuccessfully()
        {
            // Arrange
            IBidRepository mockRepository = new MockBidRepository();
            BidService bidService = new BidService(mockRepository);

            int bidId = 1;
            BasicUser oldUser = new BasicUser(1, "UserName", "User");
            BasicUser newUser = new BasicUser(2, "NewUserName", "NewUser");
            float oldBidSum = 100.0f;
            float newBidSum = 150.0f;
            DateTime oldBidDate = DateTime.UtcNow;
            DateTime newBidDate = DateTime.UtcNow.AddDays(1);
            bidService.AddBid(bidId, oldUser, oldBidSum, oldBidDate);

            // Act
            bidService.UpdateBid(bidId, oldUser, oldBidSum, oldBidDate, newUser, newBidSum, newBidDate);

            // Assert
            List<IBidModel> bids = mockRepository.GetBids();
            Assert.That(bids.Count, Is.EqualTo(1));
        }

        [Test]
        public void TestGettingAllBids()
        {
            // Arrange
            IBidRepository mockRepository = new MockBidRepository();
            BidService bidService = new BidService(mockRepository);

            int bidId1 = 1;
            BasicUser user1 = new BasicUser(1, "UserName", "User");
            float bidSum1 = 100.0f;
            DateTime bidDate1 = DateTime.UtcNow;

            int bidId2 = 2;
            BasicUser user2 = new BasicUser(2, "SecondUserName", "User2");
            float bidSum2 = 150.0f;
            DateTime bidDate2 = DateTime.UtcNow.AddDays(1);

            bidService.AddBid(bidId1, user1, bidSum1, bidDate1);
            bidService.AddBid(bidId2, user2, bidSum2, bidDate2);

            // Act
            List<IBidModel> bids = bidService.GetBids();

            // Assert
            Assert.That(bids.Count, Is.EqualTo(2));
        }

    }
}
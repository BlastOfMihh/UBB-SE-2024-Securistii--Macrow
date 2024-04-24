﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiddingPlatform;
using BiddingPlatform.Auction;
using BiddingPlatform.Bid;
using BiddingPlatform.User;
using Moq;

namespace NUnitMacrow.AuctionTests
{
    [TestFixture]
    internal class AuctionModelTest
    {
        [Test]
        public void TestAddUserToAuction_UserAddedToList()
        {
            var userMock = new BasicUser(1, "User1", "nickname1");
            var auction = new AuctionModel(1, DateTime.Now, "Test Auction", "Test", 100.0f);

            auction.addUserToAuction(userMock);
            Assert.Contains(userMock, auction.listOfUsers);
        }

        [Test]
        public void TestAddBidToAuction_BidAddedToList()
        {
            var userMock = new BasicUser(1, "User1", "nickname1");
            var bidMock = new BidModel(1, userMock, 50.0f, DateTime.Now);
            var auction = new AuctionModel(1, DateTime.Now, "Test Auction", "Test", 100.0f);

            auction.addBidToAuction(bidMock);
            Assert.Contains(bidMock, auction.ListOfBids);
        }

        [Test]
        public void TestAuctionModelConstructor_WithListOfUsersAndBids_CorrectlyInitialized()
        {
            var userMock1 = new BasicUser(1, "User1", "nickaname1");
            var userMock2 = new BasicUser(2, "User2", "nickaname2");
            var userMock3 = new BasicUser(3, "User3", "nickaname3");
            var userMocks = new List<BasicUser> { userMock1, userMock2 };

            var bidMock = new BidModel(1, userMock1, 50.0f, DateTime.Now);
            var bidMocks = new List<BidModel> {bidMock};

            var auction = new AuctionModel(1, DateTime.Now, "Test Auction", "Test", 100.0f, userMocks, bidMocks);

            CollectionAssert.AreEqual(userMocks, auction.listOfUsers);
            CollectionAssert.AreEqual(bidMocks, auction.ListOfBids);
        }
    }
}
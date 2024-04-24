﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BiddingPlatform.Bid;
using BiddingPlatform.User;

namespace BiddingPlatform.Auction
{
    public class AuctionModel : IAuctionModel
    {
        public int auctionId {  get; set; }
        public DateTime startingDate { get; set; }
        public string description {  get; set; }
        public string name { get; set; }
        public float currentMaxSum { get; set; }
        private List<BasicUser> listOfUsers { get; set; }
        public List<IBidModel> listOfBids { get; set; }

        public AuctionModel(int _id, DateTime startingDate, string description, string name, float currentMaxSum, List<BasicUser> listOfUsers, List<IBidModel> listOfBids)
        {
            this.auctionId = _id;
            this.startingDate = startingDate;
            this.description = description;
            this.name = name;
            this.currentMaxSum = currentMaxSum;
            this.listOfUsers = listOfUsers;
            this.listOfBids = listOfBids;
        }

        public AuctionModel(int _id, DateTime startingDate, string description, string name, float currentMaxSum)
        {
            this.auctionId = _id;
            this.startingDate = startingDate;
            this.description = description;
            this.name = name;
            this.currentMaxSum = currentMaxSum;
            this.listOfUsers = new List<BasicUser>();
            this.listOfBids = new List<IBidModel>();
        }

        public void addUserToAuction(BasicUser user)
        {
            this.listOfUsers.Add(user);
        }

        public void addBidToAuction(IBidModel bid)
        {
            this.listOfBids.Add(bid);
        }
    }
}

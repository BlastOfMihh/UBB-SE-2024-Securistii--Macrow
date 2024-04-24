﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BiddingPlatform.Auction
{
    public class AuctionService : IAuctionService
    {
        private IAuctionRepository AuctionRepository { get; set; }

        public AuctionService(AuctionRepository auctionRepository) 
        {
            this.AuctionRepository = auctionRepository;
        }

        public void addAuction(int id, DateTime startingDate, string description, string name, float currentMaxSum)
        {
            IAuctionModel auction = new AuctionModel(id, startingDate, description, name, currentMaxSum);
            this.AuctionRepository.addAuctionToRepo(auction);
        }

        public void removeAuction(int id, DateTime startingDate, string description, string name, float currentMaxSum)
        {
            IAuctionModel auction = new AuctionModel(id, startingDate, description, name, currentMaxSum);
            this.AuctionRepository.removeAuctionFromRepo(auction);
        }

        public List<IAuctionModel> getAuctions()
        {
            return this.AuctionRepository.listOfAuctions;
        }

        public void updateAuction(int id, DateTime oldstartingDate, string olddescription, string oldname, float oldcurrentMaxSum, DateTime newstartingDate, string newdescription, string newname, float newcurrentMaxSum)
        {
            IAuctionModel oldauction = new AuctionModel(id, oldstartingDate, olddescription, oldname, oldcurrentMaxSum);
            IAuctionModel newauction = new AuctionModel(id, newstartingDate, newdescription, newname, newcurrentMaxSum);
            this.AuctionRepository.updateAuctionIntoRepo(oldauction, newauction);
        }

        public float getMaxBidSum(int index)
        {
            return this.AuctionRepository.getBidMaxSum(index);
        }

        public void addBid(string name, string description, DateTime date, float currentMaxSum)
        {
            this.AuctionRepository.addToDB(name, description, date, currentMaxSum);
        }
    }
}

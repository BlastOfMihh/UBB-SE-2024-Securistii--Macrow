﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingPlatform.Auction
{
    public interface IAuctionService
    {
        void AddAuction(int id, DateTime startingDate, string description, string name, float currentMaxSum);
        void RemoveAuction(int id, DateTime startingDate, string description, string name, float currentMaxSum);
        List<IAuctionModel> GetAuctions();
        void UpdateAuction(int id, DateTime oldstartingDate, string olddescription, string oldname, float oldcurrentMaxSum, DateTime newstartingDate, string newdescription, string newname, float newcurrentMaxSum);
        float GetMaxBidSum(int index);
        void AddBid(string name, string description, DateTime date, float currentMaxSum);
    }
}

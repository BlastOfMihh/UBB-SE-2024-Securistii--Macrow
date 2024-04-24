﻿using BiddingPlatform.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingPlatform.Bid
{
    public class BidModel : IBidModel
    {
        public int BidId { get; set; }
        public BasicUser BasicUser { get; set; }
        public float BidSum { get; set; }
        public DateTime BidDateTime { get; set; }

        public BidModel(int id, BasicUser user, float bidSum, DateTime bidDateTime)
        {
            this.BidId = id;
            this.BasicUser = user;
            this.BidSum = bidSum;
            this.BidDateTime = bidDateTime;
        }
    }
}

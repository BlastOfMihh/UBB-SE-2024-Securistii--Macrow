using BiddingPlatform.User;

namespace BiddingPlatform.Bid
{
    public class BidService : IBidService
    {
        public IBidRepository BidRepository { get; set; }
        public BidService(IBidRepository bidRepository)
        {
            BidRepository = bidRepository;
        }

        public void AddBid(int id, BasicUser user, float bidSum, DateTime biddate)
        {
            IBidModel toAdd = new BidModel(id, user, bidSum, biddate) as IBidModel;

            this.BidRepository.AddBidToRepo(toAdd);
        }

        public void RemoveBid(int id, BasicUser user, float bidSum, DateTime biddate)
        {
            IBidModel toremove = new BidModel(id, user, bidSum, biddate) as IBidModel;
            this.BidRepository.DeleteBidFromRepo(toremove);
        }

        public void UpdateBid(int id, BasicUser olduser, float oldbidSum, DateTime oldbiddate, BasicUser newuser, float newbidSum, DateTime newbiddate)
        {
            IBidModel oldbid = new BidModel(id, olduser, oldbidSum, oldbiddate) as IBidModel;
            IBidModel newbid = new BidModel(id, newuser, newbidSum, newbiddate) as IBidModel;
            this.BidRepository.UpdateBidIntoRepo(oldbid, newbid);
        }

        public List<IBidModel> GetBids()
        {
            return this.BidRepository.GetBids();
        }
    }
}

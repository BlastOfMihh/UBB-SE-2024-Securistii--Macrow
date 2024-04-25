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
            IBidModel toadd = new BidModel(id, user, bidSum, biddate);

            this.BidRepository.AddBidToRepo(toadd);
        }

        public void RemoveBid(int bidID, BasicUser user, float bidSum, DateTime biddate)
        {
            IBidModel toremove = new BidModel(bidID, user, bidSum, biddate);
            this.BidRepository.DeleteBidFromRepo(toremove);
        }

        public void UpdateBid(int bidID, BasicUser userToBeUpdated, float bidSumToBeUpdated, DateTime bidDateToBeUpdated, BasicUser newuser, float newbidSum, DateTime newBidDate)
        {
            IBidModel bidToBeUpdated = new BidModel(bidID, userToBeUpdated, bidSumToBeUpdated, bidDateToBeUpdated);
            IBidModel newBid = new BidModel(bidID, newuser, newbidSum, newBidDate);
            this.BidRepository.UpdateBidIntoRepo(bidToBeUpdated, newBid);
        }

        public List<IBidModel> GetBids()
        {
            return this.BidRepository.GetBids();
        }
    }
}

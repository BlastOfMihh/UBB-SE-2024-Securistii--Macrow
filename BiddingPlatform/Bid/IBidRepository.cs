namespace BiddingPlatform.Bid
{
    public interface IBidRepository
    {
        List<IBidModel> Bids { get; set; }
        Task AddBidToRepo(IBidModel bid);
        Task DeleteBidFromRepo(IBidModel bid);
        List<IBidModel> GetBids();
        Task UpdateBidIntoRepo(IBidModel oldbid, IBidModel newbid);
    }
}
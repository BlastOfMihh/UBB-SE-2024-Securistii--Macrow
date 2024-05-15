using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BiddingPlatform.User;

namespace BiddingPlatform.Bid
{
    public class BidRepository : IBidRepository
    {
        private readonly HttpClient httpClient;
        public List<IBidModel> Bids { get; set; }

        public BidRepository(HttpClient httpClient)
        {
            this.httpClient = httpClient;
            this.Bids = new List<IBidModel>();
            this.LoadBidsFromApi().Wait();
        }

        public BidRepository(List<IBidModel> bids, HttpClient httpClient)
        {
            this.httpClient = httpClient;
            Bids = bids;
        }

        private async Task LoadBidsFromApi()
        {
            var bids = await httpClient.GetFromJsonAsync<List<BidModel>>("http://localhost:7100/api/bids");
            if (bids != null)
            {
                foreach (var bid in bids)
                {
                    Bids.Add(bid);
                }
            }
        }

        public async Task AddBidToRepo(IBidModel bid)
        {
            var response = await httpClient.PostAsJsonAsync("http://localhost:7100/api/bids", bid);
            response.EnsureSuccessStatusCode();
            Bids.Add(bid);
        }

        public List<IBidModel> GetBids()
        {
            return this.Bids;
        }

        public async Task DeleteBidFromRepo(IBidModel bid)
        {
            var response = await httpClient.DeleteAsync($"http://localhost:7100/api/bids/{bid.BidId}");
            response.EnsureSuccessStatusCode();
            Bids.Remove(bid);
        }

        public async Task UpdateBidIntoRepo(IBidModel oldBid, IBidModel newBid)
        {
            var response = await httpClient.PutAsJsonAsync($"http://localhost:7100/api/bids/{oldBid.BidId}", newBid);
            response.EnsureSuccessStatusCode();
            int oldBidIndex = this.Bids.FindIndex(bid => bid == oldBid);
            if (oldBidIndex != -1)
            {
                this.Bids[oldBidIndex] = newBid;
            }
        }
    }
}

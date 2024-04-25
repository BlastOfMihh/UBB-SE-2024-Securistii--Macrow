using BiddingPlatform;
using BiddingPlatform.Bid;
using BiddingPlatform.User;

namespace NUnitMacrow.BidTests
{
    public class BidModelTest
    {
        private BidModel BidModel { get; set; }

        private BasicUser BasicUser { get; set; }

        [SetUp]
        public void Setup()
        {
            this.BasicUser = new BasicUser(1, "basicUserName1", "basicUserNickname1");
            DateTime dateTime = new (2024, 4, 23, 20, 34, 33);  // YYYY/MM/dd HH:mm:ss
            this.BidModel = new BidModel(2, this.BasicUser, 40, dateTime);
        }

        [Test]
        public void GetBidIdEqualTest()
        {
            int bidId = this.BidModel.BidId;

            Assert.AreEqual(2, bidId);
        }

        [Test]
        public void SetBidId_EqualTest()
        {
            this.BidModel.BidId = 4;

            int bidId = this.BidModel.BidId;

            Assert.AreEqual(4, bidId);
        }

        [Test]
        public void GetBasicUserEqualTest()
        {
            BasicUser basicUser = this.BidModel.BasicUser;

            Assert.AreEqual(this.BasicUser, basicUser);
        }

        [Test]
        public void SetBasicUserEqualTest()
        {
            BasicUser newUser = new (11, "basicUserName2", "basicUserNickname2");
            this.BidModel.BasicUser = newUser;

            BasicUser basicUser = this.BidModel.BasicUser;

            Assert.AreEqual(newUser, basicUser);
        }

        [Test]
        public void GetBidSumEqualTest()
        {
            float bidSum = this.BidModel.BidSum;

            Assert.AreEqual(40, bidSum);
        }

        [Test]
        public void SetBidSumEqualTest()
        {
            this.BidModel.BidSum = 666;

            float bidSum = this.BidModel.BidSum;

            Assert.AreEqual(666, bidSum);
        }

        [Test]
        public void GetBidDateEqualTest()
        {
            DateTime dateTime = this.BidModel.BidDateTime;
            DateTime expectedDateTime = new (2024, 4, 23, 20, 34, 33);

            Assert.AreEqual(expectedDateTime, dateTime);
        }

        [Test]
        public void SetBidDateEqualTest()
        {
            DateTime newDateTime = new (2048, 8, 16, 16, 32, 32);
            this.BidModel.BidDateTime = newDateTime;

            DateTime dateTime = this.BidModel.BidDateTime;

            Assert.AreEqual(newDateTime, dateTime);
        }
    }
}

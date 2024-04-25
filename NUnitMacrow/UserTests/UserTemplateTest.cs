using BiddingPlatform;
using BiddingPlatform.User;

namespace NUnitMacrow.UserTests
{
    public class UserTemplateTest
    {
        private UserTemplate UserTemplate { get; set; }

        [SetUp]
        public void Setup()
        {
            this.UserTemplate = new UserTemplate(1, "Username1");
        }

        [Test]
        public void GetIdEqualTest()
        {
            int id = this.UserTemplate.GetId();

            Assert.AreEqual(1, id);
        }

        [Test]
        public void SetIdEqualTest()
        {
            this.UserTemplate.SetId(10);

            int id = this.UserTemplate.GetId();

            Assert.AreEqual(10, id);
        }

        [Test]
        public void GetUsernameEqualTest()
        {
            string username = this.UserTemplate.GetUsername();

            Assert.AreEqual("Username1", username);
        }

        [Test]
        public void SetUsernameEqualTest()
        {
            this.UserTemplate.SetUsername("Username222");

            string username = this.UserTemplate.GetUsername();

            Assert.AreEqual("Username222", username);
        }
    }
}

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
        public void GetId_WithValidUserTemplate_ReturnsIdOf1()
        {
            int id = this.UserTemplate.GetId();

            Assert.AreEqual(1, id);
        }

        [Test]
        public void SetId_WithValidValue_ReturnsSameValue()
        {
            this.UserTemplate.SetId(10);

            int id = this.UserTemplate.GetId();

            Assert.AreEqual(10, id);
        }

        [Test]
        public void GetUsername_WithValidUserTemplate_ReturnsUsername1()
        {
            string username = this.UserTemplate.GetUsername();

            Assert.AreEqual("Username1", username);
        }

        [Test]
        public void SetUsername_WithValidValue_ReturnsUsername222()
        {
            this.UserTemplate.SetUsername("Username222");

            string username = this.UserTemplate.GetUsername();

            Assert.AreEqual("Username222", username);
        }
    }
}

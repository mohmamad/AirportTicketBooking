using Airport.BLL.Handlers;

namespace Airport.BLLTests
{
    [TestClass]
    public class UserHandlerTests
    {
        [TestMethod]
        public void SignupTest()
        {
            //--arrange
           UserHandler user = new UserHandler();
            bool expected = false;
            string expected2 = "Failed to login: Wrong user name or password.";
            //--act
            bool act = user.Signup("mohamad","1234");
            string act2 =  user.Login("mohaqmad","1234");

            //--assert
            Assert.AreEqual(expected, act);
            Assert.AreEqual(expected2, act2);
        }
    }
}

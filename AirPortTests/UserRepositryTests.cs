using Airport.DAL;

namespace AirPortTests
{
    [TestClass]
    public class UserRepositryTests
    {
        [TestMethod]
        public void VerifyemailTest()
        {
            //--arrange
            UserRepository userRepository = new UserRepository();
            userRepository.Signup("mohamad,1234,1");
            
            string expectedName = "mohamad";
            string expectedPass = "1234";
            string expectedLvl = "1";

            //act
            List<UserData> act = userRepository.GetAll();
            //--assert
            foreach(UserData actual in act)
            {
                Assert.AreEqual(actual.UserName, expectedName);
                Assert.AreEqual(actual.UserPassword, expectedPass);
                Assert.AreEqual(actual.UserLevel, expectedLvl);
            }
           

            
            
        }
    }
}
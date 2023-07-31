using Airport.DAL;
using System.Diagnostics;

namespace AirPortTests
{
    [TestClass]
    public class UserRepositryTests
    {
        [TestMethod]
        public void AddNewUserTest()
        {
            //--arrange
            UserRepository userRepository = new UserRepository();
            userRepository.Signup("moha,12345,0");
            
            string expectedName = "moha";
            string expectedPass = "12345";
            string expectedLvl = "0";

            //act
            List<UserData> act = userRepository.GetAllUsers();
            Debug.WriteLine(act.Count);
            //--assert
            foreach (UserData actual in act)
            {
                Debug.WriteLine(actual);
                Assert.AreEqual(actual.UserName, expectedName);
                Assert.AreEqual(actual.UserPassword, expectedPass);
                Assert.AreEqual(actual.UserLevel, expectedLvl);
            }
           

            
            
        }
    }
}
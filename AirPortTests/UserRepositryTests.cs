using Airport.DAL.Repositories;
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
            User user = new User { UserName = "moha", UserPassword = "1234" ,UserLevel = "0" };
            userRepository.Signup(user);
            
            string expectedName = "moha";
            string expectedPass = "1234";
            string expectedLvl = "0";

            //act
            string[] act = userRepository.GetAllUsers();
           // Debug.WriteLine(act.Count);
            //--assert
            foreach (string actual in act)
            {
                Debug.WriteLine(actual);
                Assert.AreEqual(actual.Split(',')[0], expectedName);
                Assert.AreEqual(actual.Split(',')[1], expectedPass);
                Assert.AreEqual(actual.Split(',')[2], expectedLvl);
            }
           

            
            
        }
    }
}
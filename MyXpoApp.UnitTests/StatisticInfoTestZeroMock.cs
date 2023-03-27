//using DevExpress.Data.Linq.Helpers;
//using DevExpress.Xpo;
//using DevExpress.Xpo.DB;
//using ZeroMock;

//namespace MyXpoApp.Tests
//{
//    public class StatisticInfoTestZeroMock
//    {


//        Mock<UnitOfWork> unitOfWorkMock;
//        UnitOfWork session;
//        //[OneTimeSetUp]
//        //public void OneTimeSetUp() { XpoDefault.Session = null; }
//        [SetUp]
//        public void SetUp()
//        {
//            //dataLayerMock = new Mock<IDataLayer>();//new SimpleDataLayer(new InMemoryDataStore(AutoCreateOption.DatabaseAndSchema, false));
//            //dataLayerMock.Setup(d => d.SelectData(Any)It.IsAny<SelectStatement>()).Returns();
//            unitOfWorkMock = new Mock<UnitOfWork>();
//            session = unitOfWorkMock.Object;
//        }

//        [Test]
//        public void CanaryTest()
//        {
//            //string userInput = "new line";
//            //StatisticInfo newInfo = new StatisticInfo(session);
//            //newInfo.Info = userInput;
//            //newInfo.Date = DateTime.Now;
//            //session.CommitChanges();

//            ////THEN
//            //var queryStatisticInfo = session.Query<StatisticInfo>()
//            //    .Select(info => info);
//            //Assert.That(queryStatisticInfo.Count(), Is.EqualTo(1));
//            //Assert.That(userInput, Is.EqualTo(queryStatisticInfo.First().Info));
//            //System.Console.WriteLine("alabala");
//            //Assert.Equals(1, 2);
//            Assert.Fail();
//        }


//        [Test]
//        public void CanaryTest1()
//        {
//            Assert.Pass();
//        }

//        [Test]
//        public void GivenSpecifiTextLine_WhenCommit_ThenGetReturnsTheText1()
//        {
//            //GIVEN
//            //string userInput = "new line";
//            //StatisticInfo newInfo = new StatisticInfo(session);
//            //newInfo.Info = userInput;
//            //newInfo.Date = DateTime.Now;

//            //WHEN
//            //session.CommitChanges();

//            //THEN
//            //var queryStatisticInfo = session.Query<StatisticInfo>()
//            //    .Select(info => info);
//            //Assert.That(queryStatisticInfo.Count(), Is.EqualTo(1));
//            //Assert.That(userInput, Is.EqualTo(queryStatisticInfo.First().Info));
//            Assert.Pass();

//        }

//        //[Test]
//        //public void GivenDifferentTextLine_WhenCommit_ThenGetReturnsTheText()
//        //{
//        //    //GIVEN
//        //    const string userInput1 = "stat info 1";
//        //    StatisticInfo newInfo1 = new StatisticInfo(session);
//        //    newInfo1.Info = userInput1;
//        //    newInfo1.Date = DateTime.Now;
//        //    const string userInput2 = "stat info 2";
//        //    StatisticInfo newInfo2 = new StatisticInfo(session);
//        //    newInfo2.Info = userInput2;
//        //    newInfo2.Date = DateTime.Now;

//        //    //WHEN
//        //    session.CommitChanges();

//        //    //THEN
//        //    var queryStatisticInfo = session.Query<StatisticInfo>()
//        //        .Select(info => info);
//        //    Assert.That(queryStatisticInfo.Count(), Is.EqualTo(2));
//        //    List<StatisticInfo> statisicInfoInDB = queryStatisticInfo.ToList();
//        //    statisicInfoInDB.Contains(newInfo1);
//        //    Assert.True(statisicInfoInDB.Contains(newInfo1));
//        //    Assert.True(statisicInfoInDB.Contains(newInfo2));
//        //    //Assert.That(userInput1, Is.EqualTo(queryStatisticInfo.Last().Info));

//        //}

//        //[TearDown]
//        //public void TearDown()
//        //{
//        //    session.Dispose();
//        //    //dataLayer.Dispose();
//        //}
//    }
//}

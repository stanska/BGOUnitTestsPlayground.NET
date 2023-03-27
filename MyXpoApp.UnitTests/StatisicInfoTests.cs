using DevExpress.Data.Linq.Helpers;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using System.Linq;

namespace MyXpoApp.Tests
{
    public class StatisticInfoTests
    {

        IDataLayer dataLayer;
        UnitOfWork session;
        [OneTimeSetUp]
        public void OneTimeSetUp() { XpoDefault.Session = null; }
        [SetUp]
        public void SetUp()
        {
            dataLayer = new SimpleDataLayer(new InMemoryDataStore(AutoCreateOption.DatabaseAndSchema, false));
            session = new UnitOfWork(dataLayer);
        }


        [Test]
        public void CanaryTest()
        {
            Assert.Pass();
        }
        [Test]
        public void CommitChanges_Save1StatisticInfoInEmptyDB_QueryReturns1RecordWithCorrectInfo()
        {
            //Arrange
            const string userInput = "new line";
            StatisticInfo newInfo = new StatisticInfo(session);
            newInfo.Info = userInput;
            newInfo.Date = DateTime.Now;

            //Act
            session.CommitChanges();

            //Assert
            var queryStatisticInfo = session.Query<StatisticInfo>()
                .Select(info => info);
            Assert.That(queryStatisticInfo.Count(), Is.EqualTo(1));
            Assert.That(queryStatisticInfo.First().Info, Is.EqualTo(userInput));

        }

        [Test]
        public void CommitChanges_Save2StatisticInfoInEmptyDB_QueryReturns1RecordWithCorrectInfo()
        {
            //Arrange
            const string userInput1 = "stat info 1";
            StatisticInfo newInfo1 = new StatisticInfo(session);
            newInfo1.Info = userInput1;
            newInfo1.Date = DateTime.Now;
            const string userInput2 = "stat info 2";
            StatisticInfo newInfo2 = new StatisticInfo(session);
            newInfo2.Info = userInput2;
            newInfo2.Date = DateTime.Now;

            //Act
            session.CommitChanges();

            //Assert
            var queryStatisticInfo = session.Query<StatisticInfo>()
                .Select(info => info);
            Assert.That(queryStatisticInfo.Count(), Is.EqualTo(2));
            List<StatisticInfo> statisicInfoInDB = queryStatisticInfo.ToList();
            statisicInfoInDB.Contains(newInfo1);
            Assert.True(statisicInfoInDB.Contains(newInfo1));
            Assert.True(statisicInfoInDB.Contains(newInfo2));
        }

        [TearDown]
        public void TearDown()
        {
            session.Dispose();
            dataLayer.Dispose();
        }
    }
}

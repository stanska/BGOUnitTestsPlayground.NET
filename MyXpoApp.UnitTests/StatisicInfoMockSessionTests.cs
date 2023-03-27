using DevExpress.Xpo;
using Moq;
using DevExpress.Xpo.DB;

namespace MyXpoApp.Tests
{
    public class StatisicTestMockSessionTests
    {

        Mock<ISessionWrapper> SessionWrapperMock;
        UnitOfWork Session;
        SimpleDataLayer DataLayer;
        [SetUp]
        public void SetUp()
        {
            SessionWrapperMock = new Mock<ISessionWrapper>();
            DataLayer = new SimpleDataLayer(new InMemoryDataStore(AutoCreateOption.DatabaseAndSchema, false));
            Session = new UnitOfWork(DataLayer);
            SessionWrapperMock.Setup(s => s.Session).Returns(Session);
        }

        [Test]
        public void MethodToTest_2StasticInfoInDB_Return2()
        {
            //Arrange
            SessionWrapperMock.Setup(wrraper => wrraper.Count()).Returns(2);

            StatisticInfoMockSession newInfo = new StatisticInfoMockSession(SessionWrapperMock.Object);

            //Act
            var rowCount = newInfo.MethodToTest();

            //Assert
            Assert.That(rowCount, Is.EqualTo(2));

        }

        [Test]
        public void GetLastStatisticInfo_StatisticInfoInDB_ReturnLastAdded()
        {
            //Arrange
            Mock<IDataStore> dsMock = new Mock<IDataStore>();
            DataLayer = new SimpleDataLayer(dsMock.Object);
            Session = new UnitOfWork(DataLayer);
            SessionWrapperMock = new Mock<ISessionWrapper>();
            SessionWrapperMock.Setup(wrraper => wrraper.Session).Returns(Session);

            const String userInput = "324";
            StatisticInfoMockSession newInfo = new StatisticInfoMockSession(SessionWrapperMock.Object);
            newInfo.Info = userInput;
            SessionWrapperMock.Setup(wrraper => wrraper.GetLastStisticalInfo()).Returns(newInfo);

            //Act
            var statisticInfo = newInfo.GetLastStatisticInfo();

            //Assert
            Assert.That(statisticInfo.Info, Is.EqualTo(userInput));
        }


        [TearDown]
        public void TearDown()
        {
            Session.Dispose();
            DataLayer.Dispose();
        }
    }
}

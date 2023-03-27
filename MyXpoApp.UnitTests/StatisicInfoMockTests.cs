//using DevExpress.Xpo;
//using Moq;
//using DevExpress.Xpo.DB;
//using DevExpress.Xpo.Helpers;
//using DevExpress.Data.Linq.Helpers;
//using Castle.Components.DictionaryAdapter.Xml;
//using System.Linq;
//using DevExpress.Xpo.Metadata;

//namespace MyXpoApp.Tests
//{
//    public class StatisicTestMock
//    {

//        Mock<IDataStore> mock;
//        IDataLayer dataLayer;
//        SelectedData selectedDataMock;
//        UnitOfWork session;
//        //[OneTimeSetUp]
//        //public void OneTimeSetUp() { XpoDefault.Session = null; }
//        [SetUp]
//        public void SetUp()
//        {
//            //new SimpleObjectLayer().LoadObjects
//            //ObjectCollectionLoader.LoadObjects
//            mock = new Mock<IDataStore>();
//            //"alabala] new line"
//            //Object[] resultset = { { "key" : 1}, {info : "2"} , {date => "3"} };
//            var dict = new XPDictionaryStub();
//            //how to construct XPDictionary with the correct class information

//            dataLayer = new SimpleDataLayer( mock.Object);
//            session = new UnitOfWork(dataLayer);
//            Int32 key = 1;
       
//            StatisticInfoMock statisticInfoMock = new StatisticInfoMock(session);
//            statisticInfoMock.Info = 1;
//            statisticInfoMock.Key = 3;
//            Object[] resultset1 = { 1, "2", "3", "4", 1, "2", "3", "4" };
//            //Object[] resultset2 = { 1, "2", "3", "4", 1, "2", "3", "4" };
//            //session.Dictionary.AddClassInfo(statisticInfoMock.ClassInfo);
//            System.Console.WriteLine(session.Dictionary.Classes.Count);

//            var result = new SelectStatementResultRow[1] { 
//                            new SelectStatementResultRow(resultset1)
//                        };

//            //var result2 = new SelectStatementResultRow[1] {
//            //                new SelectStatementResultRow(resultset2)
//            //            };
//            //TODO: pass metadata dictionary to SimpleDataLayer, check in the inmemory
//            //how to instatiate IXPDictionaryProvider


//            //result[0] = "1";
//            System.Console.WriteLine("REsult" + result);
//            //SelectStatementResult[] rows = { new SelectStatementResult(result)};
//            selectedDataMock = new SelectedData(new SelectStatementResult(result));
//            //selectedDataMock = new SelectedData(rows.AsEnumerable);
            
//            mock.Setup(d => d.SelectData(It.IsAny<SelectStatement>())).Returns(selectedDataMock);
//            System.Console.WriteLine("First" + selectedDataMock.ResultSet.First().Rows);
//            System.Console.WriteLine("result set count" + selectedDataMock.ResultSet.Count().ToString());
//            System.Console.WriteLine("Output shown");
//            //selectedDataMock.Setup(d => d.ResultSet(It.IsAny<SelectStatement>())).Returns(selectedDataMock);
//            //mock.Setup(d => d.GetComponentType()).Returns(typeof(StatisticInfoMock));
//            //mock.Setup(d => d.SelectData(It.IsAny<SelectStatement>())).Returns(selectedDataMock);
//            //mock.Setup(d => d.GetType()).Returns(typeof(StatisticInfoMock));
//            //mock.Setup(d => d.GetComponentType()).Returns(typeof(StatisticInfoMock));
//            //mock.Setup(d => d.Equals(It.IsAny<SelectStatement>())).Returns(true);
//            //mock.Setup(d => d.Equals(It.IsAny<SelectStatement>())).Returns(true);
//            //mock.Setup(d => d.(It.IsAny<SelectStatement>())).Returns(selectedDataMock.Object);
//            //mock.Setup(p=>p.LoadObjects())

//            //mock.Setups(ds => ds.)
//            //dataStoreMock.Setup(p => { p})
//            //dataLayer = new SimpleDataLayer(mock.Object);

//            //session = new UnitOfWork(mock.Object);

//            //Mock<UnitOfWork> sessionMock = new Mock<UnitOfWork>();
//            //sessionMock.Setup(s => s.CommitChanges());

//            //session = sessionMock.Object;

//            //session = Mocknew UnitOfWork(dataLayer);
//            //dataLayerMock.Setup(d/ => d.)
//            //session = new UnitOfWork(dataLayer);
//        }

//        [Test]
//        public void CanaryTest()
//        {
//            Assert.Pass();
//        }

//        [Test]
//        public void GivenSpecifiTextLine_WhenCommit_ThenGetReturnsTheText()
//        {
//            //Arrange
//            String userInput = "324";
//            StatisticInfoMock newInfo = new StatisticInfoMock(session);
//            newInfo.Info = 1;
//            newInfo.Key = 32;

//            //newInfo.Date = DateTime.Now;

//            //Act
//            session.CommitChanges();

//            ////Assert
//            var queryStatisticInfo = session.Query<StatisticInfoMock>()
//                .Select(info => info.Info);
//            //queryStatisticInfo.Count
//            //var mockQuery = new Mock<Queryable>();
//            //mockQuery.Setup(q=>q.Count()).Returns(1);
//            Assert.That(queryStatisticInfo.Count(), Is.EqualTo(2));

//            //System.Console.WriteLine(queryStatisticInfo.First().Info);
//            //session.Dictionary.GetDataStoreSchema(new StatisticInfoMock(session).ClassInfo)[0].Columns
//            System.Console.WriteLine(queryStatisticInfo);
//            Assert.AreEqual(queryStatisticInfo.First(), 2);

//        }


//        [TearDown]
//        public void TearDown()
//        {
//            session.Dispose();
//            dataLayer.Dispose();
//        }
//    }
//}

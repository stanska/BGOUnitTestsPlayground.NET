//using DevExpress.Xpo;
//using DevExpress.Xpo.Helpers;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
////using ZeroMock;
//using Moq;

//namespace MyXpoApp.Tests
//{
//    internal class ZeroMock
//    {
//        Mock<ISessionProvider> unitOfWorkMock;
//        Session session;

//        [Test]
//        public void Test1() {
//            unitOfWorkMock = new Mock<ISessionProvider>();
//            session = unitOfWorkMock.Object;
//            string userInput = "new line";
//            StatisticInfo newInfo = new StatisticInfo(session);
//            //newInfo.Info = userInput;
//            //newInfo.Date = DateTime.Now;
//            //session.CommitChanges();
//            //System.Console.WriteLine("1");


//            //mock.Setup(e => e.Example(It.Is<string>(e => e.Contains("Hello"))))
//            //    .Returns("World")
//            //    .CallBack(() => Console.WriteLine("Callback!"));

//            //var obj = mock.Object;
//            //var result = obj.Example("Helloooo");

//            //mock.Verify(e => e.Example("Hello"), Times.Once());
//            Assert.True(false);
//        }
//    }
//}

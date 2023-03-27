# BGOUnitTestsPlayground.NET
The repo contains sample tests using [Moq](https://github.com/moq/moq) and [nUnit](https://nunit.org/) for testing the [devexpress](https://www.devexpress.com) ORM named [XPO](https://www.devexpress.com/products/net/orm/).
The same approach can be reused in all types of unit tests.

TODO: Add samples for [xUnit](https://xunit.net/)
TODO: Add sample not dependant on DevExpress


### Quick start

```PowerShell
cd MyXpoApp.UnitTests
dotnet test .\MyXpoApp.UnitTests.csproj
```

You can also execute unit tests in Visual Studio bt right-click on the [Test] attribute of the test and use “Run Test(s)”. Visual Studio will compile your solution and run the test you clicked on. You can also select multiple test classes and run tests for them all.

### Why we need tests?

The main reason to write unit tests is to gain confidence. Unit tests allow us to make changes, with confidence that they will work.

**✔️Unit tests allow change.✔️**

### What makes a good unit test?

#### Our tests should run quickly
#### Our tests should run in any order
#### Our tests should be deterministic

### Mocking
Mocking is a **process used in unit testing when the unit being tested has external dependencies.** The purpose of mocking is to isolate and focus on the code being tested and not on the behavior or state of external dependencies.

#### What is Mocking?

Mocking is a process used in unit testing when the unit being tested has external dependencies. The purpose of mocking is to isolate and focus on the code being tested and not on the behavior or state of external dependencies. In mocking, the dependencies are replaced by closely controlled replacements objects that simulate the behavior of the real ones. There are three main possible types of replacement objects - fakes, stubs and mocks.

+ Fakes: A Fake is an object that will replace the actual code by implementing the same interface but without interacting with other objects. Usually the Fake is hard-coded to return fixed results. To test for different use cases, a lot of Fakes must be introduced. The problem introduced by using Fakes is that when an interface has been modified, all fakes implementing this interface should be modified as well.

+ Stubs: A Stub is an object that will return a specific result based on a specific set of inputs and usually won’t respond to anything outside of what is programed for the test. 

+ Mocks: A Mock is a much more sophisticated version of a Stub. It will still return values like a Stub, but it can also be programmed with expectations in terms of how many times each method should be called, in which order and with what data.

#### Example
XPO entites, inherit [XPLiteObject](https://docs.devexpress.com/XPO/DevExpress.Xpo.XPLiteObject) as the example [here](./MyXpoApp.UnitTests/StatisicInfoMockSessionTests.cs).

If we want to test [StatisticInfoMockSession](./MyXpoApp/StatisticInfoMockSession.cs) we can either use [in-memory DB](./MyXpoApp.UnitTests/StatisicInfoTests.cs) or create a mock and set it up, to behave in a [desired way](./MyXpoApp/StatisticInfoMockSession.cs).

```csharp
Mock<ISessionWrapper> sessionWrapperMock = new Mock<ISessionWrapper>();
SessionWrapperMock.Setup(wrraper => wrraper.Count()).Returns(2);
```

In the apper scenraio, [XPLiteObject](https://docs.devexpress.com/XPO/DevExpress.Xpo.XPLiteObject) is constructed with [Session](https://docs.devexpress.com/XPO/DevExpress.Xpo.Session) which is a concrete class. Since we can mock, with [Moq](https://github.com/Moq/moq4/wiki/Quickstart) framework, ONLY interfaces and virtual methods and we cannot change [XPLiteObject](https://docs.devexpress.com/XPO/DevExpress.Xpo.XPLiteObject), we can make a [wrapper interface of the Session](./MyXpoApp/ISessionWrapper.cs) and mock it.

```csharp
    public interface ISessionWrapper
    {
        Session Session { get; }

        int Count();

        StatisticInfoMockSession GetLastStisticalInfo();
    }

    
    public class SessionWrapper : ISessionWrapper
    {

        public Session Session { get; }


        public SessionWrapper(Session session)
        {
            Session = session;
        }

        public int Count()
        {
            return Session.Query<StatisticInfoMock>()
                        .Select(info => info).Count();
        }

        public StatisticInfoMockSession GetLastStisticalInfo()
        {
            return Session.Query<StatisticInfoMockSession>()
                    .Select(info => info)
                    .Last();
        }
    }
    
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
```

#### Frameworks
[Moq](https://github.com/Moq/moq4/wiki/Quickstart) is mocking framework used to generated replacement objects. It can help us mock interface or virtual methods. 

I have tried mocking a concrete class with [ZeroMock](https://zeromock.com/), but using ZeroMocks throws error:( There are commercial library letting you do this

### Comparison against other mock frameworks:

| Name                                                        | Open Source | Interfaces | Concrete Types | Static |
| ----------------------------------------------------------- | :---------: | :--------: | :------------: | :----: |
| [Moq](https://github.com/moq/moq4)                          |      ✔️      |     ✔️      |       ❌        |   ❌    |
| [TypeMock](https://www.typemock.com/isolator-product-page/) |      ❌      |     ✔️      |       ✔️        |   ✔️    |
| [JustMock](https://www.telerik.com/products/mocking.aspx)   |      ❌      |     ✔️      |       ✔️        |   ✔️    |
| [ZeroMock](https://github.com/CoenraadS/ZeroMock)           |      ✔️      |     ❌      |       ✔️        |   ❌    |

### Conventions
By convention, UnitTest are playced in a separate project. The test projects has reference to the main prokect(project under test) in order to have access to the code to be tested.

#### Test Project Name
The project usually is named [Project UnderTests].UnitTests.

#### Test Class Name
Usually, there is one test class per class to test. 

#### Test Method Name
There are several method name conventions, maybe the most famous one is 

+ UnitOfWork_Scenario_ExpectedResult

It uses  underscores to separate the unit of work, the test scenario, and the expected behavior in our test names. If we follow this convention for our example tests, we name our tests:

Remove_ASubstring_RemovesThatSubstring
Remove_NoParameters_ReturnsEmpty
With this convention, we can read our test names out loud like this: “When calling Remove with a substring, then it removes that substring.”

Following the second naming convention, our tests look like this:

```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Stringie.UnitTests
{
    [TestClass]
    public class RemoveTests
    {
        [TestMethod]
        public void Remove_ASubstring_RemovesThatSubstring()
        {
        }

        [TestMethod]
        public void Remove_NoParameters_ReturnsEmpty()
        {
        }
    }
}
```

These names could look funny at first glance. We should use compact names in our code. However, when writing unit tests, readability is important. Every test should state the scenario under test and the expected result. We shouldn’t worry about long test names.

#### How should we write our tests? THE AAA Principle

Now, let’s write the body of our tests.

To write our tests, let’s follow the **Arrange/Act/Assert (AAA) principle**. Each test should contain these three parts.

In the Arrange part, we create input values to call the entry point of the code under test.

In the Act part, we call the entry point to trigger the logic being tested.

In the Assert part, we verify the expected behavior of the code under test.

Let’s use the AAA principle to replace one of our examples with a real test. Also, let’s use line breaks to visually separate the AAA parts.

```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Stringie.UnitTests
{
    [TestClass]
    public class RemoveTests
    {
        [TestMethod]
        public void Remove_NoParameters_ReturnsEmpty()
        {
            //Arrange
            string str = "Hello, world!";

            //Act
            string transformed = str.Remove();

            //Assert
            Assert.AreEqual(0, transformed.Length);
        }
    }
}
```

### Additional Info

[Parameterized unit tests in C# — Run the same test with various inputs](https://mcaden.medium.com/writing-parameterized-unit-tests-in-c-run-the-same-test-with-various-inputs-acb6c6e12175)

https://docs.nunit.org/articles/nunit/technical-notes/usage/Parameterized-Tests.html

[How to mock or stub a class without an interface](https://peterdaugaardrasmussen.com/2022/05/15/csharp-how-to-mock-or-stub-a-class-without-an-interface/)

4 common [mistakes](https://canro91.github.io/2021/03/29/UnitTestingCommonMistakes/) when writing unit tests
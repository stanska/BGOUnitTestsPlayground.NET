

using DevExpress.Xpo;

namespace MyXpoApp
{
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
}

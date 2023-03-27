using DevExpress.Xpo;

namespace MyXpoApp
{
    // ...
    public class StatisticInfoMockSession : XPLiteObject
    {

        ISessionWrapper SessionWrapper { get; set; }
        
        public StatisticInfoMockSession(ISessionWrapper sessionWrapper)
            : base(sessionWrapper.Session)
        {
            this.SessionWrapper = sessionWrapper;
        }
        Guid key;
        [Key(true)]
        public Guid Key
        {
            get { return key; }
            set { SetPropertyValue(nameof(Key), ref key, value); }
        }
        string info;
        [Size(255)]
        public string Info
        {
            get { return info; }
            set { SetPropertyValue(nameof(Info), ref info, value); }
        }
        DateTime date;
        public DateTime Date
        {
            get { return date; }
            set { SetPropertyValue(nameof(Date), ref date, value); }
        }

        public int MethodToTest() {
            return SessionWrapper.Count();
        }

        public StatisticInfoMockSession GetLastStatisticInfo()
        {
            return SessionWrapper.GetLastStisticalInfo();
        }
    }
}

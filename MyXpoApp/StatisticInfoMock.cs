using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Xpo;

namespace MyXpoApp
{
    // ...
    public class StatisticInfoMock : XPLiteObject
    {
        public StatisticInfoMock(Session session)
            : base(session)
        {
        }

        int key;
        [Key(false)]
        public int Key
        {
            get { return key; }
            set { SetPropertyValue(nameof(Key), ref key, value); }
        }

        int info;
        //[Size(255)]
        public int Info
        {
            get { return info; }
            set { SetPropertyValue(nameof(Info), ref info, value); }
        }
       
    }
}

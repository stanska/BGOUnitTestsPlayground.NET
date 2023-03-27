using DevExpress.Utils.About;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyXpoApp
{

    public interface ISessionWrapper
    {
        Session Session { get; }

        int Count();

        StatisticInfoMockSession GetLastStisticalInfo();
    }
}

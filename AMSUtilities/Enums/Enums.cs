using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMSUtilities.Enums
{
    /// <summary>
    /// 
    /// </summary>
    public enum AlertMessageTypes
    {
        Success =0,
        Info = 1,
        Warning = 2,
        Danger = 3
    }

    /// <summary>
    /// Referring the values from AssetStatus table.
    /// </summary>
    public enum AssetTrackingStatus
    {
        New = 1,
        Assign = 2,
        Unassign = 3,
        Reassign = 4,
        Expire = 5,
        Renew = 6,
        Damage = 7,
        Scraped = 8,
        Retire = 9
    }
}

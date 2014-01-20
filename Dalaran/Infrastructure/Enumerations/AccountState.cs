using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Dalaran.Infrastructure.Enumerations
{
    public enum AccountState
    {
        [Description("Not Validated")]
        NotValidated,
        [Description("Active")]
        Active,
        [Description("Inactive")]
        Inactive,
        [Description("Banned")]
        Banned
    }
}
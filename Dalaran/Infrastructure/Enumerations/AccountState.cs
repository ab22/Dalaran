using System.ComponentModel;

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
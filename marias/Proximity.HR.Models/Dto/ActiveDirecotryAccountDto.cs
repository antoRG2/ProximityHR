using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Proximity.HR.Models.Dto
{
    public class ActiveDirecotryAccountDto
    {

        public string AccountName { get; set; }
        public string Email { get; set; }
        public string UserGroup { get; set; }
        public string DisplayName { get; set; }

    }

    [KnownType(typeof(ActiveDirecotryAccountDto))]
    public class ActiveDirecotryAccountsDto : List<ActiveDirecotryAccountDto> { }
}

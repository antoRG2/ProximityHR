using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Proximity.HR.Models.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsResource { get; set; }
        public bool IsProyectManager { get; set; }
        public bool Enabled { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string EditedBy { get; set; }
        public Nullable<System.DateTime> EditedDate { get; set; }

        public virtual ICollection<EmployeeDto> Employees { get; set; }
    }

    [KnownType(typeof(UserDto))]
    public class UsersDto : List<UserDto> { }
}

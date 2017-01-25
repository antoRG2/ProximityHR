using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Proximity.HR.Models.Dto
{
    public class SkillSetDto
    {
        public int Employee { get; set; }
        public int Feature { get; set; }
        public bool Teachable { get; set; }
        public bool Desirable { get; set; }
        public string Detail { get; set; }
        public bool Enabled { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string EditedBy { get; set; }
        public Nullable<System.DateTime> EditedDate { get; set; }
        public int Level { get; set; }
        //public ICollection<FeatureDto> Features { get; set; }
    }

    [KnownType(typeof(SkillSetDto))]
    public class SkillsSetDto : List<SkillSetDto> { }
}


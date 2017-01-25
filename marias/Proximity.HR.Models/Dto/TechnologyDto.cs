using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Proximity.HR.Models.Dto
{
    public class TechnologyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        public bool Enabled { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string EditedBy { get; set; }
        public Nullable<System.DateTime> EditedDate { get; set; }

        public List<FeatureDto> Features { get; set; }
    }

    [KnownType(typeof(TechnologyDto))]
    public class TechnologiesDto : List<TechnologyDto> { }
}

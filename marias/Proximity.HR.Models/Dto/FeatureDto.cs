using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Proximity.HR.Models.Dto
{
    public class FeatureDto
    {

        public int Id { get; set; }
        public int Technology { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        public bool Enabled { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string EditedBy { get; set; }
        public int Level { get; set; }
        public bool Teachable { get; set; }
        public bool Desirable { get; set; }
        public Nullable<System.DateTime> EditedDate { get; set; }
    }

    [KnownType(typeof(FeatureDto))]
    public class FeaturesDto : List<FeatureDto> { }
}


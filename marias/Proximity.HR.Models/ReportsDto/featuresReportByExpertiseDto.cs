using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Proximity.HR.Models.ReportsDto
{
   public  class featuresReportByExpertiseDto
    {
        public string EMPLOYEE { get; set; }

        public string FEATURE { get; set; }

        public int LEVEL { get; set; }
        //public string FullName { get; set; }

        //public string FeatureName { get; set; }

        //public int Level { get; set; }
    }

    [KnownType(typeof(featuresReportByExpertiseDto))]
    public class featRepByExpDto : List<featuresReportByExpertiseDto> { }
}

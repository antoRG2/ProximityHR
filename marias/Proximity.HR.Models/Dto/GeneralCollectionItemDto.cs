using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Proximity.HR.Models.Dto
{
    public class GeneralCollectionItemDto
    {
        public int Value { get; set; }
        public string Display { get; set; }
    }

    [KnownType(typeof(GeneralCollectionDto))]
    public class GeneralCollectionDto : List<GeneralCollectionItemDto> { }
}

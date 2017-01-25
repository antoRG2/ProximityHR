using AutoMapper;
using Proximity.HR.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proximity.HR.Data.Repository
{
    public class GeneralDataRepository
    {
        private ProximityHREntities _proximityHREntities;

        public GeneralDataRepository()
        {
            _proximityHREntities = new ProximityHREntities();
            MappingBase.Configure();
          
        }


        public GeneralCollectionDto GetCountries()
        {
            var result = new GeneralCollectionDto();
            var data = _proximityHREntities.Countries;

            result.AddRange(from Country country in data select Mapper.Map<Country, GeneralCollectionItemDto>(country));

            return result;
        }


        public GeneralCollectionDto GetStates(int countryId)
        {
            var result = new GeneralCollectionDto();
            var data = _proximityHREntities.States.Select(x => x.Country == countryId);

            result.AddRange(from State state in data select Mapper.Map<State, GeneralCollectionItemDto>(state));

            return result;
        }



        public GeneralCollectionDto GetCities(int stateId) {
            var result = new GeneralCollectionDto();
            var data = _proximityHREntities.Cities.Select(x => x.State == stateId);
     
                result.AddRange(from City citi in data select Mapper.Map<City,GeneralCollectionItemDto>(citi));
         
            return result;
        }


        public GeneralCollectionDto GetDistrict(int cityId)
        {
            var result = new GeneralCollectionDto();
            var data = _proximityHREntities.Districts.Select(x => x.City  == cityId);

            result.AddRange(from District district in data select Mapper.Map<District, GeneralCollectionItemDto>(district));

            return result;
        }
    }
}
